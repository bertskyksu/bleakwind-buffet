using System;
using Xunit;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Interface;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.DataTests.UnitTests.MenuTests
{
    public class ComboOrderTests
    {
        ComboOrder combo = new ComboOrder(new BriarheartBurger(), new FriedMiraak(), new SailorSoda());
        DoubleDraugr newEntree = new DoubleDraugr();
        MadOtarGrits newSide = new MadOtarGrits();
        MarkarthMilk newDrink = new MarkarthMilk();


        ComboOrder combo2 = new ComboOrder(new DoubleDraugr(), new MadOtarGrits(), new MarkarthMilk());

        [Fact]
        public void ComboShouldListenForChanges()
        {
            //this test will properly check for when a side/drink size changes in the combo, but but not the combo size itself
            //  newDrink.Size =    vs   combo.Drink.Size =   
            //this checks our event listeners
            ComboOrder combo3 = new ComboOrder(newEntree, newSide, newDrink);
            
            Assert.PropertyChanged(combo3, "Price", () => newSide.Size = Size.Large);
            Assert.PropertyChanged(combo3, "Price", () => newSide.Size = Size.Medium);
            Assert.PropertyChanged(combo3, "Price", () => newSide.Size = Size.Small);
            Assert.PropertyChanged(combo3, "Calories", () => newSide.Size = Size.Large);
            Assert.PropertyChanged(combo3, "Calories", () => newSide.Size = Size.Medium);
            Assert.PropertyChanged(combo3, "Calories", () => newSide.Size = Size.Small);
            Assert.PropertyChanged(combo3, "SpecialInstructions", () => newSide.Size = Size.Large);
            Assert.PropertyChanged(combo3, "SpecialInstructions", () => newSide.Size = Size.Medium);
            Assert.PropertyChanged(combo3, "SpecialInstructions", () => newSide.Size = Size.Small);
            Assert.PropertyChanged(combo3, "Price", () => newDrink.Size = Size.Large);
            Assert.PropertyChanged(combo3, "Price", () => newDrink.Size = Size.Medium);
            Assert.PropertyChanged(combo3, "Price", () => newDrink.Size = Size.Small);
            Assert.PropertyChanged(combo3, "Calories", () => newDrink.Size = Size.Large);
            Assert.PropertyChanged(combo3, "Calories", () => newDrink.Size = Size.Medium);
            Assert.PropertyChanged(combo3, "Calories", () => newDrink.Size = Size.Small);
            Assert.PropertyChanged(combo3, "SpecialInstructions", () => newDrink.Size = Size.Large);
            Assert.PropertyChanged(combo3, "SpecialInstructions", () => newDrink.Size = Size.Medium);
            Assert.PropertyChanged(combo3, "SpecialInstructions", () => newDrink.Size = Size.Small);

        }
            [Fact]
        public void ComboShouldReturnCorrectPrice()
        {
            Assert.Equal(8.52, combo.Price);
            combo.Entree = newEntree;
            Assert.Equal(9.52, combo.Price);
            combo.Side = newSide;
            Assert.Equal(8.96, combo.Price);
            combo.Drink = new AretinoAppleJuice();
            Assert.Equal(8.16, combo.Price);
            Assert.Equal(1.05, newDrink.Price);
            combo.Drink = newDrink; //why does marcarth milk do this?
            //worst case i try to find a correction solution
            Assert.Equal(8.59, combo2.Price);
        }

        [Fact]
        public void ComboShouldReturnCorrectCalories()
        {
            Assert.Equal(1011.ToString(), (combo.Calories).ToString());
            combo.Entree = newEntree;
            Assert.Equal(1111.ToString(), (combo.Calories).ToString());
            combo.Side = newSide;
            Assert.Equal(1065.ToString(), (combo.Calories).ToString());
            combo.Drink = newDrink;
            Assert.Equal(1004.ToString(), (combo.Calories).ToString());
        }
        [Theory]
        [InlineData(true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false)]
        public void ComboShouldReturnCorrectSpecialInstructionsEntree(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese, bool includeTomato,
                                                                    bool includeLettuce, bool includeMayo)
        {
            ComboOrder combo3 = new ComboOrder(newEntree, newSide, newDrink);
            //List<IOrderItem> testlist = new List<IOrderItem>();
            //testlist.Add(newEntree);
            //testlist.Add(newSide);
            //testlist.Add(newDrink);

            newEntree.Bun = includeBun;
            newEntree.Ketchup = includeKetchup;
            newEntree.Mustard = includeMustard;
            newEntree.Pickle = includePickle;
            newEntree.Cheese = includeCheese;
            newEntree.Tomato = includeTomato;
            newEntree.Lettuce = includeLettuce;
            newEntree.Mayo = includeMayo;

            if (!includeBun) Assert.Contains("Hold bun", combo3.SpecialInstructions);
            if (!includeKetchup) Assert.Contains("Hold ketchup", combo3.SpecialInstructions);
            if (!includeMustard) Assert.Contains("Hold mustard", combo3.SpecialInstructions);
            if (!includePickle) Assert.Contains("Hold pickle", combo3.SpecialInstructions);
            if (!includeCheese) Assert.Contains("Hold cheese", combo3.SpecialInstructions);
            if (!includeTomato) Assert.Contains("Hold tomato", combo3.SpecialInstructions);
            if (!includeLettuce) Assert.Contains("Hold lettuce", combo3.SpecialInstructions);
            if (!includeMayo) Assert.Contains("Hold mayo", combo3.SpecialInstructions);
            else
            {
                Assert.Contains("Double Draugr", combo3.SpecialInstructions);
                Assert.Contains("Small Markarth Milk", combo3.SpecialInstructions);
                Assert.Contains("Small Mad Otar Grits", combo3.SpecialInstructions);
            } //should also include test cases for markarth milk nad mad otar grits specialInstructions
        } 


        [Theory]
        [InlineData(Size.Small, 8.52)]
        [InlineData(Size.Medium, 9.07)]
        [InlineData(Size.Large, 10.27)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            //Note: price - 1
            //assumeing briarheartBurger, friedMirakk, and SailorSoda
            combo.Side.Size = size;
            combo.Drink.Size = size;
            Assert.Equal(price, combo.Price);
        }

        [Theory]
        [InlineData(Size.Small, 1011)]
        [InlineData(Size.Medium, 1132)]
        [InlineData(Size.Large, 1254)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint calories)
        {
            //assumeing briarheartBurger, friedMirakk, and SailorSoda
            combo.Side.Size = size;
            combo.Drink.Size = size;
            Assert.Equal(calories, combo.Calories);
        }


        [Fact]
        public void ProfileShouldNotifyOfComboCaloriesChanges()
        {
            Assert.PropertyChanged(combo, "Calories", () => combo.Entree = newEntree);
            Assert.PropertyChanged(combo, "Calories", () => combo.Drink = newDrink);
            Assert.PropertyChanged(combo, "Calories", () => combo.Side = newSide);
        }

        [Fact]
        public void ProfileShouldNotifyOfComboPriceChanges()
        {
            Assert.PropertyChanged(combo, "Price", () => combo.Entree = newEntree);
            Assert.PropertyChanged(combo, "Price", () => combo.Drink = newDrink);
            Assert.PropertyChanged(combo, "Price", () => combo.Side = newSide);
        }
        [Fact]
        public void ProfileShouldNotifyOfComboSpecialInstructionChanges()
        {
            Assert.PropertyChanged(combo, "SpecialInstructions", () => combo.Entree = newEntree);
            Assert.PropertyChanged(combo, "SpecialInstructions", () => combo.Drink = newDrink);
            Assert.PropertyChanged(combo, "SpecialInstructions", () => combo.Side = newSide);
        }
    }
}
