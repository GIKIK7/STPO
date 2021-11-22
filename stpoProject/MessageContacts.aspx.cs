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
        int secondUserInConversation;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = (UserController)Session["userController"];

            MessageController messageController = (MessageController)Session["messageController"];

            int currUser = Int16.Parse(Session["ID_current_user"].ToString());
            secondUserInConversation = Int16.Parse(Session["ID_user"].ToString());

            List<Message> messages = messageController.getMessageList();

            ConversationController conversationController = new ConversationController();

            conversationController.createConversations(currUser, messages);

            //DO POPRAWY
            //LINKED BUTTON MUSI PRZYJMOWAC ID Z TEKSTU (ALBO INACZEJ)
            LinkButton help = new LinkButton();
            help.Text += conversationController.printConversations();
            help.Click += new EventHandler(linkClicked);
            Panel_conversation.Controls.Add(help);
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
            //ID user = second user
            //int secondUserInConversation = Int16.Parse(Session["ID_user"].ToString());
            //Session["ID_user"] = secondUserInConversation;


            Session["ID_user"] = 16;
            Response.Redirect("MessagesForm.aspx");
        }
    }
}