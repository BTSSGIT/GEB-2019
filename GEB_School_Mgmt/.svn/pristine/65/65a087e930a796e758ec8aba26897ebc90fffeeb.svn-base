using System;
using System.Data;
using System.Web.UI.WebControls;
using GEB_School.Common;
using GEB_School.BL;
using GEB_School.BO;
using log4net;
using System.Web.UI;

namespace GEB_School.PayRoll
{
    public partial class PayItem : PageBase
    {
        private static ILog logger = LogManager.GetLogger(typeof(PayItem));

        #region PageLoad
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
                    GridDataBind();
                    ViewState["Mode"] = "Save";
                    ViewState["PayItemMID"] = 0;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                }
                catch (Exception ex)
                {
                    logger.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
        }
        #endregion

        #region Bind grid
        private void GridDataBind()
        {
            try
            {

                ApplicationResult objResult = new ApplicationResult();
                PayItemBl objPayItemBl = new PayItemBl();

                objResult = objPayItemBl.PayItem_SelectAll(Convert.ToInt32(Session[ApplicationSession.TRUSTID]));
                if (objResult != null)
                {
                    if (objResult.resultDT.Rows.Count > 0)
                    {
                        gvPayItem.DataSource = objResult.resultDT;
                        gvPayItem.DataBind();
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

        #region Save Event
        protected void btnSave_Click(object sender, EventArgs e)
        {

            PayItemBo objPayItemBo = new PayItemBo();
            ApplicationResult objResults = new ApplicationResult();
            PayItemBl objPayItemBl = new PayItemBl();
            Controls objControls = new Controls();

            objPayItemBo.TrustMID = Convert.ToInt32(Session[ApplicationSession.TRUSTID]);
            objPayItemBo.Name = txtPayItemName.Text;
            objPayItemBo.Description = txtPayItemDescription.Text;
            objPayItemBo.Type = Convert.ToInt32(rdEraningDeductionList.SelectedValue);
            if (rdEraningDeductionList.SelectedValue != "0")
            {
                objPayItemBo.Deduction = Convert.ToInt32(rbtnDeduction.SelectedValue);
            }

            objPayItemBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
            objPayItemBo.LastModifiedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
            if (ViewState["Mode"].ToString() == "Save")
            {
                objPayItemBo.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                objPayItemBo.CreatedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                objResults = objPayItemBl.PayItem_Insert(objPayItemBo);

                if (objResults.status == ApplicationResult.CommonStatusType.SUCCESS)
                {
                    ClearAll();
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Pay Item Created Successfully.');</script>");
                    GridDataBind();
                    PanelGrid_VisibilityMode(1);
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Pay Item already Exists.');</script>");
                }

            }
            else
            {
                objPayItemBo.PayItemMID = Convert.ToInt32(ViewState["PayItemMID"].ToString());

                objResults = objPayItemBl.PayItem_Update(objPayItemBo);
                if (objResults.status == ApplicationResult.CommonStatusType.SUCCESS)
                {

                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='JavaScript'>alert('Pay Item updated successfully.');</script>");

                    GridDataBind();
                    ClearAll();
                    //objControls.ClearForm(Master.FindControl("ContentPlaceHolder1"));
                    ViewState["Mode"] = "Save";
                    btnSave.Text = "Save";
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Pay Item already Exists.');</script>");
                }
            }

        }
        #endregion

        #region ViewList Event
        protected void lnkViewList_Click(object sender, EventArgs e)
        {
            Controls objControls = new Controls();
            objControls.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            ViewState["PayItemMID"] = null;
            PanelGrid_VisibilityMode(1);
        }
        #endregion

        #region Add New Event
        protected void lnkAddNew_Click(object sender, EventArgs e)
        {
            Controls objControls = new Controls();
            objControls.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            PanelGrid_VisibilityMode(2);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
        }
        #endregion

        #region PayItem RowCommand
        protected void gvPayItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PayItemBl objPayItemBl = new PayItemBl();
            try
            {
                ViewState["PayItemMID"] = Convert.ToInt32(e.CommandArgument.ToString());
                if (e.CommandName.ToString() == "Edit1")
                {
                    ApplicationResult objResultsEdit = new ApplicationResult();
                    objResultsEdit = objPayItemBl.PayItem_Select(Convert.ToInt32(ViewState["PayItemMID"].ToString()));

                    if (objResultsEdit != null)
                    {
                        if (objResultsEdit.resultDT.Rows.Count > 0)
                        {
                            txtPayItemName.Text = objResultsEdit.resultDT.Rows[0][PayItemBo.PAYITEM_NAME].ToString();
                            txtPayItemDescription.Text = objResultsEdit.resultDT.Rows[0][PayItemBo.PAYITEM_DESCRIPTION].ToString();
                            rdEraningDeductionList.SelectedValue = objResultsEdit.resultDT.Rows[0][PayItemBo.PAYITEM_TYPE].ToString();
                            if (objResultsEdit.resultDT.Rows[0][PayItemBo.PAYITEM_TYPE].ToString() == "1")
                            {
                                rbtnDeduction.SelectedValue = objResultsEdit.resultDT.Rows[0][PayItemBo.PAYITEM_DEDUCTION].ToString();
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divShow();", true);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                            }
                           
                            ViewState["Mode"] = "Edit";
                            PanelGrid_VisibilityMode(2);
                        }
                    }
                }

                if (e.CommandName.ToString() == "Delete1")
                {
                    Controls objControls = new Controls();
                    //objControls.EnableControls(Master.FindControl("ContentPlaceHolder1"));
                    ApplicationResult objDelete = new ApplicationResult();

                    objDelete = objPayItemBl.PayItem_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    if (objDelete.status == ApplicationResult.CommonStatusType.SUCCESS)
                    {
                        ClearAll();
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='JavaScript'>alert('Pay Items deleted successfully.');</script>");
                        GridDataBind();
                        PanelGrid_VisibilityMode(1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='JavaScript'>alert('Pay Items is Used so you can't delete it.');</script>");
                    }
                }
           
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }

        protected void gvPayItem_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvPayItem.Rows.Count > 0)
                {
                    gvPayItem.UseAccessibleHeader = true;
                    gvPayItem.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region Clear all
        public void ClearAll()
        {
            ViewState["PayItemMID"] = 0;
            ViewState["Mode"] = "Save";
            Controls objControls = new Controls();
            objControls.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            rdEraningDeductionList.SelectedIndex = 0;
            rbtnDeduction.SelectedIndex = 0;

        }
        #endregion

        #region PanelGrid_VisibilityMode

        private void PanelGrid_VisibilityMode(int intMode)
        {
            if (intMode == 1)
            {
                gvPayItem.Visible = true;
                tabs.Visible = false;
                lnkAddNew.Visible = true;
                lnkViewList.Visible = false;
                divGrid.Visible = true;
            }
            else if (intMode == 2)
            {

                gvPayItem.Visible = false;
                tabs.Visible = true;
                lnkAddNew.Visible = true;
                lnkViewList.Visible = true;
                divGrid.Visible = false;
            }
        }

        #endregion PanelGrid_VisibilityMode


    }
}