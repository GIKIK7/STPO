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
        protected void Page_Load(object sender, EventArgs e)
        {
            UserController userController = (UserController)Session["userController"];
            int currUserID = Int16.Parse(Session["ID_current_user"].ToString());
            User currUser = userController.getUserbyID(currUserID);

            SqlDataSource1.SelectCommand = "SELECT DISTINCT loginTo, loginFrom FROM [dbo].[Contacts] WHERE loginTo ='" + currUser.login() + "' OR loginFrom ='" + currUser.login() + "'";
            if(DataList_Contacts.Items.Count == 0)
            {
                LbL_contactsInfo.Text = "Nie masz jeszcze żadnych rozmów";
            }
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
    }
}