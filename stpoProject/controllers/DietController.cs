using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class DietController
    {
        List<Diet> m_diets = new List<Diet>();

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        public void getDietListFromDatabase()
        {
            m_diets.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetDiet = "SELECT * FROM [dbo].[diets]";

            SqlCommand cmdGetDiet = new SqlCommand(strGetDiet, connection);
            SqlDataReader readerGetDiet = cmdGetDiet.ExecuteReader();

            while (readerGetDiet.Read())
            {
                int dietID = Int16.Parse(readerGetDiet.GetValue(0).ToString());
                int breakfastID= Int16.Parse(readerGetDiet.GetValue(1).ToString());
                int amountBreakfast= Int16.Parse(readerGetDiet.GetValue(2).ToString());
                int dinnerID = Int16.Parse(readerGetDiet.GetValue(3).ToString());
                int amountDinner = Int16.Parse(readerGetDiet.GetValue(4).ToString());
                int supperID = Int16.Parse(readerGetDiet.GetValue(5).ToString());
                int amountSupper = Int16.Parse(readerGetDiet.GetValue(6).ToString());

                Diet diet = new Diet(dietID, breakfastID, amountBreakfast, dinnerID, amountDinner, supperID, amountSupper);
                m_diets.Add(diet);
            }
            connection.Close();
        }

        public void addDiet(int breakfastID, int amountBreakfast, int dinnerID, int amountDinner, int supperID, int amountSupper)
        {
            Diet diet = new Diet(breakfastID, amountBreakfast, dinnerID, amountDinner, supperID, amountSupper);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[diets] (ID_meal_breakfast, Amount_breakfast, ID_meal_dinner, Amount_dinner, ID_meal_supper , Amount_supper ) VALUES " +
                "('" + breakfastID + "','" + amountBreakfast + "','" + dinnerID + "','" + amountDinner + "','" + "','" + supperID + "','" +
                "','" + amountSupper + "')";

            cmd = new SqlCommand(insertStr, connection);

            cmd.ExecuteReader();

            connection.Close();


            connection.Open();

            int dietID = 0;

            String getDietID = "SELECT ID FROM [dbo].[diets] WHERE ID_meal_breakfast='" + breakfastID + "' AND Amount_breakfast='" + amountBreakfast + "' AND ID_meal_dinner='"+
              dinnerID + "' AND Amount_dinner ='" + amountDinner + "' AND ID_meal_supper='" + supperID + "' AND Amount_supper ='" + amountSupper + "'";

            SqlCommand command = new SqlCommand(getDietID, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dietID = Int16.Parse(reader.GetValue(0).ToString());
            }

            diet.setID(dietID);

            m_diets.Add(diet);

            connection.Close();
        }
    }
}