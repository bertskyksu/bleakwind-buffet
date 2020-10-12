﻿
/*
* Author: Albert Winemiller
* Class name: WarriorWater.cs
* Purpose: This class represents the Drink Warrior Water and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// This class represents the Drink Warrior Water and its customer order characteristics
    /// </summary>
    public class WarriorWater : Drink, INotifyPropertyChanged
    {

        /// <summary>
        /// This implements the interface of INotifyPropertyChanged.
        /// Then invoke for each property
        /// </summary>
        //public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This will Notify that a property for this food item has changed and invoke the 
        /// </summary>
        /// <remarks> If you use the CallerMemberName attribute, calls to the NotifyPropertyChanged method 
        /// don't have to specify the property name as a string argument requires "using System.Runtime.CompilerServices" ;  </remarks>
        /// <param name="propertyName"></param>
        /*private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }*/
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// size property of this drink customization
        /// </summary>
        private Size size = Size.Small;
        /// <summary>
        /// This sets the drink customization size and checks if there were any changes 
        /// from the drink Customization size GUI controls 
        /// </summary>
        /// <value> size is small,medium, or large</value>
        public override Size Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value != this.size)
                {
                    this.size = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("Price");
                    NotifyPropertyChanged("Calories");
                }
            }
        }

        /// <summary>
        /// This will update the price of the food item based on the order size for the customer
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the Price for the size is not known 
        /// </exception>
        /// <returns> The price of the food item</returns>
        public override double Price
        {
            get
            {
                if (Size == Size.Large)
                {
                    return 0;
                }
                else if (Size == Size.Medium)
                {
                    return 0;
                }
                else if (Size == Size.Small)
                {
                    return 0;
                }
                else throw new NotImplementedException("unknown size");
            }
        }

        /// <summary>
        /// This will update the calories of the food item based on the order size for the customer
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// Thrown if the Calories for the size is not known 
        /// </exception>
        /// <returns> the calories of the food item </returns>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Large)
                {
                    return 0;
                }
                else if (Size == Size.Medium)
                {
                    return 0;
                }
                else if (Size == Size.Small)
                {
                    return 0; //Size.small
                }
                else throw new NotImplementedException("unknown size");
            }
        }

        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this drink customization
        /// </summary>
        private bool ice = true;
        /// <summary>
        /// private value required for this NotifyPropertyChanged and to set the default
        /// bool property of this drink customization
        /// </summary>
        private bool lemon = false;

        /// <summary>
        /// This sets the drink customization and checks if there were any changes 
        /// from the drink Customization GUI controls 
        /// </summary>
        /// <value> If the Ice is on or off the drink item</value>
        public bool Ice
        {
            get
            {
                return this.ice;
            }
            set
            {
                if (value != this.ice)
                {
                    this.ice = value;
                    NotifyPropertyChanged();
                }
            }
        }


        /// <summary>
        /// This sets the drink customization and checks if there were any changes 
        /// from the drink Customization GUI controls 
        /// </summary>
        /// <value> If the Lemon is on or off the drink item</value>
        public bool Lemon
        {
            get
            {
                return this.lemon;
            }
            set
            {
                if (value != this.lemon)
                {
                    this.lemon = value;
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
                if (!Ice) instructions.Add("Hold ice"); 
                if (Lemon) instructions.Add("Add lemon");

                return instructions;
            }
        }

        /// <summary>
        /// all Drinks override the ToString() function and return the name of the drink.
        /// </summary>
        /// <returns> the name of the food item and size description if applicable </returns>
        public override string ToString()
        {
            return $"{Size} Warrior Water";

        }
    }
}
