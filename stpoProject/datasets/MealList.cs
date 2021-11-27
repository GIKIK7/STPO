using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class MealList
    {
        private int m_ID_mealList;
        private int m_IDmealBrakfast;
        private int m_AmountBreakfast;
        private int m_IDmealDinner;
        private int m_AmountDinner;
        private int m_IDmealSupper;
        private int m_AmountSupper;

        public MealList(int ID, int IDmealBrakfast, int AmountBreakfast, int IDmealDinner, int AmountDinner, int IDmealSupper, int AmountSupper)
        {
            m_ID_mealList = ID;
            m_IDmealBrakfast = IDmealBrakfast;
            m_AmountBreakfast = AmountBreakfast;
            m_IDmealDinner = IDmealDinner;
            m_AmountDinner = AmountDinner;
            m_IDmealSupper = IDmealSupper;
            m_AmountSupper = AmountSupper;
        }

        public MealList(int IDmealBrakfast, int AmountBreakfast, int IDmealDinner, int AmountDinner, int IDmealSupper, int AmountSupper)
        {
            m_IDmealBrakfast = IDmealBrakfast;
            m_AmountBreakfast = AmountBreakfast;
            m_IDmealDinner = IDmealDinner;
            m_AmountDinner = AmountDinner;
            m_IDmealSupper = IDmealSupper;
            m_AmountSupper = AmountSupper;
        }

        public void setID(int ID)
        {
            m_ID_mealList = ID;
        }
        public void setIDmealBrakfast(int ID)
        {
            m_IDmealBrakfast = ID;
        }

        public void setAmountBreakfast(int val)
        {
            m_AmountBreakfast = val;
        }

        public void setIDdinner(int ID)
        {
            m_IDmealDinner = ID;
        }

        public void setAmountDinner(int val)
        {
            m_AmountDinner = val;
        }
        public void setIDsupper(int ID)
        {
            m_IDmealSupper = ID;
        }

        public void setAmountSupper(int val)
        {
            m_AmountSupper = val;
        }

        public int ID()
        {
            return m_ID_mealList;
        }

        public int IDmealBrakfast()
        {
            return m_IDmealBrakfast;
        }

        public int AmountBreakfast()
        {
            return m_AmountBreakfast;
        }

        public int IDmealDinner()
        {
            return m_IDmealDinner;
        }

        public int AmountDinner()
        {
            return m_AmountDinner;
        }
        public int IDmealSupper()
        {
            return m_IDmealSupper;
        }

        public int AmountSupper()
        {
            return m_AmountSupper;
        }
    }
}