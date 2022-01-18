using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EverISay.LoveLive.SIF.Delper {
    public partial class FormCard1:Form {
        public FormCard1() {
            InitializeComponent();
        }

        private MySqlConnection cm;
        private SQLiteConnection clUnit;
        private int cardCount = 0;
        private int cardPageMax = 0;
        private readonly string cardIconPath = Properties.Settings.Default.SitePathR2 + "sif\\card\\icon1\\";
        private List<int> signedCardIds = new List<int>();

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

        private void PageChanged(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char)Keys.Enter) return;
            int.TryParse(tstbPage.Text, out int pageNum);
            if (pageNum < 1 || pageNum > cardPageMax) return;
            dgvCards.Rows.Clear();
            var sql = "SELECT unit_id,unit_number,jp_name,idolized FROM unit "
                    + "WHERE unit_id BETWEEN " + (pageNum * 100 - 99) + " AND " + (pageNum * 100);
            var cmc = new MySqlCommand(sql, cm);
            var cmr = cmc.ExecuteReader();
            while (cmr.Read()) {
                var cardId = cmr.GetInt32("unit_id");
                var cols = new List<object> {
                    cardId,
                    cmr.GetInt32("unit_number"),
                    cmr.GetValue(2),
                };
                if (File.Exists(cardIconPath + pageNum + "\\" + cardId + ".png")) {
                    cols.Add("OK");
                } else {
                    cols.Add("暂未生成");
                }
                if (cmr.GetBoolean("idolized")) {
                    cols.Add("无");
                } else if (File.Exists(cardIconPath + pageNum + "\\" + cardId + "i.png")) {
                    cols.Add("OK");
                } else {
                    cols.Add("暂未生成");
                }
                if (!signedCardIds.Contains(cardId)) {
                    cols.Add("无");
                } else if (File.Exists(cardIconPath + pageNum + "\\" + cardId + "s.png")) {
                    cols.Add("OK");
                } else {
                    cols.Add("暂未生成");
                }
                dgvCards.Rows.Add(cols.ToArray());
            }
            cmr.Close();
        }

        private void DataGridViewCardsFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex >= 3 && e.ColumnIndex <= 5) {
                switch (e.Value) {
                    case "OK":
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        break;
                    case "暂未生成":
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
