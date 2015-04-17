using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblMenu{
		public const string _PKIMENUID="PKiMenuID";
		public const string _FKIPROVIDERID="FKiProviderID";
		public const string _FKIMENUID="FKiMenuID";
		public const string _FKIMENUGROUPID="FKiMenuGroupID";
		public const string _SMENUITEMNAME="sMenuItemName";
		public const string _SMENUITEMDESCRIPTION="sMenuItemDescription";
		public const string _DTMENUITEMMODIFIED="dtMenuItemModified";
		public const string _DBLMENUITEMPRICE="dblMenuItemPrice";
		public const string _IMGMENUITEMIMAGE="imgMenuItemImage";
		public const string _BACTIVESTATUS="bActiveStatus";
		public const string _tblMenu="tblmenu";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiMenuID;
		public int PKiMenuID{
			get {
				return _PKiMenuID;
			}
			set {
				_PKiMenuID = value;
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
		private int _FKiMenuID;
		public int FKiMenuID{
			get {
				return _FKiMenuID;
			}
			set {
				_FKiMenuID = value;
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
		private string _sMenuItemName;
		public string sMenuItemName{
			get {
				return _sMenuItemName;
			}
			set {
				_sMenuItemName = value;
			}
		}
		private string _sMenuItemDescription;
		public string sMenuItemDescription{
			get {
				return _sMenuItemDescription;
			}
			set {
				_sMenuItemDescription = value;
			}
		}
		private DateTime _dtMenuItemModified;
		public DateTime dtMenuItemModified{
			get {
				return _dtMenuItemModified;
			}
			set {
				_dtMenuItemModified = value;
			}
		}
		private double _dblMenuItemPrice;
		public double dblMenuItemPrice{
			get {
				return _dblMenuItemPrice;
			}
			set {
				_dblMenuItemPrice = value;
			}
		}
		private string _imgMenuItemImage;
		public string imgMenuItemImage{
			get {
				return _imgMenuItemImage;
			}
			set {
				_imgMenuItemImage = value;
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
		private string sOrderBy="PKiMenuID";
		private string sOrderType="ASC";

		public tblMenu(int initPKiMenuID){
			addEquals(_PKIMENUID,initPKiMenuID);
			List<tblMenu> listtblMenu=executeSelect();
			tblMenu atblMenu=listtblMenu[0];
			this.PKiMenuID=atblMenu.PKiMenuID;
			this.FKiProviderID=atblMenu.FKiProviderID;
			this.FKiMenuID=atblMenu.FKiMenuID;
			this.FKiMenuGroupID=atblMenu.FKiMenuGroupID;
			this.sMenuItemName=atblMenu.sMenuItemName;
			this.sMenuItemDescription=atblMenu.sMenuItemDescription;
			this.dtMenuItemModified=atblMenu.dtMenuItemModified;
			this.dblMenuItemPrice=atblMenu.dblMenuItemPrice;
			this.imgMenuItemImage=atblMenu.imgMenuItemImage;
			this.bActiveStatus=atblMenu.bActiveStatus;
		}

		public tblMenu(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblMenu> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblMenu> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblMenu> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblMenu> listtblMenu=new List<tblMenu>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblMenu atblMenu= new tblMenu();
					iIndex=aSqlReader.GetOrdinal("PKiMenuID");
					atblMenu.PKiMenuID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiProviderID");
					atblMenu.FKiProviderID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiMenuID");
					atblMenu.FKiMenuID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("FKiMenuGroupID");
					atblMenu.FKiMenuGroupID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sMenuItemName");
					atblMenu.sMenuItemName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sMenuItemDescription");
					atblMenu.sMenuItemDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("dtMenuItemModified");
					atblMenu.dtMenuItemModified=aSqlReader.IsDBNull(iIndex) ? new DateTime() : aSqlReader.GetDateTime(iIndex);
					iIndex=aSqlReader.GetOrdinal("dblMenuItemPrice");
					atblMenu.dblMenuItemPrice=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetDouble(iIndex);
					iIndex=aSqlReader.GetOrdinal("imgMenuItemImage");
					atblMenu.imgMenuItemImage=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("bActiveStatus");
					atblMenu.bActiveStatus=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					listtblMenu.Add(atblMenu);
					}
			}
			aSqlReader.Close();
			return listtblMenu;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblmenu WHERE "+ sSqlWhere;
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
			List<tblMenu> listtblMenu=new List<tblMenu>();
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

			public tblluMenugroups gettblluMenugroups_FKiMenuGroupID(){
				tblluMenugroups atblluMenugroups=new tblluMenugroups(FKiMenuGroupID);
				return atblluMenugroups;
			}

			public tblProviders gettblProviders_FKiProviderID(){
				tblProviders atblProviders=new tblProviders(FKiProviderID);
				return atblProviders;
			}

			public List<tblluSubmenus> gettblluSubmenus_FKiMenuIDList(){
				tblluSubmenus atblluSubmenus=new tblluSubmenus();
				atblluSubmenus.addEquals("FKiMenuID",PKiMenuID);
				return atblluSubmenus.executeSelect();
			}

			public List<tblluSubmenus> gettblluSubmenus_FKiMenuIDList(string localsOrderBy,string localsOrderType){
				tblluSubmenus atblluSubmenus=new tblluSubmenus();
				atblluSubmenus.addEquals("FKiMenuID",PKiMenuID);
				return atblluSubmenus.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblluSubmenus> gettblluSubmenus_FKiMenuIDList(string sAddToSqlWhere,string localsOrderBy,string localsOrderType){
				tblluSubmenus atblluSubmenus=new tblluSubmenus();
				atblluSubmenus.addToSqlWhere(sAddToSqlWhere);
				atblluSubmenus.addEquals("FKiMenuID",PKiMenuID);
				return atblluSubmenus.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblluSubmenus> gettblluSubmenus_FKiMenuIDList(string sAddToSqlWhere){
				tblluSubmenus atblluSubmenus=new tblluSubmenus();
				atblluSubmenus.addToSqlWhere(sAddToSqlWhere);
				return atblluSubmenus.executeSelect();
			}

			public List<tblOrders> gettblOrders_FKiMenuIDList(){
				tblOrders atblOrders=new tblOrders();
				atblOrders.addEquals("FKiMenuID",PKiMenuID);
				return atblOrders.executeSelect();
			}

			public List<tblOrders> gettblOrders_FKiMenuIDList(string localsOrderBy,string localsOrderType){
				tblOrders atblOrders=new tblOrders();
				atblOrders.addEquals("FKiMenuID",PKiMenuID);
				return atblOrders.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblOrders> gettblOrders_FKiMenuIDList(string sAddToSqlWhere,string localsOrderBy,string localsOrderType){
				tblOrders atblOrders=new tblOrders();
				atblOrders.addToSqlWhere(sAddToSqlWhere);
				atblOrders.addEquals("FKiMenuID",PKiMenuID);
				return atblOrders.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblOrders> gettblOrders_FKiMenuIDList(string sAddToSqlWhere){
				tblOrders atblOrders=new tblOrders();
				atblOrders.addToSqlWhere(sAddToSqlWhere);
				return atblOrders.executeSelect();
			}

			public tblMenu executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblmenu_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiMenuID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiMenuID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@FKiProviderID",FKiProviderID);
				insertCommand.Parameters.AddWithValue("@FKiMenuID",FKiMenuID);
				insertCommand.Parameters.AddWithValue("@FKiMenuGroupID",FKiMenuGroupID);
				insertCommand.Parameters.AddWithValue("@sMenuItemName",sMenuItemName);
				insertCommand.Parameters.AddWithValue("@sMenuItemDescription",sMenuItemDescription);
				insertCommand.Parameters.AddWithValue("@dtMenuItemModified",dtMenuItemModified);
				insertCommand.Parameters.AddWithValue("@dblMenuItemPrice",dblMenuItemPrice);
				insertCommand.Parameters.AddWithValue("@imgMenuItemImage",imgMenuItemImage);
				insertCommand.Parameters.AddWithValue("@bActiveStatus",bActiveStatus);
				insertCommand.ExecuteNonQuery();
             PKiMenuID= (Int32)insertCommand.Parameters["@outPKiMenuID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblmenu_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiMenuID", PKiMenuID);
				updateCommand.Parameters.AddWithValue("@inFKiProviderID", FKiProviderID);
				updateCommand.Parameters.AddWithValue("@inFKiMenuID", FKiMenuID);
				updateCommand.Parameters.AddWithValue("@inFKiMenuGroupID", FKiMenuGroupID);
				updateCommand.Parameters.AddWithValue("@insMenuItemName", sMenuItemName);
				updateCommand.Parameters.AddWithValue("@insMenuItemDescription", sMenuItemDescription);
				updateCommand.Parameters.AddWithValue("@indtMenuItemModified", dtMenuItemModified);
				updateCommand.Parameters.AddWithValue("@indblMenuItemPrice", dblMenuItemPrice);
				updateCommand.Parameters.AddWithValue("@inimgMenuItemImage", imgMenuItemImage);
				updateCommand.Parameters.AddWithValue("@inbActiveStatus", bActiveStatus);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
