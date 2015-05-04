using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HandUpGUI {
    public partial class pgManagement : System.Web.UI.Page {
        public string PKiProviderID;
        protected void Page_Load(object sender, EventArgs e) {
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            PKiProviderID = dsE.Tables[0].Rows[0]["FKiProviderID"].ToString();
            if (!IsPostBack) {
                PopulateEmployees();
                PopulateTables();
                PopulateMenu();
            }
        }

        protected void PopulateEmployees() {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.EmployeeListPerProvireAdminFull(Convert.ToInt32(PKiProviderID), true);
            string sOrderList = "<table border='1'>";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                sOrderList += "<tr><td>Waiter</td><td>" + dr["sEmployeeName"].ToString() + "</td><td>" + dr["sEmployeeSurname"].ToString() + "</td><td>" + dr["sUserName"].ToString() + "</td><td><div id=\"order3C\" onclick=\"EditDeleteEmployee('" + dr["PKiEmployeeID"].ToString() + "', '0', '0')\">Update</div></td><td><div id=\"order3Ca\" onclick=\"EditDeleteEmployee('" + dr["PKiEmployeeID"].ToString() + "', '1', '0')\">Delete</div></td><td><div id=\"order3T\" onclick=\"EditDeleteEmployee('" + dr["PKiEmployeeID"].ToString() + "', '0', '1')\">Set Active</div></td></tr>";
            }
            sOrderList += "</table>";
            dvEmployeeList.InnerHtml = sOrderList;
        }

        protected void PopulateMenu() {
            DataSet ds = new DataSet();
            localhost.HandUpService WSNew = new localhost.HandUpService();
            ds = WSNew.MenuForProvider(PKiProviderID); // Admin

            string MenuTotal = "";
            string MenuHeaders = "<table width=\"100%\"><tr>";
            string menuHeaderCollection = "";
            foreach (DataRow drGroups in ds.Tables["MenuGroup"].Rows) {
                menuHeaderCollection += drGroups["PKiMenuGroupID"].ToString() + "|";
                MenuHeaders += "<td><div id=" + drGroups["PKiMenuGroupID"].ToString() + "Click onclick=ChangemenuArea(\"dvGroup" + drGroups["PKiMenuGroupID"].ToString() + "\")>" + drGroups["sMenuGroupName"].ToString() + "</div></td>";
                MenuTotal += "<div id=\"dvGroup" + drGroups["PKiMenuGroupID"].ToString() + "\"><table border='1'  width=\"100%\">";
                string CurrentMenuID = "";
                int ItemRow = 0;
                hdnMaxSubs.Value = (ds.Tables.Count - 1).ToString();
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    if (dr["FKiMenuID"].ToString() == "" && dr["FKiMenuGroupID"].ToString() == drGroups["PKiMenuGroupID"].ToString()) {
                        MenuTotal += "<tr><td><img id=\"MenuImage " + dr["FKiMenuID"].ToString() + "\" src=\"" + dr["imgMenuItemImage"].ToString() + "\" height='50' /></td><td>" + dr["sMenuItemName"].ToString() + "</td><td>" + dr["sMenuItemDescription"].ToString();
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
                        MenuTotal += "</td><td>" + dr["dblMenuItemPrice"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"" + dr["PKiMenuID"].ToString() + "\" onclick=\"Order('" + dr["PKiMenuID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/order_now.png\" height='50' /></div></td></tr>";
                        ItemRow++;
                    }
                }
                MenuTotal += "</table></div>";
            }
            MenuHeaders += "</tr></table>";
            dvMenuGroup.InnerHtml = MenuHeaders;
            hdnGroupHeaders.Value = menuHeaderCollection;
            dvMenulist.InnerHtml = MenuTotal;
        }

        protected void PopulateTables() {
            string sOrderList = "<table border='1'><tr><td>Waiter 1</td><td>Table Name 1</td><td><div id=\"order3C\" onclick=\"EditDeleteTable('Table3')\">CONFIRM</div></td></tr>";
            sOrderList += "<tr><td>Waiter 2</td><td>Table Name 1</td><td><div id=\"order4C\" onclick=\"EditDeleteTable('Table4')\">CONFIRM</div></td></tr>";
            sOrderList += "</table>";
            dvEditTableOrders.InnerHtml = sOrderList;
        }

        protected void PopulateSingleTable() {
            string CurrentOrderID = "111";
            string TableListStart = "<select name=\"" + CurrentOrderID + "\" id=\"" + CurrentOrderID + "\">";
            string TableSList = "<option value='1'>--</option>";
            TableSList += "<option value='1'>Table 1</option>";
            TableSList += "<option value='1'>Table 2</option>";
            string TableListEnd = "</select>";

            string sOrderList = "<table border='1'><tr><td>Table 1</td><td>Patron 1</td><td>Hamburger and Chips</td><td>><div id=\"order3T\" onclick=\"AddTextTable('ORDER3')\">TEXT</div></td><td>" + TableListStart + TableSList + TableListEnd + "</td><td><input id='Order1' type='text' value='99.99' /></td><td><div id=\"order3T\" onclick=\"UpdateOrder('ORDER3')\">Update</div></td></tr>";
            sOrderList += "<tr><td>Table 1</td><td>Patron 2</td><td>Steak egg and chips</td><td>><div id=\"order3T\" onclick=\"AddTextTable('ORDER4')\">TEXT</div></td><td>" + TableListStart + TableSList + TableListEnd + "</td><td><input id='Order1' type='text' value='25.00' /></td><td><div id=\"order4T\" onclick=\"UpdateOrder('ORDER4')\">Update</div></td></tr>";
            sOrderList += "</table>";
            dvEditTableOrders.InnerHtml = sOrderList;
        }

        /// <summary>
        /// Edit a menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditMenuItem_Click(object sender, EventArgs e) {
            if (hdnMenuStatus.Value == "1") {
                //Send update to "delete" menu item
            }
            else {
                //set the fields in the menu edit update add fields.
            }
        }

        /// <summary>
        /// edit an employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditEmployee_Click(object sender, EventArgs e) {
            if (hdnEmployeeStatus.Value == "1") {
                //Send update to "delete" menu item
            }
            else {
                //set the fields in the menu edit update add fields.
                localhost.HandUpService WSNew = new localhost.HandUpService();
                DataSet ds = WSNew.EmployeeListPerProvireAdminFull(Convert.ToInt32(PKiProviderID), true);
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    if (dr["PKiEmployeeID"].ToString() == hdnEmployeeID.Value) {
                        //hdnEmployeeID.Value = "";
                        txtAddress2.Text = dr["sEmployeeAddress2"].ToString();
                        txtAddress3.Text = dr["sEmployeeAddress3"].ToString();
                        txtAdress1.Text = dr["sEmployeeAddress1"].ToString();
                        txtContactNumber.Text = dr["sEmployeeTel"].ToString();
                        txtEmail.Text = dr["sEmployeeEmail"].ToString();
                        txtID.Text = dr["sEmployeeID"].ToString();
                        txtName.Text = dr["sEmployeeName"].ToString();
                        txtPassword.Text = dr["sPassword"].ToString();
                        txtSurname.Text = dr["sEmployeeSurname"].ToString();
                        txtUsername.Text = dr["sUserName"].ToString();
                        try {
                            calStartDate.TodaysDate = Convert.ToDateTime(dr["dtStartDate"].ToString());
                            calEndDate.TodaysDate = Convert.ToDateTime(dr["dtEndDate"].ToString());
                            ddlEmpStatus.SelectedIndex = Convert.ToInt32(dr["bActiveStatus"].ToString());
                            ddlEmpType.SelectedIndex = Convert.ToInt32(dr["FKiEmployeeType"].ToString());
                            rbtnGender.SelectedIndex = Convert.ToInt32(dr["bGender"].ToString());
                        }
                        catch{}
                    }
                }
            }
        }

        /// <summary>
        /// Select a table and set that table orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditTable_Click(object sender, EventArgs e) {
            string TableID = hdnTableID.Value;
        }

        /// <summary>
        /// UPdate the text value for an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateTextValues_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// Set the values in the employee edit area to the selected employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateAddEmp_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            WSNew.UpdateEmployeePerProviderAdminFull(Convert.ToInt32(hdnEmployeeID.Value), true, Convert.ToInt32(ddlEmpType.SelectedIndex) + 1, true, txtAdress1.Text, txtAddress2.Text, txtAddress3.Text, txtEmail.Text, txtID.Text, txtName.Text, "", txtSurname.Text, txtContactNumber.Text, txtPassword.Text, txtUsername.Text);
        }

        /// <summary>
        /// Clear the employee current there data to enter a new employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClearAddNew_Click(object sender, EventArgs e) {
            hdnEmployeeID.Value = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtAdress1.Text = "";
            txtContactNumber.Text = "";
            txtEmail.Text = "";
            txtID.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtSurname.Text = "";
            txtUsername.Text = "";
            calStartDate.TodaysDate = DateTime.Today;
            calEndDate.TodaysDate = DateTime.Today;
            ddlEmpStatus.SelectedIndex = 0;
            ddlEmpType.SelectedIndex = 0;
        }
    }
}