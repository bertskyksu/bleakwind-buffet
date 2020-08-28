
/*
* Author: Albert Winemiller
* Class name: SmokehouseSkeleton.cs
* Purpose: This class represents the Entree Smokehouse Skeleton and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Smokehouse Skeleton and its customer order characteristics
    /// </summary>
    class SmokehouseSkeleton
    {
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        public double Price => 5.62;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        public uint Calories => 602;

        //this format makes the code shorter since we only need to declare the getter/setter on one line

        //All entrées override the ToString() function and return the name of the entrée. 
        //See the table of strings the respective ToString()
        /// <summary>
        /// This sets the default option of Sausage links in the food item as true
        /// </summary>
        public bool SausageLink { get; set; } = true;
        /// <summary>
        /// This sets the default option of eggs in the food item as true
        /// </summary>
        public bool Egg { get; set; } = true;
        /// <summary>
        /// This sets the default option of hash browns in the food item as true
        /// </summary>
        public bool HashBrowns { get; set; } = true;
        /// <summary>
        /// This sets the default option of pancakes in the food item as true
        /// </summary>
        public bool Pancake { get; set; } = true;

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
                if (!SausageLink) instructions.Add("Hold sausage");
                if (!Egg) instructions.Add("Hold egg");
                if (!HashBrowns) instructions.Add("Hold hash browns");
                if (!Pancake) instructions.Add("Hold pancakes");

                return instructions;
            }

        }
        /// <summary>
        /// all Entrees override the ToString() function and return the name of the Entree.
        /// </summary>
        public override string ToString()
        {
            return "Smokehouse Skeleton";
        }
    }
}
