using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

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

        public string CreateTable() {
            string SqlText = "insert into tblTables (FKiEmployeeID, FKiProviderID, iGuestNumber, dtStartDateTime, dtEndDateTime, UIDGenerate) values (" + WaiterID + ", '" + ProviderID + "', '" + NumberOfGuests + "', '" + TableStartDate + "', '" + TableEndDate + "', '" + TableCode + "')";
            DataAdapters da = new DataAdapters();
            da.InsertUpdateData(SqlText);
            return ""; 
        }

        public DataSet JoinTableCode(string sTableCode) {
            DataAdapters newAdapter = new DataAdapters();
            string SqlText = "Select * from tbltables where UIDGenerated = '" + sTableCode + "'";
            DataSet da = newAdapter.RetrieveTable(SqlText);
            return da; 
        }

       
    }
}