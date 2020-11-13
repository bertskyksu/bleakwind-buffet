/*
* Author: Albert Winemiller
* Class name: IOrderItem.cs
* Purpose: This class represents a interface used the properies of certain food items
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;


namespace BleakwindBuffet.Data.Interface
{
    public interface IOrderItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The price for a food item
        /// </summary>
        double Price { get; } //i couldnt make these public for some reason

        /// <summary>
        /// The calories for a food item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// the special insturctions for a food item
        /// </summary>
        List<string> SpecialInstructions { get; }

        /// <summary>
        /// the description of a food item
        /// </summary>
        string Description { get; }

    }
}
