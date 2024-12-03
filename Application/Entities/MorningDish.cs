using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class MorningDish : IDish
    {
        public string Name { get; private set; }

        public int Cod { get; set; }

        public string DishType { get; set; }

        public MorningDish(string name, string dishType,int cod)
        {
            Name = name;
            Cod = cod;
            DishType = dishType;    
        }       
    }
}
