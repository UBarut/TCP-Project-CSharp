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
using System.Drawing.Text;

namespace CepteSef
{
    public partial class CategoryPanel : Form
    {
        public static CategoryPanel categoryPanel;
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O4DQSUN;Initial Catalog=CepteSefdb;Integrated Security=True");
        //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D7I6MTC;Initial Catalog=CepteSefdb;Integrated Security=True");
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Colors color = new Colors();
        UC_FoodCardPanel foodsCard;
        Adapter adapter = new Adapter();
        Button button;

        //Values
        int count = 0;
        PrivateFontCollection pfc;

        public CategoryPanel()
        {
            InitializeComponent();
            categoryPanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            fontChange();
            CategoryButtons();
            this.Resize += CategoryPanel_Resize;

            BackColor = color.light;
            label1.ForeColor = color.red;
            label1.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
            lblCategoryName.ForeColor = color.red;
            lblCategoryName.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
        }


        public void CategoryPanel_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width < 1200)
            {
                FoodsOfCategories(50F, 2);
            }
            else if (this.Size.Width > 1200 && this.Size.Width <= 1500)
            {
                FoodsOfCategories(33.33F, 3);
            }
            else if (this.Size.Width > 1500 && this.Size.Width <= 1800)
            {
                FoodsOfCategories(25F, 4);
            }
        }

        public void CategoryButtons()
        {
            SqlDataReader category = adapter.SqlOperations(sqlCommandProcess.Select("Category"), connection);
            pnlCategories.AutoScroll = true;
            while (category.Read())
            {
                button = new Button();
                button.Name = "btnCategory" + count;
                button.Text = category["Category"].ToString();
                button.Dock = DockStyle.Top;
                button.Size = new Size(pnlCategories.Size.Width, 50);
                button.Font = new Font(pfc.Families[1], 14, FontStyle.Regular);
                button.ForeColor = color.red;
                button.Padding = new Padding(10);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.MouseDownBackColor = Color.Transparent;
                button.FlatAppearance.MouseOverBackColor = Color.Transparent;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.Transparent;
                button.Click += Button_Click;
                button.MouseHover += Button_MouseHover;
                button.MouseLeave += Button_MouseLeave;
                pnlCategories.Controls.Add(button);
                count++;
            }
            connection.Close();
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = color.red;
            button.Font = new Font(pfc.Families[1], 14, FontStyle.Regular);
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = color.main;
            button.Font = new Font(pfc.Families[1], 14, FontStyle.Underline);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            SqlDataReader category = adapter.SqlOperations(sqlCommandProcess.Select("Category"), connection);
            while (category.Read())
            {
                if ((sender as Button).Text.ToString() == category["Category"].ToString())
                {
                    Form1.form1.categoryID = Convert.ToInt32(category["ID"].ToString());
                    lblCategoryName.Text = category["Category"].ToString();
                }
            }
            connection.Close();
            CategoryPanel_Resize(sender, e);
        }
        public void FoodsOfCategories(Single percent, int row)
        {
            SqlDataReader food = adapter.SqlOperations(sqlCommandProcess.Select("FoodsOfCategory") + Form1.form1.categoryID.ToString(), connection);
            pnlFoodCards_Category.Controls.Clear();
            int count = 0;
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.ColumnCount = row;
            panel.RowCount = 1;
            pnlFoodCards_Category.Controls.Add(panel);
            panel.AutoScroll = true;
            int i = 0, j = 0;
            int count2 = 0;
            while (food.Read())
            {
                foodsCard = new UC_FoodCardPanel();
                foodsCard.Name = food["Food"].ToString();
                foodsCard.lblFoodTitle.Text = food["Food"].ToString();
                foodsCard.lblFoodComment.Text = food["FoodExplanation"].ToString();
                //if (Convert.ToInt32(food["UserID"].ToString())==UserLoginPanel.userLoginPanel.userID &&)
                //{

                //}
                foodsCard.pictureBox1.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\{food["Food_Picture"]}");
                foodsCard.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                while (count2 < row)
                {
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                    count2++;
                }
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                if (i < panel.ColumnCount)
                {
                    foodsCard.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    panel.Controls.Add(foodsCard, i, j);
                    i++;
                }
                else
                {
                    panel.RowCount = panel.RowCount + 1;
                    panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    i = 0;
                    j++;
                }
                count++;
            }
            connection.Close();
            SqlDataReader favorite = adapter.SqlOperations("select * from Favorites as fav right join Foods as f on(fav.Favorite_FoodID=f.ID) left join User_Information as u on(fav.UserID=u.ID)  where f.CategoryID='" + Form1.form1.categoryID.ToString() + "' and UserID='" + UserLoginPanel.userLoginPanel.userID.ToString() + "'", connection);
            while (favorite.Read())
            {
                Debug.WriteLine(favorite["Food"].ToString());
                foreach (UC_FoodCardPanel card in panel.Controls.OfType<UC_FoodCardPanel>())
                {
                    if (card.Name.ToString() == favorite["Food"].ToString())
                    {
                        card.btnFavorite.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\favoriteFill.png");
                        Form1.form1.favoriteIcon = "favoriteFill";
                    }
                }
            }
            connection.Close();
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
