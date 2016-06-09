namespace Spotify_AdMuter
{
    partial class Main
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
            this.spotifyStatus = new System.Windows.Forms.Label();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.showJSON = new System.Windows.Forms.CheckBox();
            this.muterStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // spotifyStatus
            // 
            this.spotifyStatus.AutoSize = true;
            this.spotifyStatus.Location = new System.Drawing.Point(12, 69);
            this.spotifyStatus.Name = "spotifyStatus";
            this.spotifyStatus.Size = new System.Drawing.Size(0, 13);
            this.spotifyStatus.TabIndex = 0;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 500;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // showJSON
            // 
            this.showJSON.AutoSize = true;
            this.showJSON.Location = new System.Drawing.Point(12, 12);
            this.showJSON.Name = "showJSON";
            this.showJSON.Size = new System.Drawing.Size(79, 17);
            this.showJSON.TabIndex = 1;
            this.showJSON.Text = "showJSON";
            this.showJSON.UseVisualStyleBackColor = true;
            // 
            // muterStatus
            // 
            this.muterStatus.AutoSize = true;
            this.muterStatus.Location = new System.Drawing.Point(12, 42);
            this.muterStatus.Name = "muterStatus";
            this.muterStatus.Size = new System.Drawing.Size(0, 13);
            this.muterStatus.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.muterStatus);
            this.Controls.Add(this.showJSON);
            this.Controls.Add(this.spotifyStatus);
            this.Name = "Main";
            this.Text = "Spotify AdMuter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label spotifyStatus;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.CheckBox showJSON;
        private System.Windows.Forms.Label muterStatus;
    }
}

