
/*
* Author: Albert Winemiller
* Class name: PhillyPoacher.cs
* Purpose: This class represents the Entree Philly Poacher and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Philly Poacher and its customer order characteristics
    /// </summary>
    public class PhillyPoacher : Entree, INotifyPropertyChanged
    {

        /*
        /// <summary>
        /// This implements the interface of INotifyPropertyChanged.
        /// Then invoke for each property
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This will Notify that a property for this food item has changed and invoke the 
        /// </summary>
        /// <remarks> If you use the CallerMemberName attribute, calls to the NotifyPropertyChanged method 
        /// don't have to specify the property name as a string argument requires "using System.Runtime.CompilerServices" ;  </remarks>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }*/
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
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool sirloin = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool onion = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool roll = true;

        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Sirloin is on or off the food item</value>
        public bool Sirloin
        {
            get
            {
                return this.sirloin;
            }
            set
            {
                if (value != this.sirloin)
                {
                    this.sirloin = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Onion is on or off the food item</value>
        public bool Onion
        {
            get
            {
                return this.onion;
            }
            set
            {
                if (value != this.onion)
                {
                    this.onion = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Roll is on or off the food item</value>
        public bool Roll
        {
            get
            {
                return this.roll;
            }
            set
            {
                if (value != this.roll)
                {
                    this.roll = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
