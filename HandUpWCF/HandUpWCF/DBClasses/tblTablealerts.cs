using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblTablealerts{
		public const string _PKITABLEALERTSID="PKiTableAlertsID";
		public const string _FKITABLEID="FKiTableID";
		public const string _FKIEPLOYEEID="FKiEployeeID";
		public const string _DTALERTSTARTTIME="dtAlertStartTime";
		public const string _DTALERTCONFIMTIME="dtAlertConfimTime";
		public const string _SALERTMESSAGE="sAlertMessage";
		public const string _BACTIVESTATUS="bActiveStatus";
		public const string _SALERTGUI="sAlertGUI";
		public const string _tblTablealerts="tbltablealerts";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiTableAlertsID;
		public int PKiTableAlertsID{
			get {
				return _PKiTableAlertsID;
			}
			set {
				_PKiTableAlertsID = value;
			}
		}
		private int _FKiTableID;
		public int FKiTableID{
			get {
				return _FKiTableID;
			}
			set {
				_FKiTableID = value;
			}
		}
		private int _FKiEployeeID;
		public int FKiEployeeID{
			get {
				return _FKiEployeeID;
			}
			set {
				_FKiEployeeID = value;
			}
		}
		private DateTime _dtAlertStartTime;
		public DateTime dtAlertStartTime{
			get {
				return _dtAlertStartTime;
			}
			set {
				_dtAlertStartTime = value;
			}
		}
		private DateTime _dtAlertConfimTime;
		public DateTime dtAlertConfimTime{
			get {
				return _dtAlertConfimTime;
			}
			set {
				_dtAlertConfimTime = value;
			}
		}
		private string _sAlertMessage;
		public string sAlertMessage{
			get {
				return _sAlertMessage;
			}
			set {
				_sAlertMessage = value;
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
		private string _sAlertGUI;
		public string sAlertGUI{
			get {
				return _sAlertGUI;
			}
			set {
				_sAlertGUI = value;
			}
		}
		private string sOrderBy="PKiTableAlertsID";
		private string sOrderType="ASC";

		public tblTablealerts(int initPKiTableAlertsID){
			addEquals(_PKITABLEALERTSID,initPKiTableAlertsID);
			List<tblTablealerts> listtblTablealerts=executeSelect();
			tblTablealerts atblTablealerts=listtblTablealerts[0];
			this.PKiTableAlertsID=atblTablealerts.PKiTableAlertsID;
			this.FKiTableID=atblTablealerts.FKiTableID;
			this.FKiEployeeID=atblTablealerts.FKiEployeeID;
			this.dtAlertStartTime=atblTablealerts.dtAlertStartTime;
			this.dtAlertConfimTime=atblTablealerts.dtAlertConfimTime;
			this.sAlertMessage=atblTablealerts.sAlertMessage;
			this.bActiveStatus=atblTablealerts.bActiveStatus;
			this.sAlertGUI=atblTablealerts.sAlertGUI;
		}

		public tblTablealerts(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblTablealerts> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblTablealerts> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblTablealerts> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblTablealerts> listtblTablealerts=new List<tblTablealerts>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblTablealerts atblTablealerts= new tblTablealerts();
					iIndex=aSqlReader.GetOrdinal("PKiTableAlertsID");
					atblTablealerts.PKiTableAlertsID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiTableID");
					atblTablealerts.FKiTableID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiEployeeID");
					atblTablealerts.FKiEployeeID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtAlertStartTime");
					atblTablealerts.dtAlertStartTime=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtAlertConfimTime");
					atblTablealerts.dtAlertConfimTime=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("sAlertMessage");
					atblTablealerts.sAlertMessage=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("bActiveStatus");
					atblTablealerts.bActiveStatus=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sAlertGUI");
					atblTablealerts.sAlertGUI=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblTablealerts.Add(atblTablealerts);
					}
			}
			aSqlReader.Close();
			return listtblTablealerts;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tbltablealerts WHERE "+ sSqlWhere;
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
			List<tblTablealerts> listtblTablealerts=new List<tblTablealerts>();
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

			public string addEquals(string sColumnName,DateTime aValue){
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

			public string addLike(string sColumnName,DateTime aValue){
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

			public string addLessThan(string sColumnName,DateTime aValue){
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

			public string addGreaterThan(string sColumnName,DateTime aValue){
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

			public tblEmployees gettblEmployees_FKiEployeeID(){
				tblEmployees atblEmployees=new tblEmployees(FKiEployeeID);
				return atblEmployees;
			}

			public tblTables gettblTables_FKiTableID(){
				tblTables atblTables=new tblTables(FKiTableID);
				return atblTables;
			}

			public tblTablealerts executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tbltablealerts_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiTableAlertsID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiTableAlertsID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiTableID",FKiTableID);
				insertCommand.Parameters.AddWithValue("@FKiEployeeID",FKiEployeeID);
				insertCommand.Parameters.AddWithValue("@dtAlertStartTime",dtAlertStartTime);
				insertCommand.Parameters.AddWithValue("@dtAlertConfimTime",dtAlertConfimTime);
				insertCommand.Parameters.AddWithValue("@sAlertMessage",sAlertMessage);
				insertCommand.Parameters.AddWithValue("@bActiveStatus",bActiveStatus);
				insertCommand.Parameters.AddWithValue("@sAlertGUI",sAlertGUI);
				insertCommand.ExecuteNonQuery();
             PKiTableAlertsID= (Int32)insertCommand.Parameters["@outPKiTableAlertsID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tbltablealerts_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiTableAlertsID", PKiTableAlertsID);
				updateCommand.Parameters.AddWithValue("@inFKiTableID", FKiTableID);
				updateCommand.Parameters.AddWithValue("@inFKiEployeeID", FKiEployeeID);
				updateCommand.Parameters.AddWithValue("@indtAlertStartTime", dtAlertStartTime);
				updateCommand.Parameters.AddWithValue("@indtAlertConfimTime", dtAlertConfimTime);
				updateCommand.Parameters.AddWithValue("@insAlertMessage", sAlertMessage);
				updateCommand.Parameters.AddWithValue("@inbActiveStatus", bActiveStatus);
				updateCommand.Parameters.AddWithValue("@insAlertGUI", sAlertGUI);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
