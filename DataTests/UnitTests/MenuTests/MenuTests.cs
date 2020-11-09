using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Interface;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using Xunit;
using System.Linq;

namespace BleakwindBuffet.DataTests.UnitTests.MenuTests
{
    public class MenuTests
    {
        public IEnumerable<IOrderItem> Entrees { get; set; }
        public IEnumerable<IOrderItem> Entrees2 { get; set; }
        public IEnumerable<IOrderItem> Entrees3 { get; set; }
        public IEnumerable<IOrderItem> Sides { get; set; }
        public IEnumerable<IOrderItem> Sides2 { get; set; }
        public IEnumerable<IOrderItem> Drinks { get; set; }
        public IEnumerable<IOrderItem> Drinks2 { get; set; }

        public string[] CategoriesEmptyList = { "Entrees", "Sides", "Drinks" };
        public string[] CategoriesNoEntrees = { "Sides", "Drinks" };
        public string[] CategoriesNoSides = { "Entrees", "Drinks" };
        public string[] CategoriesNoDrinks = { "Entrees", "Sides" };
        [Fact]
        public void ReturnCorrectComboExamples()
        {
            IEnumerable<IOrderItem> combosExample = Menu.ComboExamples();

            //Assert.Contains(combosExample, (item) => { return item.Price.ToString().Equals(7.16); });
            
       
               // Entree e = combo.Entree;
                Assert.Contains(combosExample, (item) => { return item.Price.ToString().Equals("7.16"); });

        }

