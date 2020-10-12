
/*
* Author: Albert Winemiller
* Class name: ThalmorTriple.cs
* Purpose: This class represents the Entree Thalmor Triple and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Thalmor Triple and its customer order characteristics
    /// </summary>
    public class ThalmorTriple : Entree, INotifyPropertyChanged
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
        public override double Price => 8.32;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        /// <value> The calories of the food item</value>
        public override uint Calories => 943;

        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool bun = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool ketchup = true;

        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool mustard = true;

        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool pickle = true;

        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool cheese = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool tomato = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool lettuce = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool mayo = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool bacon = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool egg = true;

        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the bun is on or off the food item</value>
        public bool Bun
        {
            get
            {
                return this.bun;
            }
            set
            {
                if (value != this.bun)
                {
                    this.bun = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Ketchup is on or off the food item</value>
        public bool Ketchup
        {
            get
            {
                return this.ketchup;
            }
            set
            {
                if (value != this.ketchup)
                {
                    this.ketchup = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Mustard is on or off the food item</value>
        public bool Mustard
        {
            get
            {
                return this.mustard;
            }
            set
            {
                if (value != this.mustard)
                {
                    this.mustard = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Pickle is on or off the food item</value>
        public bool Pickle
        {
            get
            {
                return this.pickle;
            }
            set
            {
                if (value != this.pickle)
                {
                    this.pickle = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Cheese is on or off the food item</value>
        public bool Cheese
        {
            get
            {
                return this.cheese;
            }
            set
            {
                if (value != this.cheese)
                {
                    this.cheese = value;
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
        /// <value> If the lettuce is on or off the food item</value>
        public bool Lettuce
        {
            get
            {
                return this.lettuce;
            }
            set
            {
                if (value != this.lettuce)
                {
                    this.lettuce = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the mayo is on or off the food item</value>
        public bool Mayo
        {
            get
            {
                return this.mayo;
            }
            set
            {
                if (value != this.mayo)
                {
                    this.mayo = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Bacon is on or off the food item</value>>
        public bool Bacon
        {
            get
            {
                return this.bacon;
            }
            set
            {
                if (value != this.bacon)
                {
                    this.bacon = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Egg is on or off the food item</value>
        public bool Egg
        {
            get
            {
                return this.egg;
            }
            set
            {
                if (value != this.egg)
                {
                    this.egg = value;
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
        /// <returns> the name of the food item </returns>
        public override string ToString()
        {
            return "Thalmor Triple";
        }
    }
}
