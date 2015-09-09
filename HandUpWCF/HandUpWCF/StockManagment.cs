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
            DataSet dsStock = aStock.executeCustomSQLDataSet("SELECT distinct " +
                                                                " PKiStockID, " +
                                                                " sStockitemName, " +
                                                                " sStockDescription, " +
                                                                " iStockReplace, " +
                                                                " iStockLevel, " +
                                                                " FKiStockLevelType, " +
                                                                " tblStockLevelTypeDescription, " +
                                                                " sMenuItemName, " +
                                                                " sMenuItemDescription, " +
                                                                " iStockReplace, " +
                                                                " tblmenu.PKiMenuID, " +
                                                                " tbllusubmenus.sSubMenuName, " +
                                                                " tbllusubmenus.PKiSubMenuID, " +
                                                                " iQuantity " +
                                                                " FROM tblStockItem " +
                                                                "  join tblStockLevelType on tblstockitem.FKiStockLevelType=tblstockleveltype.PKistockleveltypeID " +
                                                                "  join tblstock on tblstock.fkistockitem = tblstockitem.pkistockitemid " +
                                                                " join tblstockpermenuitem on tblstockpermenuitem.FKiStockID=tblstock.PKiStockID " +
                                                                " join tblmenu on tblmenu.PKiMenuID=tblstockpermenuitem.FKiMenuItem " +
                                                                " left join tbllusubmenus on tbllusubmenus.FKiMenuID=tblmenu.PKiMenuID  " +
                                                                " 	and tbllusubmenus.PKiSubMenuID=tblstockpermenuitem.FKiSubmenuItem " +
                                                                " where tblmenu.FKiProviderID=" + providerID);
            return dsStock;
        }

        public void StockAdd(int StockID, double StockAddValue) {
            tblStock aStock = new tblStock();
            DataSet dsStock = aStock.executeCustomSQLDataSet("UPDATE tblStockItem " +
                                                            " SET iStockLevel = iStockLevel + " + StockAddValue +
                                                            " where tblstockItem.PKiStockItemID=" + StockID);
        }

        public void StockDeduct(int StockID, double StockAddValue) {
            tblStock aStock = new tblStock();
            DataSet dsStock = aStock.executeCustomSQLDataSet("UPDATE tblStockItem " +
                                                            " SET iStockLevel = iStockLevel - " + StockAddValue +
                                                            " where tblstockitem.PKiStockitemID=" + StockID);
        }

        public DataSet StockItem(int StockID) {
            tblStock aStock = new tblStock();
            DataSet dsStock = aStock.executeCustomSQLDataSet("SELECT distinct PKiStockID, " +
                                                                " sStockItemName, " +
                                                                " sStockDescription, " +
                                                                " iStockReplace, " +
                                                                " iStockLevel, " +
                                                                " FKiStockLevelType, " +
                                                                " tblStockLevelTypeDescription, " +
                                                                " sMenuItemName, " +
                                                                " sMenuItemDescription, " +
                                                                " iStockReplace, " +
                                                                " tblmenu.PKiMenuID " +
                                                                " FROM tblStockitem " +
                                                                " join tblstock on tblstock.FKiStockItem=tblstockitem.pkistockitemid " +
                                                                "  join tblStockLevelType on tblstockitem.FKiStockLevelType=tblstockleveltype.PKistockleveltypeID " +
                                                                " join tblstockpermenuitem on tblstockpermenuitem.FKiStockID=tblstock.PKiStockID " +
                                                                " join tblmenu on tblmenu.PKiMenuID=tblstockpermenuitem.FKiMenuItem " +
                                                                " where tblstock.PKiStockID=" + StockID);
            return dsStock;
        }

        public DataSet StockTypeList() {
            tblStockleveltype aStockLevel = new tblStockleveltype();
            aStockLevel.addGreaterThan(tblStockleveltype._PKISTOCKLEVELTYPEID, 0);
            return aStockLevel.executeSelectDataSet();
        }

        public void UpdateStockItem(string StockItemID, string StockName, string StockDesc, string MenuItem, string SubmenuItem, string ReduceAmount) {
            tblStock aStock = new tblStock();
            tblStockpermenuitem aStockMenu = new tblStockpermenuitem();            
            aStock.sStockDescription = StockDesc;
            aStock.iQuantity = Convert.ToInt32(ReduceAmount);
            if (StockItemID != "") {
                aStock.addEquals(tblStock._PKISTOCKID, Convert.ToInt32(StockItemID));
                aStock.executeUPDATE();
                aStockMenu.addEquals(tblStockpermenuitem._FKISTOCKID, Convert.ToInt32(StockItemID));
                aStockMenu.FKiMenuItem = Convert.ToInt32(MenuItem);
                aStockMenu.FKiSubmenuItem = Convert.ToInt32(SubmenuItem);
                aStockMenu.executeUPDATE();
            }
            else {
                tblStock newStock = aStock.executeINSERT();
                aStock.PKiStockID = newStock.PKiStockID;
                aStockMenu.FKiMenuItem = Convert.ToInt32(MenuItem);
                aStockMenu.FKiSubmenuItem = Convert.ToInt32(SubmenuItem);
                aStockMenu.FKiStockID = aStock.PKiStockID;
                aStockMenu.executeINSERT();
            }

        }

        public void UpdateStockLevels(int OrderID, string SubmenuList) {
            Orders aOrder = new Orders();
            DataSet dsItems = aOrder.GetMenuItemsPerOrder(OrderID);
            tblStockpermenuitem aStockMenu = new tblStockpermenuitem();
            tblStock aStock = new tblStock();
            tblStockitem aStockItem = new tblStockitem();
            
            foreach (DataRow dr in dsItems.Tables[0].Rows) {
                try {
                    aStockMenu.addEquals(tblStockpermenuitem._FKIMENUITEM, Convert.ToInt32(dr[3].ToString()));
                    aStockMenu.addAND();
                    aStockMenu.addEquals(tblStockpermenuitem._FKISUBMENUITEM, 0);
                    DataSet dsItemsLinked = aStockMenu.executeSelectDataSet();
                    aStock.addEquals(tblStock._PKISTOCKID, Convert.ToInt32(dsItemsLinked.Tables[0].Rows[0][2].ToString()));
                    DataSet dsStockItem = aStock.executeSelectDataSet();
                    aStockItem.executeUPDATESTOCKLEVEL(Convert.ToInt32(dsStockItem.Tables[0].Rows[0][1].ToString()), Convert.ToInt32(dsItemsLinked.Tables[0].Rows[0][3].ToString()));
                    string[] sAllSubs = dsItems.Tables[0].Rows[0][3].ToString().Split(',');
                    foreach (string item in sAllSubs) {
                        try {
                            aStockMenu.addEquals(tblStockpermenuitem._FKIMENUITEM, Convert.ToInt32(dsItems.Tables[0].Rows[0][3].ToString()));
                            aStockMenu.addAND();
                            aStockMenu.addEquals(tblStockpermenuitem._FKISUBMENUITEM, Convert.ToInt32(item));
                            dsItemsLinked = aStockMenu.executeSelectDataSet();
                            aStock.addEquals(tblStock._PKISTOCKID, Convert.ToInt32(dsItemsLinked.Tables[0].Rows[0][2].ToString()));
                            dsStockItem = aStock.executeSelectDataSet();
                            aStockItem.executeUPDATESTOCKLEVEL(Convert.ToInt32(dsStockItem.Tables[0].Rows[0][1].ToString()), Convert.ToInt32(dsItemsLinked.Tables[0].Rows[0][3].ToString()));
                        }
                        catch { }
                    }
                }
                catch (Exception ex) { }
            }
        }

        public DataSet getStockItemsPerProvider(int ProviderID) {
            tblStockitem aStockItem = new tblStockitem();
            aStockItem.addEquals(tblStockitem._FKIPROVIDERID, ProviderID);
            return aStockItem.executeSelectDataSet();
        }
    }
}