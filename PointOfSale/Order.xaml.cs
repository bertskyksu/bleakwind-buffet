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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : UserControl
    {



        /// <summary>
        /// This component will oversee all the other components: menu & item selection.
        /// Provide space for other components to be displayed. 
        /// 1. Completing the order building process and starting the payment process
        /// 2. Canceling the in-progress order, for those occasions where the customer changes their mind.
        /// </summary>
        /// 
        //ItemCustomizationScreen itemCustom = new ItemCustomizationScreen();
        MenuSelectionScreen menuSelect = new MenuSelectionScreen();
        List<ItemCustomizationScreen> listOfItemCustom = new List<ItemCustomizationScreen>();
        //List<ItemCustomizationScreen> FinalOrder = new List<ItemCustomizationScreen>();

        int currentListIndex = 0;

        public Order()
        {
            InitializeComponent();
            switchBorder.Child = menuSelect; //the default starting screen is menu selection
        }

        /// <summary>
        /// selecting a food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SwitchToMenuSelection(object sender, RoutedEventArgs e) //EventArgs e just carrries information
        {
            switchBorder.Child = menuSelect;
            //most contorls cant only have one child
        }
        //click events use RoutedEventArgs e

        /// <summary>
        /// add selected food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SwitchToItemCustomization(object sender, RoutedEventArgs e) //EventArgs e just carrries information
        {
            var newCustom = new ItemCustomizationScreen();
            //switchBorder.Child = itemCustom[];
            currentListIndex = listOfItemCustom.Count;
            listOfItemCustom.Add(newCustom);
            switchBorder.Child = newCustom;
            
            
            //most controls can only have one child
            //var newFood = new ItemCustomizationScreen
            foreach()
            itemsListView.Items.Add(newCustom); // i meant to have this to go back and edit later

            //we should have some list childs for going back and editing food items?
        }

        void EditItemCustomization(object sender, RoutedEventArgs e) //EventArgs e just carrries information
        {
            //add this later to keep track of a Item Customization from the. maybe use some kind of id for the 
        }
    }
}
