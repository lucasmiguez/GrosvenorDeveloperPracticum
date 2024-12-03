using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManagerMorning : IMenu
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
            var dishMorning = GetOrderName(order);
            var existingOrder = returnValue.SingleOrDefault(x => x.DishName == dishMorning.Name);
            if (existingOrder == null)
            {
                returnValue.Add(new Dish
                {
                    DishName = dishMorning.Name,
                    Count = 1
                });
            } else if (IsMultipleAllowed(order))
            {
                existingOrder.Count++;
            }
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", dishMorning.Name));
            }
        }

        private MorningDish GetOrderName(int order)
        {
            switch (order)
            {
                case 0:
                    return new MorningDish("", "", order);
                case 1:
                    return new MorningDish("egg","entree", order);
                case 2:
                    return new MorningDish("toast", "side", order);
                case 3:
                    return new MorningDish("coffee", "drink", order);
                default:
                    throw new ApplicationException("Order does not exist");

            }
        }


        private bool IsMultipleAllowed(int order)
        {
            switch (order)
            {
                case 0: // No Item
                    return true;    
                case 3: // Coffee
                    return true;
                default:
                    return false;

            }
        }
    }
}