
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
    public class FriedMiraak : Side
    {
        /// <summary>
        /// This gets the Size of the food item and sets it to an inital value of Small
        /// </summary>
        /// <value> The Size of the food item</value>
        public override Size Size { get; set; } = Size.Small; //default small
        /// <summary>
        /// This will update the price of the food item based on the order size for the customer
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the Price for the size is not known 
        /// </exception>
        /// <returns> The price of the food item</returns>
        public override double Price
        {
            get
            {
                if (Size == Size.Large)
                {
                    return 2.88;
                }
                else if (Size == Size.Medium)
                {
                    return 2.01;
                }
                else if (Size == Size.Small)
                {
                    return 1.78; //Size.small
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
        public override uint Calories
        {
            get
            {
                if (Size == Size.Large)
                {
                    return 306;
                }
                else if (Size == Size.Medium)
                {
                    return 236;
                }
                else if (Size == Size.Small)
                {
                    return 151; //Size.small
                }
                else throw new NotImplementedException("unknown size");
            }
        }

        /// <summary>
        /// adds any special food insturctions to the list if applicable and returns the list
        /// </summary>
        /// <returns> an empty list of instructions</returns>
        public override List<string> SpecialInstructions
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
            return $"{Size} Fried Miraak";

        }
    }
}
