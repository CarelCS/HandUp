using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;

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

        public string CreateNewTable() {
            string SqlText = "insert into tblTables (FKiEmployeeID, FKiProviderID, iGuestNumber, dtStartDateTime, dtEndDateTime, UIDGenerate) values (" + WaiterID + ", '" + ProviderID + "', '" + NumberOfGuests + "', '" + TableStartDate + "', '" + TableEndDate + "', '" + TableCode + "')";
            DataAdapters da = new DataAdapters();
            da.InsertUpdateData(SqlText);
            return "";
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
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public DataSet ActiveTablesForProcessor(int EmployeeID) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public DataSet ActiveTablesForProvider(int ProviderID) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public DataSet AllTablesForProviderByDate(int ProviderID, DateTime dtFromDate) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public DataSet AllTablesForProviderByDateStatus(int ProviderID, DateTime dtFromDate, int StatusID) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }
    }
}