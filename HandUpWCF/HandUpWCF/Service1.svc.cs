﻿using System;
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
            return clsOrder.AddOrder( MenuItemID,  TableID,  TextValue);
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

        public string AddTable(int FKiEmployeeID, int FKiProviderID, int iGuestNumber) {
            Table clsTable = new Table();
            return clsTable.AddTable(FKiEmployeeID,FKiProviderID,iGuestNumber);
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
    }
}
