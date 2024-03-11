using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspMvcProject.Models
{
    public class BaseAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool VarifyLogin()
        {
            //Data base connection code

            DataTable dataTable = new DataTable();
            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.Connection = connection;


            cmd.CommandText = "spOst_LstUsers";
            cmd.Parameters.Add(new SqlParameter("@UserName", this.UserName));
            cmd.Parameters.Add(new SqlParameter("@Password", this.Password));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            //SelectCommand selectCommand = new SelectCommand(adapter);
            adapter.Fill(dataTable);
            cmd.Dispose();
            connection.Close();

            //
            var pdata = (from p in dataTable.AsEnumerable()
                         where p.Field<string>("Name") == this.UserName && p.Field<string>("Password") == this.Password
                         select new
                         {
                             UserName = p.Field<string>("Name")
                         }).SingleOrDefault();

            if (dataTable.Rows.Count>0)
            {
                return true;
            }
            return false;

            /*
            if(this.UserName == "Protik" && this.Password == "123456")
            {
                return true;
            }
            return false;
            */
        }
    }
}