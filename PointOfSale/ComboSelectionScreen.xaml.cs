/*
* Author: Albert Winemiller
* Class name: ComboSelectionScreen.xaml.cs
* Purpose: This class represents the GUI interface with buttons to choose a combo
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
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Menu;
using PointOfSale.Entrees;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for ComboSelectionScreen.xaml
    /// </summary>
    public partial class ComboSelectionScreen : UserControl
    {
        private Entree chosenEntree;
        private Drink chosenDrink;
        private Side chosenSide;

        //initialize a combo
        public ComboSelectionScreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// a event handler to know what food item was selected on the menu from a button push.
        /// This Event will be listened from the Order.xaml.cs
        /// </summary>
        public event EventHandler<MenuSelectionEvent> FoodSelected;

        private DependencyObject parent = new DependencyObject();

        private Order currentOrder;


        public void GetOrderObject()
        {
            parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent == null || parent is Order));
            if (parent is Order ancestor)
            {
                currentOrder = ancestor;
            }
        }
        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BriarheartBurgerSelection(object sender, RoutedEventArgs e)
        {
            GetOrderObject();
            BriarheartBurger entree = new BriarheartBurger();
            BriarheartBurgerCustomization fooditem = new BriarheartBurgerCustomization(entree);
            fooditem.DataContext = entree;
            chosenEntree = entree;
            currentOrder.switchBorder.Child = fooditem;
            ResetEntreeButtons();
            briarheartBurgerButton.IsEnabled = false;
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DoubleDraugrSelection(object sender, RoutedEventArgs e)
        {
            GetOrderObject();
            DoubleDraugr entree = new DoubleDraugr();
            chosenEntree = entree;
            ResetEntreeButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ThalmorTripleSelection(object sender, RoutedEventArgs e)
        {
            GetOrderObject();
            ThalmorTriple entree = new ThalmorTriple();
            chosenEntree = entree;
            ResetEntreeButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SmokehouseSkeletonSelection(object sender, RoutedEventArgs e)
        {
            SmokehouseSkeleton entree = new SmokehouseSkeleton();
            chosenEntree = entree;
            ResetEntreeButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GardenOrcOmeletteSelection(object sender, RoutedEventArgs e)
        {
            GardenOrcOmelette entree = new GardenOrcOmelette();
            chosenEntree = entree;
            ResetEntreeButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PhillyPoacherSelection(object sender, RoutedEventArgs e)
        {
            PhillyPoacher entree = new PhillyPoacher();
            chosenEntree = entree;
            ResetEntreeButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ThugsTBoneSelection(object sender, RoutedEventArgs e)
        {
            ThugsTBone entree = new ThugsTBone();
            chosenEntree = entree;
            ResetEntreeButtons();
        }

        //drinks:
        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SailorsSodaSelection(object sender, RoutedEventArgs e)
        {
            SailorSoda drink = new SailorSoda();
            chosenDrink = drink;
            ResetDrinkButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MarkarthMilkSelection(object sender, RoutedEventArgs e)
        {
            MarkarthMilk drink = new MarkarthMilk();
            chosenDrink = drink;
            ResetDrinkButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AretinoAppleJuiceSelection(object sender, RoutedEventArgs e)
        {
            AretinoAppleJuice drink = new AretinoAppleJuice();
            chosenDrink = drink;
            ResetDrinkButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CandlehearthCoffeeSelection(object sender, RoutedEventArgs e)
        {
            CandlehearthCoffee drink = new CandlehearthCoffee();
            chosenDrink = drink;
            ResetDrinkButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WarriorWaterSelection(object sender, RoutedEventArgs e)
        {
            WarriorWater drink = new WarriorWater();
            chosenDrink = drink;
            ResetDrinkButtons();
        }

        //sides:
        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void VokunSaladSelection(object sender, RoutedEventArgs e)
        {
            VokunSalad side = new VokunSalad();
            chosenSide = side;
            ResetSideButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FriedMiraakSelection(object sender, RoutedEventArgs e)
        {
            FriedMiraak side = new FriedMiraak();
            chosenSide = side;
            ResetSideButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MadOtarGritsSelection(object sender, RoutedEventArgs e)
        {
            MadOtarGrits side = new MadOtarGrits();
            chosenSide = side;
            ResetSideButtons();
        }

        /// <summary>
        /// A button click event that send the information from the food button
        /// to the MenuSelectionEvent which will be accessed by the FoodButtonClickEvent
        /// in the Order class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DragonbornWaffleFriesSelection(object sender, RoutedEventArgs e)
        {
            DragonbornWaffleFries side = new DragonbornWaffleFries();
            chosenSide = side;
            ResetSideButtons();
        }

        public void ConfirmComboSelection(object sender, RoutedEventArgs e)
        {
            if(chosenEntree != null && chosenSide != null && chosenDrink != null)
            {
                ComboOrder combo = new ComboOrder(chosenEntree, chosenSide, chosenDrink);

                FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = combo });
            }
            else
            {
                MessageBox.Show("please finish selecting combo");
            }
            
            
        }

        /// <summary>
        /// This class would enable buttons in the event a food item
        /// was unselected before going to customization screen
        /// </summary>
        public void ResetEntreeButtons() //not needed unless we make a food item confirmation button before switching to customization
        {

            briarheartBurgerButton.IsEnabled = true;
            doubleDraugrButton.IsEnabled = true;
            thalmorTripleButton.IsEnabled = true;
            smokehouseSkeletonButton.IsEnabled = true;
            gardenOrcOmeletteButton.IsEnabled = true;
            phillyPoacherButton.IsEnabled = true;
            thugsTBoneButton.IsEnabled = true;
        }
        /// <summary>
        /// This class would enable buttons in the event a food item
        /// was unselected before going to customization screen
        /// </summary>
        public void ResetDrinkButtons() //not needed unless we make a food item confirmation button before switching to customization
        {
            sailorsSodaButton.IsEnabled = true;
            markarthMilkButton.IsEnabled = true;
            aretinoAppleJuiceButton.IsEnabled = true;
            candlehearthButton.IsEnabled = true;
            warriorWaterButton.IsEnabled = true;
        }
            /// <summary>
            /// This class would enable buttons in the event a food item
            /// was unselected before going to customization screen
            /// </summary>
        public void ResetSideButtons() //not needed unless we make a food item confirmation button before switching to customization
        {
            vokunSaladButton.IsEnabled = true;
            friedMiraakButton.IsEnabled = true;
            MadOtarGritsButton.IsEnabled = true;
            dragonbornWaffleFriesButton.IsEnabled = true;
        }

        /// <summary>
        /// This class would enable buttons in the event a food item
        /// was unselected before going to customization screen
        /// </summary>
        public void TurnOffEntreeButtons() //not needed unless we make a food item confirmation button before switching to customization
        {

            briarheartBurgerButton.IsEnabled = false;
            doubleDraugrButton.IsEnabled = false;
            thalmorTripleButton.IsEnabled = false;
            smokehouseSkeletonButton.IsEnabled = false;
            gardenOrcOmeletteButton.IsEnabled = false;
            phillyPoacherButton.IsEnabled = false;
            thugsTBoneButton.IsEnabled = false;
        }
        /// <summary>
        /// This class would enable buttons in the event a food item
        /// was unselected before going to customization screen
        /// </summary>
        public void TurnOffDrinkButtons() //not needed unless we make a food item confirmation button before switching to customization
        {
            sailorsSodaButton.IsEnabled = false;
            markarthMilkButton.IsEnabled = false;
            aretinoAppleJuiceButton.IsEnabled = false;
            candlehearthButton.IsEnabled = false;
            warriorWaterButton.IsEnabled = false;
        }
        /// <summary>
        /// This class would enable buttons in the event a food item
        /// was unselected before going to customization screen
        /// </summary>
        public void TurnOffSideButtons() //not needed unless we make a food item confirmation button before switching to customization
        {
            vokunSaladButton.IsEnabled = false;
            friedMiraakButton.IsEnabled = false;
            MadOtarGritsButton.IsEnabled = false;
            dragonbornWaffleFriesButton.IsEnabled = false;
        }
    }
}
