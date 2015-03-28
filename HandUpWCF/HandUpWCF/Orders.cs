using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandUpWCF {
    public class Orders {
        public void AddOrder(int MenuItemID, string OrderText) {
            string SqlText = "insert into tblOrders () values (" + MenuItemID + ", '" + OrderText + "')";
            DataAdapters da = new DataAdapters();
            da.InsertUpdateData(SqlText);
        }

        public void ConfirmDenyOrder(int OrderID, string sStatus) {
            string SqlText = "update tblOrders set sOrderStatus = '" + sStatus + "' where PKiOrderID = '" + OrderID + "')";
            DataAdapters da = new DataAdapters();
            da.InsertUpdateData(SqlText);
        }
    }
}