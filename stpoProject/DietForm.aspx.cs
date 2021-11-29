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
            ClientController clientController = (ClientController)Session["clientController"];
            CoachController coachController = (CoachController)Session["coachController"];
            DietController dietController = (DietController)Session["dietController"];
            MealListController mealListController = (MealListController)Session["mealListController"];
            MealController mealController = (MealController)Session["mealController"];
            UserController userController = (UserController)Session["userController"];

            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            string date = Session["dietDate"].ToString();
            int IDdietOwnerUser = Int16.Parse(Session["ID_user"].ToString());

            User currUser = userController.getUserbyID(currUserID);

            Diet currDiet = dietController.getDietByDate(date, IDdietOwnerUser);

            MealList currMealList = mealListController.getMealListByID(currDiet.ID_mealList());

            Lbl_diet.Text += currDiet.date();

            Lbl_breakfastMealName.Text = mealController.getNameByID(currMealList.IDmealBrakfast()) + " ";
            Lbl_amountBreakfast.Text = currMealList.AmountBreakfast().ToString() +  "g";

            Lbl_dinnerName.Text = mealController.getNameByID(currMealList.IDmealDinner()) + " ";
            Lbl_amountDinner.Text = currMealList.AmountDinner().ToString() + " g";

            Lbl_supperMealName.Text = mealController.getNameByID(currMealList.IDmealSupper()) + " ";
            Lbl_amountSupper.Text = currMealList.AmountSupper().ToString() + " g";

            if (!currUser.isTrener())
            {
                Btn_goEditDiet.Enabled = false;
                Btn_goEditDiet.Visible = false;
            }
            else
            {
                int IDpageOwner = Int16.Parse(Session["ID_user"].ToString());

                Client pageOwnerClient = clientController.getClientByIDuser(IDpageOwner);
                Coach currCoach = coachController.getCoachByIDuser(currUserID);

                User assignCoachUser = userController.getUserbyID(pageOwnerClient.ID_assign_coach());

                if (pageOwnerClient.ID_assign_coach() != currUser.ID())
                {
                    Btn_goEditDiet.Enabled = false;
                    Btn_goEditDiet.Text = "Klient nie jest twoim podopiecznym";
                }
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

        protected void Btn_goEditDiet_Click(object sender, EventArgs e)
        {
            Response.Redirect("DietEditForm.aspx");
        }
    }
}