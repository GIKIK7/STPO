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
    public partial class MessageContacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = (UserController)Session["userController"];

            MessageController messageController = (MessageController)Session["messageController"];

            int IDcurrUser = Int16.Parse(Session["ID_current_user"].ToString());

            List<Message> messages = messageController.getMessageList();

            ConversationController conversationController = new ConversationController();

            conversationController.createConversations(IDcurrUser, messages);

            List<Conversation> conversations = conversationController.getConversationList();

            foreach (Conversation conversation in conversations) {
                LinkButton LinkBtn_conversation = new LinkButton();
                LinkBtn_conversation.Text += "konwersacja z ";

               if(IDcurrUser != conversation.IDfrom())
               {
                    LinkBtn_conversation.Text += userController.getLoginByID(conversation.IDfrom());
                }
               else
               {
                    LinkBtn_conversation.Text += userController.getLoginByID(conversation.IDto());
               }

                LinkBtn_conversation.Click += new EventHandler(linkClicked);
                Panel_conversation.Controls.Add(LinkBtn_conversation);
                Panel_conversation.Controls.Add(new LiteralControl("<br />"));
            }
            
        }

        protected void Btn_back_Click(object sender, EventArgs e)
        {
            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);

            if (currUser.isTrener())
            {
                Response.Redirect("CoachDetailsForm.aspx");
            }
            else
            {
                Response.Redirect("ClientDetailsForm.aspx");
            }
        }

        protected void linkClicked(object sender, EventArgs e)
        {
            String s = (sender as LinkButton).Text;
            string[] separator = { "konwersacja z " };
            string[] cuttedString = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            UserController userController = (UserController)Session["userController"];

            int IDuser = 0;

            if(cuttedString.Count() == 1)
            {
                IDuser = userController.geIDByLogin(cuttedString[0].ToString());
            }
            else
            {
                Lbl_helper.Text = "Error in ID parse from link button!";
            }

            Session["ID_user_conversation"] = IDuser;

            Response.Redirect("MessagesForm.aspx");


        }
    }
}