
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
    class GardenOrcOmelette
    {
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        public double Price => 4.57;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        public uint Calories => 404;

        //this format makes the code shorter since we only need to declare the getter/setter on one line

        //All entrées override the ToString() function and return the name of the entrée. 
        //See the table of strings the respective ToString()
        /// <summary>
        /// This sets the default option of broccoli in the food item as true
        /// </summary>
        public bool Broccoli { get; set; } = true;
        /// <summary>
        /// This sets the default option of mushrooms in the food item as true
        /// </summary>
        public bool Mushrooms { get; set; } = true;
        /// <summary>
        /// This sets the default option of Tomatos in the food item as true
        /// </summary>
        public bool Tomato { get; set; } = true;
        /// <summary>
        /// This sets the default option of Cheddar cheese in the food item as true
        /// </summary>
        public bool Cheddar { get; set; } = true;

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
        public override string ToString()
        {
            return "Garden Orc Omelette";
        }
    }
}
