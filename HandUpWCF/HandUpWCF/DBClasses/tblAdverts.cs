using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblAdverts{
		public const string _PKIADVERTID="PKiAdvertID";
		public const string _FKIPROVIDERID="FKiProviderID";
		public const string _SADVERTURL="sAdvertURL";
		public const string _IMGADVERTIMAGE="imgAdvertImage";
		public const string _tblAdverts="tbladverts";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiAdvertID;
		public int PKiAdvertID{
			get {
				return _PKiAdvertID;
			}
			set {
				_PKiAdvertID = value;
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
		private string _sAdvertURL;
		public string sAdvertURL{
			get {
				return _sAdvertURL;
			}
			set {
				_sAdvertURL = value;
			}
		}
		private string _imgAdvertImage;
		public string imgAdvertImage{
			get {
				return _imgAdvertImage;
			}
			set {
				_imgAdvertImage = value;
			}
		}
		private string sOrderBy="PKiAdvertID";
		private string sOrderType="ASC";

		public tblAdverts(int initPKiAdvertID){
			addEquals(_PKIADVERTID,initPKiAdvertID);
			List<tblAdverts> listtblAdverts=executeSelect();
			tblAdverts atblAdverts=listtblAdverts[0];
			this.PKiAdvertID=atblAdverts.PKiAdvertID;
			this.FKiProviderID=atblAdverts.FKiProviderID;
			this.sAdvertURL=atblAdverts.sAdvertURL;
			this.imgAdvertImage=atblAdverts.imgAdvertImage;
		}

		public tblAdverts(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblAdverts> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblAdverts> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblAdverts> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblAdverts> listtblAdverts=new List<tblAdverts>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblAdverts atblAdverts= new tblAdverts();
					iIndex=aSqlReader.GetOrdinal("PKiAdvertID");
					atblAdverts.PKiAdvertID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblAdverts.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sAdvertURL");
					atblAdverts.sAdvertURL=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("imgAdvertImage");
					atblAdverts.imgAdvertImage=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblAdverts.Add(atblAdverts);
					}
			}
			aSqlReader.Close();
			return listtblAdverts;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tbladverts WHERE "+ sSqlWhere;
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
			List<tblAdverts> listtblAdverts=new List<tblAdverts>();
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

			public tblAdverts executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tbladverts_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiAdvertID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiAdvertID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.Parameters.AddWithValue("@sAdvertURL",sAdvertURL);
				insertCommand.Parameters.AddWithValue("@imgAdvertImage",imgAdvertImage);
				insertCommand.ExecuteNonQuery();
             PKiAdvertID= (Int32)insertCommand.Parameters["@outPKiAdvertID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tbladverts_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiAdvertID", PKiAdvertID);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.Parameters.AddWithValue("@insAdvertURL", sAdvertURL);
				updateCommand.Parameters.AddWithValue("@inimgAdvertImage", imgAdvertImage);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
