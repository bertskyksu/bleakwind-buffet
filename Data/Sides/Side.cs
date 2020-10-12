/*
* Author: Albert Winemiller
* Class name: Side.cs
* Purpose: This class represents the characteristics of some of the properties for sides
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.Data.Sides
{
    public abstract class Side : IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// This implements the interface of INotifyPropertyChanged.
        /// Then invoke for each property
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This will Notify that a property for this food item has changed and invoke the property
        /// </summary>
        /// <remarks> If you use the CallerMemberName attribute, calls to the NotifyPropertyChanged method 
        /// don't have to specify the property name as a string argument requires "using System.Runtime.CompilerServices" ;  </remarks>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        { //we want this protected so only the derived classes can access this
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// The size of the Entree. 
        /// </summary>
        public virtual Size Size { get; set; }

        /// <summary>
        /// The price of the Entree
        /// </summary>
        /// <value>
        /// In US Dollars
        /// </value>
        public abstract double Price { get; }

        /// <summary>
        /// The calories of the Entree
        /// </summary>
        /// <value>
        /// In calories
        /// </value>
        public abstract uint Calories { get; }

        /// <summary>
        /// A list of special instructions for the Entree
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
