using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManagerEvening : IMenu
    {
        /// <summary>
        /// Takes an Order object, sorts the orders and builds a list of dishes to be returned. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(Order order)
        {
            var returnValue = new List<Dish>();
            order.Dishes.Sort();
            foreach (var dishType in order.Dishes)
            {
                AddOrderToList(dishType, returnValue);
            }
            return returnValue;
        }

        /// <summary>
        /// Takes an int, representing an order type, tries to find it in the list.
        /// If the dish type does not exist, add it and set count to 1
        /// If the type exists, check if multiples are allowed and increment that instances count by one
        /// else throw error
        /// </summary>
        /// <param name="order">int, represents a dishtype</param>
        /// <param name="returnValue">a list of dishes, - get appended to or changed </param>
        private void AddOrderToList(int order, List<Dish> returnValue)
        {
            var dishEveninng = GetOrderName(order);
            var existingOrder = returnValue.SingleOrDefault(x => x.DishName == dishEveninng.Name);
            if (existingOrder == null)
            {
                returnValue.Add(new Dish
                {
                    DishName = dishEveninng.Name,
                    Count = 1
                });
            } else if (IsMultipleAllowed(order))
            {
                existingOrder.Count++;
            }
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", dishEveninng.Name));
            }
        }

        private EveningDish GetOrderName(int order)
        {
            switch (order)
            {
                case 0:
                    return new EveningDish("", "", order);    
                case 1:
                    return new EveningDish("steak", "entree", order);
                case 2:
                    return new EveningDish("potato", "side", order);
                case 3:
                    return new EveningDish("wine", "drink", order);
                case 4:
                    return new EveningDish("cake", "dessert", order);
                default:
                    throw new ApplicationException("Order does not exist");
            }
        }

        private bool IsMultipleAllowed(int order)
        {
            switch (order)
            {

                case 0: //No Item
                    return true;
                case 2: //potato
                    return true;
                default:
                    return false;

            }
        }
    }
}