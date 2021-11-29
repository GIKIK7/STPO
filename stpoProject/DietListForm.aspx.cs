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
    public partial class DietListForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientController clientController = (ClientController)Session["clientController"];
            CoachController coachController = (CoachController)Session["coachController"];
            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            int IDpageOwner = Int16.Parse(Session["ID_user"].ToString());

            DietController dietController = (DietController)Session["dietController"];
            dietController.getDietsFromDatabase();
            Session["dietController"] = dietController;

            User currUser = userController.getUserbyID(currUserID); 
            User pageOwner = userController.getUserbyID(IDpageOwner);

            dietController.getDietsFromDatabase();

            List<Diet> diets = dietController.getDietsOfUser(IDpageOwner);

            foreach(Diet diet in diets)
            {
                LinkButton LBdiet = new LinkButton();
                Label lbl = new Label();
                LBdiet.Text += diet.date();
                lbl.Text = "lista posiłków na dzień: ";
                LBdiet.Click += new EventHandler(LnkBtn_Click);
                Panel_diet.Controls.Add(lbl);
                Panel_diet.Controls.Add(LBdiet);
                Panel_diet.Controls.Add(new LiteralControl("<br />"));
            }

            if (!currUser.isTrener())
            {
                Btn_createDiet.Enabled = false;
                Btn_createDiet.Visible = false;
            }
            else
            {
                Client pageOwnerClient = clientController.getClientByIDuser(IDpageOwner);
                Coach currCoach = coachController.getCoachByIDuser(currUserID);

                User assignCoachUser = userController.getUserbyID(pageOwnerClient.ID_assign_coach());

                if (pageOwnerClient.ID_assign_coach() != currUser.ID())
                {
                    Btn_createDiet.Enabled = false;
                    Btn_createDiet.Text = "Klient nie jest twoim podopiecznym";
                }
            }

        }

        protected void LnkBtn_Click(object sender, EventArgs e)
        {
            String s = (sender as LinkButton).Text;

            Session["dietDate"] = s;

            Response.Redirect("DietForm.aspx");

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

        protected void Btn_createDiet_Click(object sender, EventArgs e)
        {
            Response.Redirect("DietCreateForm.aspx");
        }
    }
}