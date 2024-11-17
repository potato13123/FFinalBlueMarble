namespace BlueMarbleProject
{
    partial class GameStartScreen
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameStartScreen));
            this.GameStart_btn = new System.Windows.Forms.Button();
            this.GameRule_Btn = new System.Windows.Forms.Button();
            this.Exit_Btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GameStart_btn
            // 
            this.GameStart_btn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GameStart_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.GameStart_btn.Location = new System.Drawing.Point(358, 377);
            this.GameStart_btn.Margin = new System.Windows.Forms.Padding(2);
            this.GameStart_btn.Name = "GameStart_btn";
            this.GameStart_btn.Size = new System.Drawing.Size(174, 45);
            this.GameStart_btn.TabIndex = 0;
            this.GameStart_btn.Text = "게임 시작";
            this.GameStart_btn.UseVisualStyleBackColor = false;
            this.GameStart_btn.Click += new System.EventHandler(this.GameStart_btn_Click);
            // 
            // GameRule_Btn
            // 
            this.GameRule_Btn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GameRule_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.GameRule_Btn.Location = new System.Drawing.Point(358, 439);
            this.GameRule_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.GameRule_Btn.Name = "GameRule_Btn";
            this.GameRule_Btn.Size = new System.Drawing.Size(174, 45);
            this.GameRule_Btn.TabIndex = 1;
            this.GameRule_Btn.Text = "게임 설명";
            this.GameRule_Btn.UseVisualStyleBackColor = false;
            this.GameRule_Btn.Click += new System.EventHandler(this.GameRule_Btn_Click);
            // 
            // Exit_Btn
            // 
            this.Exit_Btn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Exit_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Exit_Btn.Location = new System.Drawing.Point(358, 506);
            this.Exit_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Exit_Btn.Name = "Exit_Btn";
            this.Exit_Btn.Size = new System.Drawing.Size(174, 45);
            this.Exit_Btn.TabIndex = 2;
            this.Exit_Btn.Text = "나가기";
            this.Exit_Btn.UseVisualStyleBackColor = false;
            this.Exit_Btn.Click += new System.EventHandler(this.Exit_Btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(197, 64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(474, 275);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // GameStartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 572);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Exit_Btn);
            this.Controls.Add(this.GameRule_Btn);
            this.Controls.Add(this.GameStart_btn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameStartScreen";
            this.Text = "BlueMarble";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameStartScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GameStart_btn;
        private System.Windows.Forms.Button GameRule_Btn;
        private System.Windows.Forms.Button Exit_Btn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

