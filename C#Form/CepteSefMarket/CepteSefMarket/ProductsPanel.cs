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

namespace CepteSefMarket
{
    public partial class ProductsPanel : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O4DQSUN;Initial Catalog=CepteSefdb;Integrated Security=True");
        //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D7I6MTC;Initial Catalog=CepteSefdb;Integrated Security=True");

        public static ProductsPanel productsPanel;
        Colors color = new Colors();
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        UC_ProductCard productCard;
        Button button;
        public TableLayoutPanel panel;

        //Values
        int categoryID=1;

        public ProductsPanel()
        {
            InitializeComponent();
            productsPanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            BackColor = Color.White; 
            AllCategories(33.33F, 3);
            this.Resize += ProductsPanel_Resize;
            Buttons();
        }

        public void ProductsPanel_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width <= 1200)
            {
                AllCategories(33.33F, 3);
            }
            else if (this.Size.Width > 1200 && this.Size.Width <= 1500)
            {
                AllCategories(25F, 4);
            }
            else if (this.Size.Width > 1500 && this.Size.Width <= 1800)
            {
                AllCategories(20F, 5);
            }
        }

        public void AllCategories(Single percent, int row)
        {
            SqlDataReader product = adapter.SqlOperations("select * from Nutrients as n inner join Type_Of_Nutrient as t on(n.TON_ID=t.ID) where TON_ID="+ categoryID, connection);
            pnlProducts.Controls.Clear();
            int count = 0;
            panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.ColumnCount = row;
            panel.RowCount = 1;
            pnlProducts.Controls.Add(panel);
            panel.AutoScroll = true;
            int i = 0, j = 0;
            int count2 = 0;
            while (product.Read())
            {
                productCard = new UC_ProductCard();
                productCard.Name = product["Nutrient_Name"].ToString();
                productCard.lblProductName.Text = product["Nutrient_Name"].ToString();
                //productCard.pbProduct.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProje\C#Form\CepteSef\CepteSef\Resources\{product["Category_Picture"]}");
                //productCard.pbProduct.BackgroundImageLayout = ImageLayout.Stretch;
                while (count2 < row)
                {
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                    count2++;
                }
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                if (i < panel.ColumnCount + 1)
                {
                    productCard.Anchor = AnchorStyles.None;
                    panel.Controls.Add(productCard, i, j);
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
        }
        public void Buttons()
        {
            SqlDataReader type = adapter.SqlOperations("select * from Type_Of_Nutrient order by ID desc", connection);
            pnlCategories.AutoScroll = true;
            pnlCategories.Controls.Clear();
            while (type.Read())
            {
                button = new Button();
                button.Name = type["Types"].ToString();
                button.Text = type["Types"].ToString();
                button.Dock = DockStyle.Top;
                button.Padding = new Padding(0);
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = color.blue;
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.Transparent;
                button.ForeColor = color.blue;
                button.Size = new Size(pnlCategories.Size.Width, 50);
                button.Padding = new Padding(10);
                button.Font = new Font("Coolvetica Condensed Rg", 15, FontStyle.Regular);
                button.FlatAppearance.MouseDownBackColor = Color.Transparent;
                button.FlatAppearance.MouseOverBackColor = Color.Transparent;

                button.MouseHover += Button_MouseHover;
                button.MouseLeave += Button_MouseLeave;

                button.Click += Button_Click;
                pnlCategories.Controls.Add(button);
            }
            connection.Close();
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = color.blue;
            button.Font = new Font("Coolvetica Condensed Rg", 15, FontStyle.Regular);
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            (sender as Button).ForeColor = color.main;
            button.Font = new Font("Coolvetica Condensed Rg", 15, FontStyle.Underline);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            SqlDataReader category = adapter.SqlOperations("select * from Nutrients as n inner join Type_Of_Nutrient as t on(n.TON_ID=t.ID)", connection);
            while (category.Read())
            {
                if ((sender as Button).Text.ToString() == category["Types"].ToString())
                {
                    categoryID = Convert.ToInt32(category["TON_ID"].ToString());
                }
            }
            connection.Close();
            ProductsPanel_Resize(sender, e);
        }
    }
}
