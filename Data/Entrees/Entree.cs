/*
* Author: Albert Winemiller
* Class name: Entree.cs
* Purpose: This class represents the characteristics of some of the properties for Entrees
*/
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.Data.Entrees
{
    public abstract class Entree : IOrderItem
    {
        /// <summary>
        /// The price of the Entree
        /// </summary>
        /// <value>
        /// In US Dollars
        /// </value>
        public abstract double Price { get; }

        /// <summary>
        /// The calories of the Entree
        /// </summary>
        /// <value>
        /// units in calories
        /// </value>
        public abstract uint Calories { get; }

        /// <summary>
        /// A list of special instructions for the Entrees
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
