using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace HandUpWCF {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class HandUpService : IHandUpService {
        //string MyConnectionString = "Server=localhost;Database=Handup;Uid=root;Pwd=Password1;";

        #region Login

        public DataSet Login(string sUserName, string sPassword) {
            clsLogin aLogin = new clsLogin();
            return aLogin.Login(sUserName, sPassword);
        }

        #endregion

        #region Orders

        public DataSet AddOrder(int MenuItemID, int TableID, string TextValue) {
            Orders clsOrder = new Orders();
            return clsOrder.AddOrder(MenuItemID, TableID, TextValue);
        }

        public string ConfirmOrder(int OrderID, string sStatus) {
            Orders order = new Orders();
            order.ConfirmDenyOrder(OrderID, sStatus);
            return string.Format("ConfirmOrder");
        }

        public string DeclineOrder(int OrderID) { return string.Format("DeclineOrder"); }

        public DataSet AddTextToOrder(int OrderID, string TextValue) {
            Orders clsOrder = new Orders();
            return clsOrder.AddTextToOrder(OrderID, TextValue);
        }

        public DataSet OrdersPerTable(int TableID) {
            Orders clsOrder = new Orders();
            return clsOrder.OrdersPerTable(TableID);
        }

        #endregion

        #region Tables

        public DataSet JoinTableCode(string sTableCode) {
            Table clsTable = new Table();
            return clsTable.JoinTableCode(sTableCode);
        }

        public string AddTable(int FKiEmployeeID, int FKiProviderID, int iGuestNumber, string TableName, string Description) {
            Table clsTable = new Table();
            return clsTable.AddTable(FKiEmployeeID, FKiProviderID, iGuestNumber, TableName, Description);
        }

        public string AddPatronToTable(int PkiTableID) {
            Table clsTable = new Table();
            return clsTable.AddPatronToTable(PkiTableID);
        }

        public string CloseTable(int PkiTableID, int iStatusID) { return string.Format("CloseTable"); }

        public string CallWaiter(int PkiTableID, string sMessage) {
            Table clsTable = new Table();
            return clsTable.CallWaiter(PkiTableID, sMessage);
        }

        public DataSet ActiveTablesForWaiter(int EmployeeID) {
            Table clsTable = new Table();
            return clsTable.ActiveTablesForWaiter(EmployeeID);
        }

        public DataSet ActiveTablesForProcessor(int EmployeeID) {
            Table clsTable = new Table();
            return clsTable.ActiveTablesForProcessor(EmployeeID);
        }

        public DataSet ActiveTablesForProvider(int ProviderID) {
            Table clsTable = new Table();
            return clsTable.ActiveTablesForProvider(ProviderID);
        }

        public DataSet AllTablesForProviderByDate(int ProviderID, DateTime dtFromDate) {
            Table clsTable = new Table();
            return clsTable.AllTablesForProviderByDate(ProviderID, dtFromDate);
        }

        public DataSet AllTablesForProviderByDateStatus(int ProviderID, DateTime dtFromDate, int StatusID) {
            Table clsTable = new Table();
            return clsTable.AllTablesForProviderByDateStatus(ProviderID, dtFromDate, StatusID);
        }

        #endregion

        #region Menu

        public DataSet MenuForProvider(string ProviderID) {
            Menu table = new Menu();
            return table.MenuForProvider(ProviderID);

        }
        #endregion

        #region Employee

        public DataSet TableAlertPerEmployee(int EmployeeID) {
            Employees clsEmployees = new Employees();
            return clsEmployees.TableAlertPerEmployee(EmployeeID);
        }

        #endregion

        public string AddEmployee() { return string.Format("AddEmployee"); }
        public string EditEmployee() { return string.Format("EditEmployee"); }
        public string DisableEmployee() { return string.Format("DisableEmployee"); }
        public string GrantDenyAccessEmployee() { return string.Format("GrantDenyAccessEmployee"); }
        public string AddMenuItem() { return string.Format("AddMenuItem"); }
        public string AddSubmenuItem() { return string.Format("AddSubmenuItem"); }
        public string OverrideOrderValue() { return string.Format("OverrideOrderValue"); }
        public string MoveOrderFromTable() { return string.Format("MoveOrderFromTable"); }
        public string ReportsOverView() { return string.Format("ReportsOverView"); }
        public string AddSpecialsList() {

            DataAdapters newAdapter = new DataAdapters();
            DataSet newDs = newAdapter.RetrieveTable("");
            string ThisValue = newDs.Tables[0].Rows[0][1].ToString() + " " + newDs.Tables[0].Rows[0][2].ToString();
            return string.Format(ThisValue);

        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        #region Management

        public DataSet MenuPerProviderAdminFull(int ProviderID) {
            Management clsManagement = new Management();
            return clsManagement.MenuPerProviderAdminFull(ProviderID);
        }



        public DataSet EmployeeListPerProvireAdminFull(int ProviderID) {
            Management clsManagement = new Management();
            return clsManagement.EmployeeListPerProvireAdminFull(ProviderID);
        }

        public DataSet AddEmployeePerProviderAdminFull(int ProviderID, int EmployeeType, string EmployeeAddress1, string EmployeeAddress2, string EmployeeAddress3, string EmployeeEmail,
           string EmployeeID, string EmployeeName, string EmployeeNationality, string EmployeeSurname, string EmployeeTel, string Password, string UserName) {
            Management clsManagement = new Management();
            return clsManagement.AddEmployeePerProviderAdminFull(ProviderID, EmployeeType, EmployeeAddress1, EmployeeAddress2, EmployeeAddress3, EmployeeEmail, EmployeeID, EmployeeName, EmployeeNationality, EmployeeSurname, EmployeeTel, Password, UserName);
        }

        public DataSet UpdateEmployeePerProviderAdminFull(int EmployeeID, int EmployeeType, string EmployeeAddress1, string EmployeeAddress2, string EmployeeAddress3, string EmployeeEmail,
           string sEmployeeID, string EmployeeName, string EmployeeNationality, string EmployeeSurname, string EmployeeTel, string Password, string UserName) {
            Management clsManagement = new Management();
            return clsManagement.UpdateEmployeePerProviderAdminFull(EmployeeID, EmployeeType, EmployeeAddress1, EmployeeAddress2, EmployeeAddress3, EmployeeEmail, sEmployeeID, EmployeeName, EmployeeNationality, EmployeeSurname, EmployeeTel, Password, UserName);
        }

        #endregion



        public DataSet TablesPerProviderAdminFull(int ProviderID, DateTime dtOpen) {
            Management clsManagement = new Management();
            return clsManagement.TablesPerProviderAdminFull(ProviderID, dtOpen);
        }

        public DataSet ReOpenTablesPerProviderAdmin(int ProviderID, int TableID) {
            Management clsManagement = new Management();
            return clsManagement.ReOpenTablesPerProviderAdmin(ProviderID, TableID);
        }

        public DataSet MoveOrderBetweenTablesPerProviderAdmin(int ProviderID, int OrderID, int ToTableID) {
            Management clsManagement = new Management();
            return clsManagement.MoveOrderBetweenTablesPerProviderAdmin(ProviderID, OrderID,ToTableID);
        }

        public DataSet MoveTableBetweenEmployeePerProviderAdmin(int ProviderID, int EmployeeID, int ToTableID) {
            Management clsManagement = new Management();
            return clsManagement.MoveTableBetweenEmployeePerProviderAdmin(ProviderID, EmployeeID, ToTableID);
        }

        public DataSet ChangeOrderValuePerOrderPerProviderAdmin(int ProviderID, int OrderID, double OrderValue) {
            Management clsManagement = new Management();
            return clsManagement.ChangeOrderValuePerOrderPerProviderAdmin(ProviderID, OrderID,OrderValue);
        }

        public DataSet TablesPerProviderPerStatusAdminFull(int ProviderID, DateTime dtOpen, int StatusID) {
            Management clsManagement = new Management();
            return clsManagement.TablesPerProviderPerStatusAdminFull(ProviderID, dtOpen,StatusID);
        }


        public DataSet AddNewMenuItem(int ProviderID, int MenuGroupID, string MenuItemName, string MenuItemDescription, string MenuItemImage, double MenuItemPrice) {
            Management clsManagement = new Management();
            return clsManagement.AddNewMenuItem(ProviderID, MenuGroupID,MenuItemName, MenuItemDescription,MenuItemImage,MenuItemPrice);
        }

        public DataSet UpdateMenuItem(int MenuItemID, int MenuGroupID, string MenuItemName, string MenuItemDescription, string MenuItemImage, double MenuItemPrice, int ActiveStatus) {
            Management clsManagement = new Management();
            return clsManagement.UpdateMenuItem(MenuItemID, MenuGroupID, MenuItemName, MenuItemDescription, MenuItemImage, MenuItemPrice, ActiveStatus);
        }

        public DataSet AddMenuGroupPerProvider(int ProviderID, string MenuGroupName, string MenuGroupDescription) {
            Management clsManagement = new Management();
            return clsManagement.AddMenuGroupPerProvider(ProviderID, MenuGroupName, MenuGroupDescription);
        }



        public DataSet UpdateMenuGroupTypesPerProvider(int MenuGroupID, string MenuGroupName, string MenuGroupDescription) {
            Management clsManagement = new Management();
            return clsManagement.UpdateMenuGroupTypesPerProvider(MenuGroupID, MenuGroupName, MenuGroupDescription);
        }

        public DataSet AddSubMenuGroupTypesPerProvider(int ProviderID, string SubMenuGroupTypeName, string SubMenuGroupTypepDescription) {
            Management clsManagement = new Management();
            return clsManagement.AddSubMenuGroupTypesPerProvider(ProviderID, SubMenuGroupTypeName, SubMenuGroupTypepDescription);
        }

        public DataSet UpdateSubMenuGroupTypePerProvider(int SubMenuGroupTypeID, string SubMenuGroupTypeName, string SubMenuGroupTypepDescription, int ActiveStatus) {
            Management clsManagement = new Management();
            return clsManagement.UpdateSubMenuGroupTypePerProvider(SubMenuGroupTypeID, SubMenuGroupTypeName, SubMenuGroupTypepDescription, ActiveStatus);
        }

        public DataSet AddSubMenuPerProvider(int ProviderID, int MenuItemID, int SubMenuGroupTypeID, string SubMenuName, string SubMenuDescription) {
            Management clsManagement = new Management();
            return clsManagement.AddSubMenuPerProvider(ProviderID, MenuItemID, SubMenuGroupTypeID, SubMenuName, SubMenuDescription);
        }

        public DataSet UpdateSubMenuPerProvider(int SubMenuID, int MenuItemID, int SubMenuGroupTypeID, string SubMenuName, string SubMenuDescription) {
            Management clsManagement = new Management();
            return clsManagement.UpdateSubMenuPerProvider(SubMenuID, MenuItemID, SubMenuGroupTypeID, SubMenuName, SubMenuDescription);
        }
    }
}