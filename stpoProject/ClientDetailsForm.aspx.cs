using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace stpoProject
{
    using datasets;
    using controllers;
    public partial class ClientDetailsForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientController clientController = (ClientController)Session["clientController"];

            clientController.getClientList();

            Client clientOwnerPage = clientController.getClientByIDuser(Int16.Parse(Session["ID_User"].ToString()));

            if(Session["ID_current_user"].ToString() != Session["ID_user"].ToString())
            {
                btn_goToEditClientProfile.Enabled = false;
            }
            else
            {
                btn_goToEditClientProfile.Enabled = true;
            }

            if (Int16.Parse(Session["ID_user"].ToString()) == -1)
            {
                Response.Redirect("LogInForm.aspx");
            }

            Lbl_Name.Text = clientOwnerPage.name();
            Lbl_lastName.Text = clientOwnerPage.lastName();
        }

        protected void Btn_wyloguj_Click(object sender, EventArgs e)
        {
            Session["ID_user"] = -1;
            Response.Redirect("LogInForm.aspx");
        }

        protected void btn_goToEditClientProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientEditForm.aspx");
        }
    }
}