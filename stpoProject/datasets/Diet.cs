using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Diet
    {
        private int m_ID;
        private int m_IDmealBrakfast;
        private int m_AmountBreakfast;
        private int m_IDmealDinner;
        private int m_AmountDinner;
        private int m_IDmealSupper;
        private int m_AmountSupper;

        public Diet(int ID, int IDmealBrakfast, int AmountBreakfast, int IDmealDinner, int AmountDinner, int IDmealSupper, int AmountSupper)
        {
            m_ID = ID;
            m_IDmealBrakfast = IDmealBrakfast;
            m_AmountBreakfast = AmountBreakfast;
            m_IDmealDinner = IDmealDinner;
            m_AmountDinner = AmountDinner;
            m_IDmealSupper = IDmealSupper;
            m_AmountSupper = AmountSupper;
        }

        public Diet(int IDmealBrakfast, int AmountBreakfast, int IDmealDinner, int AmountDinner, int IDmealSupper, int AmountSupper)
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
            m_ID = ID;
        }

        public int ID()
        {
            return m_ID;
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