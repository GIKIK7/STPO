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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void funkcja(object sender, EventArgs e)
        {
            Lbl_helper.Text = "haha gowno";
        }


        public void itemCommand(object sender, DataListCommandEventArgs e)
        {
            string itemID = e.CommandArgument.ToString();
            Lbl_helper.Text = itemID;
        }
    }
}