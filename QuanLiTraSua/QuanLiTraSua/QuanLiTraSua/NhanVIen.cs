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
    public partial class NhanVIen : Form
    {
        public NhanVIen()
        {
            InitializeComponent();
        }
        NVien nv = new NVien();
        public void reload()
        {
            SqlCommand command = new SqlCommand("SELECT  * FROM viewNhanVien");
            SqlDataAdapter stdTableAdapte = new SqlDataAdapter(command);


            dgvThongTinNhanVien.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dgvThongTinNhanVien.RowTemplate.Height = 80;
            dgvThongTinNhanVien.DataSource = nv.getNV(command);
         
            dgvThongTinNhanVien.AllowUserToAddRows = false;
            dgvThongTinNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvThongTinNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvThongTinNhanVien.Columns[3].HeaderText = "Ngày sinh";
         
            dgvThongTinNhanVien.Columns[4].HeaderText = "Số ĐT";
            dgvThongTinNhanVien.Columns[5].HeaderText = "Địa Chỉ";
            dgvThongTinNhanVien.Columns[6].HeaderText = "Loại Nhân Viên";
            dgvThongTinNhanVien.Columns[7].HeaderText = "Lương";
        }
        private void NhanVIen_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {

            string id = txtNVID.Text;
     
            string name = txtHoTen.Text;
            DateTime bdate = DateTimeBirthday.Value;
            string phone = txtSDT.Text;
            string adrs = txtDiaChi.Text;
            string gender = txtGioiTinh.Text;
            string loai = txtMaCN.Text;
            int luong = int.Parse(txtLuong.Text);
            int born_year = DateTimeBirthday.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || (this_year - born_year) > 100)
            {
                MessageBox.Show("the student age must be between 10 and 100 year", "ngay sinh k hop le", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                if (!nv.NVExist(id))
                {
                    
                    if (nv.insertNV(id, name, gender, bdate, phone, adrs,loai,luong ))
                    {
                        MessageBox.Show("new nv add", "add nv", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("error", "add nv", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("the IDNV already exists", "add score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("empty fieds", "add nv", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool verif()
            {
                if ((txtHoTen.Text.Trim() == "")
                    || (txtGioiTinh.Text.Trim() == "")
                    || (txtMaCN.Text.Trim() == "")
                    || (txtSDT.Text.Trim() == "")
                    || (txtLuong.Text.Trim() == "")
                    || (txtDiaChi.Text.Trim() == "")
                    || (txtNVID.Text.Trim() == ""))
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

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string ID = dgvThongTinNhanVien.CurrentRow.Cells[0].Value.ToString();
            nv.deleteNV(ID);
            reload();
        }

        private void dgvThongTinNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNVID.Text= dgvThongTinNhanVien.CurrentRow.Cells[0].Value.ToString();

            txtHoTen.Text= dgvThongTinNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtGioiTinh.Text = dgvThongTinNhanVien.CurrentRow.Cells[2].Value.ToString();
            DateTimeBirthday.Value= DateTime.Parse(dgvThongTinNhanVien.CurrentRow.Cells[3].Value.ToString());
            txtSDT.Text= dgvThongTinNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtDiaChi.Text= dgvThongTinNhanVien.CurrentRow.Cells[5].Value.ToString();
           
            txtMaCN.Text= dgvThongTinNhanVien.CurrentRow.Cells[6].Value.ToString();
            txtLuong.Text= dgvThongTinNhanVien.CurrentRow.Cells[7].Value.ToString();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string id = txtNVID.Text;

            string name = txtHoTen.Text;
            DateTime bdate = DateTimeBirthday.Value;
            string phone = txtSDT.Text;
            string adrs = txtDiaChi.Text;
            string gender = txtGioiTinh.Text;
            string loai = txtMaCN.Text;
            int luong = int.Parse(txtLuong.Text);
            int born_year = DateTimeBirthday.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || (this_year - born_year) > 100)
            {
                MessageBox.Show("the student age must be between 10 and 100 year", "ngay sinh k hop le", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                

                    if (nv.updateNV(id, name, gender, bdate, phone, adrs, loai, luong))
                    {
                        MessageBox.Show("new nv add", "add nv", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("error", "update nv", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
               
            }
            else
            {
                MessageBox.Show("empty fieds", "add nv", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool verif()
            {
                if ((txtHoTen.Text.Trim() == "")
                    || (txtGioiTinh.Text.Trim() == "")
                    || (txtMaCN.Text.Trim() == "")
                    || (txtSDT.Text.Trim() == "")
                    || (txtDiaChi.Text.Trim() == "")
                    || (txtNVID.Text.Trim() == ""))
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

        private void panelNV_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
