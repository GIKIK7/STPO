using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace stpoProject
{

    using datasets;
    using controllers;

    public partial class ClientEditForm : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = Int16.Parse(Session["ID_current_user"].ToString());

            if (userID == -1)
            {
                Response.Redirect("LogInForm.aspx");
            }

            ClientController clientController = (ClientController)Session["clientController"];

            Client clientOwnerPage = clientController.getClientByIDuser(userID);

            Lbl_Client.Text = "Edycja Klienta: " + clientOwnerPage.name() + " " + clientOwnerPage.lastName();

            Lbl_lastName.Text = clientOwnerPage.name() + " " + clientOwnerPage.lastName();

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
            ClientController clientController = (ClientController)Session["clientController"];

            int userID = Int16.Parse(Session["ID_user"].ToString());

            clientController.updateClient(name, lastName, userID);
        }
    }
}