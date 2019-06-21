using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEB_School.Client.UI
{
    public partial class TrustReports : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Mode"] == "GeneralReports")
                {
                    divGeneralReports.Visible = true;
                    divInventory.Visible = false;
                    divPayRoll.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divFeesCollection.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "InventoryReports")
                {
                    divGeneralReports.Visible = false;
                    divInventory.Visible = true;
                    divPayRoll.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divFeesCollection.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "PayRollReports")
                {
                    divGeneralReports.Visible = false;
                    divInventory.Visible = false;
                    divPayRoll.Visible = true;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divFeesCollection.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "AccountingReports")
                {
                    divGeneralReports.Visible = false;
                    divInventory.Visible = false;
                    divPayRoll.Visible = false;
                    divAccounting.Visible = true;
                    divStatutory.Visible = false;
                    divFeesCollection.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "StatutoryReports")
                {
                    divGeneralReports.Visible = false;
                    divInventory.Visible = false;
                    divPayRoll.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = true;
                    divFeesCollection.Visible = false;
                }
                else if (Request.QueryString["Mode"] == "FeesReport")
                {
                    divGeneralReports.Visible = false;
                    divInventory.Visible = false;
                    divPayRoll.Visible = false;
                    divAccounting.Visible = false;
                    divStatutory.Visible = false;
                    divFeesCollection.Visible = true;
                }
                else
                {
                    divGeneralReports.Visible = true;
                    divInventory.Visible = true;
                    divPayRoll.Visible = true;
                    divAccounting.Visible = true;
                    divStatutory.Visible = true;
                    divFeesCollection.Visible = false;
                }
            }
        }
    }
}