using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblStockpermenuitem{
		public const string _PKISTOCKPERMENUITEMID="PKistockpermenuitemID";
		public const string _FKIMENUITEM="FKiMenuItem";
		public const string _FKISTOCKID="FKiStockID";
		public const string _ISTOCKAMOUNT="iStockAmount";
		public const string _FKISUBMENUITEM="FKiSubmenuItem";
		public const string _tblStockpermenuitem="tblstockpermenuitem";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKistockpermenuitemID;
		public int PKistockpermenuitemID{
			get {
				return _PKistockpermenuitemID;
			}
			set {
				_PKistockpermenuitemID = value;
			}
		}
		private int _FKiMenuItem;
		public int FKiMenuItem{
			get {
				return _FKiMenuItem;
			}
			set {
				_FKiMenuItem = value;
			}
		}
		private int _FKiStockID;
		public int FKiStockID{
			get {
				return _FKiStockID;
			}
			set {
				_FKiStockID = value;
			}
		}
		private int _iStockAmount;
		public int iStockAmount{
			get {
				return _iStockAmount;
			}
			set {
				_iStockAmount = value;
			}
		}
		private int _FKiSubmenuItem;
		public int FKiSubmenuItem{
			get {
				return _FKiSubmenuItem;
			}
			set {
				_FKiSubmenuItem = value;
			}
		}
		private string sOrderBy="PKistockpermenuitemID";
		private string sOrderType="ASC";

		public tblStockpermenuitem(int initPKistockpermenuitemID){
			addEquals(_PKISTOCKPERMENUITEMID,initPKistockpermenuitemID);
			List<tblStockpermenuitem> listtblStockpermenuitem=executeSelect();
			tblStockpermenuitem atblStockpermenuitem=listtblStockpermenuitem[0];
			this.PKistockpermenuitemID=atblStockpermenuitem.PKistockpermenuitemID;
			this.FKiMenuItem=atblStockpermenuitem.FKiMenuItem;
			this.FKiStockID=atblStockpermenuitem.FKiStockID;
			this.iStockAmount=atblStockpermenuitem.iStockAmount;
			this.FKiSubmenuItem=atblStockpermenuitem.FKiSubmenuItem;
		}

		public tblStockpermenuitem(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblStockpermenuitem> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblStockpermenuitem> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblStockpermenuitem> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblStockpermenuitem> listtblStockpermenuitem=new List<tblStockpermenuitem>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblStockpermenuitem atblStockpermenuitem= new tblStockpermenuitem();
					iIndex=aSqlReader.GetOrdinal("PKistockpermenuitemID");
					atblStockpermenuitem.PKistockpermenuitemID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiMenuItem");
					atblStockpermenuitem.FKiMenuItem=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiStockID");
					atblStockpermenuitem.FKiStockID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("iStockAmount");
					atblStockpermenuitem.iStockAmount=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiSubmenuItem");
					atblStockpermenuitem.FKiSubmenuItem=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					listtblStockpermenuitem.Add(atblStockpermenuitem);
					}
			}
			aSqlReader.Close();
			return listtblStockpermenuitem;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblstockpermenuitem WHERE "+ sSqlWhere;
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
			List<tblStockpermenuitem> listtblStockpermenuitem=new List<tblStockpermenuitem>();
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

			public string addLike(string sColumnName,int aValue){
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

			public string addGreaterThan(string sColumnName,int aValue){
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

			public tblStockpermenuitem executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblstockpermenuitem_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKistockpermenuitemID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKistockpermenuitemID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiMenuItem",FKiMenuItem);
				insertCommand.Parameters.AddWithValue("@FKiStockID",FKiStockID);
				insertCommand.Parameters.AddWithValue("@iStockAmount",iStockAmount);
				insertCommand.Parameters.AddWithValue("@FKiSubmenuItem",FKiSubmenuItem);
				insertCommand.ExecuteNonQuery();
             PKistockpermenuitemID= (Int32)insertCommand.Parameters["@outPKistockpermenuitemID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblstockpermenuitem_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKistockpermenuitemID", PKistockpermenuitemID);
				updateCommand.Parameters.AddWithValue("@inFKiMenuItem", FKiMenuItem);
				updateCommand.Parameters.AddWithValue("@inFKiStockID", FKiStockID);
				updateCommand.Parameters.AddWithValue("@iniStockAmount", iStockAmount);
				updateCommand.Parameters.AddWithValue("@inFKiSubmenuItem", FKiSubmenuItem);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
