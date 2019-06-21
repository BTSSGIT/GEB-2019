using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace GEB_School.Bo
{
	public class LeaveApplyBo
	{
		#region LeaveApply Class Properties
		
		public const string LEAVEAPPLY_TABLE = "tbl_LeaveApply";
		public const string LEAVEAPPLY_LEAVEAPPLYLID = "LeaveApplylID";
		public const string LEAVEAPPLY_EMPLOYEEMID = "EmployeeMID";
		public const string LEAVEAPPLY_FROMDATE = "FromDate";
		public const string LEAVEAPPLY_TODATE = "ToDate";
		public const string LEAVEAPPLY_REASON = "Reason";
		public const string LEAVEAPPLY_APPROVEDBY = "ApprovedBy";
		public const string LEAVEAPPLY_APPROVEDDATE = "ApprovedDate";
		public const string LEAVEAPPLY_TOTALDAYS = "TotalDays";
		public const string LEAVEAPPLY_ISDELETED = "IsDeleted";
		public const string LEAVEAPPLY_CREATEDBY = "CreatedBy";
		public const string LEAVEAPPLY_CREATEDDATE = "CreatedDate";
		public const string LEAVEAPPLY_LASTMODIFIEDBY = "LastModifiedBy";
		public const string LEAVEAPPLY_LASTMODIFIEDDATE = "LastModifiedDate";
		
			
		
		private int intLeaveApplylID = 0;
		private int intEmployeeMID = 0;
		private string strFromDate = string.Empty;
		private string strToDate = string.Empty;
		private string strReason = string.Empty;
		private int intApprovedBy = 0;
		private string strApprovedDate = string.Empty;
		private double dbTotalDays = 0.0;
		private int intIsDeleted = 0;
		private int intCreatedBy = 0;
		private string strCreatedDate = string.Empty;
		private int intLastModifiedBy = 0;
		private string strLastModifiedDate = string.Empty;

		#endregion
		
		 #region ---Properties---
		public int LeaveApplylID
		{
			get { return intLeaveApplylID;}
			set { intLeaveApplylID = value;}
		}
		public int EmployeeMID
		{
			get { return intEmployeeMID;}
			set { intEmployeeMID = value;}
		}
		public string FromDate
		{
			get { return strFromDate;}
			set { strFromDate = value;}
		}
		public string ToDate
		{
			get { return strToDate;}
			set { strToDate = value;}
		}
		public string Reason
		{
			get { return strReason;}
			set { strReason = value;}
		}
		public int ApprovedBy
		{
			get { return intApprovedBy;}
			set { intApprovedBy = value;}
		}
		public string ApprovedDate
		{
			get { return strApprovedDate;}
			set { strApprovedDate = value;}
		}
		public double TotalDays
		{
			get { return dbTotalDays;}
			set { dbTotalDays = value;}
		}
		public int IsDeleted
		{
			get { return intIsDeleted;}
			set { intIsDeleted = value;}
		}
		public int CreatedBy
		{
			get { return intCreatedBy;}
			set { intCreatedBy = value;}
		}
		public string CreatedDate
		{
			get { return strCreatedDate;}
			set { strCreatedDate = value;}
		}
		public int LastModifiedBy
		{
			get { return intLastModifiedBy;}
			set { intLastModifiedBy = value;}
		}
		public string LastModifiedDate
		{
			get { return strLastModifiedDate;}
			set { strLastModifiedDate = value;}
		}

		#endregion
	}
}
