/*
 * Author: Zachery Brunner
 * Class: VokunSaladTests.cs
 * Purpose: Test the VokunSalad.cs class in the Data library
 * Modified by: Albert Winemiller
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Interface;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
    public class VokunSaladTests
    {
        VokunSalad side = new VokunSalad();

        [Fact]
        public void ProfileShouldNotifyOfFoodSizeCustomizationChanges()
        {
            Assert.PropertyChanged(side, "Size", () => side.Size = Size.Medium);
            Assert.PropertyChanged(side, "Size", () => side.Size = Size.Large);
            Assert.PropertyChanged(side, "Size", () => side.Size = Size.Small);

            Assert.PropertyChanged(side, "Calories", () => side.Size = Size.Medium);
            Assert.PropertyChanged(side, "Calories", () => side.Size = Size.Large);
            Assert.PropertyChanged(side, "Calories", () => side.Size = Size.Small);

            Assert.PropertyChanged(side, "Price", () => side.Size = Size.Medium);
            Assert.PropertyChanged(side, "Price", () => side.Size = Size.Large);
            Assert.PropertyChanged(side, "Price", () => side.Size = Size.Small);
        }
        [Fact]
        public void CheckIsAssignableFromINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(side);
        }
        [Fact]
        public void CheckIsAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(side);
        }
        [Fact]
        public void ShouldBeADrink()
        {
            Assert.IsAssignableFrom<Side>(side);
        }
        [Fact]
        public void ShouldBeSmallByDefault()
        {
            Assert.Equal(Size.Small, side.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            side.Size = Size.Large;
            Assert.Equal(Size.Large, side.Size);
            side.Size = Size.Medium;
            Assert.Equal(Size.Medium, side.Size);
            side.Size = Size.Small;
            Assert.Equal(Size.Small, side.Size);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            Assert.Empty(side.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 0.93)]
        [InlineData(Size.Medium, 1.28)]
        [InlineData(Size.Large, 1.82)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
            side.Size = size;
            Assert.Equal(price, side.Price);
        }

        [Theory]
        [InlineData(Size.Small, 41)]
        [InlineData(Size.Medium, 52)]
        [InlineData(Size.Large, 73)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            side.Size = size;
            Assert.Equal(calories, side.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Vokun Salad")]
        [InlineData(Size.Medium, "Medium Vokun Salad")]
        [InlineData(Size.Large, "Large Vokun Salad")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            side.Size = size;
            Assert.Equal(name, side.ToString());
        }
    }
}