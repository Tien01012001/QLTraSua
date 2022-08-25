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
    public partial class QuanLyUser : Form
    {
        public QuanLyUser()
        {
            InitializeComponent();
        }
        User user = new User();
        public void reload()
        {
            SqlCommand command = new SqlCommand("select * from viewUser");
            dataGridViewTK.ReadOnly = true;
            dataGridViewTK.RowTemplate.Height = 80;
            dataGridViewTK.DataSource = user.getTK(command);
            dataGridViewTK.AllowUserToAddRows = false;
            dataGridViewTK.Columns[0].HeaderText = "Mã Nhân Viên";
            dataGridViewTK.Columns[1].HeaderText = "Mật khẩu";
            dataGridViewTK.Columns[2].HeaderText = "Loại quyền";

        }
        private void QuanLyUser_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string ID = txtNVID.Text.ToString();
            
            string pass = txtPass.Text.ToString();
            int lquyen = int.Parse(txtLoaiQuyen.Text.ToString());
            
            if (verif())
            {
                if (!user.TKExist(ID))
                {

                    if (user.insertTK(ID, pass,lquyen))
                    {

                        MessageBox.Show("tài khoản đã được thêm", "add TK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("error", "add TK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("the maNV already exists", "add tk", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("empty fieds", "add HD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool verif()
            {
                if ((txtNVID.Text.Trim() == "")
                    || (txtPass.Text.Trim() == "")
                    || (txtLoaiQuyen.Text.Trim() == ""))
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

        private void dataGridViewTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNVID.Text = dataGridViewTK.CurrentRow.Cells[0].Value.ToString();
            txtPass.Text = dataGridViewTK.CurrentRow.Cells[1].Value.ToString();
            txtLoaiQuyen.Text= dataGridViewTK.CurrentRow.Cells[2].Value.ToString();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string ID = txtNVID.Text.ToString();

            string pass = txtPass.Text.ToString();
            int lquyen = int.Parse(txtLoaiQuyen.Text.ToString());

            if (verif())
            {
                

                    if (user.updateTK(ID, pass, lquyen))
                    {

                        MessageBox.Show("tài khoản đã được cập nhật", "update TK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("error", "update TK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }
            else
            {
                MessageBox.Show("empty fieds", "update HD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bool verif()
            {
                if ((txtNVID.Text.Trim() == "")
                    || (txtPass.Text.Trim() == "")
                    || (txtLoaiQuyen.Text.Trim() == ""))
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
            try
            {
                string MaNV = txtNVID.Text;
                if ((MessageBox.Show("bạn có muốn xóa Tài Khoản này không này không?", "delete tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (user.deleteTK(MaNV))
                    {
                        MessageBox.Show("da xoa tài khoản ", "delete tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNVID.Text = "";
                        txtPass.Text = "";

                        txtLoaiQuyen.Text = "";
                        
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản chưa được xóa", "delete tài khoản ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("please enter v valid Mã TK", "delete TK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reload();
        }
    }
}
