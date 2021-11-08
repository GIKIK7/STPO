using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace stpoProject
{
    public partial class LogInForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Btn_LogInClick(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "stpo.database.windows.net";
            builder.UserID = "GIKIK";
            builder.Password = "AdminHaslo137";
            builder.InitialCatalog = "DBstpo";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                String sql = "SELECT ID, password FROM [dbo].[users] WHERE login='" + TxtBox_User.Text + "'";

                SqlCommand cmdGetPassword = new SqlCommand(sql, connection);
                SqlDataReader readerGetPassword = cmdGetPassword.ExecuteReader();

                while (readerGetPassword.Read())
                {
                    if (readerGetPassword.GetValue(1).ToString() == TxtBox_Password.Text)
                    {
                        LbL_Helper.Text = "Zalogowano!";
                        Session["ID_user"] = Int16.Parse(readerGetPassword.GetValue(0).ToString());
                        Response.Redirect("CoachDetailsForm.aspx");
                    }
                    else
                    {
                        LbL_Helper.Text = "Niepoprawne haslo!";
                    }
                }
                connection.Close();
            }
        }
    }
}