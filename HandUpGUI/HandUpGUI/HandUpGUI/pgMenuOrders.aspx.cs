using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandUpGUI {
    public partial class pgMenuOrders : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblEmployeeUserName.Text = Session["SEmployee"].ToString();
            dvTablesTop.InnerHtml = "<table border='1'><tr><td><div id=\"Table1\" onclick=\"OpenTable('1')\">Table 1</div></td><td><div id=\"Table2\" onclick=\"OpenTable('2')\">Table 2</div></td><td><div id=\"Table3\" onclick=\"OpenTable('3')\">Table 3</div></td></tr></table>";
        }

        protected void btnAddTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();

        }

        protected void btnChangeTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();
            string TableValue = hdnTableNumber.Value;
            lblTableOpened.Text = "Table " + TableValue;
            lblTableGUI.Text = "GUI " + TableValue;
            PopulateTable("GUI " + TableValue);
        }

        protected void PopulateTable(string TableGUI) {
            string sOrderList = "<table border='1'><tr><td>Patron 1</td><td>Hamburger and Chips</td><td><div id=\"order3C\" onclick=\"ConfirmOrder('ORDER3')\">CONFIRM</div></td><td><div id=\"order3Ca\" onclick=\"CancelOrder('ORDER3')\">Cancel</div></td><td><div id=\"order3T\" onclick=\"AddTextTable('ORDER3')\">TEXT</div></td></tr>";
            sOrderList += "<tr><td>Patron 2</td><td>Steak egg and chips</td><td><div id=\"order4C\" onclick=\"ConfirmOrder('ORDER4')\">CONFIRM</div></td><td><div id=\"order4Ca\" onclick=\"CancelOrder('ORDER4')\">Cancel</div></td><td><div id=\"order4T\" onclick=\"AddTextTable('ORDER4')\">TEXT</div></td></tr>";
            sOrderList += "</table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        protected void btnAlertUpdate_Click(object sender, EventArgs e) {
            lblAlert.Text = "ALERT";
        }

        protected void btnUpdateTextValues_Click(object sender, EventArgs e) {
            string OrderNumber = hdnOrderNumber.Value;
            string OrderText = hdnTextForOrder.Value;
        }
    }
}