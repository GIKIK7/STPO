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
            UserController userController = (UserController)Session["userController"];
            ClientController clientController = (ClientController)Session["clientController"];

            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());

            User currUser = userController.getUserbyID(IDcurrUser);

            clientController.getClientList();

            int userID = Int16.Parse(Session["ID_user"].ToString());

            Client clientOwnerPage = clientController.getClientByIDuser(userID);

            if(Session["ID_current_user"].ToString() != Session["ID_user"].ToString())
            {
                btn_goToEditClientProfile.Enabled = false;
                Btn_wyloguj.Enabled = false;
                Btn_wyloguj.Visible = false;
                Btn_Chat.Text = "Przejdz do rozmowy";
            }
            else
            {
                btn_goToEditClientProfile.Enabled = true;
            }

            if (Int16.Parse(Session["ID_current_user"].ToString()) == -1)
            {
                Response.Redirect("LogInForm.aspx");
            }

            if (currUser.isTrener())
            {
                Btn_searchCoaches.Enabled = false;
                Btn_searchCoaches.Visible = false;

                if(clientOwnerPage.ID_assign_coach() != currUser.ID())
                {
                    Btn_Diet.Enabled = false;
                    Btn_Diet.Text = "dieta- klient nie jest Twoim podopiecznym";
                }
            }

            Lbl_Name.Text = clientOwnerPage.name();
            Lbl_lastName.Text = clientOwnerPage.lastName();
            Lbl_assignCoach.Text = clientOwnerPage.ID_assign_coach().ToString();
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

        protected void Btn_Chat_Click(object sender, EventArgs e)
        {
            int ID_page_owner = Int16.Parse(Session["ID_user"].ToString());

            if (Btn_Chat.Text == "Przejdz do rozmowy")
            {
                Session["ID_user_conversation"] = ID_page_owner;
                Response.Redirect("MessagesForm.aspx");
            }
            else
            {
                Session["ID_user_conversation"] = ID_page_owner;
                Response.Redirect("MessageContacts.aspx");
            }
        }

        protected void Btn_searchCoaches_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoachSearchForm.aspx");
        }

        protected void Btn_makeDiet_Click(object sender, EventArgs e)
        {
            Response.Redirect("DietListForm.aspx");
        }

        protected void Btn_goToYourProfile_Click(object sender, EventArgs e)
        {
            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);

            Session["ID_user"] = currUserID;

            if (currUser.isTrener())
            {
                Response.Redirect("CoachDetailsForm.aspx");
            }
            else
            {
                Response.Redirect("ClientDetailsForm.aspx");
            }
        }
    }
}