
namespace QuanLiTraSua
{
    partial class ThongKe
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblKhachSan = new System.Windows.Forms.Label();
            this.DVG = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePk = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.DGVsum = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVsum)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 36);
            this.button1.TabIndex = 18;
            this.button1.Text = "Save file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblKhachSan
            // 
            this.lblKhachSan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKhachSan.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhachSan.ForeColor = System.Drawing.Color.IndianRed;
            this.lblKhachSan.Location = new System.Drawing.Point(0, 0);
            this.lblKhachSan.Name = "lblKhachSan";
            this.lblKhachSan.Size = new System.Drawing.Size(1517, 60);
            this.lblKhachSan.TabIndex = 17;
            this.lblKhachSan.Text = "THỐNG KÊ";
            this.lblKhachSan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DVG
            // 
            this.DVG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVG.Location = new System.Drawing.Point(19, 142);
            this.DVG.Margin = new System.Windows.Forms.Padding(4);
            this.DVG.Name = "DVG";
            this.DVG.RowHeadersWidth = 51;
            this.DVG.Size = new System.Drawing.Size(1064, 268);
            this.DVG.TabIndex = 16;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(205, 446);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(151, 36);
            this.btnXoa.TabIndex = 20;
            this.btnXoa.Text = "Delete";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1092, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Thu nhập:";
            // 
            // dateTimePk
            // 
            this.dateTimePk.Location = new System.Drawing.Point(1170, 72);
            this.dateTimePk.Name = "dateTimePk";
            this.dateTimePk.Size = new System.Drawing.Size(200, 22);
            this.dateTimePk.TabIndex = 22;
            this.dateTimePk.Value = new System.DateTime(2021, 11, 15, 0, 0, 0, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1388, 63);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 45);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // DGVsum
            // 
            this.DGVsum.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVsum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVsum.Location = new System.Drawing.Point(1106, 142);
            this.DGVsum.Margin = new System.Windows.Forms.Padding(4);
            this.DGVsum.Name = "DGVsum";
            this.DGVsum.RowHeadersWidth = 51;
            this.DGVsum.Size = new System.Drawing.Size(395, 268);
            this.DGVsum.TabIndex = 24;
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 494);
            this.Controls.Add(this.DGVsum);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dateTimePk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblKhachSan);
            this.Controls.Add(this.DVG);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVsum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblKhachSan;
        private System.Windows.Forms.DataGridView DVG;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePk;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView DGVsum;
    }
}