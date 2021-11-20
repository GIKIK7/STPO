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
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };
        protected void Page_Load(object sender, EventArgs e)
        {

            MessageController messageController = (MessageController)Session["messageController"];
            

            UserController userController = (UserController)Session["userController"];

            int currUser = Int16.Parse(Session["ID_current_user"].ToString());
            int secondUserInConversation = Int16.Parse(Session["ID_user"].ToString());

            List<Message> messages = messageController.getConversation(currUser, secondUserInConversation);

            Panel1.Width = 200;

            foreach (Message message in messages)
            {
                Label messageLabel = new Label();
                messageLabel.Width = Panel1.Width;
                messageLabel.Height = 50;
                messageLabel.BorderWidth = 2;
                messageLabel.Text += userController.getLoginByID(message.ID_from());
                messageLabel.Text += "<br />";
                messageLabel.Text += message.content();
                Panel1.Controls.Add(messageLabel);
                Panel1.Controls.Add(new LiteralControl("<br />"));
            }

            /*
            for(int i=0; i<10; i++)
            {
                Label l1 = new Label();
                l1.Text = "elo" + "<br />" + " co tam u ciebie mordziaty?";
                //l1.Text += Environment.NewLine;
                //l1.Text += " co tam u ciebie mordziaty?";
                l1.Width = Panel1.Width;
                l1.Height = 50;
                l1.BorderWidth = 2;
                Panel1.Controls.Add(l1);
                Panel1.Controls.Add(new LiteralControl("<br />"));
            }
            */

        }
    }
}