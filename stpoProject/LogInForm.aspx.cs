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
        static List<Client> clients = new List<Client>();
        static List<Coach> coaches = new List<Coach>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_user"] = -1;

            ClientController clientController = new ClientController();
            clientController.getClientListFromDatabase();
            clients = clientController.getClientList();

            UserController userController = new UserController();
            userController.getUserListFromDatabase();
            users = userController.getUsserList();
            Session["userController"] = userController;

            CoachController coachController = new CoachController();
            coachController.getCoachListFromDatabase();
            coaches = coachController.getCoachList();
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


            /*
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                String sql = "SELECT ID, password, isTrener FROM [dbo].[users] WHERE login='" + TxtBox_User.Text + "'";

                SqlCommand cmdGetInfoUser = new SqlCommand(sql, connection);
                SqlDataReader readerGetInfoUser = cmdGetInfoUser.ExecuteReader();

                while (readerGetInfoUser.Read())
                {
                    if (readerGetInfoUser.GetValue(1).ToString() == TxtBox_Password.Text)
                    {
                        LbL_Helper.Text = "Zalogowano!";
                        Session["ID_user"] = Int16.Parse(readerGetInfoUser.GetValue(0).ToString());
                        
                        if(readerGetInfoUser.GetValue(2).ToString() == "True")
                        {
                            Response.Redirect("CoachDetailsForm.aspx");
                        }
                        else
                        {
                            Response.Redirect("ClientDetailsForm.aspx");
                        }
                    }
                    else
                    {
                        LbL_Helper.Text = "Niepoprawne haslo!";
                    }
                }
                connection.Close();
            }
            */
        }
    }
}