using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SQLite;

namespace MusicCollection
{
    public partial class frmMusicCollection : Form
    {
        // 意思是：從 bin\Debug 往回走兩層，直接存取根目錄的 music.db
        string dbPath = @"Data Source=..\..\music.db;Version=3;";
        string currentSongLink = ""; // 用來暫存目前這首歌的網址
        public frmMusicCollection()
        {
            InitializeComponent();
        }

        // 3. 【新增這段】自動建立資料庫與表格的方法
        private void InitializeDatabase()
        {
            if (!File.Exists(@"..\..\music.db"))
            {
                // 如果真的不見了，就在根目錄重新建一個
                SQLiteConnection.CreateFile(@"..\..\music.db");
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string sql = @"CREATE TABLE Songs (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            SongName TEXT NOT NULL,
                            Artist TEXT,
                            Album TEXT,
                            Lyrics TEXT,
                            ArtistImage TEXT,
                            AlbumImage TEXT,
                            Link TEXT
                         )";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // --- 【新增】專門用來去資料庫撈歌單的方法 ---
        private void LoadSongList(string keyword = "")
        {
            lstSong.Items.Clear(); // 先清空畫面舊清單

            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                string sql;

                // 如果搜尋框是空的，就照原本的方式全部撈出來
                if (string.IsNullOrEmpty(keyword))
                {
                    sql = "SELECT SongName FROM Songs ORDER BY Artist ASC, Album ASC";
                }
                else
                {
                    // 如果有打字，就使用 LIKE 來搜尋「歌名/專輯」或「歌手」
                    // SQL 裡的 % 代表「任意字元」，例如 '%夢%' 就會抓到「夢のまた夢」
                    sql = "SELECT SongName FROM Songs WHERE SongName LIKE @kw OR Artist LIKE @kw OR Album LIKE @kw ORDER BY Artist ASC, Album ASC";
                }

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // 安全地把使用者輸入的字塞進 @kw 參數裡，並在前後加上 % 符號
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    }

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstSong.Items.Add(reader["SongName"].ToString());
                        }
                    }
                }
            }
        }

        private void frmMusicCollection_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            LoadSongList(); // 程式啟動時，自動去資料庫抓歌單
        }

        private void lstSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSong.SelectedItem == null) return;

            string selectedSong = lstSong.SelectedItem.ToString();

            // 每次切換歌曲時，先讓畫面回到預設空白狀態
            picArtist.Image = null;
            picAlbum.Image = null;
            lblArtist.Text = "歌手/音樂家：";
            lblAlbum.Text = "專輯：";
            txtLyrics.Text = "";

            // --- 【大翻新】用一句 SQL 搞定所有歌曲的讀取 ---
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                // SQL：去 Songs 表格找「歌名等於我們點選的那首歌」的所有資料
                string sql = "SELECT * FROM Songs WHERE SongName = @name";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    // 把 @name 安全地替換成我們點選的歌名
                    cmd.Parameters.AddWithValue("@name", selectedSong);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // 如果有找到這首歌
                        {
                            // 1. 填入文字資料
                            lblArtist.Text = "歌手/音樂家：" + reader["Artist"].ToString();
                            lblAlbum.Text = "專輯：" + reader["Album"].ToString();
                            txtLyrics.Text = reader["Lyrics"].ToString();
                            // 把資料庫裡的 Link 存進剛剛宣告的變數裡
                            currentSongLink = reader["Link"].ToString();

                            // 2. 讀取圖片字串
                            string artistImgStr = reader["ArtistImage"].ToString();
                            string albumImgStr = reader["AlbumImage"].ToString();

                            // --- 【動態控制 YouTube 圖示的顯示與隱藏】 ---
                            if (!string.IsNullOrEmpty(currentSongLink))
                            {
                                picYTLink.Visible = true;
                            }
                            else
                            {
                                picYTLink.Visible = false;
                            }                            

                            // --- 處理歌手圖片（支援新舊相容） ---
                            if (string.IsNullOrEmpty(artistImgStr))
                            {
                                picArtist.Image = null; // 沒填圖片就留白
                            }
                            else if (artistImgStr.Contains("\\"))
                            {
                                // 新歌模式：路徑包含斜線，代表是實體檔案位置
                                if (System.IO.File.Exists(artistImgStr))
                                {
                                    picArtist.Image = Image.FromFile(artistImgStr); // 暴力讀取外部檔案
                                }
                                else
                                {
                                    MessageBox.Show("找不到歌手圖片檔案，請確認路徑：\n" + artistImgStr, "圖片遺失");
                                    picArtist.Image = null;
                                }
                            }
                            else
                            {
                                // 舊歌模式：直接從 Resources 內部資源檔抓取
                                picArtist.Image = (Image)Properties.Resources.ResourceManager.GetObject(artistImgStr);
                            }


                            // --- 處理專輯圖片（支援新舊相容） ---
                            if (string.IsNullOrEmpty(albumImgStr))
                            {
                                picAlbum.Image = null;
                            }
                            else if (albumImgStr.Contains("\\"))
                            {
                                // 新歌模式
                                if (System.IO.File.Exists(albumImgStr))
                                {
                                    picAlbum.Image = Image.FromFile(albumImgStr);
                                }
                                else
                                {
                                    MessageBox.Show("找不到專輯圖片檔案，請確認路徑：\n" + albumImgStr, "圖片遺失");
                                    picAlbum.Image = null;
                                }
                            }
                            else
                            {
                                // 舊歌模式
                                picAlbum.Image = (Image)Properties.Resources.ResourceManager.GetObject(albumImgStr);
                            }

                           
                        }
                    }
                }
            }
        }

        private void picYTLink_Click(object sender, EventArgs e)
        {
            // 1. 先檢查這首歌到底有沒有網址 (如果資料庫裡是空的就不執行)
            if (!string.IsNullOrEmpty(currentSongLink))
            {
                try
                {
                    // 2. 【最核心的魔法】呼叫 Windows 系統預設的瀏覽器來打開網址！
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = currentSongLink,
                        UseShellExecute = true
                    });
                }
                catch
                {
                    MessageBox.Show("無法開啟連結！請檢查網址格式是否正確。");
                }
            }
            else
            {
                // 如果資料庫裡這首歌的 Link 是空的
                MessageBox.Show("這首歌目前還沒有專屬連結喔！");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // 把文字框 (txtSearch) 裡面的字 (Text)，丟進 LoadSongList 方法的 keyword 手套裡！
            LoadSongList(txtSearch.Text);
        }

        private void picAddSong_Click(object sender, EventArgs e)
        {
            // 1. 產生我們剛剛做好的新增視窗
            frmAddSong addForm = new frmAddSong();

            // 2. 使用 ShowDialog() 讓它以「對話框」模式跳出來 
            // (這會強制使用者必須關閉新增視窗後，才能點擊後面的主畫面)
            addForm.ShowDialog();

            // 3. 最重要的一步：當新增視窗關閉後，程式會繼續往下走。
            // 這時候我們立刻呼叫你之前寫好的讀取清單方法，畫面上的歌單就會瞬間更新！
            LoadSongList();
        }

        private void picDeleteSong_Click(object sender, EventArgs e)
        {
            // 1. 第一層防呆：確認使用者有沒有從清單點選一首歌？
            if (lstSong.SelectedItem == null)
            {
                MessageBox.Show("請先從左側清單選擇要刪除的歌曲喔！", "提示");
                return;
            }

            string selectedSong = lstSong.SelectedItem.ToString();

            // 2. 第二層防呆：跳出警告視窗再次確認 (這個對話框設計絕對會大加分！)
            DialogResult result = MessageBox.Show(
                $"你確定要將《{selectedSong}》從資料庫中永久刪除嗎？",
                "刪除確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // 3. 如果使用者點擊「是(Yes)」，才執行刪除
            if (result == DialogResult.Yes)
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    // SQL 語法：從 Songs 表格中刪除歌名相符的資料
                    string sql = "DELETE FROM Songs WHERE SongName = @name";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", selectedSong);
                        cmd.ExecuteNonQuery(); // 執行刪除！
                    }
                }

                MessageBox.Show("歌曲已成功刪除！", "完成");

                // 4. 【關鍵細節】刪除後，把右邊的詳細資訊清空，避免歌被刪了，照片還殘留在畫面上
                picArtist.Image = null;
                picAlbum.Image = null;
                lblArtist.Text = "歌手/音樂家：";
                lblAlbum.Text = "專輯：";
                txtLyrics.Text = "";
                picYTLink.Visible = false;

                // 5. 重新讀取資料庫，更新左側清單 (被刪掉的歌就會瞬間消失)
                LoadSongList();
            }
        }

        private void picEditSong_Click(object sender, EventArgs e)
        {
            // 1. 第一層防呆：確認使用者有沒有從清單點選一首歌？
            if (lstSong.SelectedItem == null)
            {
                MessageBox.Show("請先從左側清單選擇要修改的歌曲喔！", "提示");
                return;
            }

            // 2. 取得使用者目前選中的歌名
            string selectedSong = lstSong.SelectedItem.ToString();

            // 3. 呼叫我們剛剛做好的修改視窗，並且把歌名「傳遞」過去！
            // (這裡會呼叫到你剛剛在 frmEditSong 寫好的那個帶有參數的建構子)
            frmEditSong editForm = new frmEditSong(selectedSong);

            // 4. 使用 ShowDialog() 讓它以「對話框」模式跳出來 
            editForm.ShowDialog();

            // 5. 當使用者按下「儲存修改」並關閉視窗後，程式會繼續往下執行。
            // 這時候我們立刻重新讀取一次資料庫，讓畫面更新！
            LoadSongList();
        }
    }
}
