/*
 * Author: Zachery Brunner
 * Class: MarkarthMilkTests.cs
 * Purpose: Test the MarkarthMilk.cs class in the Data library
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
    public class MarkarthMilkTests
    {
        MarkarthMilk drink = new MarkarthMilk();

        [Fact]
        public void ShouldReturnCorrectDescription()
        {

            Assert.Equal("Hormone-free organic 2% milk.", drink.Description);
        }
        [Fact]
        public void ProfileShouldNotifyOfFoodSizeCustomizationChanges()
        {
            Assert.PropertyChanged(drink, "Ice", () => drink.Ice = true);
            Assert.PropertyChanged(drink, "Ice", () => drink.Ice = false);

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
        public void ShouldBySmallByDefault()
        {
            Assert.Equal(Size.Small, drink.Size);
        }

        [Fact]
        public void ShouldByAbleToSetIce()
        {
            drink.Ice = true;
            Assert.True(drink.Ice);
            drink.Ice = false;
            Assert.False(drink.Ice);
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
        [InlineData(Size.Small, 1.05)]
        [InlineData(Size.Medium, 1.11)]
        [InlineData(Size.Large, 1.22)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            drink.Size = size;
            Assert.Equal(price, drink.Price);
        }

        [Theory]
        [InlineData(Size.Small, 56)]
        [InlineData(Size.Medium, 72)]
        [InlineData(Size.Large, 93)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            drink.Size = size;
            Assert.Equal(cal, drink.Calories);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce)
        {
            drink.Ice = includeIce;
            if (includeIce) Assert.Contains("Add ice", drink.SpecialInstructions);
            else Assert.Empty(drink.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, "Small Markarth Milk")]
        [InlineData(Size.Medium, "Medium Markarth Milk")]
        [InlineData(Size.Large, "Large Markarth Milk")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            drink.Size = size;
            Assert.Equal(name, drink.ToString());
        }
    }
}