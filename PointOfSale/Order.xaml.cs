using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using PointOfSale.Drinks;
using PointOfSale.Entrees;
using PointOfSale.Sides;
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
        MenuSelectionScreen menu = new MenuSelectionScreen();
        List<ItemCustomizationScreen> Custom = new List<ItemCustomizationScreen>();
        //List<ItemCustomizationScreen> FinalOrder = new List<ItemCustomizationScreen>();

        


        //int currentListIndex = 0;

        public Order()
        {
            InitializeComponent();
            
            switchBorder.Child = menu; //the default starting screen is menu selection

            //add event handler click event:
            menu.FoodSelected += OrderClick;
        //attach an event handler
        }

        
        void OrderClick(object sender, MenuSelectionEvent e)
        {
            //ItemCustomizationScreen footitem = new ItemCustomizationScreen();
            
            //entrees
            if(e.fooditem is BriarheartBurger) // this will check if an object is a certain type
            {
                BriarheartBurgerCustomization fooditem = new BriarheartBurgerCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }

            if (e.fooditem is DoubleDraugr) // this will check if an object is a certain type
            {
                DoubleDraugrCustomization fooditem = new DoubleDraugrCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }

            if (e.fooditem is ThalmorTriple) // this will check if an object is a certain type
            {
                ThalmorTripleCustomization fooditem = new ThalmorTripleCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }

            if (e.fooditem is SmokehouseSkeleton) // this will check if an object is a certain type
            {
                SmokehouseSkeletonCustomization fooditem = new SmokehouseSkeletonCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }

            if (e.fooditem is GardenOrcOmelette) // this will check if an object is a certain type
            {
                GardenOrcOmeletteCustomization fooditem = new GardenOrcOmeletteCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }

            if (e.fooditem is PhillyPoacher) // this will check if an object is a certain type
            {
                PhillyPoacherCustomization fooditem = new PhillyPoacherCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }

            if (e.fooditem is ThugsTBone) // this will check if an object is a certain type
            {
                ThugsTBoneCustomization fooditem = new ThugsTBoneCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }


            //drinks
            if (e.fooditem is SailorSoda)
            {
                SailorSodaCustomization fooditem = new SailorSodaCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }
            if (e.fooditem is MarkarthMilk)
            {
                MarkarthMilkCustomization fooditem = new MarkarthMilkCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }
            if (e.fooditem is AretinoAppleJuice)
            {
                AretinoAppleJuiceCustomization fooditem = new AretinoAppleJuiceCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }
            if (e.fooditem is CandlehearthCoffee)
            {
                CandlehearthCoffeeCustomization fooditem = new CandlehearthCoffeeCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }
            if (e.fooditem is WarriorWater)
            {
                WarriorWaterCustomization fooditem = new WarriorWaterCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }

            //sides:
            if (e.fooditem is VokunSalad)
            {
                VokunSaladCustomization fooditem = new VokunSaladCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }
            if (e.fooditem is FriedMiraak)
            {
                FriedMiraakCustomization fooditem = new FriedMiraakCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }
            if (e.fooditem is MadOtarGrits)
            {
                MadOtarGritsCustomization fooditem = new MadOtarGritsCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }
            if (e.fooditem is DragonbornWaffleFries)
            {
                DragonbornWaffleFriesCustomization fooditem = new DragonbornWaffleFriesCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
            }

            //switchBorder.Child = fooditem;
        }
        //how to show it now? in order component

        //now make evetn happend
        


        /// <summary>
        /// selecting a food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SwitchToMenuSelection(object sender, RoutedEventArgs e) //EventArgs e just carrries information
        {
            switchBorder.Child = menu;
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
            //currentListIndex = listOfItemCustom.Count;
            //listOfItemCustom.Add(newCustom);
            switchBorder.Child = newCustom;
            
            
            //most controls can only have one child
            //var newFood = new ItemCustomizationScreen
            //foreach()
            //itemsListView.Items.Add(newCustom); // i meant to have this to go back and edit later

            //we should have some list childs for going back and editing food items?
        }


        /*
        void EditItemCustomization(object sender, RoutedEventArgs e) //EventArgs e just carrries information
        {
            //add this later to keep track of a Item Customization from the. maybe use some kind of id for the 
        }

        void SwitchToBriarheartBurgerCustomization(object sender, RoutedEventArgs e)
        {

        }
        */
    }
}
