
/*
* Author: Albert Winemiller
* Class name: ThugsTBone.cs
* Purpose: This class represents the Entree Thugs T-Bone
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Thugs T-Bone
    /// </summary>
    class ThugsTBone
    {
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        public double Price => 6.44;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        public uint Calories => 982;
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
                //returns empty list
                return instructions;
            }

        }
        /// <summary>
        /// all Entrees override the ToString() function and return the name of the Entree.
        /// </summary>
        public override string ToString()
        {
            return "Thugs T-Bone";
        }
    }
}
