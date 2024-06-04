namespace Laboratory_2
{
    partial class DoctorForm
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
            this.DocNameTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PatientFirstNameTxb = new System.Windows.Forms.TextBox();
            this.PatientSecNameTxb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TreatmentSubmissionBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PatientsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TreatmentTxtBx = new System.Windows.Forms.TextBox();
            this.BackBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DocNameTbx
            // 
            this.DocNameTbx.Location = new System.Drawing.Point(9, 85);
            this.DocNameTbx.Multiline = true;
            this.DocNameTbx.Name = "DocNameTbx";
            this.DocNameTbx.ReadOnly = true;
            this.DocNameTbx.Size = new System.Drawing.Size(263, 26);
            this.DocNameTbx.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Doctor\'s Name";
            // 
            // PatientFirstNameTxb
            // 
            this.PatientFirstNameTxb.Location = new System.Drawing.Point(9, 379);
            this.PatientFirstNameTxb.Multiline = true;
            this.PatientFirstNameTxb.Name = "PatientFirstNameTxb";
            this.PatientFirstNameTxb.ReadOnly = true;
            this.PatientFirstNameTxb.Size = new System.Drawing.Size(222, 28);
            this.PatientFirstNameTxb.TabIndex = 10;
            // 
            // PatientSecNameTxb
            // 
            this.PatientSecNameTxb.Location = new System.Drawing.Point(9, 413);
            this.PatientSecNameTxb.Multiline = true;
            this.PatientSecNameTxb.Name = "PatientSecNameTxb";
            this.PatientSecNameTxb.ReadOnly = true;
            this.PatientSecNameTxb.Size = new System.Drawing.Size(222, 28);
            this.PatientSecNameTxb.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "F. Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "S. Name";
            // 
            // TreatmentSubmissionBtn
            // 
            this.TreatmentSubmissionBtn.AutoSize = true;
            this.TreatmentSubmissionBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TreatmentSubmissionBtn.Depth = 0;
            this.TreatmentSubmissionBtn.Icon = null;
            this.TreatmentSubmissionBtn.Location = new System.Drawing.Point(478, 379);
            this.TreatmentSubmissionBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.TreatmentSubmissionBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.TreatmentSubmissionBtn.Name = "TreatmentSubmissionBtn";
            this.TreatmentSubmissionBtn.Primary = false;
            this.TreatmentSubmissionBtn.Size = new System.Drawing.Size(226, 36);
            this.TreatmentSubmissionBtn.TabIndex = 14;
            this.TreatmentSubmissionBtn.Text = "Submit the treatment";
            this.TreatmentSubmissionBtn.UseVisualStyleBackColor = true;
            this.TreatmentSubmissionBtn.Click += new System.EventHandler(this.TreatmentSubmissionBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PatientsListBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 256);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // PatientsListBox
            // 
            this.PatientsListBox.FormattingEnabled = true;
            this.PatientsListBox.ItemHeight = 16;
            this.PatientsListBox.Location = new System.Drawing.Point(6, 22);
            this.PatientsListBox.Name = "PatientsListBox";
            this.PatientsListBox.Size = new System.Drawing.Size(226, 228);
            this.PatientsListBox.TabIndex = 19;
            this.PatientsListBox.SelectedIndexChanged += new System.EventHandler(this.PatientsListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Write treatment for:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Treatments:";
            // 
            // TreatmentTxtBx
            // 
            this.TreatmentTxtBx.Location = new System.Drawing.Point(385, 85);
            this.TreatmentTxtBx.Multiline = true;
            this.TreatmentTxtBx.Name = "TreatmentTxtBx";
            this.TreatmentTxtBx.Size = new System.Drawing.Size(403, 264);
            this.TreatmentTxtBx.TabIndex = 17;
            // 
            // BackBtn
            // 
            this.BackBtn.AutoSize = true;
            this.BackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBtn.Depth = 0;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.BackBtn.Icon = null;
            this.BackBtn.Location = new System.Drawing.Point(703, 31);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Primary = false;
            this.BackBtn.Size = new System.Drawing.Size(89, 36);
            this.BackBtn.TabIndex = 18;
            this.BackBtn.Text = "<- HOME";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.TreatmentTxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TreatmentSubmissionBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PatientSecNameTxb);
            this.Controls.Add(this.PatientFirstNameTxb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DocNameTbx);
            this.Name = "DoctorForm";
            this.Text = "DoctorForm";
            this.Load += new System.EventHandler(this.DoctorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox DocNameTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PatientFirstNameTxb;
        private System.Windows.Forms.TextBox PatientSecNameTxb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialFlatButton TreatmentSubmissionBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox PatientsListBox;
        private System.Windows.Forms.TextBox TreatmentTxtBx;
        private MaterialSkin.Controls.MaterialFlatButton BackBtn;
    }
}