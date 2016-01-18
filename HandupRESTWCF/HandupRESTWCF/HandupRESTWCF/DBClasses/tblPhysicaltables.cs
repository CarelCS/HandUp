using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandupRESTWCF.DBClasses{
	class tblPhysicaltables{
		public const string _PKIPHYSICATABLEID="PKiPhysicaTableID";
		public const string _FKIPROVIDERID="FKiProviderID";
		public const string _FKIEMPLOYEEID="FKIEmployeeID";
		public const string _SDESCRIPTION="sDescription";
		public const string _SNAME="sName";
		public const string _tblPhysicaltables="tblphysicaltables";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiPhysicaTableID;
		public int PKiPhysicaTableID{
			get {
				return _PKiPhysicaTableID;
			}
			set {
				_PKiPhysicaTableID = value;
			}
		}
		private int _FKiProviderID;
		public int FKiProviderID{
			get {
				return _FKiProviderID;
			}
			set {
				_FKiProviderID = value;
			}
		}
		private int _FKIEmployeeID;
		public int FKIEmployeeID{
			get {
				return _FKIEmployeeID;
			}
			set {
				_FKIEmployeeID = value;
			}
		}
		private string _sDescription;
		public string sDescription{
			get {
				return _sDescription;
			}
			set {
				_sDescription = value;
			}
		}
		private string _sName;
		public string sName{
			get {
				return _sName;
			}
			set {
				_sName = value;
			}
		}
		private string sOrderBy="PKiPhysicaTableID";
		private string sOrderType="ASC";

		public tblPhysicaltables(int initPKiPhysicaTableID){
			addEquals(_PKIPHYSICATABLEID,initPKiPhysicaTableID);
			List<tblPhysicaltables> listtblPhysicaltables=executeSelect();
			tblPhysicaltables atblPhysicaltables=listtblPhysicaltables[0];
			this.PKiPhysicaTableID=atblPhysicaltables.PKiPhysicaTableID;
			this.FKiProviderID=atblPhysicaltables.FKiProviderID;
			this.FKIEmployeeID=atblPhysicaltables.FKIEmployeeID;
			this.sDescription=atblPhysicaltables.sDescription;
			this.sName=atblPhysicaltables.sName;
		}

		public tblPhysicaltables(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblPhysicaltables> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblPhysicaltables> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblPhysicaltables> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblPhysicaltables> listtblPhysicaltables=new List<tblPhysicaltables>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblPhysicaltables atblPhysicaltables= new tblPhysicaltables();
					iIndex=aSqlReader.GetOrdinal("PKiPhysicaTableID");
					atblPhysicaltables.PKiPhysicaTableID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblPhysicaltables.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKIEmployeeID");
					atblPhysicaltables.FKIEmployeeID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sDescription");
					atblPhysicaltables.sDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sName");
					atblPhysicaltables.sName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblPhysicaltables.Add(atblPhysicaltables);
					}
			}
			aSqlReader.Close();
			return listtblPhysicaltables;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblphysicaltables WHERE "+ sSqlWhere;
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
			List<tblPhysicaltables> listtblPhysicaltables=new List<tblPhysicaltables>();
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

			public tblPhysicaltables executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblphysicaltables_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiPhysicaTableID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiPhysicaTableID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.Parameters.AddWithValue("@FKIEmployeeID",FKIEmployeeID);
				insertCommand.Parameters.AddWithValue("@sDescription",sDescription);
				insertCommand.Parameters.AddWithValue("@sName",sName);
				insertCommand.ExecuteNonQuery();
             PKiPhysicaTableID= (Int32)insertCommand.Parameters["@outPKiPhysicaTableID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblphysicaltables_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiPhysicaTableID", PKiPhysicaTableID);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.Parameters.AddWithValue("@inFKIEmployeeID", FKIEmployeeID);
				updateCommand.Parameters.AddWithValue("@insDescription", sDescription);
				updateCommand.Parameters.AddWithValue("@insName", sName);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
