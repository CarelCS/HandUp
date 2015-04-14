using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF {
    public class DataAdapters {
        public string MyConnectionString = "Server=localhost;Database=HandUp;Uid=root;Pwd=Password1;";
        public void InsertUpdateData(string InsertData) {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(InsertData, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet RetrieveTable(string QueryString) {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = QueryString;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            connection.Close();
            return ds;
        }
    }
}