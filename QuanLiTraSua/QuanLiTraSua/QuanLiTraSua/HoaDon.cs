using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiTraSua
{
    class HoaDon
    {
        MY_DB mydb = new MY_DB();
        public bool insertHD(string Mahd, DateTime ngaytao, string MaK, string idsp,int sl,int tongtien, string MaNV)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spThemHoaDon";
            comand.Parameters.Add("@IDhoadon", SqlDbType.VarChar).Value = Mahd;
            comand.Parameters.Add("@NgayTao", SqlDbType.DateTime).Value = ngaytao;
            comand.Parameters.Add("@IDkh", SqlDbType.VarChar).Value = MaK;
            comand.Parameters.Add("@IDsanpham", SqlDbType.VarChar).Value = idsp;
            comand.Parameters.Add("@SLsanpham", SqlDbType.Int).Value = sl;
            comand.Parameters.Add("@TongTien", SqlDbType.VarChar).Value = tongtien;
            comand.Parameters.Add("@maNV", SqlDbType.VarChar).Value = Global.GlobalUserId;
            


            if ((comand.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateHD(string Mahd, DateTime ngaytao, string MaK, string idsp, int sl, int tongtien, int MaNV)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spCapNhatHoaDon";
            comand.Parameters.Add("@IDhoadon", SqlDbType.VarChar).Value = Mahd;
            comand.Parameters.Add("@NgayTao", SqlDbType.DateTime).Value = ngaytao;
            comand.Parameters.Add("@IDkh", SqlDbType.VarChar).Value = MaK;
            comand.Parameters.Add("@IDsanpham", SqlDbType.VarChar).Value = idsp;
            comand.Parameters.Add("@SLsanpham", SqlDbType.Int).Value = sl;
            comand.Parameters.Add("@TongTien", SqlDbType.VarChar).Value = tongtien;
            comand.Parameters.Add("@maNV", SqlDbType.VarChar).Value = MaNV;


            if ((comand.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool deleteHD(string id)
        {
            SqlCommand command = new SqlCommand();
            mydb.openConection();
            command.Connection = mydb.getConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spXoaHoaDon_TheoMaHoaDon";
            command.Parameters.Add("@IDhoadon", SqlDbType.NVarChar).Value = id;

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }
        public bool HDExist(string HD)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[F_HoaDonById] (@IDhd)", mydb.getConnection);
            command.Parameters.Add("@IDhd", SqlDbType.VarChar).Value = HD;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public DataTable getAllHoaDon()
        {
            SqlCommand command = new SqlCommand("select * from viewHoaDon", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getHD(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getAllKH()
        {
            SqlCommand command = new SqlCommand("select * from viewKhachHang", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
