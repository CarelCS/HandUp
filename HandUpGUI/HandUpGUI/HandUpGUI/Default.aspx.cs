using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HandUpGUI {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void Button1_Click(object sender, EventArgs e) {
            localhost.HandUpService WSnew = new localhost.HandUpService();
            DataSet ReturnValue = WSnew.LoginWaiter(txtUserName.Text, txtPassword.Text);
            if (ReturnValue.Tables[0].Rows.Count != 0) {
                Session.Add("SEmployee", ReturnValue);
                if (ReturnValue.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "3")
                    Server.Transfer("pgOrderProcessing.aspx", false);
                else
                    Server.Transfer("pgMenuOrders.aspx", false);
            }
            else {
                txtPassword.Text = "";
                lblLoginFailure.Text = "Login failed. Please try again.";
            }
        }

        protected void btnJoinTable_Click(object sender, EventArgs e) {
            localhost.HandUpService WSnew = new localhost.HandUpService();
            string ReturnValue = WSnew.JoinTableCode(txtTableCode.Text);
        }

        protected void btnSendSize_Click(object sender, EventArgs e) {
            string ScreenH = screenHeight.Value;
            string ScreenW = screenWidth.Value;
        }
    }
}
