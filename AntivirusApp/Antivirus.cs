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
        public Antivirus()
        {
            InitializeComponent();
        }
        private int cnt_virus = 0;
        private void btn_Folder_Click(object sender, EventArgs e)
        {
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
            string[] search = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.*");
            progressBar1.Maximum = search.Length;
            foreach (string item in search)
            {
                try
                {
                    StreamReader stream = new StreamReader(item);
                    string read = stream.ReadToEnd();
                    string[] virus = new string[] { "trojan", "virus", "hacker" };
                    foreach (string vrs in virus)
                    {
                        if (Regex.IsMatch(read,vrs))
                        {
                            MessageBox.Show("Virus Detected");
                            cnt_virus += 1;
                            lbl_cntViruses.Visible = true;
                            lbl_cntViruses.Text = string.Format("Total number of viruses:{0}", cnt_virus);
                            listBox1.Items.Add(item);


                        }
                        progressBar1.Increment(1);
                    }
                }
                catch (Exception)
                {

                    string read = item;
                    string[] virusList = new string[] { "trojan", "virus", "hacker" };
                    foreach (string s in virusList)
                    {
                        if (Regex.IsMatch(read,s))
                        {
                            MessageBox.Show("Virus Detected");
                            cnt_virus += 1;
                            lbl_cntViruses.Visible = true;
                            lbl_cntViruses.Text = string.Format("Total number of viruses:{0}", cnt_virus);
                            listBox1.Items.Add(item);
                        }
                        progressBar1.Increment(1);
                    }
                }
            }
        }
    }
}
