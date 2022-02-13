using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CepteSefMarket
{
    public partial class SearchPanel : Form
    {
        public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O4DQSUN;Initial Catalog=CepteSefdb;Integrated Security=True");
        //public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D7I6MTC;Initial Catalog=CepteSefdb;Integrated Security=True");

        public static SearchPanel searchPanel;
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        Colors color = new Colors();
        TableLayoutPanel panel;
        UC_ProductCard productCard;
        public SearchPanel()
        {
            InitializeComponent();
            searchPanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;

            BackColor = color.light;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            AllCategories(33.33F, 3);
        }

        public void AllCategories(Single percent, int row)
        {
            SqlDataReader product = adapter.SqlOperations($"select * from Nutrients where Nutrient_Name like '%{tbSearchBar.Text}%'", connection);
            pnlScreen.Controls.Clear();
            int count = 0;
            panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.ColumnCount = row;
            panel.RowCount = 1;
            pnlScreen.Controls.Add(panel);
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
    }
}
