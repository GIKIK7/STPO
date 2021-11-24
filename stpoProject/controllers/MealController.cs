using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class MealController
    {
        List<Meal> m_meals = new List<Meal>();

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };


        public void getMealListFromDatabase()
        {
            m_meals.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetClient = "SELECT * FROM [dbo].[meals]";

            SqlCommand cmdGetCategory = new SqlCommand(strGetClient, connection);
            SqlDataReader readerGetCategory = cmdGetCategory.ExecuteReader();

            while (readerGetCategory.Read())
            {
                int ID = Int16.Parse(readerGetCategory.GetValue(0).ToString());
                string name = readerGetCategory.GetValue(1).ToString();

                Meal meal= new Meal(ID, name);
                m_meals.Add(meal);
            }
            connection.Close();
        }

        public List<Meal> getMealList()
        {
            return m_meals;
        }

        public string getNameByID(int ID)
        {
            foreach (Meal meal in m_meals)
            {
                if (meal.ID() == ID)
                {
                    return meal.name();
                }
            }
            return "";
        }

        public int getIDbyName(string name)
        {
            foreach (Meal meal in m_meals)
            {
                if (meal.name() == name)
                {
                    return meal.ID();
                }
            }
            return -1;
        }
    }
}