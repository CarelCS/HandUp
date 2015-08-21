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
            string sStockList = "<table>";
            sStockList += "<tr><td>Name</td><td>Description</td><td>Stock Level</td><td>Stock Level Type</td><td>Menu Name</td><td>Stock Replace Level</td></tr>"; 
            foreach (DataRow dr in ds.Tables[0].Rows) {
                sStockList += "<tr id=tr" + dr[0].ToString() + " onclick='ChangeStock(" + dr[0].ToString() + ")'><td>" + dr[1].ToString() + "</td><td>" + dr[2].ToString() + "</td><td>" + dr[4].ToString() + "</td><td>" + dr[6].ToString() + "</td><td>" + dr[7].ToString() + "</td><td>" + dr[9].ToString() + "</td></tr>"; 
            }
            sStockList += "</table>";
            dvStockList.InnerHtml = sStockList;
        }

        protected void btnUpdateStockItem_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet dsS = new DataSet();
            DataSet dsST = new DataSet();
            dsS = WSNew.StockItem(Convert.ToInt32(hdnStockNumber.Value), true);
            dsST = WSNew.StockTypeList();
            foreach (DataRow dr in dsST.Tables[0].Rows) {
                ListItem li = new ListItem();
                li.Text = dr[1].ToString();
                li.Value = dr[0].ToString();
                if (dr[0].ToString() == dsS.Tables[0].Rows[0][5].ToString())
                    li.Selected = true;
                ddlStockLevelType.Items.Add(li);
            }
            txtStockLevel.Text = dsS.Tables[0].Rows[0][4].ToString();
            txtStockLevelReplace.Text = dsS.Tables[0].Rows[0][9].ToString();
            txtStockName.Text = dsS.Tables[0].Rows[0][1].ToString();
            txtStockDesc.Text = dsS.Tables[0].Rows[0][2].ToString();
            DataSet MenuList = WSNew.MenuForProvider(PKiProviderID);
            foreach (DataRow dr in MenuList.Tables[0].Rows) {
                ListItem li = new ListItem();
                li.Text = dr[4].ToString();
                li.Value = dr[0].ToString();
                if (dr[0].ToString() == dsS.Tables[0].Rows[0][10].ToString())
                    li.Selected = true;
                ddlMenuItem.Items.Add(li);
            }
            Page_Load(sender, e);
        }

        protected void btnClearStockItem_Click(object sender, EventArgs e) {
            txtStockName.Text = "";
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
            WSNew.UpdateStockItem(hdnStockNumber.Value, txtStockName.Text, txtStockDesc.Text, txtStockLevel.Text, txtStockLevelReplace.Text, ddlMenuItem.SelectedValue, ddlStockLevelType.SelectedValue);
            Page_Load(sender, e);
            btnClearStockItem_Click(sender, e);
        }
    }
}