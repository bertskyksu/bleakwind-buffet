
/*
* Author: Albert Winemiller
* Class name: GardenOrcOmelette.cs
* Purpose: This class represents the Entree Garden Orc Omelette and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Garden Orc Omelette and its customer order characteristics
    /// </summary>
    public class GardenOrcOmelette : Entree
    {
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        /// <value> The price of the food item</value>
        public override double Price => 4.57;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        /// <value> The calories of the food item</value>
        public override uint Calories => 404;

        /// <summary>
        /// This sets the default option of broccoli in the food item as true
        /// </summary>
        /// <value> If the Broccoli is on or off the food item</value>
        public bool Broccoli { get; set; } = true;
        /// <summary>
        /// This sets the default option of mushrooms in the food item as true
        /// </summary>
        /// <value> If the Mushrooms is on or off the food item</value>
        public bool Mushrooms { get; set; } = true;
        /// <summary>
        /// This sets the default option of Tomatos in the food item as true
        /// </summary>
        /// <value> If the Tomato is on or off the food item</value>
        public bool Tomato { get; set; } = true;
        /// <summary>
        /// This sets the default option of Cheddar cheese in the food item as true
        /// </summary>
        /// <value> If the Cheddar is on or off the food item</value>
        public bool Cheddar { get; set; } = true;

        /// <summary>
        /// adds any special food insturctions to the list if applicable and returns the list
        /// </summary>
        /// <returns> The list of special food instructions for the food item</returns>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Broccoli) instructions.Add("Hold broccoli");
                if (!Mushrooms) instructions.Add("Hold mushrooms");
                if (!Tomato) instructions.Add("Hold tomato");
                if (!Cheddar) instructions.Add("Hold cheddar");

                return instructions;
            }

        }
        /// <summary>
        /// all Entrees override the ToString() function and return the name of the Entree.
        /// </summary>
        /// <returns> the name of the food item </returns>
        public override string ToString()
        {
            return "Garden Orc Omelette";
        }
    }
}
