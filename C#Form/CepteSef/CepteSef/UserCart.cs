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
    public partial class UserCart : Form
    {
        public static UserCart userCart;
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-O4DQSUN;Initial Catalog=CepteSefdb;Integrated Security=True");
        //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-D7I6MTC;Initial Catalog=CepteSefdb;Integrated Security=True");
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        Colors color = new Colors();
        PrivateFontCollection pfc;

        public UserCart()
        {
            InitializeComponent();
            userCart = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            Dock = DockStyle.Fill;
            fontChange();
            gradientPanel1.ColorBottom = color.main;
            gradientPanel1.ColorTop = color.main;
            label1.Font = new Font(pfc.Families[1], 16, FontStyle.Bold);
            label1.ForeColor = color.red;
            lbCartList.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);
            lbCartList.ForeColor = color.red;

            foreach (Button button in pnlButtons.Controls.OfType<Button>())
            {
                button.Font = new Font(pfc.Families[0], 12, FontStyle.Bold);
                button.ForeColor = color.red;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.MouseDownBackColor = Color.Transparent;
                button.FlatAppearance.MouseOverBackColor = Color.Transparent;
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = Color.Transparent;
                button.Click += Button_Click;
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name.ToString() == "btnAddFood")
            {
                Form1.form1.HiddenScreens();
                Form1.form1.recipePanel.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnClear")
            {
                lbCartList.Items.Clear();
            }
            else if ((sender as Button).Name.ToString() == "btnRemove")
            {
                if (lbCartList.SelectedIndex != -1)
                {
                    lbCartList.Items.Remove(lbCartList.SelectedItem);
                }
                
            }
        }

        private void btnCloseCart_Click(object sender, EventArgs e)
        {
            Form1.form1.userCart.Hide();
            Form1.form1.mainPanel.Show();
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
