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

                String sql = "SELECT ID, password, isTrener FROM [dbo].[users] WHERE login='" + TxtBox_User.Text + "'";

                SqlCommand cmdGetInfoUser = new SqlCommand(sql, connection);
                SqlDataReader readerGetInfoUser = cmdGetInfoUser.ExecuteReader();

                while (readerGetInfoUser.Read())
                {
                    if (readerGetInfoUser.GetValue(1).ToString() == TxtBox_Password.Text)
                    {
                        LbL_Helper.Text = "Zalogowano!";
                        Session["ID_user"] = Int16.Parse(readerGetInfoUser.GetValue(0).ToString());
                        
                        if(readerGetInfoUser.GetValue(2).ToString() == "True")
                        {
                            Response.Redirect("CoachDetailsForm.aspx");
                        }
                        else
                        {
                            Response.Redirect("ClientDetailsForm.aspx");
                        }
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