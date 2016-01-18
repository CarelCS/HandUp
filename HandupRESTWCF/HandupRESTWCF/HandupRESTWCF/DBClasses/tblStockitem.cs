using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandupRESTWCF.DBClasses{
	class tblStockitem{
		public const string _PKISTOCKITEMID="PKiStockitemID";
		public const string _SSTOCKITEMNAME="sStockItemName";
		public const string _ISTOCKREPLACE="iStockReplace";
		public const string _ISTOCKLEVEL="iStockLevel";
		public const string _FKISTOCKLEVELTYPE="FKiStockLevelType";
		public const string _FKIPROVIDERID="FKiProviderID";
		public const string _tblStockitem="tblstockitem";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiStockitemID;
		public int PKiStockitemID{
			get {
				return _PKiStockitemID;
			}
			set {
				_PKiStockitemID = value;
			}
		}
		private string _sStockItemName;
		public string sStockItemName{
			get {
				return _sStockItemName;
			}
			set {
				_sStockItemName = value;
			}
		}
		private int _iStockReplace;
		public int iStockReplace{
			get {
				return _iStockReplace;
			}
			set {
				_iStockReplace = value;
			}
		}
		private int _iStockLevel;
		public int iStockLevel{
			get {
				return _iStockLevel;
			}
			set {
				_iStockLevel = value;
			}
		}
		private int _FKiStockLevelType;
		public int FKiStockLevelType{
			get {
				return _FKiStockLevelType;
			}
			set {
				_FKiStockLevelType = value;
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
		private string sOrderBy="PKiStockitemID";
		private string sOrderType="ASC";

		public tblStockitem(int initPKiStockitemID){
			addEquals(_PKISTOCKITEMID,initPKiStockitemID);
			List<tblStockitem> listtblStockitem=executeSelect();
			tblStockitem atblStockitem=listtblStockitem[0];
			this.PKiStockitemID=atblStockitem.PKiStockitemID;
			this.sStockItemName=atblStockitem.sStockItemName;
			this.iStockReplace=atblStockitem.iStockReplace;
			this.iStockLevel=atblStockitem.iStockLevel;
			this.FKiStockLevelType=atblStockitem.FKiStockLevelType;
			this.FKiProviderID=atblStockitem.FKiProviderID;
		}

		public tblStockitem(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblStockitem> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblStockitem> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblStockitem> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblStockitem> listtblStockitem=new List<tblStockitem>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblStockitem atblStockitem= new tblStockitem();
					iIndex=aSqlReader.GetOrdinal("PKiStockitemID");
					atblStockitem.PKiStockitemID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sStockItemName");
					atblStockitem.sStockItemName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("iStockReplace");
					atblStockitem.iStockReplace=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("iStockLevel");
					atblStockitem.iStockLevel=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiStockLevelType");
					atblStockitem.FKiStockLevelType=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblStockitem.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					listtblStockitem.Add(atblStockitem);
					}
			}
			aSqlReader.Close();
			return listtblStockitem;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblstockitem WHERE "+ sSqlWhere;
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
			List<tblStockitem> listtblStockitem=new List<tblStockitem>();
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

			public tblStockitem executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblstockitem_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiStockitemID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiStockitemID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@sStockItemName",sStockItemName);
				insertCommand.Parameters.AddWithValue("@iStockReplace",iStockReplace);
				insertCommand.Parameters.AddWithValue("@iStockLevel",iStockLevel);
				insertCommand.Parameters.AddWithValue("@FKiStockLevelType",FKiStockLevelType);
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.ExecuteNonQuery();
             PKiStockitemID= (Int32)insertCommand.Parameters["@outPKiStockitemID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblstockitem_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiStockitemID", PKiStockitemID);
				updateCommand.Parameters.AddWithValue("@insStockItemName", sStockItemName);
				updateCommand.Parameters.AddWithValue("@iniStockReplace", iStockReplace);
				updateCommand.Parameters.AddWithValue("@iniStockLevel", iStockLevel);
				updateCommand.Parameters.AddWithValue("@inFKiStockLevelType", FKiStockLevelType);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.ExecuteNonQuery();
				return true;
			}

            public bool executeUPDATESTOCKLEVEL(int StockitemID, int StocklevelReduce) {
                MySqlCommand updateLevel = new MySqlCommand("stockReduce_UPDATE", clsDatabase.getPooledConnection());
                updateLevel.CommandType = System.Data.CommandType.StoredProcedure;
                updateLevel.Parameters.AddWithValue("inPKiStockItemID", StockitemID);
                updateLevel.Parameters.AddWithValue("iniQuantity", StocklevelReduce);
                updateLevel.ExecuteNonQuery();
                return true;
            }
	}
}
