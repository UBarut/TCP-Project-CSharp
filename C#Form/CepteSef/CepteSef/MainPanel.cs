using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace CepteSef
{
    public partial class MainPanel : Form
    {
        public static MainPanel mainPanel;
        UC_FoodCardPanel foodCard;
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O4DQSUN;Initial Catalog=CepteSefdb;Integrated Security=True");
        Colors color = new Colors();

        int count = 0;
        int pnlX = 20, pnlY = 20;
        PrivateFontCollection pfc;

        public MainPanel()
        {
            InitializeComponent();
            RandomFood();
            MostViewedFood();
            FavoritesFood();
            mainPanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            fontChange();

            BackColor = color.light;
            foreach (Label lbl in tableLayoutPanel1.Controls.OfType<Label>())
            {
                lbl.ForeColor = color.red;
                lbl.Font = new Font(pfc.Families[1], 16, FontStyle.Regular);
            }
        }
        public void RandomFood()
        {
            pnlRandomRecipe.AutoScroll = true;
            SqlDataReader random = adapter.SqlOperations("select top 10 * from Foods order by NEWID()");
            while (random.Read())
            {
                foodCard = new UC_FoodCardPanel();
                foodCard.Name = random["Food"].ToString();
                foodCard.lblFoodTitle.Text = random["Food"].ToString();
                foodCard.lblFoodComment.Text = random["FoodExplanation"].ToString();
                try
                {
                    foodCard.pictureBox1.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\{random["Food_Picture"]}");
                    foodCard.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception)
                {
                    
                }
                foodCard.Location = new Point(pnlX, pnlY);
                foodCard.Dock = DockStyle.Top;
                foodCard.Padding = new Padding(10);
                pnlY += foodCard.Size.Height + 20;
                pnlRandomRecipe.Controls.Add(foodCard);
            }
            Form1.form1.connection.Close();
            //CheckFavorite(foodCard);
        }
        public void MostViewedFood()
        {
            pnlMostViewed.Controls.Clear();
            pnlMostViewed.AutoScroll = true;
            SqlDataReader mostView = adapter.SqlOperations("select top 10 * from Foods order by total_views desc");
            while (mostView.Read())
            {
                foodCard = new UC_FoodCardPanel();
                foodCard.Name = mostView["Food"].ToString();
                foodCard.lblFoodTitle.Text = mostView["Food"].ToString();
                foodCard.lblFoodComment.Text = mostView["FoodExplanation"].ToString();
                try
                {
                    foodCard.pictureBox1.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\{mostView["Food_Picture"]}");
                    foodCard.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception)
                {

                }
                
                foodCard.Location = new Point(pnlX, pnlY);
                foodCard.Dock = DockStyle.Top;
                foodCard.Padding = new Padding(10);
                pnlY += foodCard.Size.Height + 20;
                pnlMostViewed.Controls.Add(foodCard);
            }
            Form1.form1.connection.Close();
            //CheckFavorite(foodCard);
        }
        public void FavoritesFood()
        {
            pnlFavorites.Controls.Clear();
            pnlFavorites.AutoScroll = true;
            SqlDataReader favorite = adapter.SqlOperations("select Food,COUNT(f.ID),Food_Picture,FoodExplanation from Favorites as fav inner join Foods as f on(fav.Favorite_FoodID=f.ID) group by Food,Food_Picture,FoodExplanation ORDER BY COUNT(f.ID) DESC");
            while (favorite.Read())
            {
                foodCard = new UC_FoodCardPanel();
                foodCard.Name = favorite["Food"].ToString();
                foodCard.lblFoodTitle.Text = favorite["Food"].ToString();
                foodCard.lblFoodComment.Text = favorite["FoodExplanation"].ToString();
                try
                {
                    foodCard.pictureBox1.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\{favorite["Food_Picture"]}");
                    foodCard.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception)
                {

                }
                
                foodCard.Location = new Point(pnlX, pnlY);
                foodCard.Dock = DockStyle.Top;
                foodCard.Padding = new Padding(10);
                pnlY += foodCard.Size.Height + 20;
                pnlFavorites.Controls.Add(foodCard);
            }
            Form1.form1.connection.Close();
        }
        public void CheckFavorite(UC_FoodCardPanel ismi)
        {
            //bool check= true;
            SqlDataReader favorite = adapter.SqlOperations("select * from Favorites as fav right join Foods as f on(fav.Favorite_FoodID=f.ID) left join User_Information as u on(fav.UserID=u.ID)  where UserID='" + UserLoginPanel.userLoginPanel.userID.ToString() + "'");
            while (favorite.Read())
            {
                if (ismi.Name.ToString() == favorite["Food"].ToString())
                {
                    UC_FoodCardPanel.foodCardPanel.btnFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favorite.png");
                    break;
                }
                else
                {
                    UC_FoodCardPanel.foodCardPanel.btnFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favoriteFill.png");
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
