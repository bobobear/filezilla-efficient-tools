using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Web.Security;

namespace filezilla_efficient_tools
{
    public partial class MainForm : Form
    {
        public static readonly string LINUX_MKDIR = "mkdir -p {0}/{1}\r";
        public static readonly string WINDOWS_MKDIR = "mkdir {0}\\{1}\r\n";
        public static readonly string USERS_DIR_SCRIPT;
        public static readonly string USERS_SCRIPT;

        static MainForm() 
        {
            USERS_DIR_SCRIPT = Path.Combine(Application.StartupPath, "users_dir.txt");
            USERS_SCRIPT = Path.Combine(Application.StartupPath, "users.txt");
        }

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void lnkMkdir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(USERS_DIR_SCRIPT);
        }

        private void linkAddUsers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(USERS_SCRIPT);
        }  

        private void btnXls_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Import Excel";
                ofd.ShowHelp = true;
                ofd.Filter = "Excel (*.xls)|*.xls";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = false;
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.lblImportPath.Text = ofd.FileName;
                    Import(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Import(string filePath)
        {
            String pathSpliter = this.radWin.Checked ? "\\" : "/";
            String commandTemplate = this.radWin.Checked ? WINDOWS_MKDIR : LINUX_MKDIR;

            try
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" 
                    + "Extended Properties=Excel 8.0;";
                OleDbConnection con = new OleDbConnection(strConn);
                con.Open();
                string sheet = "Sheet1";
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = string.Format(" select * from [{0}$]", sheet); //[sheetName$]
                OleDbDataReader odr = cmd.ExecuteReader();
                StringBuilder sbUses = new StringBuilder();
                StringBuilder sbUsersDir = new StringBuilder();
                while (odr.Read())
                {
                    if (odr[0].ToString() == "用户名")
                        continue;
                    string rootPath = txtRootPath.Text;
                    sbUses.Append(genUser(pathSpliter, rootPath, odr[0].ToString(), odr[1].ToString()));
                    sbUsersDir.Append(genMakeDirCmd(commandTemplate, rootPath, odr[0].ToString()));
                }
                odr.Close();

                writeToFile(USERS_DIR_SCRIPT, sbUsersDir.ToString());
                writeToFile(USERS_SCRIPT, sbUses.ToString());

                lnkMkdir.Visible = true;                
                linkAddUsers.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void writeToFile(string path, string content)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.Flush();
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
            m_streamWriter.Write(content);
            m_streamWriter.Close();
        }

        private string genMakeDirCmd(string commandTemplate, string rootPath, string user) {
            return String.Format(commandTemplate, rootPath, user);
        }

        private string genUser(string pathSpliter, string rootPath, string user, string pwd) {
            String template = "<User Name=\"{0}\">{4}"
                + " <Option Name=\"Pass\">{1}</Option>{4}"
                + " <Option Name=\"Group\"></Option>{4}"
                + " <Option Name=\"Bypass server userlimit\">0</Option>{4}"
                + " <Option Name=\"User Limit\">0</Option>{4}"
                + " <Option Name=\"IP Limit\">0</Option>{4}"
                + " <Option Name=\"Enabled\">1</Option>{4}"
                + " <Option Name=\"Comments\"></Option>{4}"
                + " <Option Name=\"ForceSsl\">0</Option>{4}"
                + " <IpFilter>{4}"
                + "    <Disallowed />{4}"
                + "    <Allowed />{4}"
                + " </IpFilter>{4}"
                + " <Permissions>{4}"
                + "    <Permission Dir=\"{2}{3}{0}\">{4}"
                + "        <Option Name=\"FileRead\">1</Option>{4}"
                + "        <Option Name=\"FileWrite\">0</Option>{4}"
                + "        <Option Name=\"FileDelete\">0</Option>{4}"
                + "        <Option Name=\"FileAppend\">0</Option>{4}"
                + "        <Option Name=\"DirCreate\">0</Option>{4}"
                + "        <Option Name=\"DirDelete\">0</Option>{4}"
                + "        <Option Name=\"DirList\">1</Option>{4}"
                + "        <Option Name=\"DirSubdirs\">1</Option>{4}"
                + "        <Option Name=\"IsHome\">1</Option>{4}"
                + "        <Option Name=\"AutoCreate\">0</Option>{4}"
                + "    </Permission>{4}"
                + " </Permissions>{4}"
                + " <SpeedLimits DlType=\"0\" DlLimit=\"10\" ServerDlLimitBypass=\"0\" UlType=\"0\" UlLimit=\"10\" ServerUlLimitBypass=\"0\">{4}"
                + "    <Download />{4}"
                + "    <Upload />{4}"
                + " </SpeedLimits>{4}"
                + "</User>{4}";

            return String.Format(template, user,
                FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5").ToLower(),
                rootPath, pathSpliter, "/" == pathSpliter ? "\n" : "\r\n");
        }      
    }
}
