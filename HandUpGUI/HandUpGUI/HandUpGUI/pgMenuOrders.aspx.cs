﻿using System;
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
                if (hdnTableNumber.Value == "") 
                {
                    hdnTableNumber.Value = "1";
                    Table tbl = new Table();
                    string TableValue = hdnTableNumber.Value;
                    lblTableOpened.Text = "Table " + TableValue;
                    lblTableGUI.Text = "GUI " + TableValue;
                    PopulateTable("GUI " + TableValue);
                }
                dsTables = WSNew.ActiveTablesForWaiter(Convert.ToInt32(ds.Tables[0].Rows[0]["PKiEmployeeID"].ToString()), true);
                if (dsTables.Tables.Count > 0) {
                    string sTablesDisplay = "<table border='1'><tr>";
                    foreach (DataRow dr in dsTables.Tables[0].Rows) {
                        sTablesDisplay += "<td><div style=\"cursor:pointer;\" id=\"Table" + dr["PKiTableID"].ToString() + "\" onclick=\"OpenTable('" + dr["PKiTableID"].ToString() + "')\">" + dr["PKiTableID"].ToString() + "</div></td>";
                    }
                    sTablesDisplay += "</tr></table>";
                    dvTablesTop.InnerHtml = sTablesDisplay;
                }
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
            string sOrderList = "<table border='1'>";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                sOrderList += "<tr><td>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"ConfirmOrder('" + dr["PKiOrderID"].ToString() + "')\">CONFIRM</div></td><td><div style=\"cursor:pointer;\" id=\"order3Ca\" onclick=\"CancelOrder('" + dr["PKiOrderID"].ToString() + "')\">Cancel</div></td><td><div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"AddTextTable('" + dr["PKiOrderID"].ToString() + "')\">TEXT</div></td></tr>";
            }
            sOrderList += "</table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        protected void PopulateNewOrderForTable(DataSet ds) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string sOrderList = "<table border='1'>";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                sOrderList += "<tr><td>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"ConfirmOrder('" + dr["PKiOrderID"].ToString() + "')\">CONFIRM</div></td><td><div style=\"cursor:pointer;\" id=\"order3Ca\" onclick=\"CancelOrder('" + dr["PKiOrderID"].ToString() + "')\">Cancel</div></td><td><div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"AddTextTable('" + dr["PKiOrderID"].ToString() + "')\">TEXT</div></td></tr>";
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
            PopulateNewOrderForTable(WSNew.AddTextToOrder(Convert.ToInt32(OrderNumber), true, OrderText));
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