﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandupRESTWCF.DBClasses;

namespace HandupRESTWCF {
    public class Orders {
        public DataSet AddOrder( int MenuItemID, int TableID, string TextValue, string SubmenuList) {
            tblOrders aOrder = new tblOrders();
            tblMenu aMenuItem=new tblMenu(MenuItemID);
            aOrder.dblOrderValue = aMenuItem.dblMenuItemPrice;
            aOrder.dtOrderDateStamp = DateTime.Now;
            aOrder.FKiMenuGroupID = aMenuItem.FKiMenuGroupID;
            aOrder.FKiMenuID = aMenuItem.PKiMenuID;
            aOrder.FKiPatronID = 0;
            aOrder.FKiProviderID = aMenuItem.FKiProviderID;
            aOrder.FKiTableID = TableID;
            aOrder.iBillID = 0;
            aOrder.sMenuItemChanges = TextValue;
            aOrder.sOrderStatus = "1";
            aOrder.sSubmenuList = SubmenuList;
            aOrder.executeINSERT();
            
            Orders clsOrders=new Orders();
            DataSet aDataSet = clsOrders.OrdersPerTable(TableID);
            
            //string SqlText = "insert into tblOrders () values (" + MenuItemID + ", '" + OrderText + "')";
            ///DataAdapters da = new DataAdapters();
            //da.InsertUpdateData(SqlText);
            return aDataSet;
        }

        public void ConfirmDenyOrder(int OrderID, string sStatus) {
            tblOrders aOrder = new tblOrders(OrderID);
            aOrder.sOrderStatus = sStatus;
            aOrder.executeUPDATE();
            if (sStatus == "3") {
                StockManagment sStock = new StockManagment();
                sStock.UpdateStockLevels(OrderID, aOrder.sSubmenuList);
            }
        }

        public DataSet OrdersPerTable(int TableID) {
            tblTables aTable = new tblTables(TableID);
            tblOrders aOrder=new tblOrders();
            aOrder.addEquals(tblOrders._FKITABLEID,TableID);
            DataSet aDataSet = aOrder.executeSelectDataSet();
            aDataSet.Tables[0].Columns.Add(tblMenu._SMENUITEMDESCRIPTION);
            aDataSet.Tables[0].Columns.Add(tblMenu._SMENUITEMNAME);

            Dictionary<int, tblMenu> dicMenu = new Dictionary<int, tblMenu>();
            foreach (DataRow aMenuItemRow in aDataSet.Tables[0].Rows) {
                int iPKMenuID=Convert.ToInt32(aMenuItemRow[tblOrders._FKIMENUID]);
                tblMenu aMenuItem;
                if (dicMenu.ContainsKey(iPKMenuID)) {
                    aMenuItem = dicMenu[iPKMenuID];
                }
                else {
                    aMenuItem = new tblMenu((int)aMenuItemRow[tblOrders._FKIMENUID]);
                    dicMenu.Add(aMenuItem.PKiMenuID, aMenuItem);
                }
                aMenuItemRow[tblMenu._SMENUITEMDESCRIPTION] = aMenuItem.sMenuItemDescription;
                aMenuItemRow[tblMenu._SMENUITEMNAME] = aMenuItem.sMenuItemName;
            }
            return aDataSet;
        }

        public DataSet AddTextToOrder(int OrderID, string TextValue) {
            tblOrders aOrder = new tblOrders(OrderID);
            aOrder.sMenuItemChanges = aOrder.sMenuItemChanges + "<br /> "+TextValue;
            aOrder.executeUPDATE();
            return OrdersPerTable(aOrder.FKiTableID);
        }

        /// <summary>
        /// Waiter
        /// </summary>
        /// <param name="TableID"></param>
        /// <returns></returns>
        public DataSet OrdersPerActiveTables(int TableID) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        /// <summary>
        /// Processor
        /// </summary>
        /// <param name="ProcessorID"></param>
        /// <returns></returns>
        public DataSet OrdersForActiveTablesPerProcessor(int ProcessorID) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        /// <summary>
        /// Provider
        /// </summary>
        /// <param name="ProviderId"></param>
        /// <param name="dtFromDateTime"></param>
        /// <returns></returns>
        public DataSet AllOrdersForProviderTables(int ProviderId, DateTime dtFromDateTime) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        /// <summary>
        /// Provider
        /// </summary>
        /// <param name="ProviderId"></param>
        /// <param name="StatusID"></param>
        /// <param name="dtFromDateTime"></param>
        /// <returns></returns>
        public DataSet AllOrdersForProviderTablesPerStatus(int ProviderId,  DateTime dtFromDateTime,int StatusID) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public DataSet AllOrdersByProviderTableByTableId(int ProverId, int TablesID) {
            DataSet aDataSet = new DataSet();
            return aDataSet;
        }

        public DataSet GetMenuItemsPerOrder(int OrderID) {
            DataSet dDataSet = new DataSet();

            tblOrders aOrder = new tblOrders(OrderID);
            //aOrder.addEquals(tblOrders._PKIORDERID, OrderID);
            dDataSet = aOrder.executeSelectDataSet();
            return dDataSet;
        }
    }
}