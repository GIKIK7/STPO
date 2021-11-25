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
            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_user"].ToString());

            DietController dietController = (DietController)Session["dietController"];

            User currUser = userController.getUserbyID(currUserID); 

            dietController.getDietsFromDatabase();

            List<Diet> diets = dietController.getDietsOfUser(currUserID);

            foreach(Diet diet in diets)
            {
                LinkButton LBdiet = new LinkButton();
                Label lbl = new Label();
                LBdiet.Text += diet.date();
                lbl.Text = "lista posiłków na dzień: ";
                LBdiet.Click += new EventHandler(LnkBtn_Click);
                Panel_diet.Controls.Add(LBdiet);
                Panel_diet.Controls.Add(new LiteralControl("<br />"));
            }
        }

        protected void LnkBtn_Click(object sender, EventArgs e)
        {
            String s = (sender as LinkButton).Text;
            string[] separator = { "lista posiłków na dzień: " };
            string[] cuttedString = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            DietController dietController = (DietController)Session["dietController"];

            Session["dietDate"] = cuttedString[0];

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
    }
}