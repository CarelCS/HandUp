using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace HandUpWCF {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHandUpService {
        #region Adverts

        [OperationContract]
        DataSet AllAdvertsAvailableForProvider(int ProviderID);

        #endregion


        #region Login

        [OperationContract]
        DataSet Login(string sUserName, string sPassword);

        #endregion

        #region Orders

        [OperationContract]
        DataSet AddOrder(int MenuItemID, int TableID, string TextValue);
        [OperationContract]
        string ConfirmOrder(int OrderID, string sStatus);
        [OperationContract]
        string DeclineOrder(int OrderID);
        [OperationContract]
        DataSet AddTextToOrder(int OrderID, string TextValue);
        [OperationContract]
        DataSet OrdersPerTable(int TableID);


        #endregion

        #region Tables

        [OperationContract]
        DataSet JoinTableCode(string sTableCode);
        [OperationContract]
        string AddTable(int FKiEmployeeID, int FKiProviderID, int iGuestNumber, string TableName, string Description);
        [OperationContract]
        string AddPatronToTable(int PkiTableID);
        [OperationContract]
        string CloseTable(int PkiTableID, int iStatusID);
        [OperationContract]
        string CallWaiter(int PkiTableID, string sMessage);
        [OperationContract]
        DataSet ActiveTablesForWaiter(int EmployeeID);
        [OperationContract]
        DataSet ActiveTablesForProcessor(int EmployeeID);
        [OperationContract]
        DataSet ActiveTablesForProvider(int ProviderID);
        [OperationContract]
        DataSet AllTablesForProviderByDate(int ProviderID, DateTime dtFromDate);
        [OperationContract]
        DataSet AllTablesForProviderByDateStatus(int ProviderID, DateTime dtFromDate, int StatusID);
        [OperationContract]
        DataSet getEmployeeAssignedToTable(int TableID);

        #endregion

        #region Menu

        [OperationContract]
        DataSet MenuForProvider(string ProviderID);
        [OperationContract]
        DataSet getMenuItemByID(int PKiMenuID);
        [OperationContract]
        DataSet getMenuGroupsPerProvider(int ProviderID);
        [OperationContract]
        DataSet getServiceStationsPerProvider(int ProviderID);

        #endregion

        #region Employees

        [OperationContract]
        DataSet TableAlertPerEmployee(int EmployeeID);
        [OperationContract]
        void ConfirmAlert(string sCode, int EmployeeID);
        [OperationContract]
        DataSet getEmployeeByID(int EmployeeID);

        #endregion

        #region Managment

        [OperationContract]
        DataSet MenuPerProviderAdminFull(int ProviderID);
        [OperationContract]
        DataSet EmployeeListPerProvireAdminFull(int ProviderID);

        [OperationContract]
        DataSet AddEmployeePerProviderAdminFull(int ProviderID, int EmployeeType, string EmployeeAddress1, string EmployeeAddress2, string EmployeeAddress3, string EmployeeEmail,
          string EmployeeID, string EmployeeName, string EmployeeNationality, string EmployeeSurname, string EmployeeTel, string Password, string UserName);

        [OperationContract]
        DataSet UpdateEmployeePerProviderAdminFull(int EmployeeID, int EmployeeType, string EmployeeAddress1, string EmployeeAddress2, string EmployeeAddress3, string EmployeeEmail,
          string sEmployeeID, string EmployeeName, string EmployeeNationality, string EmployeeSurname, string EmployeeTel, string Password, string UserName, string ServiceStation);

        [OperationContract]
        DataSet TablesPerProviderAdminFull(int ProviderID, DateTime dtOpen);

        [OperationContract]
        DataSet ReOpenTablesPerProviderAdmin(int ProviderID, int TableID);

        [OperationContract]
        DataSet MoveOrderBetweenTablesPerProviderAdmin(int ProviderID, int OrderID, int ToTableID);

        [OperationContract]
        DataSet MoveTableBetweenEmployeePerProviderAdmin(int ProviderID, int EmployeeID, int ToTableID);

        [OperationContract]
        DataSet ChangeOrderValuePerOrderPerProviderAdmin(int ProviderID, int OrderID, double OrderValue);

        [OperationContract]
        DataSet TablesPerProviderPerStatusAdminFull(int ProviderID, DateTime dtOpen, int StatusID);


        [OperationContract]
        DataSet AddNewMenuItem(int ProviderID, int ServiceSationID, int MenuGroupID, string MenuItemName, string MenuItemDescription, string MenuItemImage, double MenuItemPrice);

        [OperationContract]
        DataSet UpdateMenuItem(int MenuItemID, int MenuGroupID, string MenuItemName, string MenuItemDescription, string MenuItemImage, double MenuItemPrice, int ActiveStatus, int ProviderID, int ServiceSationID);

        [OperationContract]
        DataSet UpdateMenuGroupPerProvider(int ProviderID, int MenuGroupID, string MenuGroupName, string MenuGroupDescription, string FKiMenuGroupID);

        [OperationContract]
        DataSet AddMenuGroupPerProvider(int ProviderID, string MenuGroupName, string MenuGroupDescription, string FKiMenuGroupID);

        [OperationContract]
        DataSet AddNewServiceStation(int ProviderID, int ServicestationID, string ServiceStationName, string ServiceNameDescription, string ActiveStatus);

        [OperationContract]
        DataSet UpdateServiceStation(int ProviderID, int ServicestationID, string ServiceStationName, string ServiceNameDescription, string ActiveStatus);


        [OperationContract]
        DataSet UpdateMenuGroupTypesPerProvider(int MenuGroupID, string MenuGroupName, string MenuGroupDescription);

        [OperationContract]
        DataSet AddSubMenuGroupTypesPerProvider(int ProviderID, string SubMenuGroupTypeName, string SubMenuGroupTypepDescription);

        [OperationContract]
        DataSet UpdateSubMenuGroupTypePerProvider(int SubMenuGroupTypeID, string SubMenuGroupTypeName, string SubMenuGroupTypepDescription, int ActiveStatus);

        [OperationContract]
        DataSet AddSubMenuPerProvider(int ProviderID, int MenuItemID, int SubMenuGroupTypeID, string SubMenuName, string SubMenuDescription);

        [OperationContract]
        DataSet UpdateSubMenuPerProvider(int SubMenuID, int MenuItemID, int SubMenuGroupTypeID, string SubMenuName, string SubMenuDescription);

        [OperationContract]
        DataSet GetSubMenusPerProvider(int ProviderID);

        [OperationContract]
        DataSet SubmenuGroupTypesPerProvireAdminFull(int ProviderID);

        [OperationContract]
        DataSet DefaultReportPerProvider(int ProviderID);

        #endregion

        [OperationContract]
        string AddEmployee();
        [OperationContract]
        string EditEmployee();
        [OperationContract]
        string DisableEmployee();
        [OperationContract]
        string GrantDenyAccessEmployee();
        [OperationContract]
        string AddMenuItem();
        [OperationContract]
        string AddSubmenuItem();
        [OperationContract]
        string OverrideOrderValue();
        [OperationContract]
        string MoveOrderFromTable();
        [OperationContract]
        string ReportsOverView();
        [OperationContract]
        string AddSpecialsList();


        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