        [Fact]
        public void ReturnCorrectFilterByCalories()
        {
            Entrees = Menu.Entrees();
            Entrees2 = Menu.Entrees();
            Entrees3 = Menu.Entrees();
            Sides = Menu.Sides();
            Drinks = Menu.Drinks();

            

            Entrees = Menu.FilterByCalories(Entrees, 170, 800);
            Sides = Menu.FilterByCalories(Sides, 170, 800);
            Drinks = Menu.FilterByCalories(Drinks, 170, 800);

            
            Assert.Contains(Entrees, (item) => { return item is BriarheartBurger; });
            Assert.DoesNotContain(Entrees, (item) => { return item is DoubleDraugr; });
            Assert.Contains(Entrees, (item) => { return item is GardenOrcOmelette; });
            Assert.Contains(Entrees, (item) => { return item is PhillyPoacher; });
            Assert.Contains(Entrees, (item) => { return item is SmokehouseSkeleton; });
            Assert.DoesNotContain(Entrees, (item) => { return item is ThalmorTriple; });
            Assert.DoesNotContain(Entrees, (item) => { return item is ThugsTBone; });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Aretino Apple Juice"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Aretino Apple Juice"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Aretino Apple Juice"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Decaf Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Decaf Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Decaf Candlehearth Coffee"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Candlehearth Coffee"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Markarth Milk"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Markarth Milk"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Markarth Milk"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Warrior Water"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Warrior Water"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Warrior Water"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Dragonborn Waffle Fries"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Dragonborn Waffle Fries"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Large Dragonborn Waffle Fries"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Fried Miraak"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Medium Fried Miraak"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Large Fried Miraak"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Mad Otar Grits"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Mad Otar Grits"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Large Mad Otar Grits"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Vokun Salad"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Vokun Salad"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Large Vokun Salad"); });

            Entrees2 = Menu.FilterByCalories(Entrees2, 500, 0);
            Assert.Contains(Entrees2, (item) => { return item is BriarheartBurger; });
            Assert.Contains(Entrees2, (item) => { return item is DoubleDraugr; });
            Assert.DoesNotContain(Entrees2, (item) => { return item is GardenOrcOmelette; });
            Assert.Contains(Entrees2, (item) => { return item is PhillyPoacher; });
            Assert.Contains(Entrees2, (item) => { return item is SmokehouseSkeleton; });
            Assert.Contains(Entrees2, (item) => { return item is ThalmorTriple; });
            Assert.Contains(Entrees2, (item) => { return item is ThugsTBone; });

            Entrees3 = Menu.FilterByCalories(Entrees3, 0, 1500);
            Assert.Contains(Entrees3, (item) => { return item is BriarheartBurger; });
            Assert.Contains(Entrees3, (item) => { return item is DoubleDraugr; });
            Assert.Contains(Entrees3, (item) => { return item is GardenOrcOmelette; });
            Assert.Contains(Entrees3, (item) => { return item is PhillyPoacher; });
            Assert.Contains(Entrees3, (item) => { return item is SmokehouseSkeleton; });
            Assert.Contains(Entrees3, (item) => { return item is ThalmorTriple; });
            Assert.Contains(Entrees3, (item) => { return item is ThugsTBone; });
        }
        [Fact]
        public void ReturnCorrectFilterByPrices()
        {
            Entrees = Menu.Entrees();
            Entrees2 = Menu.Entrees();
            Sides = Menu.Sides();
            Sides2 = Menu.Sides();
            Drinks = Menu.Drinks();
            Entrees3 = Menu.Entrees();

            Entrees = Menu.FilterByPrices(Entrees, 2.0, 7.0);
            Sides = Menu.FilterByPrices(Sides, 2.0, 7.0);
            Drinks = Menu.FilterByPrices(Drinks, 2.0, 7.0);

            Assert.Contains(Menu.FilterByPrices(Entrees, 2.0, 7.0), (item) => { return item is BriarheartBurger; });
            Assert.DoesNotContain(Entrees, (item) => { return item is DoubleDraugr; });
            Assert.Contains(Entrees, (item) => { return item is GardenOrcOmelette; });
            Assert.DoesNotContain(Entrees, (item) => { return item is PhillyPoacher; });
            Assert.Contains(Entrees, (item) => { return item is SmokehouseSkeleton; });
            Assert.DoesNotContain(Entrees, (item) => { return item is ThalmorTriple; });
            Assert.Contains(Entrees, (item) => { return item is ThugsTBone; });



            Assert.DoesNotContain(Menu.FilterByPrices(Drinks, 2.0, 7.0), (item) => { return item is AretinoAppleJuice; });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Aretino Apple Juice"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Aretino Apple Juice"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Aretino Apple Juice"); });
            Assert.DoesNotContain(Menu.FilterByPrices(Drinks, 2.0, 7.0), (item) => { return item is CandlehearthCoffee; });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Decaf Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Decaf Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Decaf Candlehearth Coffee"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Candlehearth Coffee"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Markarth Milk"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Markarth Milk"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Markarth Milk"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Warrior Water"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Warrior Water"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Warrior Water"); });

            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Dragonborn Waffle Fries"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Dragonborn Waffle Fries"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Large Dragonborn Waffle Fries"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Fried Miraak"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Medium Fried Miraak"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Large Fried Miraak"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Mad Otar Grits"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Mad Otar Grits"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Large Mad Otar Grits"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Vokun Salad"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Vokun Salad"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Large Vokun Salad"); });

            Entrees2 = Menu.FilterByPrices(Entrees2, 0.0, 0.0);
            Assert.Contains(Entrees2, (item) => { return item is DoubleDraugr; });
            Assert.Contains(Entrees2, (item) => { return item is GardenOrcOmelette; });
            Assert.Contains(Entrees2, (item) => { return item is PhillyPoacher; });
            Assert.Contains(Entrees2, (item) => { return item is SmokehouseSkeleton; });
            Assert.Contains(Entrees2, (item) => { return item is ThalmorTriple; });
            Assert.Contains(Entrees2, (item) => { return item is ThugsTBone; });

            Sides2 = Menu.FilterByPrices(Sides2, 0.0, 5.0);
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Small Dragonborn Waffle Fries"); });
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Medium Dragonborn Waffle Fries"); });
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Large Dragonborn Waffle Fries"); });

            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Small Fried Miraak"); });
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Medium Fried Miraak"); });
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Large Fried Miraak"); });
            
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Small Mad Otar Grits"); });
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Medium Mad Otar Grits"); });
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Large Mad Otar Grits"); });

            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Small Vokun Salad"); });
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Medium Vokun Salad"); });
            Assert.Contains(Sides2, (item) => { return item.ToString().Equals("Large Vokun Salad"); });

            Entrees3 = Menu.FilterByPrices(Entrees3, 5.0, 0.0);
            Assert.Contains(Entrees3, (item) => { return item is DoubleDraugr; });
            Assert.DoesNotContain(Entrees3, (item) => { return item is GardenOrcOmelette; });
            Assert.Contains(Entrees3, (item) => { return item is PhillyPoacher; });
            Assert.Contains(Entrees3, (item) => { return item is SmokehouseSkeleton; });
            Assert.Contains(Entrees3, (item) => { return item is ThalmorTriple; });
            Assert.Contains(Entrees3, (item) => { return item is ThugsTBone; });
        }
        [Fact]
        public void ReturnCorrectFilterByTypes()
        {
            Entrees = Menu.Entrees();
            //Entrees = Menu.FilterByType(Entrees, CategoriesEmptyList);

            Sides = Menu.Sides();
            Sides = Menu.FilterByType(Sides, CategoriesEmptyList);

            Drinks = Menu.Drinks();
            Drinks = Menu.FilterByType(Drinks, CategoriesEmptyList);

            Assert.Contains(Menu.FilterByType(Entrees, CategoriesEmptyList), (item) => { return item is BriarheartBurger; });
            Assert.Contains(Entrees, (item) => { return item is DoubleDraugr; });
            Assert.Contains(Entrees, (item) => { return item is GardenOrcOmelette; });
            Assert.Contains(Entrees, (item) => { return item is PhillyPoacher; });
            Assert.Contains(Entrees, (item) => { return item is SmokehouseSkeleton; });
            Assert.Contains(Entrees, (item) => { return item is ThalmorTriple; });
            Assert.Contains(Entrees, (item) => { return item is ThugsTBone; });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Aretino Apple Juice"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Medium Aretino Apple Juice"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Large Aretino Apple Juice"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Decaf Candlehearth Coffee"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Medium Decaf Candlehearth Coffee"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Large Decaf Candlehearth Coffee"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Candlehearth Coffee"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Medium Candlehearth Coffee"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Large Candlehearth Coffee"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Markarth Milk"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Medium Markarth Milk"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Large Markarth Milk"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Warrior Water"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Medium Warrior Water"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Large Warrior Water"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });

            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Small Dragonborn Waffle Fries"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Medium Dragonborn Waffle Fries"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Large Dragonborn Waffle Fries"); });

            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Small Fried Miraak"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Medium Fried Miraak"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Large Fried Miraak"); });

            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Small Mad Otar Grits"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Medium Mad Otar Grits"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Large Mad Otar Grits"); });

            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Small Vokun Salad"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Medium Vokun Salad"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Large Vokun Salad"); });

            Entrees = Menu.FilterByType(Entrees, CategoriesNoEntrees);
            int count = Entrees.Count();
            Assert.Equal(0, count); //empty list

            Sides = Menu.FilterByType(Sides, CategoriesNoSides);
            count = Sides.Count();
            Assert.Equal(0, count); //empty list

            Drinks = Menu.FilterByType(Drinks, CategoriesNoDrinks);
            count = Drinks.Count();
            Assert.Equal(0, count); //empty list
        }
        [Fact]
        public void ReturnCorrectFilterBySearch()
        {
            Entrees = Menu.Entrees();
            Sides = Menu.Sides();
            Drinks = Menu.Drinks();

            Entrees = Menu.Search(Entrees, "Burger");
            Sides = Menu.Search(Sides, "Fried");
            Drinks = Menu.Search(Drinks, "Small");

            Assert.Contains(Entrees, (item) => { return item is BriarheartBurger; });
            Assert.DoesNotContain(Entrees, (item) => { return item is DoubleDraugr; });
            Assert.DoesNotContain(Entrees, (item) => { return item is GardenOrcOmelette; });
            Assert.DoesNotContain(Entrees, (item) => { return item is PhillyPoacher; });
            Assert.DoesNotContain(Entrees, (item) => { return item is SmokehouseSkeleton; });
            Assert.DoesNotContain(Entrees, (item) => { return item is ThalmorTriple; });
            Assert.DoesNotContain(Entrees, (item) => { return item is ThugsTBone; });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Aretino Apple Juice"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Aretino Apple Juice"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Aretino Apple Juice"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Decaf Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Decaf Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Decaf Candlehearth Coffee"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Candlehearth Coffee"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Candlehearth Coffee"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Markarth Milk"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Markarth Milk"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Markarth Milk"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Warrior Water"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Warrior Water"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Warrior Water"); });

            Assert.Contains(Drinks, (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.DoesNotContain(Drinks, (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Dragonborn Waffle Fries"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Dragonborn Waffle Fries"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Large Dragonborn Waffle Fries"); });

            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Small Fried Miraak"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Medium Fried Miraak"); });
            Assert.Contains(Sides, (item) => { return item.ToString().Equals("Large Fried Miraak"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Mad Otar Grits"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Mad Otar Grits"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Large Mad Otar Grits"); });

            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Small Vokun Salad"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Medium Vokun Salad"); });
            Assert.DoesNotContain(Sides, (item) => { return item.ToString().Equals("Large Vokun Salad"); });
        }


        [Fact]
        public void ReturnAllDrinksNoFlavors()
        {
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Small Aretino Apple Juice"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Medium Aretino Apple Juice"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Large Aretino Apple Juice"); });

            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Small Candlehearth Coffee"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Medium Candlehearth Coffee"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Large Candlehearth Coffee"); });

            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Small Markarth Milk"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Medium Markarth Milk"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Large Markarth Milk"); });

            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Small Warrior Water"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Medium Warrior Water"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Large Warrior Water"); });

            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.Contains(Menu.DrinksNoFlavors(), (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });
        }

        [Fact]
        public void ReturnAllDrinksSoda()
        {
            Assert.Contains(Menu.DrinksSoda(), (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.Contains(Menu.DrinksSoda(), (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.Contains(Menu.DrinksSoda(), (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });
        }

        [Fact]
        public void ReturnAllDrinksSodaFlavors()
        {
            Assert.Contains(Menu.DrinksSodaFlavors(), (item) => { return item.ToString().Equals("Blackberry"); });
            Assert.Contains(Menu.DrinksSodaFlavors(), (item) => { return item.ToString().Equals("Cherry"); });
            Assert.Contains(Menu.DrinksSodaFlavors(), (item) => { return item.ToString().Equals("Grapefruit"); });
            Assert.Contains(Menu.DrinksSodaFlavors(), (item) => { return item.ToString().Equals("Lemon"); });
            Assert.Contains(Menu.DrinksSodaFlavors(), (item) => { return item.ToString().Equals("Peach"); });
            Assert.Contains(Menu.DrinksSodaFlavors(), (item) => { return item.ToString().Equals("Watermelon"); });
        }
        /*
        [Fact]
        public void ReturnAllComboExamples()
        {
            Assert.Contains(Menu.ComboExamples(), (item) => { return item.ToString().Equals("Briarheart Burger"); });
            
        }
        */
        [Fact]
        public void ReturnAllEntrees()
        {
            Assert.Contains(Menu.Entrees(), (item) => { return item is BriarheartBurger; });
            Assert.Contains(Menu.Entrees(), (item) => { return item is DoubleDraugr; });
            Assert.Contains(Menu.Entrees(), (item) => { return item is GardenOrcOmelette; });
            Assert.Contains(Menu.Entrees(), (item) => { return item is PhillyPoacher; });
            Assert.Contains(Menu.Entrees(), (item) => { return item is SmokehouseSkeleton; });
            Assert.Contains(Menu.Entrees(), (item) => { return item is ThalmorTriple; });
            Assert.Contains(Menu.Entrees(), (item) => { return item is ThugsTBone; });
        }

        [Fact]
        public void ReturnAllDrinksWithoutSoda()
        {
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Aretino Apple Juice"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Aretino Apple Juice"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Aretino Apple Juice"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Decaf Candlehearth Coffee"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Decaf Candlehearth Coffee"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Decaf Candlehearth Coffee"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Candlehearth Coffee"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Candlehearth Coffee"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Candlehearth Coffee"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Markarth Milk"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Markarth Milk"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Markarth Milk"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Warrior Water"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Warrior Water"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Warrior Water"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });
        }

        [Fact]
        public void ReturnAllSodaDrinks()
        {
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Blackberry Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Blackberry Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Blackberry Sailor Soda"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Grapefruit Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Grapefruit Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Grapefruit Sailor Soda"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Lemon Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Lemon Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Lemon Sailor Soda"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Peach Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Peach Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Lemon Sailor Soda"); });

            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Small Watermelon Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Medium Watermelon Sailor Soda"); });
            Assert.Contains(Menu.Drinks(), (item) => { return item.ToString().Equals("Large Watermelon Sailor Soda"); });

        }

        [Fact]
        public void ReturnAllSides()
        {
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Small Dragonborn Waffle Fries"); });
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Medium Dragonborn Waffle Fries"); });
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Large Dragonborn Waffle Fries"); });

            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Small Fried Miraak"); });
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Medium Fried Miraak"); });
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Large Fried Miraak"); });

            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Small Mad Otar Grits"); });
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Medium Mad Otar Grits"); });
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Large Mad Otar Grits"); });

            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Small Vokun Salad"); });
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Medium Vokun Salad"); });
            Assert.Contains(Menu.Sides(), (item) => { return item.ToString().Equals("Large Vokun Salad"); });
        }

        
        [Fact]
        public void ReturnFullMenuAllEntrees()
        {
            Assert.Contains(Menu.FullMenu(), (item) => { return item is BriarheartBurger; });
            Assert.Contains(Menu.FullMenu(), (item) => { return item is DoubleDraugr; });
            Assert.Contains(Menu.FullMenu(), (item) => { return item is GardenOrcOmelette; });
            Assert.Contains(Menu.FullMenu(), (item) => { return item is PhillyPoacher; });
            Assert.Contains(Menu.FullMenu(), (item) => { return item is SmokehouseSkeleton; });
            Assert.Contains(Menu.FullMenu(), (item) => { return item is ThalmorTriple; });
            Assert.Contains(Menu.FullMenu(), (item) => { return item is ThugsTBone; });
        }

        [Fact]
        public void ReturnFullMenuAllDrinksWithoutSoda()
        {
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Aretino Apple Juice"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Aretino Apple Juice"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Aretino Apple Juice"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Decaf Candlehearth Coffee"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Decaf Candlehearth Coffee"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Decaf Candlehearth Coffee"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Candlehearth Coffee"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Candlehearth Coffee"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Candlehearth Coffee"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Markarth Milk"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Markarth Milk"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Markarth Milk"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Warrior Water"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Warrior Water"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Warrior Water"); });

        }

        [Fact]
        public void ReturnFullMenuAllSodaDrinks()
        {
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Blackberry Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Blackberry Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Blackberry Sailor Soda"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Cherry Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Cherry Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Cherry Sailor Soda"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Grapefruit Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Grapefruit Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Grapefruit Sailor Soda"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Lemon Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Lemon Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Lemon Sailor Soda"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Peach Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Peach Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Lemon Sailor Soda"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Watermelon Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Watermelon Sailor Soda"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Watermelon Sailor Soda"); });

        }

        [Fact]
        public void ReturnFullMenuAllSides()
        {
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Dragonborn Waffle Fries"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Dragonborn Waffle Fries"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Dragonborn Waffle Fries"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Fried Miraak"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Fried Miraak"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Fried Miraak"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Mad Otar Grits"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Mad Otar Grits"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Mad Otar Grits"); });

            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Small Vokun Salad"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Medium Vokun Salad"); });
            Assert.Contains(Menu.FullMenu(), (item) => { return item.ToString().Equals("Large Vokun Salad"); });
        }
    }
}
