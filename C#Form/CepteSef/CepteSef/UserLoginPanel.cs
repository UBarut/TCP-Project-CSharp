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
using System.Drawing.Text;

namespace CepteSef
{
    public partial class UserLoginPanel : Form
    {
        public static UserLoginPanel userLoginPanel;
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        Colors color = new Colors();

        public int userID = -1;
        bool check = true;
        PrivateFontCollection pfc;

        public UserLoginPanel()
        {
            InitializeComponent();
            userLoginPanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            fontChange();

            BackColor = color.light;
            pnlLogo.BackColor = color.orange;
            lblLogo.Font = new Font(pfc.Families[2], 72, FontStyle.Regular);
            lblLogo.ForeColor = color.red;
            foreach (Label lbl in tableLayoutPanel2.Controls.OfType<Label>())
            {
                lbl.ForeColor = color.red;
                lbl.Font = new Font(pfc.Families[0], 10, FontStyle.Bold);
            }
            foreach (Button btn in tableLayoutPanel2.Controls.OfType<Button>())
            {
                btn.ForeColor = color.red;
                btn.Font = new Font(pfc.Families[1], 13, FontStyle.Regular);
            }
            lblLogin.ForeColor = color.red;
            foreach (Label lbl in tableLayoutPanel4.Controls.OfType<Label>())
            {
                lbl.ForeColor = color.red;
                lbl.Font = new Font(pfc.Families[0], 10, FontStyle.Bold);
            }
            foreach (Button btn in tableLayoutPanel4.Controls.OfType<Button>())
            {
                btn.ForeColor = color.red;
                btn.Font = new Font(pfc.Families[1], 14, FontStyle.Regular);
            }
        }

        private void btnSıgnIn_Click(object sender, EventArgs e)
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
            sqlCommandProcess.Proc("UserAdd", AddProc);
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
            sqlCommandProcess.ProcAdd("port", SqlDbType.Int, Convert.ToInt32(tbBankID.Text));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlDataReader user = adapter.SqlOperations(sqlCommandProcess.Select("Users"));
            while (user.Read())
            {
                if (tbLoginPassword.Text == user["Password"].ToString() && tbLoginUserName.Text == user["UserName"].ToString())
                {
                    Form1.form1.btnFavorite.Show();
                    Form1.form1.btnProfil.Show();
                    Form1.form1.btnExit.Show();
                    Form1.form1.btnCart.Show();
                    Form1.form1.btnSharing.Show();
                    Form1.form1.btnMenus.Show();
                    Form1.form1.btnLogin.Hide();

                    //MainPanel mainPanel = new MainPanel();
                    Form1.form1.HiddenScreens();
                    Form1.form1.mainPanel.Show();
                    pnlLogo.Show();

                    userID= Convert.ToInt32(user["ID"].ToString());
                }
            }
            Form1.form1.connection.Close();
        }
        public void changeFavorites()
        {
            SqlDataReader favorite = adapter.SqlOperations("select * from Favorites as fav right join Foods as f on(fav.Favorite_FoodID=f.ID) left join User_Information as u on(fav.UserID=u.ID)  where UserID='" + UserLoginPanel.userLoginPanel.userID.ToString() + "'");
            while (favorite.Read())
            {
                if (UC_FoodCardPanel.foodCardPanel.Name.ToString() == favorite["Food"].ToString() /*&& FoodPanel.foodPanel.lblFoodName.Text == favorite["Food"].ToString()*/)
                {
                    UC_FoodCardPanel.foodCardPanel.btnFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favoriteFill.png");
                    //FoodPanel.foodPanel.btnClickAddToFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favoriteFill.png");
                    Form1.form1.favoriteIcon = "favoriteFill";
                }
            }
            Form1.form1.connection.Close();
        }
        public void fontChange()
        {
            pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\VintageParty-FreeVersion.ttf");
            pfc.AddFontFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\coolvetica condensed rg.otf");
            pfc.AddFontFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\CaviarDreams_Italic.ttf");
        }
    }
}
