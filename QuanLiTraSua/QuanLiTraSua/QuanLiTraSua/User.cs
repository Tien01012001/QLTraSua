using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiTraSua
{
    class User
    {
        MY_DB mydb = new MY_DB();
        public bool insertTK(string matk, string password, int role)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spThemTaiKhoan";
            comand.Parameters.Add("@maNV", SqlDbType.VarChar).Value = matk;
            comand.Parameters.Add("@Pword", SqlDbType.VarChar).Value = password;
            comand.Parameters.Add("@IDLoaiQuyen", SqlDbType.Int).Value = role;
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
        public bool updateTK(string matk, string password, int role)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spSuaTaiKhoan_TheoTenTK";
            comand.Parameters.Add("@maNV", SqlDbType.VarChar).Value = matk;
            comand.Parameters.Add("@Pword", SqlDbType.VarChar).Value = password;
            comand.Parameters.Add("@IDLoaiQuyen", SqlDbType.Int).Value = role;


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

        public bool deleteTK(string matk)
        {
            SqlCommand command = new SqlCommand();
            mydb.openConection();
            command.Connection = mydb.getConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spXoaTaiKhoan_TheoTenTK";
            command.Parameters.Add("@maNV", SqlDbType.VarChar).Value = matk;


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
        public bool TKExist(string HD)
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

        public DataTable getAllTK()
        {
            SqlCommand command = new SqlCommand("select * from viewUser ", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getTK(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
