using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class CategoryControllers
    {
        private List<Category> m_categories = new List<Category>();

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };


        public void getCategoryListFromDatabase()
        {
            m_categories.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetClient = "SELECT * FROM [dbo].[category]";

            SqlCommand cmdGetCategory = new SqlCommand(strGetClient, connection);
            SqlDataReader readerGetCategory = cmdGetCategory.ExecuteReader();

            while (readerGetCategory.Read())
            {
                int categoryID = Int16.Parse(readerGetCategory.GetValue(0).ToString());
                string categoryName = readerGetCategory.GetValue(1).ToString();

                Category category = new Category(categoryID, categoryName);
                m_categories.Add(category);
            }
            connection.Close();
        }

        public List<Category> getCategoryList()
        {
            return m_categories;
        }

        public string getNameByID(int ID)
        {
            foreach (Category category in m_categories)
            {
                if (category.ID() == ID)
                {
                    return category.name();
                }
            }
            return "";
        }

        public int getIDbyName(string name)
        {
            foreach (Category category in m_categories)
            {
                if(category.name() == name)
                {
                    return category.ID();
                }
            }
            return -1;
        }
    }
}