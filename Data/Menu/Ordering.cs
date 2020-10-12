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

        public event PropertyChangedEventHandler PropertyChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

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

        public Ordering() 
        {
            OrderNumber = nextOrderNumber;
            nextOrderNumber++;
        }


        /// <summary>
        /// This should add an IOrderItem to the list and Trigger property changed events
        /// </summary>
        /// <param name="item"></param>
        public void Add(IOrderItem orderItem)
        {
            
            ListOrder.Add(orderItem);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, orderItem));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            orderItem.PropertyChanged += OrderItemChanged;
        }

        /// <summary>
        /// This should remove an IOrderItem to the list and Trigger property changed events
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

        public void Clear()
        {
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


        public double SalesTaxRate { get; set; } = 0.12;

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
                    subtotal += a.Price;
                }
                subtotal = Math.Round(subtotal, 2);
                return subtotal;
            }
        }

        private double tax;
        /// <summary>
        /// sum of subtotal * Tax rate
        /// </summary>
        public double Tax
        {
            get
            {
                tax = Math.Round((Subtotal * SalesTaxRate), 2);
                return tax;
            }
        }

        private double total;
        /// <summary>
        /// sum of Subtotal and Tax
        /// </summary>
        public double Total
        {
            get
            {
                total = Math.Round((Subtotal + Tax), 2);
                return total;
            }
        }

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
