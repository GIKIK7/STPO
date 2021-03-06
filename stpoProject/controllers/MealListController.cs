using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class MealListController
    {
        private List<MealList> m_mealLists = new List<MealList>();

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        public string showMealList()
        {
            string str = "";
            foreach (MealList mealList in m_mealLists)
            {
                str += mealList.ID() + " " + mealList.IDmealBrakfast() + " " + mealList.AmountBreakfast() + " " 
                    + mealList.IDmealDinner() + " " + mealList.AmountDinner() + " " 
                    + mealList.IDmealSupper() + " " + mealList.AmountSupper() + " ";
            }
            return str;
        }

        public void getmealListListFromDatabase()
        {
            m_mealLists.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetmealList = "SELECT * FROM [dbo].[mealList]";

            SqlCommand cmdGetmealList = new SqlCommand(strGetmealList, connection);
            SqlDataReader readerGetMealList = cmdGetmealList.ExecuteReader();

            while (readerGetMealList.Read())
            {
                int mealListID = Int16.Parse(readerGetMealList.GetValue(0).ToString());
                int breakfastID= Int16.Parse(readerGetMealList.GetValue(1).ToString());
                int amountBreakfast= Int16.Parse(readerGetMealList.GetValue(2).ToString());
                int dinnerID = Int16.Parse(readerGetMealList.GetValue(3).ToString());
                int amountDinner = Int16.Parse(readerGetMealList.GetValue(4).ToString());
                int supperID = Int16.Parse(readerGetMealList.GetValue(5).ToString());
                int amountSupper = Int16.Parse(readerGetMealList.GetValue(6).ToString());

                MealList mealList = new MealList(mealListID, breakfastID, amountBreakfast, dinnerID, amountDinner, supperID, amountSupper);
                m_mealLists.Add(mealList);
            }
            connection.Close();
        }

        public void addMealList(int breakfastID, int amountBreakfast, int dinnerID, int amountDinner, int supperID, int amountSupper)
        {
            MealList mealList = new MealList(breakfastID, amountBreakfast, dinnerID, amountDinner, supperID, amountSupper);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[mealList] (ID_meal_breakfast, Amount_breakfast, ID_meal_dinner, Amount_dinner, ID_meal_supper , Amount_supper ) VALUES " +
                "('" + breakfastID + "','" + amountBreakfast + "','" + dinnerID + "','" + amountDinner + "','" + "','" + supperID + "','" +
                "','" + amountSupper + "')";

            cmd = new SqlCommand(insertStr, connection);

            cmd.ExecuteReader();

            connection.Close();


            connection.Open();

            int mealListID = 0;

            String getmealListID = "SELECT ID FROM [dbo].[mealList] WHERE ID_meal_breakfast='" + breakfastID + "' AND Amount_breakfast='" + amountBreakfast + "' AND ID_meal_dinner='"+
              dinnerID + "' AND Amount_dinner ='" + amountDinner + "' AND ID_meal_supper='" + supperID + "' AND Amount_supper ='" + amountSupper + "'";

            SqlCommand command = new SqlCommand(getmealListID, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                mealListID = Int16.Parse(reader.GetValue(0).ToString());
            }

            mealList.setID(mealListID);

            m_mealLists.Add(mealList);

            connection.Close();
        }
    
        public MealList getMealListByID(int ID)
        {
            foreach (MealList mealList in m_mealLists)
            {
                if(mealList.ID() == ID)
                {
                    return mealList;
                }
            }
            return null;
        }

        public void updateMealList(int ID, int IDbreakfast, int amountBreakfast, int IDdinner, int amountDinner, int IDsuppeer, int amountSupper)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String updateCoach = "UPDATE [dbo].[mealList] SET ID_meal_breakfast ='" + IDbreakfast + "', Amount_breakfast='" + amountBreakfast + "', ID_meal_dinner='" + IDdinner
                + "', Amount_dinner = '" + amountDinner + "', ID_meal_supper = '" + IDsuppeer + "', Amount_supper='" + amountSupper
                   + "'WHERE ID =" + ID;


            SqlCommand cmdEditCoach = new SqlCommand(updateCoach, connection);
            cmdEditCoach.ExecuteReader();

            connection.Close();
            
            foreach (MealList meal in m_mealLists)
            {
                if (meal.ID() == ID)
                {
                    meal.setIDmealBrakfast(IDbreakfast);
                    meal.setAmountBreakfast(amountBreakfast);
                    meal.setIDdinner(IDdinner);
                    meal.setAmountDinner(amountDinner);
                    meal.setIDsupper(IDsuppeer);
                    meal.setAmountSupper(amountSupper);
                }
            }
            
        }

        public int addMealListReturnID(int IDbreakfast, int amountBreakfast, int IDdinner, int amountDinner, int IDsuppeer, int amountSupper)
        {
            MealList mealList = new MealList(IDbreakfast, amountBreakfast, IDdinner, amountDinner, IDsuppeer, amountSupper);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[mealList] (ID_meal_breakfast, Amount_breakfast, ID_meal_dinner, Amount_dinner, ID_meal_supper, Amount_supper) " +
                "VALUES ('" + IDbreakfast + "','" + amountBreakfast + "','" + IDdinner + "','" + amountDinner + "','" + IDsuppeer + "','" + amountSupper + "')";

            using (cmd = new SqlCommand(insertStr, connection))
            {
                cmd.ExecuteReader();
            }

            connection.Close();


            connection.Open();

            int ID = 0;

            String getID = "SELECT ID FROM [dbo].[mealList] WHERE ID_meal_breakfast ='" + IDbreakfast + "' AND Amount_breakfast='" + amountBreakfast + "' AND ID_meal_dinner='" + IDdinner
                + "'AND Amount_dinner ='" + amountDinner + "'AND ID_meal_supper='" + IDsuppeer + "'AND Amount_supper='" + amountSupper + "'";

            using (SqlCommand command = new SqlCommand(getID, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ID = Int16.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            mealList.setID(ID);

            m_mealLists.Add(mealList);

            connection.Close();

            return mealList.ID();
        }

    }
}