using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF {
    public class DataAdapters {
        public string MyConnectionString = "Server=localhost;Database=HandUp;Uid=root;Pwd=Password1;";
        public void InsertData(string InsertData) {
        }

        public void UpdateData(string InsertData) {
        }

        public DataSet RetrieveTable(string QueryString) {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "Select * from tblEmployees";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds;
        }
    }
}