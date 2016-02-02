using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblEmployees{
		public const string _PKIEMPLOYEEID="PKiEmployeeID";
		public const string _FKIPROVIDERID="FKiProviderID";
		public const string _FKIEMPLOYEETYPE="FKiEmployeeType";
		public const string _SEMPLOYEENAME="sEmployeeName";
		public const string _SEMPLOYEESURNAME="sEmployeeSurname";
		public const string _SEMPLOYEEID="sEmployeeID";
		public const string _SEMPLOYEEEMAIL="sEmployeeEmail";
		public const string _SEMPLOYEETEL="sEmployeeTel";
		public const string _SEMPLOYEEADDRESS1="sEmployeeAddress1";
		public const string _SEMPLOYEEADDRESS2="sEmployeeAddress2";
		public const string _SEMPLOYEEADDRESS3="sEmployeeAddress3";
		public const string _SEMPLOYEENATIONALITY="sEmployeeNationality";
		public const string _SUSERNAME="sUserName";
		public const string _SPASSWORD="sPassword";
		public const string _DTSTARTDATE="dtStartDate";
		public const string _DTENDDATE="dtEndDate";
		public const string _BGENDER="bGender";
        public const string _BACTIVESTATUS = "bActiveStatus";
        public const string _FKISERVICESTAIONID = "FKiServicestaionID";
        public const string _SONSHIFT = "sOnShift";
		public const string _tblEmployees="tblemployees";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiEmployeeID;
		public int PKiEmployeeID{
			get {
				return _PKiEmployeeID;
			}
			set {
				_PKiEmployeeID = value;
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
		private int _FKiEmployeeType;
		public int FKiEmployeeType{
			get {
				return _FKiEmployeeType;
			}
			set {
				_FKiEmployeeType = value;
			}
		}
		private string _sEmployeeName;
		public string sEmployeeName{
			get {
				return _sEmployeeName;
			}
			set {
				_sEmployeeName = value;
			}
		}
		private string _sEmployeeSurname;
		public string sEmployeeSurname{
			get {
				return _sEmployeeSurname;
			}
			set {
				_sEmployeeSurname = value;
			}
		}
		private string _sEmployeeID;
		public string sEmployeeID{
			get {
				return _sEmployeeID;
			}
			set {
				_sEmployeeID = value;
			}
		}
		private string _sEmployeeEmail;
		public string sEmployeeEmail{
			get {
				return _sEmployeeEmail;
			}
			set {
				_sEmployeeEmail = value;
			}
		}
		private string _sEmployeeTel;
		public string sEmployeeTel{
			get {
				return _sEmployeeTel;
			}
			set {
				_sEmployeeTel = value;
			}
		}
		private string _sEmployeeAddress1;
		public string sEmployeeAddress1{
			get {
				return _sEmployeeAddress1;
			}
			set {
				_sEmployeeAddress1 = value;
			}
		}
		private string _sEmployeeAddress2;
		public string sEmployeeAddress2{
			get {
				return _sEmployeeAddress2;
			}
			set {
				_sEmployeeAddress2 = value;
			}
		}
		private string _sEmployeeAddress3;
		public string sEmployeeAddress3{
			get {
				return _sEmployeeAddress3;
			}
			set {
				_sEmployeeAddress3 = value;
			}
		}
		private string _sEmployeeNationality;
		public string sEmployeeNationality{
			get {
				return _sEmployeeNationality;
			}
			set {
				_sEmployeeNationality = value;
			}
		}
		private string _sUserName;
		public string sUserName{
			get {
				return _sUserName;
			}
			set {
				_sUserName = value;
			}
		}
		private string _sPassword;
		public string sPassword{
			get {
				return _sPassword;
			}
			set {
				_sPassword = value;
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
		private string _bGender;
		public string bGender{
			get {
				return _bGender;
			}
			set {
				_bGender = value;
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
        private string _FKiServicestaionID;
        public string FKiServicestaionID {
            get {
                return _FKiServicestaionID;
            }
            set {
                _FKiServicestaionID = value;
            }
        }

        private string _sOnShift;
        public string sOnShift {
            get {
                return _sOnShift;
            }
            set {
                _sOnShift = value;
            }
        }

		private string sOrderBy="PKiEmployeeID";
		private string sOrderType="ASC";

		public tblEmployees(int initPKiEmployeeID){
			addEquals(_PKIEMPLOYEEID,initPKiEmployeeID);
			List<tblEmployees> listtblEmployees=executeSelect();
			tblEmployees atblEmployees=listtblEmployees[0];
			this.PKiEmployeeID=atblEmployees.PKiEmployeeID;
			this.FKiProviderID=atblEmployees.FKiProviderID;
			this.FKiEmployeeType=atblEmployees.FKiEmployeeType;
			this.sEmployeeName=atblEmployees.sEmployeeName;
			this.sEmployeeSurname=atblEmployees.sEmployeeSurname;
			this.sEmployeeID=atblEmployees.sEmployeeID;
			this.sEmployeeEmail=atblEmployees.sEmployeeEmail;
			this.sEmployeeTel=atblEmployees.sEmployeeTel;
			this.sEmployeeAddress1=atblEmployees.sEmployeeAddress1;
			this.sEmployeeAddress2=atblEmployees.sEmployeeAddress2;
			this.sEmployeeAddress3=atblEmployees.sEmployeeAddress3;
			this.sEmployeeNationality=atblEmployees.sEmployeeNationality;
			this.sUserName=atblEmployees.sUserName;
			this.sPassword=atblEmployees.sPassword;
			this.dtStartDate=atblEmployees.dtStartDate;
			this.dtEndDate=atblEmployees.dtEndDate;
			this.bGender=atblEmployees.bGender;
			this.bActiveStatus=atblEmployees.bActiveStatus;
            this.FKiServicestaionID = atblEmployees.FKiServicestaionID;
            this.sOnShift = atblEmployees.sOnShift;
		}

		public tblEmployees(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblEmployees> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblEmployees> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblEmployees> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblEmployees> listtblEmployees=new List<tblEmployees>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblEmployees atblEmployees= new tblEmployees();
					iIndex=aSqlReader.GetOrdinal("PKiEmployeeID");
					atblEmployees.PKiEmployeeID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblEmployees.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiEmployeeType");
					atblEmployees.FKiEmployeeType=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeName");
					atblEmployees.sEmployeeName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeSurname");
					atblEmployees.sEmployeeSurname=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeID");
					atblEmployees.sEmployeeID=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeEmail");
					atblEmployees.sEmployeeEmail=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeTel");
					atblEmployees.sEmployeeTel=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeAddress1");
					atblEmployees.sEmployeeAddress1=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeAddress2");
					atblEmployees.sEmployeeAddress2=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeAddress3");
					atblEmployees.sEmployeeAddress3=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeNationality");
					atblEmployees.sEmployeeNationality=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sUserName");
					atblEmployees.sUserName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sPassword");
					atblEmployees.sPassword=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtStartDate");
					atblEmployees.dtStartDate=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtEndDate");
					atblEmployees.dtEndDate=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("bGender");
					atblEmployees.bGender=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("bActiveStatus");
                    atblEmployees.bActiveStatus = aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
                    iIndex = aSqlReader.GetOrdinal("FKiServicestaionID");
                    atblEmployees.FKiServicestaionID = aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
                    iIndex = aSqlReader.GetOrdinal("sOnShift");
                    atblEmployees.sOnShift = aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblEmployees.Add(atblEmployees);
					}
			}
			aSqlReader.Close();
			return listtblEmployees;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblemployees WHERE "+ sSqlWhere;
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
			List<tblEmployees> listtblEmployees=new List<tblEmployees>();
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

			public tblluEmployeetype gettblluEmployeetype_FKiEmployeeType(){
				tblluEmployeetype atblluEmployeetype=new tblluEmployeetype(FKiEmployeeType);
				return atblluEmployeetype;
			}

			public tblProviders gettblProviders_FKiProviderID(){
				tblProviders atblProviders=new tblProviders(FKiProviderID);
				return atblProviders;
			}

			public List<tblTablealerts> gettblTablealerts_FKiEployeeIDList(){
				tblTablealerts atblTablealerts=new tblTablealerts();
				atblTablealerts.addEquals("FKiEployeeID",PKiEmployeeID);
				return atblTablealerts.executeSelect();
			}

			public List<tblTablealerts> gettblTablealerts_FKiEployeeIDList(string localsOrderBy,string localsOrderType){
				tblTablealerts atblTablealerts=new tblTablealerts();
				atblTablealerts.addEquals("FKiEployeeID",PKiEmployeeID);
				return atblTablealerts.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblTablealerts> gettblTablealerts_FKiEployeeIDList(string sAddToSqlWhere,string localsOrderBy,string localsOrderType){
				tblTablealerts atblTablealerts=new tblTablealerts();
				atblTablealerts.addToSqlWhere(sAddToSqlWhere);
				atblTablealerts.addEquals("FKiEployeeID",PKiEmployeeID);
				return atblTablealerts.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblTablealerts> gettblTablealerts_FKiEployeeIDList(string sAddToSqlWhere){
				tblTablealerts atblTablealerts=new tblTablealerts();
				atblTablealerts.addToSqlWhere(sAddToSqlWhere);
				return atblTablealerts.executeSelect();
			}

			public List<tblTables> gettblTables_FKiEmployeeIDList(){
				tblTables atblTables=new tblTables();
				atblTables.addEquals("FKiEmployeeID",PKiEmployeeID);
				return atblTables.executeSelect();
			}

			public List<tblTables> gettblTables_FKiEmployeeIDList(string localsOrderBy,string localsOrderType){
				tblTables atblTables=new tblTables();
				atblTables.addEquals("FKiEmployeeID",PKiEmployeeID);
				return atblTables.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblTables> gettblTables_FKiEmployeeIDList(string sAddToSqlWhere,string localsOrderBy,string localsOrderType){
				tblTables atblTables=new tblTables();
				atblTables.addToSqlWhere(sAddToSqlWhere);
				atblTables.addEquals("FKiEmployeeID",PKiEmployeeID);
				return atblTables.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblTables> gettblTables_FKiEmployeeIDList(string sAddToSqlWhere){
				tblTables atblTables=new tblTables();
				atblTables.addToSqlWhere(sAddToSqlWhere);
				return atblTables.executeSelect();
			}

			public tblEmployees executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblemployees_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiEmployeeID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiEmployeeID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.Parameters.AddWithValue("@FKiEmployeeType",FKiEmployeeType);
				insertCommand.Parameters.AddWithValue("@sEmployeeName",sEmployeeName);
				insertCommand.Parameters.AddWithValue("@sEmployeeSurname",sEmployeeSurname);
				insertCommand.Parameters.AddWithValue("@sEmployeeID",sEmployeeID);
				insertCommand.Parameters.AddWithValue("@sEmployeeEmail",sEmployeeEmail);
				insertCommand.Parameters.AddWithValue("@sEmployeeTel",sEmployeeTel);
				insertCommand.Parameters.AddWithValue("@sEmployeeAddress1",sEmployeeAddress1);
				insertCommand.Parameters.AddWithValue("@sEmployeeAddress2",sEmployeeAddress2);
				insertCommand.Parameters.AddWithValue("@sEmployeeAddress3",sEmployeeAddress3);
				insertCommand.Parameters.AddWithValue("@sEmployeeNationality",sEmployeeNationality);
				insertCommand.Parameters.AddWithValue("@sUserName",sUserName);
				insertCommand.Parameters.AddWithValue("@sPassword",sPassword);
				insertCommand.Parameters.AddWithValue("@dtStartDate",dtStartDate);
				insertCommand.Parameters.AddWithValue("@dtEndDate",dtEndDate);
				insertCommand.Parameters.AddWithValue("@bGender",bGender);
                insertCommand.Parameters.AddWithValue("@bActiveStatus", bActiveStatus);
                insertCommand.Parameters.AddWithValue("@FKiServicestaionID", FKiServicestaionID);
                insertCommand.Parameters.AddWithValue("@sOnShift", sOnShift);
				insertCommand.ExecuteNonQuery();
             PKiEmployeeID= (Int32)insertCommand.Parameters["@outPKiEmployeeID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblemployees_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiEmployeeID", PKiEmployeeID);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.Parameters.AddWithValue("@inFKiEmployeeType", FKiEmployeeType);
				updateCommand.Parameters.AddWithValue("@insEmployeeName", sEmployeeName);
				updateCommand.Parameters.AddWithValue("@insEmployeeSurname", sEmployeeSurname);
				updateCommand.Parameters.AddWithValue("@insEmployeeID", sEmployeeID);
				updateCommand.Parameters.AddWithValue("@insEmployeeEmail", sEmployeeEmail);
				updateCommand.Parameters.AddWithValue("@insEmployeeTel", sEmployeeTel);
				updateCommand.Parameters.AddWithValue("@insEmployeeAddress1", sEmployeeAddress1);
				updateCommand.Parameters.AddWithValue("@insEmployeeAddress2", sEmployeeAddress2);
				updateCommand.Parameters.AddWithValue("@insEmployeeAddress3", sEmployeeAddress3);
				updateCommand.Parameters.AddWithValue("@insEmployeeNationality", sEmployeeNationality);
				updateCommand.Parameters.AddWithValue("@insUserName", sUserName);
				updateCommand.Parameters.AddWithValue("@insPassword", sPassword);
				updateCommand.Parameters.AddWithValue("@indtStartDate", dtStartDate);
				updateCommand.Parameters.AddWithValue("@indtEndDate", dtEndDate);
				updateCommand.Parameters.AddWithValue("@inbGender", bGender);
                updateCommand.Parameters.AddWithValue("@inbActiveStatus", bActiveStatus);
                updateCommand.Parameters.AddWithValue("@inFKiServicestaionID", FKiServicestaionID);
                updateCommand.Parameters.AddWithValue("@insOnShift", sOnShift);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
