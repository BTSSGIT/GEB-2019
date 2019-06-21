﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using GEB_School.DataAccess;
using GEB_School.BO;
using GEB_School.Common;

namespace GEB_School.BL
{
    /// <summary>
    /// Class Created By : Nafisa, 01-06-2015
    /// Summary description for Organisation.
    /// </summary>
    public class EmployeeattendanceBl
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion


        #region Select All Employeeattendance Details
        /// <summary>
        /// To Select All data from the tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_SelectAll()
        {
            try
            {
                sSql = "usp_tbl_EmployeeAttendance_M_SelectAll";
                DataTable dtEmployeeattendance = new DataTable();
                dtEmployeeattendance = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtEmployeeattendance);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select Employeeattendance Details by EmployeeAttandenceMID
        /// <summary>
        /// Select all details of Employeeattendance for selected EmployeeAttandenceMID from tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="intEmployeeAttandenceMID"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_Select(int intEmployeeAttandenceMID)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@EmployeeAttandenceMID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intEmployeeAttandenceMID;

                strStoredProcName = "usp_tbl_EmployeeAttendance_M_Select";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select Employeeattendance For Check for same date data
        /// <summary>
        /// Select all details of Employeeattendance for selected EmployeeAttandenceMID from tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Employeeattendance_Select_ForBiomatric(string strAttendanceList, string strFilename)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@AttendanceList", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strAttendanceList;

                pSqlParameter[1] = new SqlParameter("@Filename", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strFilename;

                strStoredProcName = "usp_tbl_EmployeeAttendance_M_Select_ForBiomatric";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete Employeeattendance Details by EmployeeAttandenceMID
        /// <summary>
        /// To Delete details of Employeeattendance for selected EmployeeAttandenceMID from tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="intEmployeeAttandenceMID"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_Delete(int intEmployeeAttandenceMID)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@EmployeeAttandenceMID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intEmployeeAttandenceMID;

                pSqlParameter[1] = new SqlParameter("@LastModifiedUserID", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intEmployeeAttandenceMID;

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = intEmployeeAttandenceMID;

                strStoredProcName = "usp_tbl_EmployeeAttendance_M_Delete";

                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.FAILURE;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select Employeeattendance for Employee Monthly Report
        /// <summary>
        /// Select all details of Employeeattendance for selected EmployeeAttandenceMID from tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="intEmployeeAttandenceMID"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_Select_ForEmployeeMonthlyAttendance(string strMonth,string strAcademicYear)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@Month", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strMonth;

                pSqlParameter[1] = new SqlParameter("@AcademicYear", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strAcademicYear;

                strStoredProcName = "usp_rpt_EmployeeMonthlyAttendance";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select Employeeattendance for Employee Monthly Report
        /// <summary>
        /// Select all details of Employeeattendance for selected EmployeeAttandenceMID from tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="intEmployeeAttandenceMID"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_Select_ForEmployeeWiseAttendance(int intEmployeeMID, string strFromDate, string strToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@EmployeeMID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intEmployeeMID;

                pSqlParameter[1] = new SqlParameter("@FromDate", SqlDbType.VarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = strFromDate;

                pSqlParameter[2] = new SqlParameter("@ToDate", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strToDate;

                strStoredProcName = "usp_rpt_EmployeeWiseAttendance";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Insert Employeeattendance Details
        /// <summary>
        /// To Insert details of Employeeattendance in tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="objEmployeeattendanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_Insert(EmployeeattendanceBo objEmployeeattendanceBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[10];


                pSqlParameter[0] = new SqlParameter("@TrustMID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objEmployeeattendanceBO.TrustMID;

                pSqlParameter[1] = new SqlParameter("@SchoolMID", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objEmployeeattendanceBO.SchoolMID;

                pSqlParameter[2] = new SqlParameter("@EmployeeMID", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objEmployeeattendanceBO.EmployeeMID;

                pSqlParameter[3] = new SqlParameter("@InTime", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objEmployeeattendanceBO.InTime;

                pSqlParameter[4] = new SqlParameter("@OutTime", SqlDbType.VarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objEmployeeattendanceBO.OutTime;

                pSqlParameter[5] = new SqlParameter("@Date", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objEmployeeattendanceBO.Date;

                pSqlParameter[6] = new SqlParameter("@CreateModifiedUserID", SqlDbType.Int);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objEmployeeattendanceBO.CreateModifiedUserID;

                pSqlParameter[7] = new SqlParameter("@CreatedModifiedDate", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objEmployeeattendanceBO.CreatedModifiedDate;

                pSqlParameter[8] = new SqlParameter("@Time", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objEmployeeattendanceBO.Time;

                pSqlParameter[9] = new SqlParameter("@TotalTime", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objEmployeeattendanceBO.TotalTime;


                sSql = "usp_tbl_EmployeeAttendance_M_Insert";
                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.FAILURE;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objEmployeeattendanceBO = null;
            }
        }
        #endregion

        #region Insert Employeeattendance For Biomatric
        /// <summary>
        /// To Insert details of Employeeattendance in tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="objEmployeeattendanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_Insert_ForBioMatric(EmployeeattendanceBo objEmployeeattendanceBO, string strAttendanceList, string strFilename)
        {
            try
            {
                pSqlParameter = new SqlParameter[7];


                pSqlParameter[0] = new SqlParameter("@TrustMID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objEmployeeattendanceBO.TrustMID;

                pSqlParameter[1] = new SqlParameter("@SchoolMID", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objEmployeeattendanceBO.SchoolMID;

                pSqlParameter[2] = new SqlParameter("@IsManual", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objEmployeeattendanceBO.IsManual;

                pSqlParameter[3] = new SqlParameter("@CreateModifiedUserID", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objEmployeeattendanceBO.CreateModifiedUserID;

                pSqlParameter[4] = new SqlParameter("@CreatedModifiedDate", SqlDbType.VarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objEmployeeattendanceBO.CreatedModifiedDate;

                pSqlParameter[5] = new SqlParameter("@AttendanceList", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = strAttendanceList;

                pSqlParameter[6] = new SqlParameter("@Filename", SqlDbType.VarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = strFilename;

                sSql = "usp_tbl_EmployeeAttendance_M_Insert_ForBiomatric";
                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.FAILURE;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objEmployeeattendanceBO = null;
            }
        }
        #endregion

        #region Update Employeeattendance Details
        /// <summary>
        /// To Update details of Employeeattendance in tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="objEmployeeattendanceBO"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_Update(EmployeeattendanceBo objEmployeeattendanceBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[10];


                pSqlParameter[0] = new SqlParameter("@EmployeeMID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objEmployeeattendanceBO.EmployeeMID;

                pSqlParameter[1] = new SqlParameter("@TrustMID", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objEmployeeattendanceBO.TrustMID;

                pSqlParameter[2] = new SqlParameter("@SchoolMID", SqlDbType.Int);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objEmployeeattendanceBO.SchoolMID;

                pSqlParameter[3] = new SqlParameter("@InTime", SqlDbType.VarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objEmployeeattendanceBO.InTime;

                pSqlParameter[4] = new SqlParameter("@OutTime", SqlDbType.VarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objEmployeeattendanceBO.OutTime;

                pSqlParameter[5] = new SqlParameter("@Date", SqlDbType.VarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objEmployeeattendanceBO.Date;

                pSqlParameter[6] = new SqlParameter("@LastModifiedUserID", SqlDbType.Int);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objEmployeeattendanceBO.LastModifiedUserID;

                pSqlParameter[7] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objEmployeeattendanceBO.LastModifiedDate;

                pSqlParameter[8] = new SqlParameter("@Time", SqlDbType.VarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objEmployeeattendanceBO.Time;

                pSqlParameter[9] = new SqlParameter("@TotalTime", SqlDbType.VarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objEmployeeattendanceBO.TotalTime;


                sSql = "usp_tbl_EmployeeAttendance_M_Update";
                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.status = ApplicationResult.CommonStatusType.FAILURE;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objEmployeeattendanceBO = null;
            }
        }
        #endregion




        #region Select Employeeattendance Details by EmployeeattendanceName
        /// <summary>
        /// Select all details of Employeeattendance for selected EmployeeattendanceName from tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="EmployeeattendanceName"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_Select_byEmployeeattendanceName(string strEmployeeattendanceName)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@EmployeeattendanceName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strEmployeeattendanceName;

                strStoredProcName = "usp_tbl_EmployeeAttendance_M_Select_ByEmployeeattendance";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region ValidateName for Employeeattendance
        /// <summary>
        /// Function which validates whether the EmployeeattendanceName already exits in tbl_EmployeeAttendance_M table.
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="strEmployeeattendanceName"></param>
        /// <returns></returns>
        public ApplicationResult Employeeattendance_ValidateName(string strEmployeeattendanceName)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@EmployeeattendanceName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strEmployeeattendanceName;

                strStoredProcName = "usp_tbl_EmployeeAttendance_M_Validate_EmployeeattendanceName";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete Employeeattendance Details by EmployeeAttandenceMID
        /// <summary>
        /// To Delete details of Employeeattendance for selected EmployeeAttandenceMID from tbl_EmployeeAttendance_M table
        /// Created By : Nafisa, 01-06-2015
        /// Modified By :
        /// </summary>
        /// <param name="intEmployeeAttandenceMID"></param>
        /// <returns></returns>
        public ApplicationResult Select_Employee_ForAttandanceDateWise(string strDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Date", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = strDate;

                strStoredProcName = "usp_tbl_EmployeeAttendence_M_Select_DateWise";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.status = ApplicationResult.CommonStatusType.SUCCESS;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}


