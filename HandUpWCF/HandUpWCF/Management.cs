using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace HandUpWCF {
    public class Management {
        public DataSet MenuPerProviderAdminFull(int ProviderID) {
            DataSet ds = new DataSet();
            return ds;
        }

        public DataSet EmployeeListPerProvireAdminFull(int ProviderID) {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet AddEmployeePerProviderAdminFull(int ProviderID) {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet UpdateEmployeePerProviderAdminFull(int ProviderID) {
            DataSet ds = new DataSet();
            return ds;

        }

        #region Tables

        public DataSet TablesPerProviderAdminFull(int ProviderID, DateTime dtOpen) {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet ReOpenTablesPerProviderAdmin(int ProviderID, DateTime dtOpen) {
            DataSet ds = new DataSet();
            return ds;
            // true is Employee is still active - send only db tbale 
            // false  db tbale and table with active Employees
        }

        public DataSet MoveOrderBetweenTablesPerProviderAdmin(int ProviderID, DateTime dtOpen) {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet MoveTableBetweenEmployeePerProviderAdmin(int ProviderID, DateTime dtOpen) {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet ChangeOrderValuePerOrderPerProviderAdmin(int ProviderID, DateTime dtOpen) {
            DataSet ds = new DataSet();
            return ds;
            //set order status inctive with reason description 
            // create new order
            // update relevant db tables
        }


        #endregion

        public DataSet TablesPerProviderPerStatusAdminFull(int ProviderID, DateTime dtOpen, int StatusID) {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet AddNewMenuItem() {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet UpdateMenuItem() {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet MenuGroupPerProvider() {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet AddMenuGroupPerProvider() {
            DataSet ds = new DataSet();
            return ds;

        }


        public DataSet MenuGroupTypesPerProvider() {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet SubMenuGroupTypesPerProvider() {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet SubMenuGroupPerProvider() {
            DataSet ds = new DataSet();
            return ds;

        }

        public DataSet AddSubMenuGroupPerProvider() {
            DataSet ds = new DataSet();
            return ds;

        }
        

        #region Reports

        public DataSet DefaultReportPerProvider(int ProviderID) {
            DataSet ds = new DataSet();
            return ds;

        }

        // top 10 MenuPerMenuGoup per month
        // top 10 Employee per Value per number of Patrons
        // Employee escelation count per month
        // Value sales per hour per month combine  Patrons count per hour per month

        // Table alert linked to a 3 char code before Eployee before alert can be confirmed
         

        #endregion


    }
}