using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace HandUpWCF {
    public class Management {
        public DataSet MenuPerProviderAdminFull(int ProviderID) {

        }

        public DataSet EmployeeListPerProvireAdminFull(int ProviderID) {

        }

        public DataSet AddEmployeePerProviderAdminFull(int ProviderID) {

        }

        public DataSet UpdateEmployeePerProviderAdminFull(int ProviderID) {

        }

        #region Tables

        public DataSet TablesPerProviderAdminFull(int ProviderID,DateTime dtOpen) {

        }

        public DataSet  ReOpenTablesPerProviderAdmin(int ProviderID, DateTime dtOpen) {
            // true is Employee is still active - send only db tbale 
            // false  db tbale and table with active Employees
        }

        public DataSet MoveOrderBetweenTablesPerProviderAdmin(int ProviderID, DateTime dtOpen) {

        }

        public DataSet MoveTableBetweenEmployeePerProviderAdmin(int ProviderID, DateTime dtOpen) {

        }

        public DataSet ChangeOrderValuePerOrderPerProviderAdmin(int ProviderID, DateTime dtOpen) {
            //set order status inctive with reason description 
            // create new order
            // update relevant db tables
        }


        #endregion

        public DataSet TablesPerProviderPerStatusAdminFull(int ProviderID, DateTime dtOpen,int StatusID) {

        }

        public DataSet AddNewMenuItem() {

        }

        public DataSet UpdateMenuItem() {

        }

        public DataSet MenuGroupPerProvider() {

        }

        public DataSet AddMenuGroupPerProvider() {

        }


        public DataSet MenuGroupTypesPerProvider() {

        }

        public DataSet SubMenuGroupTypesPerProvider() {

        }

        public DataSet SubMenuGroupPerProvider() {

        }

        public DataSet AddSubMenuGroupPerProvider() {

        }
        

        #region Reports
        
        public DataSet DefaultReportPerProvider(int ProviderID) {

        }

        // top 10 MenuPerMenuGoup per month
        // top 10 Employee per Value per number of Patrons
        // Employee escelation count per month
        // Value sales per hour per month combine  Patrons count per hour per month

        // Table alert linked to a 3 char code before Eployee before alert can be confirmed
         

        #endregion


    }
}