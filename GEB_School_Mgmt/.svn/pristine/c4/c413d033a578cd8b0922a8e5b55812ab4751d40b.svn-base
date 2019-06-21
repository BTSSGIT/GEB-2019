using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using GEB_School.Bl;
using GEB_School.BL;
using GEB_School.Bo;
using GEB_School.BO;
using GEB_School.Common;
using GEB_School.DataAccess;

namespace GEB_School.Leave
{
    public partial class ApplyLeave : System.Web.UI.Page
    {
        private static ILog logger = LogManager.GetLogger(typeof(Leave));

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    btnApply.Enabled = false;
                    BindCheckEmployee();
                    PanelVisibilityMode(1);
                    BindLeaveBalance();
                    BindApplyLeave();
                    divDate.Visible = false;
                }
                catch (Exception ex)
                {
                    logger.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
        }
        #endregion



        #region Bind Check Employee
        private void BindCheckEmployee()
        {
            int EmployeeMID = Convert.ToInt32(Session[ApplicationSession.USERID]);
            if (EmployeeMID == 1)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You are not authorise for apply leave.');</script>");
            }
            else
            {
                btnApply.Enabled = true;
            }

        }
        #endregion

        #region Bind Leave Type
        private void BindLeaveType()
        {
            try
            {
                LeaveBl objLeaveBl = new LeaveBl();
                ApplicationResult objResults = new ApplicationResult();
                Controls objControls = new Controls();
                for (int i = 0; i < gvLeave.Rows.Count; i++)
                {
                    DropDownList ddlLeaveType = (DropDownList)gvLeave.Rows[i].Cells[3].FindControl("ddlLeaveType");
                    objResults = objLeaveBl.Leave_SelectAll_ForApply();
                    if (objResults != null)
                    {
                        if (objResults.resultDT.Rows.Count > 0)
                        {
                            objControls.BindDropDown_ListBox(objResults.resultDT, ddlLeaveType, "LeaveName", "LeaveID");
                        }
                        ddlLeaveType.Items.Insert(0, new ListItem("-Select-", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }

        }
        #endregion

        #region Bind Leave Balance
        private void BindLeaveBalance()
        {
            LeaveBl objLeaveBl = new LeaveBl();
            var objResult =
                objLeaveBl.Leave_Select_ForBalance(Convert.ToInt32(Session[ApplicationSession.USERID].ToString()));
            if (objResult != null)
            {
                if (objResult.resultDT.Rows.Count > 0)
                {
                    gvLeaveBalance.DataSource = objResult.resultDT;
                    gvLeaveBalance.DataBind();
                    txtFromDate.Enabled = true;
                    txtToDate.Enabled = true;
                    btnApply.Enabled = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Leave Template has not created.Please Create Leave Template first.');</script>");
                    txtFromDate.Enabled = false;
                    txtToDate.Enabled = false;
                    btnApply.Enabled = false;
                }
            }
        }
        #endregion

        #region Bind Apply Leaves
        private void BindApplyLeave()
        {
            ApplicationResult objResult = new ApplicationResult();
            LeaveApplyBl objLeaveApplyBl = new LeaveApplyBl();

            objResult = objLeaveApplyBl.LeaveApply_Select(0,Convert.ToInt32(Session[ApplicationSession.USERID].ToString()));
            if (objResult != null)
            {
                if (objResult.resultDT.Rows.Count > 0)
                {
                    gvLeaveApprove.DataSource = objResult.resultDT;
                    gvLeaveApprove.DataBind();
                    divLeaveApprove.Visible = true;
                }
                else
                {
                    divLeaveApprove.Visible = false;
                }
            }
        }
        #endregion 



        #region Go Button Click Event
        protected void btnApply_OnClick(object sender, EventArgs e)
        {
            try
            {
               // DateTime dtFromDate = Convert.ToDateTime(txtFromDate.Text);
                DateTime dtFromDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dtToDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
               // DateTime dtToDate = Convert.ToDateTime(txtToDate.Text);
                //DateTime dtFromDate = DateTime.Parse(txtFromDate.Text, new CultureInfo("en-CA"));
                //DateTime dtToDate = DateTime.Parse(txtToDate.Text, new CultureInfo("en-CA"));
                int Compare = DateTime.Compare(dtFromDate, dtToDate);
                if (Compare > 0)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Select Proper Date.');</script>");
                }
                else
                {
                    TimeSpan tsdifference = dtToDate - dtFromDate;
                    var days = tsdifference.TotalDays;
                    days = days + 1;
                    ViewState["TotalDays"] = days;
                    DataTable dt = new DataTable();
                    dt.Rows.Clear();
                    dt.Columns.Add("NO");
                    for (var i = 0; i < days; i++)
                    {
                        dt.Rows.Add(this.ToString());
                    }
                    gvLeave.DataSource = dt;
                    gvLeave.DataBind();
                    DateTime dtDate = dtFromDate;
                    for (var i = 0; i < days; i++)
                    {
                        ((TextBox) (gvLeave.Rows[i].Cells[0].FindControl("txtGridDates"))).Enabled = false;
                        if (i == 0)
                        {
                            ((TextBox)(gvLeave.Rows[i].Cells[0].FindControl("txtGridDates"))).Text = dtDate.ToString("dd/MM/yyyy");
                            dtDate = dtFromDate.AddDays(1);
                        }
                        else
                        {

                            ((TextBox)(gvLeave.Rows[i].Cells[0].FindControl("txtGridDates"))).Text = dtDate.ToString("dd/MM/yyyy");
                            dtDate = dtDate.AddDays(1);
                        }

                    }
                    BindLeaveType();
                    PanelVisibilityMode(2);
                }
                
                
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region Save Button click Event
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                LeaveApplyBl objLeaveApplyBl = new LeaveApplyBl();
                LeaveApplyBo objLeaveApplyBo = new LeaveApplyBo();
                LeaveApprovalBo objLeaveApprovalBo = new LeaveApprovalBo();
                LeaveApprovalBl objLeaveApprovalBl = new LeaveApprovalBl();
                ApplicationResult objResult = new ApplicationResult();
                double dbTotalDays = 0.0;
                foreach (GridViewRow row in gvLeave.Rows)
                {
                    if (((CheckBox) row.FindControl("cbHalfDay")).Checked)
                    {
                        dbTotalDays += 0.5;
                    }
                    else
                    {
                        dbTotalDays += 1;
                    }
                }

                objLeaveApplyBo.FromDate = txtFromDate.Text;
                objLeaveApplyBo.ToDate = txtToDate.Text;
                objLeaveApplyBo.Reason = txtReason.Text.Trim();
                objLeaveApplyBo.EmployeeMID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                objLeaveApplyBo.TotalDays = Convert.ToDouble(dbTotalDays);
                objLeaveApplyBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.USERID]);
                objLeaveApplyBo.CreatedDate = DateTime.UtcNow.AddDays(5.5).ToString();
                objLeaveApplyBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.USERID]);
                objLeaveApplyBo.LastModifiedDate = DateTime.UtcNow.AddDays(5.5).ToString();

                DatabaseTransaction.OpenConnectionTransation();
                int intLeaveApplyID = 0;
                objResult = objLeaveApplyBl.LeaveApply_Insert(objLeaveApplyBo);
                if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                {
                    //ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record saved successfully.');</script>");
                    //ClearAll();
                    if ((objResult.resultDT.Rows[0]["LeaveApplylID"].ToString()) != "")
                    {
                        intLeaveApplyID = Convert.ToInt32(objResult.resultDT.Rows[0]["LeaveApplylID"].ToString());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('You have already apply leave between this dates.');</script>");
                        return;
                    }
                }
                int a = 0;
                int b = 0;

                foreach (GridViewRow row in gvLeave.Rows)
                {
                     a += 1;
                    objLeaveApprovalBo.LeaveApplyID = intLeaveApplyID;
                    objLeaveApprovalBo.ApplyDate = (((TextBox)row.FindControl("txtGridDates")).Text);
                    objLeaveApprovalBo.LeaveID = Convert.ToInt32((((DropDownList) row.FindControl("ddlLeaveType")).SelectedValue));
                    objLeaveApprovalBo.IsHalfDay = Convert.ToInt32((((CheckBox) row.FindControl("cbHalfDay")).Checked));
                    objLeaveApprovalBo.CreatedBy = Convert.ToInt32(Session[ApplicationSession.USERID]);
                    objLeaveApprovalBo.CreatedDate = DateTime.UtcNow.AddDays(5.5).ToString();
                    objLeaveApprovalBo.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.USERID]);
                    objLeaveApprovalBo.LastModifiedDate = DateTime.UtcNow.AddDays(5.5).ToString();

                    var objResultApproval = objLeaveApprovalBl.LeaveApproval_Insert(objLeaveApprovalBo);
                    if (objResultApproval != null)
                    {
                        if (objResultApproval.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {
                            b += 1;
                        }
                    }
                }
                if (a == b)
                {
                    DatabaseTransaction.CommitTransation();
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record saved successfully.');</script>");
                    ClearAll();
                    PanelVisibilityMode(1);
                    divLeaveApprove.Visible = true;
                    divDate.Visible = false;
                    BindApplyLeave();
                }
            }
            catch (Exception ex)
            {
                DatabaseTransaction.RollbackTransation();
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof (Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
            finally
            {
                DatabaseTransaction.connection.Close();
            }
        }
        #endregion

        #region Button ApplyLeave Click Event
        protected void btnApplyLeave_OnClick(object sender, EventArgs e)
        {
            try
            {
                divDate.Visible = true;
                divLeaveApprove.Visible = false;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion


        #region Leave Approve GridView Events [Row Command, Pre Render]

        protected void gvLeaveApprove_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                LeaveApplyBl objLeaveApplyBl = new LeaveApplyBl();

                if (e.CommandName.ToString() == "Delete1")
                {
                    var objResult = objLeaveApplyBl.LeaveApply_Delete(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(Session[ApplicationSession.USERID]), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult != null)
                    {
                        if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {
                            BindApplyLeave();
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Leave has been successfully cancelled');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }

        protected void gvLeaveApprove_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvLeaveApprove.Rows.Count > 0)
                {
                    gvLeaveApprove.UseAccessibleHeader = true;
                    gvLeaveApprove.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion



        #region PanelVisibilityMode
        private void PanelVisibilityMode(int intMode)
        {
            if (intMode == 1)
            {
                divPanel.Visible = true;
                divGrid.Visible = false;
            }
            else if (intMode == 2)
            {
                divPanel.Visible = false;
                divGrid.Visible = true;
            }
        }
        #endregion

        #region Clear All Method
        public void ClearAll()
        {
            Controls objControl = new Controls();
            objControl.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            ViewState["Mode"] = "Save";
        }
        #endregion

    }
}