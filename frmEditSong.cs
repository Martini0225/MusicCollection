using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MusicCollection
{
    public partial class frmEditSong : Form
    {
        string dbPath = @"Data Source=..\..\music.db;Version=3;";
        string targetSongName; // 用來記住是哪首歌要被改

        // 新增這三個記憶抽屜，用來記住原本的文字
        string memorySongName = "";
        string memoryArtist = "";
        string memoryYTLink = "";

        // 這裡多加一個 string name 參數
        public frmEditSong(string name)
        {
            InitializeComponent();
            targetSongName = name; // 接住傳過來的歌名
        }

        private void frmEditSong_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                string sql = "SELECT * FROM Songs WHERE SongName = @name";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", targetSongName);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtSong.Text = reader["SongName"].ToString();
                            txtArtist.Text = reader["Artist"].ToString();
                            txtAlbum.Text = reader["Album"].ToString();
                            txtLyrics.Text = reader["Lyrics"].ToString();
                            txtYTLink.Text = reader["Link"].ToString();
                            txtArtistImage.Text = reader["ArtistImage"].ToString();
                            txtAlbumImage.Text = reader["AlbumImage"].ToString();

                            // 新增這段把重要的資料備份到記憶抽屜裡
                            memorySongName = txtSong.Text;
                            memoryArtist = txtArtist.Text;
                            memoryYTLink = txtYTLink.Text;
                        }
                    }
                }


            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {

            // 防呆 1：歌名檢查
            if (string.IsNullOrWhiteSpace(txtSong.Text))
            {
                MessageBox.Show("歌曲名稱不能是空白的喔！已為您恢復原名。", "提示");
                txtSong.Text = memorySongName; // 自動恢復成原本的歌名！
                return;
            }

            // 防呆 2：歌手檢查
            if (string.IsNullOrWhiteSpace(txtArtist.Text))
            {
                MessageBox.Show("歌手/音樂家名稱不能是空白的喔！已為您恢復原名。", "提示");
                txtArtist.Text = memoryArtist; // 自動恢復成原本的歌手！
                return;
            }

            // 防呆 3：YouTube 網址檢查
            string ytLink = txtYTLink.Text.Trim();
            if (string.IsNullOrWhiteSpace(ytLink))
            {
                MessageBox.Show("YouTube 連結不能是空白的喔！已為您恢復原網址。", "提示");
                txtYTLink.Text = memoryYTLink; // 自動恢復成原本的網址！
                return;
            }
            else
            {
                if (!ytLink.StartsWith("http://") && !ytLink.StartsWith("https://"))
                {
                    MessageBox.Show("請輸入完整的網址喔！已為您恢復原網址。", "格式錯誤");
                    txtYTLink.Text = memoryYTLink; // 自動恢復
                    return;
                }

                if (!ytLink.Contains("youtube.com") && !ytLink.Contains("youtu.be"))
                {
                    MessageBox.Show("這看起來不像是有效的 YouTube 連結喔！已為您恢復原網址。", "格式錯誤");
                    txtYTLink.Text = memoryYTLink; // 自動恢復
                    return;
                }
            }

            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                // 使用 UPDATE 語法，並指定 WHERE SongName = @oldName (最重要！)
                string sql = @"UPDATE Songs SET 
                       SongName = @newName, Artist = @artist, Album = @album, 
                       Lyrics = @lyrics, Link = @link, 
                       ArtistImage = @artistImg, AlbumImage = @albumImg 
                       WHERE SongName = @oldName";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@newName", txtSong.Text);
                    cmd.Parameters.AddWithValue("@artist", txtArtist.Text);
                    cmd.Parameters.AddWithValue("@album", txtAlbum.Text);
                    cmd.Parameters.AddWithValue("@lyrics", txtLyrics.Text);
                    cmd.Parameters.AddWithValue("@link", txtYTLink.Text);
                    cmd.Parameters.AddWithValue("@artistImg", txtArtistImage.Text);
                    cmd.Parameters.AddWithValue("@albumImg", txtAlbumImage.Text);
                    cmd.Parameters.AddWithValue("@oldName", targetSongName); // 鎖定原本那首歌

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("修改成功！", "成功");
            this.Close();
        }

        private void btnBrowseArtist_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "圖片檔案 (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "請選擇歌手圖片";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtArtistImage.Text = ofd.FileName; // 把選到的檔案路徑填入文字框
                }
            }
        }

        private void btnBrowseAlbum_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "圖片檔案 (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "請選擇專輯圖片";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtAlbumImage.Text = ofd.FileName; // 把選到的檔案路徑填入文字框
                }
            }
        }
    }
}
