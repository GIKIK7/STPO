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
    public partial class WorkoutForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientController clientController = (ClientController)Session["clientController"];
            CoachController coachController = (CoachController)Session["coachController"];
            WorkoutController workoutController = (WorkoutController)Session["workoutController"];
            ExerciseListController exerciseListController = (ExerciseListController)Session["exerciseListController"];
            ExerciseController exerciseController = (ExerciseController)Session["exerciseController"];
            UserController userController = (UserController)Session["userController"];

            int pageOwnerID = Int16.Parse(Session["ID_user"].ToString());
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);

            string dateCurrWorkout = Session["workoutDate"].ToString();
            Workout currWorkout = workoutController.getWorkoutByDate(dateCurrWorkout, pageOwnerID);

            if (!currUser.isTrener())
            {
                Btn_editWorkout.Enabled = false;
                Btn_editWorkout.Visible = false;
            }
            else
            {
                int IDpageOwner = Int16.Parse(Session["ID_user"].ToString());

                Client pageOwnerClient = clientController.getClientByIDuser(IDpageOwner);
                Coach currCoach = coachController.getCoachByIDuser(currUserID);

                User assignCoachUser = userController.getUserbyID(pageOwnerClient.ID_assign_coach());

                if (pageOwnerClient.ID_assign_coach() != currCoach.ID_user())
                {
                    Btn_editWorkout.Enabled = false;
                    Btn_editWorkout.Text = "Klient nie jest twoim podopiecznym";
                }
            }

            Lbl_workout.Text += currWorkout.date();

            List<ExerciseList> currExerciseList = exerciseListController.getExerciseListInWorkoutByWorkoutID(currWorkout.ID());

            foreach (ExerciseList exerList in currExerciseList)
            {
                Label lbl_exerciseName = new Label();
                Label lbl_exerciseSets = new Label();
                Label lbl_exerciseReps = new Label();

                Exercise exercise = exerciseController.getExerciseByID(exerList.ID_exercise());
                lbl_exerciseName.Text = exercise.name();
                lbl_exerciseName.Width = 200;

                lbl_exerciseSets.Text = exerList.sets().ToString() + " serii ";
                lbl_exerciseSets.Width = 100;

                lbl_exerciseReps.Text = exerList.reps().ToString() + " powtórzeń";
                lbl_exerciseReps.Width = 150;


                Panel_workout.Controls.Add(lbl_exerciseName);
                Panel_workout.Controls.Add(lbl_exerciseSets);
                Panel_workout.Controls.Add(lbl_exerciseReps);
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

        protected void Btn_editWorkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkoutEditForm.aspx");
        }
    }
}