using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;

namespace DEMOQLNH
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public static string ID_USER = "";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ID_USER = Class.Functions.getID(txtUser.Text, txtPass.Text);
            if (ID_USER != "")
            {
                this.Hide();
                frmMain f = new frmMain();
                f.Show();
                txtUser.Text = "";
                txtPass.Text = "";
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    //DataTable dtServers = SmoApplication.EnumAvailableSqlServers(true);
            //    //if (dtServers.Rows.Count > 0)
            //    //{
            //    //    foreach (DataRow drserver in dtServers.Rows)
            //    //    {
            //    //        cmbServer.Items.Add(drserver["Name"]);//combobox lưu server
            //    //    }
            //    //}

            //    //DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            //    //foreach (DataRow dr in dt.Rows)
            //    //{
            //    //    cmbServer.Items.Add(string.Concat(dr["ServerName"], "\\", dr["InstanceName"]));
            //    //}

            //    //string myServer = Environment.MachineName;
            //    //MessageBox.Show(myServer);
            //    //DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            //    ////MessageBox.Show(servers.Rows[0]["ServerName"].ToString());
            //    //for (int i = 0; i < servers.Rows.Count; i++)
            //    //{
            //    //    MessageBox.Show("Có Sever");
            //    //    if (myServer == servers.Rows[i]["ServerName"].ToString())
            //    //    {
            //    //        cmbServer.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);

            //    //    }
            //    //    else
            //    //    {
            //    //        cmbServer.Items.Add(servers.Rows[i]["ServerName"]);
            //    //    }
            //    //}

            //    //RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
            //    //String[] instances = (String[])rk.GetValue("InstalledInstances");
            //    //if (instances.Length > 0)
            //    //{
            //    //    foreach (String element in instances)
            //    //    {
            //    //        if (element == "MSSQLSERVER")
            //    //            cmbServer.Items.Add(System.Environment.MachineName);
            //    //        else
            //    //            cmbServer.Items.Add(System.Environment.MachineName + @"\" + element);
            //    //    }
            //    //}
            //    //cmbServer.SelectedIndex = 0; //LẤY TÊN SERVER ĐẦU TIÊN
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Không thể kết nối Server!\n" + ex.Message);
            //}
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain f = new frmMain();
            f.Show();
        }
    }
}
