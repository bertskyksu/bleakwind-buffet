/*
 * Author: Zachery Brunner
 * Class: PhillyPoacherTests.cs
 * Purpose: Test the PhillyPoacher.cs class in the Data library
 * Modified by: Albert Winemiller
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class PhillyPoacherTests
    {
        PhillyPoacher entree = new PhillyPoacher();

        [Fact]
        public void ProfileShouldNotifyOfFoodCustomizationChanges()
        {
            Assert.PropertyChanged(entree, "Sirloin", () => entree.Sirloin = false);
            Assert.PropertyChanged(entree, "Onion", () => entree.Onion = false);
            Assert.PropertyChanged(entree, "Roll", () => entree.Roll = false);

        }
        [Fact]
        public void CheckIsAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(entree);
        }
        [Fact]
        public void ShouldBeADrink()
        {
            Assert.IsAssignableFrom<Entree>(entree);
        }
        [Fact]
        public void ShouldInlcudeSirloinByDefault()
        {
            Assert.True(entree.Sirloin);
        }

        [Fact]
        public void ShouldInlcudeOnionByDefault()
        {
            Assert.True(entree.Onion);
        }

        [Fact]
        public void ShouldInlcudeRollByDefault()
        {
            Assert.True(entree.Roll);
        }

        [Fact]
        public void ShouldBeAbleToSetSirloin()
        {
            entree.Sirloin = true;
            Assert.True(entree.Sirloin);
            entree.Sirloin = false;
            Assert.False(entree.Sirloin);
        }

        [Fact]
        public void ShouldBeAbleToSetOnions()
        {
            entree.Onion = true;
            Assert.True(entree.Onion);
            entree.Onion = false;
            Assert.False(entree.Onion);
        }

        [Fact]
        public void ShouldBeAbleToSetRoll()
        {
            entree.Roll = true;
            Assert.True(entree.Roll);
            entree.Roll = false;
            Assert.False(entree.Roll);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(7.23, entree.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal(784.ToString(), (entree.Calories).ToString());
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSirloin, bool includeOnion,
                                                            bool includeRoll)
        {
            entree.Sirloin = includeSirloin;
            entree.Onion = includeOnion;
            entree.Roll = includeRoll;

            if (!includeSirloin) Assert.Contains("Hold sirloin", entree.SpecialInstructions);
            if (!includeOnion) Assert.Contains("Hold onions", entree.SpecialInstructions);
            if (!includeRoll) Assert.Contains("Hold roll", entree.SpecialInstructions);
            else Assert.Empty(entree.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Philly Poacher", entree.ToString());
        }
    }
}