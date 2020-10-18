/*
* Author: Albert Winemiller
* Class name: SmokehouseSkeletonCustomization.xaml.cs
* Purpose: This class represents the customization options on Smokehouse Skeleton for a GUI
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
using BleakwindBuffet.Data.Interface;

namespace PointOfSale.Entrees
{
    /// <summary>
    /// Interaction logic for SmokehouseSkeletonCustomization.xaml
    /// </summary>
    public partial class SmokehouseSkeletonCustomization : UserControl
    {
        public SmokehouseSkeletonCustomization(IOrderItem food)
        {
            InitializeComponent();
            //this.Ketchup.IsChecked = true; //default Ketchup value?
            Food = food;
            //DataContext = new BriarheartBurger();
        }

        public IOrderItem Food;

        /// <summary>
        /// This button confirms the customization allows the user to switch back to the main menu screen
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

        /// <summary>
        /// This button will check for the ancestor and then call on cancel
        /// current customization from the order.xaml.cs to remove the current
        /// food item if this choice was a mistake. also changes back to menu screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CancelCustomization(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent == null || parent is Order));
            if (parent is Order ancestor)
            {
                ancestor.CancelCurrentCustomization(Food); //calls on switchToMenu method
            }
        }
    }
}
