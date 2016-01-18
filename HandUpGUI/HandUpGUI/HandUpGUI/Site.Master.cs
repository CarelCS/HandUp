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
                Session.Add("ScreenWidth", ScreenW);
                if (Convert.ToInt32(ScreenH) > Convert.ToInt32(ScreenW)) {
                }
                else {
                }
            }
            catch { Session.Add("ScreenWidth", 800); }
        }
    }
}
