using System;
using System.Data.SqlClient;
using System.Linq;

namespace stpoProject
{
    public partial class SignInForm : System.Web.UI.Page
    {

        static bool isChecked = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Lbl_Helper.Text = "";
            ChkBox_trener.Checked = isChecked;
        }

        protected void Btn_SignIn_Click(object sender, EventArgs e)
        {
            String login = TxtBox_login.Text.Trim();
            String password = TxtBox_password.Text.Trim();
            String name = TxtBox_name.Text.Trim();
            String lName = TxtBox_LastName.Text.Trim();
            bool isTrener = isChecked;

            if (login.Length == 0 || password.Length == 0 || name.Length == 0 || lName.Length == 0)
            {
                Lbl_Helper.Text = "Wszystkie pola sa wymagane!";
            }
            else
            {
                registerUser(login, password, name, lName, isTrener);
                Response.Redirect("LogInForm.aspx");
            }
            
        }

        private void registerUser(String login, String password, String name, String lName, bool isTrener)
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
                
                String sql = "INSERT INTO [dbo].[users] (login, password, isTrener) VALUES ('" + login + "','" + password + "','" + isTrener + "')";

                cmd = new SqlCommand(sql, connection);

                cmd.ExecuteReader();

                connection.Close();

                connection.Open();

                String getIdUser = "SELECT ID FROM [dbo].[users] WHERE login='" + login + "' AND password='" + password + "'";

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

                connection.Close();

                connection.Open();

                String insertStr="";

                if (isTrener == true)
                {
                    insertStr = "INSERT INTO [dbo].[coaches] (ID_user, name, last_name) VALUES ('" + user_id + "','" + name + "','" + lName + "')";
                }
                else
                {
                    insertStr = "INSERT INTO [dbo].[clients] (ID_user, name, last_name) VALUES ('" + user_id + "','" + name + "','" + lName + "')";
                }
                
                using (SqlCommand command = new SqlCommand(insertStr, connection))
                {
                    command.ExecuteReader();
                }

            }

        }

        protected void ChkBox_trener_CheckedChanged(object sender, EventArgs e)
        {
            Lbl_Helper.Text += "he";
            //Lbl_Helper.Text = isTrener.ToString();
            if (isChecked)
            {
                isChecked = false;
                ChkBox_trener.Checked = isChecked;
            }
            else
            {
                isChecked = true;
                ChkBox_trener.Checked = isChecked;
            }
        }
    }
}