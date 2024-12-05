using System.Collections.Generic;

namespace Application
{

    public interface IMenu
    {
        /// <summary>
        /// Constructs a list of dishes, each dish with a name and a count
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        List<Dish> GetDishes(Order order);
        //List<Dish> GetDishes(Order order);
    }
}