/*
* Author: Albert Winemiller
* Class name: Menu.cs
* Purpose: This class represents the Entree Thugs T-Bone
*/
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Interface;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using System.Dynamic;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using System.Linq;

namespace BleakwindBuffet.Data.Menu
{
    /// <summary>
    /// This class cover all the available food items(entrees,sides,drinks) available
    /// on the menu for customers
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// an instance of all available entrees offered by Bleakwind Buffet
        /// </summary>
        /// <returns> IEnumerable of Entrees </returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            List<IOrderItem> entrees = new List<IOrderItem>() { new BriarheartBurger(), new DoubleDraugr(), new GardenOrcOmelette(), 
                                                    new PhillyPoacher(), new SmokehouseSkeleton(), new ThalmorTriple(), new ThugsTBone() };

            return entrees;
        }

        /// <summary>
        /// an instance of all available Sides offered by Bleakwind Buffet
        /// </summary>
        /// <returns> IEnumerable of Sides </returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            //List<IOrderItem> sides = new List<IOrderItem>() { new DragonbornWaffleFries(), new FriedMiraak(), 
            //                                              new MadOtarGrits(), new VokunSalad() };
            List<IOrderItem> sides = new List<IOrderItem>();
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                    
                DragonbornWaffleFries itemFries = new DragonbornWaffleFries();
                itemFries.Size = size;
                sides.Add(itemFries);

                FriedMiraak itemMiraak = new FriedMiraak();
                itemMiraak.Size = size;
                sides.Add(itemMiraak);

                MadOtarGrits itemGrits = new MadOtarGrits();
                itemGrits.Size = size;
                sides.Add(itemGrits);

                VokunSalad itemSalad = new VokunSalad();
                itemSalad.Size = size;
                sides.Add(itemSalad);
            }
            return sides;
        }

        /// <summary>
        /// an instance of all available Drinks offered by Bleakwind Buffet
        /// </summary>
        /// <returns> IEnumerable of Drinks </returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();
            
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {

                AretinoAppleJuice itemJuice = new AretinoAppleJuice();
                itemJuice.Size = size;
                drinks.Add(itemJuice);

                CandlehearthCoffee itemCoffee = new CandlehearthCoffee();
                itemCoffee.Size = size;
                drinks.Add(itemCoffee);

                CandlehearthCoffee itemCoffeeDecaf = new CandlehearthCoffee();
                itemCoffeeDecaf.Size = size;
                itemCoffeeDecaf.Decaf = true;
                drinks.Add(itemCoffeeDecaf);

                MarkarthMilk itemMilk = new MarkarthMilk();
                itemMilk.Size = size;
                drinks.Add(itemMilk);

                WarriorWater itemWater = new WarriorWater();
                itemWater.Size = size;
                drinks.Add(itemWater);


                
                foreach (SodaFlavor flavor in Enum.GetValues(typeof(SodaFlavor)))
                {
                    SailorSoda itemSoda = new SailorSoda();
                    itemSoda.Size = size;
                    itemSoda.Flavor = flavor;
                    drinks.Add(itemSoda);
                }
                
            }
            return drinks;
        }

        /// <summary>
        /// This static method will call on the methods Entrees, Sides, and Drinks
        /// and combine these 
        /// </summary>
        /// <returns> IEnumerable list of all menu food items</returns>
        public static IEnumerable<IOrderItem> FullMenu()
        {
            List<IOrderItem> FullMenu = new List<IOrderItem>();

            FullMenu.AddRange(Entrees());
            FullMenu.AddRange(Sides());
            FullMenu.AddRange(Drinks());

            return FullMenu;
        }

    }
}
