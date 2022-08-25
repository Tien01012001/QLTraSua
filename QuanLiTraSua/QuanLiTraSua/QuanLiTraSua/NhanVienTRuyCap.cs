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
    public partial class NhanVienTRuyCap : Form
    {
        public NhanVienTRuyCap()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            QuanLyKhach kh = new QuanLyKhach();
            kh.Show(this);
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            TaoHD thd = new TaoHD();
            thd.Show(this);
        }
    }
}
