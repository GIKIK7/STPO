using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace stpoProject
{
    public partial class CoachEditForm : System.Web.UI.Page
    {

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Int16.Parse(Session["ID_user"].ToString()) == -1)
            {
                Response.Redirect("LogInForm.aspx");
            }

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String sql = "SELECT name, last_name FROM [dbo].[coaches] WHERE ID_user='" + Session["ID_user"] + "'";

            SqlCommand cmdGetFullName = new SqlCommand(sql, connection);
            SqlDataReader readerGetFullName = cmdGetFullName.ExecuteReader();

            while (readerGetFullName.Read())
            {
                Lbl_Coach.Text = "Edycja Trenera: " + readerGetFullName.GetValue(0).ToString() + " " + readerGetFullName.GetValue(1).ToString();
            }
            connection.Close();
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            String name = TxtBox_Name.Text.Trim();
            String lName = TxtBox_lastName.Text.Trim();

            if (name.Length == 0 || lName.Length == 0)
            {
                Lbl_helper.Text = "Wszystkie pola sa wymagane!";
            }
            else
            {
                submitFunction(name, lName);
                Response.Redirect("CoachDetailsForm.aspx");
            }
        }

        void submitFunction(String name, String lastName)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String updateCoach = "UPDATE [dbo].[coaches] SET name ='" + name + "', last_name='" + lastName + "' WHERE ID_user =" + Session["ID_user"];

            SqlCommand cmdEditCoach = new SqlCommand(updateCoach, connection);
            cmdEditCoach.ExecuteReader();

            connection.Close();
        }
    }
}