using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblStockleveltype{
		public const string _PKISTOCKLEVELTYPEID="PKistockleveltypeID";
		public const string _TBLSTOCKLEVELTYPEDESCRIPTION="tblStockLevelTypeDescription";
		public const string _tblStockleveltype="tblstockleveltype";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKistockleveltypeID;
		public int PKistockleveltypeID{
			get {
				return _PKistockleveltypeID;
			}
			set {
				_PKistockleveltypeID = value;
			}
		}
		private string _tblStockLevelTypeDescription;
		public string tblStockLevelTypeDescription{
			get {
				return _tblStockLevelTypeDescription;
			}
			set {
				_tblStockLevelTypeDescription = value;
			}
		}
		private string sOrderBy="PKistockleveltypeID";
		private string sOrderType="ASC";

		public tblStockleveltype(int initPKistockleveltypeID){
			addEquals(_PKISTOCKLEVELTYPEID,initPKistockleveltypeID);
			List<tblStockleveltype> listtblStockleveltype=executeSelect();
			tblStockleveltype atblStockleveltype=listtblStockleveltype[0];
			this.PKistockleveltypeID=atblStockleveltype.PKistockleveltypeID;
			this.tblStockLevelTypeDescription=atblStockleveltype.tblStockLevelTypeDescription;
		}

		public tblStockleveltype(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblStockleveltype> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblStockleveltype> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblStockleveltype> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblStockleveltype> listtblStockleveltype=new List<tblStockleveltype>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblStockleveltype atblStockleveltype= new tblStockleveltype();
					iIndex=aSqlReader.GetOrdinal("PKistockleveltypeID");
					atblStockleveltype.PKistockleveltypeID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("tblStockLevelTypeDescription");
					atblStockleveltype.tblStockLevelTypeDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblStockleveltype.Add(atblStockleveltype);
					}
			}
			aSqlReader.Close();
			return listtblStockleveltype;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblstockleveltype WHERE "+ sSqlWhere;
			sCompleteSQL+=" ORDER BY " + sOrderBy + " " + sOrderType;
			return sCompleteSQL;
		}

		public DataSet executeSelectDataSet(){
			return getConnectionAndExecuteSelectDataSet(getCompleteSQL());
		}

		public DataSet executeSelectDataSet(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelectDataSet(getCompleteSQL());
		}

		public DataSet executeCustomSQLDataSet(string sCustomSQL){
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sCustomSQL;
			MySqlDataAdapter aDataAdapter = new MySqlDataAdapter(aSqlCommand);
			DataSet aDataSet = new DataSet();
			aDataAdapter.Fill(aDataSet);
			return aDataSet;
		}

		private DataSet getConnectionAndExecuteSelectDataSet(string sSelectStmt){
			List<tblStockleveltype> listtblStockleveltype=new List<tblStockleveltype>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataAdapter aDataAdapter = new MySqlDataAdapter(aSqlCommand);
			DataSet aDataSet = new DataSet();
			aDataAdapter.Fill(aDataSet);
			return aDataSet;
		}


			public string addEquals(string sColumnName,int aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" = "+aValue;
				sReturnString = sColumnName +" = "+aValue;
				return sReturnString;
			}

			public string addEquals(string sColumnName,string aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" = "+"\'"+aValue+"\'";
				sReturnString = sColumnName +" = "+"\'"+aValue+"\'";
				return sReturnString;
			}

			public string addLike(string sColumnName,int aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" LIKE "+aValue;
				sReturnString = sColumnName +" LIKE "+aValue;
				return sReturnString;
			}

			public string addLike(string sColumnName,string aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" LIKE "+"\'"+aValue+"%\'";
				sReturnString = sColumnName +" LIKE "+"\'"+aValue+"%\'";
				return sReturnString;
			}

			public string addLessThan(string sColumnName,int aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" < "+aValue;
				sReturnString= sColumnName +" < "+aValue;
				return sReturnString;
			}

			public string addLessThan(string sColumnName,string aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" < "+"\'"+aValue+"%\'";
				sReturnString= sColumnName +" < "+"\'"+aValue+"%\'";
				return sReturnString;
			}

			public string addGreaterThan(string sColumnName,int aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" > "+aValue;
				sReturnString= sColumnName +" > "+aValue;
				return sReturnString;
			}

			public string addGreaterThan(string sColumnName,string aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" > "+"\'"+aValue+"%\'";
				sReturnString= sColumnName +" > "+"\'"+aValue+"%\'";
				return sReturnString;
			}

			public string addIsNull(string sColumnName){
				sSqlWhere += sColumnName +" IS NULL";
				return sColumnName +" IS NULL";
			}

			public string addIsNotNull(string sColumnName){
				sSqlWhere += sColumnName +" IS NOT NULL";
				return sColumnName +" IS NOT NULL";
			}

			public string addAND(){
				sSqlWhere += " AND ";
				return " AND ";
			}

			public string addOR(){
				sSqlWhere += " OR ";
				return " OR ";
			}

			public string setOrderByTypeASC(){
				sOrderType = "ASC";
				return "ASC";
			}

			public string setOrderByTypeDESC(){
				sOrderType = "DESC";
				return "DESC";
			}

			public tblStockleveltype executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblstockleveltype_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKistockleveltypeID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKistockleveltypeID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@tblStockLevelTypeDescription",tblStockLevelTypeDescription);
				insertCommand.ExecuteNonQuery();
             PKistockleveltypeID= (Int32)insertCommand.Parameters["@outPKistockleveltypeID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblstockleveltype_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKistockleveltypeID", PKistockleveltypeID);
				updateCommand.Parameters.AddWithValue("@intblStockLevelTypeDescription", tblStockLevelTypeDescription);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
