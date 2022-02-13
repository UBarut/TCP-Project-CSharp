using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Text;

namespace CepteSefMarket
{
    public partial class UserCart : Form
    {
        public static UserCart userCart;
        Label lblProductName, lblProductCount,label;
        TableLayoutPanel panel;
        Button button,button2;
        UC_ProductInCart productInCart;
        Colors color = new Colors();
        Adapter adapter = new Adapter();

        SimpleTcpServer server;
        string iptxt = "192.168.1.30";
        int port = 1903;

        int i = 0;
        int count = 0;
        bool adding = false;
        PrivateFontCollection pfc;

        public UserCart()
        {
            InitializeComponent();
            userCart = this;
            TopLevel = false;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;

            fontChange();
            ForeColor = color.main;
            BackColor = color.light;
            btnBuy.Font = new Font(pfc.Families[1], 18, FontStyle.Regular);
            btnClear.Font = new Font(pfc.Families[1], 18, FontStyle.Regular);
            label1.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
        }


        private void UserCart_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DelimiterDataReceived += Server_DelimiterDataReceived;

            try
            {
                System.Net.IPAddress ip = System.Net.IPAddress.Parse(iptxt);
                SqlDataReader portt = adapter.SqlOperations("select * from User_Information where ID=" + UserLoginPanel.userLoginPanel.userID, Form1.form1.connection);
                while (portt.Read())
                {
                    server.Start(ip, Convert.ToInt32(portt["Port"].ToString()));
                }
                Form1.form1.connection.Close();
                //server.Start(ip, port);
                Thread.Sleep(1000);
                Debug.WriteLine("Bağlantı gerçekleşti");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Bağlantı oluşturulurken hata oluştu" + ex);
            }
        }

        private void Server_DelimiterDataReceived(object sender, SimpleTCP.Message e)
        {
            pnlCartList.Invoke((MethodInvoker)delegate ()
            {
                foreach (UC_ProductInCart cart in pnlCartList.Controls.OfType<UC_ProductInCart>())
                {
                    if (cart.Name.ToString() == "pnlProduct" + e.MessageString)
                    {
                        AddProductCard(e.MessageString);
                        cart.lblCount.Text = (Convert.ToInt32(cart.lblCount.Text) + 1).ToString();
                        adding = true;
                        break;
                    }
                }
                if (!adding)
                {
                    productInCart = new UC_ProductInCart();
                    productInCart.Name = "pnlProduct" + e.MessageString;
                    productInCart.lblProductName.Name = "lblProdcutName" + e.MessageString;
                    productInCart.lblCount.Name = "lblCount" + e.MessageString;
                    productInCart.btnAdd.Name = "btnAdd" + e.MessageString;
                    productInCart.btnSubtract.Name = "btnSubtract" + e.MessageString;
                    productInCart.lblProductName.Text = e.MessageString;
                    productInCart.lblCount.Text = "1";
                    pnlCartList.Controls.Add(productInCart);
                    productInCart.Dock = DockStyle.Top;
                    AddProductCard(e.MessageString);
                }
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pnlCartList.Controls.Clear();
            foreach (UC_ProductCard card in ProductsPanel.productsPanel.panel.Controls.OfType<UC_ProductCard>())
            {
                card.lblCount.Text = "0";
            }
        }

        public void AddProductCard(string name)
        {
            foreach (UC_ProductCard card in ProductsPanel.productsPanel.panel.Controls.OfType<UC_ProductCard>())
            {
                if (card.lblProductName.Text == name)
                {
                    card.lblCount.Text = (Convert.ToInt32(card.lblCount.Text)+1).ToString();
                }
            }
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
