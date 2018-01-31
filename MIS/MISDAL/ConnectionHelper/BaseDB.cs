using System.Configuration;
using System.Data.OracleClient;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MISDAL.ConnectionHelper
{
    public class BaseDB
    {
        //property is made protected as it will not be initialized
        /// <summary>
        /// Gets the db.
        /// </summary>
        /// <value>
        /// The db.
        /// </value>
        protected Database db
        {
            get 
            { 
                var db1 = DatabaseFactory.CreateDatabase();
                return db1;
            }
        }
        protected SqlConnection SqlConn
        {
            get
            {
                SqlConnection vcon = null;
                vcon = new SqlConnection(ConnectionString);

                return vcon;
            }
        }
        protected OracleConnection OrlConn
        {
            get
            {
                OracleConnection vcon = null;
                vcon = new OracleConnection(ConnectionString);
                return vcon;
            }
        }
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            }
        }
        protected SqlConnection GetSqlConn()
        {
            SqlConnection vcon = null;
            vcon = new SqlConnection(ConnectionString);

            return vcon;
        }
        protected OracleConnection GetOrclConn()
        {
            OracleConnection vcon = null;
            vcon = new OracleConnection(ConnectionString);
            return vcon;
        }
        

    }
}
