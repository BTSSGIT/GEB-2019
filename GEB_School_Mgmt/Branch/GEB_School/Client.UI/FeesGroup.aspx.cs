using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GEB_School.BO;
using GEB_School.BL;
using GEB_School.Common;
using GEB_School.DataAccess;
using log4net;



namespace GEB_School.Client.UI
{
    public partial class FeesGroup : PageBase
    {
        private static ILog logger = LogManager.GetLogger(typeof(FeesGroup));
        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("../UserLogin.aspx");
            }
            if (!Page.IsPostBack)
            {
                try
                {
                    BindFeesGroup();
                    ViewState["Mode"] = "Save";
                    ViewState["FeesGroupID"] = 0;
                   // BindGeneralLedger();
                }
                catch (Exception ex)
                {
                    logger.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
        }
        #endregion



        #region BindFeesGroup

        public void BindFeesGroup()
        {
            try
            {
                FeesGroupBl objFeesGroupBL = new FeesGroupBl();
                ApplicationResult objResult = new ApplicationResult();

                objResult = objFeesGroupBL.FeesGroup_SelectAll(Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));
                if (objResult != null)
                {
                    gvFeesGroup.DataSource = objResult.resultDT;
                    gvFeesGroup.DataBind();
                    if (gvFeesGroup.Rows.Count > 0)
                    {
                        PanelGrid_VisibilityMode(1);
                    }
                    else
                    {
                        PanelGrid_VisibilityMode(2);
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

        //#region BindGeneralLedger
        //public void BindGeneralLedger()
        //{
        //    try
        //    {
        //        FeesGroupBl ObjFeesGroupBL = new FeesGroupBl();
        //        ApplicationResult objResult = new ApplicationResult();
        //        Controls objControls = new Controls();


        //        objResult = ObjFeesGroupBL.GeneralLedger_SelectAll_FeesGroup_dropdown(Convert.ToInt32(Session[ApplicationSession.SCHOOLID]), Convert.ToInt32(Session[ApplicationSession.TRUSTID]));
        //        if (objResult != null)
        //        {
        //            if (objResult.resultDT.Rows.Count > 0)
        //            {
        //                objControls.BindDropDown_ListBox(objResult.resultDT, ddlLedger, "AccountName", "LedgerID");
        //                ddlLedger.Items.Insert(0, new ListItem("-Select-", ""));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Error", ex);
        //        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
        //    }
        //}
        //#endregion



        #region Add new Button Click Event
        protected void lnkAddNewFeesGroup_Click(object sender, EventArgs e)
        {
            ClearAll();
            PanelGrid_VisibilityMode(2);
        }
        #endregion

        #region Save Button Click Event
        protected void btnSaveFeesGroup_Click(object sender, EventArgs e)
        {
            try
            {
                FeesGroupBo objFeesGroupBO = new FeesGroupBo();
                FeesGroupBl objFeesGroupBL = new FeesGroupBl();
                ApplicationResult objResults = new ApplicationResult();
                Controls objControls = new Controls();

                objFeesGroupBO.TrustMID = Convert.ToInt32(Session[ApplicationSession.TRUSTID]);
                objFeesGroupBO.SchoolMID = Convert.ToInt32(Session[ApplicationSession.SCHOOLID]);
                objFeesGroupBO.FeeGroupName = txtFeesGroupName.Text.Trim();
                objFeesGroupBO.Description = txtDescription.Text.Trim();

                if (ViewState["Mode"].ToString() == "Save")
                {
                    objFeesGroupBO.CreatedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                    objFeesGroupBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString();

                    objResults = objFeesGroupBL.FeesGroup_Insert(objFeesGroupBO);

                    if (objResults.status == ApplicationResult.CommonStatusType.SUCCESS)
                    {
                        ClearAll();
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Fees Group Created Successfully.');</script>");
                        BindFeesGroup();
                        PanelGrid_VisibilityMode(1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Fees Group Name already Exists.');</script>");
                    }

                }
                else
                {
                    objFeesGroupBO.FeesGroupID = Convert.ToInt32(ViewState["FeesGroupID"].ToString());
                    objFeesGroupBO.LastModifiedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                    objFeesGroupBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();

                    objResults = objFeesGroupBL.FeesGroup_Update(objFeesGroupBO);
                    if (objResults.status == ApplicationResult.CommonStatusType.SUCCESS)
                    {

                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='JavaScript'>alert('Fees Group updated successfully.');</script>");

                        BindFeesGroup();
                        ClearAll();
                        ViewState["Mode"] = "Save";
                        //  btnSave.Text = "Save";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='JavaScript'>alert('Fees Group Name already Exists.');</script>");
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

        #region ViewList Click Event
        protected void lnkViewList_Click(object sender, EventArgs e)
        {
            ClearAll();
            PanelGrid_VisibilityMode(1);
        }
        #endregion



        #region FeesGroup GridView Events [RowCommand,PreRender]
        protected void gvFeesGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                FeesGroupBl objFeesGroupBL = new FeesGroupBl();

                if (e.CommandName.ToString() == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["FeesGroupID"] = e.CommandArgument.ToString();

                    objResult = objFeesGroupBL.FeesGroup_Select(Convert.ToInt32(e.CommandArgument.ToString()));
                    if (objResult != null)
                    {
                        if (objResult.resultDT.Rows.Count > 0)
                        {
                            txtFeesGroupName.Text = objResult.resultDT.Rows[0][FeesGroupBo.FEESGROUP_FEEGROUPNAME].ToString();
                            txtDescription.Text = objResult.resultDT.Rows[0][FeesGroupBo.FEESGROUP_DESCRIPTION].ToString();
                            PanelGrid_VisibilityMode(2);
                        }
                    }
                }
                else if (e.CommandName.ToString() == "Delete1")
                {
                    objResult = objFeesGroupBL.FeesGroup_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.USERID]), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully');</script>");
                        PanelGrid_VisibilityMode(1);
                        BindFeesGroup();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvFeesGroup_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvFeesGroup.Rows.Count > 0)
                {
                    gvFeesGroup.UseAccessibleHeader = true;
                    gvFeesGroup.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
           
        }
        #endregion



        #region PanelGrid_VisibilityMode

        private void PanelGrid_VisibilityMode(int intMode)
        {
            if (intMode == 1)
            {
                divGrid.Visible = true;
                tabs.Visible = false;
                lnkViewList.Visible = false;
            }
            else if (intMode == 2)
            {

                divGrid.Visible = false;
                tabs.Visible = true;
                lnkAddNewFeesGroup.Visible = true;
                lnkViewList.Visible = true;
                
            }
        }

        #endregion PanelGrid_VisibilityMode

        #region ClearAll Method
        private void ClearAll()
        {
            Controls objControl = new Controls();
            objControl.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            ViewState["Mode"] = "Save";

        }
        #endregion
    }
}