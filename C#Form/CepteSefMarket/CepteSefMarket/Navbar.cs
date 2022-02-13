using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CepteSefMarket
{
    
    class Navbar
    {
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();

        public void NavbarControl()
        {
            foreach (Control button in Form1.form1.pnlNavbar.Controls.OfType<Button>())
            {
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name.ToString() == "btnProducts")
            {
                Form1.form1.HiddenScreens();
                Form1.form1.productsPanel.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnCart")
            {
                Form1.form1.HiddenScreens();
                Form1.form1.userCart.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnSearch")
            {
                Form1.form1.HiddenScreens();
                Form1.form1.searchPanel.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnProfil")
            {
                
            }
            else if ((sender as Button).Name.ToString() == "btnLogin")
            {
                Form1.form1.HiddenScreens();
                Form1.form1.userLoginPanel.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnExit")
            {
                DialogResult dialog = MessageBox.Show("Çıkmak İstediğine Emin misin?", "Çıkış", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Form1.form1.HiddenNavbar();
                    UserLoginPanel.userLoginPanel.userID = -1;
                    Form1.form1.lblUserName.Text = "";
                    Form1.form1.userLoginPanel.Show();
                }
            }
        }
    }
}
