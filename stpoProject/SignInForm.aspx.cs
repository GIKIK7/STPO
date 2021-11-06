using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace stpoProject
{
    public partial class SignInForm : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        String queryStr;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            registerUser();
        }

        private void registerUser()
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnString"].ToString();

            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);

            conn.Open();

            queryStr = "";

            queryStr = "INSERT INTO stpo.users (login, password) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);

            cmd.ExecuteReader();

            conn.Close();

        }
    }
}