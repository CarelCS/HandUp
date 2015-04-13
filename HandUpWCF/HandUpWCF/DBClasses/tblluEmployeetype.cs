using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace HandUpWCF.DBClasses{
	class tblluEmployeetype{
		public const string _PKIEMPLOYEETYPEID="PKiEmployeeTypeID";
		public const string _SEMPLOYEETYPENAME="sEmployeeTypeName";
		public const string _SEMPLOYEETYPEDESCRIPTION="sEmployeeTypeDescription";
		public const string _tblluEmployeetype="tblluemployeetype";
		public const string _Ascending="ASC";
		public const string _Descending="DESC";

		private string sSqlWhere="";

		private int _PKiEmployeeTypeID;
		public int PKiEmployeeTypeID{
			get {
				return _PKiEmployeeTypeID;
			}
			set {
				_PKiEmployeeTypeID = value;
			}
		}
		private string _sEmployeeTypeName;
		public string sEmployeeTypeName{
			get {
				return _sEmployeeTypeName;
			}
			set {
				_sEmployeeTypeName = value;
			}
		}
		private string _sEmployeeTypeDescription;
		public string sEmployeeTypeDescription{
			get {
				return _sEmployeeTypeDescription;
			}
			set {
				_sEmployeeTypeDescription = value;
			}
		}
		private string sOrderBy="PKiEmployeeTypeID";
		private string sOrderType="ASC";

		public tblluEmployeetype(int initPKiEmployeeTypeID){
			addEquals(_PKIEMPLOYEETYPEID,initPKiEmployeeTypeID);
			List<tblluEmployeetype> listtblluEmployeetype=executeSelect();
			tblluEmployeetype atblluEmployeetype=listtblluEmployeetype[0];
			this.PKiEmployeeTypeID=atblluEmployeetype.PKiEmployeeTypeID;
			this.sEmployeeTypeName=atblluEmployeetype.sEmployeeTypeName;
			this.sEmployeeTypeDescription=atblluEmployeetype.sEmployeeTypeDescription;
		}

		public tblluEmployeetype(){
			sSqlWhere="";
		}

		public void resetSqlWhere(){
			sSqlWhere="";
		}

		public string addToSqlWhere(string sAddToSqlWhere){
			sSqlWhere+=sAddToSqlWhere;
			return sSqlWhere;
		}

		public List<tblluEmployeetype> executeSelect(){
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		public List<tblluEmployeetype> executeSelect(string localsOrderBy,string localsOrderType){
			sOrderBy=localsOrderBy;
			sOrderType=localsOrderType;
			return getConnectionAndExecuteSelect(getCompleteSQL());
		}

		private List<tblluEmployeetype> getConnectionAndExecuteSelect(string sSelectStmt){
			List<tblluEmployeetype> listtblluEmployeetype=new List<tblluEmployeetype>();
			MySqlCommand aSqlCommand = new MySqlCommand();
			aSqlCommand.Connection=clsDatabase.getPooledConnection();
			aSqlCommand.CommandText = sSelectStmt;
			MySqlDataReader aSqlReader=aSqlCommand.ExecuteReader();
         int iIndex=0;
			if (aSqlReader.HasRows) {
				while (aSqlReader.Read()) {
					tblluEmployeetype atblluEmployeetype= new tblluEmployeetype();
					iIndex=aSqlReader.GetOrdinal("PKiEmployeeTypeID");
					atblluEmployeetype.PKiEmployeeTypeID=aSqlReader.IsDBNull(iIndex) ? 0 : aSqlReader.GetInt32(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeTypeName");
					atblluEmployeetype.sEmployeeTypeName=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					iIndex=aSqlReader.GetOrdinal("sEmployeeTypeDescription");
					atblluEmployeetype.sEmployeeTypeDescription=aSqlReader.IsDBNull(iIndex) ? "" : aSqlReader.GetString(iIndex);
					listtblluEmployeetype.Add(atblluEmployeetype);
					}
			}
			aSqlReader.Close();
			return listtblluEmployeetype;
		}

		public string getCompleteSQL(){
			string sCompleteSQL="SELECT * FROM tblluemployeetype WHERE "+ sSqlWhere;
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
			List<tblluEmployeetype> listtblluEmployeetype=new List<tblluEmployeetype>();
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

			public tblEmployees gettblEmployees_PKiEmployeeTypeID(){
				tblEmployees atblEmployees=new tblEmployees(PKiEmployeeTypeID);
				return atblEmployees;
			}

			public tblluEmployeetype executeINSERT(){
				MySqlCommand insertCommand = new MySqlCommand("tblluemployeetype_INSERT", clsDatabase.getPooledConnection());
				insertCommand.CommandType = System.Data.CommandType.StoredProcedure;
				insertCommand.Parameters.AddWithValue("@outPKiEmployeeTypeID",MySqlDbType.Int32);
				insertCommand.Parameters["@outPKiEmployeeTypeID"].Direction = System.Data.ParameterDirection.Output;
				insertCommand.Parameters.AddWithValue("@sEmployeeTypeName",sEmployeeTypeName);
				insertCommand.Parameters.AddWithValue("@sEmployeeTypeDescription",sEmployeeTypeDescription);
				insertCommand.ExecuteNonQuery();
             PKiEmployeeTypeID= (Int32)insertCommand.Parameters["@outPKiEmployeeTypeID"].Value;
				return this;
			}

			public bool executeUPDATE(){
				MySqlCommand updateCommand = new MySqlCommand("tblluemployeetype_UPDATE", clsDatabase.getPooledConnection());
				updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
				updateCommand.Parameters.AddWithValue("@inPKiEmployeeTypeID", PKiEmployeeTypeID);
				updateCommand.Parameters.AddWithValue("@insEmployeeTypeName", sEmployeeTypeName);
				updateCommand.Parameters.AddWithValue("@insEmployeeTypeDescription", sEmployeeTypeDescription);
				updateCommand.ExecuteNonQuery();
				return true;
			}
	}
}
