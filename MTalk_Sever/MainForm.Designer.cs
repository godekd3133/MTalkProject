namespace MTalk_Sever
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
            this.IPAddressText = new System.Windows.Forms.TextBox();
            this.PortText = new System.Windows.Forms.TextBox();
            this.ServerOpenButton = new System.Windows.Forms.Button();
            this.ServerStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IPAddressText
            // 
            this.IPAddressText.Location = new System.Drawing.Point(37, 57);
            this.IPAddressText.Name = "IPAddressText";
            this.IPAddressText.Size = new System.Drawing.Size(100, 21);
            this.IPAddressText.TabIndex = 0;
            // 
            // PortText
            // 
            this.PortText.Location = new System.Drawing.Point(157, 57);
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(100, 21);
            this.PortText.TabIndex = 1;
            // 
            // ServerOpenButton
            // 
            this.ServerOpenButton.Location = new System.Drawing.Point(37, 103);
            this.ServerOpenButton.Name = "ServerOpenButton";
            this.ServerOpenButton.Size = new System.Drawing.Size(219, 59);
            this.ServerOpenButton.TabIndex = 2;
            this.ServerOpenButton.Text = "button1";
            this.ServerOpenButton.UseVisualStyleBackColor = true;
            this.ServerOpenButton.Click += new System.EventHandler(this.ServerOpenButton_Click);
            // 
            // ServerStatusLabel
            // 
            this.ServerStatusLabel.AutoSize = true;
            this.ServerStatusLabel.Location = new System.Drawing.Point(71, 187);
            this.ServerStatusLabel.Name = "ServerStatusLabel";
            this.ServerStatusLabel.Size = new System.Drawing.Size(65, 12);
            this.ServerStatusLabel.TabIndex = 3;
            this.ServerStatusLabel.Text = "서버상태 : ";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ServerStatusLabel);
            this.Controls.Add(this.ServerOpenButton);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.IPAddressText);
            this.Name = "MainForm";
            this.Text = "MTalk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPAddressText;
        private System.Windows.Forms.TextBox PortText;
        private System.Windows.Forms.Button ServerOpenButton;
        private System.Windows.Forms.Label ServerStatusLabel;
    }
}

