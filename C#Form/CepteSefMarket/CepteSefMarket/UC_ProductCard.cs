using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CepteSefMarket
{
    public partial class UC_ProductCard : UserControl
    {
        public static UC_ProductCard productCard;
        UC_ProductInCart productInCart;
        Colors color = new Colors();
        public UC_ProductCard()
        {
            InitializeComponent();
            productCard = this;
            foreach (Button button in tableLayoutPanel2.Controls.OfType<Button>())
            {
                button.Click += Button_Click;
            }
            ForeColor = color.main;
            BackColor = color.light2;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (UserLoginPanel.userLoginPanel.userID == -1)
            {
                MessageBox.Show("Üyelik Girişi Yapınız.");
            }
            else if(UserLoginPanel.userLoginPanel.userID == 0)
            {

            }
            else
            {
                if ((sender as Button).Name.ToString() == "btnAdd")
                {
                    if (Convert.ToInt32(lblCount.Text) > 0)
                    {
                        lblCount.Text = (Convert.ToInt32(lblCount.Text) + 1).ToString();
                        foreach (UC_ProductInCart productCart in UserCart.userCart.pnlCartList.Controls.OfType<UC_ProductInCart>())
                        {
                            if (productCart.lblProductName.Text == lblProductName.Text)
                            {
                                productCart.lblCount.Text = (Convert.ToInt32(productCart.lblCount.Text) + 1).ToString();
                            }
                        }
                    }
                    else if (lblCount.Text == "0")
                    {
                        lblCount.Text = (Convert.ToInt32(lblCount.Text) + 1).ToString();
                        productInCart = new UC_ProductInCart();
                        productInCart.Name = "pnlProduct" + lblProductName.Text;
                        productInCart.lblProductName.Name = "lblProdcutName" + lblProductName.Text;
                        productInCart.lblCount.Name = "lblCount" + lblProductName.Text;
                        productInCart.btnAdd.Name = "btnAdd" + lblProductName.Text;
                        productInCart.btnSubtract.Name = "btnSubtract" + lblProductName.Text;
                        productInCart.lblProductName.Text = lblProductName.Text;
                        productInCart.lblCount.Text = "1";
                        UserCart.userCart.pnlCartList.Controls.Add(productInCart);
                        productInCart.Dock = DockStyle.Top;
                    }
                }
                else if ((sender as Button).Name.ToString() == "btnSubtract")
                {
                    if (Convert.ToInt32(lblCount.Text) == 0)
                    {
                        MessageBox.Show("Ürün sepetinde bulunmamaktadır.");
                    }
                    else if (Convert.ToInt32(lblCount.Text) == 1)
                    {
                        lblCount.Text = (Convert.ToInt32(lblCount.Text) - 1).ToString();
                        foreach (UC_ProductInCart productCart in UserCart.userCart.pnlCartList.Controls.OfType<UC_ProductInCart>())
                        {
                            if (productCart.lblProductName.Text == lblProductName.Text)
                            {
                                UserCart.userCart.pnlCartList.Controls.Remove(productCart);
                            }
                        }
                    }
                    else
                    {
                        lblCount.Text = (Convert.ToInt32(lblCount.Text) - 1).ToString();
                        foreach (UC_ProductInCart productCart in UserCart.userCart.pnlCartList.Controls.OfType<UC_ProductInCart>())
                        {
                            if (productCart.lblProductName.Text == lblProductName.Text)
                            {
                                productCart.lblCount.Text = (Convert.ToInt32(productCart.lblCount.Text) - 1).ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}
