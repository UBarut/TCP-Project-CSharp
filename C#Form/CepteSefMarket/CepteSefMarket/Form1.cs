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
using System.Drawing.Text;

namespace CepteSefMarket
{
    public partial class Form1 : Form
    {
        public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O4DQSUN;Initial Catalog=CepteSefdb;Integrated Security=True");
        //public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D7I6MTC;Initial Catalog=CepteSefdb;Integrated Security=True");

        public static Form1 form1;
        Colors color = new Colors();
        public UserCart userCart = new UserCart();
        public ProductsPanel productsPanel = new ProductsPanel();
        public UserLoginPanel userLoginPanel = new UserLoginPanel();
        public SearchPanel searchPanel = new SearchPanel();
        Navbar navbar = new Navbar();
        PrivateFontCollection pfc;

        public Form1()
        {
            InitializeComponent();
            form1 = this;
            pnlScreen.Controls.Add(userCart);
            pnlScreen.Controls.Add(productsPanel);
            pnlScreen.Controls.Add(userLoginPanel);
            pnlScreen.Controls.Add(searchPanel);
            productsPanel.Show();
            navbar.NavbarControl();
            HiddenNavbar();
            fontChange();

            lblLogo.ForeColor = color.blue;
            lblLogo.Font = new Font(pfc.Families[2], 20, FontStyle.Regular);
            tableLayoutPanel5.BackColor = color.main;
            lblUserName.ForeColor = color.pink;
            lblUserName.Font = new Font(pfc.Families[2], 14, FontStyle.Regular);
            pnlScreen.BackColor = color.light;

            foreach (Button btn in pnlNavbar.Controls.OfType<Button>())
            {
                btn.ForeColor = color.yellow;
                btn.Font = new Font(pfc.Families[1], 20, FontStyle.Regular);
                btn.MouseHover += Btn_MouseHover;
                btn.MouseLeave += Btn_MouseLeave;
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = color.yellow;
            (sender as Button).Font = new Font(pfc.Families[1], 20, FontStyle.Regular);
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = color.pink;
            (sender as Button).Font = new Font(pfc.Families[1], 20, FontStyle.Underline);
        }

        public void HiddenScreens()
        {
            productsPanel.Hide();
            userCart.Hide();
            userLoginPanel.Hide();
            searchPanel.Hide();
            searchPanel.pnlScreen.Controls.Clear();
            searchPanel.tbSearchBar.Controls.Clear();
        }
        public void HiddenNavbar()
        {
            btnCart.Hide();
            btnProfil.Hide();
            btnExit.Hide();
            btnLogin.Show();
        }
        public void fontChange()
        {
            pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\VintageParty-FreeVersion.ttf");
            pfc.AddFontFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\coolvetica condensed rg.otf");
            pfc.AddFontFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\CaviarDreams_Italic.ttf");
        }
    }
}
