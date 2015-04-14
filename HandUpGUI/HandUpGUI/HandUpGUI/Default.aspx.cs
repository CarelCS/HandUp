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
        
        protected void btnJoinTable_Click(object sender, EventArgs e) {
            localhost.HandUpService WSnew = new localhost.HandUpService();
            if (txtUserName.Text != "" && txtPassword.Text != "") {
                DataSet ReturnValue = WSnew.Login(txtUserName.Text, txtPassword.Text);
                DataSet TableSet = new DataSet();
                bool IsTable = false;
                if (ReturnValue.Tables[0].Rows.Count != 0) {
                    if (txtTableCode.Text != "") {
                        TableSet = WSnew.JoinTableCode(txtTableCode.Text);
                        if (TableSet.Tables[0].Rows.Count > 0) {
                            Session.Add("sTableCodeActive", TableSet);
                            IsTable = true;
                        }
                        else {
                            IsTable = false;
                        }
                    }
                    Session.Add("SEmployee", ReturnValue);
                    if (ReturnValue.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "3")
                        Server.Transfer("pgOrderProcessing.aspx", false);
                    else {
                        if (ReturnValue.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "4")
                            Server.Transfer("pgManagement.aspx", false);
                        else {
                            if (ReturnValue.Tables[0].Rows[0][12].ToString() == "2"){
                                if (IsTable)
                                    Server.Transfer("pgMenuOrders.aspx", false);
                                else
                                    Server.Transfer("pgPatron.aspx", false);
                            }
                            else
                                Server.Transfer("pgMenuOrders.aspx", false);
                        }
                    }
                }
                else {
                    txtPassword.Text = "";
                    lblLoginFailure.Text = "Login failed. Please try again.";
                }
            }
            else {
                if (txtTableCode.Text != "") {
                    DataSet TableSet = new DataSet();
                    TableSet = WSnew.JoinTableCode(txtTableCode.Text);
                    Session.Add("sTableCodeActive", TableSet);
                    Server.Transfer("pgMenuOrders.aspx", false);
                }
                else { }
            }
        }

        protected void btnSendSize_Click(object sender, EventArgs e) {
            string ScreenH = screenHeight.Value;
            string ScreenW = screenWidth.Value;
        }

        protected void btnRegister_Click(object sender, EventArgs e) {
            Server.Transfer("pgRegistration.aspx", false);
        }
    }
}
