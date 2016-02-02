using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace HandUpGUI {
    public partial class pgStockManagement : System.Web.UI.Page {
        public string PKiProviderID;
        protected void Page_Load(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            PKiProviderID = dsE.Tables[0].Rows[0]["FKiProviderID"].ToString();
            DataSet ds = WSNew.StockTable(Convert.ToInt32(PKiProviderID), true);
            string sStockList = "<table border='1'>";
            sStockList += "<tr><td>Name</td><td>Description</td><td>Stock Level</td><td>Stock Level Type</td><td>Menu Name</td><td>Stock Replace Level</td><td>Submenu Item</td><td>Quantity</td></tr>"; 
            foreach (DataRow dr in ds.Tables[0].Rows) {
                sStockList += "<tr id=tr" + dr[0].ToString() + " onclick='ChangeStock(" + dr[0].ToString() + ")'><td>" + dr[1].ToString() + "</td><td>" + dr[2].ToString() + "</td><td>" + dr[4].ToString() + "</td><td>" + dr[6].ToString() + "</td><td>" + dr[7].ToString() + "</td><td>" + dr[9].ToString() + "</td><td>" + dr[11].ToString() + "</td><td>" + dr[13].ToString() + "</td></tr>"; 
            }
            sStockList += "</table>";
            dvStockList.InnerHtml = sStockList;
            if (!IsPostBack) {
                DataSet dsST = WSNew.StockTypeList();
                ddlStockLevelType.Items.Clear();
                foreach (DataRow dr in dsST.Tables[0].Rows) {
                    ListItem li = new ListItem();
                    li.Text = dr[1].ToString();
                    li.Value = dr[0].ToString();
                    ddlStockLevelType.Items.Add(li);
                }
                DataSet MenuList = WSNew.MenuForProvider(PKiProviderID);
                ddlMenuItem.Items.Clear();
                foreach (DataRow dr in MenuList.Tables[0].Rows) {
                    ListItem li = new ListItem();
                    li.Text = dr[4].ToString();
                    li.Value = dr[0].ToString();
                    ddlMenuItem.Items.Add(li);
                }
                ddlMenuItem_SelectedIndexChanged(sender, e);
                DataSet dsItems = new DataSet();
                dsItems = WSNew.getStockItemsPerProvider(Convert.ToInt32(PKiProviderID), true);
                ddlStockItem.Items.Clear();
                foreach (DataRow dr in dsItems.Tables[0].Rows) {
                    ListItem li = new ListItem();
                    li.Text = dr[1].ToString();
                    li.Value = dr[0].ToString();
                    ddlStockItem.Items.Add(li);
                }

            }
        }

        protected void btnUpdateStockItem_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet dsS = new DataSet();
            DataSet dsST = new DataSet();
            dsS = WSNew.StockItem(Convert.ToInt32(hdnStockNumber.Value), true);
           
            
            DataSet MenuList = WSNew.MenuForProvider(PKiProviderID);
            ddlMenuItem.Items.Clear();
            foreach (DataRow dr in MenuList.Tables[0].Rows) {
                ListItem li = new ListItem();
                li.Text = dr[4].ToString();
                li.Value = dr[0].ToString();
                if (dr[0].ToString() == dsS.Tables[0].Rows[0][10].ToString())
                    li.Selected = true;
                ddlMenuItem.Items.Add(li);
            }
            ddlMenuItem_SelectedIndexChanged(sender, e);
            DataSet dsItems = new DataSet();
            dsItems = WSNew.getStockItemsPerProvider(Convert.ToInt32(PKiProviderID), true);
            ddlStockItem.Items.Clear();
            foreach (DataRow dr in dsItems.Tables[0].Rows) {
                ListItem li = new ListItem();
                li.Text = dr[1].ToString();
                li.Value = dr[0].ToString();
                if (dr[0].ToString() == dsS.Tables[0].Rows[0][1].ToString()) {
                    li.Selected = true;
                    dsST = WSNew.StockTypeList();
                    ddlStockLevelType.Items.Clear();
                    foreach (DataRow dr2 in dsST.Tables[0].Rows) {
                        ListItem li2 = new ListItem();
                        li2.Text = dr2[1].ToString();
                        li2.Value = dr2[0].ToString();
                        if (dr2[0].ToString() == dr[4].ToString())
                            li2.Selected = true;
                        ddlStockLevelType.Items.Add(li2);
                    }
                    txtStockLevel.Text = dr[3].ToString();
                    txtStockLevelReplace.Text = dr[2].ToString();
                }
                ddlStockItem.Items.Add(li);
            }
            Page_Load(sender, e);
        }

        protected void btnClearStockItem_Click(object sender, EventArgs e) {
            txtStockLevelReplace.Text = "";
            txtStockLevel.Text = "";
            txtStockDesc.Text = "";
            ddlStockLevelType.SelectedIndex = -1;
            ddlMenuItem.SelectedIndex = -1;
            hdnStockNumber.Value = "";
            Page_Load(sender, e);
        }

        protected void btnUpdateStockItem_Click1(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            //WSNew.UpdateStockItem(hdnStockNumber.Value, txtStockDesc.Text, txtStockLevel.Text, txtStockLevelReplace.Text, ddlMenuItem.SelectedValue, ddlStockLevelType.SelectedValue, ddlSubmenuItem.SelectedValue, txtReduceCount.Text);
            Page_Load(sender, e);
            btnClearStockItem_Click(sender, e);
        }

        protected void ddlMenuItem_SelectedIndexChanged(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.getSubmenuItemsByMenuId(Convert.ToInt32(ddlMenuItem.SelectedValue), true);
            ddlSubmenuItem.Items.Clear();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "";
            ddlSubmenuItem.Items.Add(li);
            foreach (DataRow dr in ds.Tables[0].Rows) {
                li.Value = dr[0].ToString();
                li.Text = dr[3].ToString();
                ddlSubmenuItem.Items.Add(li);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e) {
            Server.Transfer("pgManagement.aspx", false);
        }
    }
}