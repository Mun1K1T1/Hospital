namespace Laboratory_2
{
    partial class CleaningWorkerForm
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
            this.Worker_Key = new MaterialSkin.Controls.MaterialLabel();
            this.BackBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.CleaningWorkerNameTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CleaningTaskslistBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Worker_Key
            // 
            this.Worker_Key.AutoSize = true;
            this.Worker_Key.Depth = 0;
            this.Worker_Key.Font = new System.Drawing.Font("Roboto", 11F);
            this.Worker_Key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Worker_Key.Location = new System.Drawing.Point(12, 337);
            this.Worker_Key.MouseState = MaterialSkin.MouseState.HOVER;
            this.Worker_Key.Name = "Worker_Key";
            this.Worker_Key.Size = new System.Drawing.Size(90, 24);
            this.Worker_Key.TabIndex = 35;
            this.Worker_Key.Text = "Key_Here";
            this.Worker_Key.Visible = false;
            // 
            // BackBtn
            // 
            this.BackBtn.AutoSize = true;
            this.BackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBtn.Depth = 0;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.BackBtn.Icon = null;
            this.BackBtn.Location = new System.Drawing.Point(692, 27);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Primary = false;
            this.BackBtn.Size = new System.Drawing.Size(89, 36);
            this.BackBtn.TabIndex = 34;
            this.BackBtn.Text = "<- HOME";
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Cleaning Worker\'s Name";
            // 
            // CleaningWorkerNameTbx
            // 
            this.CleaningWorkerNameTbx.Location = new System.Drawing.Point(1, 82);
            this.CleaningWorkerNameTbx.Multiline = true;
            this.CleaningWorkerNameTbx.Name = "CleaningWorkerNameTbx";
            this.CleaningWorkerNameTbx.ReadOnly = true;
            this.CleaningWorkerNameTbx.Size = new System.Drawing.Size(263, 33);
            this.CleaningWorkerNameTbx.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tasks:";
            // 
            // CleaningTaskslistBox
            // 
            this.CleaningTaskslistBox.FormattingEnabled = true;
            this.CleaningTaskslistBox.ItemHeight = 16;
            this.CleaningTaskslistBox.Location = new System.Drawing.Point(468, 83);
            this.CleaningTaskslistBox.Name = "CleaningTaskslistBox";
            this.CleaningTaskslistBox.Size = new System.Drawing.Size(324, 276);
            this.CleaningTaskslistBox.TabIndex = 37;
            // 
            // CleaningWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 370);
            this.Controls.Add(this.CleaningTaskslistBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Worker_Key);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CleaningWorkerNameTbx);
            this.Name = "CleaningWorkerForm";
            this.Text = "CleaningWorkerForm";
            this.Load += new System.EventHandler(this.CleaningWorkerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel Worker_Key;
        private MaterialSkin.Controls.MaterialFlatButton BackBtn;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox CleaningWorkerNameTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CleaningTaskslistBox;
    }
}