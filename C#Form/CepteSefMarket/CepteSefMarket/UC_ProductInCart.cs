using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CepteSefMarket
{
    public partial class UC_ProductInCart : UserControl
    {
        Colors color = new Colors();
        public UC_ProductInCart()
        {
            InitializeComponent();
            gradientPanel1.ColorTop = color.pink;
            gradientPanel1.ColorBottom = color.light;
            gradientPanel1.Degree = 0F;
            ForeColor = Color.White;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblCount.Text = (Convert.ToInt32(lblCount.Text) + 1).ToString();
            foreach (UC_ProductCard card in ProductsPanel.productsPanel.panel.Controls.OfType<UC_ProductCard>())
            {
                if (card.lblProductName.Text == lblProductName.Text)
                {
                    card.lblCount.Text = (Convert.ToInt32(card.lblCount.Text) + 1).ToString();
                }
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        { 
            if (Convert.ToInt32(lblCount.Text) == 1)
            {
                UserCart.userCart.pnlCartList.Controls.Remove(this);
                foreach (UC_ProductCard card in ProductsPanel.productsPanel.panel.Controls.OfType<UC_ProductCard>())
                {
                    if (card.lblProductName.Text == lblProductName.Text)
                    {
                        card.lblCount.Text = "0";
                    }
                }
            }
            else
            {
                lblCount.Text = (Convert.ToInt32(lblCount.Text) - 1).ToString();
                foreach (UC_ProductCard card in ProductsPanel.productsPanel.panel.Controls.OfType<UC_ProductCard>())
                {
                    if (card.lblProductName.Text == lblProductName.Text)
                    {
                        card.lblCount.Text = (Convert.ToInt32(card.lblCount.Text) -1).ToString();
                    }
                }
            }
        }
    }
}
