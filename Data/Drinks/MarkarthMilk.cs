
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
    public class MarkarthMilk
    {

        /// <summary>
        /// This gets the Size of the food item and sets it to an inital value of Small
        /// </summary>
        /// <value> The Size of the food item</value>
        public Size Size { get; set; } = Size.Small; //default small

        /// <summary>
        /// This will update the price of the food item based on the order size for the customer
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the Price for the size is not known 
        /// </exception>
        /// <returns> The price of the food item</returns>
        public double Price
        {
            get
            {
                if (Size == Size.Large)
                {
                    return 1.22;
                }
                else if (Size == Size.Medium)
                {
                    return 1.11;
                }
                else if (Size == Size.Small)
                {
                    return 1.05;
                }
                else throw new NotImplementedException("unknown size");
            }
        }

        /// <summary>
        /// This will update the calories of the food item based on the order size for the customer
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the Calories for the size is not known 
        /// </exception>
        /// <returns> the calories of the food item </returns>
        public uint Calories
        {
            get
            {
                if (Size == Size.Large)
                {
                    return 93;
                }
                else if (Size == Size.Medium)
                {
                    return 72;
                }
                else if (Size == Size.Small)
                {
                    return 56; //Size.small
                }
                else throw new NotImplementedException("unknown size");
            }
        }
        /// <summary>
        /// This sets the default option of Ice in the food item as false
        /// </summary>
        /// <value>if Ice is in the food item or not</value>
        public bool Ice { get; set; } = false; //complier makes it set to false initially. hard to access the hidden "backing field"

        /// <summary>
        /// adds any special food insturctions to the list if applicable and returns the list
        /// </summary>
        /// <returns> The list of special food instructions for the food item</returns>
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
        /// <returns> the name of the food item and size description if applicable </returns>
        public override string ToString()
        {
            return $"{Size} Markarth Milk";
            
        }
    }
}
