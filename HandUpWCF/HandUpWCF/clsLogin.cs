using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;

namespace HandUpWCF {
    public class clsLogin {
        public DataSet Login(string sUserName, string sPassword) {
            tblEmployees aUser = new tblEmployees();
            aUser.addEquals(tblEmployees._SUSERNAME, sUserName);
            aUser.addAND();
            aUser.addEquals(tblEmployees._SPASSWORD, sPassword);
            DataSet aDataSet = aUser.executeSelectDataSet();
            return aDataSet;
            /*DataAdapters newAdapter = new DataAdapters();
            string sSqlQuery = "Select * from tblEmployees inner join tblluemployeetype on FKiEmployeeType = PKiEmployeeTypeID where sUserName = '" + sUserName + "' and sPassword = '" + sPassword + "'";
            DataSet newDs = newAdapter.RetrieveTable(sSqlQuery);
            string ThisValue = "";
            try {
                ThisValue = newDs.Tables[0].Rows[0][1].ToString() + " " + newDs.Tables[0].Rows[0][2].ToString();
            }
            catch { }
            return newDs;
             */
        }
    }
}