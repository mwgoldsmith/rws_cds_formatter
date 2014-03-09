using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotLiquid;

namespace Medidata.RwsCdsFormatter
{
    public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();
        }

        #region Control event handlers

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void sourceBrowseButton_Click(object sender, EventArgs e) {
            var result = sourceOpenFileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            sourceFileTextBox.Text = sourceOpenFileDialog.FileName;
        }

        private void outputBrowseButton_Click(object sender, EventArgs e) {
            var result = outputSaveFileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            outputFileTextBox.Text = outputSaveFileDialog.FileName;
        }

        private void formatButton_Click(object sender, EventArgs e) {
            formatButton.Enabled = false;

            FormatData(sourceFileTextBox.Text, outputFileTextBox.Text, rowTemplateTextBox.Text);

            formatButton.Enabled = true;
        }

        #endregion

        private void FormatData(string sourceFile, string outputFile, string rowTemplate) {
            var t = Template.Parse(rowTemplate);
            var lines = File.ReadAllLines(sourceFile).ToList();

            bool isFirst = true;
            Record previous = null, current = null, next;

            //ConfigurableDatasetRecordset is a Drop with a Name property
            //
            var request = new ConfigurableDatasetRequest { Guid = Guid.NewGuid(), Date = DateTime.Now };
            var document = new ConfigurableDatasetDocument();
            var recordset = new ConfigurableDatasetRecordset();
            var odm = new StringBuilder();

            document.Section = "header";
            Render(t, odm, document, request, null, null, null, null);

            for (int i = 2; i < lines.Count; i++) {
                Record record = BuildRecord(lines[0], lines[i]);

                //bad records
                if (record == null)
                    continue;

                if (isFirst) {
                    document.Section = "body";
                    record.IsFirst = true;
                    current = record;
                    isFirst = false;
                } else {
                    next = record;
                    Render(t, odm, document, request, recordset, previous, current, next);
                    previous = current;
                    current = next;
                }
            }

            //Render Last Record
            if (!isFirst) {
                current.IsLast = true;
                Render(t, odm, document, request, recordset, previous, current, null);
            }

            document.Section = "footer";
            Render(t, odm, document, request, null, null, null, null);

            File.WriteAllText(outputFile, odm.ToString(), Encoding.UTF8);
        }

        private static Record BuildRecord(string columns, string row) {
            string[] cols = columns.Split(',');
            string[] cells = row.Split(',');

            if (cols.Length != cells.Length)
                return null;

            Dictionary<string, string> stuff = new Dictionary<string, string>();

            for (int c = 0; c < cols.Length; c++) {
                stuff[cols[c]] = cells[c];
            }

            return new Record(stuff);
        }

        private static void Render(Template template,
                StringBuilder odm,
                ConfigurableDatasetDocument document,
                ConfigurableDatasetRequest request,
                ConfigurableDatasetRecordset recordset,
                Record previousRecord,
                Record currentRecord,
                Record nextRecord) {
            odm.Append(
                       template.Render(
                                       Hash.FromAnonymousObject(
                                                                new
                                                                {
                                                                    document = document.ToLiquid(),
                                                                    recordset = recordset == null ? null : recordset.ToLiquid(),
                                                                    request = request.ToLiquid(),
                                                                    previous = previousRecord == null ? null : previousRecord.ToLiquid(),
                                                                    current = currentRecord == null ? null : currentRecord.ToLiquid(),
                                                                    next = nextRecord == null ? null : nextRecord.ToLiquid()
                                                                })));
        }



        public class Record : ILiquidizable
        {
            public bool IsFirst { get; set; }
            public bool IsLast { get; set; }

            public IDictionary<string, string> AttributesCollection { get; protected set; }

            public Record(IDictionary<String, String> attributesCollection) {
                AttributesCollection = attributesCollection;
            }

            public virtual IDictionary<String, String> GetAttributes() {
                return AttributesCollection;
            }

            public override bool Equals(object obj) {
                var record = obj as Record;
                return record != null && record.AttributesCollection.DictionaryEquals(AttributesCollection);
            }

            public override int GetHashCode() {
                return AttributesCollection.GetHashCode();
            }

            public virtual object ToLiquid() {
                return new RecordDrop(this);
            }
        }

        /// <summary>
        /// RecordDrop wraps the record object in a liquidizable object
        /// </summary>
        public class RecordDrop : Drop
        {
            private Record record;

            public bool First {
                get { return record.IsFirst; }
            }

            public bool Last {
                get { return record.IsLast; }
            }



            public IDictionary<string, string> Attributes {
                get {
                    return record.GetAttributes();
                }
            }

            public RecordDrop() {
            }

            public RecordDrop(Record record) {
                this.record = record;
            }

            public override object BeforeMethod(string key) {
                return Attributes.Keys.Contains(key) ? Attributes[key] : String.Empty;
            }
        }

        public class ConfigurableDatasetRecordset : Drop
        {
            public string Name { get; set; }

            public override object ToLiquid() {
                return this;
            }
        }

        public class ConfigurableDatasetDocument : Drop
        {
            public string Section { get; set; }

            public override object ToLiquid() {
                return this;
            }
        }

        public class ConfigurableDatasetRequest : Drop
        {
            public Guid Guid { get; set; }
            public DateTime Date { get; set; }

            public string Id {
                get {
                    return Guid.ToString();
                }
            }

            public override object ToLiquid() {
                return this;
            }
        }
    }
}