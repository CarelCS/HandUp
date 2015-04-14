using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;

namespace HandUpWCF {
    public class Menu {
        public DataSet MenuForProvider(string sProviderID) {
            tblMenu aMenu = new tblMenu();
            aMenu.addEquals(tblMenu._FKIPROVIDERID, sProviderID);
            DataSet aDataSet = aMenu.executeSelectDataSet();

            foreach (DataRow aMenuDataRow in aDataSet.Tables[0].Rows) {
                tblluSubmenus aSubMenu = new tblluSubmenus();
                aSubMenu.addEquals(tblluSubmenus._FKIMENUID, Convert.ToInt32(aMenuDataRow[tblMenu._PKIMENUID]));
                DataSet dsSubMenus = aSubMenu.executeSelectDataSet();
                foreach (DataRow aSubMenuDataRow in dsSubMenus.Tables[0].Rows) {

                }
            }


            // DataAdapters newAdapter = new DataAdapters();
            // string SqlText = "Select * from tblmenu where FKiProviderID = '" + sProviderID + "'; Select * from tblmenu inner join tbllusubmenus on PKiSubMenuID = FKiSubMenuID;";
            //DataSet da = newAdapter.RetrieveTable(SqlText);
            return aDataSet;
        }
    }
}