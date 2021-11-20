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

    public partial class CoachSearchForm : System.Web.UI.Page
    {
        static bool ascSortName = false;
        static bool ascSortLastName = false;
        static bool ascSortCategory = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void itemCommand(object sender, DataListCommandEventArgs e)
        {
            string itemIDstr = e.CommandArgument.ToString();

            int itemID = Int16.Parse(itemIDstr);

            CoachController coachController = (CoachController)Session["coachController"];

            UserController userController = (UserController)Session["userController"];


            Session["ID_user"] = coachController.getIDuserByIDcoach(itemID).ToString();

            Response.Redirect("CoachDetailsForm.aspx");

        }

        protected void Btn_sortByName_Click(object sender, EventArgs e)
        {
            ascSortName = !ascSortName;

            if(ascSortName)
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
    }
}