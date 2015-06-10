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
            aDataSet.Tables[0].TableName = "Menu";

            tblluMenugroups aMenuGroup = new tblluMenugroups();
            DataSet dsGroupNames = aMenuGroup.executeCustomSQLDataSet("SELECT distinct " + tblluMenugroups._PKIMENUGROUPID + "," + tblluMenugroups._SMENUGROUPNAME + "," + tblluMenugroups._SMENUGROUPDESCRIPTION + ",tblluMenugroups." + tblluMenugroups._FKIMENUGROUPID +
                " FROM tbllumenugroups,tblmenu" +
                " WHERE tbllumenugroups.PKiMenuGroupID=tblmenu.FKiMenuGroupID and handup.tblmenu.FKiProviderID=" + sProviderID);
            dsGroupNames.Tables[0].TableName = "MenuGroup";
            aDataSet.Tables.Add(dsGroupNames.Tables[0].Copy());

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

        public DataSet getMenuItemByID(int MenuID) {
            tblMenu aMenu = new tblMenu();
            aMenu.addEquals(tblMenu._PKIMENUID, MenuID);
            DataSet aDataSet = aMenu.executeSelectDataSet();
            return aDataSet;
        }

        public DataSet getMenuGroupsPerProvider(int ProviderID) {
            tblluMenugroups aMenuGroup = new tblluMenugroups();
            aMenuGroup.addEquals(tblluMenugroups._SFKIPROVIDERID, ProviderID);
            DataSet aDataSet = aMenuGroup.executeSelectDataSet();
            return aDataSet;
        }
        
        public DataSet getServiceStationsPerProvider(int ProviderID) {
            tblServicestaion aMenuSS = new tblServicestaion();
            aMenuSS.addEquals(tblServicestaion._FKIPROVIDERID, ProviderID);
            DataSet aDataSet = aMenuSS.executeSelectDataSet();
            return aDataSet;
        }
    }
}