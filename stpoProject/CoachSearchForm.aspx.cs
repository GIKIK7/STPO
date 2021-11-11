using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace stpoProject
{
    public partial class CoachSearchForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void funkcja(object sender, EventArgs e)
        {
            Lbl_helper.Text = "haha gowno";
        }

        // OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="Item_Command"

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataListItem dataItem = (DataListItem)e.Item;

            //string curItem = DataList1.SelectedIndex.ToString();

            int idx = DataList1.SelectedIndex;

            Lbl_helper.Text = idx.ToString();

            /*
            Label lbl = (Label)DataList1.Items[idx].FindControl("nameLabel");
            int id = Convert.ToInt32(DataList1.SelectedValue);

            Lbl_helper.Text = id.ToString();
            */
        }
    }
}