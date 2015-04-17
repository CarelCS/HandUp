using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;

namespace HandUpWCF {
    public class Employees {
        public int PKiEmployeeID { get; set; }
        public string sEmployeeName { get; set; }
        public string sEmployeeSurname { get; set; }
        public string sEmployeeID { get; set; }
        public string sEmployeeEmail { get; set; }
        public string sEmployeeTel { get; set; }
        public string sEmployeeAddress1 { get; set; }
        public string sEmployeeAddress2 { get; set; }
        public string sEmployeeAddress3 { get; set; }
        public string sEmployeeNationality { get; set; }
        public string sUserName { get; set; }
        public string sPassword { get; set; }
        public int FKiEmployeeType { get; set; }
        public DateTime dtStartDate { get; set; }
        public DateTime dtEndDate { get; set; }
        public string bGender { get; set; }
        public int FKiProviderID { get; set; }
        public string bActiveStatus { get; set; }

        public DataSet TableAlertPerEmployee(int EmployeeID) {
            tblEmployees aEmployee = new tblEmployees(EmployeeID);
            tblTablealerts aTableAlert = new tblTablealerts();
            string sSql="SELECT tbltablealerts.*,tbltables.sTableName FROM tbltablealerts,tbltables where tbltables.PKiTableID=tbltablealerts.FKiTableID "+
                "AND tbltablealerts." + tblTablealerts._BACTIVESTATUS + "= 1 " +
                "AND tbltablealerts." + tblTablealerts._FKIEPLOYEEID + "=" + EmployeeID;
            DataSet aDataset = aTableAlert.executeCustomSQLDataSet(sSql);


           /* DataSet aDataset = aTableAlert.executeSelectDataSet();
            DataSet dsTableName = new DataSet();
            dsTableName.Tables.Add("TableNames");
            dsTableName.Tables[0].Columns.Add(tblTables._PKITABLEID);
            dsTableName.Tables[0].Columns.Add(tblTables._STABLENAME);
            foreach (DataRow aTableAlertRow in aDataset.Tables[0].Rows) {
                tblTables aTable = new tblTables((int)aTableAlertRow[tblTablealerts._FKITABLEID]);
                dsTableName.Tables[0].Rows.Add(new object[] { aTable.PKiTableID, aTable.sTableName });
            }
            aDataset.Tables.Add(dsTableName.Tables[0].Copy());
            * */
            return aDataset;
        }
    }
}