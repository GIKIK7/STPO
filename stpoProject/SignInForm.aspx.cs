using System;
using System.Data.SqlClient;
using System.Linq;

namespace stpoProject
{
    public partial class SignInForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lbl_Helper.Text = "";
        }

        protected void Btn_SignIn_Click(object sender, EventArgs e)
        {
            String login = String.Concat(TxtBox_login.Text.Where(c => !Char.IsWhiteSpace(c)));
            String password = String.Concat(TxtBox_password.Text.Where(c => !Char.IsWhiteSpace(c)));
            String name = String.Concat(TxtBox_name.Text.Where(c => !Char.IsWhiteSpace(c)));
            String lName = String.Concat(TxtBox_LastName.Text.Where(c => !Char.IsWhiteSpace(c)));

            if (login.Length == 0 || password.Length == 0 || name.Length == 0 || lName.Length == 0)
            {
                Lbl_Helper.Text = "Wszystkie pola sa wymagane!";
            }
            registerUser(login, password, name, lName);
            Response.Redirect("LogInForm.aspx");
        }

        private void registerUser(String login, String password, String name, String lName)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "stpo.database.windows.net";
            builder.UserID = "GIKIK";
            builder.Password = "AdminHaslo137";
            builder.InitialCatalog = "DBstpo";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                connection.Open();

                SqlCommand cmd;

                int user_id=0;
                
                String sql = "INSERT INTO [dbo].[userTest] (login, password) VALUES ('" + login + "','" + password + "')";

                cmd = new SqlCommand(sql, connection);

                cmd.ExecuteReader();

                connection.Close();

                connection.Open();

                String getIdUser = "SELECT ID FROM [dbo].[userTest] WHERE login='" + login + "' AND password='" + password + "'";


                using (SqlCommand command = new SqlCommand(getIdUser, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user_id = Int16.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }   

                Lbl_Helper.Text = user_id.ToString();

                connection.Close();

                connection.Open();

                String insertToKlient = "INSERT INTO [dbo].[klient] (ID_user, name, last_name) VALUES ('" + user_id + "','" + name + "','" + lName + "')";

                using (SqlCommand command = new SqlCommand(insertToKlient, connection))
                {
                    command.ExecuteReader();
                }

            }

        }
    }
}