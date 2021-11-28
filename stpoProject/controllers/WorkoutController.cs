using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class WorkoutController
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        List<Workout> m_workouts = new List<Workout>();

        public void getWorkoutFromDatabase()
        {
            m_workouts.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetWorkout = "SELECT * FROM [dbo].[workout]";

            SqlCommand cmdGetWorkout = new SqlCommand(strGetWorkout, connection);
            SqlDataReader readerGetWorkout = cmdGetWorkout.ExecuteReader();

            while (readerGetWorkout.Read())
            {
                int workoutID = Int16.Parse(readerGetWorkout.GetValue(0).ToString());
                int userID = Int16.Parse(readerGetWorkout.GetValue(1).ToString());
                DateTime date = DateTime.Parse(readerGetWorkout.GetValue(2).ToString());

                Workout workout = new Workout(workoutID, userID, date);
                m_workouts.Add(workout);
            }
            connection.Close();
        }
        public List<Workout> getWorkoutsOfUser(int ID_user)
        {
            List<Workout> workouts = new List<Workout>();
            foreach (Workout workout in m_workouts)
            {
                if (workout.ID_user() == ID_user)
                {
                    workouts.Add(workout);
                }
            }
            return workouts;
        }

        public Workout getWorkoutByDate(string date, int ID_user)
        {
            foreach (Workout workout in m_workouts)
            {
                if (workout.date() == date && workout.ID_user() == ID_user)
                {
                    return workout;
                }
            }
            return null;
        }

        public int addWorkoutReturnID(int ID_user, string dateStr)
        {
            DateTime date = DateTime.Parse(dateStr);

            Workout workout = new Workout(ID_user, date);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[workout] (ID_user, workoutDate) VALUES ('" + ID_user + "','" + dateStr  + "')";

            using (cmd = new SqlCommand(insertStr, connection))
            {
                cmd.ExecuteReader();
            }

            connection.Close();


            connection.Open();

            int ID = 0;

            String getID = "SELECT ID FROM [dbo].[workout] WHERE ID_user='" + ID_user + "' AND workoutDate ='" + dateStr + "'";

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
            workout.setID(ID);

            m_workouts.Add(workout);

            connection.Close();

            return workout.ID();
        }
    }
}