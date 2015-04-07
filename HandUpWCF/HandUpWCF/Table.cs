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

        public string JoinTableCode(string sTableCode) {
            string SqlText = "insert into tblTables (FKiEmployeeID, FKiProviderID, iGuestNumber, dtStartDateTime, dtEndDateTime, UIDGenerate) values (" + WaiterID + ", '" + ProviderID + "', '" + NumberOfGuests + "', '" + TableStartDate + "', '" + TableEndDate + "', '" + TableCode + "')";
            DataAdapters da = new DataAdapters();
            da.InsertUpdateData(SqlText);
            return ""; 
        }

        public DataSet WaiterLogin(string sUserName, string sPassword) {
            DataAdapters newAdapter = new DataAdapters();
            string sSqlQuery = "Select * from tblEmployees inner join tblluemployeetype on FKiEmployeeType = PKiEmployeeTypeID where sUserName = '" + sUserName + "' and sPassword = '" + sPassword + "'";
            DataSet newDs = newAdapter.RetrieveTable(sSqlQuery);
            string ThisValue = "";
            try {
                ThisValue = newDs.Tables[0].Rows[0][1].ToString() + " " + newDs.Tables[0].Rows[0][2].ToString();
            }
            catch { }
            return newDs; 
        }
    }
}