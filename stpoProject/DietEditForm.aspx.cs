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
    public partial class DietEditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DietController dietController = (DietController)Session["dietController"];
            MealListController mealListController = (MealListController)Session["mealListController"];
            MealController mealController = (MealController)Session["mealController"];
            UserController userController = (UserController)Session["userController"];

            string date = Session["dietDate"].ToString();
            int IDdietOwnerUser = Int16.Parse(Session["ID_user"].ToString());
            User currUser = userController.getUserbyID(IDdietOwnerUser);

            Diet currDiet = dietController.getDietByDate(date, IDdietOwnerUser);

            Lbl_diet.Text = "Edytuj diete na " + currDiet.date();

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

        protected void Btb_addDiet_Click(object sender, EventArgs e)
        {
            DietController dietController = (DietController)Session["dietController"];
            MealListController mealListController = (MealListController)Session["mealListController"];
            MealController mealController = (MealController)Session["mealController"];
            UserController userController = (UserController)Session["userController"];

            string date = Session["dietDate"].ToString();
            int IDdietOwnerUser = Int16.Parse(Session["ID_user"].ToString());
            User currUser = userController.getUserbyID(IDdietOwnerUser);

            Diet currDiet = dietController.getDietByDate(date, IDdietOwnerUser);

            MealList currMealList = mealListController.getMealListByID(currDiet.ID());

            String breakfast = TxtBox_breakfast.Text.Trim();
            String dinner = TxtBox_dinner.Text.Trim();
            String supper = TxtBox_supper.Text.Trim();


            if (breakfast.Length == 0 || dinner.Length == 0 || supper.Length == 0)
            {
                Lbl_helper.Text = "Wszystkie pola sa wymagane!";
            }
            else if (!int.TryParse(breakfast, out _) || !int.TryParse(dinner, out _) || !int.TryParse(supper, out _))
            {
                Lbl_helper.Text = "ilość musi być jako liczba całkowita!";
            }
            else
            {
                mealListController.updateMealList(currDiet.ID_mealList(), Int16.Parse(DropList_breakfast.SelectedValue), Int16.Parse(TxtBox_breakfast.Text),
                Int16.Parse(DropList_dinner.SelectedValue), Int16.Parse(TxtBox_dinner.Text), Int16.Parse(DropList_supper.SelectedValue), Int16.Parse(TxtBox_supper.Text));

                mealListController.getmealListListFromDatabase();
                Session["mealListController"] = mealListController;

                Response.Redirect("DietForm.aspx");
            }
        }
    }
}