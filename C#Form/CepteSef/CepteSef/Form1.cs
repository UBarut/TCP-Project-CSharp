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

namespace CepteSef
{
    public partial class Form1 : Form
    {
        public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O4DQSUN;Initial Catalog=CepteSefdb;Integrated Security=True");
        //public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D7I6MTC;Initial Catalog=CepteSefdb;Integrated Security=True");

        public static Form1 form1;
        public UserLoginPanel userLoginPanel;
        public MainPanel mainPanel;
        public CategoryPanel categoryPanel;
        public RecipePanel recipePanel;
        public UserCart userCart;
        public FoodPanel foodPanel;
        public SearchPanel searchPanel;
        Toolbar toolbar = new Toolbar();
        Colors color = new Colors();
        Client client = new Client();

        //Values
        public string location = "mainMenu";
        public int categoryID;
        public string favoriteIcon = "favorite";
        PrivateFontCollection pfc;

        public Form1()
        {
            form1 = this;
            recipePanel = new RecipePanel();
            userLoginPanel = new UserLoginPanel();
            mainPanel = new MainPanel();
            categoryPanel = new CategoryPanel();
            userCart = new UserCart();
            foodPanel = new FoodPanel();
            searchPanel = new SearchPanel();
            InitializeComponent();
            toolbar.AccessForm1(this);
            client.StartServer();
            gradientPanel1.BackColor = color.main;
            lblLogo.ForeColor = color.red;
            HiddenSliders(); 
            btnBack.Hide();
            fontChange();
            foreach  (Button button in pnlMenus.Controls.OfType<Button>())
            {
                button.ForeColor = color.red;
                button.Font = new Font(pfc.Families[1], 16, FontStyle.Bold);
                button.MouseHover += Button_MouseHover;
                button.MouseLeave += Button_MouseLeave;
            }
            lblLogo.Font = new Font(pfc.Families[2], 18, FontStyle.Regular);
            foreach(Button button in pnlSliderMenu.Controls.OfType<Button>())
            {
                button.Font = new Font(pfc.Families[1], 14, FontStyle.Regular);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = color.red;
            (sender as Button).Font = new Font(pfc.Families[1], 16, FontStyle.Bold);
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = color.light;
            (sender as Button).Font = new Font(pfc.Families[1], 16, FontStyle.Underline);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlScreen.Controls.Add(categoryPanel);
            pnlScreen.Controls.Add(recipePanel);
            pnlScreen.Controls.Add(userLoginPanel);
            pnlScreen.Controls.Add(userCart);
            pnlScreen.Controls.Add(mainPanel);
            pnlScreen.Controls.Add(foodPanel);
            pnlScreen.Controls.Add(searchPanel);
        }

        public void HiddenScreens()
        {
            mainPanel.Hide();
            recipePanel.Hide();
            uC_MakeMenuPanel1.Hide();
            uC_ShareRecipePanel1.Hide();
            categoryPanel.Hide();
            userLoginPanel.Hide();
            userCart.Hide();
            foodPanel.Hide();
            searchPanel.Hide();
        }
        public void HiddenSliders()
        {
            btnFavorite.Hide();
            btnProfil.Hide();
            btnExit.Hide();
            btnCart.Hide();
            btnSharing.Hide();
            btnMenus.Hide();
            btnLogin.Show();
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
