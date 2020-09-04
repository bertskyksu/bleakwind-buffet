
/*
* Author: Albert Winemiller
* Class name: PhillyPoacher.cs
* Purpose: This class represents the Entree Philly Poacher and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Philly Poacher and its customer order characteristics
    /// </summary>
    public class PhillyPoacher
    {
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        public double Price => 7.23;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        public uint Calories => 784;

        //this format makes the code shorter since we only need to declare the getter/setter on one line

        //All entrées override the ToString() function and return the name of the entrée. 
        //See the table of strings the respective ToString()
        /// <summary>
        /// This sets the default option of Sirloin in the food item as true
        /// </summary>
        public bool Sirloin { get; set; } = true;
        /// <summary>
        /// This sets the default option of onion in the food item as true
        /// </summary>
        public bool Onion { get; set; } = true;
        /// <summary>
        /// This sets the default option of a Roll in the food item as true
        /// </summary>
        public bool Roll { get; set; } = true;

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
                if (!Sirloin) instructions.Add("Hold sirloin");
                if (!Onion) instructions.Add("Hold onions");
                if (!Roll) instructions.Add("Hold roll");

                return instructions;
            }

        }
        /// <summary>
        /// all Entrees override the ToString() function and return the name of the Entree.
        /// </summary>
        public override string ToString()
        {
            return "Philly Poacher";
        }
    }
}
