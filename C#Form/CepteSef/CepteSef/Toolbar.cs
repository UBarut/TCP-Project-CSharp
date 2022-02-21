using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Threading;

namespace CepteSef
{
    class Toolbar
    {
        Form1 form1;
        //CategoryPanel categoryPanel = new CategoryPanel();
        //RecipePanel recipePanel = new RecipePanel();
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();
        Colors color = new Colors();

        //Values
        bool sliderBool = false;
        PrivateFontCollection pfc;


        public void AccessForm1(Form1 this_)
        {
            form1 = this_;
            ButtonControl();
            form1.pnlSliderMenu.Visible = sliderBool;
            form1.btnSliderMenu.Click += BtnSliderMenu_Click;
            form1.btnSearch.Click += BtnSearch_Click;
            fontChange();
            //SliderMenu Buttons
            foreach (Control button in form1.pnlSliderMenu.Controls.OfType<Button>())
            {
                button.Click += SliderBar_Click;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            form1.HiddenScreens();
            form1.searchPanel.Show();
            SearchPanel.searchPanel.searchedWord = form1.tbSearchbar.Text;
            SearchPanel.searchPanel.SearchingFood();
            form1.location = "search";
            form1.btnBack.Hide();
        }

        private void BtnSliderMenu_Click(object sender, EventArgs e)
        {
            if (sliderBool == false)
            {
                sliderBool = true;
                form1.pnlSliderMenu.BackColor = color.orange;
                form1.btnSliderMenu.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\exit.png");
            }
            else
            {
                sliderBool = false;
                form1.btnSliderMenu.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\menu.png");

            }
            form1.pnlSliderMenu.Visible = sliderBool;
        }

        public void ButtonControl()
        {
            form1.mainPanel.Show();
            form1.recipePanel.Hide();
            form1.uC_MakeMenuPanel1.Hide();
            form1.uC_ShareRecipePanel1.Hide();
            form1.foodPanel.Hide();
            form1.btnBack.Hide();
            form1.categoryPanel.Hide();
            foreach (Control button in form1.pnlMenus.Controls.OfType<Button>())
            {
                button.Click += Button_Click;
            }
            form1.btnBack.Click += BtnBack_Click;
        }

        private void SliderBar_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name.ToString() == "btnLogin")
            {
                form1.HiddenScreens();
                form1.userLoginPanel.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnCart")
            {
                form1.HiddenScreens();
                form1.userCart.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnExit")
            {
                UserLoginPanel.userLoginPanel.userID = 0;
                form1.HiddenSliders();
            }

            form1.pnlSliderMenu.Visible = false;
            sliderBool = false;
            form1.btnSliderMenu.BackgroundImage = Image.FromFile(@"C:\Users\kufub\OneDrive\Masaüstü\CepteSefProject\C#Form\CepteSef\CepteSef\Resources\menu.png");
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            foreach (var item in form1.pnlMenus.Controls)
            {
                Debug.WriteLine(item);
            }
            Debug.WriteLine("Toplam Sayfa Sayısı: "+form1.pnlScreen.Controls.Count);
            if ((sender as Button).Name.ToString() == "btnMainMenu")
            {
                form1.location = "mainMenu";
                form1.HiddenScreens();
                form1.mainPanel.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnRecipe")
            {
                form1.location = "category";
                form1.HiddenScreens();
                //RecipePanel.recipePanel.AllSetupRecipe();
                //RecipePanel.recipePanel.RecipePanel_Resize(sender, e);
                form1.recipePanel.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnMakeMenu")
            {
                form1.location = "makeMenu";
                form1.HiddenScreens();
                form1.uC_MakeMenuPanel1.Show();
            }
            else if ((sender as Button).Name.ToString() == "btnShareRecipe")
            {
                form1.location = "shareRecipe";
                form1.HiddenScreens();
                form1.uC_ShareRecipePanel1.Show();
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (form1.foodPanel.Visible && form1.location =="mainMenu")
            {
                form1.HiddenScreens();
                form1.mainPanel.Show();
                form1.btnBack.Hide();
            }
            else if (form1.categoryPanel.Visible && form1.location == "category")
            {
                form1.HiddenScreens();
                //form1.recipePanel.Show();
                form1.btnBack.Hide();
            }
            else if (form1.location == "search")
            {
                form1.HiddenScreens();
                form1.searchPanel.Show();
                form1.btnBack.Hide();
            }
            else if (form1.foodPanel.Visible) // anamenüde foodpanele geçiş ve geri dönüşte sıkıntı olabilir. İncele.
            {
                SqlDataReader category = adapter.SqlOperations(sqlCommandProcess.Select("Category"));
                while (category.Read())
                {
                    if (form1.location == category["Category"].ToString())
                    {
                        form1.HiddenScreens();
                        form1.categoryPanel.Show();
                        form1.location = "category";
                        break;
                    }
                }
                form1.connection.Close();
                CategoryPanel.categoryPanel.CategoryPanel_Resize(sender, e);
            }
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
