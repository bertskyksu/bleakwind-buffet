/*
* Author: Albert Winemiller
* Class name: ComboOrder.cs
* Purpose: This class represents a combination of all items included in the final order
*/
using BleakwindBuffet.Data.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace BleakwindBuffet.Data.Menu
{
    public class Ordering : INotifyPropertyChanged, INotifyCollectionChanged
    {
        //ICollection<IOrderItem> or build from scratch

        /// <summary>
        /// This implements the interface of INotifyPropertyChanged.
        /// Then invoke for each property
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This keeps track of the Collection of IOrderItems allowing us to use Add, Remove, Clear and to 
        /// Notify when items in our collection have changed
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// This list will hold all of the IOrderItems from ordering
        /// </summary>
        public List<IOrderItem> ListOrder = new List<IOrderItem>();

        /// <summary>
        /// a static ordernumber that does not belong to an instance of this class.
        /// keeps track of the number of orders in the class
        /// </summary>
        private static int nextOrderNumber = 1;

        /// <summary>
        /// the order number for the current instance of an order
        /// </summary>
        public int OrderNumber;

        /// <summary>
        /// The Constructor of the Ordering class where when a new instance of a Order is made it will increment the 
        /// number of the order for the next order.
        /// </summary>
        public Ordering() 
        {
            OrderNumber = nextOrderNumber;
            nextOrderNumber++;
        }


        /// <summary>
        /// This should add an IOrderItem to the list and Trigger property changed events
        /// </summary>
        /// <param name="item">A IOrderItem of a menu selection</param>
        public void Add(IOrderItem orderItem)
        {
            
            ListOrder.Add(orderItem);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, orderItem));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            orderItem.PropertyChanged += OrderItemChanged; // setup a event listener whenever the properties of the IOrderItem are changed
        }

        /// <summary>
        /// This should remove an IOrderItem to the list and Trigger property changed events. Also
        /// Removes the event listener to prevent memory leaks
        /// </summary>
        /// <param name="item"></param>
        public bool Remove(IOrderItem orderItem)
        {
            //bool check?
            if (ListOrder.Contains(orderItem))
            {
                var index = ListOrder.IndexOf(orderItem);
                ListOrder.Remove(orderItem);
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, orderItem, index));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
                orderItem.PropertyChanged -= OrderItemChanged;
                return true;
            }
            return false;   
        }

        /// <summary>
        /// Clears all IOrderItems from the list and removes the event listeners to prevent a memory leak
        /// </summary>
        public void Clear()
        {
            foreach (IOrderItem item in ListOrder)
            {
                item.PropertyChanged -= OrderItemChanged;
            }
            ((ICollection<IOrderItem>)ListOrder).Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
        }

        public void OrderItemChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
        }

        /// <summary>
        /// sets the tax rate for the total price of the order
        /// </summary>
        public double SalesTaxRate { get; set; } = 0.12;

        /// <summary>
        /// Sets the initial value of the subtotal. should be zero
        /// </summary>
        private double subtotal = 0;
        /// <summary>
        /// the total price for all items in the order
        /// </summary>
        public double Subtotal
        {
            get
            {
                subtotal = 0;
                foreach (IOrderItem a in ListOrder)
                {
                    subtotal += a.Price; //add up the price of each item in the order
                }
                subtotal = Math.Round(subtotal, 2);
                return subtotal;
            }
        }

        /// <summary>
        /// private value for the amount of tax needed for the order
        /// </summary>
        private double tax;
        /// <summary>
        /// tax of the order is the sum of subtotal * Tax rate
        /// </summary>
        public double Tax
        {
            get
            {
                tax = Math.Round((Subtotal * SalesTaxRate), 2);
                return tax;
            }
        }

        /// <summary>
        /// private value for the total price of the order
        /// </summary>
        private double total;
        /// <summary>
        /// total price of the order is the sum of Subtotal and Tax
        /// </summary>
        public double Total
        {
            get
            {
                total = Math.Round((Subtotal + Tax), 2);
                return total;
            }
        }

        /// <summary>
        /// private value for the calories of the total order
        /// </summary>
        private uint calories;
        /// <summary>
        /// sum of all calories of all items in the entire order
        /// </summary>
        public uint Calories
        {
            get
            {
                calories = 0;
                foreach(IOrderItem a in ListOrder)
                {
                    calories += a.Calories;
                }
                
                return calories;
            }
        }

        
        
    }
}
