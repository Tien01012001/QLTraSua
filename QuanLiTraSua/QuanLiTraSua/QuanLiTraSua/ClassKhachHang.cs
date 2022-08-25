using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiTraSua
{
    class ClassKhachHang
    {
        MY_DB mydb = new MY_DB();
        public bool insertKH(string MaKH, string TenKH,string Dchi, string phone)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spThemKhachHang";
            comand.Parameters.Add("@IDkh", SqlDbType.VarChar).Value = MaKH;
            comand.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = TenKH; 
            comand.Parameters.Add("@Dchi", SqlDbType.NVarChar).Value = Dchi;
            comand.Parameters.Add("@SDT", SqlDbType.VarChar).Value = phone;
            //comand.ExecuteNonQuery();
           
            if ((comand.ExecuteNonQuery() == 1))
            {
                //int x = comand.ExecuteNonQuery();
                //MessageBox.Show("x là"+ x, "add KH", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateKH(string MaKH, string TenKH, string Dchi, string phone)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spCapNhatKhachHang";
            comand.Parameters.Add("@IDkh", SqlDbType.VarChar).Value = MaKH;
            comand.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = TenKH;
            comand.Parameters.Add("@Dchi", SqlDbType.NVarChar).Value = Dchi;
            comand.Parameters.Add("@SDT", SqlDbType.VarChar).Value = phone;
            //comand.ExecuteNonQuery();

            
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
        public DataTable getKH(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool deleteKH(string id)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spXoaKH_TheoID";
            comand.Parameters.Add("@IDkh", SqlDbType.VarChar).Value = id;
            
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
        public bool NVExist(string ID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[F_KhachHangById] (@IDkh)", mydb.getConnection);
            command.Parameters.Add("@IDkh", SqlDbType.VarChar).Value = ID;

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
        public DataTable getAllPhong()
        {
            SqlCommand command = new SqlCommand("select * from viewKhachHang", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseByMaKH(string Makh)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[F_KhachHangById] (@IDkh)", mydb.getConnection);
            command.Parameters.Add("@IDkh", SqlDbType.VarChar).Value = Makh;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
