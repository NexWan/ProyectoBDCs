using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ConnectionObj
    {
        private OracleConnection conn;

        public ConnectionObj() {
            conn = new OracleConnection();
        }

        public OracleConnection getConnection(string user, string pwd)
        {
            try
            {
                conn.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)" +
                    "(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))" +
                    $";User Id={user};Password={pwd};";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                conn = null;
            }
            return conn;
        }
    }
}
