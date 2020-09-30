
/*
* Author: Albert Winemiller
* Class name: GardenOrcOmelette.cs
* Purpose: This class represents the Entree Garden Orc Omelette and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Garden Orc Omelette and its customer order characteristics
    /// </summary>
    public class GardenOrcOmelette : Entree, INotifyPropertyChanged
    {

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
        }
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
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool broccoli = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool mushrooms = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool tomato = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool cheddar = true;


        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Broccoli is on or off the food item</value>
        public bool Broccoli
        {
            get
            {
                return this.broccoli;
            }
            set
            {
                if (value != this.broccoli)
                {
                    this.broccoli = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Mushrooms is on or off the food item</value>
        public bool Mushrooms
        {
            get
            {
                return this.mushrooms;
            }
            set
            {
                if (value != this.mushrooms)
                {
                    this.mushrooms = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Tomato is on or off the food item</value>
        public bool Tomato
        {
            get
            {
                return this.tomato;
            }
            set
            {
                if (value != this.tomato)
                {
                    this.tomato = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Cheddar is on or off the food item</value>
        public bool Cheddar
        {
            get
            {
                return this.cheddar;
            }
            set
            {
                if (value != this.cheddar)
                {
                    this.cheddar = value;
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
