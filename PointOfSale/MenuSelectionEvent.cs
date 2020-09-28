/*
* Author: Albert Winemiller
* Class name: MenuSelectionEvent.cs
* Purpose: This class represents a event argument for a food item class
*/
using BleakwindBuffet.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale
{
    /// <summary>
    /// This class uses an Event argument for button pushes. This will allow the 
    /// MenuSelectionScreen class to pass an object through the event argument
    /// </summary>
    public class MenuSelectionEvent : EventArgs
    {
        public IOrderItem fooditem;
    }
}
