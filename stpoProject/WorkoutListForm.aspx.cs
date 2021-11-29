using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace stpoProject
{
    using controllers;
    using datasets;
    public partial class WorkoutListForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientController clientController = (ClientController)Session["clientController"];
            CoachController coachController = (CoachController)Session["coachController"];
            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            int pageOwnerID = Int16.Parse(Session["ID_user"].ToString());

            WorkoutController workoutController = (WorkoutController)Session["workoutController"];

            User currUser = userController.getUserbyID(currUserID);

            if (!currUser.isTrener())
            {
                Btn_createWorkout.Enabled = false;
                Btn_createWorkout.Visible = false;
            }
            else
            {
                int IDpageOwner = Int16.Parse(Session["ID_user"].ToString());

                Client pageOwnerClient = clientController.getClientByIDuser(IDpageOwner);
                Coach currCoach = coachController.getCoachByIDuser(currUserID);

                User assignCoachUser = userController.getUserbyID(pageOwnerClient.ID_assign_coach());

                if (pageOwnerClient.ID_assign_coach() != currCoach.ID_user())
                {
                    Btn_createWorkout.Enabled = false;
                    Btn_createWorkout.Text = "Klient nie jest twoim podopiecznym";
                }
            }

            workoutController.getWorkoutFromDatabase();

            List<Workout> workouts = workoutController.getWorkoutsOfUser(pageOwnerID);

            foreach (Workout workout in workouts)
            {
                LinkButton LBworkout = new LinkButton();
                Label lbl = new Label();
                LBworkout.Text += workout.date();
                lbl.Text = "trening na dzień: ";
                LBworkout.Click += new EventHandler(LnkBtn_Click);
                Panel_workout.Controls.Add(LBworkout);
                Panel_workout.Controls.Add(new LiteralControl("<br />"));
            }

            if (currUser.isTrener())
            {
                Coach currCoach = coachController.getCoachByIDuser(currUserID);

                Lbl_lastName.Text = currCoach.name() + " " + currCoach.lastName();
            }
            else
            {
                Client currClient = clientController.getClientByIDuser(currUserID);

                Lbl_lastName.Text = currClient.name() + " " + currClient.lastName();
            }

        }

        protected void LnkBtn_Click(object sender, EventArgs e)
        {
            String s = (sender as LinkButton).Text;
            string[] separator = { "trening na dzień: " };
            string[] cuttedString = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            WorkoutController workoutController = (WorkoutController)Session["workoutController"];

            Session["workoutDate"] = cuttedString[0];

            Response.Redirect("WorkoutForm.aspx");

        }

        protected void Btn_goBackToYourProfile_Click(object sender, EventArgs e)
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

        protected void Btn_createWorkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkoutCreateForm.aspx");
        }
    }
}