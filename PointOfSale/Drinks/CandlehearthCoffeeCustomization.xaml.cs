/*
* Author: Albert Winemiller
* Class name: CandlehearthCoffeeCustomization.xaml.cs
* Purpose: This class represents the customization options on Candlehearth Coffee for a GUI
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
    /// Interaction logic for CandlehearthCoffeeCustomization.xaml
    /// </summary>
    public partial class CandlehearthCoffeeCustomization : UserControl
    {
        public CandlehearthCoffeeCustomization()
        {
            InitializeComponent();
            SizeEnum.ItemsSource = Enum.GetValues(typeof(Size)); // this avoids messy xaml code to get enum.Size
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
