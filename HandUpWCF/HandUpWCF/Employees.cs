using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandUpWCF {
    public class Employees {
        public int PKiEmployeeID { get; set; }
        public string sEmployeeName { get; set; }
        public string sEmployeeSurname { get; set; }
        public string sEmployeeID { get; set; }
        public string sEmployeeEmail { get; set; }
        public string sEmployeeTel { get; set; }
        public string sEmployeeAddress1 { get; set; }
        public string sEmployeeAddress2 { get; set; }
        public string sEmployeeAddress3 { get; set; }
        public string sEmployeeNationality { get; set; }
        public string sUserName { get; set; }
        public string sPassword { get; set; }
        public int FKiEmployeeType { get; set; }
        public DateTime dtStartDate { get; set; }
        public DateTime dtEndDate { get; set; }
        public string bGender { get; set; }
        public int FKiProviderID { get; set; }
        public string bActiveStatus { get; set; }
    }
}