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
    public partial class WorkoutEditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            string workoutDate = Session["workoutDate"].ToString();
            Lbl_editWorkout.Text = "Edycja treningu na: " + workoutDate;
        }

        protected void Btn_goBack_Click(object sender, EventArgs e)
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

        protected void Btn_addField_Click(object sender, EventArgs e)
        {
            List<Control> controlsList = (List<Control>)Session["controlsList"];

            DropDownList dropList = new DropDownList();
            dropList.DataSource = SqlDataSource1;
            dropList.DataTextField = "exerciseName";
            dropList.DataValueField = "ID";

            dropList.DataBind();

            controlsList.Add(dropList);

            controlsList.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

            TextBox sets = new TextBox();
            sets.Width = 50;

            controlsList.Add(sets);
            controlsList.Add(new LiteralControl("&nbsp; serii &nbsp;"));

            TextBox reps = new TextBox();
            reps.Width = 50;

            controlsList.Add(reps);
            controlsList.Add(new LiteralControl("&nbsp; powtórzeń"));

            Panel_workout.Controls.Add(new LiteralControl("<br />"));

            
            controlsList.Add(new LiteralControl("<br />"));
            controlsList.Add(new LiteralControl("<br />"));

            foreach (Control ctrl in controlsList)
            {
                Panel_workout.Controls.Add(ctrl);
            }
            //DODAĆ UPDATOWANIE I MOZE ZEBY DANE BYLY JUZ WYPELIONE!
        }
    }
}