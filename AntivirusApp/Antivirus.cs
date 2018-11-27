using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntivirusApp
{
    public partial class Antivirus : Form
    {
        Timer t = new Timer();
        public Antivirus()
        {
            InitializeComponent();
        }
        private int cnt_virus = 0;

        private void btn_Folder_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            lbl_searching.Visible = false;
            folderBrowserDialog1.ShowDialog();
            lbl_cntViruses.Visible = false;
            lbl_FolderPath.Text = folderBrowserDialog1.SelectedPath;
            cnt_virus = 0;
            lbl_cntViruses.Text = string.Format("Total number of viruses:{0}", cnt_virus);
            progressBar1.Value = 0;
            listBox1.Items.Clear();

        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {            
            List<string> search = DirSearch(folderBrowserDialog1.SelectedPath);
            progressBar1.Value = 0;
            progressBar1.Maximum = search.Count;
            label1.Visible = false;
            lbl_searching.Visible = false;
            string message = "Virus not found!";
            foreach (string item in search)
            {
                progressBar1.Increment(1);
                try
                {
                    StreamReader stream = new StreamReader(item);
                    string read = stream.ReadToEnd();
                    string[] virus = new string[] { "trojan", "virus", "hacker" };
                    label1.Visible = true;
                    lbl_searching.Visible = true;
                    lbl_searching.Text = item;
                    Application.DoEvents();
                    foreach (string vrs in virus)
                    {
                        if (Regex.IsMatch(read,vrs))
                        {                            
                            cnt_virus += 1;
                            lbl_cntViruses.Visible = true;
                            lbl_cntViruses.Text = string.Format("Total number of viruses:{0}", cnt_virus);
                            listBox1.Items.Add(item);
                            message = string.Format("{0} Virus detected!", cnt_virus);

                        }                       
                        
                    }
                    

                }
                catch (Exception)
                {

                    string read = item;
                    string[] virusList = new string[] { "trojan", "virus", "hacker" };
                    label1.Visible = true;
                    lbl_searching.Visible = true;
                    lbl_searching.Text = item;
                    Application.DoEvents();
                    foreach (string s in virusList)
                    {
                        if (Regex.IsMatch(read,s))
                        {
                            
                            cnt_virus += 1;
                            lbl_cntViruses.Visible = true;
                            lbl_cntViruses.Text = string.Format("Total number of viruses:{0}", cnt_virus);
                            listBox1.Items.Add(item);
                            message = string.Format("{0} Virus detected!", cnt_virus);
                        }
                        
                    }
                    
                }
            }
            lbl_searching.Text = "Search completed!";
            MessageBox.Show(message);
        }

        private void Antivirus_Load(object sender, EventArgs e)
        {            
        }

        private List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir,"*.*"))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir, "*.*"))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {                
            }            

            return files;
        }        

    }
}
