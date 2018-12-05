using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AntivirusWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            lbl_Error.Visible = false;
            StatusLabel.Text = "";

        }

        protected void btnScan_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            if (FileUpload1.HasFile)
            {
                try
                {
                    StatusLabel.Text = "";
                    int cnt_virus = 0;
                    string message = "Virus not found!";
                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                        string filename = Path.GetFileName(uploadedFile.FileName);
                        string path = Server.MapPath("~/" + uploadedFile.FileName);
                        string saveaspath = System.IO.Path.Combine(Server.MapPath("~/"), uploadedFile.FileName);
                        uploadedFile.SaveAs(saveaspath);
                        StreamReader stream = new StreamReader(path);
                        string read = stream.ReadToEnd();
                        List<string> virus = new List<string>();
                        virus = getData();
                        
                        foreach (string vrs in virus)
                        {
                            
                            if (Regex.IsMatch(read, vrs))
                            {
                                cnt_virus += 1;
                                listBox1.Items.Add(filename + " (" + vrs + ")");
                                message = string.Format("{0} Virus detected!", cnt_virus);

                            }

                        }
                        stream.DiscardBufferedData();
                        stream.Dispose();
                        if (File.Exists(path)) { System.IO.File.Delete(path); }
                        
                    }
                    StatusLabel.Text = message;



                }
                catch (Exception ex)
                {
                    lbl_Error.Visible = true;
                    lbl_Error.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
                finally
                {
                    FileUpload1.Dispose();
                }
            }
            else
            {
                lbl_Error.Visible = true;
                lbl_Error.Text = "Please upload the file!";
            }
        }
        public List<string> getData()
        {
            List<string> data = new List<string>();
            string conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            //The query to use
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string oString = "Select * from Antivirus";
            SqlCommand oCmd = new SqlCommand(oString, connection);            
            
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    data.Add(oReader["Name"].ToString());                    
                }                
            }
            connection.Close();

            return data;
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string filename = "AntivirusApp.zip";
            if (filename != "")
            {
                string path = Server.MapPath("~/" + filename);
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Response.Clear();
                    //Content-Disposition will tell the browser how to treat the file.(e.g. in case of jpg file, Either to display the file in browser or download it)
                    //Here the attachement is important. which is telling the browser to output as an attachment and the name that is to be displayed on the download dialog
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    //Telling length of the content..
                    Response.AddHeader("Content-Length", file.Length.ToString());

                    //Type of the file, whether it is exe, pdf, jpeg etc etc
                    Response.ContentType = "application/octet-stream";

                    //Writing the content of the file in response to send back to client..
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
                else
                {
                    Response.Write("This file does not exist.");
                }
            }
        }
    }
}