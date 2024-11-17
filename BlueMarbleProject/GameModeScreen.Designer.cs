namespace BlueMarbleProject
{
    partial class GameModeScreen
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
            this.SelectSolo_RadioBtn = new System.Windows.Forms.RadioButton();
            this.SelectTeam_RadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.P3_RadioBtn = new System.Windows.Forms.RadioButton();
            this.P2_RadioBtn = new System.Windows.Forms.RadioButton();
            this.P4_RadioBtn = new System.Windows.Forms.RadioButton();
            this.Start_Btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SelectTeam_RadioBtn);
            this.groupBox1.Controls.Add(this.SelectSolo_RadioBtn);
            this.groupBox1.Location = new System.Drawing.Point(55, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "게임 모드";
            // 
            // SelectSolo_RadioBtn
            // 
            this.SelectSolo_RadioBtn.AutoSize = true;
            this.SelectSolo_RadioBtn.Location = new System.Drawing.Point(28, 75);
            this.SelectSolo_RadioBtn.Name = "SelectSolo_RadioBtn";
            this.SelectSolo_RadioBtn.Size = new System.Drawing.Size(59, 16);
            this.SelectSolo_RadioBtn.TabIndex = 0;
            this.SelectSolo_RadioBtn.TabStop = true;
            this.SelectSolo_RadioBtn.Text = "개인전";
            this.SelectSolo_RadioBtn.UseVisualStyleBackColor = true;
            this.SelectSolo_RadioBtn.CheckedChanged += new System.EventHandler(this.SelectSolo_RadioBtn_CheckedChanged);
            // 
            // SelectTeam_RadioBtn
            // 
            this.SelectTeam_RadioBtn.AutoSize = true;
            this.SelectTeam_RadioBtn.Location = new System.Drawing.Point(250, 76);
            this.SelectTeam_RadioBtn.Name = "SelectTeam_RadioBtn";
            this.SelectTeam_RadioBtn.Size = new System.Drawing.Size(47, 16);
            this.SelectTeam_RadioBtn.TabIndex = 1;
            this.SelectTeam_RadioBtn.TabStop = true;
            this.SelectTeam_RadioBtn.Text = "팀전";
            this.SelectTeam_RadioBtn.UseVisualStyleBackColor = true;
            this.SelectTeam_RadioBtn.CheckedChanged += new System.EventHandler(this.SelectTeam_RadioBtn_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.P4_RadioBtn);
            this.groupBox2.Controls.Add(this.P3_RadioBtn);
            this.groupBox2.Controls.Add(this.P2_RadioBtn);
            this.groupBox2.Location = new System.Drawing.Point(55, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 168);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "인원수";
            // 
            // P3_RadioBtn
            // 
            this.P3_RadioBtn.AutoSize = true;
            this.P3_RadioBtn.Location = new System.Drawing.Point(183, 75);
            this.P3_RadioBtn.Name = "P3_RadioBtn";
            this.P3_RadioBtn.Size = new System.Drawing.Size(41, 16);
            this.P3_RadioBtn.TabIndex = 1;
            this.P3_RadioBtn.TabStop = true;
            this.P3_RadioBtn.Text = "3인";
            this.P3_RadioBtn.UseVisualStyleBackColor = true;
            // 
            // P2_RadioBtn
            // 
            this.P2_RadioBtn.AutoSize = true;
            this.P2_RadioBtn.Location = new System.Drawing.Point(28, 75);
            this.P2_RadioBtn.Name = "P2_RadioBtn";
            this.P2_RadioBtn.Size = new System.Drawing.Size(41, 16);
            this.P2_RadioBtn.TabIndex = 0;
            this.P2_RadioBtn.TabStop = true;
            this.P2_RadioBtn.Text = "2인";
            this.P2_RadioBtn.UseVisualStyleBackColor = true;
            // 
            // P4_RadioBtn
            // 
            this.P4_RadioBtn.AutoSize = true;
            this.P4_RadioBtn.Location = new System.Drawing.Point(350, 75);
            this.P4_RadioBtn.Name = "P4_RadioBtn";
            this.P4_RadioBtn.Size = new System.Drawing.Size(41, 16);
            this.P4_RadioBtn.TabIndex = 2;
            this.P4_RadioBtn.TabStop = true;
            this.P4_RadioBtn.Text = "4인";
            this.P4_RadioBtn.UseVisualStyleBackColor = true;
            // 
            // Start_Btn
            // 
            this.Start_Btn.Location = new System.Drawing.Point(266, 537);
            this.Start_Btn.Name = "Start_Btn";
            this.Start_Btn.Size = new System.Drawing.Size(213, 58);
            this.Start_Btn.TabIndex = 3;
            this.Start_Btn.Text = "선택 완료";
            this.Start_Btn.UseVisualStyleBackColor = true;
            this.Start_Btn.Click += new System.EventHandler(this.Start_Btn_Click);
            // 
            // GameModeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 631);
            this.Controls.Add(this.Start_Btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "GameModeScreen";
            this.Text = "GameModeScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameModeScreen_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SelectTeam_RadioBtn;
        private System.Windows.Forms.RadioButton SelectSolo_RadioBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton P4_RadioBtn;
        private System.Windows.Forms.RadioButton P3_RadioBtn;
        private System.Windows.Forms.RadioButton P2_RadioBtn;
        private System.Windows.Forms.Button Start_Btn;
    }
}