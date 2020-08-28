
/*
* Author: Albert Winemiller
* Class name: MarkarthMilk.cs
* Purpose: This class represents the Drink Markarth Milk and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// This class represents the Drink Markarth Milk and its customer order characteristics
    /// </summary>
    class MarkarthMilk
    {

        /// <summary>
        /// This gets the Size of the food item and sets it to an inital value of Small
        /// </summary>
        public Size Size { get; set; } = Size.Small; //default small
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        private double price = 1.05; //default will be "small" price
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
                    price = 1.22;
                }
                else if (Size == Size.Medium)
                {
                    price = 1.11;
                }
                else
                {
                    price = 1.05; //Size.small
                }
            }
        }
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        private uint calories = 56; //default will be "small" price
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
                    calories = 93;
                }
                else if (Size == Size.Medium)
                {
                    calories = 72;
                }
                else
                {
                    calories = 56; //Size.small
                }
            }
        }
        /// <summary>
        /// This sets the default option of Ice in the food item as false
        /// </summary>
        public bool Ice { get; set; } = false; //complier makes it set to false initially. hard to access the hidden "backing field"

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
                if (Ice) instructions.Add("Add ice"); //add ice if true

                return instructions;
            }

        }
        /// <summary>
        /// all Drinks override the ToString() function and return the name of the drink.
        /// </summary>
        public override string ToString()
        {
            return $"{Size} Markarth Milk";
            
        }
    }
}
