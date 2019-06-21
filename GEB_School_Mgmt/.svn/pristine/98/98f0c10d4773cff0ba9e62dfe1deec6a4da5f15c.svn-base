using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using GEB_School.Common;
using GEB_School.BL;
using GEB_School.BO;
using System.IO;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using log4net;
using GEB_School.DataAccess;

namespace GEB_School.Client.UI
{
    public partial class FeeCollection : PageBase
    {
        private static ILog logger = LogManager.GetLogger(typeof(FeeCollection));
        #region Declaration
        double totalAmount = 0;
        double totalAmount2 = 0;
        double FinalTotal = 0;
        double totalPaidAmount = 0;
        double FinalpaidTotal = 0;
        double totalPendingAmount = 0;
        double FinalPendingTotal = 0;
        double TotalDiscount = 0;
        double TotalPaidAmount = 0;
        double totalAmount1 = 0;
        double FinalTotal1 = 0;
        double totalPaidAmount1 = 0;
        double FinalpaidTotal1 = 0;
        double totalPendingAmount1 = 0;
        double FinalPendingTotal1 = 0;
        double FinalCurrentTotal1 = 0;
        double FinalCurrentTotal = 0;
        int initialInsert = 0;
        double Discount = 0;
        double Discount1 = 0;
        #endregion

        #region Pageload Event
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
                    //txtdate.Attributes.Add("readonly", "readonly");
                    txtAmountPaid.Attributes.Add("readonly", "readonly");
                    divFeePanel.Visible = false;
                    foreach (GridViewRow row in gvFees.Rows)
                    {
                        TextBox txtTotalAmount = (TextBox)row.FindControl("txtTotalAmount");
                        TextBox txtFeesAmount = (TextBox)row.FindControl("txtFeeAmount");
                        txtTotalAmount.Attributes.Add("readonly", "readonly");
                        txtFeesAmount.Attributes.Add("readonly", "readonly");

                    }
                    Session["FYear"] = GetCurrentFinancialYear();
                }
                catch (Exception ex)
                {
                    logger.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
        }
        #endregion

