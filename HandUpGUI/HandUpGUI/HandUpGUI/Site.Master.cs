using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandUpGUI {
    public partial class SiteMaster : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSendSize_Click(object sender, EventArgs e) {
            string ScreenH = screenHeight.Value;
            string ScreenW = screenWidth.Value;
            try {
                if (Convert.ToInt32(ScreenH) > Convert.ToInt32(ScreenW)) {
                    Session.Add("ScreenWidth", ScreenH);
                }
                else {
                    Session.Add("ScreenWidth", ScreenW);
                }
            }
            catch { Session.Add("ScreenWidth", 800); }
        }

        protected void btnLogout_Click(object sender, EventArgs e) {
            Session.Clear();
            Server.Transfer("Default.aspx", false);
        }
    }
}
