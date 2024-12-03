using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class MenuFactory : IMenuFactory
    {
        public IMenu CreateMenu(string period)
        {
            if (period.ToLower() == "morning")
            {
                return new DishManagerMorning();
            }
            else if (period.ToLower() == "evening")
            {
                return new DishManagerEvening();
            }
            else
            {
                throw new ArgumentException("Invalid period specified");
            }
        }
    }
}
