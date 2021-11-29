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
    public partial class CoachEditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userID = Int16.Parse(Session["ID_user"].ToString());

            if (userID == -1)
            {
                Response.Redirect("LogInForm.aspx");
            }

            CoachController coachController = (CoachController)Session["coachController"];

            Coach currentCoach = coachController.getCoachByIDuser(userID);

            Lbl_Coach.Text = "Edycja Trenera: " + currentCoach.name() + " " + currentCoach.lastName();
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
            CategoryControllers categoryController = (CategoryControllers)Session["categoryController"];

            CoachController coachController = (CoachController)Session["coachController"];

            int userID = Int16.Parse(Session["ID_user"].ToString());

            int categoryID = Int16.Parse(DropList_category.Text);

            coachController.updateCoach(name, lastName, categoryID, userID);
        }
    }
}