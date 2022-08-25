using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiTraSua
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void quanLyPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Menu menu = new Menu();
            menu.Show(this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NhanVIen nv = new NhanVIen();
            nv.Show(this);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            QuanLyKhach ql = new QuanLyKhach();
            ql.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe();
            tk.Show(this);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            TaoHD taoHD = new TaoHD();
            taoHD.Show(this);
        }

        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyUser user = new QuanLyUser();
            user.Show();
        }
    }
}
