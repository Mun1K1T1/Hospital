namespace Laboratory_2
{
    partial class NurseForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PatientsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PatientSecNameTxb = new System.Windows.Forms.TextBox();
            this.PatientFirstNameTxb = new System.Windows.Forms.TextBox();
            this.NurNameTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TreatmentTxtBx = new System.Windows.Forms.TextBox();
            this.PerformBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.DischargeBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.BackBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PatientsListBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 256);
            this.groupBox1.TabIndex = 22;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "S. Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "F. Name";
            // 
            // PatientSecNameTxb
            // 
            this.PatientSecNameTxb.Location = new System.Drawing.Point(7, 413);
            this.PatientSecNameTxb.Multiline = true;
            this.PatientSecNameTxb.Name = "PatientSecNameTxb";
            this.PatientSecNameTxb.ReadOnly = true;
            this.PatientSecNameTxb.Size = new System.Drawing.Size(222, 28);
            this.PatientSecNameTxb.TabIndex = 19;
            // 
            // PatientFirstNameTxb
            // 
            this.PatientFirstNameTxb.Location = new System.Drawing.Point(7, 379);
            this.PatientFirstNameTxb.Multiline = true;
            this.PatientFirstNameTxb.Name = "PatientFirstNameTxb";
            this.PatientFirstNameTxb.ReadOnly = true;
            this.PatientFirstNameTxb.Size = new System.Drawing.Size(222, 28);
            this.PatientFirstNameTxb.TabIndex = 18;
            // 
            // NurNameTbx
            // 
            this.NurNameTbx.Location = new System.Drawing.Point(7, 85);
            this.NurNameTbx.Multiline = true;
            this.NurNameTbx.Name = "NurNameTbx";
            this.NurNameTbx.ReadOnly = true;
            this.NurNameTbx.Size = new System.Drawing.Size(263, 26);
            this.NurNameTbx.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nurse\'s Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Treatments:";
            // 
            // TreatmentTxtBx
            // 
            this.TreatmentTxtBx.Location = new System.Drawing.Point(360, 85);
            this.TreatmentTxtBx.Multiline = true;
            this.TreatmentTxtBx.Name = "TreatmentTxtBx";
            this.TreatmentTxtBx.ReadOnly = true;
            this.TreatmentTxtBx.Size = new System.Drawing.Size(403, 264);
            this.TreatmentTxtBx.TabIndex = 26;
            // 
            // PerformBtn
            // 
            this.PerformBtn.AutoSize = true;
            this.PerformBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PerformBtn.Depth = 0;
            this.PerformBtn.Icon = null;
            this.PerformBtn.Location = new System.Drawing.Point(528, 371);
            this.PerformBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PerformBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.PerformBtn.Name = "PerformBtn";
            this.PerformBtn.Primary = false;
            this.PerformBtn.Size = new System.Drawing.Size(100, 36);
            this.PerformBtn.TabIndex = 27;
            this.PerformBtn.Text = "Perform";
            this.PerformBtn.UseVisualStyleBackColor = true;
            this.PerformBtn.Click += new System.EventHandler(this.MaterialFlatButton1_Click);
            // 
            // DischargeBtn
            // 
            this.DischargeBtn.AutoSize = true;
            this.DischargeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DischargeBtn.Depth = 0;
            this.DischargeBtn.Icon = null;
            this.DischargeBtn.Location = new System.Drawing.Point(648, 371);
            this.DischargeBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DischargeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.DischargeBtn.Name = "DischargeBtn";
            this.DischargeBtn.Primary = false;
            this.DischargeBtn.Size = new System.Drawing.Size(115, 36);
            this.DischargeBtn.TabIndex = 28;
            this.DischargeBtn.Text = "Discharge";
            this.DischargeBtn.UseVisualStyleBackColor = true;
            this.DischargeBtn.Click += new System.EventHandler(this.MaterialFlatButton2_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.AutoSize = true;
            this.BackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBtn.Depth = 0;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.BackBtn.Icon = null;
            this.BackBtn.Location = new System.Drawing.Point(673, 35);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Primary = false;
            this.BackBtn.Size = new System.Drawing.Size(89, 36);
            this.BackBtn.TabIndex = 29;
            this.BackBtn.Text = "<- HOME";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // NurseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DischargeBtn);
            this.Controls.Add(this.PerformBtn);
            this.Controls.Add(this.TreatmentTxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PatientSecNameTxb);
            this.Controls.Add(this.PatientFirstNameTxb);
            this.Controls.Add(this.NurNameTbx);
            this.Name = "NurseForm";
            this.Text = "NurseForm";
            this.Load += new System.EventHandler(this.NurseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox PatientsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PatientSecNameTxb;
        private System.Windows.Forms.TextBox PatientFirstNameTxb;
        private System.Windows.Forms.TextBox NurNameTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TreatmentTxtBx;
        private MaterialSkin.Controls.MaterialFlatButton PerformBtn;
        private MaterialSkin.Controls.MaterialFlatButton DischargeBtn;
        private MaterialSkin.Controls.MaterialFlatButton BackBtn;
    }
}