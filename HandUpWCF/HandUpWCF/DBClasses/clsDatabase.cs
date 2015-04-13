using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HandUpWCF.DBClasses{
	public sealed class clsDatabase{
		static clsDatabase instance=null;
		static readonly object padlock=new object();
		static private MySqlConnection _sqlConnection;
		static private string _sConnString="server=127.0.0.1;uid=Handup;pwd=Password1;database=Handup;";

		private clsDatabase(){
			if (_sqlConnection==null){
				_sqlConnection = new MySqlConnection(_sConnString);
				_sqlConnection.Open();
				Console.WriteLine("Created Connection in pool..");
			}
			else{
				if(_sqlConnection.State.Equals("Close")){
					_sqlConnection.Open();
				}
			}
		}

		public static MySqlConnection getPooledConnection(){
			lock(padlock){
				if(instance==null){
					instance=new clsDatabase();
				}
				if (_sqlConnection.State.ToString().Equals("Closed")) {
					_sqlConnection = new MySqlConnection(_sConnString);
					_sqlConnection.Open();
				}
				return _sqlConnection;
			}
		}

		public static void closePooledConnection() {
			try {
				if (_sqlConnection.State.Equals("Open")) {
					_sqlConnection.Close();
				}
				_sqlConnection.Close();
				_sqlConnection.Dispose();
				Console.WriteLine("Closing Connection....");
			}
			catch (Exception exp) {
				Console.WriteLine("Error closing connection. Possible reasons :- " + exp.ToString());
			}
		}
	}
}
