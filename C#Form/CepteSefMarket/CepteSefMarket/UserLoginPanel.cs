using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CepteSefMarket
{
    public partial class UserLoginPanel : Form
    {
        public static UserLoginPanel userLoginPanel;
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O4DQSUN;Initial Catalog=CepteSefdb;Integrated Security=True");
        //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D7I6MTC;Initial Catalog=CepteSefdb;Integrated Security=True");
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        Colors color = new Colors();

        public int userID = -1;
        bool check=true;
        public UserLoginPanel()
        {
            InitializeComponent();
            userLoginPanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;


            BackColor = color.light;
            pnlLogo.BackColor = color.main;
            lblLogo.ForeColor = color.blue;
            foreach (Label lbl in tableLayoutPanel2.Controls.OfType<Label>())
            {
                lbl.ForeColor = color.main;
            }
            foreach (Button btn in tableLayoutPanel2.Controls.OfType<Button>())
            {
                btn.ForeColor = color.main;
            }
            lblLogin.ForeColor = color.main;
            foreach (Label lbl in tableLayoutPanel4.Controls.OfType<Label>())
            {
                lbl.ForeColor = color.main;
            }
            foreach (Button btn in tableLayoutPanel4.Controls.OfType<Button>())
            {
                btn.ForeColor = color.main;
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (check)
            {
                pnlLogo.Hide();
                check = false;
            }
            else
            {
                pnlLogo.Show();
                check = true;
            }     
        }
        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            sqlCommandProcess.Proc("UserAdd", AddProc, connection);
            MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
            pnlLogo.Show();
            check = true;
        }
        void AddProc()
        {
            sqlCommandProcess.ProcAdd("name", SqlDbType.NVarChar, tbName.Text);
            sqlCommandProcess.ProcAdd("surname", SqlDbType.NVarChar, tbSurname.Text);
            sqlCommandProcess.ProcAdd("password", SqlDbType.NVarChar, tbLoginPassword.Text);
            sqlCommandProcess.ProcAdd("mail", SqlDbType.NVarChar, tnMail.Text);
            sqlCommandProcess.ProcAdd("username", SqlDbType.NVarChar, tbUserName.Text);
            sqlCommandProcess.ProcAdd("age", SqlDbType.Int, Convert.ToInt32(tbAge.Text));
            sqlCommandProcess.ProcAdd("cardID", SqlDbType.Int, Convert.ToInt32(tbBankID.Text));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlDataReader user = adapter.SqlOperations(sqlCommandProcess.Select("Users"), connection);
            while (user.Read())
            {
                if (tbLoginPassword.Text == user["Password"].ToString() && tbLoginUserName.Text == user["UserName"].ToString())
                {
                    Form1.form1.btnProfil.Show();
                    Form1.form1.btnExit.Show();
                    Form1.form1.btnCart.Show();
                    Form1.form1.btnLogin.Hide();

                    //MainPanel mainPanel = new MainPanel();
                    Form1.form1.HiddenScreens();
                    Form1.form1.productsPanel.Show();

                    userID = Convert.ToInt32(user["ID"].ToString());
                    Form1.form1.lblUserName.Text = user["UserName"].ToString();
                }
            }
            connection.Close();
        }
    }
}
