using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblTables{
		public const string _PKITABLEID="PKiTableID";
		public const string _FKIEMPLOYEEID="FKiEmployeeID";
		public const string _FKIPROVIDERID="FKiProviderID";
		public const string _IGUESTNUMBER="iGuestNumber";
		public const string _DTSTARTDATETIME="dtStartDateTime";
		public const string _DTENDDATETIME="dtEndDateTime";
		public const string _UIDGENERATED="UIDGenerated";
		public const string _tblTables="tbltables";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiTableID;
		public int PKiTableID{
			get {
				return _PKiTableID;
			}
			set {
				_PKiTableID = value;
			}
		}
		private int _FKiEmployeeID;
		public int FKiEmployeeID{
			get {
				return _FKiEmployeeID;
			}
			set {
				_FKiEmployeeID = value;
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
		private int _iGuestNumber;
		public int iGuestNumber{
			get {
				return _iGuestNumber;
			}
			set {
				_iGuestNumber = value;
			}
		}
		private DateTime _dtStartDateTime;
		public DateTime dtStartDateTime{
			get {
				return _dtStartDateTime;
			}
			set {
				_dtStartDateTime = value;
			}
		}
		private DateTime _dtEndDateTime;
		public DateTime dtEndDateTime{
			get {
				return _dtEndDateTime;
			}
			set {
				_dtEndDateTime = value;
			}
		}
		private string _UIDGenerated;
		public string UIDGenerated{
			get {
				return _UIDGenerated;
			}
			set {
				_UIDGenerated = value;
			}
		}
		private string sOrderBy="PKiTableID";
		private string sOrderType="ASC";

		public tblTables(int initPKiTableID){
			addEquals(_PKITABLEID,initPKiTableID);
			List<tblTables> listtblTables=executeSelect();
			tblTables atblTables=listtblTables[0];
			this.PKiTableID=atblTables.PKiTableID;
			this.FKiEmployeeID=atblTables.FKiEmployeeID;
			this.FKiProviderID=atblTables.FKiProviderID;
			this.iGuestNumber=atblTables.iGuestNumber;
			this.dtStartDateTime=atblTables.dtStartDateTime;
			this.dtEndDateTime=atblTables.dtEndDateTime;
			this.UIDGenerated=atblTables.UIDGenerated;
		}

		public tblTables(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblTables> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblTables> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblTables> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblTables> listtblTables=new List<tblTables>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblTables atblTables= new tblTables();
					iIndex=aSqlReader.GetOrdinal("PKiTableID");
					atblTables.PKiTableID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiEmployeeID");
					atblTables.FKiEmployeeID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblTables.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("iGuestNumber");
					atblTables.iGuestNumber=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtStartDateTime");
					atblTables.dtStartDateTime=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtEndDateTime");
					atblTables.dtEndDateTime=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("UIDGenerated");
					atblTables.UIDGenerated=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblTables.Add(atblTables);
					}
			}
			aSqlReader.Close();
			return listtblTables;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tbltables WHERE "+ sSqlWhere;
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
			List<tblTables> listtblTables=new List<tblTables>();
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

			public tblTables executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tbltables_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiTableID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiTableID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiEmployeeID",FKiEmployeeID);
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.Parameters.AddWithValue("@iGuestNumber",iGuestNumber);
				insertCommand.Parameters.AddWithValue("@dtStartDateTime",dtStartDateTime);
				insertCommand.Parameters.AddWithValue("@dtEndDateTime",dtEndDateTime);
				insertCommand.Parameters.AddWithValue("@UIDGenerated",UIDGenerated);
				insertCommand.ExecuteNonQuery();
             PKiTableID= (Int32)insertCommand.Parameters["@outPKiTableID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tbltables_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiTableID", PKiTableID);
				updateCommand.Parameters.AddWithValue("@inFKiEmployeeID", FKiEmployeeID);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.Parameters.AddWithValue("@iniGuestNumber", iGuestNumber);
				updateCommand.Parameters.AddWithValue("@indtStartDateTime", dtStartDateTime);
				updateCommand.Parameters.AddWithValue("@indtEndDateTime", dtEndDateTime);
				updateCommand.Parameters.AddWithValue("@inUIDGenerated", UIDGenerated);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
