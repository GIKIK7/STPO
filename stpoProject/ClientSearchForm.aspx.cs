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
    public partial class ClientSearchPage : System.Web.UI.Page
    {
        static bool ascSortName = false;
        static bool ascSortLastName = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void itemCommand(object sender, DataListCommandEventArgs e)
        {
            UserController userController = (UserController)Session["userController"];
            ClientController clientController = (ClientController)Session["clientController"];

            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);

            string itemIDstr = e.CommandArgument.ToString();

            int clientID = Int16.Parse(itemIDstr);

            Client client = clientController.getClientbyID(clientID);

            User clickedUser = userController.getUserbyID(client.ID_user());

            Session["ID_user"] = clickedUser.ID();

            Response.Redirect("ClientDetailsForm.aspx");
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

        protected void Btn_sortByName_Click(object sender, EventArgs e)
        {

            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);

            ascSortName = !ascSortName;

            if (ascSortName)
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name] FROM [clients] ORDER BY [name] ASC";
            }
            else
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name] FROM [clients] ORDER BY [name] DESC";
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
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name] FROM [clients] ORDER BY [last_name] ASC";
            }
            else
            {
                DataSource_coaches.SelectCommand = "SELECT [ID], [name], [last_name] FROM [clients] ORDER BY [last_name] DESC";
            }
        }
    }
}