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
            DropList_category.Enabled = isChecked;
        }

        protected void Btn_SignIn_Click(object sender, EventArgs e)
        {
            String login = TxtBox_login.Text.Trim();
            String password = TxtBox_password.Text.Trim();
            String name = TxtBox_name.Text.Trim();
            String lName = TxtBox_LastName.Text.Trim();
            string category = DropList_category.Text;
            bool isTrener = isChecked;

            UserController userController = (UserController)Session["userController"];

            if (login.Length == 0 || password.Length == 0 || name.Length == 0 || lName.Length == 0)
            {
                Lbl_Helper.Text = "Wszystkie pola sa wymagane!";
            }
            else
            {
                if (userController.isUnique(login))
                {
                    registerUser(login, password, name, lName, isTrener, category);
                    Response.Redirect("LogInForm.aspx");
                }
                else
                {
                    Lbl_Helper.Text = "login jest już zajęty!";
                }
                
            }
        }

        private void registerUser(String login, String password, String name, String lastName, bool isTrener, string category)
        {
            CoachController coachController = (CoachController)Session["coachController"];

            ClientController clientController = (ClientController)Session["clientController"];

            UserController userController = (UserController)Session["userController"];

            CategoryControllers categoryController = (CategoryControllers)Session["categoryController"];

            userController.addUser(login, password, isTrener);

            int user_id = userController.getUserIDBy(login, password);

            int category_id = categoryController.getIDbyName(category);

            if (isTrener == true)
            {
                coachController.addCoach(user_id, name, lastName, category_id);
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
                DropList_category.Enabled = false;
                ChkBox_trener.Checked = isChecked;
            }
            else
            {
                isChecked = true;
                DropList_category.Enabled = true;
                ChkBox_trener.Checked = isChecked;
            }
        }
    }
}