using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace HandUpWCF {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class HandUpService : IHandUpService {
        //string MyConnectionString = "Server=localhost;Database=Handup;Uid=root;Pwd=Password1;";

        public string AddOrder(int MenuItemID, string TextValue) {
            Orders order = new Orders();
            order.AddOrder(MenuItemID, TextValue);
            return string.Format("Order Passed.");
        }

        public string ConfirmOrder(int OrderID, string sStatus) {
            Orders order = new Orders();
            order.ConfirmDenyOrder(OrderID, sStatus);
            return string.Format("ConfirmOrder"); 
        }

        public string DeclineOrder() { return string.Format("DeclineOrder"); }
        public string AddTextToOrder() { return string.Format("AddTextToOrder"); }
        public string AddTable() { return string.Format("AddTable"); }
        public string AddPatronToTable() { return string.Format("AddPatronToTable"); }
        public string CloseTable() { return string.Format("CloseTable"); }
        public string CallWaiter() { return string.Format("CallWaiter"); }
        public string AddEmployee() { return string.Format("AddEmployee"); }
        public string EditEmployee() { return string.Format("EditEmployee"); }
        public string DisableEmployee() { return string.Format("DisableEmployee"); }
        public string GrantDenyAccessEmployee() { return string.Format("GrantDenyAccessEmployee"); }
        public string AddMenuItem() { return string.Format("AddMenuItem"); }
        public string AddSubmenuItem() { return string.Format("AddSubmenuItem"); }
        public string OverrideOrderValue() { return string.Format("OverrideOrderValue"); }
        public string MoveOrderFromTable() { return string.Format("MoveOrderFromTable"); }
        public string ReportsOverView() { return string.Format("ReportsOverView"); }
        public string AddSpecialsList() {

            DataAdapters newAdapter = new DataAdapters();
            DataSet newDs = newAdapter.RetrieveTable("");
            string ThisValue = newDs.Tables[0].Rows[0][1].ToString();
            return string.Format(ThisValue); 
        
        }



        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
