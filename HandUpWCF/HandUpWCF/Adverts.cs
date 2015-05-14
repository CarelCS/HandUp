using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HandUpWCF.DBClasses;

namespace HandUpWCF {
    public class Adverts {
        public int PKiAdvertID { get; set; }
        public int FKiProviderID { get; set; }
        public string sAdvertURL { get; set; }
        public string imgAdvertImage { get; set; }

        public DataSet AllAdvertsAvailableForProvider(int ProviderID) {
            tblAdverts aAdverts = new tblAdverts();
            string sSql = "SELECT tblAdverts.* FROM tblAdverts " +
                "WHERE tblAdverts." + tblAdverts._FKIPROVIDERID + "= " + ProviderID;
            DataSet aDataset = aAdverts.executeCustomSQLDataSet(sSql);
            return aDataset;
        }
    }
}