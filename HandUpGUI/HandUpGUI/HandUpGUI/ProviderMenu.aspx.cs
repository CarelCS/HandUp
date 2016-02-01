using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HandUpGUI {
    public partial class ProviderMenu : System.Web.UI.Page {

        public string ScreenWidth;
        int IconWidth;
        string PKiProviderID = "";

        protected void Page_Load(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = new DataSet();
            if (!IsPostBack) {
                ds = WSNew.AllAvailableProviderMenues();
                ListItem li = new ListItem();
                li.Text = "Select a Provider to view menu.";
                li.Value = "0";
                ddlMenuesAvailable.Items.Add(li);
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    li = new ListItem();
                    li.Text = dr["sProviderName"].ToString();
                    li.Value = dr["PKiProviderID"].ToString();
                    ddlMenuesAvailable.Items.Add(li);
                }
            }
            PKiProviderID = Request.QueryString["ProviderID"].ToString();
            PopulateMenuBase("0");
        }

        protected void PopulateMenuBase(string GroupCurrent) {
            DataSet ds = new DataSet();
            localhost.HandUpService WSNew = new localhost.HandUpService();
            ds = WSNew.MenuForProvider(PKiProviderID);
            string BaseMenu = "<table width='100%' align='center'>";
            bool DoesHavemenu = false;
            foreach (DataRow drGroups in ds.Tables["MenuGroup"].Rows) {
                if (drGroups["FKiMenuGroupID"].ToString() == GroupCurrent) {
                    DoesHavemenu = true;
                    BaseMenu += "<tr><td width='20%'></td><td align='center'><div style='border-width:thin; background-color:transparent; cursor:pointer; color:White; font-weight:bolder; font-family:Arial; background-color:rgb(192,212,79)' id=" + drGroups["PKiMenuGroupID"].ToString() + "Click onclick=ChangemenuAreaByID(\"" + drGroups["PKiMenuGroupID"].ToString() + "\")>" + drGroups["sMenuGroupName"].ToString() + "</div></td><td width='20%'></td></tr>";
                }
            }
            hdnMaxSubs.Value = (ds.Tables.Count - 1).ToString();
            BaseMenu += "</table>";
            if (!DoesHavemenu) {
                string MenuTotal = "<table>";
                string CurrentMenuID = "";
                int ItemRow = 0;
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    if (dr["FKiMenuID"].ToString() == "0" && dr["FKiMenuGroupID"].ToString() == GroupCurrent) {
                        MenuTotal += "<tr><td><B>" + dr["sMenuItemName"].ToString() + "</br></B>" + dr["sMenuItemDescription"].ToString() + "</td><td width='100%'>" + dr["sMenuItemDescription"].ToString();
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
                                        MenuTotalSUB += "<option value=\"" + drInner[0].ToString() + "^" + drInner["sSubMenuName"].ToString() + "\">" + drInner["sSubMenuName"].ToString() + "</option>";
                                        IsItem = true;
                                    }
                                }
                                MenuTotalSUB += "</select>";
                                if (IsItem) {
                                    MenuTotal += MenuTotalSUB;
                                }
                            }
                        }
                        MenuTotal += "</td><td>" + dr["dblMenuItemPrice"].ToString() + "</td></tr>"; //<td><div style=\"cursor:pointer;\" id=\"" + dr["PKiMenuID"].ToString() + "\" onclick=\"Order('" + dr["PKiMenuID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/order.png\" width='" + IconWidth + "' /></div></td>
                        ItemRow++;
                    }
                }
                MenuTotal += "</table>";
                BaseMenu = MenuTotal;
            }
            dvMenuMain.InnerHtml = BaseMenu;
        }

        protected void btnGoToMenu_Click(object sender, EventArgs e) {
            if (ddlMenuesAvailable.SelectedValue != "0") {
                Server.Transfer("ProviderMenu.aspx?ProviderID=" + ddlMenuesAvailable.SelectedValue, false);
            }
        }

        protected void btnChangeGroup_Click(object sender, EventArgs e) {
            if (hdnGroupCurrent.Value != "") {
                PopulateMenuBase(hdnGroupCurrent.Value);
            }
        }
    }
}