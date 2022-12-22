using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QuickscanDAL
{
    public abstract class DatabaseConnectie
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi489724_freshhead;User Id=dbi489724_freshhead;Password=123; TrustServerCertificate=True";

        protected SqlConnection conn { get; set; }
        protected void Connect()
        {
            //connect met de database
            try
            {
                this.conn = new SqlConnection(connectionString);
                this.conn.Open();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        protected void Disconnect()
        {
            //disconnect met de database
            try
            {
                this.conn.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
}
