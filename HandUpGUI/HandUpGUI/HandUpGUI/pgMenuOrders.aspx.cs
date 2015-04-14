using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace HandUpGUI {
    public partial class pgMenuOrders : System.Web.UI.Page {
        public string PKiProviderID;
        protected void Page_Load(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = new DataSet();
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            if (dsE.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "2") {
                if ((DataSet)Session["sTableCodeActive"] != null) {
                    //a guest with table code only
                    ds = (DataSet)Session["sTableCodeActive"];
                    hdnTableCodeOnlyGuest.Value = ds.Tables[0].Rows[0]["UIDGenerated"].ToString();
                    PKiProviderID = ds.Tables[0].Rows[0]["FKiProviderID"].ToString();
                    PopulateTable(ds.Tables[0].Rows[0]["UIDGenerated"].ToString());
                }
            }
            else {
                ds = (DataSet)Session["SEmployee"];
                PKiProviderID = ds.Tables[0].Rows[0]["FKiProviderID"].ToString();
                lblEmployeeUserName.Text = ds.Tables[0].Rows[0]["sEmployeeName"].ToString();
                DataSet dsTables = new DataSet();
                dsTables = WSNew.ActiveTablesForWaiter(Convert.ToInt32(ds.Tables[0].Rows[0]["PKiEmployeeID"].ToString()), true);
                dvTablesTop.InnerHtml = "<table border='1'><tr><td><div style=\"cursor:pointer;\" id=\"Table1\" onclick=\"OpenTable('1')\">Table 1</div></td><td><div style=\"cursor:pointer;\" id=\"Table2\" onclick=\"OpenTable('2')\">Table 2</div></td><td><div style=\"cursor:pointer;\" id=\"Table3\" onclick=\"OpenTable('3')\">Table 3</div></td></tr></table>";
            }
            PopulateMenu();
        }

        protected void PopulateMenu() {
            DataSet ds = new DataSet();
            localhost.HandUpService WSNew = new localhost.HandUpService();
            ds = WSNew.MenuForProvider(PKiProviderID);
            string MenuTotal = "<table border='1'>";
            string CurrentMenuID = "";
            int ItemRow = 0;
            hdnMaxSubs.Value = (ds.Tables.Count - 1).ToString();
            foreach (DataRow dr in ds.Tables[0].Rows) {
                if (dr["FKiMenuID"].ToString() == "")
                {
                    MenuTotal += "<tr><td><img id=\"Image1\" src=\"" + dr["imgMenuItemImage"].ToString() + "\" height='50' /></td><td>" + dr["sMenuItemName"].ToString() + "</td><td>" + dr["sMenuItemDescription"].ToString();
                    CurrentMenuID = dr["PKiMenuID"].ToString();
                    bool FirstDone = false;
                    foreach(DataTable dt in ds.Tables) {
                        int ItemColumn = 0;
                        if (FirstDone)
                        {
                            string MenuTotalSUB = "<select name=\"" + CurrentMenuID + "_ddlFirstSub_" + ItemColumn + "\" id=\"" + CurrentMenuID + "_ddlFirstSub_" + ItemColumn + "\">";
                            MenuTotalSUB += "<option value='1'>--</option>";
                            bool IsItem = false;
                            foreach(DataRow drInner in dt.Rows)
                            {
                                if (drInner["FKiMenuID"].ToString() == CurrentMenuID)
                                {
                                    MenuTotalSUB += "<option value=\"" + drInner["sMenuItemName"].ToString() + "\">" + drInner["sMenuItemName"].ToString() + "</option>";
                                    IsItem = true;
                                }
                            }
                            MenuTotalSUB += "</select>";
                            if (IsItem) {
                                MenuTotal += MenuTotalSUB;
                            }

                        }
                        FirstDone = true;
                        ItemColumn++;
                    }
                    MenuTotal += "</td><td>" + dr["dblMenuItemPrice"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"" + dr["PKiMenuID"].ToString() + "\" onclick=\"Order('" + dr["PKiMenuID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/order_now.png\" height='50' /></div></td></tr>";
                    ItemRow++;
                }
            }
            MenuTotal += "</table>";
            dvMenu.InnerHtml = MenuTotal;
        }


        public static string GetUniqueKey(int maxSize) {
            char[] chars = new char[35];
            chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data) {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }

        protected void btnAddTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();
            string UITable = "";
            UITable = PKiProviderID + GetUniqueKey(3) + DateTime.Now.Month + DateTime.Now.Day;
        }

        protected void btnChangeTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();
            string TableValue = hdnTableNumber.Value;
            lblTableOpened.Text = "Table " + TableValue;
            lblTableGUI.Text = "GUI " + TableValue;
            PopulateTable("GUI " + TableValue);
        }

        protected void PopulateTable(string TableGUI) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.OrdersPerTable(Convert.ToInt32(hdnTableNumber.Value), true);
            string sOrderList = "<table border='1'><tr><td>Patron 1</td><td>Hamburger and Chips</td><td><div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"ConfirmOrder('ORDER3')\">CONFIRM</div></td><td><div style=\"cursor:pointer;\" id=\"order3Ca\" onclick=\"CancelOrder('ORDER3')\">Cancel</div></td><td><div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"AddTextTable('ORDER3')\">TEXT</div></td></tr>";
            sOrderList += "<tr><td>Patron 2</td><td>Steak egg and chips</td><td><div style=\"cursor:pointer;\" id=\"order4C\" onclick=\"ConfirmOrder('ORDER4')\">CONFIRM</div></td><td><div style=\"cursor:pointer;\" id=\"order4Ca\" onclick=\"CancelOrder('ORDER4')\">Cancel</div></td><td><div style=\"cursor:pointer;\" id=\"order4T\" onclick=\"AddTextTable('ORDER4')\">TEXT</div></td></tr>";
            sOrderList += "</table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        protected void PopulateNewOrderForTable(DataSet ds) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string sOrderList = "<table border='1'>";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                sOrderList += "<tr><td>" + dr["sMenuItemDescription"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"ConfirmOrder('ORDER3')\">CONFIRM</div></td><td><div style=\"cursor:pointer;\" id=\"order3Ca\" onclick=\"CancelOrder('ORDER3')\">Cancel</div></td><td><div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"AddTextTable('ORDER3')\">TEXT</div></td></tr>";
            }
            sOrderList += "</table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        protected void btnAlertUpdate_Click(object sender, EventArgs e) {
            lblAlert.Text = "ALERT";
        }

        protected void btnUpdateTextValues_Click(object sender, EventArgs e) {
            string OrderNumber = hdnOrderNumber.Value;
            string OrderText = hdnTextForOrder.Value;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string Success = WSNew.AddTextToOrder(Convert.ToInt32(OrderNumber), true, OrderNumber);
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e) {
            string OrderValue = hdnOrderSelectValues.Value;
            string[] OrderFull = OrderValue.Split('|');
            string OrderID = OrderFull[0];
            string ChoicesString = OrderFull[1];
            localhost.HandUpService WSNew = new localhost.HandUpService();
            PopulateNewOrderForTable(WSNew.AddOrder(Convert.ToInt32(OrderID), true, Convert.ToInt32(hdnTableNumber.Value), true, ChoicesString));
        }

        protected void btnUpdateOrderStatus_Click(object sender, EventArgs e) {
            string OrderID = hdnOrderNumber.Value;
            string OrderStatus = hdnOrderStatus.Value;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string Success = WSNew.ConfirmOrder(Convert.ToInt32(OrderID), true, OrderStatus);
        }
    }
}