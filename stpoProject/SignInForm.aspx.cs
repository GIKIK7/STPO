using System;
using System.Data.SqlClient;
using System.Linq;

namespace stpoProject
{
    using controllers;
    public partial class SignInForm : System.Web.UI.Page
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };


        static bool isChecked = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Lbl_Helper.Text = "";
            ChkBox_trener.Checked = isChecked;
        }

        protected void Btn_SignIn_Click(object sender, EventArgs e)
        {
            String login = TxtBox_login.Text.Trim();
            String password = TxtBox_password.Text.Trim();
            String name = TxtBox_name.Text.Trim();
            String lName = TxtBox_LastName.Text.Trim();
            bool isTrener = isChecked;

            if (login.Length == 0 || password.Length == 0 || name.Length == 0 || lName.Length == 0)
            {
                Lbl_Helper.Text = "Wszystkie pola sa wymagane!";
            }
            else
            {
                registerUser(login, password, name, lName, isTrener);
                Response.Redirect("LogInForm.aspx");
            }
        }

        private void registerUser(String login, String password, String name, String lastName, bool isTrener)
        {
            CoachController coachController = (CoachController)Session["coachController"];

            ClientController clientController = (ClientController)Session["clientController"];

            UserController userController = (UserController)Session["userController"];

            userController.addUser(login, password, isTrener);

            int user_id = userController.getUserIDBy(login, password);

            if (isTrener == true)
            {
                coachController.addCoach(user_id, name, lastName);
            }
            else
            {
                clientController.addClient(user_id, name, lastName);
            }

        }

        protected void ChkBox_trener_CheckedChanged(object sender, EventArgs e)
        {
            if (isChecked)
            {
                isChecked = false;
                ChkBox_trener.Checked = isChecked;
            }
            else
            {
                isChecked = true;
                ChkBox_trener.Checked = isChecked;
            }
        }
    }
}