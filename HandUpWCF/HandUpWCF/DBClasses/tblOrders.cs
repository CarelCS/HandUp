using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblOrders{
		public const string _PKIORDERID="PKiOrderID";
		public const string _FKIPROVIDERID="FKiProviderID";
		public const string _FKIPATRONID="FKiPatronID";
		public const string _FKIMENUID="FKiMenuID";
		public const string _FKITABLEID="FKiTableID";
		public const string _FKIMENUGROUPID="FKiMenuGroupID";
		public const string _DTORDERDATESTAMP="dtOrderDateStamp";
		public const string _SMENUITEMCHANGES="sMenuItemChanges";
		public const string _SORDERSTATUS="sOrderStatus";
		public const string _DBLORDERVALUE="dblOrderValue";
		public const string _IBILLID="iBillID";
		public const string _tblOrders="tblorders";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiOrderID;
		public int PKiOrderID{
			get {
				return _PKiOrderID;
			}
			set {
				_PKiOrderID = value;
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
		private int _FKiPatronID;
		public int FKiPatronID{
			get {
				return _FKiPatronID;
			}
			set {
				_FKiPatronID = value;
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
		private int _FKiTableID;
		public int FKiTableID{
			get {
				return _FKiTableID;
			}
			set {
				_FKiTableID = value;
			}
		}
		private int _FKiMenuGroupID;
		public int FKiMenuGroupID{
			get {
				return _FKiMenuGroupID;
			}
			set {
				_FKiMenuGroupID = value;
			}
		}
		private DateTime _dtOrderDateStamp;
		public DateTime dtOrderDateStamp{
			get {
				return _dtOrderDateStamp;
			}
			set {
				_dtOrderDateStamp = value;
			}
		}
		private string _sMenuItemChanges;
		public string sMenuItemChanges{
			get {
				return _sMenuItemChanges;
			}
			set {
				_sMenuItemChanges = value;
			}
		}
		private string _sOrderStatus;
		public string sOrderStatus{
			get {
				return _sOrderStatus;
			}
			set {
				_sOrderStatus = value;
			}
		}
		private double _dblOrderValue;
		public double dblOrderValue{
			get {
				return _dblOrderValue;
			}
			set {
				_dblOrderValue = value;
			}
		}
		private int _iBillID;
		public int iBillID{
			get {
				return _iBillID;
			}
			set {
				_iBillID = value;
			}
		}
		private string sOrderBy="PKiOrderID";
		private string sOrderType="ASC";

		public tblOrders(int initPKiOrderID){
			addEquals(_PKIORDERID,initPKiOrderID);
			List<tblOrders> listtblOrders=executeSelect();
			tblOrders atblOrders=listtblOrders[0];
			this.PKiOrderID=atblOrders.PKiOrderID;
			this.FKiProviderID=atblOrders.FKiProviderID;
			this.FKiPatronID=atblOrders.FKiPatronID;
			this.FKiMenuID=atblOrders.FKiMenuID;
			this.FKiTableID=atblOrders.FKiTableID;
			this.FKiMenuGroupID=atblOrders.FKiMenuGroupID;
			this.dtOrderDateStamp=atblOrders.dtOrderDateStamp;
			this.sMenuItemChanges=atblOrders.sMenuItemChanges;
			this.sOrderStatus=atblOrders.sOrderStatus;
			this.dblOrderValue=atblOrders.dblOrderValue;
			this.iBillID=atblOrders.iBillID;
		}

		public tblOrders(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblOrders> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblOrders> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblOrders> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblOrders> listtblOrders=new List<tblOrders>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblOrders atblOrders= new tblOrders();
					iIndex=aSqlReader.GetOrdinal("PKiOrderID");
					atblOrders.PKiOrderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblOrders.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiPatronID");
					atblOrders.FKiPatronID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiMenuID");
					atblOrders.FKiMenuID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiTableID");
					atblOrders.FKiTableID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiMenuGroupID");
					atblOrders.FKiMenuGroupID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtOrderDateStamp");
					atblOrders.dtOrderDateStamp=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("sMenuItemChanges");
					atblOrders.sMenuItemChanges=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sOrderStatus");
					atblOrders.sOrderStatus=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("dblOrderValue");
					atblOrders.dblOrderValue=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetDouble(iIndex);
					iIndex=aSqlReader.GetOrdinal("iBillID");
					atblOrders.iBillID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					listtblOrders.Add(atblOrders);
					}
			}
			aSqlReader.Close();
			return listtblOrders;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblorders WHERE "+ sSqlWhere;
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
			List<tblOrders> listtblOrders=new List<tblOrders>();
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

			public string addEquals(string sColumnName,double aValue){
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

			public string addLike(string sColumnName,double aValue){
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

			public string addLessThan(string sColumnName,double aValue){
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

			public string addGreaterThan(string sColumnName,double aValue){
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

			public tblMenu gettblMenu_FKiMenuID(){
				tblMenu atblMenu=new tblMenu(FKiMenuID);
				return atblMenu;
			}

			public tblProviders gettblProviders_FKiProviderID(){
				tblProviders atblProviders=new tblProviders(FKiProviderID);
				return atblProviders;
			}

			public tblTables gettblTables_FKiTableID(){
				tblTables atblTables=new tblTables(FKiTableID);
				return atblTables;
			}

			public tblOrders executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblorders_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiOrderID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiOrderID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.Parameters.AddWithValue("@FKiPatronID",FKiPatronID);
				insertCommand.Parameters.AddWithValue("@FKiMenuID",FKiMenuID);
				insertCommand.Parameters.AddWithValue("@FKiTableID",FKiTableID);
				insertCommand.Parameters.AddWithValue("@FKiMenuGroupID",FKiMenuGroupID);
				insertCommand.Parameters.AddWithValue("@dtOrderDateStamp",dtOrderDateStamp);
				insertCommand.Parameters.AddWithValue("@sMenuItemChanges",sMenuItemChanges);
				insertCommand.Parameters.AddWithValue("@sOrderStatus",sOrderStatus);
				insertCommand.Parameters.AddWithValue("@dblOrderValue",dblOrderValue);
				insertCommand.Parameters.AddWithValue("@iBillID",iBillID);
				insertCommand.ExecuteNonQuery();
             PKiOrderID= (Int32)insertCommand.Parameters["@outPKiOrderID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblorders_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiOrderID", PKiOrderID);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.Parameters.AddWithValue("@inFKiPatronID", FKiPatronID);
				updateCommand.Parameters.AddWithValue("@inFKiMenuID", FKiMenuID);
				updateCommand.Parameters.AddWithValue("@inFKiTableID", FKiTableID);
				updateCommand.Parameters.AddWithValue("@inFKiMenuGroupID", FKiMenuGroupID);
				updateCommand.Parameters.AddWithValue("@dtOrderDateStamp", dtOrderDateStamp);
				updateCommand.Parameters.AddWithValue("@insMenuItemChanges", sMenuItemChanges);
				updateCommand.Parameters.AddWithValue("@insOrderStatus", sOrderStatus);
				updateCommand.Parameters.AddWithValue("@indblOrderValue", dblOrderValue);
				updateCommand.Parameters.AddWithValue("@iniBillID", iBillID);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
