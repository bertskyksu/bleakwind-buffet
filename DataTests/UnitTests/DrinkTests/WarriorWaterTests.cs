


using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Drinks;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    public class WarriorWaterTests
    {
        WarriorWater drink = new WarriorWater();
        [Fact]
        public void ShouldIncludeIceByDefault()
        {
            Assert.True(drink.Ice);
        }
        [Fact]
        public void ShouldNotIncludeLemonByDefault()
        {
            Assert.False(drink.Lemon);
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
        public void ShouldByAbleToSetLemon()
        {
            drink.Lemon = true;
            Assert.True(drink.Lemon);
            drink.Lemon = false;
            Assert.False(drink.Lemon);
        }

        [Theory]
        [InlineData(Size.Small, 0.00)]
        [InlineData(Size.Medium, 0.00)]
        [InlineData(Size.Large, 0.00)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            drink.Size = size;
            Assert.Equal(price, drink.Price);
        }

        [Theory]
        [InlineData(Size.Small, 0)]
        [InlineData(Size.Medium, 0)]
        [InlineData(Size.Large, 0)]
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
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeLemon)
        {
            drink.Ice = includeIce;
            drink.Lemon = includeLemon;
            if (!includeIce) Assert.Contains("Hold ice", drink.SpecialInstructions);
            else if (includeLemon) Assert.Contains("Add lemon", drink.SpecialInstructions);
            else Assert.Empty(drink.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, "Small Warrior Water")]
        [InlineData(Size.Medium, "Medium Warrior Water")]
        [InlineData(Size.Large, "Large Warrior Water")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            drink.Size = size;
            Assert.Equal(name, drink.ToString());
        }
    }
}
