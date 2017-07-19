namespace PDFShrink
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDir = new System.Windows.Forms.Button();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.btnFlatten = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnCont = new System.Windows.Forms.Button();
            this.cbCopyFiles = new System.Windows.Forms.CheckBox();
            this.cbMakeDir = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.btnCloseReaders = new System.Windows.Forms.Button();
            this.cbPrintAll = new System.Windows.Forms.CheckBox();
            this.cbResetPrinter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnDir
            // 
            this.btnDir.Location = new System.Drawing.Point(573, 12);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(176, 23);
            this.btnDir.TabIndex = 0;
            this.btnDir.Text = "Choose Directory";
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(267, 13);
            this.lblDirectory.MaximumSize = new System.Drawing.Size(300, 20);
            this.lblDirectory.MinimumSize = new System.Drawing.Size(300, 20);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDirectory.Size = new System.Drawing.Size(300, 20);
            this.lblDirectory.TabIndex = 1;
            this.lblDirectory.Text = "No directory Selected";
            this.lblDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFlatten
            // 
            this.btnFlatten.Location = new System.Drawing.Point(269, 68);
            this.btnFlatten.Name = "btnFlatten";
            this.btnFlatten.Size = new System.Drawing.Size(386, 25);
            this.btnFlatten.TabIndex = 2;
            this.btnFlatten.Text = "Flatten and Print";
            this.btnFlatten.UseVisualStyleBackColor = true;
            this.btnFlatten.Click += new System.EventHandler(this.btnFlatten_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(268, 112);
            this.lblMsg.MaximumSize = new System.Drawing.Size(300, 20);
            this.lblMsg.MinimumSize = new System.Drawing.Size(300, 20);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(300, 20);
            this.lblMsg.TabIndex = 3;
            // 
            // btnCont
            // 
            this.btnCont.Location = new System.Drawing.Point(269, 106);
            this.btnCont.Name = "btnCont";
            this.btnCont.Size = new System.Drawing.Size(386, 23);
            this.btnCont.TabIndex = 4;
            this.btnCont.Text = "Finish Printing";
            this.btnCont.UseVisualStyleBackColor = true;
            this.btnCont.Click += new System.EventHandler(this.btnCont_Click);
            // 
            // cbCopyFiles
            // 
            this.cbCopyFiles.AutoSize = true;
            this.cbCopyFiles.Location = new System.Drawing.Point(271, 37);
            this.cbCopyFiles.Name = "cbCopyFiles";
            this.cbCopyFiles.Size = new System.Drawing.Size(165, 17);
            this.cbCopyFiles.TabIndex = 5;
            this.cbCopyFiles.Text = "Copy Files to Small Directory?";
            this.cbCopyFiles.UseVisualStyleBackColor = true;
            // 
            // cbMakeDir
            // 
            this.cbMakeDir.AutoSize = true;
            this.cbMakeDir.Checked = true;
            this.cbMakeDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMakeDir.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.cbMakeDir.Location = new System.Drawing.Point(481, 37);
            this.cbMakeDir.Name = "cbMakeDir";
            this.cbMakeDir.Size = new System.Drawing.Size(153, 17);
            this.cbMakeDir.TabIndex = 6;
            this.cbMakeDir.Text = "Create small_files subfolder";
            this.cbMakeDir.UseMnemonic = false;
            this.cbMakeDir.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(248, 316);
            this.listBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Set Printer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbConsole
            // 
            this.tbConsole.Location = new System.Drawing.Point(272, 171);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(477, 200);
            this.tbConsole.TabIndex = 9;
            // 
            // btnCloseReaders
            // 
            this.btnCloseReaders.Location = new System.Drawing.Point(269, 142);
            this.btnCloseReaders.Name = "btnCloseReaders";
            this.btnCloseReaders.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCloseReaders.Size = new System.Drawing.Size(386, 23);
            this.btnCloseReaders.TabIndex = 10;
            this.btnCloseReaders.Text = "Close All Reader Windows";
            this.btnCloseReaders.UseVisualStyleBackColor = true;
            this.btnCloseReaders.Click += new System.EventHandler(this.btnCloseReaders_Click);
            // 
            // cbPrintAll
            // 
            this.cbPrintAll.AutoSize = true;
            this.cbPrintAll.Location = new System.Drawing.Point(651, 37);
            this.cbPrintAll.Name = "cbPrintAll";
            this.cbPrintAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbPrintAll.Size = new System.Drawing.Size(103, 17);
            this.cbPrintAll.TabIndex = 11;
            this.cbPrintAll.Text = "Print All At Once";
            this.cbPrintAll.UseVisualStyleBackColor = false;
            // 
            // cbResetPrinter
            // 
            this.cbResetPrinter.AutoSize = true;
            this.cbResetPrinter.Location = new System.Drawing.Point(95, 339);
            this.cbResetPrinter.Name = "cbResetPrinter";
            this.cbResetPrinter.Size = new System.Drawing.Size(120, 17);
            this.cbResetPrinter.TabIndex = 12;
            this.cbResetPrinter.Text = "Reset printer on exit";
            this.cbResetPrinter.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 381);
            this.Controls.Add(this.cbResetPrinter);
            this.Controls.Add(this.cbPrintAll);
            this.Controls.Add(this.btnCloseReaders);
            this.Controls.Add(this.tbConsole);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cbMakeDir);
            this.Controls.Add(this.cbCopyFiles);
            this.Controls.Add(this.btnCont);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnFlatten);
            this.Controls.Add(this.lblDirectory);
            this.Controls.Add(this.btnDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PDF Mass Printer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDir;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.Button btnFlatten;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnCont;
        private System.Windows.Forms.CheckBox cbCopyFiles;
        private System.Windows.Forms.CheckBox cbMakeDir;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Button btnCloseReaders;
        private System.Windows.Forms.CheckBox cbPrintAll;
        private System.Windows.Forms.CheckBox cbResetPrinter;
    }
}

