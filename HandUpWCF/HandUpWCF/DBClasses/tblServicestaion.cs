using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblServicestaion{
		public const string _PKISERVICESTAIONID="PKiServiceStaionID";
		public const string _FKIPROVIDEID="FKiProvideID";
		public const string _SNAME="sName";
		public const string _SDESCRIPTION="sDescription";
		public const string _BACTIVESTATUS="bActiveStatus";
		public const string _tblServicestaion="tblservicestaion";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiServiceStaionID;
		public int PKiServiceStaionID{
			get {
				return _PKiServiceStaionID;
			}
			set {
				_PKiServiceStaionID = value;
			}
		}
		private int _FKiProvideID;
		public int FKiProvideID{
			get {
				return _FKiProvideID;
			}
			set {
				_FKiProvideID = value;
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
		private string _sDescription;
		public string sDescription{
			get {
				return _sDescription;
			}
			set {
				_sDescription = value;
			}
		}
		private int _bActiveStatus;
		public int bActiveStatus{
			get {
				return _bActiveStatus;
			}
			set {
				_bActiveStatus = value;
			}
		}
		private string sOrderBy="PKiServiceStaionID";
		private string sOrderType="ASC";

		public tblServicestaion(int initPKiServiceStaionID){
			addEquals(_PKISERVICESTAIONID,initPKiServiceStaionID);
			List<tblServicestaion> listtblServicestaion=executeSelect();
			tblServicestaion atblServicestaion=listtblServicestaion[0];
			this.PKiServiceStaionID=atblServicestaion.PKiServiceStaionID;
			this.FKiProvideID=atblServicestaion.FKiProvideID;
			this.sName=atblServicestaion.sName;
			this.sDescription=atblServicestaion.sDescription;
			this.bActiveStatus=atblServicestaion.bActiveStatus;
		}

		public tblServicestaion(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblServicestaion> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblServicestaion> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblServicestaion> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblServicestaion> listtblServicestaion=new List<tblServicestaion>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblServicestaion atblServicestaion= new tblServicestaion();
					iIndex=aSqlReader.GetOrdinal("PKiServiceStaionID");
					atblServicestaion.PKiServiceStaionID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProvideID");
					atblServicestaion.FKiProvideID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sName");
					atblServicestaion.sName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sDescription");
					atblServicestaion.sDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("bActiveStatus");
					atblServicestaion.bActiveStatus=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					listtblServicestaion.Add(atblServicestaion);
					}
			}
			aSqlReader.Close();
			return listtblServicestaion;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblservicestaion WHERE "+ sSqlWhere;
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
			List<tblServicestaion> listtblServicestaion=new List<tblServicestaion>();
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

			public tblProviders gettblProviders_FKiProvideID(){
				tblProviders atblProviders=new tblProviders(FKiProvideID);
				return atblProviders;
			}

			public tblServicestaion executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblservicestaion_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiServiceStaionID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiServiceStaionID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiProvideID",FKiProvideID);
				insertCommand.Parameters.AddWithValue("@sName",sName);
				insertCommand.Parameters.AddWithValue("@sDescription",sDescription);
				insertCommand.Parameters.AddWithValue("@bActiveStatus",bActiveStatus);
				insertCommand.ExecuteNonQuery();
             PKiServiceStaionID= (Int32)insertCommand.Parameters["@outPKiServiceStaionID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblservicestaion_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiServiceStaionID", PKiServiceStaionID);
				updateCommand.Parameters.AddWithValue("@inFKiProvideID", FKiProvideID);
				updateCommand.Parameters.AddWithValue("@insName", sName);
				updateCommand.Parameters.AddWithValue("@insDescription", sDescription);
				updateCommand.Parameters.AddWithValue("@inbActiveStatus", bActiveStatus);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
