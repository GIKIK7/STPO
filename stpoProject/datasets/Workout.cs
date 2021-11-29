using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Workout
    {
        private int m_ID;
        private int m_ID_assign_client;
        private DateTime m_workoutDate;

        public Workout(int ID, int ID_user, DateTime workoutDate)
        {
            m_ID = ID;
            m_ID_assign_client = ID_user;
            m_workoutDate = workoutDate;
        }
        public Workout(int ID_user, DateTime workoutDate)
        {
            m_ID_assign_client = ID_user;
            m_workoutDate = workoutDate;
        }
        public int ID()
        {
            return m_ID;
        }

        public int ID_user()
        {
            return m_ID_assign_client;
        }

        public int ID_assign_client()
        {
            return m_ID_assign_client;
        }

        public string date()
        {
            return m_workoutDate.Year + "-" + m_workoutDate.Month + "-" + m_workoutDate.Day;
        }

        public void setID(int ID)
        {
            m_ID = ID;
        }

        public void setID_user(int ID)
        {
            m_ID_assign_client = ID;
        }

        public void setDate(DateTime date)
        {
            m_workoutDate = date;
        }
    }
}