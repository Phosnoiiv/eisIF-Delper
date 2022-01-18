
namespace EverISay.LoveLive.SIF.Delper {
    partial class FormCard1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsGeneral = new System.Windows.Forms.ToolStrip();
            this.tstbPage = new System.Windows.Forms.ToolStripTextBox();
            this.tslPageMax = new System.Windows.Forms.ToolStripLabel();
            this.dgvCards = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIconNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIconIdolized = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIconSigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCards)).BeginInit();
            this.SuspendLayout();
            // 
            // tsGeneral
            // 
            this.tsGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstbPage,
            this.tslPageMax});
            this.tsGeneral.Location = new System.Drawing.Point(0, 0);
            this.tsGeneral.Name = "tsGeneral";
            this.tsGeneral.Size = new System.Drawing.Size(800, 25);
            this.tsGeneral.TabIndex = 0;
            this.tsGeneral.Text = "tsGeneral";
            // 
            // tstbPage
            // 
            this.tstbPage.Name = "tstbPage";
            this.tstbPage.Size = new System.Drawing.Size(100, 25);
            this.tstbPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tstbPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PageChanged);
            // 
            // tslPageMax
            // 
            this.tslPageMax.Name = "tslPageMax";
            this.tslPageMax.Size = new System.Drawing.Size(20, 22);
            this.tslPageMax.Text = "/0";
            // 
            // dgvCards
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnNumber,
            this.ColumnJaName,
            this.ColumnIconNormal,
            this.ColumnIconIdolized,
            this.ColumnIconSigned});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCards.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCards.Location = new System.Drawing.Point(0, 25);
            this.dgvCards.Name = "dgvCards";
            this.dgvCards.RowTemplate.Height = 23;
            this.dgvCards.Size = new System.Drawing.Size(800, 425);
            this.dgvCards.TabIndex = 1;
            this.dgvCards.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewCardsFormatting);
            // 
            // ColumnID
            // 
            this.ColumnID.Frozen = true;
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Width = 50;
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.HeaderText = "No";
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.ReadOnly = true;
            this.ColumnNumber.Width = 60;
            // 
            // ColumnJaName
            // 
            this.ColumnJaName.HeaderText = "名称";
            this.ColumnJaName.Name = "ColumnJaName";
            this.ColumnJaName.ReadOnly = true;
            this.ColumnJaName.Width = 150;
            // 
            // ColumnIconNormal
            // 
            this.ColumnIconNormal.HeaderText = "通常头像";
            this.ColumnIconNormal.Name = "ColumnIconNormal";
            this.ColumnIconNormal.ReadOnly = true;
            this.ColumnIconNormal.Width = 80;
            // 
            // ColumnIconIdolized
            // 
            this.ColumnIconIdolized.HeaderText = "觉醒头像";
            this.ColumnIconIdolized.Name = "ColumnIconIdolized";
            this.ColumnIconIdolized.ReadOnly = true;
            this.ColumnIconIdolized.Width = 80;
            // 
            // ColumnIconSigned
            // 
            this.ColumnIconSigned.HeaderText = "签名头像";
            this.ColumnIconSigned.Name = "ColumnIconSigned";
            this.ColumnIconSigned.ReadOnly = true;
            this.ColumnIconSigned.Width = 80;
            // 
            // FormCard1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCards);
            this.Controls.Add(this.tsGeneral);
            this.Name = "FormCard1";
            this.Text = "SIF 卡片管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCard1Closed);
            this.Load += new System.EventHandler(this.FormCard1Load);
            this.tsGeneral.ResumeLayout(false);
            this.tsGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsGeneral;
        private System.Windows.Forms.ToolStripTextBox tstbPage;
        private System.Windows.Forms.ToolStripLabel tslPageMax;
        private System.Windows.Forms.DataGridView dgvCards;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIconNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIconIdolized;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIconSigned;
    }
}