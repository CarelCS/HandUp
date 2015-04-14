using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblPatrons{
		public const string _PKIPATRONID="PKiPatronID";
		public const string _SPATRONNAME="sPatronName";
		public const string _SPATRONSURNAME="sPatronSurname";
		public const string _SPATRONCONTACTNUMBER="sPatronContactNumber";
		public const string _SPATRONEMAIL="sPatronEmail";
		public const string _BGENDER="bGender";
		public const string _FKIPROVIDERID="FKiProviderID";
		public const string _DTSIGNUPDATE="dtSignUpDate";
		public const string _tblPatrons="tblpatrons";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiPatronID;
		public int PKiPatronID{
			get {
				return _PKiPatronID;
			}
			set {
				_PKiPatronID = value;
			}
		}
		private string _sPatronName;
		public string sPatronName{
			get {
				return _sPatronName;
			}
			set {
				_sPatronName = value;
			}
		}
		private string _sPatronSurname;
		public string sPatronSurname{
			get {
				return _sPatronSurname;
			}
			set {
				_sPatronSurname = value;
			}
		}
		private string _sPatronContactNumber;
		public string sPatronContactNumber{
			get {
				return _sPatronContactNumber;
			}
			set {
				_sPatronContactNumber = value;
			}
		}
		private string _sPatronEmail;
		public string sPatronEmail{
			get {
				return _sPatronEmail;
			}
			set {
				_sPatronEmail = value;
			}
		}
		private string _bGender;
		public string bGender{
			get {
				return _bGender;
			}
			set {
				_bGender = value;
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
		private DateTime _dtSignUpDate;
		public DateTime dtSignUpDate{
			get {
				return _dtSignUpDate;
			}
			set {
				_dtSignUpDate = value;
			}
		}
		private string sOrderBy="PKiPatronID";
		private string sOrderType="ASC";

		public tblPatrons(int initPKiPatronID){
			addEquals(_PKIPATRONID,initPKiPatronID);
			List<tblPatrons> listtblPatrons=executeSelect();
			tblPatrons atblPatrons=listtblPatrons[0];
			this.PKiPatronID=atblPatrons.PKiPatronID;
			this.sPatronName=atblPatrons.sPatronName;
			this.sPatronSurname=atblPatrons.sPatronSurname;
			this.sPatronContactNumber=atblPatrons.sPatronContactNumber;
			this.sPatronEmail=atblPatrons.sPatronEmail;
			this.bGender=atblPatrons.bGender;
			this.FKiProviderID=atblPatrons.FKiProviderID;
			this.dtSignUpDate=atblPatrons.dtSignUpDate;
		}

		public tblPatrons(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblPatrons> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblPatrons> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblPatrons> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblPatrons> listtblPatrons=new List<tblPatrons>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblPatrons atblPatrons= new tblPatrons();
					iIndex=aSqlReader.GetOrdinal("PKiPatronID");
					atblPatrons.PKiPatronID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sPatronName");
					atblPatrons.sPatronName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sPatronSurname");
					atblPatrons.sPatronSurname=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sPatronContactNumber");
					atblPatrons.sPatronContactNumber=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sPatronEmail");
					atblPatrons.sPatronEmail=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("bGender");
					atblPatrons.bGender=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblPatrons.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtSignUpDate");
					atblPatrons.dtSignUpDate=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					listtblPatrons.Add(atblPatrons);
					}
			}
			aSqlReader.Close();
			return listtblPatrons;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblpatrons WHERE "+ sSqlWhere;
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
			List<tblPatrons> listtblPatrons=new List<tblPatrons>();
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

			public tblPatrons executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblpatrons_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiPatronID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiPatronID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@sPatronName",sPatronName);
				insertCommand.Parameters.AddWithValue("@sPatronSurname",sPatronSurname);
				insertCommand.Parameters.AddWithValue("@sPatronContactNumber",sPatronContactNumber);
				insertCommand.Parameters.AddWithValue("@sPatronEmail",sPatronEmail);
				insertCommand.Parameters.AddWithValue("@bGender",bGender);
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.Parameters.AddWithValue("@dtSignUpDate",dtSignUpDate);
				insertCommand.ExecuteNonQuery();
             PKiPatronID= (Int32)insertCommand.Parameters["@outPKiPatronID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblpatrons_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiPatronID", PKiPatronID);
				updateCommand.Parameters.AddWithValue("@insPatronName", sPatronName);
				updateCommand.Parameters.AddWithValue("@insPatronSurname", sPatronSurname);
				updateCommand.Parameters.AddWithValue("@insPatronContactNumber", sPatronContactNumber);
				updateCommand.Parameters.AddWithValue("@insPatronEmail", sPatronEmail);
				updateCommand.Parameters.AddWithValue("@inbGender", bGender);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.Parameters.AddWithValue("@indtSignUpDate", dtSignUpDate);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
