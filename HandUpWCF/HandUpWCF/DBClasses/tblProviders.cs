using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblProviders{
		public const string _PKIPROVIDERID="PKiProviderID";
		public const string _SPROVIDERNAME="sProviderName";
		public const string _SPROVIDERLOCATION="sProviderLocation";
		public const string _DTPROVIDERJOINED="dtProviderJoined";
		public const string _SPROVIDERCONTACTPERSON="sProviderContactPerson";
		public const string _SPROVIDERCONTACTINFO="sProviderContactInfo";
		public const string _SPROVIDEREMAIL="sProviderEmail";
		public const string _SPROVIDERSTATUS="sProviderStatus";
		public const string _tblProviders="tblproviders";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiProviderID;
		public int PKiProviderID{
			get {
				return _PKiProviderID;
			}
			set {
				_PKiProviderID = value;
			}
		}
		private string _sProviderName;
		public string sProviderName{
			get {
				return _sProviderName;
			}
			set {
				_sProviderName = value;
			}
		}
		private string _sProviderLocation;
		public string sProviderLocation{
			get {
				return _sProviderLocation;
			}
			set {
				_sProviderLocation = value;
			}
		}
		private DateTime _dtProviderJoined;
		public DateTime dtProviderJoined{
			get {
				return _dtProviderJoined;
			}
			set {
				_dtProviderJoined = value;
			}
		}
		private string _sProviderContactPerson;
		public string sProviderContactPerson{
			get {
				return _sProviderContactPerson;
			}
			set {
				_sProviderContactPerson = value;
			}
		}
		private string _sProviderContactInfo;
		public string sProviderContactInfo{
			get {
				return _sProviderContactInfo;
			}
			set {
				_sProviderContactInfo = value;
			}
		}
		private string _sProviderEmail;
		public string sProviderEmail{
			get {
				return _sProviderEmail;
			}
			set {
				_sProviderEmail = value;
			}
		}
		private string _sProviderStatus;
		public string sProviderStatus{
			get {
				return _sProviderStatus;
			}
			set {
				_sProviderStatus = value;
			}
		}
		private string sOrderBy="PKiProviderID";
		private string sOrderType="ASC";

		public tblProviders(int initPKiProviderID){
			addEquals(_PKIPROVIDERID,initPKiProviderID);
			List<tblProviders> listtblProviders=executeSelect();
			tblProviders atblProviders=listtblProviders[0];
			this.PKiProviderID=atblProviders.PKiProviderID;
			this.sProviderName=atblProviders.sProviderName;
			this.sProviderLocation=atblProviders.sProviderLocation;
			this.dtProviderJoined=atblProviders.dtProviderJoined;
			this.sProviderContactPerson=atblProviders.sProviderContactPerson;
			this.sProviderContactInfo=atblProviders.sProviderContactInfo;
			this.sProviderEmail=atblProviders.sProviderEmail;
			this.sProviderStatus=atblProviders.sProviderStatus;
		}

		public tblProviders(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblProviders> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblProviders> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblProviders> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblProviders> listtblProviders=new List<tblProviders>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblProviders atblProviders= new tblProviders();
					iIndex=aSqlReader.GetOrdinal("PKiProviderID");
					atblProviders.PKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sProviderName");
					atblProviders.sProviderName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sProviderLocation");
					atblProviders.sProviderLocation=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtProviderJoined");
					atblProviders.dtProviderJoined=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("sProviderContactPerson");
					atblProviders.sProviderContactPerson=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sProviderContactInfo");
					atblProviders.sProviderContactInfo=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sProviderEmail");
					atblProviders.sProviderEmail=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sProviderStatus");
					atblProviders.sProviderStatus=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblProviders.Add(atblProviders);
					}
			}
			aSqlReader.Close();
			return listtblProviders;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblproviders WHERE "+ sSqlWhere;
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
			List<tblProviders> listtblProviders=new List<tblProviders>();
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

			public tblProviders executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblproviders_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiProviderID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiProviderID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@sProviderName",sProviderName);
				insertCommand.Parameters.AddWithValue("@sProviderLocation",sProviderLocation);
				insertCommand.Parameters.AddWithValue("@dtProviderJoined",dtProviderJoined);
				insertCommand.Parameters.AddWithValue("@sProviderContactPerson",sProviderContactPerson);
				insertCommand.Parameters.AddWithValue("@sProviderContactInfo",sProviderContactInfo);
				insertCommand.Parameters.AddWithValue("@sProviderEmail",sProviderEmail);
				insertCommand.Parameters.AddWithValue("@sProviderStatus",sProviderStatus);
				insertCommand.ExecuteNonQuery();
             PKiProviderID= (Int32)insertCommand.Parameters["@outPKiProviderID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblproviders_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiProviderID", PKiProviderID);
				updateCommand.Parameters.AddWithValue("@insProviderName", sProviderName);
				updateCommand.Parameters.AddWithValue("@insProviderLocation", sProviderLocation);
				updateCommand.Parameters.AddWithValue("@indtProviderJoined", dtProviderJoined);
				updateCommand.Parameters.AddWithValue("@insProviderContactPerson", sProviderContactPerson);
				updateCommand.Parameters.AddWithValue("@insProviderContactInfo", sProviderContactInfo);
				updateCommand.Parameters.AddWithValue("@insProviderEmail", sProviderEmail);
				updateCommand.Parameters.AddWithValue("@insProviderStatus", sProviderStatus);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
