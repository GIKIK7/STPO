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
    public partial class DietCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btb_addDiet_Click(object sender, EventArgs e)
        {
            DietController dietController = (DietController)Session["dietController"];
            MealListController mealListController = (MealListController)Session["mealListController"];
            MealController mealController = (MealController)Session["mealController"];
            UserController userController = (UserController)Session["userController"];

            int IDdietOwnerUser = Int16.Parse(Session["ID_user"].ToString());
            User currUser = userController.getUserbyID(IDdietOwnerUser);

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
                int newMealListID = mealListController.addMealListReturnID(Int16.Parse(DropList_breakfast.SelectedValue), Int16.Parse(TxtBox_breakfast.Text),
                Int16.Parse(DropList_dinner.SelectedValue), Int16.Parse(TxtBox_dinner.Text), Int16.Parse(DropList_supper.SelectedValue), Int16.Parse(TxtBox_supper.Text));

                mealListController.getmealListListFromDatabase();

                DateTime selectedDate = calendar_diet.SelectedDate; //10.11.2021 00:00:00
                string convertedDate = selectedDate.ToString("yyyy-MM-dd");

                dietController.addDiet(currUser.ID(), newMealListID, convertedDate);
                Session["mealListController"] = mealListController;

                Response.Redirect("DietListForm.aspx");
            }
        }
    }
}