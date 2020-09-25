using BleakwindBuffet.Data.Entrees;
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
using System.Collections.ObjectModel;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;

namespace PointOfSale
{
    
   
    
    /// <summary>
    /// Interaction logic for MenuSelectionScreen.xaml
    /// </summary>
    public partial class MenuSelectionScreen : UserControl
    {
        

        public event EventHandler<MenuSelectionEvent> FoodSelected;
        
        /// <summary>
        /// This will consist of all the buttons available to select food items in the menu.
        /// All food items will start off all on one screen (upgrade later).
        /// </summary>
        public MenuSelectionScreen()
        {
            InitializeComponent();
        }
       
        void BriarheartBurger(object sender, RoutedEventArgs e)
        {
            BriarheartBurger entreeBriar = new BriarheartBurger();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = entreeBriar });
            
        }
        void SailorsSoda(object sender, RoutedEventArgs e)
        {
            SailorSoda drinkSoda = new SailorSoda();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = drinkSoda });
        }
        void VokunSalad(object sender, RoutedEventArgs e)
        {
            VokunSalad sideSalad = new VokunSalad();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = sideSalad });
        }

        void resetbuttons()
        {
            briarheartBurgerButton.IsEnabled = true;
            sailorsSodaButton.IsEnabled = true;
            vokunSaladButton.IsEnabled = true;
        }

        void turnOffButtons()
        {
            briarheartBurgerButton.IsEnabled = false;
            sailorsSodaButton.IsEnabled = false;
            vokunSaladButton.IsEnabled = false;
        }
    }
}
