namespace BlueMarbleProject
{
    partial class GameRuleScreen
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
            this.RuleBack_Btn = new System.Windows.Forms.Button();
            this.LeftPage_Btn = new System.Windows.Forms.Button();
            this.RightPage_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RuleBack_Btn
            // 
            this.RuleBack_Btn.Location = new System.Drawing.Point(12, 12);
            this.RuleBack_Btn.Name = "RuleBack_Btn";
            this.RuleBack_Btn.Size = new System.Drawing.Size(61, 57);
            this.RuleBack_Btn.TabIndex = 0;
            this.RuleBack_Btn.Text = "Back";
            this.RuleBack_Btn.UseVisualStyleBackColor = true;
            this.RuleBack_Btn.Click += new System.EventHandler(this.RuleBack_Btn_Click);
            // 
            // LeftPage_Btn
            // 
            this.LeftPage_Btn.Location = new System.Drawing.Point(272, 382);
            this.LeftPage_Btn.Name = "LeftPage_Btn";
            this.LeftPage_Btn.Size = new System.Drawing.Size(61, 56);
            this.LeftPage_Btn.TabIndex = 1;
            this.LeftPage_Btn.Text = "Left_pg";
            this.LeftPage_Btn.UseVisualStyleBackColor = true;
            // 
            // RightPage_Btn
            // 
            this.RightPage_Btn.Location = new System.Drawing.Point(479, 382);
            this.RightPage_Btn.Name = "RightPage_Btn";
            this.RightPage_Btn.Size = new System.Drawing.Size(61, 56);
            this.RightPage_Btn.TabIndex = 2;
            this.RightPage_Btn.Text = "Right_pg";
            this.RightPage_Btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(361, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "n";
            // 
            // GameRuleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RightPage_Btn);
            this.Controls.Add(this.LeftPage_Btn);
            this.Controls.Add(this.RuleBack_Btn);
            this.Name = "GameRuleScreen";
            this.Text = "GameRuleScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameRuleScreen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RuleBack_Btn;
        private System.Windows.Forms.Button LeftPage_Btn;
        private System.Windows.Forms.Button RightPage_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}