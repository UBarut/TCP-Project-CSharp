using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CepteSef
{
    public partial class SearchPanel : Form
    {
        public static SearchPanel searchPanel;
        readonly Adapter adapter = new Adapter();
        readonly Colors color = new Colors();
        UC_FoodCardPanel foodCard;

        //Values
        int pnlX, pnlY;
        public string searchedWord="";
        public SearchPanel()
        {
            InitializeComponent();
            searchPanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            BackColor = color.light;
            SearchingFood();
        }
        public void SearchingFood()
        {
            pnlScreen.Controls.Clear();
            pnlScreen.AutoScroll = true;
            SqlDataReader searching = adapter.SqlOperations($"select * from Foods where Food like '%{searchedWord}%'");
            while (searching.Read())
            {
                foodCard = new UC_FoodCardPanel();
                foodCard.Name = searching["Food"].ToString();
                foodCard.lblFoodTitle.Text = searching["Food"].ToString();
                foodCard.lblFoodComment.Text = searching["FoodExplanation"].ToString();
                try
                {
                    foodCard.pictureBox1.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\{searching["Food_Picture"]}");
                    foodCard.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
                catch (Exception)
                {

                }

                foodCard.Location = new Point(pnlX, pnlY);
                foodCard.Dock = DockStyle.Top;
                foodCard.Padding = new Padding(10);
                pnlY += foodCard.Size.Height + 20;
                pnlScreen.Controls.Add(foodCard);
            }
            Form1.form1.connection.Close();
            //CheckFavorite(foodCard);
        }
    }
}
