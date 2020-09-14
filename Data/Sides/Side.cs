/*
* Author: Albert Winemiller
* Class name: Side.cs
* Purpose: This class represents the characteristics of some of the properties for sides
*/
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.Data.Sides
{
    public abstract class Side : IOrderItem
    {
        /// <summary>
        /// The size of the Entree. 
        /// </summary>
        public virtual Size Size { get; set; } //complier is creating this for us

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
        /// In calories
        /// </value>
        public abstract uint Calories { get; }

        /// <summary>
        /// A list of special instructions for the Entree
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
