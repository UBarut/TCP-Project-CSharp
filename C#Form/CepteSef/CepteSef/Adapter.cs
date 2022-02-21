using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace CepteSef
{
    class Adapter
    {
        public void SqlOperations(string sqlCommand, Form1 form1, DataGridView dgv)
        {
            form1.connection.Open();
            DataTable datatable = new DataTable();
            SqlDataAdapter fillTable = new SqlDataAdapter(sqlCommand, form1.connection);
            fillTable.Fill(datatable);
            dgv.DataSource = datatable;
            form1.connection.Close();
        }
        public SqlDataReader SqlOperations(string sqlCommand)
        {
            Form1.form1.connection.Open();
            SqlCommand sqlCommandName = new SqlCommand(sqlCommand, Form1.form1.connection);
            SqlDataReader dataReader = sqlCommandName.ExecuteReader();
            return dataReader;
        }
    }
}
