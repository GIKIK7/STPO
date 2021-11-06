using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace stpoProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        static int i = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("insert into Users values('" + TextBox1.Text + "','" + TextBox2.Text + "')", con);
            SqlCommand cmd = new SqlCommand("insert into Users values('" + i + "','" + TextBox1.Text + "','" + TextBox2.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            //Label1.Text = "Data has been inserted";
            GridView1.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            i++;
        }
    }
}