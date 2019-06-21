using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace GEB_School.Bo
{
	public class LeaveApprovalBo
	{
		#region LeaveApproval Class Properties
		
		public const string LEAVEAPPROVAL_TABLE = "tbl_LeaveApproval";
		public const string LEAVEAPPROVAL_LEAVEAPPROVALID = "LeaveApprovalID";
public const string LEAVEAPPROVAL_LEAVEAPPLYID = "LeaveApplyID";
public const string LEAVEAPPROVAL_ISAPPROVED = "IsApproved";
public const string LEAVEAPPROVAL_APPLYDATE = "ApplyDate";
public const string LEAVEAPPROVAL_LEAVEID = "LeaveID";
public const string LEAVEAPPROVAL_ISHALFDAY = "IsHalfDay";
public const string LEAVEAPPROVAL_NAREASON = "NAReason";
public const string LEAVEAPPROVAL_ISDELETED = "IsDeleted";
public const string LEAVEAPPROVAL_CREATEDBY = "CreatedBy";
public const string LEAVEAPPROVAL_CREATEDDATE = "CreatedDate";
public const string LEAVEAPPROVAL_LASTMODIFIEDBY = "LastModifiedBy";
public const string LEAVEAPPROVAL_LASTMODIFIEDDATE = "LastModifiedDate";

			
		
		private int intLeaveApprovalID = 0;
		private int intLeaveApplyID = 0;
		private int intIsApproved = 0;
		private string strApplyDate = string.Empty;
		private int intLeaveID = 0;
		private int intIsHalfDay = 0;
		private string strNAReason = string.Empty;
		private int intIsDeleted = 0;
		private int intCreatedBy = 0;
		private string strCreatedDate = string.Empty;
		private int intLastModifiedBy = 0;
		private string strLastModifiedDate = string.Empty;

		#endregion
		
		 #region ---Properties---
		public int LeaveApprovalID
		{
			get { return intLeaveApprovalID;}
			set { intLeaveApprovalID = value;}
		}
		public int LeaveApplyID
		{
			get { return intLeaveApplyID;}
			set { intLeaveApplyID = value;}
		}
		public int IsApproved
		{
			get { return intIsApproved;}
			set { intIsApproved = value;}
		}
		public string ApplyDate
		{
			get { return strApplyDate;}
			set { strApplyDate = value;}
		}
		public int LeaveID
		{
			get { return intLeaveID;}
			set { intLeaveID = value;}
		}
		public int IsHalfDay
		{
			get { return intIsHalfDay;}
			set { intIsHalfDay = value;}
		}
		public string NAReason
		{
			get { return strNAReason;}
			set { strNAReason = value;}
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
