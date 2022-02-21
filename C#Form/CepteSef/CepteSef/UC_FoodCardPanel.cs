using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Drawing.Text;

namespace CepteSef
{
    public partial class UC_FoodCardPanel : UserControl
    {
        Colors color = new Colors();
        public static UC_FoodCardPanel foodCardPanel;
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();

        public int foodID;
        public string foodName = "";
        private int userID;
        bool check = true;
        PrivateFontCollection pfc;

        public UC_FoodCardPanel()
        {
            InitializeComponent();
            Design();
            Buttons();
            foodCardPanel = this;
            fontChange();
            lblFoodTitle.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lblFoodComment.Font = new Font(pfc.Families[0], 9, FontStyle.Bold);
        }
        private void Design()
        {
            lblFoodComment.ForeColor = Color.White;
            lblFoodTitle.ForeColor = color.orange;
            tableLayoutPanel2.BackColor = color.main;
        }
        private void Buttons()
        {
            foreach (Control button in pnlButtons.Controls.OfType<Button>())
            {
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name.ToString() == "btnFood")
            {
                Form1.form1.HiddenScreens();
                //FoodPanel foodPanel = new FoodPanel();
                //foodName = lblFoodTitle.Text;
                Form1.form1.foodPanel.Show();
                Form1.form1.btnBack.Show();
                TransferFoodInfo();
                TransferFavorite();
                sqlCommandProcess.Proc("AddViews", AddView);
            }
            else if ((sender as Button).Name.ToString() == "btnAddToCart")
            {
                if (UserLoginPanel.userLoginPanel.userID != -1)
                {
                    bool none = true;
                    foreach (string name in UserCart.userCart.lbCartList.Items)
                    {
                        if (name == lblFoodTitle.Text)
                        {
                            MessageBox.Show("Bu yemek Sepetinizde bulunmaktadır.");
                            none = false;
                        }
                    }
                    if (none)
                    {
                        UserCart.userCart.lbCartList.Items.Add(lblFoodTitle.Text);
                        MessageBox.Show("Yemek Sepetinize Eklendi.");
                    }
                }
                else
                {
                    MessageBox.Show("Giriş Yapınız.");
                }
                
            }
            else if ((sender as Button).Name.ToString() == "btnFavorite")
            {
                if (UserLoginPanel.userLoginPanel.userID != -1)
                {
                    SqlDataReader food = adapter.SqlOperations(sqlCommandProcess.Select("Foods"));
                    while (food.Read())
                    {
                        if (food["Food"].ToString() == lblFoodTitle.Text)
                        {
                            foodID = Convert.ToInt32(food["ID"].ToString());
                            break;
                        }
                    }
                    Form1.form1.connection.Close();
                    CheckFavorite(lblFoodTitle.Text);
                    AddRemoveFav();
                }
                else
                {
                    MessageBox.Show("Giriş Yapınız.");
                }
            }
        }
        public void TransferFoodInfo()
        {
            SqlDataReader food = adapter.SqlOperations(sqlCommandProcess.Select("Foods"));
            while (food.Read())
            {
                if (lblFoodTitle.Text == food["Food"].ToString())
                {
                    FoodPanel.foodPanel.lblFoodName.Text = food["Food"].ToString();
                    FoodPanel.foodPanel.lblFoodExplanation.Text = food["FoodExplanation"].ToString();
                    FoodPanel.foodPanel.rtbIngredients.Text = food["IngredientsText"].ToString();
                    FoodPanel.foodPanel.rtbSteps.Text = food["Steps"].ToString();
                    FoodPanel.foodPanel.pbFood.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\{food["Food_Picture"]}");
                    FoodPanel.foodPanel.pbFood.BackgroundImageLayout = ImageLayout.Stretch;
                    if (Form1.form1.location == "mainMenu")
                    {
                        break;
                    }
                    else if (Form1.form1.location != "search")
                    {
                        Form1.form1.location = food["Category"].ToString();
                    }
                    foodID = Convert.ToInt32(food["ID"].ToString());
                    break;
                }
            }
            Form1.form1.connection.Close();
        }
        public void AddView()
        {
            sqlCommandProcess.ProcAdd("id", SqlDbType.Int, foodID);
        }

        public void CheckFavorite(string name)
        {
            SqlDataReader favorite = adapter.SqlOperations("select * from Favorites as fav right join Foods as f on(fav.Favorite_FoodID=f.ID) left join User_Information as u on(fav.UserID=u.ID)  where UserID='" + UserLoginPanel.userLoginPanel.userID.ToString() + "'");
            while (favorite.Read())
            {
                if (/*this.Name.ToString()*/name == favorite["Food"].ToString())
                {
                    btnFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favorite.png");
                    FoodPanel.foodPanel.btnClickAddToFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favorite.png");
                    userID =Convert.ToInt32(favorite["UserID"].ToString());
                    check = false;
                    break;
                }
                else
                {
                    btnFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favoriteFill.png");
                    FoodPanel.foodPanel.btnClickAddToFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favoriteFill.png");
                    userID = Convert.ToInt32(favorite["UserID"].ToString());
                    check = true;
                }
            }
            Form1.form1.connection.Close();
            
        }
        public void AddRemoveFav()
        {
            if (UserLoginPanel.userLoginPanel.userID<1)
            {
                MessageBox.Show("Favori_foodcardpanel hata var.");
            }
            else
            {
                if (check)
                {
                    sqlCommandProcess.Proc("AddFavorite", procValue);
                }
                else if (!check)
                {
                    sqlCommandProcess.Proc("RemoveFavorite", procValue);
                }
            }
            
        }
        public void procValue()
        {
            sqlCommandProcess.ProcAdd("userid", SqlDbType.Int, UserLoginPanel.userLoginPanel.userID);
            sqlCommandProcess.ProcAdd("foodid", SqlDbType.Int, foodID);
        }
        public void TransferFavorite()
        {
            SqlDataReader favorite = adapter.SqlOperations("select * from Favorites as fav right join Foods as f on(fav.Favorite_FoodID=f.ID) left join User_Information as u on(fav.UserID=u.ID)  where UserID='" + UserLoginPanel.userLoginPanel.userID.ToString() + "'");
            while (favorite.Read())
            {
                if (this.Name.ToString() == favorite["Food"].ToString())
                {
                    FoodPanel.foodPanel.btnClickAddToFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\favoriteFill.png");
                    break;
                }
                else
                {
                    FoodPanel.foodPanel.btnClickAddToFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\favorite.png");
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
