using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEB_School.BO
{
    public class FeesGroupBo
    {
        #region FeesGroup Class Properties

        public const string FEESGROUP_TABLE = "tbl_FeesGroup_M";
        public const string FEESGROUP_FEESGROUPID = "FeesGroupID";
        public const string FEESGROUP_FEEGROUPNAME = "FeeGroupName";
        public const string FEESGROUP_TRUSTMID = "TrustMID";
        public const string FEESGROUP_SCHOOLMID = "SchoolMID";
        public const string FEESGROUP_ISDELETED = "IsDeleted";
        public const string FEESGROUP_CREATEDUSERID = "CreatedUserID";
        public const string FEESGROUP_LASTMODIFIEDUSERID = "LastModifiedUserID";
        public const string FEESGROUP_CREATEDDATE = "CreatedDate";
        public const string FEESGROUP_LASTMODIFIEDDATE = "LastModifiedDate";
        public const string FEESGROUP_DESCRIPTION = "Description";



        private int intFeesGroupID = 0;
        private string strFeeGroupName = string.Empty;
        private int intTrustMID = 0;
        private int intSchoolMID = 0;
        private int intIsDeleted = 0;
        private int intCreatedUserID = 0;
        private int intLastModifiedUserID = 0;
        private string strCreatedDate = string.Empty;
        private string strLastModifiedDate = string.Empty;
        private string strDescription = string.Empty;

        #endregion

        #region ---Properties---
        public int FeesGroupID
        {
            get { return intFeesGroupID; }
            set { intFeesGroupID = value; }
        }
        public string FeeGroupName
        {
            get { return strFeeGroupName; }
            set { strFeeGroupName = value; }
        }
        public int TrustMID
        {
            get { return intTrustMID; }
            set { intTrustMID = value; }
        }
        public int SchoolMID
        {
            get { return intSchoolMID; }
            set { intSchoolMID = value; }
        }
        public int IsDeleted
        {
            get { return intIsDeleted; }
            set { intIsDeleted = value; }
        }
        public int CreatedUserID
        {
            get { return intCreatedUserID; }
            set { intCreatedUserID = value; }
        }
        public int LastModifiedUserID
        {
            get { return intLastModifiedUserID; }
            set { intLastModifiedUserID = value; }
        }
        public string CreatedDate
        {
            get { return strCreatedDate; }
            set { strCreatedDate = value; }
        }
        public string LastModifiedDate
        {
            get { return strLastModifiedDate; }
            set { strLastModifiedDate = value; }
        }
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        #endregion
    }
}


