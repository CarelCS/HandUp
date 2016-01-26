using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HandUpGUI;

namespace HandUpGUI {
    public partial class BarcodeAlert : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string sProvider = Request.QueryString["Provider"];
            string sTable = Request.QueryString["Table"];
            localhost.HandUpService newWS = new localhost.HandUpService();
            string Success = newWS.SendNewTableAlert(sProvider, sTable);
            if (Success == "SENT") {
                lblAlertSent.Text = "An Alert has been sent to all active waiters.";
            }
            else {
                lblAlertSent.Text = "No waiters are active on tables at the moment, please flag one down and get them working.";
            }
        }

        protected void btnGoToLogin_Click(object sender, EventArgs e) {
            Server.Transfer("Default.aspx", false);
        }
    }
}