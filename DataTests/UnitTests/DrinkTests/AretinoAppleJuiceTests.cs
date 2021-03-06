﻿/*
 * Author: Zachery Brunner
 * Class: AretinoAppleJuiceTests.cs
 * Purpose: Test the AretinoAppleJuice.cs class in the Data library
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
    public class AretinoAppleJuiceTests
    {
        AretinoAppleJuice drink = new AretinoAppleJuice();

        [Fact]
        public void ShouldReturnCorrectDescription()
        {
            
            Assert.Equal("Fresh squeezed apple juice.", drink.Description);
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
        public void ShouldBeAbleToSetSize()
        {
            
            drink.Size = Size.Large;
            Assert.Equal(Size.Large, drink.Size);
            drink.Size = Size.Medium;
            Assert.Equal(Size.Medium, drink.Size);
            drink.Size = Size.Small;
            Assert.Equal(Size.Small, drink.Size);
        }
        [Fact]
        public void ShouldBeAbleToSetPrice()
        {
            Assert.Equal(0.62, drink.Price);
        }
            [Theory]
        [InlineData(Size.Small, 0.62)]
        [InlineData(Size.Medium, 0.87)]
        [InlineData(Size.Large, 1.01)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            
            drink.Size = size;
            Assert.Equal(price, drink.Price);
        }

        [Theory]
        [InlineData(Size.Small, 44)]
        [InlineData(Size.Medium, 88)]
        [InlineData(Size.Large, 132)]
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
        [InlineData(Size.Small, "Small Aretino Apple Juice")]
        [InlineData(Size.Medium, "Medium Aretino Apple Juice")]
        [InlineData(Size.Large, "Large Aretino Apple Juice")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            drink.Size = size;
            Assert.Equal(name, drink.ToString());
        }
    }
}