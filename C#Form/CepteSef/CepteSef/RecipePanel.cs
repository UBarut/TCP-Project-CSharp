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
    public partial class RecipePanel : Form
    {
        //Access Process
        UC_CategoryCardPanel categoriesCard;
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        Colors color = new Colors();


        //Values
        public static RecipePanel recipePanel;
        TableLayoutPanel panel = new TableLayoutPanel();
        int count2 = 0;
        public RecipePanel()
        {
            InitializeComponent();
            recipePanel = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            AllCategories(33.33F, 3);
            this.Resize += RecipePanel_Resize;
            BackColor = color.light;
            Padding = new Padding(10);
        }

        public void RecipePanel_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width <= 500)
            {
                categoryResize(100F, 1);
            }
            else if (this.Size.Width <= 800)
            {
                categoryResize(50F, 2);
            }
            else if (this.Size.Width <= 1200)
            {
                categoryResize(33.33F, 3);
            }
            else if (this.Size.Width > 1200 && this.Size.Width <= 1500)
            {
                categoryResize(25F, 4);
            }
            else if (this.Size.Width > 1500 && this.Size.Width <= 1800)
            {
                categoryResize(20F, 5);
            }
        }


        public void AllCategories(Single percent, int row)
        {
            SqlDataReader category = adapter.SqlOperations(sqlCommandProcess.Select("Category"));
            this.Controls.Clear();
            int count = 0;
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.Transparent;
            panel.ColumnCount = row;
            panel.RowCount = 1;
            this.Controls.Add(panel);
            panel.AutoScroll = true;
            int i = 0, j = 0;
            while (category.Read())
            {
                categoriesCard = new UC_CategoryCardPanel();
                categoriesCard.Name = "cntlPnlCategory" + count;
                categoriesCard.lblCategoryPanelName.Text = category["Category"].ToString();
                categoriesCard.pbCategory.BackgroundImage = Image.FromFile(@$"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\{category["Category_Picture"]}");
                categoriesCard.pbCategory.BackgroundImageLayout = ImageLayout.Stretch;
                while (count2 < row)
                {
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                    count2++;
                }
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                if (i < panel.ColumnCount + 1)
                {
                    categoriesCard.Anchor = AnchorStyles.None;
                    panel.Controls.Add(categoriesCard, i, j);
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
            Form1.form1.connection.Close();
        }
        public void categoryResize(Single percent, int row)
        {
            panel.ColumnCount = row;
            while (count2 < row)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));
                count2++;
            }
        }
    }
}
