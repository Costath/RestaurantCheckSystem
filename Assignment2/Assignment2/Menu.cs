using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Menu
    {
        /// <summary>
        /// List of MenuItem objects containing the available Beverages
        /// </summary>
        public List<MenuItem> Beverages = new List<MenuItem> {
            new MenuItem{
                        Name = "Soda",
                        Category = "Beverage",
                        Price = 1.95m
                        },
            new MenuItem{
                        Name = "Tea",
                        Category = "Beverage",
                        Price = 1.50m
                        },
            new MenuItem{
                        Name = "Coffee",
                        Category = "Beverage",
                        Price = 1.25m
                        },
            new MenuItem{
                        Name = "Mineral Water",
                        Category = "Beverage",
                        Price = 2.95m
                        },
            new MenuItem{
                        Name = "Juice",
                        Category = "Beverage",
                        Price = 2.50m
                        },
            new MenuItem{
                        Name = "Milk",
                        Category = "Beverage",
                        Price = 1.50m
                        }};

        /// <summary>
        /// List of MenuItem objects containing the available Appetizers
        /// </summary>
        public List<MenuItem> Appetizers = new List<MenuItem> {
            new MenuItem{
                        Name = "Buffalo Wings",
                        Category = "Appetizer",
                        Price = 5.95m
                        },
            new MenuItem{
                        Name = "Buffalo Fingers",
                        Category = "Appetizer",
                        Price = 6.95m
                        },
            new MenuItem{
                        Name = "Potato Skins",
                        Category = "Appetizer",
                        Price = 8.95m
                        },
            new MenuItem{
                        Name = "Nachos",
                        Category = "Appetizer",
                        Price = 8.95m
                        },
            new MenuItem{
                        Name = "Mushroom Caps",
                        Category = "Appetizer",
                        Price = 10.95m
                        },
            new MenuItem{
                        Name = "Shrimp Cocktail",
                        Category = "Appetizer",
                        Price = 12.95m
                        },
            new MenuItem{
                        Name = "Chips and Salsa",
                        Category = "Appetizer",
                        Price = 6.95m
                        } };

        /// <summary>
        /// List of MenuItem objects containing the available Main Course dishes
        /// </summary>
        public List<MenuItem> MainCourseDishes = new List<MenuItem> {
            new MenuItem{
                        Name = "Seafood Alfredo",
                        Category = "Main Course",
                        Price = 15.95m
                        },
            new MenuItem{
                        Name = "Chicken Alfredo",
                        Category = "Main Course",
                        Price = 13.95m
                        },
            new MenuItem{
                        Name = "Chicken Picatta",
                        Category = "Main Course",
                        Price = 13.95m
                        },
            new MenuItem{
                        Name = "Turkey Club",
                        Category = "Main Course",
                        Price = 11.95m
                        },
            new MenuItem{
                        Name = "Lobster Pie",
                        Category = "Main Course",
                        Price = 19.95m
                        },
            new MenuItem{
                        Name = "Prime Rib",
                        Category = "Main Course",
                        Price = 20.95m
                        },
            new MenuItem{
                        Name = "Shrimp Scampi",
                        Category = "Main Course",
                        Price = 18.95m
                        },
            new MenuItem{
                        Name = "Turkey Dinner",
                        Category = "Main Course",
                        Price = 13.95m
                        },
            new MenuItem{
                        Name = "Stuffed Chicken",
                        Category = "Main Course",
                        Price = 14.95m
                        } };

        /// <summary>
        /// List of MenuItem objects containing the available Desserts
        /// </summary>
        public List<MenuItem> Desserts = new List<MenuItem> {
            new MenuItem{
                        Name = "Apple Pie",
                        Category = "Dessert",
                        Price = 5.95m
                        },
            new MenuItem{
                        Name = "Sundae",
                        Category = "Dessert",
                        Price = 3.95m
                        },
            new MenuItem{
                        Name = "Carrot Cake",
                        Category = "Dessert",
                        Price = 5.95m
                        },
            new MenuItem{
                        Name = "Mud Pie",
                        Category = "Dessert",
                        Price = 4.95m
                        },
            new MenuItem{
                        Name = "Apple Crisp",
                        Category = "Dessert",
                        Price = 5.95m
                        },

        };

    }
}
