using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace HandUpWCF {
    public class Menu {
        public DataSet MenuForProvider(string sProviderID) {
            DataAdapters newAdapter = new DataAdapters();
            string SqlText = "Select * from tblmenu where FKiProviderID = '" + sProviderID + "'; Select * from tblmenu inner join tbllusubmenus on PKiSubMenuID = FKiSubMenuID;";
            DataSet da = newAdapter.RetrieveTable(SqlText);
            return da;
        }
    }
}