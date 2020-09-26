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

        
        /// <summary>
        /// this class 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OrderClick(object sender, MenuSelectionEvent e)
        {
            //ItemCustomizationScreen footitem = new ItemCustomizationScreen();
            
            //entrees
            if(e.fooditem is BriarheartBurger) // this will check if an object is a certain type
            {
                BriarheartBurgerCustomization fooditem = new BriarheartBurgerCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen

                //now how can we use the information from Custimization...
                //to make changes to e.fooditem which is the new BriarheartBurger()
                //final goal ->   use BriarheartBurger.SpecialInstructions

                //we need to find a better way of capturing fooditem's customization information
                //FinalOrderListView.Items.Add("Briarheart Burger");
                FinalOrderListView.Items.Add(fooditem.ToString());
            }

            if (e.fooditem is DoubleDraugr) // this will check if an object is a certain type
            {
                DoubleDraugrCustomization fooditem = new DoubleDraugrCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add(fooditem.ToString());
            }

            if (e.fooditem is ThalmorTriple) // this will check if an object is a certain type
            {
                ThalmorTripleCustomization fooditem = new ThalmorTripleCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add(fooditem.ToString());
            }

            if (e.fooditem is SmokehouseSkeleton) // this will check if an object is a certain type
            {
                SmokehouseSkeletonCustomization fooditem = new SmokehouseSkeletonCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add(fooditem.ToString());
            }

            if (e.fooditem is GardenOrcOmelette) // this will check if an object is a certain type
            {
                GardenOrcOmeletteCustomization fooditem = new GardenOrcOmeletteCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add(fooditem.ToString());
            }

            if (e.fooditem is PhillyPoacher) // this will check if an object is a certain type
            {
                PhillyPoacherCustomization fooditem = new PhillyPoacherCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add(fooditem.ToString());
            }

            if (e.fooditem is ThugsTBone) // this will check if an object is a certain type
            {
                ThugsTBoneCustomization fooditem = new ThugsTBoneCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add(fooditem.ToString());
            }


            //drinks
            if (e.fooditem is SailorSoda)
            {
                SailorSodaCustomization fooditem = new SailorSodaCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }
            if (e.fooditem is MarkarthMilk)
            {
                MarkarthMilkCustomization fooditem = new MarkarthMilkCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }
            if (e.fooditem is AretinoAppleJuice)
            {
                AretinoAppleJuiceCustomization fooditem = new AretinoAppleJuiceCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }
            if (e.fooditem is CandlehearthCoffee)
            {
                CandlehearthCoffeeCustomization fooditem = new CandlehearthCoffeeCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }
            if (e.fooditem is WarriorWater)
            {
                WarriorWaterCustomization fooditem = new WarriorWaterCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }

            //sides:
            if (e.fooditem is VokunSalad)
            {
                VokunSaladCustomization fooditem = new VokunSaladCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }
            if (e.fooditem is FriedMiraak)
            {
                FriedMiraakCustomization fooditem = new FriedMiraakCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }
            if (e.fooditem is MadOtarGrits)
            {
                MadOtarGritsCustomization fooditem = new MadOtarGritsCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }
            if (e.fooditem is DragonbornWaffleFries)
            {
                DragonbornWaffleFriesCustomization fooditem = new DragonbornWaffleFriesCustomization();
                switchBorder.Child = fooditem; //add burger customization to the screen
                FinalOrderListView.Items.Add("Briarheart Burger");
            }
        }

        


        /// <summary>
        /// This button event will take the user back to the main menu to select another food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SwitchToMenuSelection(object sender, RoutedEventArgs e) //click events use RoutedEventArgs e
        {
            switchBorder.Child = menu; //most controls can only have one child
        }
  

        /// <summary>
        /// add selected food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SwitchToItemCustomization(object sender, RoutedEventArgs e) //EventArgs e just carrries information
        {
            //This method will be used later for editing an existing order
        }

    }
}
