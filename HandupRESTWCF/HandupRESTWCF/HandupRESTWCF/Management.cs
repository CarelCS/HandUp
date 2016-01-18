using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandupRESTWCF.DBClasses;

namespace HandupRESTWCF {
    public class Management {

        #region Menu

        public DataSet MenuPerProviderAdminFull(int ProviderID) {
            tblMenu aMenu = new tblMenu();
            aMenu.addEquals(tblMenu._FKIPROVIDERID, ProviderID);
            DataSet aDataSet = aMenu.executeSelectDataSet();
            aDataSet.Tables[0].TableName = "Menu";

            tblluMenugroups aMenuGroup = new tblluMenugroups();
            DataSet dsGroupNames = aMenuGroup.executeCustomSQLDataSet("SELECT distinct " + tblluMenugroups._PKIMENUGROUPID + "," + tblluMenugroups._SMENUGROUPNAME + "," + tblluMenugroups._SMENUGROUPDESCRIPTION +
                " FROM tbllumenugroups,tblmenu" +
                " WHERE tbllumenugroups.PKiMenuGroupID=tblmenu.FKiMenuGroupID and handup.tblmenu.FKiProviderID=" + ProviderID);
            dsGroupNames.Tables[0].TableName = "MenuGroup";
            aDataSet.Tables.Add(dsGroupNames.Tables[0].Copy());

            foreach (DataRow aMenuDataRow in aDataSet.Tables[0].Rows) {
                tblluSubmenus aSubMenu = new tblluSubmenus();
                aSubMenu.addEquals(tblluSubmenus._FKIMENUID, Convert.ToInt32(aMenuDataRow[tblMenu._PKIMENUID]));
                DataSet dsSubMenus = aSubMenu.executeSelectDataSet();

                Dictionary<string, DataSet> dicSubMenuGroup = new Dictionary<string, DataSet>();

                foreach (DataRow aSubMenuDataRow in dsSubMenus.Tables[0].Rows) {
                    tblluSubmenugrouptype aSubMenuGroup = new tblluSubmenugrouptype((int)aSubMenuDataRow[tblluSubmenus._FKISUBMENUGROUPTYPEID]);
                    if (dicSubMenuGroup.ContainsKey(aSubMenuGroup.sSubMenuGroupTypeName)) {
                        DataSet aSubMenuPerGroupDS = dicSubMenuGroup[aSubMenuGroup.sSubMenuGroupTypeName];
                        aSubMenuPerGroupDS.Tables[aSubMenuGroup.sSubMenuGroupTypeName].ImportRow(aSubMenuDataRow);
                    }
                    else {
                        DataSet aSubMenuPerGroupDS = new DataSet();
                        aSubMenuPerGroupDS.Tables.Add(aSubMenuGroup.sSubMenuGroupTypeName);
                        foreach (DataColumn aDataColumn in dsSubMenus.Tables[0].Columns) {
                            aSubMenuPerGroupDS.Tables[aSubMenuGroup.sSubMenuGroupTypeName].Columns.Add(aDataColumn.ToString());
                        }
                        aSubMenuPerGroupDS.Tables[aSubMenuGroup.sSubMenuGroupTypeName].ImportRow(aSubMenuDataRow);
                        dicSubMenuGroup.Add(aSubMenuGroup.sSubMenuGroupTypeName, aSubMenuPerGroupDS);
                    }
                }
                foreach (KeyValuePair<string, DataSet> aKeyPair in dicSubMenuGroup) {
                    aDataSet.Tables.Add(aKeyPair.Value.Tables[0].Copy());
                }
            }
            return aDataSet;
        }

        #endregion

        #region Employees

