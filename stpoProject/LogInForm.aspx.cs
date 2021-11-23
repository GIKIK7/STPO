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

    public partial class LogInForm : System.Web.UI.Page
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
                DataSource = "stpo.database.windows.net",
                UserID = "GIKIK",
                Password = "AdminHaslo137",
                InitialCatalog = "DBstpo"
        };

        static List<User> users = new List<User>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_current_user"] = -1;
            Session["ID_user"] = -1;

            ClientController clientController = new ClientController();
            clientController.getClientListFromDatabase();
            Session["clientController"] = clientController;

            UserController userController = new UserController();
            userController.getUserListFromDatabase();
            users = userController.getUserList();
            Session["userController"] = userController;

            CoachController coachController = new CoachController();
            coachController.getCoachListFromDatabase();
            Session["coachController"] = coachController;

            CategoryControllers categoryController = new CategoryControllers();
            categoryController.getCategoryListFromDatabase();
            Session["categoryController"] = categoryController;

            MessageController messageController = new MessageController();
            messageController.getMessagesListFromDatabase();
            Session["messageController"] = messageController;
        }

        protected void Btn_LogInClick(object sender, EventArgs e)
        {
            foreach (User user in users)
            {
                if(user.login() == TxtBox_User.Text)
                {
                    if(user.password() == TxtBox_Password.Text)
                    {
                        Session["ID_user"] = user.ID();
                        Session["ID_current_user"] = user.ID();
                        if (user.isTrener())
                        {
                            Response.Redirect("CoachDetailsForm.aspx");
                        }
                        else
                        {
                            Response.Redirect("ClientDetailsForm.aspx");
                        }
                    } 
                }
                else
                {
                    LbL_Helper.Text = "Niepoprawne haslo!";
                }
            }
        }

        protected void Btn_testowa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Testowa.aspx");
        }
    }
}