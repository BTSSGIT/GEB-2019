using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEB_School.Client.UI
{
    public partial class FeeCollection1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTable();

        }

        public void BindTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SrNO", typeof(int));
            dt.Columns.Add("StudentName", typeof(string));
            dt.Columns.Add("GRNo", typeof(int));
            //dt.Columns.Add("txtReceiptNo", typeof(int));
            //dt.Columns.Add("txtAdmissionFees", typeof(int));
            //dt.Columns.Add("txtTermFees", typeof(int));
            //dt.Columns.Add("txtTuitionfees", typeof(int));

            dt.Rows.Add();

            dt.Rows[0]["SrNO"] = 1;
            dt.Rows[0]["StudentName"] = "Rahul Patel";
            dt.Rows[0]["GRNo"] = 1254;
            //dt.Rows[0]["txtReceiptNo"] = 3587;
            //dt.Rows[0]["txtAdmissionFees"] = 3000;
            //dt.Rows[0]["txtTermFees"] = 4000;
            //dt.Rows[0]["txtTuitionfees"] = 5000;
            dt.Rows.Add();
            dt.Rows[1]["SrNO"] = 2;
            dt.Rows[1]["StudentName"] = "Prerak";
            dt.Rows[1]["GRNo"] = 1444;

            dt.Rows.Add();
            dt.Rows[2]["SrNO"] = 3;
            dt.Rows[2]["StudentName"] = "Ish";
            dt.Rows[2]["GRNo"] = 1477;


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    gvfc.DataSource = dt;
                    gvfc.DataBind();


                }
            }

        }



    }
}