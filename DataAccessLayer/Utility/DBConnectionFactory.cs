using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Text;

namespace DataAccessLayer.Utility
{
    class DbConnectionFactory
    {
        public static IDbConnection GetDbConnection(DbConnectionTypes dbType, string connectionString)
        {
            IDbConnection connection = null;

            switch (dbType)
            {
                case DbConnectionTypes.SQL:
                    connection = new SqlConnection(connectionString);
                    break;
                case DbConnectionTypes.SQlite:
                    connection = new SQLiteConnection(connectionString);
                    break;
                case DbConnectionTypes.Oracle:

                    break;
                case DbConnectionTypes.XML:

                    break;
                case DbConnectionTypes.DOCUMENT:

                    break;
                default:
                    connection = null;
                    break;
            }

            connection.Open();
            return connection;
        }
    }

    public enum DbConnectionTypes
    {
        SQL,
        SQlite,
        Oracle,
        DOCUMENT,
        XML
    }
}
