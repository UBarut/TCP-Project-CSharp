using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace CepteSef
{
    public partial class FoodPanel : Form
    {
        public static FoodPanel foodPanel;
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        Colors color = new Colors();

        //int foodID;
        public string foodNamee;
        PrivateFontCollection pfc;

        public FoodPanel()
        {
            InitializeComponent();
            foodPanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            fontChange();
            pbFood.BackgroundImageLayout = ImageLayout.Stretch;
            sqlCommandProcess.Proc("AddViews", AddView);
            //TransferFoodInfo();
            BackColor = color.light;
            btnClickAddToCart.ForeColor = color.red;
            btnClickAddToFavorite.ForeColor = color.red;
            btnClickAnotherRecipes.ForeColor = color.red;
            lblIngredientsTitle.ForeColor = color.red;
            lblIngredientsTitle.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lblFoodName.ForeColor = color.red;
            lblFoodName.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            lblHowDo.ForeColor = color.red;
            lblHowDo.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lblFoodExplanation.Font = new Font(pfc.Families[0], 9, FontStyle.Regular);
            btnClickAddToFavorite.Font = new Font(pfc.Families[1], 12, FontStyle.Regular);
            btnClickAnotherRecipes.Font = new Font(pfc.Families[1], 12, FontStyle.Regular);
            btnClickAddToCart.Font = new Font(pfc.Families[1], 12, FontStyle.Regular);

        }

        private void btnClickAddToCart_Click(object sender, EventArgs e)
        {
            if (UserLoginPanel.userLoginPanel.userID > 0)
            {
                bool none = true;
                foreach (string name in UserCart.userCart.lbCartList.Items)
                {
                    if (name == lblFoodName.Text)
                    {
                        MessageBox.Show("Bu yemek Sepetinizde bulunmaktadır.");
                        none = false;
                    }
                }
                if (none)
                {
                    UserCart.userCart.lbCartList.Items.Add(lblFoodName.Text);
                    MessageBox.Show("Yemek Sepetinize Eklendi.");
                }
            }
            else
            {
                MessageBox.Show("Giriş Yapınız.");
            }
        }
        private void btnClickAddToFavorite_Click(object sender, EventArgs e)
        {
            if (UserLoginPanel.userLoginPanel.userID > 0)
            {
                SqlDataReader food = adapter.SqlOperations(sqlCommandProcess.Select("Foods"));
                while (food.Read())
                {
                    if (food["Food"].ToString() == lblFoodName.Text)
                    {
                        UC_FoodCardPanel.foodCardPanel.foodID = Convert.ToInt32(food["ID"].ToString());
                        break;
                    }
                }
                Form1.form1.connection.Close();
                UC_FoodCardPanel.foodCardPanel.CheckFavorite(lblFoodName.Text);
                UC_FoodCardPanel.foodCardPanel.AddRemoveFav();
            }
            else
            {
                MessageBox.Show("Giriş Yapınız.");
            }
        }
        public void TransferFoodInfo()
        {
            SqlDataReader food = adapter.SqlOperations(sqlCommandProcess.Select("Foods"));
            while (food.Read())
            {
                if (foodNamee == food["Food"].ToString())
                {
                    lblFoodName.Text = food["Food"].ToString();
                    lblFoodExplanation.Text = food["FoodExplanation"].ToString();
                    rtbIngredients.Text = food["IngredientsText"].ToString();
                    rtbSteps.Text = food["Steps"].ToString();
                    pbFood.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\{food["Food_Picture"]}");
                    pbFood.BackgroundImageLayout = ImageLayout.Stretch;
                    Form1.form1.location = food["Category"].ToString();
                    UC_FoodCardPanel.foodCardPanel.foodID = Convert.ToInt32(food["ID"].ToString());
                    break;
                }
            }
            Form1.form1.connection.Close();
        }

        public void AddView()
        {
            sqlCommandProcess.ProcAdd("id", SqlDbType.Int, UC_FoodCardPanel.foodCardPanel.foodID);
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
