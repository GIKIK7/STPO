using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class ExerciseListController
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        private List<ExerciseList> m_exerciseLists = new List<ExerciseList>();

        public void getExerciseListFromDatabase()
        {
            m_exerciseLists.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetExercisxeList = "SELECT * FROM [dbo].[exerciseList]";

            SqlCommand cmdGetExerciseList = new SqlCommand(strGetExercisxeList, connection);
            SqlDataReader readerGetExerciseList = cmdGetExerciseList.ExecuteReader();

            while (readerGetExerciseList.Read())
            {
                int exerciseListID = Int16.Parse(readerGetExerciseList.GetValue(0).ToString());
                int ID_workout = Int16.Parse(readerGetExerciseList.GetValue(1).ToString());
                int ID_exercise = Int16.Parse(readerGetExerciseList.GetValue(2).ToString());
                int sets = Int16.Parse(readerGetExerciseList.GetValue(3).ToString());
                int reps = Int16.Parse(readerGetExerciseList.GetValue(4).ToString());

                ExerciseList exerciseList = new ExerciseList(exerciseListID, ID_workout, ID_exercise, sets, reps);
                m_exerciseLists.Add(exerciseList);
            }
            connection.Close();
        }
        public List<ExerciseList> getExerciseListInWorkoutByWorkoutID(int ID_workout)
        {
            List<ExerciseList> exerciseLists = new List<ExerciseList>();
            foreach (ExerciseList exerList in m_exerciseLists)
            {
                if (exerList.ID_workout() == ID_workout)
                {
                    exerciseLists.Add(exerList);
                }
            }
            return exerciseLists;
        }
    }
}