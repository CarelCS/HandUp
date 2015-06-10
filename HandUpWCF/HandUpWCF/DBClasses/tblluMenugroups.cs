using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblluMenugroups{
		public const string _PKIMENUGROUPID="PKiMenuGroupID";
		public const string _SMENUGROUPNAME="sMenuGroupName";
		public const string _SMENUGROUPDESCRIPTION="sMenuGroupDescription";
        public const string _SFKIPROVIDERID = "FKiProviderID";
        public const string _FKIMENUGROUPID = "FKiMenuGroupID";
		public const string _tblluMenugroups="tbllumenugroups";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiMenuGroupID;
		public int PKiMenuGroupID{
			get {
				return _PKiMenuGroupID;
			}
			set {
				_PKiMenuGroupID = value;
			}
		}
        private int _FKiMenuGroupID;
        public int FKiMenuGroupID {
            get {
                return _FKiMenuGroupID;
            }
            set {
                _FKiMenuGroupID = value;
            }
        }
		private string _sMenuGroupName;
		public string sMenuGroupName{
			get {
				return _sMenuGroupName;
			}
			set {
				_sMenuGroupName = value;
			}
		}
		private string _sMenuGroupDescription;
		public string sMenuGroupDescription{
			get {
				return _sMenuGroupDescription;
			}
			set {
				_sMenuGroupDescription = value;
			}
		}
        private string _FKiProviderID;
        public string FKiProviderID {
            get {
                return _FKiProviderID;
            }
            set {
                _FKiProviderID = value;
            }
        }
		private string sOrderBy="PKiMenuGroupID";
		private string sOrderType="ASC";

		public tblluMenugroups(int initPKiMenuGroupID){
			addEquals(_PKIMENUGROUPID,initPKiMenuGroupID);
			List<tblluMenugroups> listtblluMenugroups=executeSelect();
			tblluMenugroups atblluMenugroups=listtblluMenugroups[0];
			this.PKiMenuGroupID=atblluMenugroups.PKiMenuGroupID;
			this.sMenuGroupName=atblluMenugroups.sMenuGroupName;
			this.sMenuGroupDescription=atblluMenugroups.sMenuGroupDescription;
            this.FKiMenuGroupID = atblluMenugroups.FKiMenuGroupID;
            this.FKiProviderID = atblluMenugroups.FKiProviderID;
		}

		public tblluMenugroups(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblluMenugroups> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblluMenugroups> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblluMenugroups> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblluMenugroups> listtblluMenugroups=new List<tblluMenugroups>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblluMenugroups atblluMenugroups= new tblluMenugroups();
					iIndex=aSqlReader.GetOrdinal("PKiMenuGroupID");
					atblluMenugroups.PKiMenuGroupID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sMenuGroupName");
					atblluMenugroups.sMenuGroupName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sMenuGroupDescription");
                    atblluMenugroups.sMenuGroupDescription = aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
                    iIndex = aSqlReader.GetOrdinal("FKiMenuGroupID");
                    atblluMenugroups.FKiMenuGroupID = aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
                    iIndex = aSqlReader.GetOrdinal("FKiProviderID");
                    atblluMenugroups.FKiProviderID = aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblluMenugroups.Add(atblluMenugroups);
					}
			}
			aSqlReader.Close();
			return listtblluMenugroups;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tbllumenugroups WHERE "+ sSqlWhere;
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
			List<tblluMenugroups> listtblluMenugroups=new List<tblluMenugroups>();
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

			public List<tblMenu> gettblMenu_FKiMenuGroupIDList(){
				tblMenu atblMenu=new tblMenu();
				atblMenu.addEquals("FKiMenuGroupID",PKiMenuGroupID);
				return atblMenu.executeSelect();
			}

			public List<tblMenu> gettblMenu_FKiMenuGroupIDList(string localsOrderBy,string localsOrderType){
				tblMenu atblMenu=new tblMenu();
				atblMenu.addEquals("FKiMenuGroupID",PKiMenuGroupID);
				return atblMenu.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblMenu> gettblMenu_FKiMenuGroupIDList(string sAddToSqlWhere,string localsOrderBy,string localsOrderType){
				tblMenu atblMenu=new tblMenu();
				atblMenu.addToSqlWhere(sAddToSqlWhere);
				atblMenu.addEquals("FKiMenuGroupID",PKiMenuGroupID);
				return atblMenu.executeSelect(localsOrderBy,localsOrderType);
			}

			public List<tblMenu> gettblMenu_FKiMenuGroupIDList(string sAddToSqlWhere){
				tblMenu atblMenu=new tblMenu();
				atblMenu.addToSqlWhere(sAddToSqlWhere);
				return atblMenu.executeSelect();
			}

			public tblluMenugroups executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tbllumenugroups_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiMenuGroupID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiMenuGroupID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@sMenuGroupName",sMenuGroupName);
                insertCommand.Parameters.AddWithValue("@sMenuGroupDescription", sMenuGroupDescription);
                insertCommand.Parameters.AddWithValue("@FKiMenuGroupID", FKiMenuGroupID);
                insertCommand.Parameters.AddWithValue("@sFKiProviderID", FKiProviderID);
				insertCommand.ExecuteNonQuery();
             PKiMenuGroupID= (Int32)insertCommand.Parameters["@outPKiMenuGroupID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tbllumenugroups_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiMenuGroupID", PKiMenuGroupID);
				updateCommand.Parameters.AddWithValue("@insMenuGroupName", sMenuGroupName);
                updateCommand.Parameters.AddWithValue("@insMenuGroupDescription", sMenuGroupDescription);
                updateCommand.Parameters.AddWithValue("@inFKiMenuGroupID", FKiMenuGroupID);
                updateCommand.Parameters.AddWithValue("@insFKiProviderID", FKiProviderID);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
