using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblSpecials{
		public const string _PKISPECIALID="PKiSpecialID";
		public const string _FKIMENUID="FKiMenuID";
		public const string _DTSTARTDATE="dtStartDate";
		public const string _DTENDDATE="dtEndDate";
		public const string _SDAYSOFWEEK="sDaysOfWeek";
		public const string _TSTARTTIME="tStartTime";
		public const string _TENDTIME="tEndTime";
		public const string _tblSpecials="tblspecials";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiSpecialID;
		public int PKiSpecialID{
			get {
				return _PKiSpecialID;
			}
			set {
				_PKiSpecialID = value;
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
		private DateTime _dtStartDate;
		public DateTime dtStartDate{
			get {
				return _dtStartDate;
			}
			set {
				_dtStartDate = value;
			}
		}
		private DateTime _dtEndDate;
		public DateTime dtEndDate{
			get {
				return _dtEndDate;
			}
			set {
				_dtEndDate = value;
			}
		}
		private string _sDaysOfWeek;
		public string sDaysOfWeek{
			get {
				return _sDaysOfWeek;
			}
			set {
				_sDaysOfWeek = value;
			}
		}
		private string _tStartTime;
		public string tStartTime{
			get {
				return _tStartTime;
			}
			set {
				_tStartTime = value;
			}
		}
		private string _tEndTime;
		public string tEndTime{
			get {
				return _tEndTime;
			}
			set {
				_tEndTime = value;
			}
		}
		private string sOrderBy="PKiSpecialID";
		private string sOrderType="ASC";

		public tblSpecials(int initPKiSpecialID){
			addEquals(_PKISPECIALID,initPKiSpecialID);
			List<tblSpecials> listtblSpecials=executeSelect();
			tblSpecials atblSpecials=listtblSpecials[0];
			this.PKiSpecialID=atblSpecials.PKiSpecialID;
			this.FKiMenuID=atblSpecials.FKiMenuID;
			this.dtStartDate=atblSpecials.dtStartDate;
			this.dtEndDate=atblSpecials.dtEndDate;
			this.sDaysOfWeek=atblSpecials.sDaysOfWeek;
			this.tStartTime=atblSpecials.tStartTime;
			this.tEndTime=atblSpecials.tEndTime;
		}

		public tblSpecials(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblSpecials> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblSpecials> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblSpecials> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblSpecials> listtblSpecials=new List<tblSpecials>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblSpecials atblSpecials= new tblSpecials();
					iIndex=aSqlReader.GetOrdinal("PKiSpecialID");
					atblSpecials.PKiSpecialID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiMenuID");
					atblSpecials.FKiMenuID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtStartDate");
					atblSpecials.dtStartDate=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtEndDate");
					atblSpecials.dtEndDate=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("sDaysOfWeek");
					atblSpecials.sDaysOfWeek=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("tStartTime");
					atblSpecials.tStartTime=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("tEndTime");
					atblSpecials.tEndTime=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblSpecials.Add(atblSpecials);
					}
			}
			aSqlReader.Close();
			return listtblSpecials;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblspecials WHERE "+ sSqlWhere;
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
			List<tblSpecials> listtblSpecials=new List<tblSpecials>();
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

			public tblSpecials executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblspecials_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiSpecialID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiSpecialID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiMenuID",FKiMenuID);
				insertCommand.Parameters.AddWithValue("@dtStartDate",dtStartDate);
				insertCommand.Parameters.AddWithValue("@dtEndDate",dtEndDate);
				insertCommand.Parameters.AddWithValue("@sDaysOfWeek",sDaysOfWeek);
				insertCommand.Parameters.AddWithValue("@tStartTime",tStartTime);
				insertCommand.Parameters.AddWithValue("@tEndTime",tEndTime);
				insertCommand.ExecuteNonQuery();
             PKiSpecialID= (Int32)insertCommand.Parameters["@outPKiSpecialID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblspecials_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiSpecialID", PKiSpecialID);
				updateCommand.Parameters.AddWithValue("@inFKiMenuID", FKiMenuID);
				updateCommand.Parameters.AddWithValue("@indtStartDate", dtStartDate);
				updateCommand.Parameters.AddWithValue("@indtEndDate", dtEndDate);
				updateCommand.Parameters.AddWithValue("@insDaysOfWeek", sDaysOfWeek);
				updateCommand.Parameters.AddWithValue("@intStartTime", tStartTime);
				updateCommand.Parameters.AddWithValue("@intEndTime", tEndTime);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
