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
    public partial class DietForm : System.Web.UI.Page
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

            MealList currMealList = mealListController.getMealListByID(currDiet.ID());

            Lbl_diet.Text += currDiet.date();

            Lbl_breakfastMealName.Text = mealController.getNameByID(currMealList.IDmealBrakfast()) + " ";
            Lbl_amountBreakfast.Text = currMealList.AmountBreakfast().ToString() +  "g";

            Lbl_dinnerName.Text = mealController.getNameByID(currMealList.IDmealDinner()) + " ";
            Lbl_amountDinner.Text = currMealList.AmountDinner().ToString() + " g";

            Lbl_supperMealName.Text = mealController.getNameByID(currMealList.IDmealSupper()) + " ";
            Lbl_amountSupper.Text = currMealList.AmountSupper().ToString() + " g";
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
    }
}