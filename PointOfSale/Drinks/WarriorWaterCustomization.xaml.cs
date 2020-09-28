/*
* Author: Albert Winemiller
* Class name: WarriorWaterCustomization.xaml.cs
* Purpose: This class represents the customization options on Warrior Water for a GUI
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

namespace PointOfSale.Drinks
{
    /// <summary>
    /// Interaction logic for WarriorWaterCustomization.xaml
    /// </summary>
    public partial class WarriorWaterCustomization : UserControl
    {
        public WarriorWaterCustomization()
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
            return "Warrior Water";
        }
    }
}
