using Microsoft.Office.Interop.Word;
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
using DataTable = System.Data.DataTable;
using Word = Microsoft.Office.Interop.Word;

namespace QuanLiTraSua
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        HoaDon hd = new HoaDon();
        MY_DB mydb = new MY_DB();
        public void reload()
        {
            SqlCommand command = new SqlCommand("Select * FROM viewHoaDon");
            DVG.AllowUserToAddRows = false;
            DVG.DataSource = hd.getHD(command);
            DVG.Columns[0].HeaderText = "Mã Hoá Đơn";
            DVG.Columns[1].HeaderText = "Ngày tạo";
            DVG.Columns[2].HeaderText = "Mã Khách Hàng";
            DVG.Columns[3].HeaderText = "Mã Sản Phẩm";
            DVG.Columns[4].HeaderText = "Số lượng";
            DVG.Columns[5].HeaderText = "Tổng Tiền";
            DVG.Columns[6].HeaderText = "Mã Nhân Viên";

        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            reload();
        
        }
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {

            int RowCount = DGV.Rows.Count;
            int ColumnCount = DGV.Columns.Count;
            Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
            for (int j = 0; j < ColumnCount; j++)
            {
                for (int i = 0; i < RowCount; i++)
                {
                    DataArray[i, j] = DGV.Rows[i].Cells[j].Value;
                }
            }
            //Create and watch word activity
            Word.Document oDoc = new Word.Document();
            oDoc.Application.Visible = true;
            //Create information title
            object oMissing = System.Reflection.Missing.Value;
            var para = oDoc.Content.Paragraphs.Add(ref oMissing);
            para.Range.Text = "Tra Sua MILKTEA                                                                                                   Thời gian in:  " + DateTime.Now.ToString("HH:mm:ss");
            para.Range.Underline = (WdUnderline)1;
            para.Range.Font.Name = "Times New Roman";
            para.Range.InsertParagraphAfter();
            para.Range.Underline = 0;


            para.Range.Text = "DANH SÁCH HÓA ĐƠN";
            para.Range.Bold = 1;
            para.CharacterUnitLeftIndent = 20;
            para.Range.Font.Size = 16;
            para.Range.Font.Name = "Times New Roman";
            para.Range.InsertParagraphAfter();
            para.Range.InsertParagraphAfter();

            para.Range.Bold = 0;


            

           
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            oDoc.Application.Selection.MoveDown();
            //Create table
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            dynamic oRange = oDoc.Content.Application.Selection.Range;
            string oTemp = "";
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    oTemp = oTemp + DataArray[i, j] + "\t";
                }
            }
            oRange.Text = oTemp;
            object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
            object ApplyBorders = true;
            object AutoFit = true;
            object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;
            oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount, Type.Missing, Type.Missing, ref ApplyBorders, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);
            oRange.Select();
            //Add header row
            oDoc.Application.Selection.Tables[1].Rows[1].Select();
            oDoc.Application.Selection.InsertRowsAbove(1);
            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
            }
            //Table format
            oDoc.Application.Selection.Tables[1].Select();
            oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
            oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
            oDoc.Application.Selection.Tables[1].Range.Font.Name = "Times New Roman";
            oDoc.Application.Selection.Tables[1].Range.Font.Size = 12;
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;
            oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
            oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            oDoc.Application.Selection.Tables[1].Rows[RowCount + 2].Delete();
            //SaveFile
            oDoc.SaveAs2(filename);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DVG.Rows.Count != 0)
            {
                SaveFileDialog svf = new SaveFileDialog();
                svf.Filter = "Word Documents (*.docx)|*.docx";
                svf.FileName = ".docx";
                if (svf.ShowDialog() == DialogResult.OK)
                {
                    Export_Data_To_Word(DVG, svf.FileName);
                }
            }
            else
            {
                MessageBox.Show("Không có hóa đơn nào", "Print HoaDon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string MaP = DVG.CurrentRow.Cells[0].Value.ToString();
                if (MessageBox.Show("bạn có muốn xóa hóa đơn này không?", "delete hd", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (hd.deleteHD(MaP))
                    {
                        MessageBox.Show("da xoa hóa đơn này", "delete hd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("Hóa đơn chưa được xóa", "delete hd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception e1)
            {

                MessageBox.Show("please enter v valid Ma Hoa Don " + e1, "delete sp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime day = dateTimePk.Value;
            //MessageBox.Show("Da them San Pham"+day, "add sp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SqlCommand comand = new SqlCommand("Select * from F_ThuNhapByNgay(@ngay)", mydb.getConnection);
            comand.Parameters.Add("@ngay", SqlDbType.DateTime).Value = day;
            SqlDataAdapter adapter = new SqlDataAdapter(comand);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DGVsum.DataSource = table;
            DGVsum.AllowUserToAddRows = false;
        }
    }
}
