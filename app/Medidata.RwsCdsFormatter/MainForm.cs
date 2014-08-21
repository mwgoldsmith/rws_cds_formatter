using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DotLiquid;
using Medidata.RwsCdsFormatter.Liquid;

namespace Medidata.RwsCdsFormatter
{
    public partial class MainForm : Form
    {
        #region Private fields

        private bool _running;
        private string _template;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public MainForm() {
            InitializeComponent();
        }

        #endregion

        #region Control event handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sourceBrowseButton_Click(object sender, EventArgs e) {
            var result = sourceOpenFileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            sourceFileTextBox.Text = sourceOpenFileDialog.FileName;
            formatButton.Enabled = CanEnableFormatButton();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputBrowseButton_Click(object sender, EventArgs e) {
            var result = outputSaveFileDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            outputFileTextBox.Text = outputSaveFileDialog.FileName;
            formatButton.Enabled = CanEnableFormatButton();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputFileTextBox_TextChanged(object sender, EventArgs e) {
            formatButton.Enabled = CanEnableFormatButton();
        }

        private void sourceFileTextBox_TextChanged(object sender, EventArgs e) {
            formatButton.Enabled = CanEnableFormatButton();
        }

        private void rowTemplateTextBox_TextChanged(object sender, EventArgs e) {
            formatButton.Enabled = CanEnableFormatButton();
            prettyPrintButton.Enabled = rowTemplateTextBox.Text.Length > 0;
        }

        private void prettyPrintButton_Click(object sender, EventArgs e) {
            if (_template != null) {
                rowTemplateTextBox.Text = _template;
                _template = null;
                prettyPrintButton.Text = @"Pretty";
            } else {
                _template = rowTemplateTextBox.Text;
                var nl = Environment.NewLine;
                var pretty= Regex.Replace(_template, @"\{%",nl +  @"{%");
                rowTemplateTextBox.Text = Regex.Replace(pretty, @"%\}", @"%}" + nl);
                prettyPrintButton.Text = @"Unpretty";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatButton_Click(object sender, EventArgs e) {
            formatButton.Enabled = false;

            _running = true;
            FormatData(sourceFileTextBox.Text, outputFileTextBox.Text, _template ?? rowTemplateTextBox.Text);
            _running = false;

            formatButton.Enabled = CanEnableFormatButton();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CanEnableFormatButton() {
            var outputFile =outputFileTextBox.Text;
            var sourceFile = sourceFileTextBox.Text;
            var templateText = rowTemplateTextBox.Text;
            var enabled = true;

            enabled &= outputFile.Length > 0;
            enabled &= sourceFile.Length > 0;
            enabled &= templateText.Length > 0;

            try {
                enabled &= File.Exists(sourceFile);
            } catch (Exception ex) {
                Debug.WriteLine("CEFB-0100: " + ex.Message);
            }

            return enabled && !_running;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="rowTemplate"></param>
        private static void FormatData(string sourceFile, string outputFile, string rowTemplate) {
            var isFirst = true;
            Record previous = null;
            Record current = null;
            List<string> lines;
            var sb = new StringBuilder();

            var t = Template.Parse(rowTemplate);
            if (t.Errors != null && t.Errors.Count > 0) {
                sb.AppendLine("The following template occurred: ");
                foreach (var e in t.Errors) {
                    sb.AppendLine(e.Message);
                }

                MessageBox.Show(sb.ToString());
                return;
            }
            try {
                lines = File.ReadAllLines(sourceFile).ToList();
            } catch (Exception ex) {
                MessageBox.Show(@"The following occurred: " + ex.Message);
                return;
            }

            //ConfigurableDatasetRecordset is a Drop with a Name property
            var request = new ConfigurableDatasetRequest { Guid = Guid.NewGuid(), Date = DateTime.Now };
            var document = new ConfigurableDatasetDocument();
            var recordset = new ConfigurableDatasetRecordset();

            document.Section = "header";
            Render(new RenderTemplate(t, sb, document, request));

            for (var i = 2; i < lines.Count; i++) {
                var record = BuildRecord(lines[0], lines[i]);

                //bad records
                if (record == null)
                    continue;

                if (isFirst) {
                    document.Section = "body";
                    record.IsFirst = true;
                    current = record;
                    isFirst = false;
                } else {
                    var next = record;
                    var rt = new RenderTemplate(t, sb, document, request)
                    {
                        Recordset = recordset,
                        PreviousRecord = previous,
                        CurrentRecord = next
                    };

                    Render(rt);
                    previous = current;
                    current = next;
                }
            }

            //Render Last Record
            if (!isFirst) {
                current.IsLast = true;
                var rt = new RenderTemplate(t, sb, document, request)
                {
                    Recordset = recordset,
                    PreviousRecord = previous, 
                    CurrentRecord = current
                };

                Render(rt);
            }

            document.Section = "footer";
            Render(new RenderTemplate(t, sb, document, request));

            try {
                File.WriteAllText(outputFile, sb.ToString(), Encoding.UTF8);
            } catch (Exception ex) {
                MessageBox.Show(@"Failed to save output: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Record BuildRecord(string columns, string row) {
            var cols = columns.Split(',');
            var cells = row.Split(',');

            if (cols.Length != cells.Length)
                return null;

            var stuff = new Dictionary<string, string>();

            for (var c = 0; c < cols.Length; c++) {
                stuff[cols[c]] = cells[c];
            }

            return new Record(stuff);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rt"></param>
        private static void Render(RenderTemplate rt) {
            var anon =
                new
                {
                    document = rt.Document.ToLiquid(),
                    recordset = rt.Recordset == null ? null : rt.Recordset.ToLiquid(),
                    request = rt.Request.ToLiquid(),
                    previous = rt.PreviousRecord == null ? null : rt.PreviousRecord.ToLiquid(),
                    current = rt.CurrentRecord == null ? null : rt.CurrentRecord.ToLiquid(),
                    next = rt.NextRecord == null ? null : rt.NextRecord.ToLiquid()
                };

            rt.Odm.Append(rt.Template.Render(Hash.FromAnonymousObject(anon)));
        }

        #endregion
    }
}