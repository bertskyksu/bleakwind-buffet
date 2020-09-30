/*
* Author: Albert Winemiller
* Class name: BriarheartBurgerCustomization.xaml.cs
* Purpose: This class represents the customization options on Briarheart Burger for a GUI
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
using System.ComponentModel;
using BleakwindBuffet.Data.Entrees;

namespace PointOfSale.Entrees
{
    /// <summary>
    /// Interaction logic for BriarheartBurgerCustomization.xaml
    /// </summary>
    public partial class BriarheartBurgerCustomization : UserControl
    {
        public BriarheartBurgerCustomization()
        {
            InitializeComponent();
            //this.Ketchup.IsChecked = true; //default Ketchup value?

            //DataContext = new BriarheartBurger();
        }
        
        /// <summary>
        /// This class allows the user to switch back to the main menu screen
        /// by traversing until Order.xaml.cs is found as a parent then 
        /// calling on the SwitchToMenu() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SwitchBackToMenu(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent == null || parent is Order));
            if (parent is Order ancestor)
            {
                ancestor.SwitchToMenu(); //calls on switchToMenu method
            }
            //goal is to switch back to Order
        }

    }
}
