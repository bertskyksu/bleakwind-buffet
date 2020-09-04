
/*
* Author: Albert Winemiller
* Class name: FriedMiraak.cs
* Purpose: This class represents the side Fried Miraak and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// This class represents the side Fried Miraak and its customer order characteristics
    /// </summary>
    public class FriedMiraak
    {
        /// <summary>
        /// This gets the Size of the food item and sets it to an inital value of Small
        /// </summary>
        public Size Size { get; set; } = Size.Small; //default small
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        private double price = 1.78; //default will be "small" price
        /// <summary>
        /// This will update the price of the food item based on the order size for the customer
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (Size == Size.Large)
                {
                    price = 2.88;
                }
                else if (Size == Size.Medium)
                {
                    price = 2.01;
                }
                else
                {
                    price = 1.78; //Size.small
                }
            }
        }
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        private uint calories = 151; //default will be "small" price
        /// <summary>
        /// This will update the calories of the food item based on the order size for the customer
        /// </summary>
        public uint Calories
        {
            get
            {
                return calories;
            }
            set
            {
                if (Size == Size.Large)
                {
                    calories = 306;
                }
                else if (Size == Size.Medium)
                {
                    calories = 236;
                }
                else
                {
                    calories = 151; //Size.small
                }
            }
        }
        /// <summary>
        /// makes a new empty list for any special food insturctions from the customer
        /// </summary>
        private List<string> specialInstructions = new List<string>();//backing variable
        /// <summary>
        /// adds any special food insturctions to the list if applicable and returns the list
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();

                return instructions; //return empty list
            }

        }

        /// <summary>
        /// all sides override the ToString() function and return the name of the side.
        /// </summary>
        public override string ToString()
        {
            return $"{Size} Fried Miraak";

        }
    }
}
