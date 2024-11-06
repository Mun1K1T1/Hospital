namespace Laboratory_2
{
    partial class MainPage
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
            this.CleaningWorkerBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.CleaningManagerBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.PatientBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.DoctorBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.NurseBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CleaningWorkerBtn);
            this.groupBox1.Controls.Add(this.CleaningManagerBtn);
            this.groupBox1.Controls.Add(this.PatientBtn);
            this.groupBox1.Controls.Add(this.DoctorBtn);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.NurseBtn);
            this.groupBox1.Location = new System.Drawing.Point(13, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 145);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your role";
            // 
            // CleaningWorkerBtn
            // 
            this.CleaningWorkerBtn.AutoSize = true;
            this.CleaningWorkerBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CleaningWorkerBtn.Depth = 0;
            this.CleaningWorkerBtn.Icon = null;
            this.CleaningWorkerBtn.Location = new System.Drawing.Point(260, 85);
            this.CleaningWorkerBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CleaningWorkerBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CleaningWorkerBtn.Name = "CleaningWorkerBtn";
            this.CleaningWorkerBtn.Primary = false;
            this.CleaningWorkerBtn.Size = new System.Drawing.Size(178, 36);
            this.CleaningWorkerBtn.TabIndex = 34;
            this.CleaningWorkerBtn.Text = "Cleaning worker";
            this.CleaningWorkerBtn.UseVisualStyleBackColor = true;
            this.CleaningWorkerBtn.Click += new System.EventHandler(this.CleaningWorkerBtn_Click);
            // 
            // CleaningManagerBtn
            // 
            this.CleaningManagerBtn.AutoSize = true;
            this.CleaningManagerBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CleaningManagerBtn.Depth = 0;
            this.CleaningManagerBtn.Icon = null;
            this.CleaningManagerBtn.Location = new System.Drawing.Point(49, 85);
            this.CleaningManagerBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CleaningManagerBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.CleaningManagerBtn.Name = "CleaningManagerBtn";
            this.CleaningManagerBtn.Primary = false;
            this.CleaningManagerBtn.Size = new System.Drawing.Size(191, 36);
            this.CleaningManagerBtn.TabIndex = 33;
            this.CleaningManagerBtn.Text = "Cleaning Manager";
            this.CleaningManagerBtn.UseVisualStyleBackColor = true;
            this.CleaningManagerBtn.Click += new System.EventHandler(this.CleaningManagerBtn_Click);
            // 
            // PatientBtn
            // 
            this.PatientBtn.AutoSize = true;
            this.PatientBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PatientBtn.Depth = 0;
            this.PatientBtn.Icon = null;
            this.PatientBtn.Location = new System.Drawing.Point(24, 37);
            this.PatientBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PatientBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.PatientBtn.Name = "PatientBtn";
            this.PatientBtn.Primary = false;
            this.PatientBtn.Size = new System.Drawing.Size(92, 36);
            this.PatientBtn.TabIndex = 32;
            this.PatientBtn.Text = "Patient";
            this.PatientBtn.UseVisualStyleBackColor = true;
            this.PatientBtn.Click += new System.EventHandler(this.PatientBtn_Click);
            // 
            // DoctorBtn
            // 
            this.DoctorBtn.AutoSize = true;
            this.DoctorBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DoctorBtn.Depth = 0;
            this.DoctorBtn.Icon = null;
            this.DoctorBtn.Location = new System.Drawing.Point(197, 37);
            this.DoctorBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DoctorBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.DoctorBtn.Name = "DoctorBtn";
            this.DoctorBtn.Primary = false;
            this.DoctorBtn.Size = new System.Drawing.Size(89, 36);
            this.DoctorBtn.TabIndex = 30;
            this.DoctorBtn.Text = "Doctor";
            this.DoctorBtn.UseVisualStyleBackColor = true;
            this.DoctorBtn.Click += new System.EventHandler(this.DoctorBtn_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(180, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(119, 24);
            this.materialLabel4.TabIndex = 28;
            this.materialLabel4.Text = "Who are you:";
            // 
            // NurseBtn
            // 
            this.NurseBtn.AutoSize = true;
            this.NurseBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NurseBtn.Depth = 0;
            this.NurseBtn.Icon = null;
            this.NurseBtn.Location = new System.Drawing.Point(380, 37);
            this.NurseBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.NurseBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.NurseBtn.Name = "NurseBtn";
            this.NurseBtn.Primary = false;
            this.NurseBtn.Size = new System.Drawing.Size(76, 36);
            this.NurseBtn.TabIndex = 31;
            this.NurseBtn.Text = "Nurse";
            this.NurseBtn.UseVisualStyleBackColor = true;
            this.NurseBtn.Click += new System.EventHandler(this.NurseBtn_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 229);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainPage";
            this.Text = "Role Choice";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialFlatButton DoctorBtn;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialFlatButton NurseBtn;
        private MaterialSkin.Controls.MaterialFlatButton PatientBtn;
        private MaterialSkin.Controls.MaterialFlatButton CleaningWorkerBtn;
        private MaterialSkin.Controls.MaterialFlatButton CleaningManagerBtn;
    }
}

