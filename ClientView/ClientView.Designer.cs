namespace ClientView
{
    partial class Client
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
                client.Close();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.logger = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.receive = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.logger);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.sendButton);
            this.splitContainer1.Panel2.Controls.Add(this.inputBox);
            this.splitContainer1.Panel2.Controls.Add(this.receive);
            this.splitContainer1.Size = new System.Drawing.Size(484, 312);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 0;
            // 
            // logger
            // 
            this.logger.BackColor = System.Drawing.SystemColors.ControlLight;
            this.logger.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logger.Location = new System.Drawing.Point(0, 0);
            this.logger.Multiline = true;
            this.logger.Name = "logger";
            this.logger.ReadOnly = true;
            this.logger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logger.Size = new System.Drawing.Size(209, 312);
            this.logger.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(199, 24);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(66, 30);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.Location = new System.Drawing.Point(2, 4);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(191, 68);
            this.inputBox.TabIndex = 1;
            // 
            // receive
            // 
            this.receive.BackColor = System.Drawing.SystemColors.ControlLight;
            this.receive.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receive.Location = new System.Drawing.Point(2, 78);
            this.receive.Multiline = true;
            this.receive.Name = "receive";
            this.receive.ReadOnly = true;
            this.receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receive.Size = new System.Drawing.Size(263, 234);
            this.receive.TabIndex = 0;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.Controls.Add(this.splitContainer1);
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox logger;
        private System.Windows.Forms.TextBox receive;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox inputBox;

    }
}

