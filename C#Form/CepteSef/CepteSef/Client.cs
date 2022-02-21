using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace CepteSef
{
    class Client
    {
        SimpleTcpClient client;
        SqlCommandProcess sqlCommandProcess = new SqlCommandProcess();
        Adapter adapter = new Adapter();

        string ip = "192.168.1.30";
        int port;
        int count=0;
        public void StartServer()
        {
            UserCart.userCart.btnSendCart.Click += BtnSendCart_Click;
            
        }
        //AccessNutrients
        private void BtnSendCart_Click(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8; 

            try
            {
                SqlDataReader portt = adapter.SqlOperations("select * from User_Information where ID=" + UserLoginPanel.userLoginPanel.userID);
                while (portt.Read())
                {
                    client.Connect(ip, Convert.ToInt32(portt["Port"].ToString()));
                }
                Form1.form1.connection.Close();
                Debug.WriteLine("Bağlantı Aktif.");

                int[] foodIDs = new int[1000];
                List<string> nutrients = new List<string>();
                //string sqlString = "select Nutrient_Name from Nutrients Where ID in (select * from string_split((select Ingredients from Foods where ID='"+1+"'),','))";
                SqlDataReader food = adapter.SqlOperations(sqlCommandProcess.Select("Foods"));
                while (food.Read())
                {
                    foreach (string foods in UserCart.userCart.lbCartList.Items)
                    {
                        if (foods == food["Food"].ToString())
                        {
                            foodIDs[count] = Convert.ToInt32(food["ID"].ToString());
                            count++;
                        }
                    }
                }
                Form1.form1.connection.Close();
                for (int i = 1; i < count + 1; i++)
                {
                    SqlDataReader sqlNutrients = adapter.SqlOperations("select Nutrient_Name from Nutrients Where ID in (select * from string_split((select Ingredients from Foods where ID='" + foodIDs[i] + "'),','))");
                    while (sqlNutrients.Read())
                    {
                        if (!nutrients.Contains(sqlNutrients["Nutrient_Name"].ToString()))
                        {
                            nutrients.Add(sqlNutrients["Nutrient_Name"].ToString());
                        }
                    }
                    Form1.form1.connection.Close();
                }
                foreach (string a in nutrients)
                {
                    client.WriteLineAndGetReply(a, TimeSpan.FromSeconds(3));
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Bağlantıda Hata Var.");
                MessageBox.Show("CepteSef Market ile hesabınız eşleşmemektedir!");
            }

            
        }
    }
}
