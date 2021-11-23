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
            CoachController coachController = (CoachController)Session["coachController"];
            
            CategoryControllers categoryController = (CategoryControllers)Session["categoryController"];

            coachController.getCoachList();

            Session["coachController"] = coachController;

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
    }
}