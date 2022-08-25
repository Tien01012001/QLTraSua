using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiTraSua
{
    class NVien
    {
        MY_DB mydb = new MY_DB();
        public bool insertNV(string id, string TenNV, string Gioitinh, DateTime bdate, string phone, string address, string LoaiNV, int Luong)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spThemNhanVien";
            comand.Parameters.Add("@maNV", SqlDbType.VarChar).Value = id;
            comand.Parameters.Add("@tenNV", SqlDbType.NVarChar).Value = TenNV;
            comand.Parameters.Add("@Gtinh", SqlDbType.NVarChar).Value = Gioitinh;
            comand.Parameters.Add("@Nsinh", SqlDbType.DateTime).Value = bdate;

            comand.Parameters.Add("@SDt", SqlDbType.VarChar).Value = phone;
            comand.Parameters.Add("@Dchi", SqlDbType.NVarChar).Value = address;
            comand.Parameters.Add("@LoaiNV", SqlDbType.NVarChar).Value = LoaiNV;
            comand.Parameters.Add("@Luong", SqlDbType.Int).Value = Luong;



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
        public bool updateNV(string id, string TenNV, string Gioitinh, DateTime bdate, string phone, string address, string LoaiNV, int Luong)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spCapNhatNhanVien";
            comand.Parameters.Add("@maNV", SqlDbType.VarChar).Value = id;
            comand.Parameters.Add("@tenNV", SqlDbType.NVarChar).Value = TenNV;
            comand.Parameters.Add("@Gtinh", SqlDbType.NVarChar).Value = Gioitinh;
            comand.Parameters.Add("@Nsinh", SqlDbType.DateTime).Value = bdate;

            comand.Parameters.Add("@SDt", SqlDbType.VarChar).Value = phone;
            comand.Parameters.Add("@Dchi", SqlDbType.NVarChar).Value = address;
            comand.Parameters.Add("@LoaiNV", SqlDbType.NVarChar).Value = LoaiNV;
            comand.Parameters.Add("@Luong", SqlDbType.Int).Value = Luong;



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
        public DataTable getNV(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool deleteNV(string id)
        {
            SqlCommand comand = new SqlCommand();
            mydb.openConection();
            comand.Connection = mydb.getConnection;
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "spXoaNhanVien_MaNV";
            comand.Parameters.Add("@maNV", SqlDbType.VarChar).Value = id;

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
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[F_NVById](@id)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = ID;

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
        public DataTable getNVByID(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[F_NVById](@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getAllNV()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM viewNhanVien", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
