using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CepteSef
{
    class SqlCommandProcess
    {
        public string value;
        SqlCommand sqlCommand;

        //Procedure Komutlarını Cekme
        public void Proc(string procName, Action ProcProcess, SqlConnection connection)
        {
            connection.Open();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = procName;
            ProcProcess();
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void Proc(string procName)
        {
            Form1.form1.connection.Open();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = Form1.form1.connection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = procName;
            sqlCommand.ExecuteNonQuery();
            Form1.form1.connection.Close();
        }
        public void ProcAdd(string toolName, SqlDbType Type, object assignedValue)
        {
            sqlCommand.Parameters.Add(toolName.ToString(), Type).Value = assignedValue;
        }

        //Select Komutları
        public string Select(string valueName)
        {
            switch (valueName)
            {
                case "Foods":
                    value = "Select * From Foods as f inner join Category_Of_Food as c on(f.CategoryID=c.ID)";
                    break;
                case "Category":
                    value = "Select * From Category_Of_Food";
                    break;
                case "FoodsOfCategory":
                    value = "select * from Foods as f inner join Category_Of_Food as c on(f.CategoryID=c.ID) where c.ID="; //f.Food
                    break;
                case "Users":
                    value = "select * from User_Information";
                    break;
            }
            return value;
        }
    }
}
