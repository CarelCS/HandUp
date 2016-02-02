using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HandUpGUI {
    public partial class pgOnShiftWaiters : System.Web.UI.Page {
        public string PKiProviderID;
        protected void Page_Load(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            PKiProviderID = dsE.Tables[0].Rows[0]["FKiProviderID"].ToString();
            DataSet ds = new DataSet();
            ds = WSNew.EmployeeListPerProvireAdminFull(Convert.ToInt32(PKiProviderID), true);
            foreach (DataRow dr in ds.Tables[0].Rows) {
                CheckBox chk = new CheckBox();
                chk.Text = dr["sUserName"].ToString();
                chk.ID = "emp" + dr["PKiEmployeeID"].ToString();
                if (dr["PKiEmployeeID"].ToString() == "1"){
                    chk.Checked = true;
                }
                else {
                    chk.Checked = false;
                }
                PlaceHolder1.Controls.Add(chk);
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            localhost.HandUpService NewWS = new localhost.HandUpService();
            foreach (Control control in PlaceHolder1.Controls) {
                string SetChk = "0";
                int EmpID = 0;
                if (control is CheckBox) {
                    CheckBox checkBox = control as CheckBox;
                    if (checkBox.Checked) {
                        SetChk = "1";
                    }
                    else {
                        SetChk = "0";
                    }
                    string Emp = checkBox.ID;
                    EmpID = Convert.ToInt32(Emp.Substring(3));
                    NewWS.updateOnShift(EmpID, true, SetChk);
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e) {

            Server.Transfer("pgManagement.aspx", false);
        }
    }
}