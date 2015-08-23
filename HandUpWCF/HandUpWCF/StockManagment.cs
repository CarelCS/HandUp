using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;

namespace HandUpWCF {
    public class StockManagment {
        public DataSet StockTable(int providerID) {
            tblStock aStock = new tblStock();
            DataSet dsStock = aStock.executeCustomSQLDataSet("SELECT distinct PKiStockID,sStockName,sStockDescription,iStockLevelReplace,iStockLevel,FKiStockLevelTypeID,tblStockLevelTypeDescription,sMenuItemName,sMenuItemDescription,iStockLevelReplace,tblmenu.PKiMenuID" +
                                                            " FROM tblStock join tblStockLevelType on tblstock.FKiStockLevelTypeID=tblstockleveltype.PKistockleveltypeID" +
                                                            " join tblstockpermenuitem on tblstockpermenuitem.FKiStockID=tblstock.PKiStockID" +
                                                            " join tblmenu on tblmenu.PKiMenuID=tblstockpermenuitem.FKiMenuItem" +
                                                            " where tblmenu.FKiProviderID=" + providerID);
            return dsStock;
        }

        public void StockAdd(int StockID, double StockAddValue) {
            tblStock aStock = new tblStock();
            DataSet dsStock = aStock.executeCustomSQLDataSet("UPDATE tblStock " +
                                                            " SET iStockLevel = iStockLevel + " + StockAddValue +
                                                            " where tblstock.PKiStockID=" + StockID);
        }

        public void StockDeduct(int StockID, double StockAddValue) {
            tblStock aStock = new tblStock();
            DataSet dsStock = aStock.executeCustomSQLDataSet("UPDATE tblStock " +
                                                            " SET iStockLevel = iStockLevel - " + StockAddValue +
                                                            " where tblstock.PKiStockID=" + StockID);
        }

        public DataSet StockItem(int StockID) {
            tblStock aStock = new tblStock();
            DataSet dsStock = aStock.executeCustomSQLDataSet("SELECT distinct PKiStockID,sStockName,sStockDescription,iStockLevelReplace,iStockLevel,FKiStockLevelTypeID,tblStockLevelTypeDescription,sMenuItemName,sMenuItemDescription,iStockLevelReplace,tblmenu.PKiMenuID" +
                                                            " FROM tblStock join tblStockLevelType on tblstock.FKiStockLevelTypeID=tblstockleveltype.PKistockleveltypeID" +
                                                            " join tblstockpermenuitem on tblstockpermenuitem.FKiStockID=tblstock.PKiStockID" +
                                                            " join tblmenu on tblmenu.PKiMenuID=tblstockpermenuitem.FKiMenuItem" +
                                                            " where tblstock.PKiStockID=" + StockID);
            return dsStock;
        }

        public DataSet StockTypeList() {
            tblStockleveltype aStockLevel = new tblStockleveltype();
            aStockLevel.addGreaterThan(tblStockleveltype._PKISTOCKLEVELTYPEID, 0);
            return aStockLevel.executeSelectDataSet();
        }

        public void UpdateStockItem(string StockItemID, string StockName, string StockDesc, string StockLevel, string StocklevelReplace, string MenuItem, string StocklevelType) {
            tblStock aStock = new tblStock();
            tblStockpermenuitem aStockMenu = new tblStockpermenuitem();
            aStock.sStockName = StockName;
            aStock.iStockLevelReplace = Convert.ToInt32(StocklevelReplace);
            aStock.sStockDescription = StockDesc;
            aStock.iStockLevel = StockLevel;
            aStock.FKiStockLevelTypeID = Convert.ToInt32(StocklevelType);
            if (StockItemID != "") {
                aStock.addEquals(tblStock._PKISTOCKID, Convert.ToInt32(StockItemID));
                aStock.executeUPDATE();
                aStockMenu.addEquals(tblStockpermenuitem._FKISTOCKID, Convert.ToInt32(StockItemID));
                aStockMenu.FKiMenuItem = Convert.ToInt32(MenuItem);
                aStockMenu.executeUPDATE();
            }
            else {
                tblStock newStock = aStock.executeINSERT();
                aStock.PKiStockID = newStock.PKiStockID;
                aStockMenu.FKiMenuItem = Convert.ToInt32(MenuItem);
                aStockMenu.FKiStockID = aStock.PKiStockID;
                aStockMenu.executeINSERT();
            }

        }

        public void UpdateStockLevels(int OrderID, string SubmenuList) {
            Orders aOrder = new Orders();
            DataSet dsItems = aOrder.GetMenuItemsPerOrder(OrderID);
            tblStockpermenuitem aStockMenu = new tblStockpermenuitem();
            tblStock aStock = new tblStock();
            
            foreach (DataRow dr in dsItems.Tables[0].Rows) {
                aStockMenu.addEquals(tblStockpermenuitem._FKIMENUITEM, Convert.ToInt32(dsItems.Tables[0].Rows[0][3].ToString()));
                DataSet dsItemsLinked = aStockMenu.executeSelectDataSet();
                aStock.addEquals(tblStock._PKISTOCKID, Convert.ToInt32(dr[2].ToString()));
                aStock.executeStockSP();
                string[] sAllSubs = dsItems.Tables[0].Rows[0][3].ToString().Split(',');
                foreach (string item in sAllSubs) {
                    try {
                        aStock.addEquals(tblStock._PKISTOCKID, Convert.ToInt32(item));
                        aStock.executeStockSP();
                    }
                    catch { }
                }
            }
        }
    }
}