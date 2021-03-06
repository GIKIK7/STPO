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

    public partial class CoachSearchForm : System.Web.UI.Page
    {
        static bool ascSortName = false;
        static bool ascSortLastName = false;
        static bool ascSortCategory = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = (UserController)Session["userController"];
            ClientController clientController = (ClientController)Session["clientController"];

            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);
            Client currClient = clientController.getClientByIDuser(currUserID);

            Lbl_lastName.Text = currClient.name() + " " + currClient.lastName();
        }

        public void itemCommand(object sender, DataListCommandEventArgs e)
        {
            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);


            string itemIDstr = e.CommandArgument.ToString();

            int itemID = Int16.Parse(itemIDstr);

            CoachController coachController = (CoachController)Session["coachController"];

            ClientController clientController = (ClientController)Session["clientController"];
            Session["ID_user"] = coachController.getIDuserByIDcoach(itemID).ToString();

            Response.Redirect("CoachDetailsForm.aspx");
        }

        protected void Btn_sortByName_Click(object sender, EventArgs e)
        {

            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);

            ascSortName = !ascSortName;

            if (ascSortName)
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name], [categoryName] FROM [CoachesWithCategories] ORDER BY [name] ASC";
            }
            else
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name], [categoryName] FROM [CoachesWithCategories] ORDER BY [name] DESC";
            }

        }

        protected void Btn_sortByLastName_Click(object sender, EventArgs e)
        {

            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);

            ascSortLastName = !ascSortLastName;

            if (ascSortLastName)
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name], [categoryName] FROM [CoachesWithCategories] ORDER BY [last_name] ASC";
            }
            else
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name], [categoryName] FROM [CoachesWithCategories] ORDER BY [last_name] DESC";
            }
        }

        protected void Btn_sortByCategory_Click(object sender, EventArgs e)
        {
            ascSortCategory = !ascSortCategory;

            if (ascSortCategory)
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name], [categoryName] FROM [CoachesWithCategories] ORDER BY [categoryName] ASC";
            }
            else
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name], [categoryName] FROM [CoachesWithCategories] ORDER BY [categoryName] DESC";
            }
        }

        protected void Btn_back_Click(object sender, EventArgs e)
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