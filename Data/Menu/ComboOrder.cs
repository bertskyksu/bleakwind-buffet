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
        /// private entree if we wanted to set and initial value of the Entree
        /// </summary>
        private Entree entree;
        /// <summary>
        /// The Entree of the ComboOrder. When the Entree changes it will notify the properties: Entree, Price, Calories, and
        /// SpecialInstructions so that these changes will be reflected on the comboorder throughout the program
        /// </summary>
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
                    entree.PropertyChanged += NotifyComboChanges; //(correction ???)
                }
            }
        }

        /// <summary>
        /// private drink if we wanted to set and initial value of the drink
        /// </summary>
        private Drink drink;
        /// <summary>
        /// The Drink of the ComboOrder. When the Drink changes it will notify the properties: Drink, Price, Calories, and
        /// SpecialInstructions so that these changes will be reflected on the ComboOrder throughout the program
        /// </summary>
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
                    NotifyPropertyChanged(); //changes property of drink
                    NotifyPropertyChanged("Price");
                    NotifyPropertyChanged("Calories");
                    NotifyPropertyChanged("SpecialInstructions");
                    drink.PropertyChanged += NotifyComboChanges; //(correction ???)
                }
            }
        }

        /// <summary>
        /// private side if we wanted to set and initial value of the side
        /// </summary>
        private Side side;
        /// <summary>
        /// The Side of the ComboOrder. When the Side changes it will notify the properties: Side, Price, Calories, and
        /// SpecialInstructions so that these changes will be reflected on the ComboOrder throughout the program
        /// </summary>
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
                    side.PropertyChanged += NotifyComboChanges; //(correction ???)
                }
            }
        }

        /// <summary>
        /// private price if we wanted to set the initial value of a price. not that it would be useful
        /// </summary>
        private double price;
        /// <summary>
        /// This combines the prices of the Entree, Drink, and Side of the ComboOrder to get the total price of the Combo.
        /// The price is also discounted by $1.00 for making the Combo.
        /// </summary>
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
        /// <summary>
        /// This combines the calories of the Entree, Drink, and Side of the ComboOrder to get the total calories of the Combo.
        /// </summary>
        public uint Calories
        {
            get
            {
                return Side.Calories + Entree.Calories + Drink.Calories;
            }
           
        }

        /// <summary>
        /// This combines the descriptions of all all 3 items in the combo
        /// </summary>
        public string Description
        {
            get
            {
                return Side.Description + Entree.Description + Drink.Description;
            }
        }

        /// <summary>
        /// This combines the Special Instructions of the Entree, Drink, and Side of the ComboOrder to get the combined string list
        /// of the entire combo.
        /// </summary>
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
