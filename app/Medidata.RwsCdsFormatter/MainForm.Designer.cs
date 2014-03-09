namespace Medidata.RwsCdsFormatter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.sourceOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.sourceFileTextBox = new System.Windows.Forms.TextBox();
            this.sourceBrowseButton = new System.Windows.Forms.Button();
            this.outputBrowseButton = new System.Windows.Forms.Button();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.formatButton = new System.Windows.Forms.Button();
            this.rowTemplateTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceOpenFileDialog
            // 
            this.sourceOpenFileDialog.DefaultExt = "csv";
            this.sourceOpenFileDialog.Filter = "CSV (comma delimited) (*.csv)|*.csv|All Files (*.*)|*.*";
            this.sourceOpenFileDialog.Title = "Choose source data file";
            // 
            // outputSaveFileDialog
            // 
            this.outputSaveFileDialog.DefaultExt = "xml";
            this.outputSaveFileDialog.Filter = "XML Data (*.xml)|*.xml|All Files (*.*)|*.*";
            this.outputSaveFileDialog.Title = "Set file for output";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(539, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source data file:";
            // 
            // sourceFileTextBox
            // 
            this.sourceFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceFileTextBox.Location = new System.Drawing.Point(102, 29);
            this.sourceFileTextBox.Name = "sourceFileTextBox";
            this.sourceFileTextBox.Size = new System.Drawing.Size(344, 20);
            this.sourceFileTextBox.TabIndex = 2;
            // 
            // sourceBrowseButton
            // 
            this.sourceBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceBrowseButton.Location = new System.Drawing.Point(452, 27);
            this.sourceBrowseButton.Name = "sourceBrowseButton";
            this.sourceBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.sourceBrowseButton.TabIndex = 3;
            this.sourceBrowseButton.Text = "Browse";
            this.sourceBrowseButton.UseVisualStyleBackColor = true;
            this.sourceBrowseButton.Click += new System.EventHandler(this.sourceBrowseButton_Click);
            // 
            // outputBrowseButton
            // 
            this.outputBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBrowseButton.Location = new System.Drawing.Point(452, 53);
            this.outputBrowseButton.Name = "outputBrowseButton";
            this.outputBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.outputBrowseButton.TabIndex = 6;
            this.outputBrowseButton.Text = "Browse";
            this.outputBrowseButton.UseVisualStyleBackColor = true;
            this.outputBrowseButton.Click += new System.EventHandler(this.outputBrowseButton_Click);
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFileTextBox.Location = new System.Drawing.Point(102, 55);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.Size = new System.Drawing.Size(344, 20);
            this.outputFileTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output file:";
            // 
            // formatButton
            // 
            this.formatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.formatButton.Location = new System.Drawing.Point(452, 297);
            this.formatButton.Name = "formatButton";
            this.formatButton.Size = new System.Drawing.Size(75, 23);
            this.formatButton.TabIndex = 9;
            this.formatButton.Text = "Format";
            this.formatButton.UseVisualStyleBackColor = true;
            this.formatButton.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // rowTemplateTextBox
            // 
            this.rowTemplateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowTemplateTextBox.Location = new System.Drawing.Point(102, 81);
            this.rowTemplateTextBox.MaxLength = 65535;
            this.rowTemplateTextBox.Multiline = true;
            this.rowTemplateTextBox.Name = "rowTemplateTextBox";
            this.rowTemplateTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rowTemplateTextBox.Size = new System.Drawing.Size(425, 210);
            this.rowTemplateTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Row template:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 332);
            this.Controls.Add(this.formatButton);
            this.Controls.Add(this.rowTemplateTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputBrowseButton);
            this.Controls.Add(this.outputFileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sourceBrowseButton);
            this.Controls.Add(this.sourceFileTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "RWS Configurable Dataset Formatter";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog sourceOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog outputSaveFileDialog;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sourceFileTextBox;
        private System.Windows.Forms.Button sourceBrowseButton;
        private System.Windows.Forms.Button outputBrowseButton;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button formatButton;
        private System.Windows.Forms.TextBox rowTemplateTextBox;
        private System.Windows.Forms.Label label3;
    }
}

