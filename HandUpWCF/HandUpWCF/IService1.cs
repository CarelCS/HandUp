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
        #region Login

        [OperationContract]
        DataSet Login(string sUserName, string sPassword);

        #endregion

        #region Orders

        [OperationContract]
        DataSet AddOrder(int MenuItemID,int TableID, string TextValue);
        [OperationContract]
        string ConfirmOrder(int OrderID, string sStatus);
        [OperationContract]
        string DeclineOrder(int OrderID);
        [OperationContract]
        string AddTextToOrder(int OrderID,string TextValue);
        [OperationContract]
        DataSet OrdersPerTable(int TableID);


        #endregion

        #region Tables

        [OperationContract]
        DataSet JoinTableCode(string sTableCode);
        [OperationContract]
        string AddTable(int FKiEmployeeID, int FKiProviderID, int iGuestNumber);
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

        #endregion

        #region Menu

        [OperationContract]
        DataSet MenuForProvider(string ProviderID);

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
