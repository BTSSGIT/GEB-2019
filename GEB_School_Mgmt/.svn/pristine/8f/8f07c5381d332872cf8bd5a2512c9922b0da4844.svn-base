using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net;
using GEB_School.BL;
using GEB_School.Common;
using GEB_School.BO;

namespace GEB_School.RTE
{
    public partial class STDWise : System.Web.UI.Page
    {
        public void PanelVisibilityMode1(bool Search, bool Grid)
        {
            divTitle.Visible = Search;
            gvRTEReport.Visible = Grid;
        }
        private static ILog logger = LogManager.GetLogger(typeof(STDWise));
        #region PageLoad Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("../UserLogin.aspx");
                }
                if (!IsPostBack)
                {
                    btnPrintDetail.Visible = false;
                    //btnBack.Visible = false;
                    //divEmployee.Visible = false;
                    //gvRTEReport.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion


        #region Get Student Web Service Method
        [System.Web.Services.WebMethod]
        public static string[] GetAllEmployeeNameForReport(string prefixText, int TrustMID, int SchoolMID)
        {
            StudentBL objStudentbl = new StudentBL();
            ApplicationResult objResult = new ApplicationResult();
            //string strSearchText = prefixText + "%";
            List<string> result = new List<string>();
            //objResult = objStudentbl.Student_SelectAll(strSearchText);
            if (objResult != null)
            {
                for (int i = 0; i < objResult.resultDT.Rows.Count; i++)
                {
                    string strStudentName = objResult.resultDT.Rows[i]["StudentName"].ToString();
                    string strStudentMID = objResult.resultDT.Rows[i][StudentBO.STUDENT_STUDENTMID].ToString();
                    result.Add(string.Format("{0}~{1}", strStudentName, strStudentMID));
                }
            }
            return result.ToArray();
        }

        #endregion

        #region Go button Event
        protected void btnGo_Click(object sender, EventArgs e)
        {


            StudentBL objStudentBL = new StudentBL();
            ApplicationResult objResult = new ApplicationResult();
            //objResult = objStudentBL.Student_Select_ClassDivisionWise(Convert.ToInt32(ddlStudentClass.SelectedValue),0,"0",Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));
            objResult = objStudentBL.Student_Select_byStudentClass((ddlStudentClass.SelectedValue), 2);
           // objResult = objStudentBL.Student_Select_byStudentClass((ddlStudentClass.SelectedValue));
            //search by class

            if (objResult != null)
            {
                ddlStudentClass.DataSource = objResult.resultDT;
                ddlStudentClass.DataBind();
            }

            PanelVisibilityMode1(true, true);


        }
        #endregion







        #region Print Button Click Event
        protected void btnPrintDetail_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "getPrint('divEmployee1');", true);
        }
        #endregion

        #region Report Button Event
        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Client.UI/SchoolReports.aspx?Mode=SchoolGeneralReports");
        }
        #endregion
    }
}