using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;
using System.Security.Cryptography;
using System.Text;

namespace HandUpWCF {
    public class Table {
        public string TableCode { get; set; }
        public int TableID { get; set; }
        public DateTime TableStartDate { get; set; }
        public DateTime TableEndDate { get; set; }
        public int WaiterID { get; set; }
        public int ProviderID { get; set; }
        public int NumberOfGuests { get; set; }
        public Table() { }


        private string GetUniqueKey(int maxSize) {
            char[] chars = new char[35];
            chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data) {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }

        public string AddPatronToTable(int PkiTableID) {
            tblTables aTable = new tblTables(PkiTableID);
            aTable.iGuestNumber = aTable.iGuestNumber + 1;
            aTable.executeUPDATE();
            return aTable.iGuestNumber.ToString();
        }

        public string CallWaiter(int PkiTableID, string sMessage) {
            tblTables aTable = new tblTables(PkiTableID);
            tblEmployees aEmp = aTable.gettblEmployees_FKiEmployeeID();
            //check if recorde exists before inseirt
            tblTablealerts aAlert = new tblTablealerts();
            aAlert.bActiveStatus = 1;
            aAlert.dtAlertStartTime = DateTime.Now;
            aAlert.FKiEployeeID = aEmp.PKiEmployeeID;
            aAlert.FKiTableID = PkiTableID;
            aAlert.sAlertMessage = sMessage;
            aAlert.sAlertGUI = aTable.UIDGenerated;
            aAlert.executeINSERT();
            return "";
        }

        public DataSet getEmployeeAssignedToTable(int PkiTableID) {
            tblTables aTable = new tblTables(PkiTableID);
            Employees aEmployee = new Employees();
            DataSet ds = new DataSet();
            ds = aEmployee.getEmployeeByID(aTable.FKiEmployeeID);
            return ds;
        }
        
        public string AddTable(int FKiEmployeeID, int FKiProviderID, int iGuestNumber, string sTableName, string sDescription) {
            tblTables aTable = new tblTables();
            aTable.bActiveStatus = 1;
            aTable.dtStartDateTime = DateTime.Now;
            aTable.FKiEmployeeID = FKiEmployeeID;
            aTable.FKiProviderID = FKiProviderID;
            aTable.iGuestNumber = iGuestNumber;
            aTable.sTableDescription = sDescription;
            aTable.sTableName = sTableName;
            aTable.UIDGenerated = FKiEmployeeID + GetUniqueKey(3) + DateTime.Now.Month + DateTime.Now.Day;
            //check if UIDGenerated is unique befor insert
            aTable.executeINSERT();

            //string SqlText = "insert into tblTables (FKiEmployeeID, FKiProviderID, iGuestNumber, dtStartDateTime, dtEndDateTime, UIDGenerate) values (" + WaiterID + ", '" + ProviderID + "', '" + NumberOfGuests + "', '" + TableStartDate + "', '" + TableEndDate + "', '" + TableCode + "')";
            //DataAdapters da = new DataAdapters();
            //da.InsertUpdateData(SqlText);
            return aTable.PKiTableID.ToString() + "_" + aTable.UIDGenerated;
        }

        public DataSet JoinTableCode(string sTableCode) {
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._UIDGENERATED, sTableCode);
            DataSet aDataSet = aTable.executeSelectDataSet();

            //DataAdapters newAdapter = new DataAdapters();
            //string SqlText = "Select * from tbltables where UIDGenerated = '" + sTableCode + "'";
            //DataSet da = newAdapter.RetrieveTable(SqlText);
            return aDataSet;
        }

        public DataSet ActiveTablesForWaiter(int EmployeeID) {
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._FKIEMPLOYEEID, EmployeeID);
            DataSet aDataSet = aTable.executeSelectDataSet();
            return aDataSet;
        }

        public DataSet ActiveTablesForProcessor(int EmployeeID) {
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._FKIEMPLOYEEID, EmployeeID);
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public DataSet ActiveTablesForProvider(int ProviderID) {
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._FKIPROVIDERID, ProviderID);
            DataSet aDataSet = aTable.executeSelectDataSet();
            return aDataSet;
        }

        public DataSet AllTablesForProviderByDate(int ProviderID, DateTime dtFromDate) {
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._FKIPROVIDERID, ProviderID);
            aTable.addAND();
            aTable.addGreaterThan(tblTables._DTSTARTDATETIME, dtFromDate);
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public DataSet AllTablesForProviderByDateStatus(int ProviderID, DateTime dtFromDate, int StatusID) {
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._FKIPROVIDERID, ProviderID);
            aTable.addAND();
            aTable.addGreaterThan(tblTables._DTSTARTDATETIME, dtFromDate);
            aTable.addAND();
            aTable.addEquals(tblTables._BACTIVESTATUS, StatusID);
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public string NewTableAlert(string sProvider, string sTable) {
            string AlertSent = "";
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._FKIPROVIDERID, sProvider);
            aTable.addAND();
            aTable.addEquals(tblTables._BACTIVESTATUS, "1");
            DataSet ds = aTable.executeSelectDataSet(); 
            string DoneList = "";
            if (ds.Tables[0].Rows.Count > 0) {
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    if (!DoneList.Contains("|" + dr["FKiEmployeeID"].ToString() + "|"))
                    {
                        tblTablealerts aAlert = new tblTablealerts();
                        aAlert.bActiveStatus = 1;
                        aAlert.dtAlertStartTime = DateTime.Now;
                        aAlert.FKiEployeeID = Convert.ToInt32(dr["FKiEmployeeID"].ToString());
                        aAlert.FKiTableID = Convert.ToInt32(dr["PKiTableID"].ToString());
                        aAlert.sAlertMessage = "NEW GUESTS AT TABLE : " + sTable;
                        aAlert.sAlertGUI = "NA";
                        aAlert.executeINSERT();
                        AlertSent = "SENT";
                    }
                    DoneList += "|" + dr["FKiEmployeeID"].ToString() + "|";
                }
            }
            return AlertSent;
        }
    }
}