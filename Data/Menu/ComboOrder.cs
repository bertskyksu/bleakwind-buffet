/*
* Author: Albert Winemiller
* Class name: ComboOrder.cs
* Purpose: This class represents a combination of a Entree, Drink, and Side
*/
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Interface;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BleakwindBuffet.Data.Menu
{
    public class ComboOrder: IOrderItem, INotifyPropertyChanged
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
        /// The constructor of combo order setting its values for a entree, drink, and side
        /// </summary>
        /// <param name="e"></param>
        /// <param name="s"></param>
        /// <param name="d"></param>
        public ComboOrder(Entree e, Side s, Drink d)
        {
            Entree = e;
            Side = s;
            Drink = d;
            Drink.PropertyChanged += NotifyComboChanges;
            Entree.PropertyChanged += NotifyComboChanges;
            Side.PropertyChanged += NotifyComboChanges;
        }

        /// <summary>
        /// This will help during a case when size changes but 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NotifyComboChanges(object sender, PropertyChangedEventArgs e)
        {
            //e.PropertyName
            NotifyPropertyChanged();
            NotifyPropertyChanged("Price");
            NotifyPropertyChanged("Calories");
            NotifyPropertyChanged("SpecialInstructions");
            //var foodItem = e.GetType(); 
            //foodItem.PropertyChanged -= NotifyComboChanges;
            this.PropertyChanged -= NotifyComboChanges; //
        }

       
        /// <summary>
        /// private instance
        /// </summary>
        private Entree entree;
        public Entree Entree
        {
            get
            {
                return this.entree;
            }
            set
            {
                if (value != this.entree)
                {
                    this.entree = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("Price");
                    NotifyPropertyChanged("Calories");
                    NotifyPropertyChanged("SpecialInstructions");
                }
            }
        }

        private Drink drink;
        public Drink Drink
        {
            get
            {

                return this.drink;
            }
            set
            {
                if (value != this.drink)
                {
                    this.drink = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("Price");
                    NotifyPropertyChanged("Calories");
                    NotifyPropertyChanged("SpecialInstructions");
                }
            }
        }

        private Side side;
        public Side Side
        {
            get
            {

                return this.side;
            }
            set
            {
                if (value != this.side)
                {
                    this.side = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("Price");
                    NotifyPropertyChanged("Calories");
                    NotifyPropertyChanged("SpecialInstructions");
                }
            }
        }

        private double price;
        public double Price
        {
            //include the $1 discount
            get
            {
                price = (Side.Price + Entree.Price + Drink.Price) - 1.00;
                price = Math.Round(price, 2); //had issues with decimals
                return price;
            }
            
        }

        //private uint calories;
        public uint Calories
        {
            get
            {
                return Side.Calories + Entree.Calories + Drink.Calories;
            }
           
        }

        //private List<string> specialInstructions;

        public List<string> SpecialInstructions
        {
            get
            {
                //combine special instructions
                List<string> specialInstructions = new List<string>();
                specialInstructions.Add(Entree.ToString());
                specialInstructions.AddRange(Entree.SpecialInstructions);
                specialInstructions.Add(Drink.ToString());
                specialInstructions.AddRange(Drink.SpecialInstructions);
                specialInstructions.Add(Side.ToString());
                specialInstructions.AddRange(Side.SpecialInstructions);
                return specialInstructions;
            }
            
        }
    }
}
