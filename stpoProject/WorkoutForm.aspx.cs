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
            WorkoutController workoutController = (WorkoutController)Session["workoutController"];
            ExerciseListController exerciseListController = (ExerciseListController)Session["exerciseListController"];
            ExerciseController exerciseController = (ExerciseController)Session["exerciseController"];
            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);
            string dateCurrWorkout = Session["workoutDate"].ToString();
            Workout currWorkout = workoutController.getWorkoutByDate(dateCurrWorkout, currUserID);

            Lbl_workout.Text += currWorkout.date();

            List<ExerciseList> currExerciseList = exerciseListController.getExerciseListInWorkoutByWorkoutID(currWorkout.ID());

            foreach (ExerciseList exerList in currExerciseList)
            {
                Label lbl_exercise = new Label();
                Exercise exercise = exerciseController.getExerciseByID(exerList.ID_exercise());
                lbl_exercise.Text = exercise.name() + " " + exerList.sets().ToString() + " serii " + exerList.reps().ToString() + " powtórzeń";
                Panel_workout.Controls.Add(lbl_exercise);
                Panel_workout.Controls.Add(new LiteralControl("<br />"));
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
            List<Control> controlsList = new List<Control>();
            Session["controlsList"] = controlsList;
            Response.Redirect("WorkoutEditForm.aspx");
        }
    }
}