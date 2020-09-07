/*
* Author: Albert Winemiller
* Class name: CandlehearthCoffee.cs
* Purpose: This class represents the Drink Candlehearth Coffee and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// This class represents the Drink Candlehearth Coffee and its customer order characteristics
    /// </summary>
    public class CandlehearthCoffee
    {

        /// <summary>
        /// This gets the Size of the food item and sets it to an inital value of Small
        /// </summary>
        public Size Size { get; set; } = Size.Small; //default small
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        private double price = 0.75; //default will be "small" price
        /// <summary>
        /// This will update the price of the food item based on the order size for the customer
        /// </summary>
        public double Price
        {
            get
            {
                if (Size == Size.Large)
                {
                    return 1.75;
                }
                else if (Size == Size.Medium)
                {
                    return 1.25;
                }
                else
                {
                    return 0.75; //Size.small
                }
            }
        }
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        private uint calories = 7; //default will be "small" price
        /// <summary>
        /// This will update the calories of the food item based on the order size for the customer
        /// </summary>
        public uint Calories
        {
           
            get
            {
                if (Size == Size.Large)
                {
                    return 20;
                }
                else if (Size == Size.Medium)
                {
                    return 10;
                }
                else
                {
                    return 7; //Size.small
                }
            }
        }
        /// <summary>
        /// This sets the default option of Ice in the food item as false
        /// </summary>
        public bool Ice { get; set; } = false; //complier makes it set to false initially. hard to access the hidden "backing field"
        /// <summary>
        /// This sets the default option of cream in the food item as false
        /// </summary>
        public bool RoomForCream { get; set; } = false;
        /// <summary>
        /// This sets the default option of Decaf in the food item as false
        /// </summary>
        public bool Decaf { get; set; } = false;

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
                if (RoomForCream) instructions.Add("Add cream");

                return instructions;
            }

        }

        /// <summary>
        /// all Drinks override the ToString() function and return the name of the drink.
        /// </summary>
        public override string ToString()
        {
            if (Decaf)
            {
                return $"{Size} Decaf Candlehearth Coffee";
            }
            else
            {
                return $"{Size} Candlehearth Coffee";
            }
        }
    }
}
