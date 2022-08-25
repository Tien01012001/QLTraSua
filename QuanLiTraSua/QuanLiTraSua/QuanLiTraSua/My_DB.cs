using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiTraSua
{
   

    
        class MY_DB
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-20SIVOG;Initial Catalog=QLTS;Integrated Security=True");
            public SqlConnection getConnection
            {
                get
                {
                    return con;
                }
            }

            public void openConection()
            {
                if ((con.State == ConnectionState.Closed))
                {
                    con.Open();
                }
            }
            public void closeConnection()
            {
                if ((con.State == ConnectionState.Open))
                {
                    con.Close();
                }
            }
            public DataTable bangdulieu = new DataTable();
            public DataTable laybang(string caulenh)
            {
                try
                {
                    openConection();
                    SqlDataAdapter Adapter = new SqlDataAdapter(caulenh, con);
                    DataSet ds = new DataSet();

                    Adapter.Fill(bangdulieu);
                }
                catch (System.Exception)
                {
                    bangdulieu = null;
                }
                finally
                {
                    closeConnection();
                }

                return bangdulieu;
            }
        }
    

}
