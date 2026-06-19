namespace MusicCollection
{
    partial class frmAddSong
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
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblSong = new System.Windows.Forms.Label();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblYTLink = new System.Windows.Forms.Label();
            this.lblArtistImage = new System.Windows.Forms.Label();
            this.lblAlbumImage = new System.Windows.Forms.Label();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.txtSong = new System.Windows.Forms.TextBox();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.txtYTLink = new System.Windows.Forms.TextBox();
            this.txtArtistImage = new System.Windows.Forms.TextBox();
            this.txtAlbumImage = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLyrics = new System.Windows.Forms.Label();
            this.txtLyrics = new System.Windows.Forms.TextBox();
            this.btnBrowseArtist = new System.Windows.Forms.Button();
            this.btnBrowseAlbum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(36, 28);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(90, 15);
            this.lblArtist.TabIndex = 0;
            this.lblArtist.Text = "歌手/音樂家:";
            // 
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.Location = new System.Drawing.Point(36, 133);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(71, 15);
            this.lblSong.TabIndex = 1;
            this.lblSong.Text = "歌曲名稱:";
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Location = new System.Drawing.Point(36, 250);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(111, 15);
            this.lblAlbum.TabIndex = 2;
            this.lblAlbum.Text = "專輯名稱(選填):";
            // 
            // lblYTLink
            // 
            this.lblYTLink.AutoSize = true;
            this.lblYTLink.Location = new System.Drawing.Point(36, 359);
            this.lblYTLink.Name = "lblYTLink";
            this.lblYTLink.Size = new System.Drawing.Size(94, 15);
            this.lblYTLink.TabIndex = 3;
            this.lblYTLink.Text = "YouTube連結:";
            // 
            // lblArtistImage
            // 
            this.lblArtistImage.AutoSize = true;
            this.lblArtistImage.Location = new System.Drawing.Point(240, 28);
            this.lblArtistImage.Name = "lblArtistImage";
            this.lblArtistImage.Size = new System.Drawing.Size(160, 15);
            this.lblArtistImage.TabIndex = 4;
            this.lblArtistImage.Text = "歌手/音樂家圖片(選填):";
            // 
            // lblAlbumImage
            // 
            this.lblAlbumImage.AutoSize = true;
            this.lblAlbumImage.Location = new System.Drawing.Point(240, 133);
            this.lblAlbumImage.Name = "lblAlbumImage";
            this.lblAlbumImage.Size = new System.Drawing.Size(111, 15);
            this.lblAlbumImage.TabIndex = 5;
            this.lblAlbumImage.Text = "專輯圖片(選填):";
            // 
            // txtArtist
            // 
            this.txtArtist.Location = new System.Drawing.Point(39, 62);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(174, 25);
            this.txtArtist.TabIndex = 6;
            // 
            // txtSong
            // 
            this.txtSong.Location = new System.Drawing.Point(39, 163);
            this.txtSong.Name = "txtSong";
            this.txtSong.Size = new System.Drawing.Size(174, 25);
            this.txtSong.TabIndex = 7;
            // 
            // txtAlbum
            // 
            this.txtAlbum.Location = new System.Drawing.Point(39, 278);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(174, 25);
            this.txtAlbum.TabIndex = 8;
            // 
            // txtYTLink
            // 
            this.txtYTLink.Location = new System.Drawing.Point(39, 392);
            this.txtYTLink.Name = "txtYTLink";
            this.txtYTLink.Size = new System.Drawing.Size(321, 25);
            this.txtYTLink.TabIndex = 9;
            // 
            // txtArtistImage
            // 
            this.txtArtistImage.Location = new System.Drawing.Point(243, 62);
            this.txtArtistImage.Name = "txtArtistImage";
            this.txtArtistImage.Size = new System.Drawing.Size(174, 25);
            this.txtArtistImage.TabIndex = 10;
            // 
            // txtAlbumImage
            // 
            this.txtAlbumImage.Location = new System.Drawing.Point(243, 163);
            this.txtAlbumImage.Name = "txtAlbumImage";
            this.txtAlbumImage.Size = new System.Drawing.Size(174, 25);
            this.txtAlbumImage.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(433, 433);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 35);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLyrics
            // 
            this.lblLyrics.AutoSize = true;
            this.lblLyrics.Location = new System.Drawing.Point(240, 250);
            this.lblLyrics.Name = "lblLyrics";
            this.lblLyrics.Size = new System.Drawing.Size(81, 15);
            this.lblLyrics.TabIndex = 15;
            this.lblLyrics.Text = "歌詞(選填):";
            // 
            // txtLyrics
            // 
            this.txtLyrics.Location = new System.Drawing.Point(243, 278);
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.Size = new System.Drawing.Size(268, 25);
            this.txtLyrics.TabIndex = 16;
            // 
            // btnBrowseArtist
            // 
            this.btnBrowseArtist.Location = new System.Drawing.Point(433, 54);
            this.btnBrowseArtist.Name = "btnBrowseArtist";
            this.btnBrowseArtist.Size = new System.Drawing.Size(78, 33);
            this.btnBrowseArtist.TabIndex = 31;
            this.btnBrowseArtist.Text = "瀏覽";
            this.btnBrowseArtist.UseVisualStyleBackColor = true;
            this.btnBrowseArtist.Click += new System.EventHandler(this.btnBrowseArtist_Click);
            // 
            // btnBrowseAlbum
            // 
            this.btnBrowseAlbum.Location = new System.Drawing.Point(433, 157);
            this.btnBrowseAlbum.Name = "btnBrowseAlbum";
            this.btnBrowseAlbum.Size = new System.Drawing.Size(78, 33);
            this.btnBrowseAlbum.TabIndex = 32;
            this.btnBrowseAlbum.Text = "瀏覽";
            this.btnBrowseAlbum.UseVisualStyleBackColor = true;
            this.btnBrowseAlbum.Click += new System.EventHandler(this.btnBrowseAlbum_Click);
            // 
            // frmAddSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 503);
            this.Controls.Add(this.btnBrowseAlbum);
            this.Controls.Add(this.btnBrowseArtist);
            this.Controls.Add(this.txtLyrics);
            this.Controls.Add(this.lblLyrics);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAlbumImage);
            this.Controls.Add(this.txtArtistImage);
            this.Controls.Add(this.txtYTLink);
            this.Controls.Add(this.txtAlbum);
            this.Controls.Add(this.txtSong);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.lblAlbumImage);
            this.Controls.Add(this.lblArtistImage);
            this.Controls.Add(this.lblYTLink);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.lblSong);
            this.Controls.Add(this.lblArtist);
            this.Name = "frmAddSong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增歌曲";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblYTLink;
        private System.Windows.Forms.Label lblArtistImage;
        private System.Windows.Forms.Label lblAlbumImage;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.TextBox txtSong;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.TextBox txtYTLink;
        private System.Windows.Forms.TextBox txtArtistImage;
        private System.Windows.Forms.TextBox txtAlbumImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLyrics;
        private System.Windows.Forms.TextBox txtLyrics;
        private System.Windows.Forms.Button btnBrowseArtist;
        private System.Windows.Forms.Button btnBrowseAlbum;
    }
}