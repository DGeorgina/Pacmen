namespace Pacman
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnNewGame = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblTimeLeft.Font = new System.Drawing.Font("Jokerman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTimeLeft.Location = new System.Drawing.Point(-1, 408);
            this.lblTimeLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(181, 70);
            this.lblTimeLeft.TabIndex = 3;
            this.lblTimeLeft.Text = "05:00";
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnNewGame
            // 
            this.btnNewGame.AutoSize = true;
            this.btnNewGame.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnNewGame.Font = new System.Drawing.Font("Jokerman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.ForeColor = System.Drawing.SystemColors.Info;
            this.btnNewGame.Location = new System.Drawing.Point(187, 439);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(156, 39);
            this.btnNewGame.TabIndex = 4;
            this.btnNewGame.Text = "Nova igra";
            this.btnNewGame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnNewGame_MouseClick);
            // 
            // btnContinue
            // 
            this.btnContinue.AutoSize = true;
            this.btnContinue.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnContinue.Font = new System.Drawing.Font("Jokerman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.SystemColors.Info;
            this.btnContinue.Location = new System.Drawing.Point(720, 439);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(89, 39);
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Text = "Start";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnPause
            // 
            this.btnPause.AutoSize = true;
            this.btnPause.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnPause.Font = new System.Drawing.Font("Jokerman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.SystemColors.Info;
            this.btnPause.Location = new System.Drawing.Point(624, 439);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(90, 39);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Stop ";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1220, 626);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblTimeLeft);
            this.Font = new System.Drawing.Font("Jokerman", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Pacman";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label btnNewGame;
        private System.Windows.Forms.Label btnContinue;
        private System.Windows.Forms.Label btnPause;
    }
}

