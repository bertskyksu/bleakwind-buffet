/*
* Author: Albert Winemiller
* Class name: MarkarthMilkCustomization.xaml.cs
* Purpose: This class represents the customization options on Markarth Milk for a GUI
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
using Size = BleakwindBuffet.Data.Enums.Size;

namespace PointOfSale.Drinks
{
    /// <summary>
    /// Interaction logic for MarkarthMilkCustomization.xaml
    /// </summary>
    public partial class MarkarthMilkCustomization : UserControl
    {
        public MarkarthMilkCustomization()
        {
            InitializeComponent();
            SizeEnum.ItemsSource = Enum.GetValues(typeof(Size)); // this avoids messy xaml code to get enum.Size
        }
        /// <summary>
        /// This method uses the overrides the toString method to output the 
        /// desired food item description from the menu page
        /// </summary>
        /// <returns>a string of the food name</returns>
        public override string ToString()
        {
            return "Markarth Milk";
        }
    }
}
