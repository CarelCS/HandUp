using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblStock{
		public const string _PKISTOCKID="PKiStockID";
		public const string _SSTOCKNAME="sStockName";
		public const string _SSTOCKDESCRIPTION="sStockDescription";
		public const string _ISTOCKLEVEL="iStockLevel";
		public const string _FKISTOCKLEVELTYPEID="FKiStockLevelTypeID";
		public const string _ISTOCKLEVELREPLACE="iStockLevelReplace";
        public const string _IQUANTITY = "iQuantity";
		public const string _tblStock="tblstock";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiStockID;
		public int PKiStockID{
			get {
				return _PKiStockID;
			}
			set {
				_PKiStockID = value;
			}
		}
		private string _sStockName;
		public string sStockName{
			get {
				return _sStockName;
			}
			set {
				_sStockName = value;
			}
		}
		private string _sStockDescription;
		public string sStockDescription{
			get {
				return _sStockDescription;
			}
			set {
				_sStockDescription = value;
			}
		}
		private string _iStockLevel;
		public string iStockLevel{
			get {
				return _iStockLevel;
			}
			set {
				_iStockLevel = value;
			}
		}
		private int _FKiStockLevelTypeID;
		public int FKiStockLevelTypeID{
			get {
				return _FKiStockLevelTypeID;
			}
			set {
				_FKiStockLevelTypeID = value;
			}
		}
		private int _iStockLevelReplace;
		public int iStockLevelReplace{
			get {
				return _iStockLevelReplace;
			}
			set {
				_iStockLevelReplace = value;
			}
		}

        private int _iQuantity;
        public int iQuantity {
            get {
                return _iQuantity;
            }
            set {
                _iQuantity = value;
            }
        }

		private string sOrderBy="PKiStockID";
		private string sOrderType="ASC";

		public tblStock(int initPKiStockID){
			addEquals(_PKISTOCKID,initPKiStockID);
			List<tblStock> listtblStock=executeSelect();
			tblStock atblStock=listtblStock[0];
			this.PKiStockID=atblStock.PKiStockID;
			this.sStockName=atblStock.sStockName;
			this.sStockDescription=atblStock.sStockDescription;
			this.iStockLevel=atblStock.iStockLevel;
			this.FKiStockLevelTypeID=atblStock.FKiStockLevelTypeID;
			this.iStockLevelReplace=atblStock.iStockLevelReplace;
            this.iQuantity = atblStock.iQuantity;
		}

		public tblStock(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblStock> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblStock> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblStock> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblStock> listtblStock=new List<tblStock>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblStock atblStock= new tblStock();
					iIndex=aSqlReader.GetOrdinal("PKiStockID");
					atblStock.PKiStockID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sStockName");
					atblStock.sStockName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sStockDescription");
					atblStock.sStockDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("iStockLevel");
					atblStock.iStockLevel=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiStockLevelTypeID");
					atblStock.FKiStockLevelTypeID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("iStockLevelReplace");
					atblStock.iStockLevelReplace=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
                    iIndex = aSqlReader.GetOrdinal("iQuantity");
                    atblStock.iQuantity = aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					listtblStock.Add(atblStock);
					}
			}
			aSqlReader.Close();
			return listtblStock;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblstock WHERE "+ sSqlWhere;
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
			List<tblStock> listtblStock=new List<tblStock>();
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

			public tblStock executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblstock_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiStockID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiStockID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@sStockName",sStockName);
				insertCommand.Parameters.AddWithValue("@sStockDescription",sStockDescription);
				insertCommand.Parameters.AddWithValue("@iStockLevel",iStockLevel);
				insertCommand.Parameters.AddWithValue("@FKiStockLevelTypeID",FKiStockLevelTypeID);
				insertCommand.Parameters.AddWithValue("@iStockLevelReplace",iStockLevelReplace);
                insertCommand.Parameters.AddWithValue("@iQuantity", iQuantity);
				insertCommand.ExecuteNonQuery();
             PKiStockID= (Int32)insertCommand.Parameters["@outPKiStockID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblstock_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiStockID", PKiStockID);
				updateCommand.Parameters.AddWithValue("@insStockName", sStockName);
				updateCommand.Parameters.AddWithValue("@insStockDescription", sStockDescription);
				updateCommand.Parameters.AddWithValue("@iniStockLevel", iStockLevel);
				updateCommand.Parameters.AddWithValue("@inFKiStockLevelTypeID", FKiStockLevelTypeID);
                updateCommand.Parameters.AddWithValue("@iniStockLevelReplace", iStockLevelReplace);
                updateCommand.Parameters.AddWithValue("@iniQuantity", iQuantity);
				updateCommand.ExecuteNonQuery();
				return true;
			}

            public bool executeStockSP() {
                MySqlCommand updateCommand = new MySqlCommand("stockReduce_UPDATE", clsDatabase.getPooledConnection());
                updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
                updateCommand.Parameters.AddWithValue("@inPKiStockID", PKiStockID);
                updateCommand.Parameters.AddWithValue("@insStockName", sStockName);
                updateCommand.Parameters.AddWithValue("@insStockDescription", sStockDescription);
                updateCommand.Parameters.AddWithValue("@iniStockLevel", iStockLevel);
                updateCommand.Parameters.AddWithValue("@inFKiStockLevelTypeID", FKiStockLevelTypeID);
                updateCommand.Parameters.AddWithValue("@iniStockLevelReplace", iStockLevelReplace);
                updateCommand.Parameters.AddWithValue("@iniQuantity", iQuantity);
                updateCommand.ExecuteNonQuery();
                return true;
            }
	}
}
