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
        public string sImageFileName;
        protected void Page_Load(object sender, EventArgs e) {
            DataSet dsE = new DataSet();
            dsE = (DataSet)Session["SEmployee"];
            PKiProviderID = dsE.Tables[0].Rows[0]["FKiProviderID"].ToString();
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet dsMG = new DataSet();
            DataSet dsSS = new DataSet();
            DataSet dsSM = new DataSet();
            dsMG = WSNew.getMenuGroupsPerProvider(Convert.ToInt32(PKiProviderID), true);
            dsSS = WSNew.getServiceStationsPerProvider(Convert.ToInt32(PKiProviderID), true);
            dsSM = WSNew.SubmenuGroupTypesPerProvireAdminFull(Convert.ToInt32(PKiProviderID), true);
            //if (!IsPostBack) {
                PopulateEmployees();
                PopulateTables();
                PopulateMenu();
                PopulateAvailableEmployees();
            //}
                if (!IsPostBack) {
                    hdnChangeDisplay.Value = "1";
                    ddlMenuGroup.Items.Clear();
                    ddlServiceStation.Items.Clear();
                    ddlEmpServiceStation.Items.Clear();
                    ddlSubmenuGroup.Items.Clear();
                    ListItem liF = new ListItem();
                    liF.Text = "Please select";
                    liF.Value = "0";
                    ddlMenuGroup.Items.Add(liF);
                    ddlServiceStation.Items.Add(liF);
                    ddlEditMenuGroup.Items.Add(liF);
                    ddlMainMenuGroup.Items.Add(liF);
                    ddlEditServiceStation.Items.Add(liF);
                    ddlSubmenuGroup.Items.Add(liF);
                    foreach (DataRow dr in dsMG.Tables[0].Rows) {
                        ListItem li = new ListItem();
                        li.Text = dr["sMenuGroupName"].ToString();
                        li.Value = dr["PKiMenuGroupID"].ToString();
                        ddlMenuGroup.Items.Add(li);
                        ddlEditMenuGroup.Items.Add(li);
                    }
                    foreach (DataRow dr in dsSS.Tables[0].Rows) {
                        ListItem li = new ListItem();
                        li.Text = dr["sName"].ToString();
                        li.Value = dr["PKiServiceStaionID"].ToString();
                        ddlServiceStation.Items.Add(li);
                        ddlEmpServiceStation.Items.Add(li);
                        ddlEditServiceStation.Items.Add(li);
                    }
                    foreach (DataRow dr in dsSM.Tables[0].Rows) {
                        ListItem li = new ListItem();
                        li.Text = dr["sSubMenuGroupTypeName"].ToString();
                        li.Value = dr["PKiSubMenuGroupTypeID"].ToString();
                        ddlSubmenuGroup.Items.Add(li);
                    }
                }
        }

        protected void PopulateAfterGroupEdit() {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet dsMG = new DataSet();
            dsMG = WSNew.getMenuGroupsPerProvider(Convert.ToInt32(PKiProviderID), true); ListItem liF = new ListItem();
            liF.Text = "Please select";
            liF.Value = "0";
            ddlMainMenuGroup.Items.Add(liF);
            ddlEditMenuGroup.Items.Add(liF);
            foreach (DataRow dr in dsMG.Tables[0].Rows) {
                ListItem li = new ListItem();
                li.Text = dr["sMenuGroupName"].ToString();
                li.Value = dr["PKiMenuGroupID"].ToString();
                ddlMainMenuGroup.Items.Add(li);
                ddlEditMenuGroup.Items.Add(li);
            }
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
                    if (dr["FKiMenuID"].ToString() == "0" && dr["FKiMenuGroupID"].ToString() == drGroups["PKiMenuGroupID"].ToString()) {
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
                        MenuTotal += "</td><td>" + dr["dblMenuItemPrice"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"" + dr["PKiMenuID"].ToString() + "\" onclick=\"EditDeleteMenuItem('" + dr["PKiMenuID"].ToString() + "', 0)\"><img id=\"Image1\" src=\"images/icons/Order.png\" height='50' /></div></td><td><div style=\"cursor:pointer;\" id=\"" + dr["PKiMenuID"].ToString() + "\" onclick=\"EditDeleteMenuItem('" + dr["PKiMenuID"].ToString() + "', 1)\"><img id=\"Image1\" src=\"images/icons/Cancel.png\" height='50' /></div></td></tr>";
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
            if (ddlTables.Items.Count == 0) {
                DataSet ds = new DataSet();
                localhost.HandUpService WSNew = new localhost.HandUpService();
                ds = WSNew.ActiveTablesForProvider(Convert.ToInt32(PKiProviderID), true);
                ListItem liBase = new ListItem();
                liBase.Text = "SELECT TABLE";
                liBase.Value = "0";
                ddlTables.Items.Add(liBase);
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    ListItem li = new ListItem();
                    li.Text = dr["sTableName"].ToString();
                    li.Value = dr["PKiTableID"].ToString();
                    ddlTables.Items.Add(li);
                }
            }
        }

        protected void PopulateAvailableEmployees() {
            if (ddlEmployees.Items.Count == 0) {
                DataSet ds = new DataSet();
                localhost.HandUpService WSNew = new localhost.HandUpService();
                ds = WSNew.EmployeeListPerProvireAdminFull(Convert.ToInt32(PKiProviderID), true);
                ListItem liBase = new ListItem();
                liBase.Text = "SELECT TABLE";
                liBase.Value = "0";
                ddlEmployees.Items.Add(liBase);
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    ListItem li = new ListItem();
                    li.Text = dr["sUserName"].ToString();
                    li.Value = dr["PKiEmployeeID"].ToString();
                    ddlEmployees.Items.Add(li);
                }
            }
        }

        protected string PopulateMoveToTables(string OrderID) {
            string OptionTable = "";
            DataSet ds = new DataSet();
            localhost.HandUpService WSNew = new localhost.HandUpService();
            ds = WSNew.ActiveTablesForProvider(Convert.ToInt32(PKiProviderID), true);
            OptionTable = "<select id='HTMLSelect" + OrderID + "' onchange=\"moveOrderToTable(this);\"><option value=\"0\">Select table</option>";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                OptionTable += "<option value=\"" + dr["PKiTableID"].ToString() +"|~\">" + dr["sTableName"].ToString() + "</option>";
            }
            OptionTable += "</select>";
            return OptionTable;
        }

        /// <summary>
        /// Edit a menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditMenuItem_Click(object sender, EventArgs e) {
            DataSet dsMG = new DataSet();
            DataSet dsSS = new DataSet();
            DataSet ds = new DataSet();
            localhost.HandUpService WSNew = new localhost.HandUpService();
            if (hdnMenuStatus.Value == "1") {
                //Send update to "delete" menu item
            }
            else {
                dsMG = WSNew.getMenuGroupsPerProvider(Convert.ToInt32(PKiProviderID), true);
                dsSS = WSNew.getServiceStationsPerProvider(Convert.ToInt32(PKiProviderID), true);
                ds = WSNew.getMenuItemByID(Convert.ToInt32(hdnMenuID.Value), true);
                sImageFileName = ds.Tables[0].Rows[0]["imgMenuItemImage"].ToString();
                string GroupID = ds.Tables[0].Rows[0]["FKiMenuGroupID"].ToString();
                string ServiceStationID = ds.Tables[0].Rows[0]["FKiServicestationID"].ToString();
                ddlMenuGroup.Items.Clear();
                ddlServiceStation.Items.Clear(); 
                ListItem liF = new ListItem();
                liF.Text = "Please select";
                liF.Value = "0";
                ddlMenuGroup.Items.Add(liF);
                ddlServiceStation.Items.Add(liF);
                foreach (DataRow dr in dsMG.Tables[0].Rows) {
                    ListItem li = new ListItem();
                    li.Text = dr["sMenuGroupName"].ToString();
                    li.Value = dr["PKiMenuGroupID"].ToString();
                    if (dr["PKiMenuGroupID"].ToString() == GroupID)
                        li.Selected = true;
                    ddlMenuGroup.Items.Add(li);
                }
                foreach (DataRow dr in dsSS.Tables[0].Rows) {
                    ListItem li = new ListItem();
                    li.Text = dr["sName"].ToString();
                    li.Value = dr["PKiServiceStaionID"].ToString();
                    if (dr["PKiServiceStaionID"].ToString() == ServiceStationID)
                        li.Selected = true;
                    ddlServiceStation.Items.Add(li);
                }
                txtMenuDescription.Text = ds.Tables[0].Rows[0]["sMenuItemName"].ToString();
                txtMenuName.Text = ds.Tables[0].Rows[0]["sMenuItemDescription"].ToString();
                txtMenuPrice.Text = ds.Tables[0].Rows[0]["dblMenuItemPrice"].ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ChangePage", "ChangePage(2);", true);
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
                        DataSet dsSS = WSNew.getServiceStationsPerProvider(Convert.ToInt32(PKiProviderID), true);
                        ddlEmpServiceStation.Items.Clear();
                        foreach (DataRow drSS in dsSS.Tables[0].Rows) {
                            ListItem li = new ListItem();
                            li.Text = drSS["sName"].ToString();
                            li.Value = drSS["PKiServiceStaionID"].ToString();
                            if (dr["FKiServicestaionID"].ToString() == li.Value)
                            {
                                li.Selected = true;
                            }
                            ddlEmpServiceStation.Items.Add(li);
                        }
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
            string OrderNumber = hdnOrderNumber.Value;
            string OrderText = hdnTextForOrder.Value;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            ddlTables_SelectedIndexChanged(sender, e);
            //PopulateNewOrderForTable(WSNew.AddTextToOrder(Convert.ToInt32(OrderNumber), true, OrderText));
        }

        /// <summary>
        /// Set the values in the employee edit area to the selected employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateAddEmp_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            int EmpID = 0;
            try {
                EmpID = Convert.ToInt32(hdnEmployeeID.Value);
            }
            catch { }
            WSNew.UpdateEmployeePerProviderAdminFull(EmpID, true, Convert.ToInt32(ddlEmpType.SelectedIndex), true, txtAdress1.Text, txtAddress2.Text, txtAddress3.Text, txtEmail.Text, txtID.Text, txtName.Text, "", txtSurname.Text, txtContactNumber.Text, txtPassword.Text, txtUsername.Text, ddlEmpServiceStation.SelectedValue);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e) {
            string ScreenWidth = Session["ScreenWidth"].ToString();
            int IconWidth = Convert.ToInt32(ScreenWidth) / 20;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = new DataSet();
            ds = WSNew.OrdersPerTable(Convert.ToInt32(ddlTables.SelectedValue), true);
            DataSet dsEmp = new DataSet();
            dsEmp = WSNew.getEmployeeAssignedToTable(Convert.ToInt32(ddlTables.SelectedValue), true);
            lblTableAssingedEmployee.Text = dsEmp.Tables[0].Rows[0]["sEmployeeName"].ToString() + " " + dsEmp.Tables[0].Rows[0]["sEmployeeSurname"].ToString() + " : " + dsEmp.Tables[0].Rows[0]["sUserName"].ToString();
            string sOrderList = "<table border='1' width=\"100%\">";
            string sCapableOption = "";
            string sCanConfirm = "";
            double TotalCost = 0;
            foreach (DataRow dr in ds.Tables[0].Rows) {
                sCanConfirm = "<div style=\"cursor:pointer;\" id=\"order3C\" onclick=\"ConfirmOrder('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Confirm.png\"  width='" + IconWidth + "'/></div>";
                sCapableOption = "<div style=\"cursor:pointer;\" id=\"order3T\" onclick=\"AddTextTable('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Text.png\"  width='" + IconWidth + "'/></div>";
                if (dr["sOrderStatus"].ToString() == "4" || dr["sOrderStatus"].ToString() == "2") {
                    if (dr["sOrderStatus"].ToString() == "4") {
                        //sOrderList += "<tr style=\"text-decoration:line-through\"><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td>R " + dr["dblOrderValue"].ToString() + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                    }
                    else {
                        sOrderList += "<tr><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"order3Ca" + dr["PKiOrderID"].ToString() + "\" onclick=\"ChangeValue('" + dr["PKiOrderID"].ToString() + "')\">R " + dr["dblOrderValue"].ToString() + "</div></td><td>" + PopulateMoveToTables(dr["PKiOrderID"].ToString()).Replace("~", dr["PKiOrderID"].ToString()) + "</td><td>" + sCanConfirm + "</td><td></td><td>" + sCapableOption + "</td></tr>";
                    }
                }
                else {
                    sOrderList += "<tr><td width='100%'>" + dr["sMenuItemDescription"].ToString() + dr["sMenuItemChanges"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"order3Ca" + dr["PKiOrderID"].ToString() + "\" onclick=\"ChangeValue('" + dr["PKiOrderID"].ToString() + "')\">R " + dr["dblOrderValue"].ToString() + "</div></td><td>" + PopulateMoveToTables(dr["PKiOrderID"].ToString()).Replace("~", dr["PKiOrderID"].ToString()) + "</td><td>" + sCanConfirm + "</td><td><div style=\"cursor:pointer;\" id=\"order3Ca\" onclick=\"CancelOrder('" + dr["PKiOrderID"].ToString() + "')\"><img id=\"Image1\" src=\"images/icons/Cancel.png\"  width='" + IconWidth + "'/></div></td><td>" + sCapableOption + "</td></tr>";
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
        protected void btnUpdateRandValues_Click(object sender, EventArgs e) {
            string NewRandValue = hdnRandValueForOrder.Value;
            string OrderID = hdnOrderNumber.Value;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.ChangeOrderValuePerOrderPerProviderAdmin(Convert.ToInt32(PKiProviderID), true, Convert.ToInt32(OrderID), true, Convert.ToDouble(NewRandValue), true);
            ddlTables_SelectedIndexChanged(sender, e);
        }

        protected void btnMoveOrderToTable_Click(object sender, EventArgs e) {
            string MoveToID = hdnMoveToTableID.Value;
            string MoveFromID = ddlTables.SelectedValue;
            string OrderID = hdnOrderNumber.Value;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.MoveOrderBetweenTablesPerProviderAdmin(Convert.ToInt32(PKiProviderID), true, Convert.ToInt32(OrderID), true, Convert.ToInt32(MoveToID), true);
            ddlTables_SelectedIndexChanged(sender, e);
        }

        protected void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e) {
            string MoveTableID = ddlTables.SelectedValue;
            string MoveTableToEmployeeID = ddlEmployees.SelectedValue;
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.MoveTableBetweenEmployeePerProviderAdmin(Convert.ToInt32(PKiProviderID), true, Convert.ToInt32(MoveTableToEmployeeID), true, Convert.ToInt32(MoveTableID), true);
            ddlTables_SelectedIndexChanged(sender, e);
        }

        protected void btnUpdateAddMenuItem_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            
            int MenuGroupID = 0;
            int ServicestationID = 0;
            if (txtNewMenuGroup.Text != "") {
                MenuGroupID = Convert.ToInt32(WSNew.AddMenuGroupPerProvider(Convert.ToInt32(PKiProviderID), true, txtNewMenuGroup.Text, "", ddlEditMenuGroup.SelectedValue).Tables[0].Rows[0]["PKiMenuGroupID"].ToString());
            }
            else {
                MenuGroupID = Convert.ToInt32(ddlMenuGroup.SelectedValue);
            }
            if (txtAddNewServicestation.Text != "") {
                MenuGroupID = Convert.ToInt32(WSNew.AddNewServiceStation(Convert.ToInt32(PKiProviderID), true, 0, true, txtAddNewServicestation.Text, "", "1").Tables[0].Rows[0]["PKiServicestaionID"].ToString());
            }
            else {
                ServicestationID = Convert.ToInt32(ddlServiceStation.SelectedValue);
            }
            int intMenuID = 0;
            try {
                intMenuID = Convert.ToInt32(hdnMenuID.Value);
            }
            catch { }
            DataSet ds = WSNew.UpdateMenuItem(intMenuID, true, Convert.ToInt32(MenuGroupID), true, txtMenuName.Text, txtMenuDescription.Text, sImageFileName, Convert.ToDouble(txtMenuPrice.Text), true, 1, true, Convert.ToInt32(PKiProviderID), true, ServicestationID, true);
            if (hdnMenuID.Value == "" || fuMenuImage.PostedFile != null)
            {
                string ThisNewID = ds.Tables[0].Rows[0]["PKiMenuID"].ToString();
                string NewFileName = "";
                if (fuMenuImage.PostedFile != null) {
                    NewFileName = uploadMenuImage(fuMenuImage.PostedFile, ThisNewID);
                }
                ds = WSNew.UpdateMenuItem(Convert.ToInt32(ThisNewID), true, Convert.ToInt32(MenuGroupID), true, txtMenuName.Text, txtMenuDescription.Text, "images\\MenuImages\\" + NewFileName, Convert.ToDouble(txtMenuPrice.Text), true, 1, true, Convert.ToInt32(PKiProviderID), true, ServicestationID, true);
            }
        }

        protected string uploadMenuImage(HttpPostedFile file, string FKiMenuID) {
            string[] Substrings = file.FileName.Split('.');
            int Length = Substrings.Length - 1;
            string Exten = Substrings[Length];
            string savePath = "C:\\Development\\HandUp\\HandUpGUI\\HandUpGUI\\HandUpGUI\\Images\\MenuImages\\" + PKiProviderID.ToString() + "_" + FKiMenuID + "." + Exten;
            file.SaveAs(savePath);
            return PKiProviderID.ToString() + "_" + FKiMenuID + "." + Exten;
        }

        protected void btnMenuGroupSubmit_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.UpdateMenuGroupPerProvider(Convert.ToInt32(PKiProviderID), true, Convert.ToInt32(ddlEditMenuGroup.SelectedValue), true, txtMenuGroupEditName.Text, txtMenuGroupEditDescription.Text, ddlMainMenuGroup.SelectedValue);
            PopulateAfterGroupEdit();
        }

        protected void btnServiceStationEdit_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.UpdateServiceStation(Convert.ToInt32(PKiProviderID), true, Convert.ToInt32(ddlEditServiceStation.SelectedValue), true, txtServiceStationEditName.Text, txtServiceStationEditDescription.Text, "1");
        }

        protected void ddlEditMenuGroup_SelectedIndexChanged(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet dsMG = new DataSet();
            dsMG = WSNew.getMenuGroupsPerProvider(Convert.ToInt32(PKiProviderID), true);
            ListItem liF = new ListItem();
            liF.Text = "Please select";
            liF.Value = "0";
            ddlMainMenuGroup.Items.Clear();
            ddlMainMenuGroup.Items.Add(liF);
            foreach (DataRow dr in dsMG.Tables[0].Rows) {
                ListItem li = new ListItem();
                li.Text = dr["sMenuGroupName"].ToString();
                li.Value = dr["PKiMenuGroupID"].ToString();
                ddlMainMenuGroup.Items.Add(li);
                if (ddlEditMenuGroup.SelectedValue == dr["PKiMenuGroupID"].ToString()) {
                    txtMenuGroupEditName.Text = dr["sMenuGroupName"].ToString();
                    txtMenuGroupEditDescription.Text = dr["sMenuGroupDescription"].ToString();
                    ddlMainMenuGroup.SelectedValue = dr["FKiMenuGroupID"].ToString();
                }
            }
        }

        protected void ddlEditServiceStation_SelectedIndexChanged(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet dsSS = new DataSet();
            dsSS = WSNew.getServiceStationsPerProvider(Convert.ToInt32(PKiProviderID), true);
            foreach (DataRow dr in dsSS.Tables[0].Rows) {
                if (ddlEditServiceStation.SelectedValue == dr["PKiServiceStaionID"].ToString()) {
                    txtServiceStationEditName.Text = dr["sName"].ToString();
                    txtServiceStationEditDescription.Text = dr["sDescription"].ToString();
                }
            }
        }

        protected void btnFillSubMenus_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.GetSubMenusPerProvider(Convert.ToInt32(PKiProviderID), true);
            string SubMenuTable = "<table>";
            foreach (DataRow dr in ds.Tables[0].Rows) {
                SubMenuTable += "<tr><td>" + dr["sSubMenuGroupTypeName"].ToString() + "</td><td>" + dr["sSubMenuName"].ToString() + "</td><td>" + dr["sSubMenuDescription"].ToString() + "</td><td><div style=\"cursor:pointer;\" id=\"" + dr["PKiSubMenuID"].ToString() + "\" onclick=\"EditDeleteSubMenuItem('" + dr["PKiSubMenuID"].ToString() + "', 0)\"><img id=\"Image1\" src=\"images/icons/Cancel.png\" height='50' /></div></td></tr>";
            }
            SubMenuTable += "</table>";
            dvSubmenuList.InnerHtml = SubMenuTable;
        }

        protected void btnDeleteSubmenuItem_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            WSNew.UpdateSubMenuPerProvider(Convert.ToInt32(hdnDeleteSubmenuId.Value), true, 0, true, 0, true, "", "");
            btnFillSubMenus_Click(sender, e);
        }

        protected void btnShowReports_Click(object sender, EventArgs e) {
            localhost.HandUpService WSNew = new localhost.HandUpService();
            DataSet ds = WSNew.DefaultReportPerProvider(Convert.ToInt32(PKiProviderID), true);
            string ReportString = "<table>";
            int reportcount = 0;
            foreach (DataTable dt in ds.Tables) {
                ReportString += "<tr><td colspan='3'>Report " + reportcount++ + "</td></tr>";
                foreach (DataRow dr in dt.Rows) {
                    ReportString += "<tr><td>" + dr[0].ToString() + "</td><td>" + dr[1].ToString() + "</td><td>" + dr[2].ToString() + "</td></tr>";
                }
            }
            ReportString += "</table>";
            dvReportDisplay.InnerHtml = ReportString;
        }
    }
}