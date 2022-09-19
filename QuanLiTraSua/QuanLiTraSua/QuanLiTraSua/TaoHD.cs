using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiTraSua
{
    public partial class TaoHD : Form
    {
        public TaoHD()
        {
            InitializeComponent();
        }
        HoaDon hd = new HoaDon();
        ClassKhachHang kh = new ClassKhachHang();
        NVien nv = new NVien();
        public void reload()
        {
            SqlCommand command = new SqlCommand("Select * FROM viewHoaDon");
            dataGridViewHD.ReadOnly = true;
            dataGridViewHD.RowTemplate.Height = 80;
            dataGridViewHD.DataSource = hd.getHD(command);
            dataGridViewHD.AllowUserToAddRows = false;
            dataGridViewHD.Columns[0].HeaderText = "Mã Hóa đơn";
            dataGridViewHD.Columns[1].HeaderText = "Ngày tạo";
            dataGridViewHD.Columns[2].HeaderText = "Mã Khách Hàng";
            dataGridViewHD.Columns[3].HeaderText = "Mã Sản Phẩm";
            dataGridViewHD.Columns[4].HeaderText = "Số lượng";
            dataGridViewHD.Columns[5].HeaderText = "Tổng tiền";
            dataGridViewHD.Columns[6].HeaderText = "Mã Nhân Viên";

        }
        private void TaoHD_Load(object sender, EventArgs e)
        {
            
            comboBoxkh.DataSource = hd.getAllKH();
            comboBoxkh.DisplayMember = "IDkh";
            comboBoxkh.ValueMember = "IDkh";
            comboBoxkh.SelectedItem = null;

            comboBoxnv.Text = Global.GlobalUserId.ToString();
            

            SqlCommand command = new SqlCommand("Select * FROM viewSanPham");
            DVG.AllowUserToAddRows = false;
            DVG.DataSource = hd.getHD(command);
            DVG.Columns[0].HeaderText = "Mã Sản Phẩm";
            DVG.Columns[1].HeaderText = "Tên Sản Phẩm";
            DVG.Columns[2].HeaderText = "Giá";

            textBoxSL.Text = "0";
            Day.Value = DateTime.Now;
            reload();
          
        }

        private void comboBoxkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string ma = Convert.ToString(comboBoxkh.SelectedValue);
                DataTable table = new DataTable();
                table = kh.getCourseByMaKH(ma);
                txtHoTen.Text = table.Rows[0][1].ToString();
      

            }
            catch { }
        }

        private void DVG_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtTong.Text = (Convert.ToInt32(DVG.CurrentRow.Cells[2].Value.ToString())* Convert.ToInt32(textBoxSL.Text.ToString())).ToString();
        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            string IDhoadon = textBoxidhd.Text.ToString();
            DateTime ngaytao = Day.Value;
            string IDkh = comboBoxkh.Text.ToString();
            string IDsanpham = DVG.CurrentRow.Cells[0].Value.ToString();
            int SLsanpham = int.Parse(textBoxSL.Text.ToString());
            int TongTien = int.Parse(txtTong.Text.ToString());
            string maNV = comboBoxnv.Text.ToString();
            if (verif())
            {
                if (!hd.HDExist(IDhoadon))
                {

                    if (hd.insertHD(IDhoadon, ngaytao, IDkh, IDsanpham,SLsanpham,TongTien,maNV))
                    {

                        MessageBox.Show("Đã thêm Hoa Don", "add HD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("error", "add HD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("the IDhoadon already exists", "add HD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("empty fieds", "add HD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool verif()
            {
                if ((textBoxidhd.Text.Trim() == "")
                    || (comboBoxkh.Text.Trim() == "")
                    || (comboBoxnv.Text.Trim() == ""))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            reload();
        }

        private void textBoxSL_TextChanged(object sender, EventArgs e)
        {
            txtTong.Text = (Convert.ToInt32(DVG.CurrentRow.Cells[2].Value.ToString()) * Convert.ToInt32(textBoxSL.Text.ToString())).ToString();
        }
    }
}
