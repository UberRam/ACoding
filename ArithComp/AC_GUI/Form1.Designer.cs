namespace AC_GUI
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
            this.sourceOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.targetLabel = new System.Windows.Forms.Label();
            this.sourceText = new System.Windows.Forms.TextBox();
            this.targetText = new System.Windows.Forms.TextBox();
            this.browseSourceButton = new System.Windows.Forms.Button();
            this.browseTargetButton = new System.Windows.Forms.Button();
            this.targetOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.encodeButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.sourceFileSizeLabel = new System.Windows.Forms.Label();
            this.targetFileSizeLabel = new System.Windows.Forms.Label();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            this.timeValueText = new System.Windows.Forms.TextBox();
            this.compressionRatioValueText = new System.Windows.Forms.TextBox();
            this.targetFileSizeValueText = new System.Windows.Forms.TextBox();
            this.sourceFileSizeValueText = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.compressionRatioLabel = new System.Windows.Forms.Label();
            this.grpLZW = new System.Windows.Forms.GroupBox();
            this.btnDecLZW = new System.Windows.Forms.Button();
            this.btnEncLZW = new System.Windows.Forms.Button();
            this.crcGroup = new System.Windows.Forms.GroupBox();
            this.btnCRCEnc = new System.Windows.Forms.Button();
            this.btnCRCDec = new System.Windows.Forms.Button();
            this.txtCRCLen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCRCpolynomial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.infoGroupBox.SuspendLayout();
            this.grpLZW.SuspendLayout();
            this.crcGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceOpenFileDialog
            // 
            this.sourceOpenFileDialog.FileName = "openFileDialog1";
            this.sourceOpenFileDialog.SupportMultiDottedExtensions = true;
            this.sourceOpenFileDialog.Title = "Browse the Source File";
            this.sourceOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.sourceOpenFileDialog_FileOk);
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(11, 22);
            this.sourceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(60, 13);
            this.sourceLabel.TabIndex = 0;
            this.sourceLabel.Text = "SourceFile:";
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.Location = new System.Drawing.Point(11, 50);
            this.targetLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(57, 13);
            this.targetLabel.TabIndex = 1;
            this.targetLabel.Text = "TargetFile:";
            // 
            // sourceText
            // 
            this.sourceText.Location = new System.Drawing.Point(75, 19);
            this.sourceText.Margin = new System.Windows.Forms.Padding(2);
            this.sourceText.Name = "sourceText";
            this.sourceText.Size = new System.Drawing.Size(359, 20);
            this.sourceText.TabIndex = 2;
            // 
            // targetText
            // 
            this.targetText.Location = new System.Drawing.Point(75, 48);
            this.targetText.Margin = new System.Windows.Forms.Padding(2);
            this.targetText.Name = "targetText";
            this.targetText.Size = new System.Drawing.Size(359, 20);
            this.targetText.TabIndex = 3;
            // 
            // browseSourceButton
            // 
            this.browseSourceButton.Location = new System.Drawing.Point(437, 18);
            this.browseSourceButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseSourceButton.Name = "browseSourceButton";
            this.browseSourceButton.Size = new System.Drawing.Size(109, 22);
            this.browseSourceButton.TabIndex = 4;
            this.browseSourceButton.Text = "Browse Source";
            this.browseSourceButton.UseVisualStyleBackColor = true;
            this.browseSourceButton.Click += new System.EventHandler(this.browseSourceButton_Click);
            // 
            // browseTargetButton
            // 
            this.browseTargetButton.Location = new System.Drawing.Point(437, 46);
            this.browseTargetButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseTargetButton.Name = "browseTargetButton";
            this.browseTargetButton.Size = new System.Drawing.Size(109, 21);
            this.browseTargetButton.TabIndex = 5;
            this.browseTargetButton.Text = "Browse Target";
            this.browseTargetButton.UseVisualStyleBackColor = true;
            this.browseTargetButton.Click += new System.EventHandler(this.browseTargetButton_Click);
            // 
            // targetOpenFileDialog
            // 
            this.targetOpenFileDialog.CheckFileExists = false;
            this.targetOpenFileDialog.CheckPathExists = false;
            this.targetOpenFileDialog.DefaultExt = "ac";
            this.targetOpenFileDialog.FileName = "openFileDialog1";
            this.targetOpenFileDialog.SupportMultiDottedExtensions = true;
            this.targetOpenFileDialog.Title = "Select Destination File";
            this.targetOpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.targetOpenFileDialog_FileOk);
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(11, 78);
            this.encodeButton.Margin = new System.Windows.Forms.Padding(2);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(242, 34);
            this.encodeButton.TabIndex = 6;
            this.encodeButton.Text = "Encode";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(331, 78);
            this.decodeButton.Margin = new System.Windows.Forms.Padding(2);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(215, 34);
            this.decodeButton.TabIndex = 7;
            this.decodeButton.Text = "Decode";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // sourceFileSizeLabel
            // 
            this.sourceFileSizeLabel.AutoSize = true;
            this.sourceFileSizeLabel.Location = new System.Drawing.Point(11, 22);
            this.sourceFileSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sourceFileSizeLabel.Name = "sourceFileSizeLabel";
            this.sourceFileSizeLabel.Size = new System.Drawing.Size(121, 13);
            this.sourceFileSizeLabel.TabIndex = 8;
            this.sourceFileSizeLabel.Text = "Source File Size (Bytes):";
            // 
            // targetFileSizeLabel
            // 
            this.targetFileSizeLabel.AutoSize = true;
            this.targetFileSizeLabel.Location = new System.Drawing.Point(14, 46);
            this.targetFileSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.targetFileSizeLabel.Name = "targetFileSizeLabel";
            this.targetFileSizeLabel.Size = new System.Drawing.Size(118, 13);
            this.targetFileSizeLabel.TabIndex = 9;
            this.targetFileSizeLabel.Text = "Target File Size (Bytes):";
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.Controls.Add(this.timeValueText);
            this.infoGroupBox.Controls.Add(this.compressionRatioValueText);
            this.infoGroupBox.Controls.Add(this.targetFileSizeValueText);
            this.infoGroupBox.Controls.Add(this.sourceFileSizeValueText);
            this.infoGroupBox.Controls.Add(this.timeLabel);
            this.infoGroupBox.Controls.Add(this.compressionRatioLabel);
            this.infoGroupBox.Controls.Add(this.sourceFileSizeLabel);
            this.infoGroupBox.Controls.Add(this.targetFileSizeLabel);
            this.infoGroupBox.Location = new System.Drawing.Point(14, 131);
            this.infoGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.infoGroupBox.Size = new System.Drawing.Size(530, 125);
            this.infoGroupBox.TabIndex = 10;
            this.infoGroupBox.TabStop = false;
            this.infoGroupBox.Text = "Information";
            // 
            // timeValueText
            // 
            this.timeValueText.Location = new System.Drawing.Point(138, 94);
            this.timeValueText.Margin = new System.Windows.Forms.Padding(2);
            this.timeValueText.Name = "timeValueText";
            this.timeValueText.ReadOnly = true;
            this.timeValueText.Size = new System.Drawing.Size(388, 20);
            this.timeValueText.TabIndex = 18;
            // 
            // compressionRatioValueText
            // 
            this.compressionRatioValueText.Location = new System.Drawing.Point(138, 70);
            this.compressionRatioValueText.Margin = new System.Windows.Forms.Padding(2);
            this.compressionRatioValueText.Name = "compressionRatioValueText";
            this.compressionRatioValueText.ReadOnly = true;
            this.compressionRatioValueText.Size = new System.Drawing.Size(388, 20);
            this.compressionRatioValueText.TabIndex = 17;
            // 
            // targetFileSizeValueText
            // 
            this.targetFileSizeValueText.Location = new System.Drawing.Point(138, 46);
            this.targetFileSizeValueText.Margin = new System.Windows.Forms.Padding(2);
            this.targetFileSizeValueText.Name = "targetFileSizeValueText";
            this.targetFileSizeValueText.ReadOnly = true;
            this.targetFileSizeValueText.Size = new System.Drawing.Size(388, 20);
            this.targetFileSizeValueText.TabIndex = 16;
            // 
            // sourceFileSizeValueText
            // 
            this.sourceFileSizeValueText.Location = new System.Drawing.Point(138, 22);
            this.sourceFileSizeValueText.Margin = new System.Windows.Forms.Padding(2);
            this.sourceFileSizeValueText.Name = "sourceFileSizeValueText";
            this.sourceFileSizeValueText.ReadOnly = true;
            this.sourceFileSizeValueText.Size = new System.Drawing.Size(388, 20);
            this.sourceFileSizeValueText.TabIndex = 11;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(78, 94);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(55, 13);
            this.timeLabel.TabIndex = 13;
            this.timeLabel.Text = "Time (ms):";
            // 
            // compressionRatioLabel
            // 
            this.compressionRatioLabel.AutoSize = true;
            this.compressionRatioLabel.Location = new System.Drawing.Point(36, 70);
            this.compressionRatioLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.compressionRatioLabel.Name = "compressionRatioLabel";
            this.compressionRatioLabel.Size = new System.Drawing.Size(98, 13);
            this.compressionRatioLabel.TabIndex = 12;
            this.compressionRatioLabel.Text = "Compression Ratio:";
            // 
            // grpLZW
            // 
            this.grpLZW.Controls.Add(this.btnDecLZW);
            this.grpLZW.Controls.Add(this.btnEncLZW);
            this.grpLZW.Location = new System.Drawing.Point(11, 266);
            this.grpLZW.Name = "grpLZW";
            this.grpLZW.Size = new System.Drawing.Size(532, 86);
            this.grpLZW.TabIndex = 11;
            this.grpLZW.TabStop = false;
            this.grpLZW.Text = "LZW";
            // 
            // btnDecLZW
            // 
            this.btnDecLZW.Location = new System.Drawing.Point(320, 33);
            this.btnDecLZW.Name = "btnDecLZW";
            this.btnDecLZW.Size = new System.Drawing.Size(206, 47);
            this.btnDecLZW.TabIndex = 1;
            this.btnDecLZW.Text = "Decode";
            this.btnDecLZW.UseVisualStyleBackColor = true;
            this.btnDecLZW.Click += new System.EventHandler(this.btnDecLZW_Click);
            // 
            // btnEncLZW
            // 
            this.btnEncLZW.Location = new System.Drawing.Point(17, 33);
            this.btnEncLZW.Name = "btnEncLZW";
            this.btnEncLZW.Size = new System.Drawing.Size(219, 47);
            this.btnEncLZW.TabIndex = 0;
            this.btnEncLZW.Text = "Encode";
            this.btnEncLZW.UseVisualStyleBackColor = true;
            this.btnEncLZW.Click += new System.EventHandler(this.btnEncLZW_Click);
            // 
            // crcGroup
            // 
            this.crcGroup.Controls.Add(this.label2);
            this.crcGroup.Controls.Add(this.txtCRCpolynomial);
            this.crcGroup.Controls.Add(this.label1);
            this.crcGroup.Controls.Add(this.txtCRCLen);
            this.crcGroup.Controls.Add(this.btnCRCDec);
            this.crcGroup.Controls.Add(this.btnCRCEnc);
            this.crcGroup.Location = new System.Drawing.Point(14, 362);
            this.crcGroup.Name = "crcGroup";
            this.crcGroup.Size = new System.Drawing.Size(529, 133);
            this.crcGroup.TabIndex = 12;
            this.crcGroup.TabStop = false;
            this.crcGroup.Text = "CRC";
            // 
            // btnCRCEnc
            // 
            this.btnCRCEnc.Location = new System.Drawing.Point(17, 77);
            this.btnCRCEnc.Name = "btnCRCEnc";
            this.btnCRCEnc.Size = new System.Drawing.Size(216, 50);
            this.btnCRCEnc.TabIndex = 0;
            this.btnCRCEnc.Text = "Encode";
            this.btnCRCEnc.UseVisualStyleBackColor = true;
            this.btnCRCEnc.Click += new System.EventHandler(this.btnCRCEnc_Click);
            // 
            // btnCRCDec
            // 
            this.btnCRCDec.Location = new System.Drawing.Point(317, 76);
            this.btnCRCDec.Name = "btnCRCDec";
            this.btnCRCDec.Size = new System.Drawing.Size(206, 51);
            this.btnCRCDec.TabIndex = 1;
            this.btnCRCDec.Text = "Decode";
            this.btnCRCDec.UseVisualStyleBackColor = true;
            this.btnCRCDec.Click += new System.EventHandler(this.btnCRCDec_Click);
            // 
            // txtCRCLen
            // 
            this.txtCRCLen.Location = new System.Drawing.Point(317, 20);
            this.txtCRCLen.Name = "txtCRCLen";
            this.txtCRCLen.Size = new System.Drawing.Size(206, 20);
            this.txtCRCLen.TabIndex = 2;
            this.txtCRCLen.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CRC length:";
            // 
            // txtCRCpolynomial
            // 
            this.txtCRCpolynomial.Location = new System.Drawing.Point(317, 47);
            this.txtCRCpolynomial.Name = "txtCRCpolynomial";
            this.txtCRCpolynomial.Size = new System.Drawing.Size(206, 20);
            this.txtCRCpolynomial.TabIndex = 4;
            this.txtCRCpolynomial.Text = "1011";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "CRC polynomial:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 507);
            this.Controls.Add(this.crcGroup);
            this.Controls.Add(this.grpLZW);
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.encodeButton);
            this.Controls.Add(this.browseTargetButton);
            this.Controls.Add(this.browseSourceButton);
            this.Controls.Add(this.targetText);
            this.Controls.Add(this.sourceText);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.sourceLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Kodowanie arytmetyczne";
            this.infoGroupBox.ResumeLayout(false);
            this.infoGroupBox.PerformLayout();
            this.grpLZW.ResumeLayout(false);
            this.crcGroup.ResumeLayout(false);
            this.crcGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog sourceOpenFileDialog;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.TextBox sourceText;
        private System.Windows.Forms.TextBox targetText;
        private System.Windows.Forms.Button browseSourceButton;
        private System.Windows.Forms.Button browseTargetButton;
        private System.Windows.Forms.OpenFileDialog targetOpenFileDialog;
        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Label sourceFileSizeLabel;
        private System.Windows.Forms.Label targetFileSizeLabel;
        private System.Windows.Forms.GroupBox infoGroupBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label compressionRatioLabel;
        private System.Windows.Forms.TextBox sourceFileSizeValueText;
        private System.Windows.Forms.TextBox timeValueText;
        private System.Windows.Forms.TextBox compressionRatioValueText;
        private System.Windows.Forms.TextBox targetFileSizeValueText;
        private System.Windows.Forms.GroupBox grpLZW;
        private System.Windows.Forms.Button btnDecLZW;
        private System.Windows.Forms.Button btnEncLZW;
        private System.Windows.Forms.GroupBox crcGroup;
        private System.Windows.Forms.Button btnCRCDec;
        private System.Windows.Forms.Button btnCRCEnc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCRCLen;
        private System.Windows.Forms.TextBox txtCRCpolynomial;
        private System.Windows.Forms.Label label2;
    }
}

