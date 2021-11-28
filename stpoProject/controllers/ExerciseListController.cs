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

        public int getNumberOfExercise(int ID_workout)
        {
            int numOfExer = 0;
            foreach(ExerciseList exerList in m_exerciseLists)
            {
                if(exerList.ID_exercise() == ID_workout)
                {
                    numOfExer++;
                }
            }
            return numOfExer;
        }

        public void updateExerciseList(int ID_workout, List<int> ID_exercise, List<int> sets, List<int> reps)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String delete_Workout = "DELETE [dbo].[exerciseList] WHERE ID_workout = '" + ID_workout + "'";


            SqlCommand cmdDelWorkout = new SqlCommand(delete_Workout, connection);
            cmdDelWorkout.ExecuteReader();

            connection.Close();

            foreach(ExerciseList exerList in m_exerciseLists.ToList())
            {
                if(exerList.ID_workout() == ID_workout)
                {
                    m_exerciseLists.Remove(exerList);
                }
            }

            


            for (int i = 0; i < ID_exercise.Count(); i++)
            {
                connection.Open();

                String insert = "INSERT INTO [dbo].[exerciseList] (ID_workout, ID_exercise, sets, reps) VALUES ('" + ID_workout + "','" + ID_exercise[i] + "','" +
                    sets[i] + "','" + reps[i] + "')";

                SqlCommand cmdInsert = new SqlCommand(insert, connection);
                cmdInsert.ExecuteReader();

                connection.Close();

                connection.Open();

                String getID = "SELECT ID FROM [dbo].[exerciseList]  WHERE ID_workout = '" + ID_workout + "' AND ID_exercise = '" + ID_exercise[i] + "' AND sets='" + sets[i] +
                    "' AND reps= '" + reps[i] + "'";

                SqlCommand cmdGetID = new SqlCommand(getID, connection);
                SqlDataReader readerGetID = cmdGetID.ExecuteReader();

                while (readerGetID.Read())
                {
                    int ID = Int16.Parse(readerGetID.GetValue(0).ToString());

                    ExerciseList exerciseList = new ExerciseList(ID, ID_workout, ID_exercise[i], sets[i], reps[i]);
                    m_exerciseLists.Add(exerciseList);
                }

                connection.Close();
            }

            this.getExerciseListFromDatabase();

        }
    }
}