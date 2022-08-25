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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.ToString();
            string pass = txtMatKhau.Text.ToString();
            SqlCommand comand = new SqlCommand("SELECT * FROM [dbo].[F_KTDangNhap](@ten,@pass)", mydb.getConnection);
            comand.Parameters.Add("@ten", SqlDbType.VarChar).Value = user;
            comand.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            SqlDataAdapter adapter = new SqlDataAdapter(comand);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table.Rows.Count>0)
            {
                MessageBox.Show("Dang Nhap Thanh Cong");
                if (table.Rows[0][2].ToString() == '1'.ToString()) {
                    string userid = table.Rows[0][0].ToString();
                    Global.SetGlobalUserId(userid);
                    Home home = new Home();
                    home.Show(this);
                }
                else
                {
                    string userid = table.Rows[0][0].ToString();
                    Global.SetGlobalUserId(userid);
                    NhanVienTRuyCap nv = new NhanVienTRuyCap();
                    nv.Show(this);
                }

            }
            else
                MessageBox.Show("Dang Nhap That bai");
        }
    }
}
