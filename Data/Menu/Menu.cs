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
        //It might be a good idea to make 3 categories here for the displayed Entrees, Sides, drinks
        
        /// <summary>
        /// Gets the possible Food types. Displayed in html code as checkboxes
        /// </summary>
        public static string[] FoodTypes
        {
            get => new string[]
            {
            "Entrees",
            "Sides",
            "Drinks",
            };
        }

        /// <summary>
        /// This method filters through the food types checkboxed by the website user and removes them from the list to be displayed
        /// </summary>
        /// <param name="foodList">a list of entrees, sides, or drinks</param>
        /// <param name="type"></param>
        /// <returns>List of food items or and empty list if it contains the string</returns>
        public static IEnumerable<IOrderItem> FilterByType(IEnumerable<IOrderItem> foodList, IEnumerable<string> type)
        {
            
            List<IOrderItem> emptyList = new List<IOrderItem>(); //create an empty list to return
            var firstElement = foodList.FirstOrDefault();
            if (type == null || type.Count() == 0) return foodList; //confirming checkboxes... but problem is multiple are checked
            if (firstElement is Entree && type.Contains("Entrees"))
            {
                return foodList;
            }
            else if (firstElement is Side && type.Contains("Sides"))
            {
                return foodList;
            }
            else if (firstElement is Drink && type.Contains("Drinks"))
            {
                return foodList;
            }
            return emptyList; //return original list
        }

        /// <summary>
        /// Searches for through the list of food items to find terms that match the search string specified by user
        /// </summary>
        /// <param name="foodList">a list of IOrderItems to search through</param>
        /// <param name="terms">a string specified by user</param>
        /// <returns>A filtered list of food items based on their strings/names</returns>
        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem> foodList, string terms) //term we are searching for
        {
            List<IOrderItem> results = new List<IOrderItem>(); //create an empty list to return
            //var firstElement = foodList.FirstOrDefault();
            if (terms == null) return foodList; //confirming checkboxes... but problem is multiple are checked
                foreach(IOrderItem foodItem in foodList)
                {
                    string foodName = foodItem.ToString();
                    if (foodName.Contains(terms, StringComparison.CurrentCultureIgnoreCase))
                    {
                        results.Add(foodItem);
                    }
                }
                return results;
        }

        /// <summary>
        /// This filters the IOrderItems by the Calories and adds them to a list if within the range
        /// </summary>
        /// <param name="foodList">List of food items</param>
        /// <param name="min">minimum Calories specified by user</param>
        /// <param name="max">maximum Calories specified by user</param>
        /// <returns>A list of Calorie filtered food items</returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> foodList, uint? min, uint? max)
        {
            List<IOrderItem> results = new List<IOrderItem>(); //create an empty list to return
            if ((min == 0 || min == null) && (max == 0 || max == null)) return foodList;
            // only a minimum specified
            if (max == null || max == 0)
            {
                foreach (IOrderItem foodItem in foodList)
                {
                    if (foodItem.Calories >= min) results.Add(foodItem);
                }
                return results;
            }
            // only a maximum specified
            if (min == null || min == 0)
            {
                foreach (IOrderItem foodItem in foodList)
                {
                    if (foodItem.Calories <= max) results.Add(foodItem);
                }
                return results;
            }
            // Both minimum and maximum specified
            foreach (IOrderItem foodItem in foodList)
            {
                if (foodItem.Calories >= min && foodItem.Calories <= max)
                {
                    results.Add(foodItem);
                }
            }
            return results;
        }

        /// <summary>
        /// This filters the IOrderItems by the Price and adds them to a list if within the range
        /// </summary>
        /// <param name="foodList">List of food items</param>
        /// <param name="min">minimum price specified by user</param>
        /// <param name="max">maximum price specified by user</param>
        /// <returns>A list of price filtered food items</returns>
        public static IEnumerable<IOrderItem> FilterByPrices(IEnumerable<IOrderItem> foodList, double? min, double? max)
        {
            List<IOrderItem> results = new List<IOrderItem>(); //create an empty list to return
            if ((min == 0 || min == null) && (max == 0 || max == null)) return foodList;
            // only a minimum specified
            if (max == null || max == 0)
            {
                foreach (IOrderItem foodItem in foodList)
                {
                    if (foodItem.Price >= min) results.Add(foodItem);
                }
                return results;
            }
            // only a maximum specified
            if (min == null || min == 0)
            {
                foreach (IOrderItem foodItem in foodList)
                {
                    if (foodItem.Price <= max) results.Add(foodItem);
                }
                return results;
            }
            // Both minimum and maximum specified
            foreach (IOrderItem foodItem in foodList)
            {
                if (foodItem.Price >= min && foodItem.Price <= max)
                {
                    results.Add(foodItem);
                }
            }
            return results;
        }

        /// <summary>
        /// A method to handle the search terms using lower case notation(found online)
        /// </summary>
        /// <param name="original"></param>
        /// <param name="checkString"></param>
        /// <param name="compare"></param>
        /// <returns>True if the string contains a string that matches in parameter</returns>
        public static bool Contains(this string original, string checkString, StringComparison compare)
        {
            return original?.IndexOf(checkString, compare) >= 0;
        }

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
            }
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {

                FriedMiraak itemMiraak = new FriedMiraak();
                itemMiraak.Size = size;
                sides.Add(itemMiraak);
            }
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                MadOtarGrits itemGrits = new MadOtarGrits();
                itemGrits.Size = size;
                sides.Add(itemGrits);
            }
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
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
        /// Gets a list of all drinks without all the soda flavors included
        /// </summary>
        /// <returns>a list of all drinks</returns>
        public static IEnumerable<IOrderItem> DrinksNoFlavors()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();

            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                AretinoAppleJuice itemJuice = new AretinoAppleJuice();
                itemJuice.Size = size;
                drinks.Add(itemJuice);

            }
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                CandlehearthCoffee itemCoffee = new CandlehearthCoffee();
                itemCoffee.Size = size;
                drinks.Add(itemCoffee);
            }
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {

                MarkarthMilk itemMilk = new MarkarthMilk();
                itemMilk.Size = size;
                drinks.Add(itemMilk);
            }
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                WarriorWater itemWater = new WarriorWater();
                itemWater.Size = size;
                drinks.Add(itemWater);
            }
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                SailorSoda itemSoda = new SailorSoda();
                itemSoda.Size = size;
                drinks.Add(itemSoda);
            }
            return drinks;
        }

        /// <summary>
        /// This gets a list of all sizes of Sailor soda 
        /// </summary>
        /// <returns>a list of sailor sodas</returns>
        public static IEnumerable<IOrderItem> DrinksSoda()
        {
            List<IOrderItem> drinksSodas = new List<IOrderItem>();
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                SailorSoda itemSoda = new SailorSoda();
                itemSoda.Size = size; 
                drinksSodas.Add(itemSoda);
            }
            return drinksSodas;
        }

        /// <summary>
        /// This accumulates a list of all the SailorSoda flavors
        /// </summary>
        /// <returns>a list of soda flavors</returns>
        public static IEnumerable<SodaFlavor> DrinksSodaFlavors()
        {
            List<SodaFlavor> drinksSodaFlavors = new List<SodaFlavor>();
            foreach(SodaFlavor flavor in Enum.GetValues(typeof(SodaFlavor)))
            {
                drinksSodaFlavors.Add(flavor);
            }
            return drinksSodaFlavors;
        }

        /// <summary>
        /// Adds all entrees comboed with fries and a cherry soda
        /// </summary>
        /// <returns>all entrees paired with fries and soda</returns>
        public static IEnumerable<IOrderItem> ComboExamples()
        {
            List<IOrderItem> combosExample = new List<IOrderItem>();
            SailorSoda drink = new SailorSoda();
            DragonbornWaffleFries side = new DragonbornWaffleFries();
            foreach (Entree entree in Entrees())
            {
                ComboOrder combo = new ComboOrder(entree, side, drink);
                combosExample.Add(combo);
            }
            return combosExample;
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
