using BleakwindBuffet.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale
{
    public class MenuSelectionEvent : EventArgs
    {
        public IOrderItem fooditem;
    }
}
