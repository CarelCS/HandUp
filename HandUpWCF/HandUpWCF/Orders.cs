using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;

namespace HandUpWCF {
    public class Orders {
        public void AddOrder(int MenuItemID, string OrderText) {
            string SqlText = "insert into tblOrders () values (" + MenuItemID + ", '" + OrderText + "')";
            DataAdapters da = new DataAdapters();
            da.InsertUpdateData(SqlText);
        }

        public void ConfirmDenyOrder(int OrderID, string sStatus) {
            tblOrders aOrder = new tblOrders(OrderID);
            aOrder.sOrderStatus = sStatus;
            aOrder.executeUPDATE();

            //string SqlText = "update tblOrders set sOrderStatus = '" + sStatus + "' where PKiOrderID = '" + OrderID + "')";
            //DataAdapters da = new DataAdapters();
            //da.InsertUpdateData(SqlText);
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
    }
}