using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses {
    public class tblServicestation {
        public const string _PKISERVICESTATIONID="PKiServiceStaionID";
		public const string _FKIPROVIDERID="FKiProvideID";
		public const string _SNAME="sName";
		public const string _SDESCRIPTION="sDescription";
		public const string _SACTIVESTATUS="bActiveStatus";
		public const string _tblServiceStation="tblservicestation";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiServiceStationID;
		public int PKiServiceStationID{
			get {
				return _PKiServiceStationID;
			}
			set {
				_PKiServiceStationID = value;
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
		private string _bActiveStatus;
		public string bActiveStatus{
			get {
				return _bActiveStatus;
			}
			set {
				_bActiveStatus = value;
			}
		}
		private string sOrderBy="PKiPatronID";
		private string sOrderType="ASC";

		public tblServicestation(int initPKiServiceStationID){
			addEquals(_PKISERVICESTATIONID,initPKiServiceStationID);
			List<tblServicestation> listtblServiceStation=executeSelect();
			tblServicestation atblServiceStation=listtblServiceStation[0];
			this.PKiServiceStationID=atblServiceStation.PKiServiceStationID;
			this.FKiProviderID=atblServiceStation.FKiProviderID;
			this.sName=atblServiceStation.sName;
			this.sDescription=atblServiceStation.sDescription;
			this.bActiveStatus=atblServiceStation.bActiveStatus;
		}

		public tblServicestation(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblServicestation> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblServicestation> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblServicestation> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblServicestation> listtblServiceStation=new List<tblServicestation>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblServicestation atblServiceStation= new tblServicestation();
					iIndex=aSqlReader.GetOrdinal("PKiServiceStaionID");
					atblServiceStation.PKiServiceStationID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblServiceStation.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sName");
					atblServiceStation.sName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sDescription");
					atblServiceStation.sDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
                    iIndex = aSqlReader.GetOrdinal("bActiveStatus");
					listtblServiceStation.Add(atblServiceStation);
					}
			}
			aSqlReader.Close();
			return listtblServiceStation;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblServicestation WHERE "+ sSqlWhere;
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
            List<tblServicestation> listtblServiceStation = new List<tblServicestation>();
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

			public string addEquals(string sColumnName,DateTime aValue){
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

			public string addLike(string sColumnName,string aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" LIKE "+"\'"+aValue+"%\'";
				sReturnString = sColumnName +" LIKE "+"\'"+aValue+"%\'";
				return sReturnString;
			}

			public string addLike(string sColumnName,DateTime aValue){
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

			public string addLessThan(string sColumnName,string aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" < "+"\'"+aValue+"%\'";
				sReturnString= sColumnName +" < "+"\'"+aValue+"%\'";
				return sReturnString;
			}

			public string addLessThan(string sColumnName,DateTime aValue){
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

			public string addGreaterThan(string sColumnName,string aValue){
				string sReturnString;
				sSqlWhere += sColumnName +" > "+"\'"+aValue+"%\'";
				sReturnString= sColumnName +" > "+"\'"+aValue+"%\'";
				return sReturnString;
			}

			public string addGreaterThan(string sColumnName,DateTime aValue){
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

			public tblServicestation executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblservicestation_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiServicestationID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiServicestationID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.Parameters.AddWithValue("@sName",sName);
				insertCommand.Parameters.AddWithValue("@sDescription",sDescription);
				insertCommand.Parameters.AddWithValue("@bActiveStatus",bActiveStatus);
				insertCommand.ExecuteNonQuery();
             PKiServiceStationID= (Int32)insertCommand.Parameters["@outPKiServicestationID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblservicestation_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiServicestationID", PKiServiceStationID);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.Parameters.AddWithValue("@insName", sName);
				updateCommand.Parameters.AddWithValue("@insDescription", sDescription);
				updateCommand.Parameters.AddWithValue("@inbActiveStatus", bActiveStatus);
				updateCommand.ExecuteNonQuery();
				return true;
			}
    }
}