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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuSelectionScreen.xaml
    /// </summary>
    public partial class MenuSelectionScreen : UserControl
    {
        //ItemCustomizationScreen foodItem = new ItemCustomizationScreen();
        public class MyItem
        {
            public static ObservableCollection<BoolString> Listmenu { get; set; }
            public static bool briar { get; set; }
            public static bool sailor { get; set; }
        }
        //public static ObservableCollection<BoolString> Listmenu { get; set; }

        //ItemCustomizationScreen newFood = new ItemCustomizationScreen();

        

        
        /// <summary>
        /// This will consist of all the buttons available to select food items in the menu.
        /// All food items will start off all on one screen (upgrade later).
        /// </summary>
        public MenuSelectionScreen()
        {
            InitializeComponent();
        }
        public class BoolString
        {
            public string TheFoodList { get; set; }
            public int TheValue { get; set; }
        }
        void BriarheartBurger(object sender, RoutedEventArgs e)
        {
            
            if(MyItem.briar == true)
            {
                resetbuttons();
                MyItem.briar = false;
            }
            else 
            {
                MyItem.briar = true;
                turnOffButtons();
                briarheartBurgerButton.IsEnabled = true;


                //i think we should make a list of food instructions
                MyItem.Listmenu = new ObservableCollection<BoolString>();
                //we could try a for each loop here for a list of toppings
                //from menuSelectionScreen
                MyItem.Listmenu.Add(new BoolString { TheFoodList = "bun", TheValue = 1 });
                MyItem.Listmenu.Add(new BoolString { TheFoodList = "tomato", TheValue = 1 });
                MyItem.Listmenu.Add(new BoolString { TheFoodList = "mustard", TheValue = 1 });
                MyItem.Listmenu.Add(new BoolString { TheFoodList = "someting", TheValue = 0 });
                //this.DataContext = this; //<- idk what this does exactly. something for data binding
                //var newFood = new ItemCustomizationScreen();
                //newFood.CreateCheckBoxList(List);


            }
        }
        void SailorsSoda(object sender, RoutedEventArgs e)
        {
            if (MyItem.sailor == true)
            {
                resetbuttons();
                MyItem.sailor = false;
            }
            else
            {
                MyItem.sailor = true;
                turnOffButtons();
                sailorsSodaButton.IsEnabled = true;


                //i think we should make a list of food instructions
                MyItem.Listmenu = new ObservableCollection<BoolString>();

                MyItem.Listmenu.Add(new BoolString { TheFoodList = "juice", TheValue = 1 });
                MyItem.Listmenu.Add(new BoolString { TheFoodList = "stuff", TheValue = 1 });
                MyItem.Listmenu.Add(new BoolString { TheFoodList = "ice", TheValue = 1 });
                MyItem.Listmenu.Add(new BoolString { TheFoodList = "cool", TheValue = 0 });
                
                //itemCustomization will try to access this static list
            }
        }
        void VokunSalad(object sender, RoutedEventArgs e)
        {

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
