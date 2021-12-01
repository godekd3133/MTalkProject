namespace MTalk_Client
{
    partial class MainForm
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
            this.ChatLogText = new System.Windows.Forms.TextBox();
            this.SendText = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChatLogText
            // 
            this.ChatLogText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChatLogText.Location = new System.Drawing.Point(12, 12);
            this.ChatLogText.Multiline = true;
            this.ChatLogText.Name = "ChatLogText";
            this.ChatLogText.ReadOnly = true;
            this.ChatLogText.Size = new System.Drawing.Size(540, 317);
            this.ChatLogText.TabIndex = 0;
            // 
            // SendText
            // 
            this.SendText.Location = new System.Drawing.Point(12, 358);
            this.SendText.Multiline = true;
            this.SendText.Name = "SendText";
            this.SendText.Size = new System.Drawing.Size(402, 80);
            this.SendText.TabIndex = 1;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(437, 356);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(115, 82);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "보내기";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 450);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.SendText);
            this.Controls.Add(this.ChatLogText);
            this.Name = "MainForm";
            this.Text = "MTalk";
            this.ResumeLayout(false);
            this.PerformLayout();
       
        }

        #endregion

        private System.Windows.Forms.TextBox ChatLogText;
        private System.Windows.Forms.TextBox SendText;
        private System.Windows.Forms.Button SendButton;
    }
}

