/*
* Author: Albert Winemiller
* Class name: NumberBox.xaml.cs
* Purpose: This class represents A gui of buttons and counters used for keeping track of the amount of currency and type
* that a customer gives to the cashier to pay for their order
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointOfSale.Payment
{
    /// <summary>
    /// Interaction logic for NumberBox.xaml
    /// </summary>
    public partial class NumberBox : UserControl
    {

        /// <summary>
        /// DependencyProperty to hold the value of the NumberBox
        /// </summary>
        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(NumberBox));

        /// <summary>
        /// gets and sets the value specified from the numberbox
        /// </summary>
        public int Value
        {
            get { return (int)GetValue(NumberBox.ValueProperty); }
            set { SetValue(NumberBox.ValueProperty, value); }
        }
        
        /// <summary>
        /// initializes the NumberBox
        /// </summary>
        public NumberBox()
        {
            InitializeComponent();
            CheckIfZero();
        }

        /// <summary>
        /// Adds one the the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void IncrementButtonClick(object sender, RoutedEventArgs e)
        {
            Value++;
            e.Handled = true;
            CheckIfZero();
            
        }

        /// <summary>
        /// prevents the checkbox from being a negative number
        /// </summary>
        void CheckIfZero()
        {
            if (Value == 0) Decrement.IsEnabled = false;
            else Decrement.IsEnabled = true;
        }

        /// <summary>
        /// decreses the textbox amound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DecrementButtonClick(object sender, RoutedEventArgs e)
        {           
            Value--;
            e.Handled = true;
            CheckIfZero();
        }

    }
}
