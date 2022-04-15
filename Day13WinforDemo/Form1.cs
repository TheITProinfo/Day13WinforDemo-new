using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Day13WinforDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Register success!!");

            //String connStr = "server=192.168.70.105;uid=sa;pwd=Cst001.com;database=Market";

            //string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

            if (!checkFrmTxt())

            {
                return;
            }


            #region //using open data base
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    string strSql = string.Format(@"insert into userinfo(  UserName, UserPassword,CreateDate)values ('{0}', '{1}','{2}')", txtUsername.Text, txtPassword.Text, DateTime.Now.ToString());
                    cmd.CommandText = strSql;
                    int num = cmd.ExecuteNonQuery();

                    if (num != 0)
                    {
                        MessageBox.Show("Register Successfully!");
                    }




                }

            } 
            #endregion



            
            }
        #region checkFrmTxt method
        private bool checkFrmTxt()
        {
            if (string.IsNullOrEmpty(this.txtUsername.Text.Trim()) || string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {

                MessageBox.Show("please enter user name or password!");
                return false;
            }

            return true;
        } 
        #endregion
    }
}
