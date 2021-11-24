using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace stpoProject
{
    using controllers;
    using datasets;

    public partial class TrenerDetailsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = (UserController)Session["userController"];

            CoachController coachController = (CoachController)Session["coachController"];
            
            CategoryControllers categoryController = (CategoryControllers)Session["categoryController"];

            coachController.getCoachList();

            Session["coachController"] = coachController;

            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());

            User currUser = userController.getUserbyID(IDcurrUser);

            Coach coachOwnerPage = coachController.getCoachByIDuser(Int16.Parse(Session["ID_user"].ToString()));

            if (Session["ID_current_user"].ToString() == Session["ID_user"].ToString())
            {
                Btn_goToEditCoachProfile.Enabled = true;
            }
            else
            {
                Btn_goToEditCoachProfile.Enabled = false;
                Btn_chat.Text = "Przejdz do rozmowy";
            }

            if (Int16.Parse(Session["ID_user"].ToString()) == -1)
            {
                Response.Redirect("LogInForm.aspx");
            }

            if (currUser.isTrener())
            {
                Btn_dealStart.Enabled = false;
            }
            else
            {
                Btn_searchClients.Enabled = false;
                Btn_searchClients.Visible = false;

                ClientController clientController = (ClientController)Session["clientController"];
                Client currClient = clientController.getClientByIDuser(currUser.ID());

                if(currClient.ID_assign_coach() != 0)
                {
                    Btn_dealStart.Enabled = false;
                    Btn_dealStart.Text = "posaidasz juz trenera";
                }
            }

            Lbl_Name.Text = coachOwnerPage.name();
            Lbl_lastName.Text = coachOwnerPage.lastName();
            LbL_Category.Text = categoryController.getNameByID(coachOwnerPage.ID_category());
        }

        protected void Btn_wyloguj_Click(object sender, EventArgs e)
        {
            Session["ID_current_user"] = -1;
            Response.Redirect("LogInForm.aspx");
        }

        protected void Btn_goToEditCoachProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoachEditForm.aspx");
        }

        protected void Btn_chat_Click(object sender, EventArgs e)
        {
            int ID_page_owner = Int16.Parse(Session["ID_user"].ToString());

            if (Btn_chat.Text == "Przejdz do rozmowy")
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

        protected void Btn_dealStart_Click(object sender, EventArgs e)
        {
            ClientController clientController = (ClientController)Session["clientController"];
            CoachController coachController = (CoachController)Session["coachController"];
            UserController userController = (UserController)Session["userController"];

            int IDcurrClient = Int16.Parse(Session["ID_current_user"].ToString());
            Client currClient = clientController.getClientByIDuser(IDcurrClient);
            
            Coach coachOwnerPage = coachController.getCoachByIDuser(Int16.Parse(Session["ID_user"].ToString()));

            if (currClient.ID_assign_coach() == 0)
            {
                currClient.setID_assign_coach(coachOwnerPage.ID_user());
                clientController.setCoachToClient(currClient, coachOwnerPage.ID_user());

                Session["ID_user"] = currClient.ID_user();
                Response.Redirect("ClientDetailsForm.aspx");
            }
        }

        protected void Btn_searchClients_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientSearchForm.aspx");
        }
    }
}