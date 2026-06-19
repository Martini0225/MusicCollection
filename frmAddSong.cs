using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml.Linq;

namespace MusicCollection
{
    public partial class frmAddSong : Form
    {
        string dbPath = @"Data Source=..\..\music.db;Version=3;";
        public frmAddSong()
        {
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 防呆機制：歌曲名稱一定要填
            if (string.IsNullOrWhiteSpace(txtSong.Text))
            {
                MessageBox.Show("歌曲名稱不能是空白的喔！", "提示");
                return;
            }
            // 防呆機制：歌手/音樂家名稱一定要填
            if (string.IsNullOrWhiteSpace(txtArtist.Text))
            {
                MessageBox.Show("歌手/音樂家名稱不能是空白的喔！", "提示");
                return;
            }
            // 檢查有沒有輸入 YouTube 連結，以及格式是否正確
            string ytLink = txtYTLink.Text.Trim(); // 先把字串前後多餘的空白去掉

            if (string.IsNullOrWhiteSpace(ytLink))
            {
                MessageBox.Show("YouTube 連結不能是空白的喔！", "提示");
                return;
            }
            else
            {
                // 檢查 1：是否以 http:// 或 https:// 開頭
                if (!ytLink.StartsWith("http://") && !ytLink.StartsWith("https://"))
                {
                    MessageBox.Show("請輸入完整的網址喔！（必須以 http:// 或 https:// 開頭）", "格式錯誤");
                    return;
                }

                // 檢查 2：網址裡面有沒有包含 youtube 相關的字眼
                if (!ytLink.Contains("youtube.com") && !ytLink.Contains("youtu.be"))
                {
                    MessageBox.Show("這看起來不像是有效的 YouTube 連結喔！請重新確認。", "格式錯誤");
                    return;
                }
            }

            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();

                // 1. 語法擴充：把 Lyrics 欄位和 @lyrics 參數加進去！
                string sql = @"INSERT INTO Songs (SongName, Artist, Album, Lyrics, Link, ArtistImage, AlbumImage) 
                   VALUES (@name, @artist, @album, @lyrics, @link, @artistImg, @albumImg)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtSong.Text);
                    cmd.Parameters.AddWithValue("@artist", txtArtist.Text);
                    cmd.Parameters.AddWithValue("@album", txtAlbum.Text);

                    // 2. 新增這一行：把歌詞框裡的字裝進 @lyrics 紙箱裡
                    cmd.Parameters.AddWithValue("@lyrics", txtLyrics.Text);

                    cmd.Parameters.AddWithValue("@link", txtYTLink.Text);
                    cmd.Parameters.AddWithValue("@artistImg", txtArtistImage.Text);
                    cmd.Parameters.AddWithValue("@albumImg", txtAlbumImage.Text);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("新增歌曲成功！", "成功");
            this.Close(); // 儲存完畢後自動關閉這個小視窗
        }
    }
}
