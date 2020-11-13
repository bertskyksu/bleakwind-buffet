/*
 * Author: Zachery Brunner
 * Class: CandlehearthCoffeeTests.cs
 * Purpose: Test the CandlehearthCoffee.cs class in the Data library
 * Modified by: Albert Winemiller
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Interface;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    public class CandlehearthCoffeeTests
    {
        CandlehearthCoffee drink = new CandlehearthCoffee();


        [Fact]
        public void ShouldReturnCorrectDescription()
        {

            Assert.Equal("Fair trade, fresh ground dark roast coffee.", drink.Description);
        }
        [Fact]
        public void ProfileShouldNotifyOfFoodSizeCustomizationChanges()
        {
            Assert.PropertyChanged(drink, "Ice", () => drink.Ice = true);
            Assert.PropertyChanged(drink, "Ice", () => drink.Ice = false);
            Assert.PropertyChanged(drink, "RoomForCream", () => drink.RoomForCream = true);
            Assert.PropertyChanged(drink, "RoomForCream", () => drink.RoomForCream = false);
            Assert.PropertyChanged(drink, "Decaf", () => drink.Decaf = true);
            Assert.PropertyChanged(drink, "Decaf", () => drink.Decaf = false);

            Assert.PropertyChanged(drink, "Size", () => drink.Size = Size.Medium);
            Assert.PropertyChanged(drink, "Size", () => drink.Size = Size.Large);
            Assert.PropertyChanged(drink, "Size", () => drink.Size = Size.Small);

            Assert.PropertyChanged(drink, "Calories", () => drink.Size = Size.Medium);
            Assert.PropertyChanged(drink, "Calories", () => drink.Size = Size.Large);
            Assert.PropertyChanged(drink, "Calories", () => drink.Size = Size.Small);

            Assert.PropertyChanged(drink, "Price", () => drink.Size = Size.Medium);
            Assert.PropertyChanged(drink, "Price", () => drink.Size = Size.Large);
            Assert.PropertyChanged(drink, "Price", () => drink.Size = Size.Small);
        }
        [Fact]
        public void CheckIsAssignableFromINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(drink);
        }
        [Fact]
        public void CheckIsAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(drink);
        }
        [Fact]
        public void ShouldBeADrink()
        {

            Assert.IsAssignableFrom<Drink>(drink);
        }
        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {
            Assert.False(drink.Ice);
        }

        [Fact]
        public void ShouldNotBeDecafByDefault()
        {
            Assert.False(drink.Decaf);
        }

        [Fact]
        public void ShouldNotHaveRoomForCreamByDefault()
        {
            Assert.False(drink.RoomForCream);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            Assert.Equal(Size.Small, drink.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            drink.Ice = true;
            Assert.True(drink.Ice);
            drink.Ice = false;
            Assert.False(drink.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetDecaf()
        {
            drink.Decaf = true;
            Assert.True(drink.Decaf);
            drink.Decaf = false;
            Assert.False(drink.Decaf);
        }

        [Fact]
        public void ShouldBeAbleToSetRoomForCream()
        {
            drink.RoomForCream = true;
            Assert.True(drink.RoomForCream);
            drink.RoomForCream = false;
            Assert.False(drink.RoomForCream);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            drink.Size = Size.Large;
            Assert.Equal(Size.Large, drink.Size);
            drink.Size = Size.Medium;
            Assert.Equal(Size.Medium, drink.Size);
            drink.Size = Size.Small;
            Assert.Equal(Size.Small, drink.Size);
        }

        [Theory]
        [InlineData(Size.Small, 0.75)]
        [InlineData(Size.Medium, 1.25)]
        [InlineData(Size.Large, 1.75)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            drink.Size = size;
            Assert.Equal(price, drink.Price);
        }

        [Theory]
        [InlineData(Size.Small, 7)]
        [InlineData(Size.Medium, 10)]
        [InlineData(Size.Large, 20)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            drink.Size = size;
            Assert.Equal(cal, drink.Calories);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeCream)
        {
            drink.Ice = includeIce;
            drink.RoomForCream = includeCream;
            if (includeIce) Assert.Contains("Add ice", drink.SpecialInstructions);
         
            else if (includeCream) Assert.Contains("Add cream", drink.SpecialInstructions);
            else Assert.Empty(drink.SpecialInstructions);
        }

        [Theory]
        [InlineData(true, Size.Small, "Small Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Medium, "Medium Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Large, "Large Decaf Candlehearth Coffee")]
        [InlineData(false, Size.Small, "Small Candlehearth Coffee")]
        [InlineData(false, Size.Medium, "Medium Candlehearth Coffee")]
        [InlineData(false, Size.Large, "Large Candlehearth Coffee")]
        public void ShouldReturnCorrectToStringBasedOnSize(bool decaf, Size size, string name)
        {
            drink.Size = size;
            drink.Decaf = decaf;
            Assert.Equal(name, drink.ToString());
        }
    }
}
