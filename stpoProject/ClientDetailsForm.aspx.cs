using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace stpoProject
{
    public partial class ClientDetailsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //default ID_user
            Session["ID_user"] = 10;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "stpo.database.windows.net";
            builder.UserID = "GIKIK";
            builder.Password = "AdminHaslo137";
            builder.InitialCatalog = "DBstpo";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String sql = "SELECT name, last_name FROM [dbo].[clients] WHERE ID_user='" + Session["ID_user"] + "'";

            SqlCommand cmdGetFullName = new SqlCommand(sql, connection);
            SqlDataReader readerGetFullName = cmdGetFullName.ExecuteReader();

            while (readerGetFullName.Read())
            {
                Lbl_Name.Text = readerGetFullName.GetValue(0).ToString();
                Lbl_lastName.Text = readerGetFullName.GetValue(1).ToString();
            }
            connection.Close();
        }

        protected void Btn_wyloguj_Click(object sender, EventArgs e)
        {
            Session["ID_user"] = -1;
            Response.Redirect("LogInForm.aspx");
        }
    }
}