        #region Bind Fees Gridview
        protected void BindFeesGrid()
        {
            try
            {
                FeesCollectionBL objFeeCollectionBL = new FeesCollectionBL();
                ApplicationResult objResults = new ApplicationResult();
                objResults = objFeeCollectionBL.Fee_Collection_WithOptionalAndCompulsoryFees(Convert.ToInt32(ViewState["StudentMID"].ToString()));
                if (objResults != null)
                {
                    gvFees.Visible = true;
                    gvFees.DataSource = objResults.resultDT;
                    gvFees.DataBind();
                    if (objResults.resultDT.Rows.Count > 0)
                    {   
                        divFeeVisibility.Visible = true;
                        lblFee.Visible = false;
                        pnlFees.Visible = true;
                    }
                    else
                    {

                        // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Class Fee Template is not defined for " + Convert.ToInt32(ViewState["ClassName"].ToString()) + "-" + ViewState["Division"].ToString() + "( " + ViewState["AcademicYear"].ToString() + " ).');</script>");
                        divFeePanel.Visible = true;
                        divFeeVisibility.Visible = false;
                        pnlFees.Visible = false;
                        lblFee.Visible = true;
                        lblFee.Text = "No fee Details";

                    }

                }

                objResults = objFeeCollectionBL.Fee_Collection_PastDetail(Convert.ToInt32(Session[ApplicationSession.SCHOOLID]), Convert.ToInt32(ViewState["ClassMID"].ToString()), Convert.ToInt32(ViewState["DivisionName"].ToString()), ViewState["AcademicYear"].ToString(), Convert.ToInt32(ViewState["StudentMID"].ToString()));
                if (objResults != null)
                {
                    if (objResults.resultDT.Rows.Count > 0)
                    {
                        lblmsg.Visible = false;
                        gvPastFees.Visible = true;
                        gvPastFees.DataSource = objResults.resultDT;
                        gvPastFees.DataBind();
                        divFeeVisibility.Visible = true;
                    }
                    else
                    {
                        //divPastFees.Visible = false;
                        lblmsg.Visible = true;
                        lblmsg.Text = "No Past Record.";
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

        #region Bind Report Gridview
        protected void BindFeesReport()
        {
            try
            {
                FeesCollectionBL objFeeCollectionBL = new FeesCollectionBL();
                ApplicationResult objResults = new ApplicationResult();
                objResults = objFeeCollectionBL.FeesCollection_Report(Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]), Convert.ToInt32(ViewState["FeesCollectionMID"]));
                if (objResults != null)
                {
                    if (objResults.resultDT.Rows.Count > 0)
                    {
                        gvReport.Visible = true;
                        gvReport.DataSource = objResults.resultDT;
                        gvReport.DataBind();

                        gvReport1.Visible = true;
                        gvReport1.DataSource = objResults.resultDT;
                        gvReport1.DataBind();
                    }
                    else
                    {
                        gvReport.Visible = false;
                        gvReport1.Visible = false;
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

        #region RowDataBound Event of Fees Report
        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalAmount2 = totalAmount2 + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FeesAmount"));
                    totalPaidAmount = totalPaidAmount + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PaidFees"));
                    Discount = Discount + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ScholarShip"));
                    totalPendingAmount = totalPendingAmount + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PendingFees"));
                    FinalCurrentTotal = FinalCurrentTotal + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CurrentlyPaid"));
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblTotalAmount = (Label)e.Row.FindControl("lblTotalAmount");
                    lblTotalAmount.Text = totalAmount2.ToString();

                    Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
                    lblPaidAmount.Text = totalPaidAmount.ToString();

                    Label lblDiscount = (Label)e.Row.FindControl("lblDiscount");
                    lblDiscount.Text = Discount.ToString();

                    Label lblCurrentlyPaid = (Label)e.Row.FindControl("lblCurrentAmount");
                    lblCurrentlyPaid.Text = FinalCurrentTotal.ToString();

                    Label lblPendingAmount = (Label)e.Row.FindControl("lblPendingAmount");
                    lblPendingAmount.Text = totalPendingAmount.ToString();

                }
                CommonFunctions objFuction = new CommonFunctions();
                lblcurAmount.Text = objFuction.ConvertInWords(Convert.ToInt32(FinalCurrentTotal));
                lblCurAmountInt.Text = Convert.ToString(FinalCurrentTotal);
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region RowDataBound Event of Fees Report
        protected void gvReport1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalAmount1 = totalAmount1 + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FeesAmount"));
                    totalPaidAmount1 = totalPaidAmount1 + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PaidFees"));
                    Discount1 = Discount1 + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ScholarShip"));
                    totalPendingAmount1 = totalPendingAmount1 + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PendingFees"));
                    FinalCurrentTotal1 = FinalCurrentTotal1 + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CurrentlyPaid"));

                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblTotalAmount1 = (Label)e.Row.FindControl("lblTotalAmount1");
                    lblTotalAmount1.Text = totalAmount1.ToString();

                    Label lblCurrentlyPaid1 = (Label)e.Row.FindControl("lblCurrentAmount1");
                    lblCurrentlyPaid1.Text = FinalCurrentTotal1.ToString();

                    Label lblDiscount1 = (Label)e.Row.FindControl("lblDiscount1");
                    lblDiscount1.Text = Discount1.ToString();

                    Label lblPaidAmount1 = (Label)e.Row.FindControl("lblPaidAmount1");
                    lblPaidAmount1.Text = totalPaidAmount1.ToString();

                    Label lblPendingAmount1 = (Label)e.Row.FindControl("lblPendingAmount1");
                    lblPendingAmount1.Text = totalPendingAmount1.ToString();

                }
                CommonFunctions objFuction = new CommonFunctions();
                lblcurAmount1.Text = objFuction.ConvertInWords(Convert.ToInt32(FinalCurrentTotal));
                lblCurAmountInt1.Text = Convert.ToString(FinalCurrentTotal1);
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region Gridview Row COmmand Event
        protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                btnSave.Enabled = true;
                btnSave.Attributes.Add("bgcolor", "#848484");
                Controls objControls = new Controls();
                StudentBL objStudentBL = new StudentBL();
                ApplicationResult objResults = new ApplicationResult();
                if (e.CommandName.ToString() == "Edit1")
                {
                    ViewState["StudentMID"] = Convert.ToInt32(e.CommandArgument.ToString());
                    divFeePanel.Visible = true;
                    objResults = objStudentBL.Student_Select(Convert.ToInt32(ViewState["StudentMID"].ToString()), 0);

                    if (objResults != null)
                    {
                        if (objResults.resultDT.Rows.Count > 0)
                        {

                            ViewState["DivisionName"] = objResults.resultDT.Rows[0][StudentBO.STUDENT_CURRENTDIVISIONTID].ToString();
                            #region Find DivisionName
                            DivisionTBL objDivision = new DivisionTBL();
                            ApplicationResult objResultsDivision = new ApplicationResult();
                            objResultsDivision = objDivision.DivisionT_Select_By_DivisionTID(Convert.ToInt32(objResults.resultDT.Rows[0][StudentBO.STUDENT_CURRENTDIVISIONTID].ToString()));
                            if (objResultsDivision != null)
                            {
                                if (objResultsDivision.resultDT.Rows.Count > 0)
                                {
                                    ViewState["Division"] = objResultsDivision.resultDT.Rows[0][DivisionTBO.DIVISIONT_DIVISIONNAME].ToString();
                                }

                            }
                            #endregion

                            #region Find SectionName
                            SectionBL objSection = new SectionBL();
                            ApplicationResult objResultsSection = new ApplicationResult();
                            objResultsSection = objSection.Section_Select(Convert.ToInt32(objResults.resultDT.Rows[0][StudentBO.STUDENT_CURRENTSECTIONID].ToString()));
                            if (objResultsSection != null)
                            {
                                if (objResultsSection.resultDT.Rows.Count > 0)
                                {
                                    ViewState["SectionName"] = objResultsSection.resultDT.Rows[0][SectionBO.SECTION_SECTIONNAME].ToString();
                                }

                            }
                            #endregion

                            #region Find Class
                            ClassBL objClass = new ClassBL();
                            ApplicationResult objResultsClass = new ApplicationResult();
                            objResultsClass = objClass.Class_Select(Convert.ToInt32(objResults.resultDT.Rows[0][StudentBO.STUDENT_CURRENTCLASSID].ToString()));
                            if (objResultsClass != null)
                            {

                                if (objResultsClass.resultDT.Rows.Count > 0)
                                {
                                    ViewState["ClassMID"] = objResultsClass.resultDT.Rows[0][ClassBO.CLASS_CLASSMID].ToString();
                                    lblClassDivision.Text = objResultsClass.resultDT.Rows[0][ClassBO.CLASS_CLASSNAME].ToString() + "-" + ViewState["Division"].ToString();
                                    ViewState["ClassName"] = objResultsClass.resultDT.Rows[0][ClassBO.CLASS_CLASSNAME].ToString();
                                }

                            }
                            #endregion

                            lblAdmissionNo.Text = objResults.resultDT.Rows[0][StudentBO.STUDENT_ADMISSIONNO].ToString();
                            lblCurrentGrNo.Text = objResults.resultDT.Rows[0][StudentBO.STUDENT_CURRENTGRNO].ToString();
                            lblStudentNameEng.Text = objResults.resultDT.Rows[0][StudentBO.STUDENT_STUDENTLASTNAMEENG].ToString() + " " + objResults.resultDT.Rows[0][StudentBO.STUDENT_STUDENTFIRSTNAMEENG].ToString() + " " + objResults.resultDT.Rows[0][StudentBO.STUDENT_STUDENTMIDDLENAMEENG].ToString();

                            lblCurrentSection.Text = ViewState["SectionName"].ToString();
                            lblAcademicYear.Text = objResults.resultDT.Rows[0][StudentBO.STUDENT_CURRENTYEAR].ToString();
                            ViewState["AcademicYear"] = objResults.resultDT.Rows[0][StudentBO.STUDENT_CURRENTYEAR].ToString();
                           
                        }
                    }
                    divFeePanel.Visible = true;
                    BindFeesGrid();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region RowDataBound Event of Fees Gridview
        protected void gvFees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    totalAmount = totalAmount + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FeesAmount"));
                    FinalTotal = FinalTotal + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FeesAmount"));
                    
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblamount = (Label)e.Row.FindControl("lblFeeAmount");
                    lblamount.Text = totalAmount.ToString();

                    Label lblTotal = (Label)e.Row.FindControl("lblTotalAmount");
                    lblTotal.Text = FinalTotal.ToString();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region Row Data Bound of Past Fee Deatils Gridview
        protected void gvPastFees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TotalPaidAmount = TotalPaidAmount + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FeesAmount"));
                    TotalDiscount = TotalDiscount + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Discount"));
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblPaidDiscount = (Label)e.Row.FindControl("lblTotalGivenDiscount");
                    lblPaidDiscount.Text = TotalDiscount.ToString();

                    Label lblTotal = (Label)e.Row.FindControl("lblTotalPaidFees");
                    lblTotal.Text = TotalPaidAmount.ToString();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region Save Click Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            FeesCollectionBL objFeeCollectionBL = new FeesCollectionBL();
            FeesCollectionBO objFeeCollectionBO = new FeesCollectionBO();
            FeesCollectionTBO objFeeCollectionTBO = new FeesCollectionTBO();
            ApplicationResult objResults = new ApplicationResult();
            //ApplicationResult objResultsJM = new ApplicationResult();
            //JournalVoucherMBL objJournalVoucherMBL = new JournalVoucherMBL();
            //JournalVoucherMBO objJournalVoucherMBO = new JournalVoucherMBO();
            try
            {
                float Total = 0;


                // Label lblTotalAmount = (Label)gvFees.FooterRow.FindControl("lblTotalAmount");
                objFeeCollectionBO.SchoolMID = Convert.ToInt32(Session[ApplicationSession.SCHOOLID]);
                objFeeCollectionBO.TrustMID = Convert.ToInt32(Session[ApplicationSession.TRUSTID]);
                objFeeCollectionBO.StudentMID = Convert.ToInt32(ViewState["StudentMID"].ToString());
                objFeeCollectionBO.FeesToBePaid = Convert.ToDouble(txtFullAmount.Text);
                objFeeCollectionBO.AmountPaid = Convert.ToDouble(txtAmountPaid.Text);
                objFeeCollectionBO.Date = txtdate.Text;
                objFeeCollectionBO.CancellationReason = "";
                objFeeCollectionBO.AcademicYear = ViewState["AcademicYear"].ToString();
                objFeeCollectionBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                objFeeCollectionBO.LastModifiedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                string FeesCollectionTIDs = string.Empty;
                int Count = 0;
                foreach (GridViewRow row in gvFees.Rows)
                {
                    ViewState["ClassTemplateIDs"] = Convert.ToInt32(row.Cells[0].Text);

                    if (((CheckBox)row.FindControl("chkChild")).Checked)
                    {

                        TextBox txt = (TextBox)row.FindControl("lblAcademicYear");
                        ViewState["Class"] = Convert.ToInt32(row.Cells[11].Text);
                        ViewState["Division"] = Convert.ToInt32(row.Cells[12].Text);
                        ViewState["Year"] = txt.Text;
                        lblFinancialYear.Text = GetCurrentFinancialYear();
                        lblFYear.Text = GetCurrentFinancialYear();
                        FeesCollectionTIDs += ViewState["ClassTemplateIDs"].ToString() + ",";
                        Count = Count + 1;
                    }
                }
                objFeeCollectionBO.ClassMID = Convert.ToInt32(ViewState["Class"].ToString());
                objFeeCollectionBO.DivisionTID = Convert.ToInt32(ViewState["Division"].ToString());
                objFeeCollectionBO.AcademicYear = ViewState["Year"].ToString();
                objFeeCollectionBO.ClassWiseTemplateIDs = FeesCollectionTIDs.TrimEnd(',');
                //objFeeCollectionTBO
                // jornal M
                // objJournalVoucherMBO.TrustMID = Convert.ToInt32(Session[ApplicationSession.TRUSTID]);
                // objJournalVoucherMBO.SchoolMID = Convert.ToInt32(Session[ApplicationSession.SCHOOLID]);
                //// objJournalVoucherMBO.SchoolMID = 0;
                // objJournalVoucherMBO.VoucherDate = txtdate.Text;
                // objJournalVoucherMBO.OperationType = "Journal";
                // objJournalVoucherMBO.Description = "Fee recieved from student: " + lblStudentNameEng.Text + " in Class " + lblClassDivision.Text + "/" + ViewState["AcademicYear"].ToString();
                // objJournalVoucherMBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.USERID]);
                // objJournalVoucherMBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
                // objJournalVoucherMBO.IsDeleted = 0;
                // objJournalVoucherMBO.LastModifideDate = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
                // objJournalVoucherMBO.LastModifideUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);

                // string[] words = ViewState["AcademicYear"].ToString().Split('-');
                // string Year = words[0] + words[1];
                // objJournalVoucherMBO.Year = Convert.ToInt32(Year);


                //if (initialInsert == 0)
                //{
                //    objJournalVoucherMBO.LedgerID = 2;
                //    objJournalVoucherMBO.TransactionType = "Debit";
                //    objJournalVoucherMBO.Amount = Convert.ToDouble(txtAmountPaid.Text);
                DatabaseTransaction.OpenConnectionTransation();
                //    objResultsJM = objJournalVoucherMBL.JournalVoucherM_Insert(objJournalVoucherMBO);
                //    initialInsert++;
                //    if (objResultsJM != null)
                //    {
                //        DataTable dt = new DataTable();
                //        dt = objResultsJM.resultDT;
                //        if (initialInsert == 1)
                //        {
                //            if (dt.Rows.Count > 0)
                //            {
                //                if (dt.Rows[0][0].ToString() == "Fail")
                //                {
                //                    DatabaseTransaction.RollbackTransation();
                //                    //ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Please Initialize Voucher Start No. For This Year.');</script>");
                //                    initialInsert = 100;// not allow to go in for loop and any transactin and master entry insert
                //                }
                //                else
                //                {
                //                    ViewState["VoucherNoJM"] = Convert.ToInt32(dt.Rows[0][0]);
                //                    ViewState["VoucherCode"] = dt.Rows[0][1].ToString();
                //                    objJournalVoucherMBO.VoucherNo = Convert.ToInt32(ViewState["VoucherNoJM"]);
                //                    objJournalVoucherMBO.VoucherCode = ViewState["VoucherCode"].ToString();
                //                }
                //            }
                //        }

                //    }
                //}
                // Total = Total + txtFeesAmount;
                objResults = objFeeCollectionBL.FeesCollection_Insert(objFeeCollectionBO);
                if (objResults != null)
                {
                    ViewState["FeesCollectionMID"] = Convert.ToInt32(objResults.resultDT.Rows[0][0].ToString());
                    ViewState["VoucherNo"] = Convert.ToInt32(objResults.resultDT.Rows[0][1].ToString());
                    if (initialInsert != 100)
                    {


                        for (int i = 0; i < gvFees.Rows.Count; i++)
                        {
                            if (((CheckBox)gvFees.Rows[i].FindControl("chkChild")).Checked)
                            {

                                ViewState["ClassWiseFeesTemplateTID"] = Convert.ToInt32(gvFees.Rows[i].Cells[0].Text);
                                ViewState["LedgerID"] = Convert.ToInt32(gvFees.Rows[i].Cells[10].Text);
                                objFeeCollectionTBO.FeesCollectionMID = Convert.ToInt32(ViewState["FeesCollectionMID"].ToString());
                                TextBox txtDiscount = (TextBox)gvFees.Rows[i].Cells[4].FindControl("txtDiscountAmount");
                                TextBox txtFeesAmount = (TextBox)gvFees.Rows[i].Cells[6].FindControl("txtTotalAmount");
                                TextBox txtRemainingAmount = (TextBox)gvFees.Rows[i].Cells[7].FindControl("txtRemainingAmount");
                                objFeeCollectionTBO.Discount = Convert.ToInt32(txtDiscount.Text);
                                objFeeCollectionTBO.FeesAmount = Convert.ToInt32(txtFeesAmount.Text);
                                objFeeCollectionTBO.RemainingAmount = Convert.ToDouble(txtRemainingAmount.Text);
                                objFeeCollectionTBO.ClassWiseFeesTemplateTID = Convert.ToInt32(ViewState["ClassWiseFeesTemplateTID"]);
                                objFeeCollectionTBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                                objFeeCollectionTBO.LastModifiedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                                objResults = objFeeCollectionBL.FeesCollectionT_Insert(objFeeCollectionTBO);
                                if (objResults != null)
                                {
                                    //ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('Fees are Collected.');</script>");
                                }

                                // insertion of Journal Voucher M



                                //if (initialInsert == 1)
                                //{
                                //    objJournalVoucherMBO.LedgerID = Convert.ToInt32(ViewState["LedgerID"].ToString());
                                //    objJournalVoucherMBO.TransactionType = "Credit";
                                //    objJournalVoucherMBO.Amount = Convert.ToInt32(txtFeesAmount.Text);
                                //    // initialInsert++;
                                //    objResultsJM = objJournalVoucherMBL.JournalVoucherM_Insert(objJournalVoucherMBO);
                                //}
                            }

                        }
                        // insertLedgerTransaction(ViewState["VoucherCode"].ToString());
                    }
                   
                    DatabaseTransaction.CommitTransation();
                    BindFeesGrid();
                    //string strToDate = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                    //string LastTwoDigit, strYear;
                    //int intNo;
                    //LastTwoDigit = strToDate.Substring(strToDate.Length - 2);
                    //intNo = Convert.ToInt32(LastTwoDigit) - 1;
                    //strYear = intNo.ToString()+'-'+  LastTwoDigit;
                    lblStudentName.Text = lblStudentNameEng.Text;
                    lblVoucherNo.Text = GetCurrentFinancialYear() + "/" + ViewState["VoucherNo"].ToString();
                    Session["FYear"] = GetCurrentFinancialYear();
                    lblStd.Text = lblClassDivision.Text;
                    lblDate.Text = txtdate.Text;
                    lblStudentName1.Text = lblStudentNameEng.Text;
                    lblVoucherNo1.Text = GetCurrentFinancialYear() + "/" + ViewState["VoucherNo"].ToString();
                    lblStd1.Text = lblClassDivision.Text;
                    lblDate1.Text = txtdate.Text;
                    BindFeesReport();
                    ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "getPrint('divFeeCollectionPrint');", true);
                    txtdate.Text = "";
                    ViewState["AcademicYear"] = "";
                    divFeePanel.Visible = false;
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Please Initialize Voucher Start No. For This Year.');</script>");
                }

            }
            catch (Exception ex)
            {
                DatabaseTransaction.RollbackTransation();
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        public static string GetCurrentFinancialYear()
        {
            int CurrentYear = DateTime.UtcNow.AddHours(5.5).Year;
            int PreviousYear = DateTime.UtcNow.AddHours(5.5).Year - 1;
            int NextYear = DateTime.UtcNow.AddHours(5.5).Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.UtcNow.AddHours(5.5).Month > 3)
                FinYear = CurYear.Substring(2, 2) + "-" + NexYear.Substring(2, 2);
            else
                FinYear = PreYear.Substring(2, 2) + "-" + CurYear.Substring(2, 2);
            return FinYear.Trim();
        }

        #region Go for Searching Student
        protected void btnGo_Click(object sender, EventArgs e)
        {
            gvFees.Visible = false;
            gvPastFees.Visible = false;
            try
            {
                StudentBL objStudentBL = new StudentBL();
                StudentBO objStudentBO = new StudentBO();

                ApplicationResult objResultProgram = new ApplicationResult();
                objResultProgram = objStudentBL.Student_Search_StudentName(txtSearchName.Text, Convert.ToInt32(ddlSearchBy.SelectedValue), Convert.ToInt32(Session[ApplicationSession.ROLEID].ToString()), Convert.ToInt32(Session[ApplicationSession.SCHOOLID].ToString()));
                if (objResultProgram != null)
                {

                    if (objResultProgram.resultDT.Rows.Count > 0)
                    {
                        gvStudent.Visible = true;
                        gvStudent.DataSource = objResultProgram.resultDT;
                        gvStudent.DataBind();
                        divFeePanel.Visible = false;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script language='javascript'>alert('No Record Found.');</script>");
                        gvStudent.Visible = false;
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

        #region InsertDataIntoTransactionTable
        public void insertLedgerTransaction(string strVoucherCode)
        {
            JournalVoucherMBL objJournalVoucherMBL = new JournalVoucherMBL();
            JournalVoucherTBL objJournalVoucherTBL = new JournalVoucherTBL();
            JournalVoucherTBO objJournalVoucherTBO = new JournalVoucherTBO();
            ApplicationResult objResultSelect = new ApplicationResult();
            ApplicationResult objResultInsert = new ApplicationResult();
            DataTable dt = new DataTable();

            objResultSelect = objJournalVoucherMBL.JournalVoucherM_Select(strVoucherCode, Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]));
            if (objResultSelect != null)
            {
                dt = objResultSelect.resultDT;
                if (dt.Rows.Count > 0)
                {
                    int intJournalID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        int intOppJpurnaaID = Convert.ToInt32(dt.Rows[i][0].ToString());

                        objJournalVoucherTBO.JournalID = intJournalID;
                        objJournalVoucherTBO.OppositeJournalID = intOppJpurnaaID;
                        objJournalVoucherTBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
                        objJournalVoucherTBO.CreatedUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);
                        objJournalVoucherTBO.IsDeleted = 0;
                        objJournalVoucherTBO.LastModifideDate = DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy");
                        objJournalVoucherTBO.LastModifideUserID = Convert.ToInt32(Session[ApplicationSession.USERID]);

                        objResultInsert = objJournalVoucherTBL.JournalVoucherT_Insert(objJournalVoucherTBO);
                    }
                }
            }
        }
        #endregion

        #region Get Employee Web Service Method
        [System.Web.Services.WebMethod]
        public static string[] GetAllStudentNameForReport(string prefixText, int SearchType, int SchoolMID)
        {
            StudentBL objEmployeeMbl = new StudentBL();
            ApplicationResult objResult = new ApplicationResult();
            string strSearchText = prefixText + "%";
            List<string> result = new List<string>();
            objResult = objEmployeeMbl.Student_ForAutocomplete(strSearchText, SearchType, SchoolMID);
            if (objResult != null)
            {
                for (int i = 0; i < objResult.resultDT.Rows.Count; i++)
                {
                    if (SearchType == 1)
                    {
                        string strStudentName = objResult.resultDT.Rows[i]["StudentName"].ToString();
                        string strStudentMID = objResult.resultDT.Rows[i][StudentBO.STUDENT_STUDENTMID].ToString();
                        result.Add(string.Format("{0}~{1}", strStudentName, strStudentMID));
                    }
                    else if (SearchType == 2)
                    {
                        string strStudentGRNo = objResult.resultDT.Rows[i]["CurrentGrNo"].ToString();
                        string strEmployeeMID = objResult.resultDT.Rows[i][StudentBO.STUDENT_STUDENTMID].ToString();
                        result.Add(string.Format("{0}~{1}", strStudentGRNo, strEmployeeMID));
                    }
                    else if (SearchType == 3)
                    {
                        string strAdmission = objResult.resultDT.Rows[i]["AdmissionNo"].ToString();
                        string strEmployeeMID = objResult.resultDT.Rows[i][StudentBO.STUDENT_STUDENTMID].ToString();
                        result.Add(string.Format("{0}~{1}", strAdmission, strEmployeeMID));
                    }
                    else if (SearchType == 4)
                    {
                        string strUniqueID = objResult.resultDT.Rows[i]["UniqueID"].ToString();
                        string strEmployeeMID = objResult.resultDT.Rows[i][StudentBO.STUDENT_STUDENTMID].ToString();
                        result.Add(string.Format("{0}~{1}", strUniqueID, strEmployeeMID));
                    }
                }
            }
            return result.ToArray();
        }

        #endregion

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }

        #region GridView PastFees RowCommand
        protected void gvPastFees_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "Print1")
                {
                    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer; 
                    
                    int ReceiptNo = Convert.ToInt32(e.CommandArgument.ToString());
                    int rowIndex = gvr.RowIndex;
                    Label lblRecNo = (Label)gvPastFees.Rows[rowIndex].Cells[0].FindControl("lblRcNo");
                    string strDate = gvPastFees.Rows[rowIndex].Cells[2].Text;
                    string strName = lblStudentNameEng.Text;
                    string strClass = lblClassDivision.Text;
                    lblFinancialYear.Text = lblRecNo.Text.Split('/')[0];
                    lblVoucherNo.Text = lblRecNo.Text;
                    lblDate.Text = strDate;
                    lblStudentName.Text = strName;
                    lblStd.Text = strClass.Split(' ')[0];
                    lblFYear.Text = lblRecNo.Text.Split('/')[0];
                    lblVoucherNo1.Text = lblRecNo.Text;
                    lblDate1.Text = strDate;
                    lblStudentName1.Text = strName;
                    lblStd1.Text = strClass.Split(' ')[0];

                    FeesCollectionBL objFeeCollectionBL = new FeesCollectionBL();
                    ApplicationResult objResults = new ApplicationResult();

                    objResults = objFeeCollectionBL.FeesCollection_RePrint(Convert.ToInt32(Session[ApplicationSession.TRUSTID]), Convert.ToInt32(Session[ApplicationSession.SCHOOLID]), ReceiptNo, Convert.ToInt32((ViewState["StudentMID"])));
                    if (objResults != null)
                    {
                        if (objResults.resultDT.Rows.Count > 0)
                        {
                            gvReport.Visible = true;
                            gvReport.DataSource = objResults.resultDT;
                            gvReport.DataBind();

                            gvReport1.Visible = true;
                            gvReport1.DataSource = objResults.resultDT;
                            gvReport1.DataBind();
                        }
                        else
                        {
                            gvReport.Visible = false;
                            gvReport1.Visible = false;
                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "getPrint('divFeeCollectionPrint');", true);
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