namespace Laboratory_2
{
    partial class CleaningManagerForm
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
            this.CleaningManager_Key = new MaterialSkin.Controls.MaterialLabel();
            this.BackBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.CleaningManagerNameTbx = new System.Windows.Forms.TextBox();
            this.WorkersListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CleaningWorker_Key = new MaterialSkin.Controls.MaterialLabel();
            this.CleaningTaskTxtBx = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CleaningManager_Key
            // 
            this.CleaningManager_Key.AutoSize = true;
            this.CleaningManager_Key.Depth = 0;
            this.CleaningManager_Key.Font = new System.Drawing.Font("Roboto", 11F);
            this.CleaningManager_Key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CleaningManager_Key.Location = new System.Drawing.Point(252, 37);
            this.CleaningManager_Key.MouseState = MaterialSkin.MouseState.HOVER;
            this.CleaningManager_Key.Name = "CleaningManager_Key";
            this.CleaningManager_Key.Size = new System.Drawing.Size(164, 24);
            this.CleaningManager_Key.TabIndex = 39;
            this.CleaningManager_Key.Text = "ManagerKey_Here";
            this.CleaningManager_Key.Visible = false;
            // 
            // BackBtn
            // 
            this.BackBtn.AutoSize = true;
            this.BackBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackBtn.Depth = 0;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.BackBtn.Icon = null;
            this.BackBtn.Location = new System.Drawing.Point(698, 25);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Primary = false;
            this.BackBtn.Size = new System.Drawing.Size(89, 36);
            this.BackBtn.TabIndex = 38;
            this.BackBtn.Text = "<- HOME";
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Cleaning Manager\'s Name";
            // 
            // CleaningManagerNameTbx
            // 
            this.CleaningManagerNameTbx.Location = new System.Drawing.Point(7, 86);
            this.CleaningManagerNameTbx.Multiline = true;
            this.CleaningManagerNameTbx.Name = "CleaningManagerNameTbx";
            this.CleaningManagerNameTbx.ReadOnly = true;
            this.CleaningManagerNameTbx.Size = new System.Drawing.Size(263, 33);
            this.CleaningManagerNameTbx.TabIndex = 36;
            // 
            // WorkersListBox
            // 
            this.WorkersListBox.FormattingEnabled = true;
            this.WorkersListBox.ItemHeight = 16;
            this.WorkersListBox.Location = new System.Drawing.Point(6, 22);
            this.WorkersListBox.Name = "WorkersListBox";
            this.WorkersListBox.Size = new System.Drawing.Size(226, 228);
            this.WorkersListBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Choose the worker:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WorkersListBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 256);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // CleaningWorker_Key
            // 
            this.CleaningWorker_Key.AutoSize = true;
            this.CleaningWorker_Key.Depth = 0;
            this.CleaningWorker_Key.Font = new System.Drawing.Font("Roboto", 11F);
            this.CleaningWorker_Key.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CleaningWorker_Key.Location = new System.Drawing.Point(506, 403);
            this.CleaningWorker_Key.MouseState = MaterialSkin.MouseState.HOVER;
            this.CleaningWorker_Key.Name = "CleaningWorker_Key";
            this.CleaningWorker_Key.Size = new System.Drawing.Size(150, 24);
            this.CleaningWorker_Key.TabIndex = 41;
            this.CleaningWorker_Key.Text = "WorkerKey_Here";
            this.CleaningWorker_Key.Visible = false;
            // 
            // CleaningTaskTxtBx
            // 
            this.CleaningTaskTxtBx.Location = new System.Drawing.Point(372, 86);
            this.CleaningTaskTxtBx.Multiline = true;
            this.CleaningTaskTxtBx.Name = "CleaningTaskTxtBx";
            this.CleaningTaskTxtBx.Size = new System.Drawing.Size(403, 264);
            this.CleaningTaskTxtBx.TabIndex = 42;
            // 
            // CleaningManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CleaningTaskTxtBx);
            this.Controls.Add(this.CleaningWorker_Key);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CleaningManager_Key);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CleaningManagerNameTbx);
            this.Name = "CleaningManagerForm";
            this.Text = "CleaningManagerForm";
            this.Load += new System.EventHandler(this.CleaningManagerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel CleaningManager_Key;
        private MaterialSkin.Controls.MaterialFlatButton BackBtn;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox CleaningManagerNameTbx;
        private System.Windows.Forms.ListBox WorkersListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel CleaningWorker_Key;
        private System.Windows.Forms.TextBox CleaningTaskTxtBx;
    }
}