using System;
using System.Data;
using System.Web.UI.WebControls;
using GEB_School.Common;
using GEB_School.BL;
using GEB_School.BO;
using System.Web.UI;
using log4net;
using GEB_School.DataAccess;


namespace GEB_School.PayRoll
{
    public partial class PayItemTemplate : PageBase
    {
        private static ILog logger = LogManager.GetLogger(typeof(PayItemTemplate));
        #region Page_Load Event
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
                    gvPayTemplate.Visible = false;
                    ViewState["Mode"] = "Save";
                    BindTemplateName();
                    BindPayItem();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                    lbDependsOn.Enabled = false;
                }
                catch (Exception ex)
                {
                    logger.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
        }
        #endregion

        #region ViewList Event
        protected void lnkViewList_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
            gvPayTemplate.Visible = false;
        }
        #endregion

        #region Add New
        protected void lnkAddNew_Click(object sender, EventArgs e)
        {
            ViewState["Mode"] = "Save";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
            gvPayTemplate.Visible = false;
        }
        #endregion

        #region Add Template Name
        protected void lnkAddNewTemplate_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divShow();", true);
            gvPayTemplate.Visible = false;
            GridTemplateBind();
            ViewState["Mode"] = "Save";
            gvPayTemplate.Visible = false;
            btnSave.Visible = true;
        }
        #endregion

        #region Add Template
        protected void btnAddTemplate_OnClick(object sender, EventArgs e)
        {
            try
            {

                TrustTemplateBo objTrustTemplateBo = new TrustTemplateBo();
                ApplicationResult objResult = new ApplicationResult();
                TrustTemplateBl ObjTrustTemplatemBl = new TrustTemplateBl();
                if (txtTemplateName.Text != "")
                {
                    objTrustTemplateBo.TrustMID = Convert.ToInt32(Session[ApplicationSession.TRUSTID]);
                    objTrustTemplateBo.TrustTemplateName = txtTemplateName.Text.Trim();
                    objTrustTemplateBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                    objTrustTemplateBo.LastModifiedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                    if (ViewState["Mode"].ToString() == "Save")
                    {
                        objTrustTemplateBo.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                        objTrustTemplateBo.CreatedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);

                        objResult = ObjTrustTemplatemBl.TrustTemplate_Insert(objTrustTemplateBo);

                        if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                            txtTemplateName.Text = "";
                            BindTemplateName();
                            GridTemplateBind();
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Template Name Saved Successfully.');</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Template Name already Exists.');</script>");
                        }
                    }
                    else
                    {
                        objTrustTemplateBo.TrustTemplateID = Convert.ToInt32(ViewState["TrustTemplateID"].ToString());
                        objResult = ObjTrustTemplatemBl.TrustTemplate_Update(objTrustTemplateBo);

                        if (objResult.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                            txtTemplateName.Text = "";
                            BindTemplateName();
                            GridTemplateBind();
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Template Name Updated Successfully.');</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Template Name already Exists.');</script>");
                        }
                    }
                    ViewState["Mode"] = "Save";
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Write template Name.');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Save Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TrustPayItemTemplateTBl objTrustPayItemTemplateBl = new TrustPayItemTemplateTBl();
                ApplicationResult objResults = new ApplicationResult();
                TrustPayItemTemplateTBo objTrustPayItemTemplateBo = new TrustPayItemTemplateTBo();

                objTrustPayItemTemplateBo.TemplateID = Convert.ToInt32(ddlSelectTemplateName.SelectedValue.ToString());


                if (lbDependsOn.Enabled == true)
                {
                    lblDependent.Text = "";
                    string dependsOn = "";
                    for (int i = 0; i < lbDependsOn.Items.Count; i++)
                    {
                        if (lbDependsOn.Items[i].Selected)
                        {
                            dependsOn = dependsOn + "," + lbDependsOn.Items[i].Value.ToString();
                        }
                    }

                    if (dependsOn == "")
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Please select the PayItem on which this PayItem depends.');</script>");
                        dependsOn = "";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                        goto Break;
                    }
                    objTrustPayItemTemplateBo.PayItemDependsOn = dependsOn;


                }
                else
                {
                    objTrustPayItemTemplateBo.PayItemDependsOn = "0";
                }


                if (txtAmount.Enabled = true && ddlPayItemType.SelectedValue == "0")
                {
                    if (txtAmount.Text != "")
                    {
                        objTrustPayItemTemplateBo.Amount = Convert.ToDouble(txtAmount.Text.Trim());
                    }
                    else
                    {
                        objTrustPayItemTemplateBo.Amount = Convert.ToDouble(0.00);

                    }
                }
                else
                {
                    objTrustPayItemTemplateBo.Amount = 0;
                    txtAmount.Text = "";
                }

                objTrustPayItemTemplateBo.PayItemType = Convert.ToInt32(ddlPayItemType.SelectedValue);
                if (txtPercentage.Enabled == true)
                {
                    if (txtPercentage.Text != "")
                    {
                        objTrustPayItemTemplateBo.Percentage = Convert.ToDouble(txtPercentage.Text.Trim());
                    }
                    else
                    {
                        objTrustPayItemTemplateBo.Percentage = 0;
                    }
                }
                else
                {
                    objTrustPayItemTemplateBo.Percentage = 0;
                }
                objTrustPayItemTemplateBo.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                objTrustPayItemTemplateBo.LastModifiedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);

                if (ViewState["Mode"].ToString() == "Save")
                {
                    for (int i = 0; i < gvPayTemplate.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(ddlPayItemName.SelectedValue) == Convert.ToInt32(gvPayTemplate.Rows[i].Cells[0].Text))
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('This PayItem is already inserted.');</script>");
                            txtAmount.Text = "";
                            ddlPayItemType.SelectedValue = "-1";
                            goto Break;
                        }
                    }
                    objTrustPayItemTemplateBo.PayItemID = Convert.ToInt32(ddlPayItemName.SelectedValue.ToString());
                    objTrustPayItemTemplateBo.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                    objTrustPayItemTemplateBo.CreatedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                    ddlSelectTemplateName.SelectedValue = Convert.ToString(objTrustPayItemTemplateBo.TemplateID);
                    if (objTrustPayItemTemplateBo.PayItemID != -1 && objTrustPayItemTemplateBo.PayItemType != -1)
                    {
                        objResults = objTrustPayItemTemplateBl.TrustPayItemTemplateT_Insert(objTrustPayItemTemplateBo);

                        if (objResults.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {

                            GridNameConvertion();
                            BindTemplateName();
                            BindPayItem();

                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Record Successfully Inserted.');</script>");
                            GridDataBind();
                        }

                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Please Select Any PayItem..');</script>");
                        ddlPayItemType.SelectedIndex = -1;

                    }
                }
                else
                {
                    objTrustPayItemTemplateBo.TrustTemplateID = Convert.ToInt32(ViewState["TrustTemplateID"].ToString());
                    objTrustPayItemTemplateBo.PayItemID = Convert.ToInt32(ddlPayItemName.SelectedValue.ToString());

                    if (objTrustPayItemTemplateBo.PayItemID != -1 && objTrustPayItemTemplateBo.PayItemType != -1)
                    {
                        //for (int i = 0; i < gvPayTemplate.Rows.Count; i++)
                        //{
                        //    if (Convert.ToInt32(ddlPayItemName.SelectedValue) == Convert.ToInt32(gvPayTemplate.Rows[i].Cells[0].Text))
                        //    {
                        //        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('This PayItem is already inserted.');</script>");
                        //        txtAmount.Text = "";
                        //        ddlPayItemType.SelectedValue = "-1";
                        //        goto Break;
                        //    }
                        //}
                        objResults = objTrustPayItemTemplateBl.TrustPayItemTemplateT_Update(objTrustPayItemTemplateBo);
                        if (objResults.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {
                            ddlSelectTemplateName.SelectedValue = ViewState["TemplateNameID"].ToString();
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Record Successfully Updated');</script>");
                            GridNameConvertion();
                            BindTemplateName();
                            BindPayItem();
                            //  int i = Convert.ToInt32(ddlSelectTemplateName.SelectedValue);
                            GridDataBind();
                        }

                    }
                }



                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                lbDependsOn.SelectedValue = (-1).ToString();
                ddlPayItemType.SelectedIndex = 0;
                txtAmount.Text = "";
                txtPercentage.Text = "";
                ddlSelectTemplateName.Enabled = true;
                ddlPayItemName.Enabled = true;

                //objControls.DisableControls(Master.FindControl("ContentPlaceHolder1"));
            Break: ;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                Exit:
                ;
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }

        }
        #endregion

        #region Selected Changed Event od Select Template Name dropdown
        protected void ddlSelectTemplateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSelectTemplateName.SelectedValue != "")
            {
                GridDataBind();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
            }
            else
            {
                ViewState["Mode"] = "Save";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                gvPayTemplate.Visible = false;
            }
        }
        #endregion

        #region ddlPayItemType dropdown's SelectedIndexChanged
        protected void ddlPayItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPayItemType.SelectedItem.Text == "Independent")
            {
                lbDependsOn.Enabled = false;
                txtPercentage.Enabled = false;
                txtAmount.Enabled = true;
                lbDependsOn.Items.Clear();
            }
            else if (ddlPayItemType.SelectedItem.Text == "Dependent")
            {
                lbDependsOn.Enabled = true;
                txtPercentage.Enabled = true;
                txtAmount.Enabled = false;

            }
            else if (ddlPayItemType.SelectedItem.Text == "Depends On Gross")
            {
                lbDependsOn.Enabled = false;
                txtPercentage.Enabled = true;
                txtAmount.Enabled = false;
                lbDependsOn.Items.Clear();
            }
            if (Convert.ToInt32(ddlPayItemType.SelectedValue.ToString()) == 1)
            {
                BindListbox();
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
        }
        #endregion

        #region ddlPayItemName dropdown's SelectedIndexChanged
        protected void ddlPayItemName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region DropDOwnList For Template Name
        public void BindTemplateName()
        {
            try
            {
                TrustTemplateBl ObjTrustTemplateBl = new TrustTemplateBl();
                ApplicationResult objResult = new ApplicationResult();
                Controls objControls = new Controls();

                objResult = ObjTrustTemplateBl.TrustTemplate_SelectAll(Convert.ToInt32(Session[ApplicationSession.TRUSTID]));
                if (objResult != null)
                {
                    if (objResult.resultDT.Rows.Count > 0)
                    {
                        objControls.BindDropDown_ListBox(objResult.resultDT, ddlSelectTemplateName, "TrustTemplateName", "TrustTemplateID");
                        ddlSelectTemplateName.Items.Insert(0, new ListItem("-Select-", ""));
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divShow();", true);
                        btnSave.Visible = true;
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

        #region DropDOwnList For PayItem
        public void BindPayItem()
        {
            try
            {
                PayItemBl ObjPayItemBl = new PayItemBl();
                ApplicationResult objResult = new ApplicationResult();
                Controls objControls = new Controls();

                objResult = ObjPayItemBl.PayItem_Select_PayItemName(Convert.ToInt32(Session[ApplicationSession.TRUSTID]));
                if (objResult != null)
                {
                    if (objResult.resultDT.Rows.Count > 0)
                    {
                        objControls.BindDropDown_ListBox(objResult.resultDT, ddlPayItemName, "Name", "PayItemMID");
                        ddlPayItemName.Items.Insert(0, new ListItem("-Select-", ""));

                    }
                    else
                    {
                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divShow();", true);
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Please insert TrustPayItem First.');</script>");
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

        #region GridNameConvertion Method
        public void GridNameConvertion()
        {
            int i;
            for (i = 0; i < gvPayTemplate.Rows.Count; ++i)
            {
                if (gvPayTemplate.Rows[i].Cells[2].Text.ToString() == "0")
                {
                    gvPayTemplate.Rows[i].Cells[2].Text = "Independent";
                }
                else
                    if (gvPayTemplate.Rows[i].Cells[2].Text.ToString() == "1")
                    {
                        gvPayTemplate.Rows[i].Cells[2].Text = "Dependent";
                    }
                    else
                        if (gvPayTemplate.Rows[i].Cells[2].Text.ToString() == "2")
                        {
                            gvPayTemplate.Rows[i].Cells[2].Text = "Depends On Gross";
                        }
                        else
                            if (gvPayTemplate.Rows[i].Cells[2].Text.ToString() == "&nbsp;")
                            {
                                gvPayTemplate.Rows[i].Cells[2].Text = "";
                            }
            }

        }
        #endregion

        #region Bind grid of Pay Template
        private void GridDataBind()
        {
            try
            {

                TrustPayItemBl objTrustPayItemBl = new TrustPayItemBl();
                ApplicationResult objResult = new ApplicationResult();

                objResult = objTrustPayItemBl.PayItemTemplate_SelectAll_TemplateID(Convert.ToInt32(ddlSelectTemplateName.SelectedValue));
                if (objResult != null)
                {
                    gvPayTemplate.DataSource = objResult.resultDT;
                    gvPayTemplate.DataBind();
                    if (objResult.resultDT.Rows.Count > 0)
                    {
                        gvPayTemplate.Visible = true;
                    }
                    else
                    {
                        gvPayTemplate.Visible = false;
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

        #region Bind grid
        private void GridTemplateBind()
        {
            try
            {

                TrustTemplateBl objTrustItemBl = new TrustTemplateBl();
                ApplicationResult objResult = new ApplicationResult();

                objResult = objTrustItemBl.TrustTemplate_SelectAll(Convert.ToInt32(Session[ApplicationSession.TRUSTID]));
                if (objResult != null)
                {
                    gvTemplates.DataSource = objResult.resultDT;
                    gvTemplates.DataBind();
                    if (objResult.resultDT.Rows.Count > 0)
                    {
                        gvPayTemplate.Visible = true;
                    }
                    else
                    {
                        gvPayTemplate.Visible = false;
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

        #region BindListBox
        private void BindListbox()
        {
            TrustPayItemTemplateTBl objTrustPayItemTemplateBl = new TrustPayItemTemplateTBl();
            ApplicationResult objResults = new ApplicationResult();
            Controls objControls = new Controls();
            objResults = objTrustPayItemTemplateBl.TrustPayItemTemplate_Select_PayItemWise(Convert.ToInt32(ddlSelectTemplateName.SelectedValue));
            if (objResults != null)
            {
                if (objResults.resultDT.Rows.Count > 0)
                {
                    objControls.BindDropDown_ListBox(objResults.resultDT, lbDependsOn, "Name", "PayItemMID");
                    //lbDependsOn.Items.Insert(0, new ListItem("-Select-", "-1"));

                }
            }
        }
        #endregion

        #region rowcommand Event of Gridview
        protected void gvPayTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            TrustPayItemTemplateTBl objTrustPayItemTemplateBl = new TrustPayItemTemplateTBl();
            ApplicationResult objResultsEdit = new ApplicationResult();
            try
            {
                ViewState["TrustTemplateID"] = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                if (e.CommandName.ToString() == "Edit1")
                {

                    ddlSelectTemplateName.Enabled = false;
                    ddlPayItemName.Enabled = false;
                    objResultsEdit = objTrustPayItemTemplateBl.TrustPayItemTemplateT_Select(Convert.ToInt32(ViewState["TrustTemplateID"].ToString()));
                    String[] str;
                    if (objResultsEdit != null)
                    {
                        if (objResultsEdit.resultDT.Rows.Count > 0)
                        {
                            ddlSelectTemplateName.SelectedValue = objResultsEdit.resultDT.Rows[0][TrustPayItemTemplateTBo.TRUSTPAYITEMTEMPLATET_TEMPLATEID].ToString();
                            ViewState["TemplateNameID"] = objResultsEdit.resultDT.Rows[0][TrustPayItemTemplateTBo.TRUSTPAYITEMTEMPLATET_TEMPLATEID].ToString();
                            ddlPayItemType.SelectedValue = objResultsEdit.resultDT.Rows[0][TrustPayItemTemplateTBo.TRUSTPAYITEMTEMPLATET_PAYITEMTYPE].ToString();
                            ddlPayItemName.SelectedValue = objResultsEdit.resultDT.Rows[0][TrustPayItemTemplateTBo.TRUSTPAYITEMTEMPLATET_PAYITEMID].ToString();
                            txtAmount.Text = objResultsEdit.resultDT.Rows[0][TrustPayItemTemplateTBo.TRUSTPAYITEMTEMPLATET_AMOUNT].ToString();
                            txtPercentage.Text = objResultsEdit.resultDT.Rows[0][TrustPayItemTemplateTBo.TRUSTPAYITEMTEMPLATET_PERCENTAGE].ToString();

                            str = gvPayTemplate.Rows[rowIndex].Cells[4].Text.ToString().Split(',');
                            int i = 0;
                            int len = str.Length;
                            for (i = 0; i < len; i++)
                            {
                                if (i >= len)
                                    break;
                                else
                                {
                                    if (str[i] != "NULL" && str[i] != "&nbsp;")
                                    {
                                        //cbDependsOn.SelectedValue = str[i];             
                                        lbDependsOn.Items.Add(str[i]);
                                    }
                                    else
                                    {
                                        lbDependsOn.SelectedValue = null;
                                    }


                                }
                            }

                            if (ddlPayItemType.SelectedItem.Text == "Depends On Gross")
                            {
                                txtPercentage.Enabled = true;
                                txtPercentage.BackColor = System.Drawing.Color.White;
                                txtAmount.Enabled = false;
                                lbDependsOn.Enabled = false;
                                lbDependsOn.Items.Clear();
                            }
                            else
                                if (ddlPayItemType.SelectedItem.Text == "Dependent")
                                {
                                    txtPercentage.Enabled = true;
                                    txtPercentage.BackColor = System.Drawing.Color.White;
                                    txtAmount.Enabled = false;
                                    lbDependsOn.Enabled = true;
                                    BindListbox();
                                }
                                else
                                    if (ddlPayItemType.SelectedItem.Text == "Independent")
                                    {
                                        txtAmount.Enabled = true;
                                        txtAmount.BackColor = System.Drawing.Color.White;
                                        txtPercentage.Enabled = false;
                                        lbDependsOn.Enabled = false;
                                        lbDependsOn.Items.Clear();

                                    }

                            ViewState["Mode"] = "Edit";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);

                        }
                    }
                }
                if (e.CommandName.ToString() == "Delete1")
                {
                    objResultsEdit = objTrustPayItemTemplateBl.TrustPayItemTemplate_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.USERID]), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResultsEdit != null)
                    {
                        if (objResultsEdit.status == ApplicationResult.CommonStatusType.SUCCESS)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('PayTemplate Deleted Successfully.');</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('There are PayTemplate(s) associated with Payroll.');</script>");
                        }

                    }
                    GridDataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region Gvtemplates Row Command
        protected void gvTemplates_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                TrustTemplateBl objTrustItemBl = new TrustTemplateBl();
                ApplicationResult objResult = new ApplicationResult();
                ViewState["TrustTemplateID"] = Convert.ToInt32(e.CommandArgument.ToString());
                if (e.CommandName.ToString() == "Edit1")
                {
                    objResult = objTrustItemBl.TrustTemplate_Select(Convert.ToInt32(ViewState["TrustTemplateID"].ToString()));

                    if (objResult != null)
                    {
                        if (objResult.resultDT.Rows.Count > 0)
                        {
                            txtTemplateName.Text = objResult.resultDT.Rows[0][TrustTemplateBo.TRUSTTEMPLATE_TRUSTTEMPLATENAME].ToString();
                            ViewState["Mode"] = "Edit";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divShow();", true);
                        }
                    }
                }
                if (e.CommandName.ToString() == "Delete1")
                {
                    Controls objControls = new Controls();
                    //objControls.EnableControls(Master.FindControl("ContentPlaceHolder1"));
                    ApplicationResult objDelete = new ApplicationResult();

                    objDelete = objTrustItemBl.TrustTemplate_Delete(Convert.ToInt32(ViewState["TrustTemplateID"].ToString()), Convert.ToInt32(Session[ApplicationSession.USERID]), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objDelete.status == ApplicationResult.CommonStatusType.SUCCESS)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='JavaScript'>alert('Template name deleted successfully.');</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "divHide();", true);
                        txtTemplateName.Text = "";
                        BindTemplateName();
                        GridTemplateBind();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='JavaScript'>alert('Template names are assigned to Employee PayRoll So you Can not Delete this.');</script>");
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

    }
}