/*
* Author: Albert Winemiller
* Class name: Drinks.cs
* Purpose: This class represents the characteristics of some of the properties for Drinks
*/
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// A base class representing the common properties of drinks
    /// </summary>
    public abstract class Drink : IOrderItem
    {
        /// <summary>
        /// The size of the drink. 
        /// </summary>
        public virtual Size Size { get; set; } //complier is creating this for us

        /// <summary>
        /// The price of the drink
        /// </summary>
        /// <value>
        /// In US Dollars
        /// </value>
        public abstract double Price { get; }

        /// <summary>
        /// The calories of the drink
        /// </summary>
        /// <value>
        /// In calories
        /// </value>
        public abstract uint Calories { get; }

        /// <summary>
        /// A list of special instructions for the Drinks
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
