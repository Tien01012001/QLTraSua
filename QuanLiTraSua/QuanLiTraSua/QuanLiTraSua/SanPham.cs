using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiTraSua
{
    class SanPham
    {
       
            MY_DB mydb = new MY_DB();
            public bool insertSP(string id, string Tensp, int Gia)
            {
                SqlCommand comand = new SqlCommand();
                mydb.openConection();
                comand.Connection = mydb.getConnection;
                comand.CommandType = CommandType.StoredProcedure;
                comand.CommandText = "spSanPham";
                comand.Parameters.Add("@IDsanpham", SqlDbType.VarChar).Value = id;
                comand.Parameters.Add("@Tensp", SqlDbType.NVarChar).Value = Tensp;
                comand.Parameters.Add("@GiaTien", SqlDbType.VarChar).Value = Gia;


                
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
            public bool updateSP(string id, string Tensp, int gia)
            {
                SqlCommand comand = new SqlCommand();
                mydb.openConection();
                comand.Connection = mydb.getConnection;
                comand.CommandType = CommandType.StoredProcedure;
                comand.CommandText = "spCapNhatSanPham";
                comand.Parameters.Add("@IDsanpham", SqlDbType.VarChar).Value = id;
                comand.Parameters.Add("@Tensp", SqlDbType.NVarChar).Value = Tensp;
                comand.Parameters.Add("@GiaTien", SqlDbType.VarChar).Value = gia;

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
            public bool deleteSP(string id)
            {
                SqlCommand command = new SqlCommand();
                mydb.openConection();
                command.Connection = mydb.getConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spXoaSanPham_TheoID";
                command.Parameters.Add("@IDsanpham", SqlDbType.NVarChar).Value = id;
                
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
            public bool SPExist(string ID)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[F_SPById] (@IDsp)", mydb.getConnection);
                command.Parameters.Add("@IDsp", SqlDbType.VarChar).Value = ID;

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
            public DataTable getSP(SqlCommand command)
            {
                command.Connection = mydb.getConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }

        
    
    }
}
