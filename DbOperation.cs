using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace OOP10052013
{
    class DbOperation
    {
        SqlConnection connection;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDa;
        string cnnStr;
        public DbOperation()
        {
            cnnStr = "Data Source=.\\SQL;Initial Catalog=TermProject;Integrated Security=true;";
        }
        public DbOperation(string connStr)
        {
            cnnStr = connStr;
        }
        public DataTable SelectTable(string cmdStr)
        {
            connection = new SqlConnection(cnnStr);
            sqlCmd = new SqlCommand(cmdStr, connection);
            sqlDa = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            try
            {
                sqlDa.Fill(dt);
            }
            catch
            {
                
            }
            return dt;
        }

        public int runCommand(string cmdStr)
        {
            int numberOfRows = 0;
            connection = new SqlConnection(cnnStr);
            sqlCmd = new SqlCommand(cmdStr, connection);
            try
            {
                connection.Open();
                numberOfRows = sqlCmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                numberOfRows = -1;
                connection.Close();
            }
            return numberOfRows;

        }
    }
}
