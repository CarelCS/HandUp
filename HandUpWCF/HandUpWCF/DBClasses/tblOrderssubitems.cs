using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblOrderssubitems{
		public const string _PKIORDERSSUBITEMID="PKiOrdersSubItemID";
		public const string _FKIORDERSID="FKiOrdersID";
		public const string _FKIMENUID="FKiMenuID";
		public const string _tblOrderssubitems="tblorderssubitems";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiOrdersSubItemID;
		public int PKiOrdersSubItemID{
			get {
				return _PKiOrdersSubItemID;
			}
			set {
				_PKiOrdersSubItemID = value;
			}
		}
		private int _FKiOrdersID;
		public int FKiOrdersID{
			get {
				return _FKiOrdersID;
			}
			set {
				_FKiOrdersID = value;
			}
		}
		private int _FKiMenuID;
		public int FKiMenuID{
			get {
				return _FKiMenuID;
			}
			set {
				_FKiMenuID = value;
			}
		}
		private string sOrderBy="PKiOrdersSubItemID";
		private string sOrderType="ASC";

		public tblOrderssubitems(int initPKiOrdersSubItemID){
			addEquals(_PKIORDERSSUBITEMID,initPKiOrdersSubItemID);
			List<tblOrderssubitems> listtblOrderssubitems=executeSelect();
			tblOrderssubitems atblOrderssubitems=listtblOrderssubitems[0];
			this.PKiOrdersSubItemID=atblOrderssubitems.PKiOrdersSubItemID;
			this.FKiOrdersID=atblOrderssubitems.FKiOrdersID;
			this.FKiMenuID=atblOrderssubitems.FKiMenuID;
		}

		public tblOrderssubitems(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblOrderssubitems> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblOrderssubitems> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblOrderssubitems> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblOrderssubitems> listtblOrderssubitems=new List<tblOrderssubitems>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblOrderssubitems atblOrderssubitems= new tblOrderssubitems();
					iIndex=aSqlReader.GetOrdinal("PKiOrdersSubItemID");
					atblOrderssubitems.PKiOrdersSubItemID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiOrdersID");
					atblOrderssubitems.FKiOrdersID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiMenuID");
					atblOrderssubitems.FKiMenuID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					listtblOrderssubitems.Add(atblOrderssubitems);
					}
			}
			aSqlReader.Close();
			return listtblOrderssubitems;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblorderssubitems WHERE "+ sSqlWhere;
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

		private DataSet getConnectionAndExecuteSelectDataSet(string sSelectStmt){
			List<tblOrderssubitems> listtblOrderssubitems=new List<tblOrderssubitems>();
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

			public string addLike(string sColumnName,int aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" LIKE "+aValue;
				sReturnString = sColumnName +" LIKE "+aValue;
				return sReturnString;
			}

			public string addLessThan(string sColumnName,int aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" < "+aValue;
				sReturnString= sColumnName +" < "+aValue;
				return sReturnString;
			}

			public string addGreaterThan(string sColumnName,int aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" > "+aValue;
				sReturnString= sColumnName +" > "+aValue;
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

			public tblOrderssubitems executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblorderssubitems_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiOrdersSubItemID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiOrdersSubItemID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiOrdersID",FKiOrdersID);
				insertCommand.Parameters.AddWithValue("@FKiMenuID",FKiMenuID);
				insertCommand.ExecuteNonQuery();
             PKiOrdersSubItemID= (Int32)insertCommand.Parameters["@outPKiOrdersSubItemID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblorderssubitems_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiOrdersSubItemID", PKiOrdersSubItemID);
				updateCommand.Parameters.AddWithValue("@inFKiOrdersID", FKiOrdersID);
				updateCommand.Parameters.AddWithValue("@inFKiMenuID", FKiMenuID);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
