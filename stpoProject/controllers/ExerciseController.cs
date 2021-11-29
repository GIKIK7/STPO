using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class ExerciseController
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        private List<Exercise> m_exercises = new List<Exercise>();

        public void getExerciseListFromDatabase()
        {
            m_exercises.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetExercise = "SELECT * FROM [dbo].[exercise]";

            SqlCommand cmdGetExercise = new SqlCommand(strGetExercise, connection);
            SqlDataReader readerGetExercise = cmdGetExercise.ExecuteReader();

            while (readerGetExercise.Read())
            {
                int exerciseID = Int16.Parse(readerGetExercise.GetValue(0).ToString());
                string exerciseName= readerGetExercise.GetValue(1).ToString();

                Exercise exercise = new Exercise(exerciseID, exerciseName);
                m_exercises.Add(exercise);
            }
            connection.Close();
        }

        public Exercise getExerciseByID(int ID)
        {
            foreach (Exercise exercise in m_exercises)
            {
                if (exercise.ID() == ID)
                {
                    return exercise;
                }
            }
            return null;
        }
    }
}