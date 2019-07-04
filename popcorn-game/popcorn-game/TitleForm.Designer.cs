namespace popcorn_game
{
    partial class TitleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleForm));
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.playerName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStartGame.Location = new System.Drawing.Point(172, 284);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(167, 23);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHelp.Location = new System.Drawing.Point(172, 334);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(167, 23);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter name:";
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(172, 239);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(167, 20);
            this.playerName.TabIndex = 4;
            this.playerName.Text = "Unknown";
            this.playerName.TextChanged += new System.EventHandler(this.playerName_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::popcorn_game.Properties.Resources.logo;
            this.pictureBox1.InitialImage = global::popcorn_game.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(172, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 187);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExit.Location = new System.Drawing.Point(172, 384);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(167, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit Game";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // TitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(510, 467);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TitleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopCorn Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerName;
        private System.Windows.Forms.Button btnExit;
    }
}