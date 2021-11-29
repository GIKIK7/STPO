using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace stpoProject
{
    using controllers;
    using datasets;

    public partial class TrenerDetailsForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = (UserController)Session["userController"];

            CoachController coachController = (CoachController)Session["coachController"];
            
            CategoryControllers categoryController = (CategoryControllers)Session["categoryController"];

            CommentController commentController = (CommentController)Session["commentController"];

            RatingController ratingController = (RatingController)Session["ratingController"];

            ClientController clientController = (ClientController)Session["clientController"];

            coachController.getCoachList();

            Session["coachController"] = coachController;

            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());
            int IDownerPage = Int16.Parse(Session["ID_user"].ToString());

            User currUser = userController.getUserbyID(IDcurrUser);

            Coach coachOwnerPage = coachController.getCoachByIDuser(Int16.Parse(Session["ID_user"].ToString()));

            if (coachOwnerPage.workoutPrice() > 0)
            {
                Lbl_actualWorkoutPrice.Text = coachOwnerPage.workoutPrice().ToString();
            }
            else 
            {
                Lbl_actualWorkoutPrice.Text = "brak";
            }

            if (coachOwnerPage.dietPrice() > 0)
            {
                Lbl_actualDietPrice.Text = coachOwnerPage.dietPrice().ToString();
            }
            else
            {
                Lbl_actualDietPrice.Text = "brak";
            }


            if (Session["ID_current_user"].ToString() == Session["ID_user"].ToString())
            {
                Btn_goToYourProfile.Enabled = false;
                Btn_goToYourProfile.Visible = false;
                Btn_goToEditCoachProfile.Enabled = true;
                Btn_dealStart.Enabled = false; 
                Btn_dealStart.Visible = false;
                TxtBox_com.Enabled = false;
                TxtBox_com.Visible = false;
                Btn_writeComm.Enabled = false;
                Btn_writeComm.Visible = false;
                Btn_rateCoach.Enabled = false;
                Btn_rateCoach.Visible = false;

                DropList_ratings.Enabled = false;
                DropList_ratings.Visible = false;
            }
            else
            {
                TxtBox_dietPrice.Enabled = false;
                TxtBox_dietPrice.Visible = false;

                TxtBox_workoutPrice.Enabled = false;
                TxtBox_workoutPrice.Visible = false;

                Btn_updateDietPrice.Enabled = false;
                Btn_updateDietPrice.Visible = false;

                Btn_updateWorkoutPrice.Enabled = false;
                Btn_updateWorkoutPrice.Visible = false;

                Btn_wyloguj.Enabled = false;
                Btn_wyloguj.Visible = false;
                Btn_goToEditCoachProfile.Enabled = false;
                Btn_chat.Text = "Przejdz do rozmowy";

                if (ratingController.youVoted(IDcurrUser, IDownerPage))
                {
                    Btn_rateCoach.Text = "Zmień swoją ocene";
                }
            }

            if (Int16.Parse(Session["ID_user"].ToString()) == -1)
            {
                Response.Redirect("LogInForm.aspx");
            }

            if (currUser.isTrener())
            {
                Btn_dealStart.Enabled = false;
            }
            else
            {
                Btn_searchClients.Enabled = false;
                Btn_searchClients.Visible = false;

                Client currClient = clientController.getClientByIDuser(currUser.ID());

                if(currClient.ID_assign_coach() != 0)
                {
                    Btn_dealStart.Enabled = false;
                    Btn_dealStart.Text = "Posiadasz juz trenera";
                }
            }

            Lbl_Name.Text = coachOwnerPage.name();
            Lbl_lastName.Text = coachOwnerPage.lastName();
            LbL_Category.Text = categoryController.getNameByID(coachOwnerPage.ID_category());


            List<Comment> comments = commentController.getCommentsOfCoach(IDownerPage);

            int i = 0;

            foreach (Comment com in comments)
            {
                User comUser = userController.getUserbyID(com.ID_client());
                Client comClient = clientController.getClientByIDuser(comUser.ID());
                
                Label commentFromWhoLbl = new Label() {
                    ID = "LblCommentOwner" + i.ToString()
                };

                commentFromWhoLbl.Text = comClient.name() + " " + comClient.lastName() + " (" + comUser.login() + ")";
                commentFromWhoLbl.Height = 20;

                Button btmCom = new Button()
                {
                    ID = "BtnComment" + i.ToString()
                };

                btmCom.Text = "x";
                btmCom.Font.Size = 10;

                btmCom.Click += DeleteComment;

                Label commentContent = new Label()
                {
                    ID = "Lblcontent" + i.ToString()
                };

                commentContent.Text = com.content();
                commentContent.Height = 40;


                if (Session["ID_current_user"].ToString() != Session["ID_user"].ToString())
                {
                    btmCom.Enabled = false;
                    btmCom.Visible = false;
                }

                i++;

                Panel_comments.Controls.Add(commentFromWhoLbl);
                Panel_comments.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                Panel_comments.Controls.Add(btmCom);
                Panel_comments.Controls.Add(new LiteralControl("<br />"));
                Panel_comments.Controls.Add(commentContent);

                Panel_comments.Controls.Add(new LiteralControl("<br >"));
                //Panel_comments.Controls.Add(new LiteralControl("<hr>"));
            }
            if(ratingController.getAverageRating(IDownerPage) < 1)
            {
                Lbl_rate.Text = "nie masz jeszcze żadnych ocen";
            }
            else
            {
                string avr = Math.Round(ratingController.getAverageRating(IDownerPage), 2).ToString();
                Lbl_rate.Text = "Średnia ocena trenera to: " + avr;
            }
        }

        protected void Btn_wyloguj_Click(object sender, EventArgs e)
        {
            Session["ID_current_user"] = -1;
            Response.Redirect("LogInForm.aspx");
        }

        protected void Btn_goToEditCoachProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoachEditForm.aspx");
        }

        protected void Btn_chat_Click(object sender, EventArgs e)
        {
            int ID_page_owner = Int16.Parse(Session["ID_user"].ToString());

            if (Btn_chat.Text == "Przejdz do rozmowy")
            {
                Session["ID_user_conversation"] = ID_page_owner;
                Response.Redirect("MessagesForm.aspx");
            }
            else
            {
                Session["ID_user_conversation"] = ID_page_owner;
                Response.Redirect("MessageContacts.aspx");
            }
        }

        protected void Btn_dealStart_Click(object sender, EventArgs e)
        {
            ClientController clientController = (ClientController)Session["clientController"];
            CoachController coachController = (CoachController)Session["coachController"];
            UserController userController = (UserController)Session["userController"];

            int IDcurrClient = Int16.Parse(Session["ID_current_user"].ToString());
            Client currClient = clientController.getClientByIDuser(IDcurrClient);
            
            Coach coachOwnerPage = coachController.getCoachByIDuser(Int16.Parse(Session["ID_user"].ToString()));

            if (currClient.ID_assign_coach() == 0)
            {
                currClient.setID_assign_coach(coachOwnerPage.ID_user());
                clientController.setCoachToClient(currClient, coachOwnerPage.ID_user());

                Session["ID_user"] = currClient.ID_user();
                Response.Redirect("ClientDetailsForm.aspx");
            }
        }

        protected void Btn_searchClients_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientSearchForm.aspx");
        }

        protected void Btn_goToYourProfile_Click(object sender, EventArgs e)
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

        protected void DeleteComment(object sender, EventArgs e)
        {
            ClientController clientController = (ClientController)Session["clientController"];
            CoachController coachController = (CoachController)Session["coachController"];
            UserController userController = (UserController)Session["userController"];
            CommentController commentController = (CommentController)Session["commentController"];

            String btnID = (sender as Button).ID;

            string[] separatorBtn = { "BtnComment" };
            string[] separatorLblComOwner = { "LblCommentOwner" };
            string[] separatorLblContent = { "Lblcontent" };

            string[] btnIDstr = btnID.Split(separatorBtn, System.StringSplitOptions.RemoveEmptyEntries);

            int IDbtnInt = Int16.Parse(btnIDstr[0]);

            int ID_userClient_toDelete = -1;
            int ID_userCoach_toDelete = Int16.Parse(Session["ID_current_user"].ToString());
            string content_toDelete = "";

            foreach (Label label in Panel_comments.Controls.OfType<Label>().ToList())
            {
                string lblIDstring = label.ID;

                if (lblIDstring.Contains(separatorLblComOwner[0]))
                {
                    string[] cuttedID = lblIDstring.Split(separatorLblComOwner, System.StringSplitOptions.RemoveEmptyEntries);
                    int lblIDint = Int16.Parse(cuttedID[0]);
                    if(lblIDint == IDbtnInt)
                    {
                        Panel_comments.Controls.Remove(label);

                        string textLabel = label.Text;
                        int Pos1 = textLabel.IndexOf("(") + 1;
                        int Pos2 = textLabel.IndexOf(")");
                        string loginUser= textLabel.Substring(Pos1, Pos2 - Pos1);
                        ID_userClient_toDelete = userController.getIDbyLogin(loginUser);
                    }
                }
                else if(lblIDstring.Contains(separatorLblContent[0]))
                {
                    string[] cuttedID = lblIDstring.Split(separatorLblContent, System.StringSplitOptions.RemoveEmptyEntries);
                    int lblIDint = Int16.Parse(cuttedID[0]);
                    if (lblIDint == IDbtnInt)
                    {

                        Panel_comments.Controls.Remove(label);


                        content_toDelete = label.Text;

                    }
                } 
            }

            Panel_comments.Controls.Remove(sender as Button);

            commentController.deleteComment(ID_userClient_toDelete, ID_userCoach_toDelete, content_toDelete);

            commentController.getCommentsFromDatabase();
            Session["commentController"] = commentController;
            //Lbl_helper.Text = btnID;
        }

        protected void Btn_writeComm_Click(object sender, EventArgs e)
        {
            CommentController commentController = (CommentController)Session["commentController"];

            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());
            int IDownerPage = Int16.Parse(Session["ID_user"].ToString());
            string content = TxtBox_com.Text;

            commentController.addComment(IDcurrUser, IDownerPage, content);
            commentController.getCommentsFromDatabase();
            Session["commentController"] = commentController;

            Response.Redirect("CoachDetailsForm.aspx");
        }

        protected void Btn_rateCoach_Click(object sender, EventArgs e)
        {
            RatingController ratingController = (RatingController)Session["ratingController"];

            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());
            int IDpageOwner = Int16.Parse(Session["ID_user"].ToString());
            int ratingVal = Int16.Parse(DropList_ratings.SelectedValue);

            //ratingController.addRating(IDcurrUser, IDpageOwner, ratingVal);

            if (!ratingController.youVoted(IDcurrUser, IDpageOwner))
            {
                ratingController.addRating(IDcurrUser, IDpageOwner, ratingVal);
            }
            else
            {
                ratingController.updateYourValue(IDcurrUser, IDpageOwner, ratingVal);
            }

            ratingController.getRatingsFromDatabase();
            Session["ratingController"] = ratingController;

            Response.Redirect("CoachDetailsForm.aspx");
        }

        protected void Btn_updateDietPrice_Click(object sender, EventArgs e)
        {
            CoachController coachController = (CoachController)Session["coachController"];

            TxtBox_dietPrice.DataBind();

            int value = Int16.Parse(TxtBox_dietPrice.Text);
            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());

            coachController.updatePrice(true, value, IDcurrUser);

            coachController.getCoachListFromDatabase();
            Session["coachController"] = coachController;

            Response.Redirect("CoachDetailsForm.aspx");
        }

        protected void Btn_updateWorkoutPrice_Click(object sender, EventArgs e)
        {
            CoachController coachController = (CoachController)Session["coachController"];

            TxtBox_workoutPrice.DataBind();

            int value = Int16.Parse(TxtBox_workoutPrice.Text);
            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());

            coachController.updatePrice(false, value, IDcurrUser);

            coachController.getCoachListFromDatabase();
            Session["coachController"] = coachController;

            Response.Redirect("CoachDetailsForm.aspx");
        }
    }
}