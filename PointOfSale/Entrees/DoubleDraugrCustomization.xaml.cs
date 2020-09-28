/*
* Author: Albert Winemiller
* Class name: DoubleDraugrCustomization.xaml.cs
* Purpose: This class represents the customization options on Double Draugr for a GUI
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

namespace PointOfSale.Entrees
{
    /// <summary>
    /// Interaction logic for DoubleDraugrCustomization.xaml
    /// </summary>
    public partial class DoubleDraugrCustomization : UserControl
    {
        public DoubleDraugrCustomization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method uses the overrides the toString method to output the 
        /// desired food item description from the menu page
        /// </summary>
        /// <returns>a string of the food name</returns>
        public override string ToString()
        {
            return "Double Drauger";
        }
    }
}
