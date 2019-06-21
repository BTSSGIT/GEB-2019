using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using GEB_School.BL;
using GEB_School.BO;
using GEB_School.Common;
using GEB_School.DataAccess;

namespace GEB_School.Accounting
{
    public partial class Payment : PageBase
    {
        #region declaration
        private static ILog logger = LogManager.GetLogger(typeof(Payment));
        Controls objControl = new Controls();
        DataTable dtGridData = new DataTable();
        #endregion

        #region Pre-Init Method
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "TU")
            {
                MasterPageFile = "~/Master/TrustMain.Master";
            }
        }
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session[ApplicationSession.HASACCESSACCOUNTUSERID]) > 0)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["mode"] == "TU")
                    {
                        lblDuration.Text = Session[ApplicationSession.TRUSTNAME].ToString() + ". Account Duration : " + Session[ApplicationSession.ACCOUNTFROMDATE].ToString() + " To " + Session[ApplicationSession.ACCOUNTTODATE].ToString();
                    }
                    else
                    {
                        if (Convert.ToInt32(Session[ApplicationSession.SCHOOLID]) == 0)
                        {
                            lblDuration.Text = Session[ApplicationSession.TRUSTNAME].ToString() + ". Account Duration : " + Session[ApplicationSession.ACCOUNTFROMDATE].ToString() + " To " + Session[ApplicationSession.ACCOUNTTODATE].ToString();
                        }
                        else
                            lblDuration.Text = Session[ApplicationSession.SCHOOLNAME].ToString() + ". Account Duration : " + Session[ApplicationSession.ACCOUNTFROMDATE].ToString() + " To " + Session[ApplicationSession.ACCOUNTTODATE].ToString();
                    }

                    GetMaxDate();
                    txtVoucherCode.Attributes.Add("readonly", "readonly");
                    txtDate.Attributes.Add("readonly", "readonly");
                    getNewRows();

                    BindGrid();
                    BindAccountGroup();
                    PanelVisibility(1);

                    ViewState["Mode"] = "Save";

                    if (Request.QueryString["modetype"] == "new")
                        btnAddNew_Click(sender, e);
                }

                if (ViewState["grid"] != null)
                {
                    dtGridData = (DataTable)ViewState["grid"];
                    dtGridData.Rows.Clear();

                    for (int i = 0; i < gvPaymentsEntry.Rows.Count; i++)
                    {
                        DataRow dr = dtGridData.NewRow();

                        dr[0] = "0";
                        dr[1] = ((DropDownList)(gvPaymentsEntry.Rows[i].Cells[1].FindControl("ddlAccountName"))).SelectedItem.Value;
                        dr[2] = ((TextBox)(gvPaymentsEntry.Rows[i].Cells[2].FindControl("txtDebitAmount"))).Text;

                        dtGridData.Rows.Add(dr);
                    }
                    ViewState["grid"] = dtGridData;
                }
                else
                {
                    dtGridData.Rows.Clear();
                    dtGridData.Columns.Add("ReceiptPaymentID");
                    dtGridData.Columns.Add("AccountID");
                    dtGridData.Columns.Add("CreditAmount");

                    ViewState["grid"] = dtGridData;
                }
                setControlScript();
            }
            else
            {
                if (Convert.ToInt32(Session[ApplicationSession.SCHOOLID]) == 0)
                    Response.Redirect("../Accounting/AccountLogin.aspx?mode=TU", false);
                else
                    Response.Redirect("../Accounting/AccountLogin.aspx", false);
            }
        }
        #endregion

        #region Button Click Events

        #region Add New Button
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            PanelVisibility(2);
            clear();
        }
        #endregion

        #region Button Viewlist
        protected void btnViewList_Click(object sender, EventArgs e)
        {
            clear();
            PanelVisibility(1);
        }
        #endregion

        #region Add New Row
        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (ViewState["ADDRow"] != null)
            {
                gvPaymentsEntry.DataSource = (DataTable)ViewState["ADDRow"];
                gvPaymentsEntry.DataBind();
                int cnt = gvPaymentsEntry.Rows.Count;
                cnt++;

                dt = (DataTable)ViewState["ADDRow"];
                dt.Rows.Add(cnt.ToString());

                gvPaymentsEntry.DataSource = dt;
                gvPaymentsEntry.DataBind();
            }
            else
            {
                int cnt = gvPaymentsEntry.Rows.Count;
                cnt++;
                dt.Columns.Add("Number");
                dt.Columns.Add("ReceiptPaymentID");
                for (int i = 0; i < cnt; i++)
                {
                    dt.Rows.Add(i.ToString(), "0");
                }
                gvPaymentsEntry.DataSource = dt;
            }
            BindAccountGroup();
            ViewState["ADDRow"] = dt;
            if (ViewState["grid"] != null)
            {
                dtGridData = (DataTable)ViewState["grid"];

                for (int i = 0; i < dtGridData.Rows.Count; i++)
                {
                    int value = 0;
                    gvPaymentsEntry.Rows[i].Cells[0].Text = Convert.ToString(value);
                    ((DropDownList)(gvPaymentsEntry.Rows[i].Cells[1].FindControl("ddlAccountName"))).SelectedValue = dtGridData.Rows[i][1].ToString();
                    ((TextBox)(gvPaymentsEntry.Rows[i].Cells[2].FindControl("txtDebitAmount"))).Text = dtGridData.Rows[i][2].ToString();
                }
            }
            setControlScript();
            getDebitCreditSum();
        }
        #endregion

        #region Save Button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ReceiptPaymentBL objReceiptPaymentBL = new ReceiptPaymentBL();
                ReceiptPaymentBO objReceiptPaymentBO = new ReceiptPaymentBO();
                ApplicationResult objResultInsert = new ApplicationResult();
                ApplicationResult objResultUpdate = new ApplicationResult();
                DataTable dtResult = new DataTable();
                double dbSum = 0.0;
                DateTime dtFromDate = Convert.ToDateTime(Session[ApplicationSession.ACCOUNTFROMDATE].ToString());
                DateTime dtToDate = Convert.ToDateTime(Session[ApplicationSession.ACCOUNTTODATE].ToString());
                DateTime dtCurrentDate = Convert.ToDateTime(txtDate.Text);

                if (ViewState["Mode"].ToString() == "Save")
                {
                    int intvalidate = 0;
                    for (int i = 0; i < gvPaymentsEntry.Rows.Count; i++)
                    {
                        string ddlVal = ((DropDownList)(gvPaymentsEntry.Rows[i].Cells[0].FindControl("ddlAccountName"))).SelectedItem.Value;
                        string strDebitAmt = ((TextBox)(gvPaymentsEntry.Rows[i].Cells[1].FindControl("txtDebitAmount"))).Text;

                        if (strDebitAmt != "")
                        {
                            if (ddlVal == "-1")
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Select General Ledger Account or enter amount before save Payment entry.');</script>");
                                return;
                            }
                        }
                        else
                        {
                            intvalidate = intvalidate + 1;
                        }
                        if (gvPaymentsEntry.Rows.Count == intvalidate)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Select General Ledger Account or enter amount before save Payment entry.');</script>");
                            return;
                        }
                    }

                    if (txtDate.Text == "" || txtDate.Text == "&nbsp;")
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Select Date First.');</script>");
                    }
                    else if (ddlReceiptMode.SelectedValue == "-1" || ddlGeneralLedger.SelectedValue == "-1")
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Please select mode of Payment and General Ledger.');</script>");
                    }
                    else
                    {
                        objReceiptPaymentBO.TrustMID = Convert.ToInt32(Session[ApplicationSession.TRUSTID]);
                        objReceiptPaymentBO.SchoolMID = Convert.ToInt32(Session[ApplicationSession.SCHOOLID]);
                        objReceiptPaymentBO.ReceiptPaymentDate = dtCurrentDate.ToShortDateString();
                        objReceiptPaymentBO.Year = Convert.ToInt32(Session[ApplicationSession.FINANCIALYEAR]);
                        objReceiptPaymentBO.TransactionType = "Payment";
                        objReceiptPaymentBO.GeneralLedger = Convert.ToInt32(ddlGeneralLedger.SelectedValue);
                        objReceiptPaymentBO.Narration = txtNarration.Text;
                        objReceiptPaymentBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.USERID]);
                        objReceiptPaymentBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
                        objReceiptPaymentBO.IsDeleted = 0;
                        objReceiptPaymentBO.LastModifideDate = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
                        objReceiptPaymentBO.LastModifideUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);

                        if (dtFromDate <= dtCurrentDate && dtCurrentDate <= dtToDate)
                        {
                            if (ddlReceiptMode.SelectedValue == "Cash")
                            {
                                objReceiptPaymentBO.TransactionMode = "Cash";
                            }
                            else if (ddlReceiptMode.SelectedValue == "Bank" || ddlReceiptMode.SelectedValue == "ODCC")
                            {
                                objReceiptPaymentBO.TransactionMode = ddlReceiptMode.SelectedValue;
                                if (txtChequeNo.Text.Length > 0)
                                    objReceiptPaymentBO.ChequeNo = Convert.ToInt32(txtChequeNo.Text);
                            }

                            for (int j = 0; j < gvPaymentsEntry.Rows.Count; j++)
                            {
                                GridViewRow row = gvPaymentsEntry.Rows[j];
                                TextBox txtCrAmount = (TextBox)row.FindControl("txtDebitAmount");
                                DropDownList ddlAccName = (DropDownList)row.FindControl("ddlAccountName");
                                if (txtCrAmount.Text == "" && ddlAccName.SelectedValue == "-1")
                                {
                                    continue;
                                }
                                else if (txtCrAmount.Text == "" || ddlAccName.SelectedValue == "-1")
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Select Account Name or Amount');</script>");
                                    break;
                                }
                                else
                                {
                                    objReceiptPaymentBO.LedgerID = Convert.ToInt32(ddlAccName.SelectedValue);
                                    dbSum = Convert.ToDouble(txtCrAmount.Text);
                                    objReceiptPaymentBO.Amount = dbSum;
                                }
                                objResultInsert = objReceiptPaymentBL.ReceiptPayment_Insert(objReceiptPaymentBO);

                                if (j == 0)
                                {
                                    if (objResultInsert != null)
                                    {
                                        dtResult = objResultInsert.resultDT;
                                        if (dtResult.Rows.Count > 0)
                                        {
                                            if (dtResult.Rows[0][0].ToString() == "0")
                                            {
                                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Please Initialize Receipt Start No. For This Year.');</script>");
                                                goto Exit;
                                            }
                                            else
                                            {
                                                ViewState["ReceiptNo"] = Convert.ToInt32(dtResult.Rows[0][0]);
                                                ViewState["ReceiptCode"] = dtResult.Rows[0][1].ToString();
                                                objReceiptPaymentBO.ReceiptPaymentNo = Convert.ToInt32(ViewState["ReceiptNo"]);
                                                objReceiptPaymentBO.ReceiptPaymentCode = ViewState["ReceiptCode"].ToString();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    objReceiptPaymentBO.ReceiptPaymentNo = Convert.ToInt32(ViewState["ReceiptNo"]);
                                    objReceiptPaymentBO.ReceiptPaymentCode = ViewState["ReceiptCode"].ToString();
                                }
                            }
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Payment Saved Successfully. Payment No is " + ViewState["ReceiptCode"].ToString() + "');</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Select Date according to your Accounting Period.');</script>");
                        }
                    }
                    BindGrid();
                    clear();
                    PanelVisibility(1);
                }
                else
                {
                    int intvalidate = 0;
                    for (int i = 0; i < gvPaymentsEntry.Rows.Count; i++)
                    {
                        string ddlVal = ((DropDownList)(gvPaymentsEntry.Rows[i].Cells[0].FindControl("ddlAccountName"))).SelectedItem.Value;
                        string strDebitAmt = ((TextBox)(gvPaymentsEntry.Rows[i].Cells[1].FindControl("txtDebitAmount"))).Text;

                        if (strDebitAmt != "")
                        {
                            if (ddlVal == "-1")
                            {
                                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Select General Ledger Account or enter amount before save Payment entry.');</script>");
                                return;
                            }
                        }
                        else
                        {
                            intvalidate = intvalidate + 1;
                        }
                        if (gvPaymentsEntry.Rows.Count == intvalidate)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Select General Ledger Account or enter amount before save Payment entry.');</script>");
                            return;
                        }
                    }
                    ApplicationResult objResultDelete = new ApplicationResult();

                    if (txtDate.Text == "" || txtDate.Text == "&nbsp;")
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                            "<script>alert('Select Date First.');</script>");
                    }
                    else if (ddlReceiptMode.SelectedValue == "-1" || ddlGeneralLedger.SelectedValue == "-1")
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                            "<script>alert('Please select mode of Payment and General Ledger.');</script>");
                    }
                    else
                    {
                        objReceiptPaymentBO.TrustMID = Convert.ToInt32(Session[ApplicationSession.TRUSTID]);
                        objReceiptPaymentBO.SchoolMID = Convert.ToInt32(Session[ApplicationSession.SCHOOLID]);
                        objReceiptPaymentBO.ReceiptPaymentDate = dtCurrentDate.ToShortDateString();
                        objReceiptPaymentBO.Year = Convert.ToInt32(Session[ApplicationSession.FINANCIALYEAR]);
                        objReceiptPaymentBO.TransactionType = "Payment";
                        objReceiptPaymentBO.GeneralLedger = Convert.ToInt32(ddlGeneralLedger.SelectedValue);
                        objReceiptPaymentBO.Narration = txtNarration.Text;
                        objReceiptPaymentBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.USERID]);
                        objReceiptPaymentBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
                        objReceiptPaymentBO.IsDeleted = 0;
                        objReceiptPaymentBO.LastModifideDate = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
                        objReceiptPaymentBO.LastModifideUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                        objReceiptPaymentBO.ReceiptPaymentNo =
                            Convert.ToInt32(txtVoucherCode.Text.Substring(6, txtVoucherCode.Text.Length - 6));
                        ;
                        objReceiptPaymentBO.ReceiptPaymentCode = txtVoucherCode.Text;

                        if (dtFromDate <= dtCurrentDate && dtCurrentDate <= dtToDate)
                        {
                            if (ddlReceiptMode.SelectedValue == "Cash")
                            {
                                objReceiptPaymentBO.TransactionMode = "Cash";
                            }
                            else if (ddlReceiptMode.SelectedValue == "Bank" || ddlReceiptMode.SelectedValue == "ODCC")
                            {
                                objReceiptPaymentBO.TransactionMode = ddlReceiptMode.SelectedValue;
                                if (txtChequeNo.Text.Length > 0)
                                    objReceiptPaymentBO.ChequeNo = Convert.ToInt32(txtChequeNo.Text);
                            }

                            DatabaseTransaction.OpenConnectionTransation();

                            objResultDelete = objReceiptPaymentBL.ReceiptPayment_Delete_Transaction(txtVoucherCode.Text, "Payment");

                            for (int j = 0; j < gvPaymentsEntry.Rows.Count; j++)
                            {
                                GridViewRow row = gvPaymentsEntry.Rows[j];
                                TextBox txtCrAmount = (TextBox)row.FindControl("txtDebitAmount");
                                DropDownList ddlAccName = (DropDownList)row.FindControl("ddlAccountName");
                                if (txtCrAmount.Text == "" && ddlAccName.SelectedValue == "-1")
                                {
                                    continue;
                                }
                                else if (txtCrAmount.Text == "" || ddlAccName.SelectedValue == "-1")
                                {
                                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                        "<script>alert('Select Account Name or Amount');</script>");
                                    break;
                                }
                                else
                                {
                                    objReceiptPaymentBO.LedgerID = Convert.ToInt32(ddlAccName.SelectedValue);
                                    dbSum = Convert.ToDouble(txtCrAmount.Text);
                                    objReceiptPaymentBO.Amount = dbSum;
                                }
                                objResultUpdate = objReceiptPaymentBL.ReceiptPayment_Update(objReceiptPaymentBO);
                            }
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Payment Updated Successfully. Receipt No is " + ViewState["ReceiptCode"].ToString() + "');</script>");
                            DatabaseTransaction.CommitTransation();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Select Date according to your Accounting Period.');</script>");
                        }
                    }
                    BindGrid();
                    clear();
                    PanelVisibility(1);
                }
            Exit: ;
            }
            catch (Exception ex)
            {
                if (ViewState["Mode"].ToString() == "Edit")
                    DatabaseTransaction.RollbackTransation();
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
            finally
            {
                DatabaseTransaction.connection.Close();
            }
        }
        #endregion

        #region Link Button Createnew
        protected void lbtnCreateNew_OnClick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session[ApplicationSession.SCHOOLID]) == 0)
                Response.Redirect("GeneralLedger.aspx?mode=TU&modetype=new&page=payment", false);
            else
                Response.Redirect("GeneralLedger.aspx", false);
        }
        #endregion

        #endregion

        #region Drop Down Index Changed Events
        #region Receipt Mode Selected Index Changed Event
        protected void ddlReceiptMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divlblBalance.Visible = false;
                if (ddlReceiptMode.SelectedValue != "")
                {
                    GeneralLedgerBL objGeneralLedgerBL = new GeneralLedgerBL();
                    GeneralLedgerBO objGeneralLedgerBO = new GeneralLedgerBO();
                    ApplicationResult objResultSelect = new ApplicationResult();
                    DataTable dtSelect = new DataTable();

                    if (ddlReceiptMode.SelectedValue == "Cash")
                    {
                        txtChequeNo.Text = "";
                        txtChequeNo.Enabled = false;
                        ddlGeneralLedger.ClearSelection();

                        objResultSelect = objGeneralLedgerBL.GeneralLedger_Select_Receipt_Payment(1, Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));
                        if (objResultSelect != null)
                        {
                            dtSelect = objResultSelect.resultDT;

                            objControl.BindDropDown_ListBox(dtSelect, ddlGeneralLedger, "AccountName", "LedgerID");
                            ddlGeneralLedger.Items.Insert(0, new ListItem("--Select--", ""));
                        }
                    }
                    else if (ddlReceiptMode.SelectedValue == "Bank")
                    {
                        txtChequeNo.Text = "";
                        txtChequeNo.Enabled = true;
                        ddlGeneralLedger.ClearSelection();

                        objResultSelect = objGeneralLedgerBL.GeneralLedger_Select_Receipt_Payment(2, Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));
                        if (objResultSelect != null)
                        {
                            dtSelect = objResultSelect.resultDT;

                            objControl.BindDropDown_ListBox(dtSelect, ddlGeneralLedger, "AccountName", "LedgerID");
                            ddlGeneralLedger.Items.Insert(0, new ListItem("--Select--", ""));
                        }
                    }
                    else
                    {
                        txtChequeNo.Text = "";
                        txtChequeNo.Enabled = true;
                        ddlGeneralLedger.ClearSelection();

                        objResultSelect = objGeneralLedgerBL.GeneralLedger_Select_Receipt_Payment(3, Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));
                        if (objResultSelect != null)
                        {
                            dtSelect = objResultSelect.resultDT;

                            objControl.BindDropDown_ListBox(dtSelect, ddlGeneralLedger, "AccountName", "LedgerID");
                            ddlGeneralLedger.Items.Insert(0, new ListItem("--Select--", ""));
                        }
                    }
                }
                else
                {
                    ddlGeneralLedger.Items.Clear();
                    ddlGeneralLedger.Items.Insert(0, new ListItem("--Select--", ""));
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #endregion

        #region Gridview Events
        protected void gvPayments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ReceiptPaymentBL objReceiptPaymentBL = new ReceiptPaymentBL();
                ReceiptPaymentBO objReceiptPaymentBO = new ReceiptPaymentBO();
                ApplicationResult objResultSelect = new ApplicationResult();
                ViewState["ReceiptCode"] = e.CommandArgument.ToString();

                if (e.CommandName.ToString() == "Edit1")
                {
                    gvPayments.SelectedIndex = -1;
                    objResultSelect = objReceiptPaymentBL.ReceiptPayment_Select(ViewState["ReceiptCode"].ToString(), Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));
                    if (objResultSelect != null)
                    {
                        DataTable dtSelect = new DataTable();
                        dtSelect = objResultSelect.resultDT;
                        if (dtSelect.Rows.Count > 0)
                        {
                            ViewState["ReceiptRow"] = dtSelect.Rows.Count;
                            DataTable dt = new DataTable();

                            dt.Columns.Add("Number");
                            dt.Columns.Add("ReceiptPaymentID");
                            for (int i = 1; i <= Convert.ToInt32(ViewState["ReceiptRow"]); i++)
                            {
                                dt.Rows.Add(i.ToString(), "0");
                            }
                            ViewState["ADDRow"] = dt;
                            gvPaymentsEntry.DataSource = dt;
                            gvPaymentsEntry.DataBind();

                            BindAccountGroup();

                            txtDate.Text = dtSelect.Rows[0]["ReceiptPaymentDate"].ToString();
                            ddlReceiptMode.SelectedValue = dtSelect.Rows[0]["TransactionMode"].ToString();
                            ddlReceiptMode_SelectedIndexChanged(sender, e);
                            ddlGeneralLedger.SelectedValue = dtSelect.Rows[0]["GeneralLedger"].ToString();
                            txtVoucherCode.Text = ViewState["ReceiptCode"].ToString();
                            txtChequeNo.Text = dtSelect.Rows[0]["ChequeNo"].ToString();
                            txtNarration.Text = dtSelect.Rows[0]["Narration"].ToString();

                            for (int i = 0; i < dtSelect.Rows.Count; i++)
                            {
                                gvPaymentsEntry.Rows[i].Cells[0].Text = dtSelect.Rows[i][0].ToString();
                                ((DropDownList)gvPaymentsEntry.Rows[i].Cells[1].FindControl("ddlAccountName")).SelectedValue = dtSelect.Rows[i]["LedgerID"].ToString();
                                ((TextBox)gvPaymentsEntry.Rows[i].Cells[2].FindControl("txtDebitAmount")).Text = dtSelect.Rows[i]["Amount"].ToString();
                            }
                            PanelVisibility(2);
                            setControlScript();
                            getDebitCreditSum();
                            ViewState["Mode"] = "Edit";
                            fnOpeningBalance(Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]), Convert.ToInt32(ddlGeneralLedger.SelectedValue), txtDate.Text);
                        }
                    }
                }
                else if (e.CommandName.ToString() == "Delete1")
                {
                    ApplicationResult objResultDelete = new ApplicationResult();
                    objResultDelete = objReceiptPaymentBL.ReceiptPayment_Delete(e.CommandArgument.ToString(), "Payment");
                    if (objResultDelete.status == ApplicationResult.CommonStatusType.SUCCESS)
                    {
                        BindGrid();
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        protected void gvPayments_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void gvPayments_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvPayments.Rows.Count > 0)
                {
                    gvPayments.UseAccessibleHeader = true;
                    gvPayments.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        protected void gvPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvPayments.SelectedIndex = -1;
        }
        #endregion


        #region User Define Functions

        #region Bind Grid
        public void BindGrid()
        {
            try
            {
                ReceiptPaymentBL objReceiptPaymentBL = new ReceiptPaymentBL();
                ReceiptPaymentBO objReceiptPaymentBO = new ReceiptPaymentBO();
                ApplicationResult objResultSelectAll = new ApplicationResult();

                objResultSelectAll = objReceiptPaymentBL.ReceiptPayment_SelectAll(Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]), Convert.ToInt32(Session[ApplicationSession.FINANCIALYEAR]), Session[ApplicationSession.ACCOUNTFROMDATE].ToString(), Session[ApplicationSession.ACCOUNTTODATE].ToString(), "Payment");
                if (objResultSelectAll != null)
                {
                    DataTable dtSelectAll = new DataTable();
                    dtSelectAll = objResultSelectAll.resultDT;
                    gvPayments.DataSource = dtSelectAll;
                    gvPayments.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region Bind Account Group
        public void BindAccountGroup()
        {
            GeneralLedgerBL objGeneralLedgerBL = new GeneralLedgerBL();
            GeneralLedgerBO objGeneralLedgerBO = new GeneralLedgerBO();
            ApplicationResult objResultSelectAll = new ApplicationResult();
            DropDownList ddlAccountName = new DropDownList();
            objResultSelectAll = objGeneralLedgerBL.GeneralLedger_SelectAll_JournalEntry(Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));
            if (objResultSelectAll != null)
            {
                DataTable dtSelectAll = new DataTable();
                dtSelectAll = objResultSelectAll.resultDT;

                for (int i = 0; i < gvPaymentsEntry.Rows.Count; i++)
                {
                    ddlAccountName = (DropDownList)gvPaymentsEntry.Rows[i].Cells[0].FindControl("ddlAccountName");
                    if (ddlAccountName != null)
                    {
                        objControl.BindDropDown_ListBox(dtSelectAll, ddlAccountName, "AccountName", "LedgerID");
                        ddlAccountName.Items.Insert(0, new ListItem("", "-1"));
                    }
                }
            }
        }
        #endregion

        #region Clear Operation and Reset page
        public void clear()
        {
            objControl.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            ViewState["Mode"] = "Save";
            ViewState["ReceiptNo"] = "";
            ViewState["ReceiptCode"] = "";
            ViewState["ReceiptRow"] = "0";
            GetMaxDate();
            divlblBalance.Visible = false;

            gvPaymentsEntry.DataSource = null;
            getNewRows();
            gvPaymentsEntry.DataBind();

            BindAccountGroup();
            setControlScript();
            getDebitCreditSum();
        }
        #endregion

        #region Panel Visibility Mode
        public void PanelVisibility(int intcode)
        {
            if (intcode == 1)
            {
                divGrid.Visible = true;
                tabs.Visible = false;
                btnViewList.Visible = false;
            }
            else if (intcode == 2)
            {
                divGrid.Visible = false;
                tabs.Visible = true;
                btnViewList.Visible = true;
            }
        }
        #endregion

        #region SetJavascriptToControls
        public void setControlScript()
        {
            for (int i = 0; i < gvPaymentsEntry.Rows.Count; i++)
            {
                ((DropDownList)(gvPaymentsEntry.Rows[i].Cells[1].FindControl("ddlAccountName"))).Attributes.Add("onchange", "javascript:makeTextBoxFocus(" + i + ");");
                ((TextBox)(gvPaymentsEntry.Rows[i].Cells[2].FindControl("txtDebitAmount"))).Attributes.Add("onfocus", "javascript:colorfocusTextBox(" + (2 * i) + ");");
            }
            txtDate.Attributes.Add("onfocus", "javascript:clearFocus();");
            txtNarration.Attributes.Add("onfocus", "javascript:clearFocus();");

            btnAddRow.Attributes.Add("onfocus", "javascript:clearFocus();");
            btnSave.Attributes.Add("onfocus", "javascript:clearFocus();");
        }
        #endregion

        #region DisableAlternateText
        public void enableDisableText()
        {
            for (int i = 0; i < gvPaymentsEntry.Rows.Count; i++)
            {
                TextBox txtDebit = ((TextBox)(gvPaymentsEntry.Rows[i].Cells[1].FindControl("txtDebitAmount")));
                TextBox txtCredit = ((TextBox)(gvPaymentsEntry.Rows[i].Cells[2].FindControl("txtCreditAmount")));

                if (txtDebit.Text != "")
                {
                    txtCredit.Enabled = false;
                }
                else
                {
                    txtCredit.Enabled = true;
                }

                if (txtCredit.Text != "")
                {
                    txtDebit.Enabled = false;
                }
                else
                {
                    txtDebit.Enabled = true;
                }
            }
        }
        #endregion

        #region SumOfValuesInGridviewTextboxes
        public void getDebitCreditSum()
        {
            double dblDebitSum = 0.0, dblCreditSum = 0.0;
            TextBox txtDebitAmount = new TextBox();
            for (int i = 0; i < gvPaymentsEntry.Rows.Count; i++)
            {
                txtDebitAmount = (TextBox)(gvPaymentsEntry.Rows[i].Cells[2].FindControl("txtDebitAmount"));
                if (txtDebitAmount.Text.Length > 0)
                {
                    dblCreditSum += Convert.ToDouble(txtDebitAmount.Text.ToString());
                }
            }
            ((System.Web.UI.HtmlControls.HtmlInputText)(gvPaymentsEntry.FooterRow.Cells[2].FindControl("txtDebitSum"))).Value = dblCreditSum.ToString();
        }
        #endregion

        #region AddNewRowInGridDynamically
        public void getNewRows()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Number");
            dt.Columns.Add("ReceiptPaymentID");
            for (int i = 1; i <= 10; i++)
            {
                dt.Rows.Add(i.ToString(), "0");
            }
            ViewState["ADDRow"] = dt;
            gvPaymentsEntry.DataSource = dt;
            gvPaymentsEntry.DataBind();
        }
        #endregion

        #region Get Max Date

        public void GetMaxDate()
        {
            JournalVoucherMBL objJournalVoucherMBL = new JournalVoucherMBL();
            ApplicationResult objresult = new ApplicationResult();
            objresult = objJournalVoucherMBL.GetMaxDate(Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]), "Payment", Convert.ToInt32(Session[ApplicationSession.FINANCIALYEAR]));
            if (objresult != null)
            {
                DataTable dt = objresult.resultDT;
                if (dt.Rows[0][0].ToString() != "")
                    txtDate.Text = dt.Rows[0][0].ToString();
                else
                    txtDate.Text = Session[ApplicationSession.ACCOUNTTODATE].ToString();
            }
        }

        #endregion

        #region FindOpeningBalance
        private void fnOpeningBalance(int intTrustMID, int intSchoolMID, int intLedgerID, string strToDate)
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                GeneralLedgerBL objGLedgerBL = new GeneralLedgerBL();
                if (Convert.ToString(intLedgerID) != "")
                {
                    divlblBalance.Visible = true;
                    objResult = objGLedgerBL.Select_OpeningBalanceForAccounting(intTrustMID, intSchoolMID, intLedgerID, strToDate);
                    if (objResult != null)
                    {

                        if (objResult.resultDT.Rows.Count > 0)
                        {
                            lblCurrentBalance.Text = objResult.resultDT.Rows[0][0].ToString();
                        }
                        else
                        {
                            lblCurrentBalance.Text = "0";
                        }
                    }
                }
                else
                {
                    divlblBalance.Visible = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region SelectedIndexChanged og GeneralLedger Dropdown
        protected void ddlGeneralLedger_SelectedIndexChanged(object sender, EventArgs e)
        {

            fnOpeningBalance(Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]), Convert.ToInt32(ddlGeneralLedger.SelectedValue), txtDate.Text);
        }
        #endregion

        #endregion


    }
}