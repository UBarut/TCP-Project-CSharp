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
    public partial class UC_CategoryCardPanel : UserControl
    {
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        Colors color = new Colors();
        PrivateFontCollection pfc;
        public UC_CategoryCardPanel()
        {
            InitializeComponent();
            fontChange();
            BackColor = color.orange;
            tableLayoutPanel1.ForeColor = color.red;
            lblCategoryPanelName.Font = new Font(pfc.Families[0], 14, FontStyle.Bold);
        }

        private void pbCategory_Click(object sender, EventArgs e)
        {
            Form1.form1.HiddenScreens();
            Form1.form1.location = "category";
            Form1.form1.btnBack.Show();
            CategoryPanel.categoryPanel.lblCategoryName.Text = lblCategoryPanelName.Text;

            SqlDataReader category = adapter.SqlOperations(sqlCommandProcess.Select("Category"));
            while (category.Read())
            {
                if (lblCategoryPanelName.Text == category["Category"].ToString())
                {
                    Form1.form1.categoryID = Convert.ToInt32(category["ID"].ToString());
                    Form1.form1.categoryPanel.lblCategoryName.Text = category["Category"].ToString();
                }
            }
            Form1.form1.connection.Close();
            CategoryPanel.categoryPanel.CategoryPanel_Resize(sender, e);
            Form1.form1.categoryPanel.Show();
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
