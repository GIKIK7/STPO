﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace stpoProject
{
    public partial class ClientEditForm : System.Web.UI.Page
    {
        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };
        

        protected void Page_Load(object sender, EventArgs e)
        {
            // default id
            Session["ID_user"] = 10;

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String sql = "SELECT name, last_name FROM [dbo].[clients] WHERE ID_user='" + Session["ID_user"] + "'";

            SqlCommand cmdGetFullName = new SqlCommand(sql, connection);
            SqlDataReader readerGetFullName = cmdGetFullName.ExecuteReader();

            while (readerGetFullName.Read())
            {
                Lbl_Client.Text = "Edycja Klienta: " + readerGetFullName.GetValue(0).ToString() + " " + readerGetFullName.GetValue(1).ToString();
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
                Response.Redirect("ClientDetailsForm.aspx");
            }
        }

        void submitFunction(String name, String lastName)
        {
            
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String updateClient = "UPDATE [dbo].[clients] SET name ='" + name + "', last_name='" + lastName + "' WHERE ID_user =" + Session["ID_user"];

            SqlCommand cmdEditClient = new SqlCommand(updateClient, connection);
            cmdEditClient.ExecuteReader();

            connection.Close();
        }
    }
}