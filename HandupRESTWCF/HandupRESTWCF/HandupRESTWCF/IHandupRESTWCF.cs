using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data;

namespace HandupRESTWCF {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHandupRESTWCF" in both code and config file together.
    [ServiceContract]
    public interface IHandupRESTWCF {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginAndroid?sUsername={sUsername}&sPassword={sPassword}")]
        string LoginAndroid(string sUsername, string sPassword);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginAndroiBlank")]
        string LoginAndroiBlank();


        #region Orders

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddOrder?MenuItemID={MenuItemID}&TableID={TableID}&TextValue={TextValue}&SubmenuList={SubmenuList}")]
        DataSet AddOrder(int MenuItemID, int TableID, string TextValue, string SubmenuList);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ConfirmOrder?OrderID={OrderID}&sStatus={sStatus}")]
        string ConfirmOrder(int OrderID, string sStatus);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeclineOrder?OrderID={OrderID}")]
        string DeclineOrder(int OrderID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddTextToOrder?OrderID={OrderID}&TextValue={TextValue}")]
        DataSet AddTextToOrder(int OrderID, string TextValue);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "OrdersPerTable?TableID={TableID}")]
        DataSet OrdersPerTable(int TableID);


        #endregion

        #region Tables

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "JoinTableCode?sTableCode={sTableCode}")]
        DataSet JoinTableCode(string sTableCode);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddTable?FKiEmployeeID={FKiEmployeeID}&FKiProviderID={FKiProviderID}&iGuestNumber={iGuestNumber}&TableName={TableName}&Description={Description}")]
        string AddTable(int FKiEmployeeID, int FKiProviderID, int iGuestNumber, string TableName, string Description);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddPatronToTable?PkiTableID={PkiTableID}")]
        string AddPatronToTable(int PkiTableID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "CloseTable?PkiTableID={PkiTableID}&iStatusID={iStatusID}")]
        string CloseTable(int PkiTableID, int iStatusID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "CallWaiter?PkiTableID={PkiTableID}&sMessage={sMessage}")]
        string CallWaiter(int PkiTableID, string sMessage);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ActiveTablesForWaiter?EmployeeID={EmployeeID}")]
        DataSet ActiveTablesForWaiter(int EmployeeID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ActiveTablesForWaiterJSON?EmployeeID={EmployeeID}")]
        string ActiveTablesForWaiterJSON(int EmployeeID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ActiveTablesForProcessor?EmployeeID={EmployeeID}")]
        DataSet ActiveTablesForProcessor(int EmployeeID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ActiveTablesForProvider?ProviderID={ProviderID}")]
        DataSet ActiveTablesForProvider(int ProviderID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AllTablesForProviderByDate?ProviderID={ProviderID}&dtFromDate={dtFromDate}")]
        DataSet AllTablesForProviderByDate(int ProviderID, DateTime dtFromDate);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AllTablesForProviderByDateStatus?ProviderID={ProviderID}&dtFromDate={dtFromDate}&StatusID={StatusID}")]
        DataSet AllTablesForProviderByDateStatus(int ProviderID, DateTime dtFromDate, int StatusID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getEmployeeAssignedToTable?TableID={TableID}")]
        DataSet getEmployeeAssignedToTable(int TableID);

        #endregion

        #region Menu

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MenuForProvider?ProviderID={ProviderID}")]
        DataSet MenuForProvider(string ProviderID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getMenuItemByID?PKiMenuID={PKiMenuID}")]
        DataSet getMenuItemByID(int PKiMenuID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getMenuGroupsPerProvider?ProviderID={ProviderID}")]
        DataSet getMenuGroupsPerProvider(int ProviderID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getServiceStationsPerProvider?ProviderID={ProviderID}")]
        DataSet getServiceStationsPerProvider(int ProviderID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getSubmenuItemsByMenuId?MenuID={MenuID}")]
        DataSet getSubmenuItemsByMenuId(int MenuID);

        #endregion

        #region Employees

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "TableAlertPerEmployee?EmployeeID={EmployeeID}")]
        DataSet TableAlertPerEmployee(int EmployeeID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ConfirmAlert?sCode={sCode}&EmployeeID={EmployeeID}")]
        void ConfirmAlert(string sCode, int EmployeeID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getEmployeeByID?EmployeeID={EmployeeID}")]
        DataSet getEmployeeByID(int EmployeeID);

        #endregion

        #region Managment

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MenuPerProviderAdminFull?ProviderID={ProviderID}")]
        DataSet MenuPerProviderAdminFull(int ProviderID);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "EmployeeListPerProvireAdminFull?ProviderID={ProviderID}")]
        DataSet EmployeeListPerProvireAdminFull(int ProviderID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "AddEmployeePerProviderAdminFull?ProviderID={ProviderID}&EmployeeType={EmployeeType}&EmployeeAddress1={EmployeeAddress1}&EmployeeAddress2={EmployeeAddress2}&EmployeeAddress3={EmployeeAddress3}&EmployeeEmail={EmployeeEmail}&EmployeeID={EmployeeID}&EmployeeName={EmployeeName}&EmployeeNationality={EmployeeNationality}&EmployeeSurname={EmployeeSurname}&EmployeeTel={EmployeeTel}&Password={Password}&UserName={UserName}")]
        DataSet AddEmployeePerProviderAdminFull(int ProviderID, int EmployeeType, string EmployeeAddress1, string EmployeeAddress2, string EmployeeAddress3, string EmployeeEmail,
          string EmployeeID, string EmployeeName, string EmployeeNationality, string EmployeeSurname, string EmployeeTel, string Password, string UserName);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateEmployeePerProviderAdminFull?EmployeeID={EmployeeID}&EmployeeType={EmployeeType}&EmployeeAddress1={EmployeeAddress1}&EmployeeAddress2={EmployeeAddress2}&EmployeeAddress3={EmployeeAddress3}&EmployeeEmail={EmployeeEmail}&sEmployeeID={sEmployeeID}&EmployeeName={EmployeeName}&EmployeeNationality={EmployeeNationality}&EmployeeSurname={EmployeeSurname}&EmployeeTel={EmployeeTel}&Password={Password}&UserName={UserName}&ServiceStation={ServiceStation}")]
        DataSet UpdateEmployeePerProviderAdminFull(int EmployeeID, 
            int EmployeeType, 
            string EmployeeAddress1, 
            string EmployeeAddress2, 
            string EmployeeAddress3, 
            string EmployeeEmail,
            string sEmployeeID, 
            string EmployeeName, 
            string EmployeeNationality, 
            string EmployeeSurname, 
            string EmployeeTel, 
            string Password, 
            string UserName, 
            string ServiceStation);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "TablesPerProviderAdminFull?ProviderID={ProviderID}&dtOpen={dtOpen}")]
        DataSet TablesPerProviderAdminFull(int ProviderID, DateTime dtOpen);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ReOpenTablesPerProviderAdmin?ProviderID={ProviderID}&TableID={TableID}")]
        DataSet ReOpenTablesPerProviderAdmin(int ProviderID, int TableID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MoveOrderBetweenTablesPerProviderAdmin?ProviderID={ProviderID}&OrderID={OrderID}&ToTableID={ToTableID}")]
        DataSet MoveOrderBetweenTablesPerProviderAdmin(int ProviderID, int OrderID, int ToTableID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MoveTableBetweenEmployeePerProviderAdmin?ProviderID={ProviderID}&EmployeeID={EmployeeID}&ToTableID={ToTableID}")]
        DataSet MoveTableBetweenEmployeePerProviderAdmin(int ProviderID, int EmployeeID, int ToTableID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ChangeOrderValuePerOrderPerProviderAdmin?ProviderID={ProviderID}&OrderID={OrderID}&OrderValue={OrderValue}")]
        DataSet ChangeOrderValuePerOrderPerProviderAdmin(int ProviderID, int OrderID, double OrderValue);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "TablesPerProviderPerStatusAdminFull?ProviderID={ProviderID}&dtOpen={dtOpen}&StatusID={StatusID}")]
        DataSet TablesPerProviderPerStatusAdminFull(int ProviderID, DateTime dtOpen, int StatusID);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddNewMenuItem?ProviderID={ProviderID}&ServiceSationID={ServiceSationID}&MenuGroupID={MenuGroupID}&MenuItemName={MenuItemName}&MenuItemDescription={MenuItemDescription}&MenuItemImage={MenuItemImage}&MenuItemPrice={MenuItemPrice}")]
        DataSet AddNewMenuItem(int ProviderID, int ServiceSationID, int MenuGroupID, string MenuItemName, string MenuItemDescription, string MenuItemImage, double MenuItemPrice);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateMenuItem?MenuItemID={MenuItemID}&MenuGroupID={MenuGroupID}&MenuItemName={MenuItemName}&MenuItemDescription={MenuItemDescription}&MenuItemImage={MenuItemImage}&MenuItemPrice={MenuItemPrice}&ActiveStatus={ActiveStatus}&ProviderID={ProviderID}&ServiceSationID={ServiceSationID}")]
        DataSet UpdateMenuItem(int MenuItemID, int MenuGroupID, string MenuItemName, string MenuItemDescription, string MenuItemImage, double MenuItemPrice, int ActiveStatus, int ProviderID, int ServiceSationID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateMenuGroupPerProvider?ProviderID={ProviderID}&MenuGroupID={MenuGroupID}&MenuGroupName={MenuGroupName}&MenuGroupDescription={MenuGroupDescription}&FKiMenuGroupID={FKiMenuGroupID}")]
        DataSet UpdateMenuGroupPerProvider(int ProviderID, int MenuGroupID, string MenuGroupName, string MenuGroupDescription, string FKiMenuGroupID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddMenuGroupPerProvider?ProviderID={ProviderID}&MenuGroupName={MenuGroupName}&MenuGroupDescription={MenuGroupDescription}&FKiMenuGroupID={FKiMenuGroupID}")]
        DataSet AddMenuGroupPerProvider(int ProviderID, string MenuGroupName, string MenuGroupDescription, string FKiMenuGroupID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddNewServiceStation?ProviderID={ProviderID}&ServicestationID={ServicestationID}&ServiceStationName={ServiceStationName}&ServiceNameDescription={ServiceNameDescription}&ActiveStatus={ActiveStatus}")]
        DataSet AddNewServiceStation(int ProviderID, int ServicestationID, string ServiceStationName, string ServiceNameDescription, string ActiveStatus);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateServiceStation?ProviderID={ProviderID}&ServicestationID={ServicestationID}&ServiceStationName={ServiceStationName}&ServiceNameDescription={ServiceNameDescription}&ActiveStatus={ActiveStatus}")]
        DataSet UpdateServiceStation(int ProviderID, int ServicestationID, string ServiceStationName, string ServiceNameDescription, string ActiveStatus);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateMenuGroupTypesPerProvider?MenuGroupID={MenuGroupID}&MenuGroupName={MenuGroupName}&MenuGroupDescription={MenuGroupDescription}")]
        DataSet UpdateMenuGroupTypesPerProvider(int MenuGroupID, string MenuGroupName, string MenuGroupDescription);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddSubMenuGroupTypesPerProvider?ProviderID={ProviderID}&SubMenuGroupTypeName={SubMenuGroupTypeName}&SubMenuGroupTypepDescription={SubMenuGroupTypepDescription}")]
        DataSet AddSubMenuGroupTypesPerProvider(int ProviderID, string SubMenuGroupTypeName, string SubMenuGroupTypepDescription);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateSubMenuGroupTypePerProvider?SubMenuGroupTypeID={SubMenuGroupTypeID}&SubMenuGroupTypeName={SubMenuGroupTypeName}&SubMenuGroupTypepDescription={SubMenuGroupTypepDescription}&ActiveStatus={ActiveStatus}")]
        DataSet UpdateSubMenuGroupTypePerProvider(int SubMenuGroupTypeID, string SubMenuGroupTypeName, string SubMenuGroupTypepDescription, int ActiveStatus);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddSubMenuPerProvider?ProviderID={ProviderID}&MenuItemID={MenuItemID}&SubMenuGroupTypeID={SubMenuGroupTypeID}&SubMenuName={SubMenuName}&SubMenuDescription={SubMenuDescription}")]
        DataSet AddSubMenuPerProvider(int ProviderID, int MenuItemID, int SubMenuGroupTypeID, string SubMenuName, string SubMenuDescription);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateSubMenuPerProvider?SubMenuID={SubMenuID}&MenuItemID={MenuItemID}&SubMenuGroupTypeID={SubMenuGroupTypeID}&SubMenuName={SubMenuName}&SubMenuDescription={SubMenuDescription}")]
        DataSet UpdateSubMenuPerProvider(int SubMenuID, int MenuItemID, int SubMenuGroupTypeID, string SubMenuName, string SubMenuDescription);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetSubMenusPerProvider?ProviderID={ProviderID}")]
        DataSet GetSubMenusPerProvider(int ProviderID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SubmenuGroupTypesPerProvireAdminFull?ProviderID={ProviderID}")]
        DataSet SubmenuGroupTypesPerProvireAdminFull(int ProviderID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DefaultReportPerProvider?ProviderID={ProviderID}")]
        DataSet DefaultReportPerProvider(int ProviderID);

        #endregion

        #region Stock Management

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "StockTable?ProviderID={ProviderID}")]
        DataSet StockTable(int ProviderID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "StockAdd?StockID={StockID}&StockAddValue={StockAddValue}")]
        string StockAdd(int StockID, double StockAddValue);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "StockDeduct?StockID={StockID}&StockAddValue={StockAddValue}")]
        string StockDeduct(int StockID, double StockAddValue);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "StockItem?StockID={StockID}")]
        DataSet StockItem(int StockID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "StockTypeList")]
        DataSet StockTypeList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateStockItem?StockItemID={StockItemID}&StockName={StockName}&StockDesc={StockDesc}&MenuItem={MenuItem}&SubmenuItem={SubmenuItem}&ReduceAmount={ReduceAmount}")]
        void UpdateStockItem(string StockItemID, string StockName, string StockDesc, string MenuItem, string SubmenuItem, string ReduceAmount);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getStockItemsPerProvider?ProviderID={ProviderID}")]
        DataSet getStockItemsPerProvider(int ProviderID);
        #endregion

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddEmployee")]
        string AddEmployee();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "EditEmployee")]
        string EditEmployee();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "DisableEmployee")]
        string DisableEmployee();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GrantDenyAccessEmployee")]
        string GrantDenyAccessEmployee();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddMenuItem")]
        string AddMenuItem();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddSubmenuItem")]
        string AddSubmenuItem();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "OverrideOrderValue")]
        string OverrideOrderValue();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "MoveOrderFromTable")]
        string MoveOrderFromTable();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "ReportsOverView")]
        string ReportsOverView();
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddSpecialsList")]
        string AddSpecialsList();


        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetDataUsingDataContract?composite={composite}")]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

    }

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
