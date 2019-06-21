using System;
using System.Data;
using System.Web.UI;
using GEB_School.Common;
using GEB_School.BL;
using GEB_School.BO;
using System.Web.UI.HtmlControls;

namespace GEB_School.Master
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
		private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		protected void Page_Load(object sender, EventArgs e)
		{
            //if (!IsPostBack)
            //{
				if (Session["UserName"] != null)
				{
					lblUserName.Text = Session["UserName"].ToString();
                lblSchoolName.Text = Session[ApplicationSession.SCHOOLNAME].ToString();

                     string sPath = Page.Page.AppRelativeVirtualPath;
                // string str= Request.Url.GetLeftPart(UriPartial.Authority);
                string sRet = sPath.Substring(sPath.LastIndexOf('/') + 1);

                if (Convert.ToInt32(Session[ApplicationSession.ISPANEL].ToString()) != 0)
                {
                    divTransfer.Visible = false;
                }
                else
                {
                    divTransfer.Visible = true;
                }


                RoleRightsBL objRoleRightsBL = new RoleRightsBL();
                ApplicationResult objResults = new ApplicationResult();

                DataTable dtRights = new DataTable();
                int flagMaster = 0;
                int flagTimeTable = 0;
                int flagInventory = 0;
                int flagFees = 0;
                int flagAccounting = 0;
                int flagReport = 0;
                int flagStudent = 0;
                int flagAttendance= 0;
                int flagResult = 0;
                int flag = 0;
                int flagVersion = 0;


                objResults = objRoleRightsBL.RoleRights_T_For_Authorisation(Convert.ToInt32(Session[ApplicationSession.ROLEID].ToString()), Convert.ToInt32(Session[ApplicationSession.TRUSTID].ToString()), Convert.ToInt32(Session[ApplicationSession.SCHOOLID].ToString()));
                if (objResults != null)
                {

                    dtRights = objResults.resultDT;
                    for (int i = 0; i < dtRights.Rows.Count; i++)
                    {
                        #region Menu Hide
                        Control MyList = FindControl("cssmenu");
                        foreach (Control MyControl in MyList.Controls)
                        {
                            if (MyControl is HtmlGenericControl)
                            {
                                HtmlGenericControl li = MyControl as HtmlGenericControl;

                                if (li.ID == dtRights.Rows[i]["DisplayName"].ToString())
                                {
                                    li.Visible = true;
                                    break;
                                }
                            }
                        }
                        //For Masterli
                        if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolDepartment")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolDesignation")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Section")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Class")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolEmployee")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "DisplayPriority")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Holiday")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ApplyLeave")
                            flagMaster = 1;
                         //Attendance
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "StudentAttendence")
                            flagAttendance = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "EmployeeAttendence")
                            flagAttendance = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolApproveLeave")
                            flagAttendance = 1;
                        //For TimeTable
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Subject")
                            flagTimeTable = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Period")
                            flagTimeTable = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SubjectAssociation")
                            flagTimeTable = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "TimeTable")
                            flagTimeTable = 1;
                        // For Student
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Registration")
                            flagStudent = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Upgradation")
                            flagStudent = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "DivisionTransfer")
                            flagStudent = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "PastEducationDetail")
                            flagStudent = 1;
                            //For Fees
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "FeesCategory")
                            flagFees = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "FeesGroup")
                            flagFees = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ClassFeesTemplate")
                            flagFees = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "StudentFeesTemplate")
                            flagFees = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "FeesCollection")
                            flagFees = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "FeesCancellation")
                            flagFees = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ClassWiseStudentTemplate")
                            flagFees = 1;
                            //For Inventory
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Inventory")
                            flagInventory = 1;
                          
                        //For Accounting
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolAccountLogin")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolAccountGroup")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolSerialNo")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolGeneralLedger")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolJournalEntry")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolContraEntry")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolReceipts")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolPayments")
                            flagAccounting = 1;

                           //For Reports
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "GeneralReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolStudentReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolStudentReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolFeesReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolInventoryReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolPayRollReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolAccountingReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolStatutoryReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SchoolTimeTableReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "DEOReport")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ExamResultReport")
                            flagReport = 1;
                        //For Result

                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ResultCreation")
                            flagResult = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Exam")
                            flagResult = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ClassExamAssociation")
                            flagResult = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ClassSubjectAssociation")
                            flagResult = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "StudentSubjectAssociation")
                            flagResult = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Grade")
                            flagResult = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ExamConfiguration")
                            flagResult = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "FinalResult")
                            flagResult = 1;
                       


                            
                        // For Version Control
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Versioncontrol")
                            flagVersion = 1;
                        #endregion
                        


                    }
                    if (sRet != "NotAuthorized.aspx")
                    {
                        for (int j = 0; j < dtRights.Rows.Count; j++)
                        {
                            #region Not Authorized

                            if (sRet == "Home.aspx")
                            {
                                flag = 0;
                                break;
                            }
                            if (dtRights.Rows[j]["ScreenName"].ToString() == sRet)
                            {
                                flag = 0;
                                break;
                            }
                            //else
                            //{
                            //    flag = 1;
                            //}

                            #endregion
                        }
                    }
                    if (flagMaster == 1)
                    {
                        Master.Visible = true;
                    }
                    else
                    {
                        Master.Visible = false;
                    }

                    if (flagAttendance == 1)
                    {
                        SchoolAttendanceA.Visible = true;
                    }
                    else
                    {
                        SchoolAttendanceA.Visible = false;
                    }

                    if (flagTimeTable == 1)
                    {
                        TimeTablea.Visible = true;
                    }
                    else
                    {
                        TimeTablea.Visible = false;
                    }
                    if (flagStudent == 1)
                    {
                        Student.Visible = true;
                    }
                    else
                    {
                        Student.Visible = false;
                    }
                    if (flagInventory == 1)
                    {
                        Inventorya.Visible = true;
                    }
                    else
                    {
                        Inventorya.Visible = false;
                    }
                    //if (flagVersion == 1)
                    //{
                    //    Versioncontrol.Visible = true;
                    //}
                    //else
                    //{
                    //    Versioncontrol.Visible = false;
                    //}
                    if (flagFees == 1)
                    {
                        Fees.Visible = true;
                    }
                    else
                    {
                        Fees.Visible = false;
                    }
                    //if (flagAccounting == 1)
                    //{
                    //    Accounting.Visible = true;
                    //}
                    //else
                    //{
                    //    Accounting.Visible = false;
                    //}
                    if (flagReport == 1)
                    {
                        Report.Visible = true;
                    }
                    else
                    {
                        Report.Visible = false;
                    }
                    if (flagResult == 1)
                    {
                        Result.Visible = true;
                    }
                    else
                    {
                        Result.Visible = false;
                    }
                }


                    if (!Page.IsPostBack)
                    {
                        FetchImage();
                    }
				}
				else
				{
					Response.Redirect("../UserLogin.aspx");
				}
			}

		#region Logout Button
		protected void imbbtnLogout_Click(object sender, ImageClickEventArgs e)
		{
			Session.Clear();
			Response.Redirect("../UserLogin.aspx", false);
		}
		#endregion

        #region Fetch Image
        public void FetchImage()
        {
            try
            {
                #region Declaretion
                SchoolBL objSchoolBl = new SchoolBL();
                DataTable dtSchool = new DataTable();
                #endregion
                ApplicationResult objResultsEdit = new ApplicationResult();
                objResultsEdit = objSchoolBl.School_Select(Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));

                if (objResultsEdit != null)
                {
                    dtSchool = objResultsEdit.resultDT;
                    if (dtSchool.Rows.Count > 0)
                    {
                       
                            ViewState["Bytes"] = dtSchool.Rows[0][SchoolBO.SCHOOL_SCHOOLLOGO];
                            if (ViewState["Bytes"].ToString() != "")
                            {
                                imgphoto.ImageUrl = "../Client.UI/GetImage.ashx?SchoolMID=" + Convert.ToInt32(Session[ApplicationSession.SCHOOLID]);

                            }
                            ViewState["Bytes"] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                //DisplayErrorMsg("CommonError", ex);
            }
        }
        #endregion

    }
}