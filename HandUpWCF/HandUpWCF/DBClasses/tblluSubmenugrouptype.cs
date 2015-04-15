using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblluSubmenugrouptype{
		public const string _PKISUBMENUGROUPTYPEID="PKiSubMenuGroupTypeID";
		public const string _SSUBMENUGROUPTYPENAME="sSubMenuGroupTypeName";
		public const string _SSUBMENUGROUPTYPEDESCRIPTION="sSubMenuGroupTypeDescription";
		public const string _BACTIVESTATUS="bActiveStatus";
		public const string _tblluSubmenugrouptype="tbllusubmenugrouptype";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiSubMenuGroupTypeID;
		public int PKiSubMenuGroupTypeID{
			get {
				return _PKiSubMenuGroupTypeID;
			}
			set {
				_PKiSubMenuGroupTypeID = value;
			}
		}
		private string _sSubMenuGroupTypeName;
		public string sSubMenuGroupTypeName{
			get {
				return _sSubMenuGroupTypeName;
			}
			set {
				_sSubMenuGroupTypeName = value;
			}
		}
		private string _sSubMenuGroupTypeDescription;
		public string sSubMenuGroupTypeDescription{
			get {
				return _sSubMenuGroupTypeDescription;
			}
			set {
				_sSubMenuGroupTypeDescription = value;
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
		private string sOrderBy="PKiSubMenuGroupTypeID";
		private string sOrderType="ASC";

		public tblluSubmenugrouptype(int initPKiSubMenuGroupTypeID){
			addEquals(_PKISUBMENUGROUPTYPEID,initPKiSubMenuGroupTypeID);
			List<tblluSubmenugrouptype> listtblluSubmenugrouptype=executeSelect();
			tblluSubmenugrouptype atblluSubmenugrouptype=listtblluSubmenugrouptype[0];
			this.PKiSubMenuGroupTypeID=atblluSubmenugrouptype.PKiSubMenuGroupTypeID;
			this.sSubMenuGroupTypeName=atblluSubmenugrouptype.sSubMenuGroupTypeName;
			this.sSubMenuGroupTypeDescription=atblluSubmenugrouptype.sSubMenuGroupTypeDescription;
			this.bActiveStatus=atblluSubmenugrouptype.bActiveStatus;
		}

		public tblluSubmenugrouptype(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblluSubmenugrouptype> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblluSubmenugrouptype> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblluSubmenugrouptype> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblluSubmenugrouptype> listtblluSubmenugrouptype=new List<tblluSubmenugrouptype>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblluSubmenugrouptype atblluSubmenugrouptype= new tblluSubmenugrouptype();
					iIndex=aSqlReader.GetOrdinal("PKiSubMenuGroupTypeID");
					atblluSubmenugrouptype.PKiSubMenuGroupTypeID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sSubMenuGroupTypeName");
					atblluSubmenugrouptype.sSubMenuGroupTypeName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sSubMenuGroupTypeDescription");
					atblluSubmenugrouptype.sSubMenuGroupTypeDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("bActiveStatus");
					atblluSubmenugrouptype.bActiveStatus=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					listtblluSubmenugrouptype.Add(atblluSubmenugrouptype);
					}
			}
			aSqlReader.Close();
			return listtblluSubmenugrouptype;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tbllusubmenugrouptype WHERE "+ sSqlWhere;
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
			List<tblluSubmenugrouptype> listtblluSubmenugrouptype=new List<tblluSubmenugrouptype>();
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

			public tblluSubmenus gettblluSubmenus_PKiSubMenuGroupTypeID(){
				tblluSubmenus atblluSubmenus=new tblluSubmenus(PKiSubMenuGroupTypeID);
				return atblluSubmenus;
			}

			public tblluSubmenugrouptype executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tbllusubmenugrouptype_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiSubMenuGroupTypeID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiSubMenuGroupTypeID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@sSubMenuGroupTypeName",sSubMenuGroupTypeName);
				insertCommand.Parameters.AddWithValue("@sSubMenuGroupTypeDescription",sSubMenuGroupTypeDescription);
				insertCommand.Parameters.AddWithValue("@bActiveStatus",bActiveStatus);
				insertCommand.ExecuteNonQuery();
             PKiSubMenuGroupTypeID= (Int32)insertCommand.Parameters["@outPKiSubMenuGroupTypeID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tbllusubmenugrouptype_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiSubMenuGroupTypeID", PKiSubMenuGroupTypeID);
				updateCommand.Parameters.AddWithValue("@insSubMenuGroupTypeName", sSubMenuGroupTypeName);
				updateCommand.Parameters.AddWithValue("@insSubMenuGroupTypeDescription", sSubMenuGroupTypeDescription);
				updateCommand.Parameters.AddWithValue("@inbActiveStatus", bActiveStatus);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
