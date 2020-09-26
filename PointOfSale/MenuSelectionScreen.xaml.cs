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

        //entrees
        void BriarheartBurgerSelection(object sender, RoutedEventArgs e)
        {
            BriarheartBurger entree = new BriarheartBurger();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = entree });
        }

        void DoubleDraugrSelection(object sender, RoutedEventArgs e)
        {
            DoubleDraugr entree = new DoubleDraugr();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = entree });
        }

        void ThalmorTripleSelection(object sender, RoutedEventArgs e)
        {
            ThalmorTriple entree = new ThalmorTriple();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = entree });
        }

        void SmokehouseSkeletonSelection(object sender, RoutedEventArgs e)
        {
            SmokehouseSkeleton entree = new SmokehouseSkeleton();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = entree });
        }

        void GardenOrcOmeletteSelection(object sender, RoutedEventArgs e)
        {
            GardenOrcOmelette entree = new GardenOrcOmelette();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = entree });
        }

        void PhillyPoacherSelection(object sender, RoutedEventArgs e)
        {
            PhillyPoacher entree = new PhillyPoacher();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = entree });
        }

        void ThugsTBoneSelection(object sender, RoutedEventArgs e)
        {
            ThugsTBone entree = new ThugsTBone();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = entree });
        }

        //drinks:
        void SailorsSodaSelection(object sender, RoutedEventArgs e)
        {
            SailorSoda drink = new SailorSoda();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = drink });
        }

        void MarkarthMilkSelection(object sender, RoutedEventArgs e)
        {
            MarkarthMilk drink = new MarkarthMilk();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = drink });
        }

        void AretinoAppleJuiceSelection(object sender, RoutedEventArgs e)
        {
            AretinoAppleJuice drink = new AretinoAppleJuice();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = drink });
        }

        void CandlehearthCoffeeSelection(object sender, RoutedEventArgs e)
        {
            CandlehearthCoffee drink = new CandlehearthCoffee();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = drink });
        }

        void WarriorWaterSelection(object sender, RoutedEventArgs e)
        {
            WarriorWater drink = new WarriorWater();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = drink });
        }

        //sides:
        void VokunSaladSelection(object sender, RoutedEventArgs e)
        {
            VokunSalad side = new VokunSalad();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = side });
        }

        void FriedMiraakSelection(object sender, RoutedEventArgs e)
        {
            FriedMiraak side = new FriedMiraak();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = side });
        }

        void MadOtarGritsSelection(object sender, RoutedEventArgs e)
        {
            MadOtarGrits side = new MadOtarGrits();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = side });
        }

        void DragonbornWaffleFriesSelection(object sender, RoutedEventArgs e)
        {
            DragonbornWaffleFries side = new DragonbornWaffleFries();
            FoodSelected?.Invoke(this, new MenuSelectionEvent() { fooditem = side });
        }

        void resetbuttons() //not needed unless we make a food item confirmation button before switching to customization
        {
            briarheartBurgerButton.IsEnabled = true;
            sailorsSodaButton.IsEnabled = true;
            vokunSaladButton.IsEnabled = true;
        }

        void turnOffButtons() //not needed
        {
            briarheartBurgerButton.IsEnabled = false;
            sailorsSodaButton.IsEnabled = false;
            vokunSaladButton.IsEnabled = false;
        }
    }
}
