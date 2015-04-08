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

        [OperationContract]
        DataSet LoginWaiter(string sUserName, string sPassword);
        [OperationContract]
        DataSet JoinTableCode(string sTableCode);
        [OperationContract]
        string AddOrder(int MenuItemID, string TextValue);
        [OperationContract]
        string ConfirmOrder(int OrderID, string sStatus);
        [OperationContract]
        string DeclineOrder();
        [OperationContract]
        string AddTextToOrder();
        [OperationContract]
        string AddTable();
        [OperationContract]
        string AddPatronToTable();
        [OperationContract]
        string CloseTable();
        [OperationContract]
        string CallWaiter();
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
        DataSet MenuForProvider(string ProviderID);

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
