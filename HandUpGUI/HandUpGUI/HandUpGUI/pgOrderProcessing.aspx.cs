using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HandUpGUI {
    public partial class pgOrderProcessing : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            if (!IsPostBack) {
                if (dsE.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "3") {
                    PopulateTableProcessor();
                }
                else {
                    PopulateTablesBarKitchen();
                }
            }
        }

        protected void PopulateTablesBarKitchen() {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string ScreenWidth = Session["ScreenWidth"].ToString();
            int IconWidth = Convert.ToInt32(ScreenWidth) / 20;
            DataSet dsE = (DataSet)Session["SEmployee"];
            string ProviderID = dsE.Tables[0].Rows[0]["FKiProviderID"].ToString();
            DataSet ds = WSNew.ActiveTablesForProvider(Convert.ToInt32(ProviderID), true);

            string sOrderList = "<table border='1' width=\"100%\">";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                DataSet dsOrder = WSNew.OrdersPerTable(Convert.ToInt32(dr["PKiTableID"].ToString()), true);
                string sCapableOption = "";
                string sCanConfirm = "";
                foreach (DataRow drOrder in dsOrder.Tables[0].Rows) {
                    if (drOrder["fkiServicestationID"].ToString() == dsE.Tables[0].Rows[0]["FKiServicestaionID"].ToString()) {
                        if (drOrder["sOrderStatus"].ToString() == "2") {
                            sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"AcceptOrder('" + drOrder["PKiOrderID"].ToString() + "')\"><img id=\"Image" + drOrder["PKiOrderID"].ToString() + "\" src=\"images/icons/Accept.png\"  width='" + IconWidth + "'/></div>";
                        }
                        else {
                            if (drOrder["sOrderStatus"].ToString() == "5") {
                                sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"CompleteOrder('" + drOrder["PKiOrderID"].ToString() + "')\"><img id=\"Image" + drOrder["PKiOrderID"].ToString() + "\" src=\"images/icons/Complete.png\"  width='" + IconWidth + "'/></div>";
                            }
                        }
                        if (drOrder["sOrderStatus"].ToString() == "2" || drOrder["sOrderStatus"].ToString() == "5") {
                            sOrderList += "<tr><td>" + dr["sTableName"].ToString() + "</td><td width='100%'>" + drOrder["sMenuItemDescription"].ToString() + drOrder["sMenuItemChanges"].ToString() + "</td><td>R " + drOrder["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                        }
                    }
                }
            }
            sOrderList += "</table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void PopulateTableProcessor() {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            string ScreenWidth = Session["ScreenWidth"].ToString();
            int IconWidth = Convert.ToInt32(ScreenWidth) / 20;
            DataSet dsE = (DataSet)Session["SEmployee"];
            string ProviderID = dsE.Tables[0].Rows[0]["FKiProviderID"].ToString();
            DataSet ds = WSNew.ActiveTablesForProvider(Convert.ToInt32(ProviderID), true);

            string sOrderList = "<table border='1' width=\"100%\">";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                DataSet dsOrder = WSNew.OrdersPerTable(Convert.ToInt32(dr["PKiTableID"].ToString()), true);
                string sCapableOption = "";
                string sCanConfirm = "";
                foreach (DataRow drOrder in dsOrder.Tables[0].Rows){
                    if (drOrder["fkiServicestationID"].ToString() == dsE.Tables[0].Rows[0]["FKiServicestaionID"].ToString()) {
                        if (drOrder["sOrderStatus"].ToString() != "6") {
                            if (drOrder["sOrderStatus"].ToString() == "2" || drOrder["sOrderStatus"].ToString() == "4") {
                                //is confirmed so cannot show cancel or with waiter. So all buttons removed.
                                if (drOrder["sOrderStatus"].ToString() == "2") {
                                    sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order" + drOrder["PKiOrderID"].ToString() + "\" onclick=\"ConfirmProcessed('" + drOrder["PKiOrderID"].ToString() + "')\"><img id=\"Image" + drOrder["PKiOrderID"].ToString() + "\" src=\"images/icons/Processed.png\"  width='" + IconWidth + "'/></div>";
                                }
                                //else {
                                //    sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3T\"><img id=\"Image1\" src=\"images/icons/Logo-01.png\"  width='" + IconWidth + "'/></div>";
                                //}
                            }
                            else {
                                sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order" + drOrder["PKiOrderID"].ToString() + "\" onclick=\"ConfirmOrder('" + drOrder["PKiOrderID"].ToString() + "')\"><img id=\"Image" + drOrder["PKiOrderID"].ToString() + "\" src=\"images/icons/Process.png\"  width='" + IconWidth + "'/></div>";
                                sCapableOption = "<div style=\"cursor:pointer;\" id=\"orderT" + drOrder["PKiOrderID"].ToString() + "\" onclick=\"AddTextTable('" + drOrder["PKiOrderID"].ToString() + "')\"><img id=\"ImageT" + drOrder["PKiOrderID"].ToString() + "\" src=\"images/icons/Text.png\"  width='" + IconWidth + "'/></div>";
                            }
                            if (drOrder["sOrderStatus"].ToString() == "4" || drOrder["sOrderStatus"].ToString() == "2") {
                                if (drOrder["sOrderStatus"].ToString() == "4") {
                                    //sOrderList += "<tr style=\"text-decoration:line-through\"><td>" + dr["sTableName"].ToString() + "</td><td width='100%'>" + drOrder["sMenuItemDescription"].ToString() + drOrder["sMenuItemChanges"].ToString() + "</td><td>R " + drOrder["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                                }
                                else {
                                    sOrderList += "<tr><td>" + dr["sTableName"].ToString() + "</td><td width='100%'>" + drOrder["sMenuItemDescription"].ToString() + drOrder["sMenuItemChanges"].ToString() + "</td><td>R " + drOrder["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                                }
                            }
                            else {
                                sOrderList += "<tr><td>" + dr["sTableName"].ToString() + "</td><td width='100%'>" + drOrder["sMenuItemDescription"].ToString() + drOrder["sMenuItemChanges"].ToString() + "</td><td>R " + drOrder["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td><div style=\"cursor:pointer;\" id=\"orderC" + drOrder["PKiOrderID"].ToString() + "\" onclick=\"CancelOrder('" + drOrder["PKiOrderID"].ToString() + "')\"><img id=\"ImageC" + drOrder["PKiOrderID"].ToString() + "\" src=\"images/icons/Cancel.png\"  width='" + IconWidth + "'/></div></td><td>" + sCapableOption + "</td></tr>";
                            }
                        }
                    }
                }
            }
            sOrderList += "</table>";
            dvTablesOrders.InnerHtml = sOrderList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateTextValues_Click(object sender, EventArgs e) {
            string OrderNumber = hdnOrderNumber.Value;
            string OrderText = hdnTextForOrder.Value;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            WSNew.AddTextToOrder(Convert.ToInt32(OrderNumber), true, OrderText);
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            if (dsE.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "3") {
                PopulateTableProcessor();
            }
            else {
                PopulateTablesBarKitchen();
            }
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
            string TableID = WSNew.TableforOrderID(Convert.ToInt32(OrderID), true);
            string Success = WSNew.ConfirmOrder(Convert.ToInt32(OrderID), true, OrderStatus);
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            if (dsE.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "3") {
                PopulateTableProcessor();
            }
            else {
                PopulateTablesBarKitchen();
            }
            if (OrderStatus == "6") {
                string Returned = WSNew.CallWaiter(Convert.ToInt32(TableID), true, "Processed");
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e) {
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            if (dsE.Tables[0].Rows[0]["FKiEmployeeType"].ToString() == "3") {
                PopulateTableProcessor();
            }
            else {
                PopulateTablesBarKitchen();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e) {
            Session.Clear();
            Server.Transfer("Default.aspx", false);
        }
    }
}