using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandUpGUI {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {


        }

        protected void Button1_Click(object sender, EventArgs e) {
            localhost.HandUpService WSnew = new localhost.HandUpService();
            TextBox1.Text = WSnew.AddSpecialsList();
        }
    }
}
