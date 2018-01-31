using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace MISDAL.ConnectionHelper
{
    public static class DBHelper
    {

        #region Destroy Command Object
        /// <summary>
        /// Closes the Command connection and destroys the Command Object.
        /// </summary>
        /// <param name="dbCmd">Command Object</param>
        public static void Destroy(this DbCommand dbCmd)
        {
            if (dbCmd != null)
            {
                if (dbCmd.Connection.State == ConnectionState.Open)
                {
                    dbCmd.Connection.Close();
                }
            }

            dbCmd = null;
        }

        #endregion

        #region Destroy DataReader Object
        /// <summary>
        /// Closes the reader and destroys the datareader Object.
        /// </summary>
        /// <param name="dread">DataReader Object</param>
        public static void Destroy(ref IDataReader dread)
        {
            if (dread != null)
            {
                dread.Close();
            }

            dread = null;
        }

        #endregion
        public static T AddParameters<T>(this DbCommand cmd,string name, object value, DbType dbType)
        where T:DbParameter
        {
            var parameters = typeof(T);
            DbParameter dbParam = null;
           if(parameters.Name=="SqlParameter")
           {
               dbParam = new SqlParameter();
           }
           else
           {
               dbParam = new OracleParameter();
           }
            dbParam.ParameterName = name;
            dbParam.Value = value;
            dbParam.DbType = dbType;

            return (T) dbParam;
        }
    }
    
}
