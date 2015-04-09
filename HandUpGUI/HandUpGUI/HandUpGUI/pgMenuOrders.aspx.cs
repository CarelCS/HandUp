using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HandUpGUI {
    public partial class pgMenuOrders : System.Web.UI.Page {
        public string PKiProviderID;
        protected void Page_Load(object sender, EventArgs e) {
            DataSet ds = new DataSet();
            if ((DataSet)Session["SEmployee"] == null) {
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
                dvTablesTop.InnerHtml = "<table border='1'><tr><td><div id=\"Table1\" onclick=\"OpenTable('1')\">Table 1</div></td><td><div id=\"Table2\" onclick=\"OpenTable('2')\">Table 2</div></td><td><div id=\"Table3\" onclick=\"OpenTable('3')\">Table 3</div></td></tr></table>";
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
                    MenuTotal += "</td><td>" + dr["dblMenuItemPrice"].ToString() + "</td><td><div id=\"" + dr["PKiMenuID"].ToString() + "\" onclick=\"Order('" + dr["PKiMenuID"].ToString() + "')\">ORDER</div></td></tr>";
                    ItemRow++;
                }
            }
            MenuTotal += "</table>";
            string sOrderList = "<table border='1'><tr><td><img id=\"Image1\" src=\"Images/MenuImages/Burger.jpg\" height='50' /></td><td>Hamburger and Chips</td><td><div id=\"order3C\" onclick=\"Order('ORDER3')\">Order</div></td><td><div id=\"order3Ca\" onclick=\"OrderWithCallWaiter('ORDER3')\">Order Call Waiter</div></td></tr>";
            sOrderList += "<tr><td><img id=\"Image2\" src=\"Images/MenuImages/Steak.jpg\" height='50' /></td><td>Steak egg and chips</td><td><div id=\"order4C\" onclick=\"Order('ORDER4')\">Order</div></td><td><div id=\"order4Ca\" onclick=\"OrderWithCallWaiter('ORDER4')\">Order Call Waiter</div></td></tr>";
            sOrderList += "</table>";
            dvMenu.InnerHtml = MenuTotal;
        }

        protected void btnAddTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();

        }

        protected void btnChangeTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();
            string TableValue = hdnTableNumber.Value;
            lblTableOpened.Text = "Table " + TableValue;
            lblTableGUI.Text = "GUI " + TableValue;
            PopulateTable("GUI " + TableValue);
        }

        protected void PopulateTable(string TableGUI) {
            string sOrderList = "<table border='1'><tr><td>Patron 1</td><td>Hamburger and Chips</td><td><div id=\"order3C\" onclick=\"ConfirmOrder('ORDER3')\">CONFIRM</div></td><td><div id=\"order3Ca\" onclick=\"CancelOrder('ORDER3')\">Cancel</div></td><td><div id=\"order3T\" onclick=\"AddTextTable('ORDER3')\">TEXT</div></td></tr>";
            sOrderList += "<tr><td>Patron 2</td><td>Steak egg and chips</td><td><div id=\"order4C\" onclick=\"ConfirmOrder('ORDER4')\">CONFIRM</div></td><td><div id=\"order4Ca\" onclick=\"CancelOrder('ORDER4')\">Cancel</div></td><td><div id=\"order4T\" onclick=\"AddTextTable('ORDER4')\">TEXT</div></td></tr>";
            sOrderList += "</table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        protected void btnAlertUpdate_Click(object sender, EventArgs e) {
            lblAlert.Text = "ALERT";
        }

        protected void btnUpdateTextValues_Click(object sender, EventArgs e) {
            string OrderNumber = hdnOrderNumber.Value;
            string OrderText = hdnTextForOrder.Value;
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e) {
            string OrderValue = hdnOrderSelectValues.Value;
            string[] OrderFull = OrderValue.Split('|');
            string OrderID = OrderFull[0];
            string ChoicesString = OrderFull[1];
        }
    }
}