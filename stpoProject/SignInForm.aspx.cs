using System;
using System.Data.SqlClient;

namespace stpoProject
{
    public partial class SignInForm : System.Web.UI.Page
    {

        //Server=tcp:stpo.database.windows.net,1433;Initial Catalog=StpoDB;
        //Persist Security Info=False;User ID=GIKIK;Password={your_password};
        //MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
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

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "stpo.database.windows.net";
            builder.UserID = "GIKIK";
            builder.Password = "AdminHaslo137";
            builder.InitialCatalog = "StpoDB";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                connection.Open();

                String sql = "SELECT * FROM dbo.users";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lbl1.Text += reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString();
                        }
                    }
                }
            }

        }
    }
}