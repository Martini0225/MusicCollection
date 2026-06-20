namespace MusicCollection
{
    partial class frmMusicCollection
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lstSong = new System.Windows.Forms.ListBox();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.picEditSong = new System.Windows.Forms.PictureBox();
            this.picDeleteSong = new System.Windows.Forms.PictureBox();
            this.picAddSong = new System.Windows.Forms.PictureBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.picYTLink = new System.Windows.Forms.PictureBox();
            this.txtLyrics = new System.Windows.Forms.TextBox();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.picAlbum = new System.Windows.Forms.PictureBox();
            this.picArtist = new System.Windows.Forms.PictureBox();
            this.grpInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditSong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeleteSong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddSong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYTLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArtist)).BeginInit();
            this.SuspendLayout();
            // 
            // lstSong
            // 
            this.lstSong.BackColor = System.Drawing.Color.LightSalmon;
            this.lstSong.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstSong.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lstSong.FormattingEnabled = true;
            this.lstSong.ItemHeight = 23;
            this.lstSong.Location = new System.Drawing.Point(0, 0);
            this.lstSong.Name = "lstSong";
            this.lstSong.Size = new System.Drawing.Size(254, 664);
            this.lstSong.TabIndex = 0;
            this.lstSong.SelectedIndexChanged += new System.EventHandler(this.lstSong_SelectedIndexChanged);
            // 
            // grpInformation
            // 
            this.grpInformation.BackColor = System.Drawing.Color.MistyRose;
            this.grpInformation.Controls.Add(this.picEditSong);
            this.grpInformation.Controls.Add(this.picDeleteSong);
            this.grpInformation.Controls.Add(this.picAddSong);
            this.grpInformation.Controls.Add(this.lblSearch);
            this.grpInformation.Controls.Add(this.txtSearch);
            this.grpInformation.Controls.Add(this.picYTLink);
            this.grpInformation.Controls.Add(this.txtLyrics);
            this.grpInformation.Controls.Add(this.lblAlbum);
            this.grpInformation.Controls.Add(this.lblArtist);
            this.grpInformation.Controls.Add(this.picAlbum);
            this.grpInformation.Controls.Add(this.picArtist);
            this.grpInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInformation.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpInformation.Location = new System.Drawing.Point(254, 0);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Size = new System.Drawing.Size(818, 664);
            this.grpInformation.TabIndex = 1;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "歌曲資訊";
            // 
            // picEditSong
            // 
            this.picEditSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEditSong.Image = global::MusicCollection.Properties.Resources.clker_free_vector_images_pencil_27423_640;
            this.picEditSong.Location = new System.Drawing.Point(134, 577);
            this.picEditSong.Name = "picEditSong";
            this.picEditSong.Size = new System.Drawing.Size(56, 48);
            this.picEditSong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEditSong.TabIndex = 10;
            this.picEditSong.TabStop = false;
            this.picEditSong.Click += new System.EventHandler(this.picEditSong_Click);
            // 
            // picDeleteSong
            // 
            this.picDeleteSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDeleteSong.Image = global::MusicCollection.Properties.Resources.nagaswetha_delete_button_6030454_640;
            this.picDeleteSong.Location = new System.Drawing.Point(212, 577);
            this.picDeleteSong.Name = "picDeleteSong";
            this.picDeleteSong.Size = new System.Drawing.Size(56, 48);
            this.picDeleteSong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDeleteSong.TabIndex = 9;
            this.picDeleteSong.TabStop = false;
            this.picDeleteSong.Click += new System.EventHandler(this.picDeleteSong_Click);
            // 
            // picAddSong
            // 
            this.picAddSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddSong.Image = global::MusicCollection.Properties.Resources.tranquangkhai_add_6491195_640;
            this.picAddSong.Location = new System.Drawing.Point(56, 577);
            this.picAddSong.Name = "picAddSong";
            this.picAddSong.Size = new System.Drawing.Size(56, 48);
            this.picAddSong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddSong.TabIndex = 8;
            this.picAddSong.TabStop = false;
            this.picAddSong.Click += new System.EventHandler(this.picAddSong_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSearch.Location = new System.Drawing.Point(470, 30);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(253, 25);
            this.lblSearch.TabIndex = 7;
            this.lblSearch.Text = "搜尋歌手或歌曲/專輯/年份:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(475, 70);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(312, 31);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // picYTLink
            // 
            this.picYTLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picYTLink.Image = global::MusicCollection.Properties.Resources.YT;
            this.picYTLink.Location = new System.Drawing.Point(365, 30);
            this.picYTLink.Name = "picYTLink";
            this.picYTLink.Size = new System.Drawing.Size(72, 71);
            this.picYTLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picYTLink.TabIndex = 5;
            this.picYTLink.TabStop = false;
            this.picYTLink.Visible = false;
            this.picYTLink.Click += new System.EventHandler(this.picYTLink_Click);
            // 
            // txtLyrics
            // 
            this.txtLyrics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLyrics.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtLyrics.Font = new System.Drawing.Font("微軟正黑體", 11F);
            this.txtLyrics.Location = new System.Drawing.Point(351, 121);
            this.txtLyrics.Multiline = true;
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.ReadOnly = true;
            this.txtLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyrics.Size = new System.Drawing.Size(436, 531);
            this.txtLyrics.TabIndex = 4;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAlbum.Location = new System.Drawing.Point(20, 273);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(57, 25);
            this.lblAlbum.TabIndex = 3;
            this.lblAlbum.Text = "專輯:";
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblArtist.Location = new System.Drawing.Point(27, 37);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(125, 25);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "歌手/音樂家:";
            // 
            // picAlbum
            // 
            this.picAlbum.Location = new System.Drawing.Point(81, 306);
            this.picAlbum.Name = "picAlbum";
            this.picAlbum.Size = new System.Drawing.Size(168, 163);
            this.picAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAlbum.TabIndex = 1;
            this.picAlbum.TabStop = false;
            // 
            // picArtist
            // 
            this.picArtist.Location = new System.Drawing.Point(81, 65);
            this.picArtist.Name = "picArtist";
            this.picArtist.Size = new System.Drawing.Size(168, 163);
            this.picArtist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picArtist.TabIndex = 0;
            this.picArtist.TabStop = false;
            // 
            // frmMusicCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 664);
            this.Controls.Add(this.grpInformation);
            this.Controls.Add(this.lstSong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMusicCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Collection";
            this.Load += new System.EventHandler(this.frmMusicCollection_Load);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditSong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeleteSong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddSong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYTLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlbum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArtist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstSong;
        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.PictureBox picAlbum;
        private System.Windows.Forms.PictureBox picArtist;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.TextBox txtLyrics;
        private System.Windows.Forms.PictureBox picYTLink;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.PictureBox picAddSong;
        private System.Windows.Forms.PictureBox picDeleteSong;
        private System.Windows.Forms.PictureBox picEditSong;
    }
}

