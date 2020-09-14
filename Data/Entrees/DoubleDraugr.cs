
/*
* Author: Albert Winemiller
* Class name: DoubleDraugr.cs
* Purpose: This class represents the Entree Double Draugr and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Double Draugr and its customer order characteristics
    /// </summary>
    public class DoubleDraugr : Entree
    {
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        /// <value> The price of the food item</value>
        public override double Price => 7.32;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        /// <value> The calories of the food item</value>
        public override uint Calories => 843;

        /// <summary>
        /// This sets the default option of Buns in the food item as true
        /// </summary>
        /// <value> If the bun is on or off the food item</value>
        public bool Bun { get; set; } = true; //complier makes it set to false initially. hard to access the hidden "backing field"
        /// <summary>
        /// This sets the default option of ketchup in the food item as true
        /// </summary>
        /// <value> If the Ketchup is on or off the food item</value>
        public bool Ketchup { get; set; } = true;
        /// <summary>
        /// This sets the default option of Mustard in the food item as true
        /// </summary>
        /// <value> If the Mustard is on or off the food item</value>
        public bool Mustard { get; set; } = true;
        /// <summary>
        /// This sets the default option of pickles in the food item as true
        /// </summary>
        /// <value> If the Pickle is on or off the food item</value>
        public bool Pickle { get; set; } = true;
        /// <summary>
        /// This sets the default option of Cheese in the food item as true
        /// </summary>
        /// <value> If the Cheese is on or off the food item</value>
        public bool Cheese { get; set; } = true;
        /// <summary>
        /// This sets the default option of tomatos in the food item as true
        /// </summary>
        /// <value> If the Tomato is on or off the food item</value>
        public bool Tomato { get; set; } = true;
        /// <summary>
        /// This sets the default option of Lettuce in the food item as true
        /// </summary>
        /// <value> If the Lettuce is on or off the food item</value>
        public bool Lettuce { get; set; } = true;

        /// <summary>
        /// This sets the default option of Mayo in the food item as true
        /// </summary>
        /// <value> If the Mayo is on or off the food item</value>
        public bool Mayo { get; set; } = true;

        /// <summary>
        /// adds any special food insturctions to the list if applicable and returns the list
        /// </summary>
        /// <returns> The list of special food instructions for the food item</returns>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Bun) instructions.Add("Hold bun");
                if (!Ketchup) instructions.Add("Hold ketchup");
                if (!Mustard) instructions.Add("Hold mustard");
                if (!Pickle) instructions.Add("Hold pickle");
                if (!Cheese) instructions.Add("Hold cheese");
                if (!Tomato) instructions.Add("Hold tomato");
                if (!Lettuce) instructions.Add("Hold lettuce");
                if (!Mayo) instructions.Add("Hold mayo");

                return instructions;
            }

        }

        /// <summary>
        /// all Entrees override the ToString() function and return the name of the Entree.
        /// </summary>
        /// <returns> the name of the food item </returns>
        public override string ToString()
        {
            return "Double Draugr";
        }
    }
}
