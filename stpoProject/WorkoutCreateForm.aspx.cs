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
        static bool isCommit = false;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Panel_workout.Controls.Clear();

            List<string> keysDrop = Request.Form.AllKeys.Where(key => key.Contains("drop")).ToList();
            List<string> keySets = Request.Form.AllKeys.Where(key => key.Contains("txtSets")).ToList();
            List<string> keyReps = Request.Form.AllKeys.Where(key => key.Contains("txtReps")).ToList();

            int i = 1;
            foreach (string key in keysDrop)
            {
                this.CreateDropDown("drop" + i);
                this.CreateSets("txtSets" + i);
                this.CreateReps("txtReps" + i);
                i++;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
           if (isCommit)
           {
                Btn_edit.Enabled = true;
           }
            else
            {
                Btn_edit.Enabled = false;
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

        protected void Btn_addField_Click(object sender, EventArgs e)
        {
            isCommit = false;

            int index_Drp = Panel_workout.Controls.OfType<DropDownList>().ToList().Count + 1;
            this.CreateDropDown("drop" + index_Drp);

            int index = Panel_workout.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateSets("txtSets" + index);

            index = Panel_workout.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateReps("txtReps" + index);
        }

        private void CreateDropDown(string id)
        {
            DropDownList drp = new DropDownList();
            drp.ID = id;

            drp.DataSource = SqlDataSource1;
            drp.DataTextField = "exerciseName";
            drp.DataValueField = "ID";

            drp.DataBind();

            Panel_workout.Controls.Add(drp);

            Panel_workout.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
        }
        private void CreateSets(string id)
        {
            TextBox txt = new TextBox();
            txt.ID = id;
            txt.Width = 50;

            txt.DataBind();

            Panel_workout.Controls.Add(txt);

            Panel_workout.Controls.Add(new LiteralControl("&nbsp; serii &nbsp;"));
        }
        private void CreateReps(string id)
        {
            TextBox txt = new TextBox();
            txt.ID = id;
            txt.Width = 50;

            txt.DataBind();

            Panel_workout.Controls.Add(txt);

            Panel_workout.Controls.Add(new LiteralControl("&nbsp; powtórzeń"));
            Panel_workout.Controls.Add(new LiteralControl("<br />"));
            Panel_workout.Controls.Add(new LiteralControl("<br />"));
        }
        
        protected void Btn_edit_Click(object sender, EventArgs e)
        {
            bool dataIsGood = true;

            List<int> exercises = new List<int>();
            List<int> sets = new List<int>();
            List<int> reps = new List<int>();

            int setsOrReps = 1;

            foreach (TextBox textBox in Panel_workout.Controls.OfType<TextBox>())
            {
                textBox.DataBind();
                if(setsOrReps %2 != 0)
                {
                    if(int.TryParse(textBox.Text, out _))
                    {
                        sets.Add(Int16.Parse(textBox.Text));
                    }
                    else
                    {
                        dataIsGood = false;
                        isCommit = false;
                        Lbl_helper.Text = "Serie oraz powtórzenia muszą być liczbą całkowitą";
                    }
                }
                else
                {
                    if (int.TryParse(textBox.Text, out _))
                    {
                        reps.Add(Int16.Parse(textBox.Text));
                    }
                    else
                    {
                        dataIsGood = false;
                        isCommit = false;
                        Lbl_helper.Text = "Serie oraz powtórzenia muszą być liczbą całkowitą";
                    }
                }
                setsOrReps++;
            }

            int c = 0;

            foreach (DropDownList drop in Panel_workout.Controls.OfType<DropDownList>())
            {
                exercises.Add(Int16.Parse(drop.SelectedValue));
                c++;
            }


            ExerciseListController exerciseListController = (ExerciseListController)Session["exerciseListController"];
            WorkoutController workoutController = (WorkoutController)Session["workoutController"];

            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());
            int IDownerPage = Int16.Parse(Session["ID_user"].ToString());

            DateTime selectedDate = workout_calendar.SelectedDate; //10.11.2021 00:00:00
            string convertedDate = selectedDate.ToString("yyyy-MM-dd");
            //Lbl_helper.Text += convertedDate; 

            if (dataIsGood)
            {
                int newWorkoutID = workoutController.addWorkoutReturnID(IDownerPage, convertedDate);

                exerciseListController.addExerciseListToDB(newWorkoutID, exercises, sets, reps);

                workoutController.getWorkoutFromDatabase();
                Session["workoutController"] = workoutController;

                Response.Redirect("WorkoutListForm.aspx");
            }
        }

        protected void Btn_commit_Click(object sender, EventArgs e)
        {
            isCommit=true;
        }

        protected void Btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkoutListForm.aspx");
        }
    }
}