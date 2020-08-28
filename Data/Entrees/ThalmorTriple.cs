
/*
* Author: Albert Winemiller
* Class name: ThalmorTriple.cs
* Purpose: This class represents the Entree Thalmor Triple and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Thalmor Triple and its customer order characteristics
    /// </summary>
    class ThalmorTriple
    {
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        public double Price => 8.32;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        public uint Calories => 943;

        //this format makes the code shorter since we only need to declare the getter/setter on one line

        //All entrées override the ToString() function and return the name of the entrée. 
        //See the table of strings the respective ToString()
        /// <summary>
        /// This sets the default option of Buns in the food item as true
        /// </summary>
        public bool Bun { get; set; } = true; //complier makes it set to false initially. hard to access the hidden "backing field"
        /// <summary>
        /// This sets the default option of ketchup in the food item as true
        /// </summary>
        public bool Ketchup { get; set; } = true;
        /// <summary>
        /// This sets the default option of Mustard in the food item as true
        /// </summary>
        public bool Mustard { get; set; } = true;
        /// <summary>
        /// This sets the default option of pickles in the food item as true
        /// </summary>
        public bool Pickle { get; set; } = true;
        /// <summary>
        /// This sets the default option of Cheese in the food item as true
        /// </summary>
        public bool Cheese { get; set; } = true;
        /// <summary>
        /// This sets the default option of tomatos in the food item as true
        /// </summary>
        public bool Tomato { get; set; } = true;
        /// <summary>
        /// This sets the default option of Lettuce in the food item as true
        /// </summary>
        public bool Lettuce { get; set; } = true;
        /// <summary>
        /// This sets the default option of mayo in the food item as true
        /// </summary>
        public bool Mayo { get; set; } = true;
        /// <summary>
        /// This sets the default option of Bacon in the food item as true
        /// </summary>
        public bool Bacon { get; set; } = true;
        /// <summary>
        /// This sets the default option of Eggs in the food item as true
        /// </summary>
        public bool Egg { get; set; } = true;

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
                if (!Bun) instructions.Add("Hold bun");
                if (!Ketchup) instructions.Add("Hold ketchup");
                if (!Mustard) instructions.Add("Hold mustard");
                if (!Pickle) instructions.Add("Hold pickle");
                if (!Cheese) instructions.Add("Hold cheese");
                if (!Tomato) instructions.Add("Hold tomato");
                if (!Lettuce) instructions.Add("Hold lettuce");
                if (!Mayo) instructions.Add("Hold mayo");
                if (!Bacon) instructions.Add("Hold bacon");
                if (!Egg) instructions.Add("Hold egg");
                return instructions;
            }

        }
        /// <summary>
        /// all Entrees override the ToString() function and return the name of the Entree.
        /// </summary>
        public override string ToString()
        {
            return "Thalmor Triple";
        }
    }
}