        public DataSet EmployeeListPerProvireAdminFull(int ProviderID) {
            tblEmployees aEmployees = new tblEmployees();
            aEmployees.addEquals(tblEmployees._FKIPROVIDERID, ProviderID);
            DataSet dsDataSet = aEmployees.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet AddEmployeePerProviderAdminFull(int ProviderID, int EmployeeType, string EmployeeAddress1, string EmployeeAddress2, string EmployeeAddress3, string EmployeeEmail,
            string EmployeeID, string EmployeeName, string EmployeeNationality, string EmployeeSurname, string EmployeeTel, string Password, string UserName) {
            tblEmployees aEmployees = new tblEmployees();
            aEmployees.FKiEmployeeType = EmployeeType;
            aEmployees.FKiProviderID = ProviderID;
            aEmployees.sEmployeeAddress1 = EmployeeAddress1;
            aEmployees.sEmployeeAddress2 = EmployeeAddress2;
            aEmployees.sEmployeeAddress3 = EmployeeAddress3;
            aEmployees.sEmployeeEmail = EmployeeEmail;
            aEmployees.sEmployeeID = EmployeeID;
            aEmployees.sEmployeeName = EmployeeName;
            aEmployees.sEmployeeNationality = EmployeeNationality;
            aEmployees.sEmployeeSurname = EmployeeSurname;
            aEmployees.sEmployeeTel = EmployeeTel;
            aEmployees.sPassword = Password;
            aEmployees.sUserName = UserName;
            aEmployees.executeINSERT();
            DataSet dsDataSet = EmployeeListPerProvireAdminFull(ProviderID);
            return dsDataSet;
        }

        public DataSet UpdateEmployeePerProviderAdminFull(int EmployeeID, int EmployeeType, string EmployeeAddress1, string EmployeeAddress2, string EmployeeAddress3, string EmployeeEmail,
            string sEmployeeID, string EmployeeName, string EmployeeNationality, string EmployeeSurname, string EmployeeTel, string Password, string UserName, string ServiceStationID) {
            tblEmployees aEmployees = new tblEmployees(EmployeeID);
            aEmployees.FKiEmployeeType = EmployeeType;
            aEmployees.sEmployeeAddress1 = EmployeeAddress1;
            aEmployees.sEmployeeAddress2 = EmployeeAddress2;
            aEmployees.sEmployeeAddress3 = EmployeeAddress3;
            aEmployees.sEmployeeEmail = EmployeeEmail;
            aEmployees.sEmployeeID = sEmployeeID;
            aEmployees.sEmployeeName = EmployeeName;
            aEmployees.sEmployeeNationality = EmployeeNationality;
            aEmployees.sEmployeeSurname = EmployeeSurname;
            aEmployees.sEmployeeTel = EmployeeTel;
            aEmployees.sPassword = Password;
            aEmployees.sUserName = UserName;
            aEmployees.executeUPDATE();
            aEmployees.addEquals(tblEmployees._PKIEMPLOYEEID, EmployeeID);
            DataSet dsDataSet = aEmployees.executeSelectDataSet();
            return dsDataSet;
        }

        #endregion

        #region Tables

        public DataSet TablesPerProviderAdminFull(int ProviderID,DateTime dtOpen) {
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._FKIPROVIDERID, ProviderID);
            aTable.addAND();
            aTable.addGreaterThan(tblTables._DTSTARTDATETIME, dtOpen);
            DataSet dsDataSet = aTable.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet ReOpenTablesPerProviderAdmin(int ProviderID, int TableID) {
            // true is Employee is still active - send only db table 
            // false  db tbale and table with active Employees
            tblTables aTable = new tblTables(TableID);
            tblEmployees aEmployee = aTable.gettblEmployees_FKiEmployeeID();
            DataSet dsDataSet = new DataSet();

            if (aEmployee.bActiveStatus.Equals("1")) {
                aTable.bActiveStatus = 1;
                aTable.executeUPDATE();
                aTable.addEquals(tblTables._PKITABLEID, TableID);
                dsDataSet = aTable.executeSelectDataSet();

            }
            else {
                aTable.addEquals(tblTables._PKITABLEID, TableID);
                dsDataSet = aTable.executeSelectDataSet();

                aEmployee = new tblEmployees();
                aEmployee.addEquals(tblEmployees._FKIPROVIDERID, aTable.FKiProviderID);
                aEmployee.addAND();
                aEmployee.addEquals(tblEmployees._BACTIVESTATUS, "1");
                DataSet dsEmployees = aEmployee.executeSelectDataSet();
                dsEmployees.Tables[0].TableName = "Employees";
                dsDataSet.Tables.Add(dsEmployees.Tables[0].Copy());
            }

            return dsDataSet;
        }

        public DataSet MoveOrderBetweenTablesPerProviderAdmin(int ProviderID, int OrderID, int ToTableID) {
            tblOrders aOrder = new tblOrders(OrderID);
            aOrder.FKiTableID = ToTableID;
            aOrder.executeUPDATE();

            //aOrder.addEquals(tblOrders._PKIORDERID, OrderID);
            DataSet dsDataSet = aOrder.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet MoveTableBetweenEmployeePerProviderAdmin(int ProviderID, int EmployeeID, int ToTableID) {
            tblTables aTable = new tblTables(ToTableID);
            aTable.FKiEmployeeID = EmployeeID; ;
            aTable.executeUPDATE();

            DataSet dsDataSet = aTable.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet ChangeOrderValuePerOrderPerProviderAdmin(int ProviderID, int OrderID, double OrderValue) {
            //set order status inctive with reason description 
            // create new order
            // update relevant db tables
            tblOrders aOrder = new tblOrders(OrderID);
            aOrder.sOrderStatus = "0";
            aOrder.dblOrderValue = OrderValue;
            aOrder.sMenuItemChanges += " Change make to Order Value by Provider Admin";
            aOrder.executeUPDATE();

            DataSet ds = new DataSet();
            return ds;
        }

        public DataSet TablesPerProviderPerStatusAdminFull(int ProviderID, DateTime dtOpen, int StatusID) {
            tblTables aTable = new tblTables();
            aTable.addEquals(tblTables._FKIPROVIDERID, ProviderID);
            aTable.addAND();
            aTable.addGreaterThan(tblTables._DTSTARTDATETIME, dtOpen);
            aTable.addAND();
            aTable.addEquals(tblTables._BACTIVESTATUS, StatusID);
            DataSet dsDataSet = aTable.executeSelectDataSet();
            return dsDataSet;
        }

        #endregion

        public DataSet AddNewServiceStation(int ProviderID, int ServicestationID, string ServiceStationName, string ServiceNameDescription, string ActiveStatus) {
            tblServicestaion aSSItem = new tblServicestaion();
            aSSItem.bActiveStatus = "1";
            aSSItem.FKiProviderID = ProviderID;
            aSSItem.sDescription = ServiceNameDescription;
            aSSItem.sName = ServiceStationName;
            aSSItem = aSSItem.executeINSERT();

            aSSItem.addEquals(tblServicestaion._PKISERVICESTATIONID, aSSItem.PKiServiceStaionID);
            DataSet dsDataSet = aSSItem.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet AddNewMenuItem(int ProviderID, int ServiceStationID, int MenuGroupID, string MenuItemName, string MenuItemDescription, string MenuItemImage, double MenuItemPrice) {
            DataSet dsDataSet = new DataSet();
            try {
                tblMenu aMenuItem = new tblMenu();
                aMenuItem.FKiMenuID = 0;
                aMenuItem.bActiveStatus = 1;
                aMenuItem.dtMenuItemModified = DateTime.Now;
                aMenuItem.dblMenuItemPrice = MenuItemPrice;
                aMenuItem.FKiMenuGroupID = MenuGroupID;
                aMenuItem.FKiProviderID = ProviderID;
                aMenuItem.imgMenuItemImage = MenuItemImage;
                aMenuItem.sMenuItemDescription = MenuItemDescription;
                aMenuItem.sMenuItemName = MenuItemName;
                aMenuItem.fkiServicestationID = ServiceStationID;
                aMenuItem = aMenuItem.executeINSERT();

                aMenuItem.addEquals(tblMenu._PKIMENUID, aMenuItem.PKiMenuID);
                dsDataSet = aMenuItem.executeSelectDataSet();
            }
            catch { }
            return dsDataSet;
        }

        public DataSet UpdateServiceStation(int ProviderID, int ServicestationID, string ServiceStationName, string ServiceNameDescription, string ActiveStatus) {
            
            DataSet dsDataSet = new DataSet();
            if (ServicestationID == 0) {
                dsDataSet = AddNewServiceStation(ProviderID, ServicestationID, ServiceStationName, ServiceNameDescription, ActiveStatus);
            }
            else {
                tblServicestaion aSSItem = new tblServicestaion(ServicestationID);
                aSSItem.bActiveStatus = ActiveStatus;
                aSSItem.sName = ServiceStationName;
                aSSItem.sDescription = ServiceNameDescription;
                aSSItem.PKiServiceStaionID = ServicestationID;
                aSSItem.FKiProviderID = ProviderID;
                aSSItem.executeUPDATE();

                dsDataSet = aSSItem.executeSelectDataSet();
            }
            return dsDataSet;
        }

        public DataSet UpdateMenuItem(int ProviderID, int ServiceStationID, int MenuItemID, int MenuGroupID, string MenuItemName, string MenuItemDescription, string MenuItemImage, double MenuItemPrice, int ActiveStatus) {
            DataSet dsDataSet = new DataSet();
            try {
                if (MenuItemID == 0) {
                    dsDataSet = AddNewMenuItem(ProviderID, ServiceStationID, MenuGroupID, MenuItemName, MenuItemDescription, MenuItemImage, MenuItemPrice);
                }
                else {
                    tblMenu aMenuItem = new tblMenu(MenuItemID);
                    aMenuItem.bActiveStatus = ActiveStatus;
                    aMenuItem.dtMenuItemModified = DateTime.Now;
                    aMenuItem.dblMenuItemPrice = MenuItemPrice;
                    aMenuItem.FKiMenuGroupID = MenuGroupID;
                    aMenuItem.imgMenuItemImage = MenuItemImage;
                    aMenuItem.sMenuItemDescription = MenuItemDescription;
                    aMenuItem.sMenuItemName = MenuItemName;
                    aMenuItem.fkiServicestationID = ServiceStationID;
                    aMenuItem.executeUPDATE();

                    dsDataSet = aMenuItem.executeSelectDataSet();
                }
            }
            catch { }
            return dsDataSet;
        }


        public DataSet UpdateMenuGroupPerProvider(int ProviderID, int MenuGroupID, string MenuGroupName, string MenuGroupDescription, string FKiMenuGroupID) {
            DataSet dsDataSet = new DataSet();
            if (MenuGroupID == 0) {
                dsDataSet = AddMenuGroupPerProvider(ProviderID, MenuGroupName, MenuGroupDescription, FKiMenuGroupID);
            }
            else {
                tblluMenugroups aMenuGroup = new tblluMenugroups(MenuGroupID);
                aMenuGroup.FKiProviderID = ProviderID.ToString();
                aMenuGroup.sMenuGroupDescription = MenuGroupDescription;
                aMenuGroup.sMenuGroupName = MenuGroupName;
                aMenuGroup.FKiMenuGroupID = Convert.ToInt32(FKiMenuGroupID);
                aMenuGroup.executeUPDATE();
                dsDataSet = aMenuGroup.executeSelectDataSet();
            }
            return dsDataSet;
        }

        public DataSet AddMenuGroupPerProvider(int ProviderID, string MenuGroupName, string MenuGroupDescription, string FKiMenuGroupID) {
            tblluMenugroups aMenuGroup = new tblluMenugroups();

            aMenuGroup.FKiProviderID = ProviderID.ToString();
            aMenuGroup.sMenuGroupDescription = MenuGroupDescription;
            aMenuGroup.sMenuGroupName = MenuGroupName;
            aMenuGroup.FKiMenuGroupID = Convert.ToInt32(FKiMenuGroupID);
            aMenuGroup = aMenuGroup.executeINSERT();

            aMenuGroup.addEquals(tblluMenugroups._PKIMENUGROUPID, aMenuGroup.PKiMenuGroupID);
            DataSet dsDataSet = aMenuGroup.executeSelectDataSet();
            return dsDataSet;
        }



        public DataSet UpdateMenuGroupTypesPerProvider(int MenuGroupID,string MenuGroupName, string MenuGroupDescription) {
            tblluMenugroups aMenuGroup = new tblluMenugroups(MenuGroupID);
            aMenuGroup.sMenuGroupDescription = MenuGroupDescription;
            aMenuGroup.sMenuGroupName=MenuGroupName;
            aMenuGroup.executeUPDATE();

            DataSet dsDataSet = aMenuGroup.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet AddSubMenuGroupTypesPerProvider(int ProviderID, string SubMenuGroupTypeName, string SubMenuGroupTypepDescription) {
            tblluSubmenugrouptype aSubMenuGroupType = new tblluSubmenugrouptype();
            aSubMenuGroupType.bActiveStatus = 1;
            aSubMenuGroupType.sSubMenuGroupTypeDescription = SubMenuGroupTypepDescription;
            aSubMenuGroupType.sSubMenuGroupTypeName = SubMenuGroupTypeName;
            aSubMenuGroupType = aSubMenuGroupType.executeINSERT();

            DataSet dsDataSet = aSubMenuGroupType.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet UpdateSubMenuGroupTypePerProvider(int SubMenuGroupTypeID, string SubMenuGroupTypeName, string SubMenuGroupTypepDescription, int ActiveStatus) {
            tblluSubmenugrouptype aSubMenuGroupType = new tblluSubmenugrouptype(SubMenuGroupTypeID);
            aSubMenuGroupType.bActiveStatus = ActiveStatus;
            aSubMenuGroupType.sSubMenuGroupTypeDescription = SubMenuGroupTypepDescription;
            aSubMenuGroupType.sSubMenuGroupTypeName = SubMenuGroupTypeName;
            aSubMenuGroupType.executeUPDATE();

            DataSet dsDataSet = aSubMenuGroupType.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet AddSubMenuPerProvider(int ProviderID,int MenuItemID, int SubMenuGroupTypeID, string SubMenuName, string SubMenuDescription) {
            tblluSubmenus aSubMenu = new tblluSubmenus();
            aSubMenu.FKiMenuID = MenuItemID;
            aSubMenu.FKiSubMenuGroupTypeID = SubMenuGroupTypeID;
            aSubMenu.sSubMenuDescription = SubMenuDescription;
            aSubMenu.sSubMenuName = SubMenuName;
            aSubMenu = aSubMenu.executeINSERT();

            DataSet dsDataSet = aSubMenu.executeSelectDataSet();
            return dsDataSet;
        }

        public DataSet UpdateSubMenuPerProvider(int SubMenuID, int MenuItemID, int SubMenuGroupTypeID, string SubMenuName, string SubMenuDescription) {
            DataSet dsDataSet = new DataSet();
            if (MenuItemID == 0 && SubMenuID != 0 && SubMenuGroupTypeID == 0 && SubMenuName == "" && SubMenuDescription == "") {
                tblluSubmenus aSubMenu = new tblluSubmenus(SubMenuID);
                dsDataSet = aSubMenu.executeCustomSQLDataSet("delete from tbllusubmenus where PKiSubMenuID = " + SubMenuID);
            }
            else {
                tblluSubmenus aSubMenu = new tblluSubmenus(SubMenuID);
                aSubMenu.FKiMenuID = MenuItemID;
                aSubMenu.FKiSubMenuGroupTypeID = SubMenuGroupTypeID;
                aSubMenu.sSubMenuDescription = SubMenuDescription;
                aSubMenu.sSubMenuName = SubMenuName;
                aSubMenu.executeUPDATE();

                dsDataSet = aSubMenu.executeSelectDataSet();
            }
            return dsDataSet;
        }

        public DataSet GetSubMenusPerProvider(int ProviderID) {
            DataSet ds = new DataSet();
            tblluSubmenugrouptype sSubMenuGroup = new tblluSubmenugrouptype();
            tblluSubmenus aSubMenu = new tblluSubmenus();
            ds = sSubMenuGroup.executeCustomSQLDataSet("select * from tbllusubmenugrouptype " +
            "inner join tbllusubmenus on FKiSubMenuGroupTypeID = PKiSubMenuGroupTypeID " +
            "where FKiProviderID = " + ProviderID);
            return ds;
        }

        public DataSet SubmenuGroupTypesPerProvireAdminFull(int ProviderID) {
            tblluSubmenugrouptype aSMT = new tblluSubmenugrouptype();
            aSMT.addEquals(tblluSubmenugrouptype._FKIPROVIDERID, ProviderID);
            DataSet dsDataSet = aSMT.executeSelectDataSet();
            return dsDataSet;
        }

        #region Reports
        
        public DataSet DefaultReportPerProvider(int ProviderID) {
            DataSet dsDataSet = new DataSet();
            tblMenu aMenuReport = new tblMenu();
            DataSet dsMostOrdered = aMenuReport.executeCustomSQLDataSet("select count(Orders.FKiMenuID) amount, Orders.FKiMenuID, (select sMenuItemName from tblmenu where PKiMenuID = Orders.FKiMenuID) as Named from tblOrders Orders where FKiProviderID = " + ProviderID + " group by Orders.FKiMenuID");
            DataSet dsSalesPerWaiterAndTables = aMenuReport.executeCustomSQLDataSet("select sum(dblOrderValue), count(FKiTableID) Tablesdone, (select Emp.sUserName from tblEmployees as Emp inner join tblTables as Tbl on Tbl.FKiEmployeeID = Emp.PKiEmployeeID where Tbl.PKiTableID = Orders.FKiTableID) as Named from tblOrders Orders where FKiProviderID = " + ProviderID + " group by Named");
            DataSet dsNumebrOfGuestsPerWaiter = aMenuReport.executeCustomSQLDataSet("select sum(iGuestNumber), count(tbls.PKiTableID) tabless, emp.sUserName  from tbltables tbls inner join tblEmployees emp on emp.PKiEmployeeID = tbls.FKiEmployeeID where tbls.FKiProviderID = " + ProviderID + " group by emp.sUserName");
            dsMostOrdered.Tables[0].TableName = "MostOrdered";
            dsSalesPerWaiterAndTables.Tables[0].TableName = "SalesPerWaiterAndTables";
            dsNumebrOfGuestsPerWaiter.Tables[0].TableName = "NumebrOfGuestsPerWaiter";
            dsDataSet.Tables.Add(dsMostOrdered.Tables[0].Copy());
            dsDataSet.Tables.Add(dsSalesPerWaiterAndTables.Tables[0].Copy());
            dsDataSet.Tables.Add(dsNumebrOfGuestsPerWaiter.Tables[0].Copy());
            return dsDataSet;
        }

        // top 10 MenuPerMenuGoup per month
        // top 10 Employee per Value per number of Patrons
        // Employee escelation count per month
        // Value sales per hour per month combine  Patrons count per hour per month

        // Table alert linked to a 3 char code before Eployee before alert can be confirmed
         

        #endregion


    }
}