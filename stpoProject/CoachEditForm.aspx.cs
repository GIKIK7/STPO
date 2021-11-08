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

        



        protected void Page_Load(object sender, EventArgs e)
        {
            // default id
            Session["ID_user"] = 16;

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            submitFunction(TxtBox_Name.Text, TxtBox_lastName.Text);
            Response.Redirect("CoachDetailsForm.aspx");
        }

        void submitFunction(String name, String lastName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "stpo.database.windows.net",
                UserID = "GIKIK",
                Password = "AdminHaslo137",
                InitialCatalog = "DBstpo"
            };

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String updateCoach = "UPDATE [dbo].[coaches] SET name ='" + name + "', last_name='" + lastName + "' WHERE ID_user =" + Session["ID_user"];

            SqlCommand cmdEditCoach = new SqlCommand(updateCoach, connection);
            cmdEditCoach.ExecuteReader();

            connection.Close();
        }
    }
}