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
    public partial class MessagesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            showConversation();
        }

        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            MessageController messageController = (MessageController)Session["messageController"];
            int currUser = Int16.Parse(Session["ID_current_user"].ToString());
            int secondUserInConversation = Int16.Parse(Session["ID_user"].ToString());

            messageController.addMessage(currUser, secondUserInConversation, TxtBox_content.Text);

            showConversation();

            TxtBox_content.Text = "";

        }

        protected void showConversation()
        {
            MessageController messageController = (MessageController)Session["messageController"];

            UserController userController = (UserController)Session["userController"];

            int currUser = Int16.Parse(Session["ID_current_user"].ToString());
            int secondUserInConversation = Int16.Parse(Session["ID_user"].ToString());

            List<Message> messages = messageController.getConversation(currUser, secondUserInConversation);

            Panel1.Width = 200;
            Panel1.Controls.Clear();

            foreach (Message message in messages)
            {
                Label messageLabel = new Label();
                messageLabel.Width = 800;
                messageLabel.Height = 50;
                messageLabel.BorderWidth = 2;
                if (currUser == message.ID_from())
                {
                    messageLabel.Text += "Ty";
                }
                else
                {
                    messageLabel.Text += userController.getLoginByID(message.ID_from());
                }
                messageLabel.Text += "<br />";
                messageLabel.Text += message.content();
                Panel1.Controls.Add(messageLabel);
                Panel1.Controls.Add(new LiteralControl("<br />"));
            }
        }
    }
}