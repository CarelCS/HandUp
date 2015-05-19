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
        public string PKiEmployeeID;
        public string PKiEmployeeTypeID;
        public string ScreenWidth;
        int IconWidth;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            try {
                ScreenWidth = Session["ScreenWidth"].ToString();
                IconWidth = Convert.ToInt32(ScreenWidth) / 20;
                imgAll.Width = Convert.ToInt32(ScreenWidth) / 6;
                imgHide.Width = Convert.ToInt32(ScreenWidth) / 6;
                imgMenu.Width = Convert.ToInt32(ScreenWidth) / 6;
                imgOrders.Width = Convert.ToInt32(ScreenWidth) / 6;
                imgCallWaiter.Width = Convert.ToInt32(ScreenWidth) / 6;
                imgCloseBill.Width = Convert.ToInt32(ScreenWidth) / 6;
                imgCloseTable.Width = Convert.ToInt32(ScreenWidth) / 6; 
                localhost.HandUpService WSNew = new localhost.HandUpService();
                DataSet dsAdds = new DataSet();
                //dsAdds = WSNew.
                DataSet ds = new DataSet();
                DataSet dsE = new DataSet();
                dsE = (DataSet)Session["SEmployee"];
                PKiEmployeeID = dsE.Tables[0].Rows[0]["PKiEmployeeID"].ToString();
                PKiEmployeeTypeID = dsE.Tables[0].Rows[0]["FKiEmployeeType"].ToString();
                if (dsE.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "2") {
                    if ((DataSet)Session["sTableCodeActive"] != null) {
                        //a guest with table code only
                        ds = (DataSet)Session["sTableCodeActive"];
                        hdnTableCodeOnlyGuest.Value = ds.Tables[0].Rows[0]["UIDGenerated"].ToString();
                        PKiProviderID = ds.Tables[0].Rows[0]["FKiProviderID"].ToString();
                        hdnTableNumber.Value = ds.Tables[0].Rows[0]["PKiTableID"].ToString();
                        lblTableGUI.Text = "GUI : " + ds.Tables[0].Rows[0]["UIDGenerated"].ToString();
                        lblWaiterName.Text = "Carel";
                        dvWaiterImage.InnerHtml = "<img id=\"Image1\" src=\"images/EmployeeImages/Carelwaiter.jpg\"  width='" + IconWidth * 2 + "'/>";
                        PopulateTable(ds.Tables[0].Rows[0]["UIDGenerated"].ToString());
                        dvCloseTable.Visible = false;
                    }
                }
                else {
                    dvCallWaiter.Visible = false;
                    dvCloseBill.Visible = false;
                    ds = (DataSet)Session["SEmployee"];
                    PKiProviderID = ds.Tables[0].Rows[0]["FKiProviderID"].ToString();
                    lblEmployeeUserName.Text = ds.Tables[0].Rows[0]["sEmployeeName"].ToString();
                    DataSet dsTables = new DataSet();
                    dsTables = WSNew.ActiveTablesForWaiter(Convert.ToInt32(ds.Tables[0].Rows[0]["PKiEmployeeID"].ToString()), true);
                    if (dsTables.Tables.Count > 0) {
                        string sTablesDisplay = "<table border='0' width=\"100%\"><tr>";
                        foreach (DataRow dr in dsTables.Tables[0].Rows) {
                            if (hdnTableNumber.Value == "") 
                            {
                                hdnTableNumber.Value = dr["PKiTableID"].ToString();
                                lblTableOpened.Text = dr["sTableName"].ToString();
                                lblTableGUI.Text = "GUI : " + dr["UIDGenerated"].ToString();
                                lblWaiterName.Text = "Carel";
                                dvWaiterImage.InnerHtml = "<img id=\"Image1\" src=\"images/EmployeeImages/Carelwaiter.jpg\"  width='" + IconWidth * 2 + "'/>";
                                PopulateTable(dr["sTableName"].ToString());
                            }
                            sTablesDisplay += "<td><table cellpadding=\"0\" cellspacing=\"0\"><tr><td><img id=\"Image1\" src=\"images/Icons/TopLeft.png\"  width='" + IconWidth / 2 + "'/></td><td valign=\"top\"><img id=\"Image1\" src=\"images/Icons/BorderBlock.png\"  width='100%' height='4.5px'/></td><td><img id=\"Image1\" src=\"images/Icons/TopRight.png\"  width='" + IconWidth / 2 + "'/></td></tr><tr><td align=\"left\"><img id=\"Image1\" src=\"images/Icons/BorderBlock.png\"  width='4.5px' height='100%'/></td><td align=\"center\"><div style='cursor:pointer; color:White; font-weight:bolder; font-family:Arial' id=\"Table" + dr["PKiTableID"].ToString() + "\" onclick=\"OpenTable('" + dr["PKiTableID"].ToString() + "')\">" + dr["sTableName"].ToString() + "</div></td><td align=\"right\"><img id=\"Image1\" src=\"images/Icons/BorderBlock.png\"  width='4.5px' height='100%'/></td></tr><tr><td><img id=\"Image1\" src=\"images/Icons/BottomLeft.png\"  width='" + IconWidth / 2 + "'/></td><td valign=\"bottom\"><img id=\"Image1\" src=\"images/Icons/BorderBlock.png\"  width='100%' height='4.5px'/></td><td><img id=\"Image1\" src=\"images/Icons/BottomRight.png\"  width='" + IconWidth / 2 + "'/></td></tr></table></td>";
                        }
                        sTablesDisplay += "</tr></table>";
                        dvTablesTop.InnerHtml = sTablesDisplay;
                    }
                }
                if (!IsPostBack) {
                    PopulateMenu();
                    if (PKiEmployeeTypeID == "2") {
                        Advertisement();
                    }
                }
            }
            catch { PKiEmployeeID = "0"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void Advertisement() {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.AllAdvertsAvailableForProvider(Convert.ToInt32(PKiProviderID), true);
            string HTMLString = "<table cellpadding=\"0\" cellspacing=\"0\"><tr>";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                HTMLString += "<td><img id=\"ImageAdv" + dr["PKiAdvertID"].ToString() + "\" src=\"" + dr["imgAdvertImage"].ToString() + "\" onclick=GoToAddSpace(\"" + dr["sAdvertURL"].ToString() + "\") /></td>";
            }
            HTMLString += "</tr></table>";
            dvAddArea.InnerHtml = HTMLString;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void PopulateMenu() {
            DataSet ds = new DataSet();
            localhost.HandUpService WSNew = new localhost.HandUpService();
            ds = WSNew.MenuForProvider(PKiProviderID);
            string MenuGroupDefault = "";
            string MenuTotal = "";
            string MenuHeaders = "<table width=\"100%\"><tr>";
            string menuHeaderCollection = "";
            foreach (DataRow drGroups in ds.Tables["MenuGroup"].Rows) {
                if (MenuGroupDefault == "")
                    MenuGroupDefault = "dvGroup" + drGroups["PKiMenuGroupID"].ToString();
                menuHeaderCollection += drGroups["PKiMenuGroupID"].ToString() + "|";
                MenuHeaders += "<td><table cellpadding=\"0\" cellspacing=\"0\"><tr><td><img id=\"Image1\" src=\"images/Icons/TopLeft.png\"  width='" + IconWidth / 2 + "'/></td><td valign=\"top\"><img id=\"Image1\" src=\"images/Icons/BorderBlock.png\"  width='100%' height='4.5px'/></td><td><img id=\"Image1\" src=\"images/Icons/TopRight.png\"  width='" + IconWidth / 2 + "'/></td></tr><tr><td align=\"left\"><img id=\"Image1\" src=\"images/Icons/BorderBlock.png\"  width='4.5px' height='100%'/></td><td align=\"center\"><div style='cursor:pointer; color:White; font-weight:bolder; font-family:Arial' id=" + drGroups["PKiMenuGroupID"].ToString() + "Click onclick=ChangemenuArea(\"dvGroup" + drGroups["PKiMenuGroupID"].ToString() + "\")>" + drGroups["sMenuGroupName"].ToString() + "</div></td><td align=\"right\"><img id=\"Image1\" src=\"images/Icons/BorderBlock.png\"  width='4.5px' height='100%'/></td></tr><tr><td><img id=\"Image1\" src=\"images/Icons/BottomLeft.png\"  width='" + IconWidth / 2 + "'/></td><td valign=\"bottom\"><img id=\"Image1\" src=\"images/Icons/BorderBlock.png\"  width='100%' height='4.5px'/></td><td><img id=\"Image1\" src=\"images/Icons/BottomRight.png\"  width='" + IconWidth / 2 + "'/></td></tr></table></td>";
                MenuTotal += "<div id=\"dvGroup" + drGroups["PKiMenuGroupID"].ToString() + "\"><table border='1'  width=\"100%\">";
                string CurrentMenuID = "";
                int ItemRow = 0;
                hdnMaxSubs.Value = (ds.Tables.Count - 1).ToString();
                foreach (DataRow dr in ds.Tables[0].Rows) 
                {
                    if (dr["FKiMenuID"].ToString() == "" && dr["FKiMenuGroupID"].ToString() == drGroups["PKiMenuGroupID"].ToString()) 
                    {
                        MenuTotal += "<tr><td><img id=\"MenuImage " + dr["FKiMenuID"].ToString() + "\" src=\"" + dr["imgMenuItemImage"].ToString() + "\" height='50' /></td><td>" + dr["sMenuItemName"].ToString() + "</td><td width='100%'>" + dr["sMenuItemDescription"].ToString();
                        CurrentMenuID = dr["PKiMenuID"].ToString();
                        int ItemColumn = 0;
                        foreach (DataTable dt in ds.Tables) {
                            if (dt.TableName != "Menu" && dt.TableName != "MenuGroup") {
                                string MenuTotalSUB = "<select name=\"" + CurrentMenuID + "_ddlFirstSub_" + ItemColumn + "\" id=\"" + CurrentMenuID + "_ddlFirstSub_" + ItemColumn + "\">";
                                ItemColumn++; 
                                MenuTotalSUB += "<option value='1'>--</option>";
                                bool IsItem = false;
                                foreach (DataRow drInner in dt.Rows) {
                                    if (drInner["FKiMenuID"].ToString() == CurrentMenuID) {
                                        MenuTotalSUB += "<option value=\"" + drInner["sSubMenuName"].ToString() + "\">" + drInner["sSubMenuName"].ToString() + "</option>";
                                        IsItem = true;
                                    }
                                }
                                MenuTotalSUB += "</select>";
                                if (IsItem) {
                                    MenuTotal += MenuTotalSUB;
                                }

                            }
                        }
                        MenuTotal += "</td><td>" + dr["dblMenuItemPrice"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"" + dr["PKiMenuID"].ToString() + "\" onclick=\"Order('" + dr["PKiMenuID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/order.png\" width='" + IconWidth + "' /></div></td></tr>";
                        ItemRow++;
                    }
                }
                MenuTotal += "</table></div>";
            }
            if (!IsPostBack)
                ClientScript.RegisterStartupScript(GetType(), "id", "ChangemenuArea('" + MenuGroupDefault + "')", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "id", "ChangemenuArea('" + hdnGroupCurrent.Value + "')", true);
            MenuHeaders += "</tr></table>";
            dvMenuGroup.InnerHtml = MenuHeaders;
            hdnGroupHeaders.Value = menuHeaderCollection;
            dvMenuMain.InnerHtml = MenuTotal;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public static string GetUniqueKey(int maxSize) {
            char[] chars = new char[35];
            chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();
            string UITable = "";
            UITable = PKiProviderID + GetUniqueKey(3) + DateTime.Now.Month + DateTime.Now.Day;

            localhost.HandUpService WSNew = new localhost.HandUpService();
            //WSNew.AddTable(
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChangeTable_Click(object sender, EventArgs e) {
            Table tbl = new Table();
            string TableValue = hdnTableNumber.Value;
            lblTableOpened.Text = "Table " + TableValue;
            lblTableGUI.Text = "GUI " + TableValue;
            lblWaiterName.Text = "Carel";
            dvWaiterImage.InnerHtml = "<img id=\"Image1\" src=\"images/icons/Confirm.png\"  width='" + IconWidth * 2 + "' />";
            PopulateTable("GUI " + TableValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableGUI"></param>
        protected void PopulateTable(string TableGUI) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.OrdersPerTable(Convert.ToInt32(hdnTableNumber.Value), true);
            string sOrderList = "<table border='1' width=\"100%\">";
            string sCapableOption = "";
            string sCanConfirm = "";
            double TotalCost = 0;
             foreach (DataRow dr in ds.Tables[0].Rows) {
                 if (dr["sOrderStatus"].ToString() == "2" || dr["sOrderStatus"].ToString() == "4") {
                     //is confirmed so cannot show cancel or with waiter. So all buttons removed.
                     if (dr["sOrderStatus"].ToString() == "2") {
                         sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3T\"><img id=\"Image1\" src=\"images/icons/Processed.png\"  width='" + IconWidth + "'/></div>";
                     }
                     //else {
                     //    sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3T\"><img id=\"Image1\" src=\"images/icons/Logo-01.png\"  width='" + IconWidth + "'/></div>";
                     //}
                 }
                 else {
                     if (PKiEmployeeTypeID == "2")
                         sCapableOption = "<div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"OrderWithCallWaiter('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Waiter.png\"  width='" + IconWidth + "'/></div>";
                     else {
                         sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"ConfirmOrder('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Confirm.png\"  width='" + IconWidth + "'/></div>";
                         sCapableOption = "<div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"AddTextTable('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Text.png\"  width='" + IconWidth + "'/></div>";
                     }
                 }
                 if (dr["sOrderStatus"].ToString() == "4" || dr["sOrderStatus"].ToString() == "2") {
                     if (dr["sOrderStatus"].ToString() == "4") {
                         //sOrderList += "<tr style=\"text-decoration:line-through\"><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td>R " + dr["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                     }
                     else {
                         sOrderList += "<tr><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td>R " + dr["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                     }
                 }
                 else {
                     sOrderList += "<tr><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td>R " + dr["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td><div style=\"cursor:pointer;\" id=\"order3Ca\" onclick=\"CancelOrder('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Cancel.png\"  width='" + IconWidth + "'/></div></td><td>" + sCapableOption + "</td></tr>";
                 }
                 if (dr["sOrderStatus"].ToString() != "4")
                    TotalCost += Convert.ToDouble(dr["dblOrderValue"].ToString());
             }
             sOrderList += "<tr><td>Bill till now.</td><td>R " + TotalCost + "</td></tr></table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        protected void PopulateNewOrderForTable(DataSet ds) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string sOrderList = "<table border='1' width=\"100%\">";
            string sCapableOption = "";
            string sCanConfirm = "";
            double TotalCost = 0;
            foreach (DataRow dr in ds.Tables[0].Rows) {
                if (dr["sOrderStatus"].ToString() == "2" || dr["sOrderStatus"].ToString() == "4") {
                    //is confirmed so cannot show cancel or with waiter. So all buttons removed.
                    if (dr["sOrderStatus"].ToString() == "2") {
                        sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3T\"><img id=\"Image1\" src=\"images/icons/Processed.png\"  width='" + IconWidth + "'/></div>";
                    }
                    //else {
                    //    sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3T\"><img id=\"Image1\" src=\"images/icons/Logo-01.png\"  width='" + IconWidth + "'/></div>";
                    //}
                }
                else {
                    if (PKiEmployeeTypeID == "2")
                        sCapableOption = "<div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"OrderWithCallWaiter('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Waiter.png\"  width='" + IconWidth + "'/></div>";
                    else {
                        sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"ConfirmOrder('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Confirm.png\"  width='" + IconWidth + "'/></div>";
                        sCapableOption = "<div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"AddTextTable('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Text.png\"  width='" + IconWidth + "'/></div>";
                    }
                }
                if (dr["sOrderStatus"].ToString() == "4" || dr["sOrderStatus"].ToString() == "2") {
                    if (dr["sOrderStatus"].ToString() == "4") {
                        //sOrderList += "<tr style=\"text-decoration:line-through\"><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td>R " + dr["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                    }
                    else {
                        sOrderList += "<tr><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td>R " + dr["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                    }
                }
                else {
                    sOrderList += "<tr><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td>R " + dr["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td><div style=\"cursor:pointer;\" id=\"order3Ca\" onclick=\"CancelOrder('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Cancel.png\"  width='" + IconWidth + "'/></div></td><td>" + sCapableOption + "</td></tr>";
                }
                if (dr["sOrderStatus"].ToString() != "4")
                    TotalCost += Convert.ToDouble(dr["dblOrderValue"].ToString());
             }
             sOrderList += "<tr><td>Bill till now.</td><td>R " + TotalCost + "</td></tr></table>";
             dvTablesOrders.InnerHtml = sOrderList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAlertUpdate_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = new DataSet();
            ds = WSNew.TableAlertPerEmployee(Convert.ToInt32(PKiEmployeeID), true);
            if (ds.Tables[0].Rows.Count > 0) {
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    lblAlert.Text += dr["sTableName"].ToString() + "\n" + dr["sAlertMessage"].ToString() + "|";
                }
            }
        }

        protected void btnUpdateTextValues_Click(object sender, EventArgs e) {
            string OrderNumber = hdnOrderNumber.Value;
            string OrderText = hdnTextForOrder.Value;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            PopulateNewOrderForTable(WSNew.AddTextToOrder(Convert.ToInt32(OrderNumber), true, OrderText));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPlaceOrder_Click(object sender, EventArgs e) {
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            PKiEmployeeID = dsE.Tables[0].Rows[0]["PKiEmployeeID"].ToString();
            string OrderValue = hdnOrderSelectValues.Value;
            string[] OrderFull = OrderValue.Split('|');
            string OrderID = OrderFull[0];
            string ChoicesString = OrderFull[1];
            localhost.HandUpService WSNew = new localhost.HandUpService();
            PopulateNewOrderForTable(WSNew.AddOrder(Convert.ToInt32(OrderID), true, Convert.ToInt32(hdnTableNumber.Value), true, ChoicesString.Replace("~", "<br />")));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateOrderStatus_Click(object sender, EventArgs e) {
            string OrderID = hdnOrderNumber.Value;
            string OrderStatus = hdnOrderStatus.Value;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string Success = WSNew.ConfirmOrder(Convert.ToInt32(OrderID), true, OrderStatus);
            PopulateTable(lblTableGUI.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        protected void AddAdverts() {
        }

        protected void btnUpdateAlertConfirmed_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            WSNew.ConfirmAlert(hdnTextForAlertGUI.Value);
        }

        protected void btnAlertSent_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string Returned = WSNew.CallWaiter(Convert.ToInt32(hdnTableNumber.Value), true, hdnAlertText.Value);
        }
    }
}