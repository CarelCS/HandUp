using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace HandupRESTWCF {
    public class Utilities {

        public string ConvertToJSON(DataSet ds) {
            System.Web.Script.Serialization.JavaScriptSerializer serializer =
           new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows =

       new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in ds.Tables[0].Rows) {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in ds.Tables[0].Columns) {
                    row.Add(col.ColumnName.Trim(), dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }  
    }
}