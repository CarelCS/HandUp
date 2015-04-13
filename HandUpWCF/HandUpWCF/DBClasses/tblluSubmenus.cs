using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblluSubmenus{
		public const string _PKISUBMENUID="PKiSubMenuID";
		public const string _SSUBMENUNAME="sSubMenuName";
		public const string _SSUBMENUDESCRIPTION="sSubMenuDescription";
		public const string _tblluSubmenus="tbllusubmenus";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiSubMenuID;
		public int PKiSubMenuID{
			get {
				return _PKiSubMenuID;
			}
			set {
				_PKiSubMenuID = value;
			}
		}
		private string _sSubMenuName;
		public string sSubMenuName{
			get {
				return _sSubMenuName;
			}
			set {
				_sSubMenuName = value;
			}
		}
		private string _sSubMenuDescription;
		public string sSubMenuDescription{
			get {
				return _sSubMenuDescription;
			}
			set {
				_sSubMenuDescription = value;
			}
		}
		private string sOrderBy="PKiSubMenuID";
		private string sOrderType="ASC";

		public tblluSubmenus(int initPKiSubMenuID){
			addEquals(_PKISUBMENUID,initPKiSubMenuID);
			List<tblluSubmenus> listtblluSubmenus=executeSelect();
			tblluSubmenus atblluSubmenus=listtblluSubmenus[0];
			this.PKiSubMenuID=atblluSubmenus.PKiSubMenuID;
			this.sSubMenuName=atblluSubmenus.sSubMenuName;
			this.sSubMenuDescription=atblluSubmenus.sSubMenuDescription;
		}

		public tblluSubmenus(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblluSubmenus> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblluSubmenus> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblluSubmenus> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblluSubmenus> listtblluSubmenus=new List<tblluSubmenus>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblluSubmenus atblluSubmenus= new tblluSubmenus();
					iIndex=aSqlReader.GetOrdinal("PKiSubMenuID");
					atblluSubmenus.PKiSubMenuID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sSubMenuName");
					atblluSubmenus.sSubMenuName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sSubMenuDescription");
					atblluSubmenus.sSubMenuDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblluSubmenus.Add(atblluSubmenus);
					}
			}
			aSqlReader.Close();
			return listtblluSubmenus;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tbllusubmenus WHERE "+ sSqlWhere;
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
			List<tblluSubmenus> listtblluSubmenus=new List<tblluSubmenus>();
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

			public tblluSubmenus executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tbllusubmenus_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiSubMenuID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiSubMenuID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@sSubMenuName",sSubMenuName);
				insertCommand.Parameters.AddWithValue("@sSubMenuDescription",sSubMenuDescription);
				insertCommand.ExecuteNonQuery();
             PKiSubMenuID= (Int32)insertCommand.Parameters["@outPKiSubMenuID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tbllusubmenus_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiSubMenuID", PKiSubMenuID);
				updateCommand.Parameters.AddWithValue("@insSubMenuName", sSubMenuName);
				updateCommand.Parameters.AddWithValue("@insSubMenuDescription", sSubMenuDescription);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
