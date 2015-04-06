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
            dvTablesTop.InnerHtml = "<table><tr><td><div id=\"Table1\" onclick=\"OpenTable('1')\">Table 1</div></td><td><div id=\"Table2\" onclick=\"OpenTable('2')\">Table 2</div></td><td><div id=\"Table3\" onclick=\"OpenTable('3')\">Table 3</div></td></tr></table>";
        }

        protected void btnAddTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();

        }

        protected void btnChangeTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();
            string TableValue = hdnTableNumber.Value;
            lblTableOpened.Text = "Table " + TableValue;
            lblTableGUI.Text = "GUI " + TableValue;
        }

        protected void btnAlertUpdate_Click(object sender, EventArgs e) {
            lblAlert.Text = "ALERT";
        }
    }
}