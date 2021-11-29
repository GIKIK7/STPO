using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class ExerciseList
    {
        private int m_ID;
        private int m_ID_workout;
        private int m_ID_exercise;
        private int m_sets;
        private int m_reps;

        public ExerciseList(int ID, int ID_workout, int ID_exercise, int sets, int reps)
        {
            m_ID = ID;
            m_ID_workout = ID_workout;
            m_ID_exercise = ID_exercise;
            m_sets = sets;
            m_reps = reps;
        }
        public ExerciseList(int ID_workout, int ID_exercise, int sets, int reps)
        {
            m_ID_workout = ID_workout;
            m_ID_exercise = ID_exercise;
            m_sets = sets;
            m_reps = reps;
        }

        public void setID(int ID)
        {
            m_ID = ID;
        }
        public void setID_workout(int ID)
        {
            m_ID_workout = ID;
        }
        public void setID_exercise(int ID)
        {
            m_ID_exercise = ID;
        }
        public void setSets(int sets)
        {
            m_sets = sets;
        }
        public void setReps(int reps)
        {
            m_reps = reps;
        }

        public int ID()
        {
            return m_ID;
        }

        public int ID_workout()
        {
            return m_ID_workout;
        }
        public int ID_exercise()
        {
            return m_ID_exercise;
        }
        public int sets()
        {
            return m_sets;
        }
        public int reps()
        {
            return m_reps;
        }
    }
}