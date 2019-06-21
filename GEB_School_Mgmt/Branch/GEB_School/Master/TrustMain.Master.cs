using System;
using System.Data;
using System.Web.UI;
using GEB_School.Common;
using GEB_School.BL;
using GEB_School.BO;
using System.Web.UI.HtmlControls;

namespace GEB_School.Master
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            if (Session["UserName"] != null)
            {
                lblUserName.Text = Session["UserName"].ToString();

                string sPath = Page.Page.AppRelativeVirtualPath;
                // string str= Request.Url.GetLeftPart(UriPartial.Authority);
                string sRet = sPath.Substring(sPath.LastIndexOf('/') + 1);



                RoleRightsBL objRoleRightsBL = new RoleRightsBL();
                ApplicationResult objResults = new ApplicationResult();

                DataTable dtRights = new DataTable();
                int flagMaster = 0;
                int flagSchool = 0;
                int flagInventory = 0;
                int flagPayroll = 0;
                int flagAccounting = 0;
                int flagReport = 0;
                int flagImport = 0;
                int flagRoleRight = 0;
                int flagAttendance = 0;
                int flag = 0;
                int flagVersion = 0;
                int flagResult = 0;
                


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
                        if (dtRights.Rows[i]["DisplayName"].ToString() == "Trust")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Department")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Designation")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Employee")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Document")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Status")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "BackUp")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Role")
                            flagMaster = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Leave")
                            flagMaster = 1;
                        // For attendance
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Attendance")
                            flagAttendance = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ApproveLeave")
                            flagAttendance = 1;

                        //For School
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "School")
                            flagSchool = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ManageSchool")
                            flagSchool = 1;
                        // For Data Import
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "StudentsImport")
                            flagImport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "EmployeeImport")
                            flagImport = 1;

                            //For Inventory
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "MaterialGroup")
                            flagInventory = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Vendor")
                            flagInventory = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Material")
                            flagInventory = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "UOM")
                            flagInventory = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Purchase")
                            flagInventory = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "StockUpdate")
                            flagInventory = 1;
                        //For PayRoll
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "LeaveMaser")
                            flagPayroll = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "PayItem")
                            flagPayroll = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "TrustTemplate")
                            flagPayroll = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "TrustPayItem")
                            flagPayroll = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "EmployeePayItem")
                            flagPayroll = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "GeneratePayslip")
                            flagPayroll = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ProcessPayroll")
                            flagPayroll = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "PayRollReport")
                            flagPayroll = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "LeaveTemplate")
                            flagPayroll = 1;

                        //For Accounting
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "AccountLogin")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "AccountGroup")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "SerialNo")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "GeneralLedger")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "JournalEntry")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ContraEntry")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Receipts")
                            flagAccounting = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "Payments")
                            flagAccounting = 1;

                           //For Reports
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "GeneralReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "InventoryReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "PayRollReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "AccountingReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "StatutoryReports")
                            flagReport = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ExamResultReport")
                            flagReport = 1;
                        // For Result
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "ExamConfiguration")
                            flagResult = 1;
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "StudentExamMarks")
                            flagResult = 1;
                        // For RoleRight
                        else if (dtRights.Rows[i]["DisplayName"].ToString() == "RoleRight")
                            flagRoleRight = 1;
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
                        AttendanceA.Visible = true;
                    }
                    else
                    {
                        AttendanceA.Visible = false;
                    }
                    if (flagRoleRight == 1)
                    {
                        RoleRight.Visible = true;
                    }
                    else
                    {
                        RoleRight.Visible = false;
                    }
                    if (flagVersion == 1)
                    {
                        Versioncontrol.Visible = true;
                    }
                    else
                    {
                        Versioncontrol.Visible = false;
                    }
                    if (flagImport == 1)
                    {
                        Import.Visible = true;
                    }
                    else
                    {
                        Import.Visible = false;
                    }
                    if (flagSchool == 1)
                    {
                        Schoola.Visible = true;
                    }
                    else
                    {
                        Schoola.Visible = false;
                    }
                    if (flagInventory == 1)
                    {
                        Inventory.Visible = true;
                    }
                    else
                    {
                        Inventory.Visible = false;
                    }
                    if (flagPayroll == 1)
                    {
                        Payroll.Visible = true;
                    }
                    else
                    {
                        Payroll.Visible = false;
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
                    //if (flagResult == 1)
                    //{
                    //    Result.Visible = true;
                    //}
                    //else
                    //{
                    //    Result.Visible = false;
                    //}
                    //if (flag == 1)
                    //{
                    //    Response.Redirect("../ClientUI/NotAuthorized.aspx", false);
                    //}
                }
                if (!Page.IsPostBack)
                {
                    //  FetchImage();
                }
            }
            else
            {
                Response.Redirect("../Default.aspx", false);
            }
            // }
        }
        //}

        #region Logout Button
        protected void imbbtnLogout_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Response.Redirect("../UserLogin.aspx", false);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "onBankDetailClick();", true);
        }
        #endregion

        #region Fetch Image
        //public void FetchImage()
        //{
        //    try
        //    {
        //        #region Declaretion
        //        TrustBL objTrustBl = new TrustBL();
        //        DataTable dtTrust = new DataTable();
        //        #endregion
        //        ApplicationResult objResultsEdit = new ApplicationResult();
        //        objResultsEdit = objTrustBl.Trust_Select(Convert.ToInt32(Session[ApplicationSession.TRUSTID]));

        //        if (objResultsEdit != null)
        //        {
        //            dtTrust = objResultsEdit.resultDT;
        //            if (dtTrust.Rows.Count > 0)
        //            {

        //                ViewState["Bytes"] = dtTrust.Rows[0][TrustBO.TRUST_TRUSTLOGO];
        //                if (ViewState["Bytes"].ToString() != "")
        //                {
        //                    imgphoto.ImageUrl = "../Client.UI/GetImage.ashx?TrustMID=" + Convert.ToInt32(Session[ApplicationSession.TRUSTID]);

        //                }
        //                ViewState["Bytes"] = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //DisplayErrorMsg("CommonError", ex);
        //    }
        //}
        #endregion
    }
}