namespace Laboratory_2
{
    partial class PatientForm
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
            this.PatientNameTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TreatmentTxtBx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DischargeBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.BackBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // PatientNameTbx
            // 
            this.PatientNameTbx.Location = new System.Drawing.Point(3, 86);
            this.PatientNameTbx.Multiline = true;
            this.PatientNameTbx.Name = "PatientNameTbx";
            this.PatientNameTbx.ReadOnly = true;
            this.PatientNameTbx.Size = new System.Drawing.Size(263, 33);
            this.PatientNameTbx.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patient\'s Name";
            // 
            // TreatmentTxtBx
            // 
            this.TreatmentTxtBx.Location = new System.Drawing.Point(376, 86);
            this.TreatmentTxtBx.Multiline = true;
            this.TreatmentTxtBx.Name = "TreatmentTxtBx";
            this.TreatmentTxtBx.ReadOnly = true;
            this.TreatmentTxtBx.Size = new System.Drawing.Size(403, 199);
            this.TreatmentTxtBx.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Treatments:";
            // 
            // DischargeBtn
            // 
            this.DischargeBtn.AutoSize = true;
            this.DischargeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DischargeBtn.Depth = 0;
            this.DischargeBtn.Icon = null;
            this.DischargeBtn.Location = new System.Drawing.Point(664, 308);
            this.DischargeBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DischargeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.DischargeBtn.Name = "DischargeBtn";
            this.DischargeBtn.Primary = false;
            this.DischargeBtn.Size = new System.Drawing.Size(83, 36);
            this.DischargeBtn.TabIndex = 29;
            this.DischargeBtn.Text = "Refuse";
            this.DischargeBtn.UseVisualStyleBackColor = true;
            this.DischargeBtn.Click += new System.EventHandler(this.DischargeBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.AutoSize = true;
            this.BackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBtn.Depth = 0;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.BackBtn.Icon = null;
            this.BackBtn.Location = new System.Drawing.Point(694, 31);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Primary = false;
            this.BackBtn.Size = new System.Drawing.Size(89, 36);
            this.BackBtn.TabIndex = 30;
            this.BackBtn.Text = "<- HOME";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // PatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 370);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DischargeBtn);
            this.Controls.Add(this.TreatmentTxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PatientNameTbx);
            this.Name = "PatientForm";
            this.Text = "PatientForm";
            this.Load += new System.EventHandler(this.PatientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TreatmentTxtBx;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialFlatButton DischargeBtn;
        public System.Windows.Forms.TextBox PatientNameTbx;
        private MaterialSkin.Controls.MaterialFlatButton BackBtn;
    }
}