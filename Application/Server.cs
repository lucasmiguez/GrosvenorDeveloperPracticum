using System;
using System.Collections.Generic;

namespace Application
{
    public class Server : IServer
    {
        private readonly IMenu _dishManager;
        private readonly IMenuFactory _menuFactory;

        public Server(IMenu dishManager, IMenuFactory menuFactory)
        {
            _dishManager = dishManager;
            _menuFactory = menuFactory;
        }
        
        public string TakeOrder(string period, string unparsedOrder)
        {
            try
            {
                if (period.ToLower() != "morning" && period.ToLower() != "evening")
                    return "Invalid period specified. Enter period (morning/evening)";

                //Factory Method Pattern
                var menu = _menuFactory.CreateMenu(period);
                
                Order order = ParseOrder(unparsedOrder);
                var availableDishes = menu.GetDishes(order);
                string returnValue = FormatOutput(availableDishes);
                return returnValue;
            }
            catch (ApplicationException)
            {
                return "error";
            }
        }


        private Order ParseOrder(string unparsedOrder)
        {
            var returnValue = new Order
            {
                Dishes = new List<int>()
            };

            var orderItems = unparsedOrder.Split(',');
            foreach (var orderItem in orderItems)
            {
                if (int.TryParse(orderItem, out int parsedOrder))
                {
                    returnValue.Dishes.Add(parsedOrder);
                }
                else
                {
                    throw new ApplicationException("Order needs to be comma separated list of numbers");
                }
            }
            return returnValue;
        }

        private string FormatOutput(List<Dish> dishes)
        {
            var returnValue = "";

            foreach (var dish in dishes)
            {
                returnValue = returnValue + string.Format(",{0}{1}", dish.DishName, GetMultiple(dish.Count));
            }

            if (returnValue.StartsWith(","))
            {
                returnValue = returnValue.TrimStart(',');
            }

            return returnValue;
        }

        private object GetMultiple(int count)
        {
            if (count > 1)
            {
                return string.Format("(x{0})", count);
            }
            return "";
        }
    }
}
