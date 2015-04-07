using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandUpGUI {
    public partial class pgOrderProcessing : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            PopulateTable("");
        }

        protected void PopulateTable(string ProviderGUI) {
            string sOrderList = "<table border='1'><tr><td>Waiter 1</td><td>Table 1</td><td>Hamburger and Chips</td><td><div id=\"order3C\" onclick=\"ConfirmOrder('ORDER3')\">CONFIRM</div></td><td><div id=\"order3Ca\" onclick=\"CancelOrder('ORDER3')\">Cancel</div></td><td><div id=\"order3T\" onclick=\"AddTextTable('ORDER3')\">TEXT</div></td></tr>";
            sOrderList += "<tr><td>Waiter 2</td><td>Table 2</td><td>Steak egg and chips</td><td><div id=\"order4C\" onclick=\"ConfirmOrder('ORDER4')\">CONFIRM</div></td><td><div id=\"order4Ca\" onclick=\"CancelOrder('ORDER4')\">Cancel</div></td><td><div id=\"order4T\" onclick=\"AddTextTable('ORDER4')\">TEXT</div></td></tr>";
            sOrderList += "</table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        protected void btnUpdateTextValues_Click(object sender, EventArgs e) {
            string OrderNumber = hdnOrderNumber.Value;
            string OrderText = hdnTextForOrder.Value;
        }
    }
}