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
using PointOfSale.Payment;
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
        /// <summary>
        /// using anthor instance of FoodReSelected so that I can go back and edit orders. Unfortunatley this technically
        /// removes the items and then re-adds it back. Still a work in progress.
        /// </summary>
        //public event EventHandler<MenuSelectionEvent> FoodReSelected;


        /// <summary>
        /// sets and instance of where selecting food items from buttons will be.
        /// A EventHandler is locacted in this class
        /// </summary>
        MenuSelectionScreen menu = new MenuSelectionScreen();

        ComboSelectionScreen comboScreen = new ComboSelectionScreen();
        /// <summary>
        /// An instance of the Ordering class in Data Project used to keep track of all the food items in a single order
        /// </summary>
        public Ordering newOrder = new Ordering();


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
            comboScreen.FoodSelected += ComboButtonClickEvent;
            //attach an event handler
            //FoodReSelected += FoodButtonClickEvent; // another event listener to keep track of editing an existing order
            newOrder.PropertyChanged += DisplayCurrentOrderListener;
        }

        public void SwitchComboSelectionScreen()
        {
            switchBorder.Child = comboScreen;
        }

        public void ComboButtonClickEvent(object sender, MenuSelectionEvent e)
        {
            if (e.fooditem is ComboOrder combo) // this will check if an object is a certain type
            {
                //newOrder.Add(combo.Entree);
                //newOrder.Add(combo.Drink);
                //newOrder.Add(combo.Side);
                newOrder.Add(combo);
            }
            DisplayCurrentOrder();
        }


        /// <summary>
        /// this class sets a new instance of the 
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
                BriarheartBurgerCustomization fooditem = new BriarheartBurgerCustomization(e.fooditem);
                switchBorder.Child = fooditem; //add burger customization to the current screen
                fooditem.DataContext = e.fooditem;
                
                //fooditem.DataContext = e.fooditem; //allows the DataContext of the XAML variables to access BriarheartBurger
                //fooditem.DataContext = newOrder;
                
            }

            else if (e.fooditem is DoubleDraugr) // this will check if an object is a certain type
            {
                DoubleDraugrCustomization fooditem = new DoubleDraugrCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
               // fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is ThalmorTriple) // this will check if an object is a certain type
            {
                ThalmorTripleCustomization fooditem = new ThalmorTripleCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is SmokehouseSkeleton) // this will check if an object is a certain type
            {
                SmokehouseSkeletonCustomization fooditem = new SmokehouseSkeletonCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is GardenOrcOmelette) // this will check if an object is a certain type
            {
                GardenOrcOmeletteCustomization fooditem = new GardenOrcOmeletteCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is PhillyPoacher) // this will check if an object is a certain type
            {
                PhillyPoacherCustomization fooditem = new PhillyPoacherCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            else if(e.fooditem is ThugsTBone) // this will check if an object is a certain type
            {
                ThugsTBoneCustomization fooditem = new ThugsTBoneCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }


            //drinks
            else if(e.fooditem is SailorSoda)
            {
                SailorSodaCustomization fooditem = new SailorSodaCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is MarkarthMilk)
            {
                MarkarthMilkCustomization fooditem = new MarkarthMilkCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
               // fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is AretinoAppleJuice)
            {
                AretinoAppleJuiceCustomization fooditem = new AretinoAppleJuiceCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is CandlehearthCoffee)
            {
                CandlehearthCoffeeCustomization fooditem = new CandlehearthCoffeeCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is WarriorWater)
            {
                WarriorWaterCustomization fooditem = new WarriorWaterCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }

            //sides:
            else if(e.fooditem is VokunSalad)
            {
                VokunSaladCustomization fooditem = new VokunSaladCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is FriedMiraak)
            {
                FriedMiraakCustomization fooditem = new FriedMiraakCustomization(e.fooditem);
                switchBorder.Child = fooditem; 
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is MadOtarGrits)
            {
                MadOtarGritsCustomization fooditem = new MadOtarGritsCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
            }
            else if(e.fooditem is DragonbornWaffleFries)
            {
                DragonbornWaffleFriesCustomization fooditem = new DragonbornWaffleFriesCustomization(e.fooditem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = e.fooditem;
                //fooditem.DataContext = newOrder;
                //finalOrder.Add(e.fooditem); //only need once below
            }

           // finalOrder.Add(e.fooditem); //add food item to the list of IOrderItem

            newOrder.Add(e.fooditem); //setting everything up for newOrder

            DisplayCurrentOrder();

        }

        public void FoodButtonEditClickEvent(IOrderItem editOrderItem)
        {
            //now how can we use the information from Custimization...
            //to make changes to e.fooditem which is the new BriarheartBurger()
            //final goal ->   use BriarheartBurger.SpecialInstructions

            //we need to find a better way of capturing fooditem's customization information
            //FinalOrderListView.Items.Add("Briarheart Burger");

            //entrees
            if (editOrderItem is BriarheartBurger) // this will check if an object is a certain type
            {
                BriarheartBurgerCustomization fooditem = new BriarheartBurgerCustomization(editOrderItem);
                switchBorder.Child = fooditem; //add burger customization to the current screen
                fooditem.DataContext = editOrderItem;

                //fooditem.DataContext = e.fooditem; //allows the DataContext of the XAML variables to access BriarheartBurger
                //fooditem.DataContext = newOrder;

            }

            else if (editOrderItem is DoubleDraugr) // this will check if an object is a certain type
            {
                DoubleDraugrCustomization fooditem = new DoubleDraugrCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                // fooditem.DataContext = newOrder;
            }

            else if (editOrderItem is ThalmorTriple) // this will check if an object is a certain type
            {
                ThalmorTripleCustomization fooditem = new ThalmorTripleCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }

            else if (editOrderItem is SmokehouseSkeleton) // this will check if an object is a certain type
            {
                SmokehouseSkeletonCustomization fooditem = new SmokehouseSkeletonCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }

            else if (editOrderItem is GardenOrcOmelette) // this will check if an object is a certain type
            {
                GardenOrcOmeletteCustomization fooditem = new GardenOrcOmeletteCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }

            else if (editOrderItem is PhillyPoacher) // this will check if an object is a certain type
            {
                PhillyPoacherCustomization fooditem = new PhillyPoacherCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }

            else if (editOrderItem is ThugsTBone) // this will check if an object is a certain type
            {
                ThugsTBoneCustomization fooditem = new ThugsTBoneCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }


            //drinks
            else if (editOrderItem is SailorSoda)
            {
                SailorSodaCustomization fooditem = new SailorSodaCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }
            else if (editOrderItem is MarkarthMilk)
            {
                MarkarthMilkCustomization fooditem = new MarkarthMilkCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                // fooditem.DataContext = newOrder;
            }
            else if (editOrderItem is AretinoAppleJuice)
            {
                AretinoAppleJuiceCustomization fooditem = new AretinoAppleJuiceCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }
            else if (editOrderItem is CandlehearthCoffee)
            {
                CandlehearthCoffeeCustomization fooditem = new CandlehearthCoffeeCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }
            else if (editOrderItem is WarriorWater)
            {
                WarriorWaterCustomization fooditem = new WarriorWaterCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }

            //sides:
            else if (editOrderItem is VokunSalad)
            {
                VokunSaladCustomization fooditem = new VokunSaladCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }
            else if (editOrderItem is FriedMiraak)
            {
                FriedMiraakCustomization fooditem = new FriedMiraakCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }
            else if (editOrderItem is MadOtarGrits)
            {
                MadOtarGritsCustomization fooditem = new MadOtarGritsCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
            }
            else if (editOrderItem is DragonbornWaffleFries)
            {
                DragonbornWaffleFriesCustomization fooditem = new DragonbornWaffleFriesCustomization(editOrderItem);
                switchBorder.Child = fooditem;
                fooditem.DataContext = editOrderItem;
                //fooditem.DataContext = newOrder;
                //finalOrder.Add(e.fooditem); //only need once below
            }

            // finalOrder.Add(e.fooditem); //add food item to the list of IOrderItem

            //newOrder.Add(editOrderItem); //setting everything up for newOrder

            DisplayCurrentOrder();



        }

        /// <summary>
        /// This Triggers whenever a property of a IOrderItem changes and then the displaycurrentorder() method is called to update display.
        /// This helps so we can see Display changes(total, special instruc, size) right away whenever we are changing the customization of food items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayCurrentOrderListener(object sender, PropertyChangedEventArgs e)
        {
            DisplayCurrentOrder();
            //real test: If we remove all the DisplayCurrentOrder() from other sections of this code.
        }

        /// <summary>
        /// This class implments a ListView to display the current order's items(price, specialinstructions), subtotal, tax, and total.
        /// buttons are also implemented so I can call another instance of FoodButtonClickEvent to edit an existing order.
        /// </summary>
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
        /// re-adds it at the end. The customization is still maintained when editing which is a good.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="item">the current food item being edited or deleted</param>
        public void ItemReSelectionClickEvent(object sender, RoutedEventArgs e, IOrderItem item)
        {
            //newOrder.Remove(item);
            //switchBorder.Child = 
            //Binding previousBind = BindingOperations.
            //Binding previousBind = BindingBase.
            //IOrderItem reSelected = (IOrderItem)e.Source;
            //FoodReSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = item }); //invokes so we can properly cancel item
            FoodButtonEditClickEvent(item);

        }

        /// <summary>
        /// This button will take the order to the payment screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CompleteOrderButtonSelection(object sender, RoutedEventArgs e)
        {
            PaymentOptions paymentScreen = new PaymentOptions();
            switchBorder.Child = paymentScreen; //switch to payment screen
            //not sure if data context will be needed?
            paymentScreen.GetOrderObject(); //makes sure I get the ancestor 'order' in Payment Screen
            DisplayCurrentOrder(); //just in case changes were made before confirming a order
        }

        /// <summary>
        /// This button event will take the user back to the main menu to start a new order.
        /// It cancels the current order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CancelOrderButtonSelection(object sender, RoutedEventArgs e) //click events use RoutedEventArgs e
        {
            switchBorder.Child = menu; //most controls can only have one child
            newOrder = new Ordering();
            DisplayCurrentOrder();
        }
        

        public void SwitchToNewScreen(UIElement newScreen)
        {
            switchBorder.Child = newScreen;
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
        public void CancelCurrentCustomization(IOrderItem canceledItem)
        {
            //FoodReSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = e.fooditem });

            //int lastElement = newOrder.ListOrder.Count;
            //finalOrder.RemoveAt(lastElement-1);
            
            //IOrderItem canceledItem = newOrder.ListOrder[lastElement - 1];
            newOrder.Remove(canceledItem);
            switchBorder.Child = menu; //most controls can only have one child

            DisplayCurrentOrder();
        }

        /// <summary>
        /// not currently implemented 
        /// </summary>
        public void CancelCurrentSelection()
        {
            //IOrderItem a = menu.FoodSelected();
        }

        /// <summary>
        /// currently not being implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SwitchToItemCustomization(object sender, RoutedEventArgs e) //EventArgs e just carrries information
        {
            //This method will be used later for editing an existing order
        }

    }
}
