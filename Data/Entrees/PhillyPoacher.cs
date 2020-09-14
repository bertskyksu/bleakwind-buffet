
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
    public class PhillyPoacher : Entree
    {
        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        /// <value> The price of the food item</value>
        public override double Price => 7.23;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        /// <value> The calories of the food item</value>
        public override uint Calories => 784;
        /// <summary>
        /// This sets the default option of Sirloin in the food item as true
        /// </summary>
        /// <value> If the Sirloin is onor off the food item</value>
        public bool Sirloin { get; set; } = true;
        /// <summary>
        /// This sets the default option of onion in the food item as true
        /// </summary>
        /// <value> If the Onion is onor off the food item</value>
        public bool Onion { get; set; } = true;
        /// <summary>
        /// This sets the default option of a Roll in the food item as true
        /// </summary>
        /// <value> If the Roll is onor off the food item</value>
        public bool Roll { get; set; } = true;

        /// <summary>
        /// adds any special food insturctions to the list if applicable and returns the list
        /// </summary>
        /// <returns> The list of special food instructions for the food item</returns>
        public override List<string> SpecialInstructions
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
        /// <returns> the name of the food item </returns>
        public override string ToString()
        {
            return "Philly Poacher";
        }
    }
}
