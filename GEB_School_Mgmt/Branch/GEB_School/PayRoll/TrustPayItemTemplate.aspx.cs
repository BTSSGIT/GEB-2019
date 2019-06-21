using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using GEB_School.Common;
using GEB_School.BL;
using GEB_School.BO;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using log4net;
using System.Web.UI;
using GEB_School.DataAccess;

namespace GEB_School.PayRoll
{
    public partial class TrustPayItemTemplate : PageBase
    {
        private static ILog logger = LogManager.GetLogger(typeof(TrustPayItemTemplate));
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
                    ViewState["Mode"] = "Save";
                    btnSave.Visible = false;
                    BindGridView();
                }
                catch (Exception ex)
                {
                    logger.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
        }

        #region BindGrid
        public void BindGridView()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                TrustTemplateBl objTrustTemplateBL = new TrustTemplateBl();

                objResult = objTrustTemplateBL.TrustTemplate_SelectAll_PayItemWithAsc(Convert.ToInt32(Session[ApplicationSession.TRUSTID]));
                if (objResult != null)
                {
                    gvPayItem.DataSource = objResult.resultDT;
                    gvPayItem.DataBind();
                    if (objResult.resultDT.Rows.Count > 0)
                    {
                        gvPayItem.Visible = true;

                        ApplicationResult objTrustTemplateResult = new ApplicationResult();
                        TrustPayItemBl objTrustPayItemBl = new TrustPayItemBl();
                        objTrustTemplateResult = objTrustPayItemBl.TrustPayItem_SelectAll_AscOrder(Convert.ToInt32(Session[ApplicationSession.TRUSTID]));
                        foreach (GridViewRow row in gvPayItem.Rows)
                        {

                            if (objTrustTemplateResult.resultDT.Rows.Count > 0)
                            {
                                int i;
                                for (i = 0; i < objTrustTemplateResult.resultDT.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(row.Cells[0].Text) == Convert.ToInt32(objTrustTemplateResult.resultDT.Rows[i][TrustPayItemBo.TRUSTPAYITEM_PAYITEMID].ToString()))
                                    {
                                        ((CheckBox)row.FindControl("CheckBoxPayItem")).Checked = true;
                                        btnSave.Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
                btnSave.Visible = true;
                //btnCancel.Visible = true;

            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TrustPayItemBo objTrustPayItemBO = new TrustPayItemBo();
                TrustPayItemBl objTrustPayItemBl = new TrustPayItemBl();

                ApplicationResult objTrustTemplateResult = new ApplicationResult();
                objTrustTemplateResult = objTrustPayItemBl.TrustPayItem_SelectAll_AscOrder(Convert.ToInt32(Session[ApplicationSession.TRUSTID]));
                #region RollBack Transaction Starts
                DatabaseTransaction.OpenConnectionTransation();
                ApplicationResult objResultsDelete = new ApplicationResult();
                if (objTrustTemplateResult.resultDT.Rows.Count > 0)
                {
                    for (int i = 0; i < objTrustTemplateResult.resultDT.Rows.Count; i++)
                    {
                        objResultsDelete = objTrustPayItemBl.TrustPayItem_Delete(Convert.ToInt32(objTrustTemplateResult.resultDT.Rows[i][TrustPayItemBo.TRUSTPAYITEM_TRUSTPAYITEMID].ToString()), Convert.ToInt32(Session[ApplicationSession.USERID]), DateTime.UtcNow.AddHours(5.5).ToString());
                    }
                }
                foreach (GridViewRow row in gvPayItem.Rows)
                {
                    if (((CheckBox)row.FindControl("CheckBoxPayItem")).Checked)
                    {
                        objTrustPayItemBO.PayItemID = Convert.ToInt32(row.Cells[0].Text);
                        objTrustPayItemBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                        objTrustPayItemBO.LastModifiedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                        ApplicationResult objResultsInsert = new ApplicationResult();
                        objTrustPayItemBO.TrustMID = Convert.ToInt32(Session[ApplicationSession.TRUSTID]);
                        objTrustPayItemBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                        objTrustPayItemBO.CreatedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                        objResultsInsert = objTrustPayItemBl.TrustPayItem_Insert(objTrustPayItemBO);
                        if (objResultsInsert != null)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Fees Amount Successfully Saved.');</script>");
                        }
                    }

                }
                DatabaseTransaction.CommitTransation();
                #endregion

                BindGridView();
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "BindClass();", true);
                // divLoading.Visible = false;
                //  Response.Redirect("Class_Template.aspx");

            }
            catch (Exception ex)
            {
                DatabaseTransaction.RollbackTransation();
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }

        protected void lnkViewList_Click(object sender, EventArgs e)
        {

        }

        protected void lnkAddNew_Click(object sender, EventArgs e)
        {

        }
    }
}