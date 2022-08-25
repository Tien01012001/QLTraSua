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
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
        }
        SanPham sp = new SanPham();
        public void reload()
        {
            SqlCommand command = new SqlCommand("Select * FROM viewSanPham ");
            dgvCapNhatSanPham.DataSource = sp.getSP(command);
            dgvCapNhatSanPham.AllowUserToAddRows = false;
            dgvCapNhatSanPham.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvCapNhatSanPham.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvCapNhatSanPham.Columns[2].HeaderText = "Giá Sản Phẩm";
           
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            string madv = textBoxMaSP.Text;
            string tenDV = txtTenSP.Text;
            int gia = int.Parse(txtGia.Text);
          
            if (verif())
            {
                if (!sp.SPExist(madv))
                {

                    if (sp.insertSP(madv, tenDV, gia))
                    {
                        MessageBox.Show("Da them San Pham", "add sp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("error", "add sp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("the maSP already exists", "add sp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("empty fieds", "add sp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool verif()
            {
                if ((textBoxMaSP.Text.Trim() == "")
                    || (txtTenSP.Text.Trim() == "")
                    || (txtGia.Text.Trim() == ""))

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

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                string MaP = textBoxMaSP.Text;
                if (MessageBox.Show("bạn có muốn xóa sản phẩm này không?", "delete sp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (sp.deleteSP(MaP))
                    {
                        MessageBox.Show("da xoa sản phẩm này", "delete sp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxMaSP.Text = "";
                        txtTenSP.Text = "";
                        txtGia.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Dịch vụ chưa được xóa", "delete sp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception e1)
            {

                MessageBox.Show("please enter v valid Mã San Pham " + e1, "delete sp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reload();
        }


        private void btnLuuCapNhatDichVu_Click(object sender, EventArgs e)
        {
            string masp = textBoxMaSP.Text;
            string tensp = txtTenSP.Text;

            int Gia = int.Parse(txtGia.Text);
            
            if (verif())
            {


                if (sp.updateSP(masp, tensp, Gia))
                {
                    MessageBox.Show("đã sửa thông tin", "update sp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("error", "update sp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("empty fieds", "update sp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool verif()
            {
                if ((textBoxMaSP.Text.Trim() == "")
                    || (txtTenSP.Text.Trim() == "")
                    || (txtGia.Text.Trim() == ""))


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

        private void dgvCapNhatSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaSP.Text = dgvCapNhatSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dgvCapNhatSanPham.CurrentRow.Cells[1].Value.ToString(); ;
            txtGia.Text = dgvCapNhatSanPham.CurrentRow.Cells[2].Value.ToString(); ;
        }
    }

}
