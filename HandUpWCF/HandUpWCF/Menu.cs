using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;

namespace HandUpWCF {
    public class Menu {
        public DataSet MenuForProvider(string sProviderID) {
            sProviderID = "1";
            tblMenu aMenu = new tblMenu();
            aMenu.addEquals(tblMenu._FKIPROVIDERID, sProviderID);
            DataSet aDataSet = aMenu.executeSelectDataSet();

            foreach (DataRow aMenuDataRow in aDataSet.Tables[0].Rows) {
                tblluSubmenus aSubMenu = new tblluSubmenus();
                aSubMenu.addEquals(tblluSubmenus._FKIMENUID, Convert.ToInt32(aMenuDataRow[tblMenu._PKIMENUID]));
                DataSet dsSubMenus = aSubMenu.executeSelectDataSet();
                Dictionary<string, DataSet> dicSubMenuGroup = new Dictionary<string, DataSet>();
                foreach (DataRow aSubMenuDataRow in dsSubMenus.Tables[0].Rows) {
                    tblluSubmenugrouptype aSubMenuGroup = new tblluSubmenugrouptype((int)aSubMenuDataRow[tblluSubmenus._FKISUBMENUGROUPTYPEID]);
                    if (dicSubMenuGroup.ContainsKey(aSubMenuGroup.sSubMenuGroupTypeName)) {
                        DataSet aSubMenuPerGroupDS = dicSubMenuGroup[aSubMenuGroup.sSubMenuGroupTypeName];
                        aSubMenuPerGroupDS.Tables[aSubMenuGroup.sSubMenuGroupTypeName].ImportRow(aSubMenuDataRow);
                    }
                    else {
                        DataSet aSubMenuPerGroupDS = new DataSet();
                        aSubMenuPerGroupDS.Tables.Add(aSubMenuGroup.sSubMenuGroupTypeName);
                        foreach (DataColumn aDataColumn in dsSubMenus.Tables[0].Columns) {
                            aSubMenuPerGroupDS.Tables[aSubMenuGroup.sSubMenuGroupTypeName].Columns.Add(aDataColumn.ToString());
                        }
                        aSubMenuPerGroupDS.Tables[aSubMenuGroup.sSubMenuGroupTypeName].ImportRow(aSubMenuDataRow);
                        dicSubMenuGroup.Add(aSubMenuGroup.sSubMenuGroupTypeName, aSubMenuPerGroupDS);
                    }
                }
                foreach (KeyValuePair<string, DataSet> aKeyPair in dicSubMenuGroup) {
                    aDataSet.Tables.Add(aKeyPair.Value.Tables[0].Copy());
                }
            }


            // DataAdapters newAdapter = new DataAdapters();
            // string SqlText = "Select * from tblmenu where FKiProviderID = '" + sProviderID + "'; Select * from tblmenu inner join tbllusubmenus on PKiSubMenuID = FKiSubMenuID;";
            //DataSet da = newAdapter.RetrieveTable(SqlText);
            return aDataSet;
        }
    }
}