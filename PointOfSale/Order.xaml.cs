/*
* Author: Albert Winemiller
* Class name: Order.xaml.cs
* Purpose: This class represents the GUI interface that controls when different screens will be shown.
*/
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Interface;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Sides;
using PointOfSale.Drinks;
using PointOfSale.Entrees;
using PointOfSale.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;
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

        public event EventHandler<MenuSelectionEvent> FoodReSelected;


        //ItemCustomizationScreen itemCustom = new ItemCustomizationScreen();
        MenuSelectionScreen menu = new MenuSelectionScreen();

        Ordering newOrder = new Ordering();

        
        List<IOrderItem> finalOrder = new List<IOrderItem>();
        //List<ItemCustomizationScreen> FinalOrder = new List<ItemCustomizationScreen>();

        //int currentListIndex = 0;

        /// <summary>
        /// This component will oversee all the other components: menu & item selection.
        /// Provide space for other components to be displayed. 
        /// 1. Completing the order building process and starting the payment process
        /// 2. Canceling the in-progress order, for those occasions where the customer changes their mind.
        /// </summary>
        public Order()
        {
            InitializeComponent(); 
            switchBorder.Child = menu; //the default starting screen is menu selection
            DisplayCurrentOrder();
            //add event handler click event:
            menu.FoodSelected += FoodButtonClickEvent; //attach event listener from MenuSelectionScreen -> FoodButtonClickEvent
            //attach an event handler
            FoodReSelected += FoodButtonClickEvent;
        }

        
        /// <summary>
        /// this class 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">represents a food object passed from FoodSelected event handler</param>
        public void FoodButtonClickEvent(object sender, MenuSelectionEvent e)
        {
            //now how can we use the information from Custimization...
            //to make changes to e.fooditem which is the new BriarheartBurger()
            //final goal ->   use BriarheartBurger.SpecialInstructions

            //we need to find a better way of capturing fooditem's customization information
            //FinalOrderListView.Items.Add("Briarheart Burger");

            //entrees
            if (e.fooditem is BriarheartBurger) // this will check if an object is a certain type
            {
                BriarheartBurgerCustomization fooditem = new BriarheartBurgerCustomization();
                switchBorder.Child = fooditem; //add burger customization to the current screen
                fooditem.DataContext = e.fooditem;
                
                //fooditem.DataContext = e.fooditem; //allows the DataContext of the XAML variables to access BriarheartBurger
                //fooditem.DataContext = newOrder;
                
            }

            else if (e.fooditem is DoubleDraugr) // this will check if an object is a certain type
            {
                DoubleDraugrCustomization fooditem = new DoubleDraugrCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
               // fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is ThalmorTriple) // this will check if an object is a certain type
            {
                ThalmorTripleCustomization fooditem = new ThalmorTripleCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is SmokehouseSkeleton) // this will check if an object is a certain type
            {
                SmokehouseSkeletonCustomization fooditem = new SmokehouseSkeletonCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is GardenOrcOmelette) // this will check if an object is a certain type
            {
                GardenOrcOmeletteCustomization fooditem = new GardenOrcOmeletteCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is PhillyPoacher) // this will check if an object is a certain type
            {
                PhillyPoacherCustomization fooditem = new PhillyPoacherCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is ThugsTBone) // this will check if an object is a certain type
            {
                ThugsTBoneCustomization fooditem = new ThugsTBoneCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }


            //drinks
            else if(e.fooditem is SailorSoda)
            {
                SailorSodaCustomization fooditem = new SailorSodaCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is MarkarthMilk)
            {
                MarkarthMilkCustomization fooditem = new MarkarthMilkCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
               // fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is AretinoAppleJuice)
            {
                AretinoAppleJuiceCustomization fooditem = new AretinoAppleJuiceCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is CandlehearthCoffee)
            {
                CandlehearthCoffeeCustomization fooditem = new CandlehearthCoffeeCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is WarriorWater)
            {
                WarriorWaterCustomization fooditem = new WarriorWaterCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            //sides:
            else if(e.fooditem is VokunSalad)
            {
                VokunSaladCustomization fooditem = new VokunSaladCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is FriedMiraak)
            {
                FriedMiraakCustomization fooditem = new FriedMiraakCustomization();
                switchBorder.Child = fooditem; 
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is MadOtarGrits)
            {
                MadOtarGritsCustomization fooditem = new MadOtarGritsCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is DragonbornWaffleFries)
            {
                DragonbornWaffleFriesCustomization fooditem = new DragonbornWaffleFriesCustomization();
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
                //finalOrder.Add(e.fooditem); //only need once below
            }

           // finalOrder.Add(e.fooditem); //add food item to the list of IOrderItem

            newOrder.Add(e.fooditem); //setting everything up for newOrder

            DisplayCurrentOrder();

            //Testing what gets put in the list
            foreach (IOrderItem food in finalOrder) //for debugging
            {
                List<string> foodlist = food.SpecialInstructions;
                foreach(string s in foodlist)
                {
                    Console.WriteLine(s);
                }
            }

        }

        


        public void DisplayCurrentOrder()
        {
            FinalOrderListView.Items.Clear();
            FinalPriceListView.Items.Clear();
            /*
            foreach (IOrderItem food in finalOrder) //for debugging
            {
                //List<string> foodlist = food.SpecialInstructions;
                FinalOrderListView.Items.Add(food.ToString());
            } */
            FinalOrderListView.Items.Add("     Order #"+ newOrder.OrderNumber);
            foreach (IOrderItem food in newOrder.ListOrder) //for debugging
            {
                //List<string> foodlist = food.SpecialInstructions;
                FinalOrderListView.Items.Add(food.ToString() + "  $" + food.Price);
                foreach (string custom in food.SpecialInstructions)
                {
                    FinalOrderListView.Items.Add("-" + custom);
                }
                Button MyButton = new Button();
               MyButton.Margin = new Thickness(20, 0, 0, 0);
                MyButton.Content = "Remove/Edit Order";
                //MyButton.Tag = food; //not sure if this works yet? could use .content
                //MyButton.Content = food;
                //MyButton.Click += ItemReSelectionClickEvent;
                MyButton.Click += (object sender, RoutedEventArgs e) => { ItemReSelectionClickEvent(sender, e, food); };
                
                FinalOrderListView.Items.Add(MyButton);
                
            }
            FinalPriceListView.Items.Add("Subtotal:          $" + newOrder.Subtotal);
            FinalPriceListView.Items.Add("Tax:                  $" + newOrder.Tax);
            FinalPriceListView.Items.Add("Total:               $" + newOrder.Total);
        }

        /// <summary>
        /// Currently this allows us to edit a selection but it basically deletes an item and
        /// re-adds it at the end. The customization is still maintained when editing which is a good thing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="item"></param>
        public void ItemReSelectionClickEvent(object sender, RoutedEventArgs e, IOrderItem item)
        {
            newOrder.Remove(item);
            //switchBorder.Child = 
            //Binding previousBind = BindingOperations.
            //Binding previousBind = BindingBase.
            //IOrderItem reSelected = (IOrderItem)e.Source;
            FoodReSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = item });
        }

        /// <summary>
        /// This button event will take the user back to the main menu to start a new order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SwitchToMenuSelection(object sender, RoutedEventArgs e) //click events use RoutedEventArgs e
        {
            switchBorder.Child = menu; //most controls can only have one child
            newOrder = new Ordering();
            DisplayCurrentOrder();
        }
        
        /// <summary>
        /// This method is used when wanting to switch to the menu screen from inside
        /// a descendant class of Order.xaml.cs
        /// </summary>
        public void SwitchToMenu() //click events use RoutedEventArgs e
        {
            switchBorder.Child = menu; //most controls can only have one child
            DisplayCurrentOrder();
        }

        /// <summary>
        /// This method is used when wanting to cancel our current food order and
        /// switch to the menu screen from inside a descendant class of Order.xaml.cs
        /// It will also update the display for the current order items
        /// </summary>
        public void CancelCurrentCustomization()
        {
            int lastElement = newOrder.ListOrder.Count;
            //finalOrder.RemoveAt(lastElement-1);

            IOrderItem canceledItem = newOrder.ListOrder[lastElement - 1];
            newOrder.Remove(canceledItem);
            switchBorder.Child = menu; //most controls can only have one child
            DisplayCurrentOrder();
        }

        public void CancelCurrentSelection()
        {
            //IOrderItem a = menu.FoodSelected();
        }

        /// <summary>
        /// add selected food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SwitchToItemCustomization(object sender, RoutedEventArgs e) //EventArgs e just carrries information
        {
            //This method will be used later for editing an existing order
        }

    }
}
