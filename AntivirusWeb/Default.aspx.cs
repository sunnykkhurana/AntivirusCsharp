﻿using System;
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
            StatusLabel.Text = "Upload status: File uploaded!";
            if (FileUpload1.HasFile)
            {
                try
                {
                    int cnt_virus = 0;
                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                        string filename = Path.GetFileName(uploadedFile.FileName);
                        string path = Server.MapPath("~/" + uploadedFile.FileName);
                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/"), uploadedFile.FileName));
                        StreamReader stream = new StreamReader(path);
                        string read = stream.ReadToEnd();
                        List<string> virus = new List<string>();
                        virus = getData();
                        foreach (string vrs in virus)
                        {
                            if (Regex.IsMatch(read, vrs))
                            {
                                cnt_virus += 1;
                                listBox1.Items.Add(filename + " (" + vrs + ")" );
                                StatusLabel.Text = string.Format("{0} Virus detected!", cnt_virus);

                            }
                            else
                            {
                                StatusLabel.Text = "Virus not found";
                            }

                        }                        
                    }
                    FileUpload1.Dispose();
                                        
                                        
                }
                catch (Exception ex)
                {
                    lbl_Error.Visible = true;
                    lbl_Error.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
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
    }
}