using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using GEB_School.BL;
using GEB_School.BO;
using GEB_School.Common;

namespace GEB_School.Client.UI
{
    public partial class BackUp : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }

        public void bindGrid()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/DBBackups/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                FileInfo fn = new FileInfo(filePath);
                long size = fn.Length / 1024;
                files.Add(new ListItem(Path.GetFileName(filePath) + "-" + size, filePath));
            }
            gvbackup.DataSource = files;
            gvbackup.DataBind();
        }

        #region Backup Button
        protected void btnbackup_Click(object sender, EventArgs e)
        {
            try
            {
                TrustBL objTrustBL = new TrustBL();
                ApplicationResult objResultBackup = new ApplicationResult();

                objResultBackup = objTrustBL.Download_DatabaseBackup();
                if (objResultBackup.status == ApplicationResult.CommonStatusType.SUCCESS)
                {
                    bindGrid();
                   // Response.Redirect(Request.Url.AbsoluteUri);
                    //String FileName = "Navchetan"+DateTime.Now.ToString("yyyy-MM-dd")+".bak";
                    //String FilePath = Server.MapPath("~/DBBackups/") + FileName; //Replace this
                    //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    //response.ClearContent();
                    //response.Clear();
                    //response.ContentType = "application/octet-stream";
                    ////response.ContentType = "text/plain";
                    //response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
                    //response.TransmitFile(FilePath);
                    //response.Flush();
                    //response.End();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Error, Please Try Again..!!";
                }

            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "" + ex.Message.ToString();
            }
        }
        #endregion

        protected void DownloadFile(object sender, EventArgs e)
        {
            String FilePath = (sender as LinkButton).CommandArgument; //Replace this
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "application/octet-stream";
            //response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(FilePath) + ";");
            response.TransmitFile(FilePath);
            response.Flush();
            response.End();
        }

        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}