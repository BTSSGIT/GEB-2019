using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEB_School.Client.UI
{
    public partial class SchoolReports : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Mode"] == "SchoolGeneralReports")
                {
                    divGeneralReports.Visible = true;
                    divFees.Visible = false;
                    divInventory.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divTimeTable.Visible = false;
                    divDEOReports.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "SchoolStudentReports")
                {
                    divStatutory.Visible = true;
                    divGeneralReports.Visible = false;
                    divFees.Visible = false;
                    divInventory.Visible = false;
                    divAccounting.Visible = false;
                    divTimeTable.Visible = false;
                    divDEOReports.Visible = false;

                }
                else if (Request.QueryString["Mode"] == "SchoolFeesReports")
                {
                    divGeneralReports.Visible = false;
                    divFees.Visible = true;
                    divInventory.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divTimeTable.Visible = false;
                    divDEOReports.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "SchoolInventoryReports")
                {
                    divGeneralReports.Visible = false;
                    divFees.Visible = false;
                    divInventory.Visible = true;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divTimeTable.Visible = false;
                    divDEOReports.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "SchoolPayrollReports")
                {
                    divGeneralReports.Visible = false;
                    divFees.Visible = false;
                    divInventory.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divTimeTable.Visible = false;
                    divDEOReports.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "SchoolAccountingReports")
                {
                    divGeneralReports.Visible = false;
                    divFees.Visible = false;
                    divInventory.Visible = false;
                    divStatutory.Visible = false;
                    divTimeTable.Visible = false;
                    divDEOReports.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "SchoolStatutoryReports")
                {
                    divStatutory.Visible = true;
                    divGeneralReports.Visible = false;
                    divFees.Visible = false;
                    divInventory.Visible = false;
                    divTimeTable.Visible = false;
                    divAccounting.Visible = false;
                    divDEOReports.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "SchoolTimeTableReports")
                {
                    divGeneralReports.Visible = false;
                    divFees.Visible = false;
                    divInventory.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divTimeTable.Visible = true;
                    divDEOReports.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "SchoolDEOReports")
                {
                    divGeneralReports.Visible = false;
                    divFees.Visible = false;
                    divInventory.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divTimeTable.Visible = false;
                    divDEOReports.Visible = true;
                }
                else
                {
                    divGeneralReports.Visible = true;
                    divFees.Visible = true;
                    divInventory.Visible = true;
                    divAccounting.Visible = true;
                    divStatutory.Visible = true;
                    divTimeTable.Visible = true;
                    divDEOReports.Visible = true;
                }
            }
        }
    }
}