
/*
* Author: Albert Winemiller
* Class name: VokunSalad.cs
* Purpose: This class represents the side Vokun Salad and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// This class represents the side Vokun Salad and its customer order characteristics
    /// </summary>
    public class VokunSalad
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
                    return 1.82;
                }
                else if (Size == Size.Medium)
                {
                    return 1.28;
                }
                else if (Size == Size.Small)
                {
                    return 0.93; //Size.small
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
                    return 73;
                }
                else if (Size == Size.Medium)
                {
                    return 52;
                }
                else if (Size == Size.Small)
                {
                    return 41; //Size.small
                }
                else throw new NotImplementedException("unknown size");
            }
        }

        /// <summary>
        /// adds any special food insturctions to the list if applicable and returns the list
        /// </summary>
        /// <returns> an empty list of instructions</returns>
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
        /// <returns> the name of the food item and size description if applicable </returns>
        public override string ToString()
        {
            return $"{Size} Vokun Salad";

        }
    }
}
