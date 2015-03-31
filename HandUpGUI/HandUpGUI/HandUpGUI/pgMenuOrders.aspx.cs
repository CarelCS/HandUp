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
        }

        protected void btnAddTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();

        }
    }
}