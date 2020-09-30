
/*
* Author: Albert Winemiller
* Class name: BriarheartBurger.cs
* Purpose: This class represents the Entree Briarheart Burger and its customer order characteristics
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// This class represents the Entree Briarheart Burger and its customer order characteristics
    /// </summary>
    public class BriarheartBurger : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// This implements the interface of INotifyPropertyChanged.
        /// Then invoke for each property
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks> If you use the CallerMemberName attribute, calls to the NotifyPropertyChanged method 
        /// don't have to specify the property name as a string argument requires "using System.Runtime.CompilerServices" ;  </remarks>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Sets the inital default price of the food item
        /// </summary>
        /// <value> The price of the food item</value>
        public override double Price => 6.32;

        /// <summary>
        /// Sets the inital default calories of the food item
        /// </summary>
        /// <value> The calories of the food item</value>
        public override uint Calories => 743;

        //this format makes the code shorter since we only need to declare the getter/setter on one line

        private bool bun = true;
        /// <summary>
        /// This sets the default option of Buns in the food item as true
        /// </summary>
        /// <value> If the bun is onor off the food item</value>
        public bool Bun
        {
            get
            {
                return this.bun;
            }
            set
            {
                if (value != this.bun)
                {
                    this.bun = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// private value required for this NotifyPropertyChanged
        /// </summary>
        private bool ketchup = true;
        
        /// <summary>
        /// This sets the default option of ketchup in the food item as true
        /// </summary>
        /// <value> If the Ketchup is on or off the food item</value>
        public bool Ketchup
        {
            get
            {
                return this.ketchup;
            }
            set
            {
                if (value != this.ketchup)
                {
                    this.ketchup = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// This sets the default option of Mustard in the food item as true
        /// </summary>
        /// <value> If the Mustard is on or off the food item</value>
        public bool Mustard { get; set; } = true;
        /// <summary>
        /// This sets the default option of pickles in the food item as true
        /// </summary>
        /// <value> If the Pickle is on or off the food item</value>
        public bool Pickle { get; set; } = true;
        /// <summary>
        /// This sets the default option of Cheese in the food item as true
        /// </summary>
        /// <value> If the Cheese is on or off the food item</value>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// adds any special food insturctions to the list if applicable and returns the list
        /// </summary>
        /// <returns> The list of special food instructions for the food item</returns>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Bun) instructions.Add("Hold bun");
                if (!Ketchup) instructions.Add("Hold ketchup");
                if (!Mustard) instructions.Add("Hold mustard");
                if (!Pickle) instructions.Add("Hold pickle");
                if (!Cheese) instructions.Add("Hold cheese");
                return instructions;
            }

        }
        /// <summary>
        /// all Entrees override the ToString() function and return the name of the Entree.
        /// </summary>
        /// <returns> the name of the food item </returns>
        public override string ToString()
        {
            return "Briarheart Burger";
        }
    }
}
