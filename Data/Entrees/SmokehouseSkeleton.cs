
/*
* Author: Albert Winemiller
* Class name: SmokehouseSkeleton.cs
* Purpose: This class represents the Entree Smokehouse Skeleton and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Smokehouse Skeleton and its customer order characteristics
    /// </summary>
    public class SmokehouseSkeleton : Entree, INotifyPropertyChanged
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
        public override double Price => 5.62;
        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        /// <value> The calories of the food item</value>
        public override uint Calories => 602;

        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool sausageLink = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool egg = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool hashBrowns = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this food customization
        /// </summary>
        private bool pancake = true;

        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the SausageLink is on or off the food item</value>
        public bool SausageLink
        {
            get
            {
                return this.sausageLink;
            }
            set
            {
                if (value != this.sausageLink)
                {
                    this.sausageLink = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Egg is on or off the food item</value>>
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
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the HashBrowns is on or off the food item</value>
        public bool HashBrowns
        {
            get
            {
                return this.hashBrowns;
            }
            set
            {
                if (value != this.hashBrowns)
                {
                    this.hashBrowns = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the food customization and checks if there were any changes 
        /// from the food Customization GUI controls 
        /// </summary>
        /// <value> If the Pancake is on or off the food item</value>
        public bool Pancake
        {
            get
            {
                return this.pancake;
            }
            set
            {
                if (value != this.pancake)
                {
                    this.pancake = value;
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
        /// <returns> the name of the food item </returns>
        public override string ToString()
        {
            return "Smokehouse Skeleton";
        }
    }
}
