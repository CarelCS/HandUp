using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HandUpGUI {
    public partial class pgPatron : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = new DataSet();
            //ds = WSNew.

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnJoinTable_Click(object sender, EventArgs e) {
            localhost.HandUpService WSnew = new localhost.HandUpService();
            DataSet TableSet = new DataSet();
            TableSet = WSnew.JoinTableCode(txtTableCode.Text);
            Session.Add("sTableCodeActive", TableSet);
            Server.Transfer("pgMenuOrders.aspx", false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeeMenu_Click(object sender, EventArgs e) {

        }
    }
}