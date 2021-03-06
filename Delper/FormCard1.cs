using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace EverISay.LoveLive.SIF.Delper {
    public partial class FormCard1:Form {
        public FormCard1() {
            InitializeComponent();
        }

        private const string ICON_UNAVAILABLE = "暂未生成";

        private MySqlConnection cm;
        private SQLiteConnection clUnit;
        private int cardCount = 0;
        private int cardPageMax = 0;
        private readonly string cardIconPath = Properties.Settings.Default.SitePathR2 + "sif\\card\\icon1\\";
        private List<int> signedCardIds = new List<int>();
        private byte[] buffer = new byte[1024];

        private void FormCard1Load(object sender, EventArgs e) {
            var cmsb = new MySqlConnectionStringBuilder() {
                Server = Properties.Settings.Default.MySQLServer,
                UserID = Properties.Settings.Default.MySQLUserID,
                Password = Properties.Settings.Default.MySQLPassword,
                Database = "sif",
            };
            cm = new MySqlConnection(cmsb.ConnectionString);
            try {
                cm.Open();
                var cmc = new MySqlCommand("SELECT MAX(unit_id) FROM unit", cm);
                cardCount = Convert.ToInt32(cmc.ExecuteScalar());
                cardPageMax = Convert.ToInt32(Math.Ceiling(cardCount / 100D));
            } catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var clsb = new SQLiteConnectionStringBuilder() {
                DataSource = Properties.Settings.Default.SQLiteDecryptedPath + "unit.db_",
            };
            clUnit = new SQLiteConnection(clsb.ConnectionString);
            clUnit.Open();
            var clc = new SQLiteCommand("SELECT unit_id FROM unit_sign_asset_m WHERE normal_icon_asset!=''", clUnit);
            var clr = clc.ExecuteReader();
            while (clr.Read()) {
                signedCardIds.Add(clr.GetInt32(0));
            }
            clr.Close();
            tslPageMax.Text = "/" + cardPageMax;
            tstbPage.Text = cardPageMax.ToString();
        }
        private void FormCard1Closed(object sender, FormClosedEventArgs e) {
            cm.Close();
            clUnit.Close();
        }

        private string GetIconFilename(int cardId, string suffix = "") {
            return Math.Ceiling(cardId / 100D) + "\\" + cardId + suffix + ".png";
        }
        private void PageChanged(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char)Keys.Enter) return;
            int.TryParse(tstbPage.Text, out int pageNum);
            if (pageNum < 1 || pageNum > cardPageMax) return;
            dgvCards.Rows.Clear();
            var sql = "SELECT unit_id,unit_number,jp_name,idolized FROM unit "
                    + "WHERE unit_id BETWEEN " + (pageNum * 100 - 99) + " AND " + (pageNum * 100)
                    + " AND unit_number<500000";
            var cmc = new MySqlCommand(sql, cm);
            var cmr = cmc.ExecuteReader();
            while (cmr.Read()) {
                var cardId = cmr.GetInt32("unit_id");
                var cols = new List<object> {
                    cardId,
                    cmr.GetInt32("unit_number"),
                    cmr.GetValue(2),
                };
                if (File.Exists(cardIconPath + GetIconFilename(cardId))) {
                    cols.Add("OK");
                } else {
                    cols.Add(ICON_UNAVAILABLE);
                }
                if (cmr.GetBoolean("idolized")) {
                    cols.Add("无");
                } else if (File.Exists(cardIconPath + GetIconFilename(cardId, "i"))) {
                    cols.Add("OK");
                } else {
                    cols.Add(ICON_UNAVAILABLE);
                }
                if (!signedCardIds.Contains(cardId)) {
                    cols.Add("无");
                } else if (File.Exists(cardIconPath + GetIconFilename(cardId, "s"))) {
                    cols.Add("OK");
                } else {
                    cols.Add(ICON_UNAVAILABLE);
                }
                dgvCards.Rows.Add(cols.ToArray());
            }
            cmr.Close();
        }
        private void DownloadIcons(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dgvCards.Rows) {
                var cardId = Convert.ToInt32(row.Cells[0].Value);
                if (ICON_UNAVAILABLE.Equals(row.Cells[3].Value)) {
                    DownloadUnsignedIcon(cardId, "", "normal_icon_asset");
                }
                if (ICON_UNAVAILABLE.Equals(row.Cells[4].Value)) {
                    DownloadUnsignedIcon(cardId, "i", "rank_max_icon_asset");
                }
                if (ICON_UNAVAILABLE.Equals(row.Cells[5].Value)) {
                    DownloadSignedIcon(cardId);
                }
            }
            MessageBox.Show("已完成。");
        }
        private void DownloadUnsignedIcon(int cardId, string suffix, string columnName) {
            var filename = Properties.Settings.Default.G1CardDownloadPath + GetIconFilename(cardId, suffix);
            if (File.Exists(filename)) return;
            var clc = new SQLiteCommand("SELECT " + columnName + " FROM unit_m WHERE unit_id=" + cardId, clUnit);
            using (var clr = clc.ExecuteReader()) {
                clr.Read();
                DownloadIcon(clr.GetString(0), filename);
            }
        }
        private void DownloadSignedIcon(int cardId) {
            var filename = Properties.Settings.Default.G1CardDownloadPath + GetIconFilename(cardId, "s");
            if (File.Exists(filename)) return;
            var clc = new SQLiteCommand("SELECT rank_max_icon_asset FROM unit_sign_asset_m WHERE unit_id=" + cardId, clUnit);
            using (var clr = clc.ExecuteReader()) {
                clr.Read();
                DownloadIcon(clr.GetString(0), filename);
            }
        }
        private void DownloadIcon(string path, string filename) {
            var req = WebRequest.CreateHttp(Properties.Settings.Default.G1DownloadFrom + path);
            var res = req.GetResponse();
            var reqStream = res.GetResponseStream();
            var saveStream = new FileStream(filename, FileMode.CreateNew);
            int size;
            while ((size = reqStream.Read(buffer, 0, 1024)) > 0) {
                saveStream.Write(buffer, 0, size);
            }
            saveStream.Close();
            reqStream.Close();
            res.Close();
        }

        private void DataGridViewCardsFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex >= 3 && e.ColumnIndex <= 5) {
                switch (e.Value) {
                    case "OK":
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        break;
                    case ICON_UNAVAILABLE:
                        e.CellStyle.ForeColor = Color.DarkRed;
                        break;
                    case "无":
                        e.CellStyle.ForeColor = Color.Gray;
                        break;
                }
            }
        }
    }
}
