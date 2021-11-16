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
        public string order { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            order = " ORDER BY [name]";
            //DataSource_coaches.SelectCommand = "SELECT [name], [last_name], [ID] FROM [coaches] ORDER BY [name]";
        }

        public void itemCommand(object sender, DataListCommandEventArgs e)
        {
            string itemID = e.CommandArgument.ToString();
            Lbl_helper.Text = itemID;
        }
    }
}