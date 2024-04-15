using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;
using System.Configuration;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitiazeConnections(DatabaseType db)
        {
            //switch (db)
            //{
            //    case DatabaseType.Sql:
            //        break;
            //    case DatabaseType.TextFile:
            //        break;
            //    default:
            //        break;
            //}
            if (db == DatabaseType.Sql)
            {
                //TODO - set SQL connection properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
           else if (db == DatabaseType.TextFile)
            {
                //TODO - create text connection
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string cnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}