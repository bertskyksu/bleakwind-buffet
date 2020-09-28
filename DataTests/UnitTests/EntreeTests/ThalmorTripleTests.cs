/*
 * Author: Zachery Brunner
 * Class: ThalmorTripleTests.cs
 * Purpose: Test the ThalmorTriple.cs class in the Data library
 * Modified by: Albert Winemiller
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class ThalmorTripleTests
    {
        ThalmorTriple entree = new ThalmorTriple();

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
        public void ShouldIncludeBunByDefault()
        {
            Assert.True(entree.Bun);
        }

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            Assert.True(entree.Ketchup);
        }

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            Assert.True(entree.Mustard);
        }

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            Assert.True(entree.Pickle);
        }

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            Assert.True(entree.Cheese);
        }

        [Fact]
        public void ShouldIncludeTomatoByDefault()
        {
            Assert.True(entree.Tomato);
        }

        [Fact]
        public void ShouldIncludeLettuceByDefault()
        {
            Assert.True(entree.Lettuce);
        }

        [Fact]
        public void ShouldIncludeMayoByDefault()
        {
            Assert.True(entree.Mayo);
        }

        [Fact]
        public void ShouldIncludeBaconByDefault()
        {
            Assert.True(entree.Bacon);
        }

        [Fact]
        public void ShouldIncludeEggByDefault()
        {
            Assert.True(entree.Egg);
        }

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            entree.Bun = true;
            Assert.True(entree.Bun);
            entree.Bun = false;
            Assert.False(entree.Bun);
        }

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            entree.Ketchup = true;
            Assert.True(entree.Ketchup);
            entree.Ketchup = false;
            Assert.False(entree.Ketchup);
        }

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            entree.Mustard = true;
            Assert.True(entree.Mustard);
            entree.Mustard = false;
            Assert.False(entree.Mustard);
        }

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            entree.Pickle = true;
            Assert.True(entree.Pickle);
            entree.Pickle = false;
            Assert.False(entree.Pickle);
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            entree.Cheese = true;
            Assert.True(entree.Cheese);
            entree.Cheese = false;
            Assert.False(entree.Cheese);
        }

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            entree.Tomato = true;
            Assert.True(entree.Tomato);
            entree.Tomato = false;
            Assert.False(entree.Tomato);
        }

        [Fact]
        public void ShouldBeAbleToSetLettuce()
        {
            entree.Lettuce = true;
            Assert.True(entree.Lettuce);
            entree.Lettuce = false;
            Assert.False(entree.Lettuce);
        }

        [Fact]
        public void ShouldBeAbleToSetMayo()
        {
            entree.Mayo = true;
            Assert.True(entree.Mayo);
            entree.Mayo = false;
            Assert.False(entree.Mayo);
        }

        [Fact]
        public void ShouldBeAbleToSetBacon()
        {
            entree.Bacon = true;
            Assert.True(entree.Bacon);
            entree.Bacon = false;
            Assert.False(entree.Bacon);
        }

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            entree.Egg = true;
            Assert.True(entree.Egg);
            entree.Egg = false;
            Assert.False(entree.Egg);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(8.32, entree.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal(943.ToString(), (entree.Calories).ToString());
        }

        [Theory]
        [InlineData(true, true, true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese, bool includeTomato,
                                                                    bool includeLettuce, bool includeMayo,
                                                                    bool includeBacon, bool includeEgg)
        {
            entree.Bun = includeBun;
            entree.Ketchup = includeKetchup;
            entree.Mustard = includeMustard;
            entree.Pickle = includePickle;
            entree.Cheese = includeCheese;
            entree.Tomato = includeTomato;
            entree.Lettuce = includeLettuce;
            entree.Mayo = includeMayo;
            entree.Bacon = includeBacon;
            entree.Egg = includeEgg;

            if (!includeBun) Assert.Contains("Hold bun", entree.SpecialInstructions);
            if (!includeKetchup) Assert.Contains("Hold ketchup", entree.SpecialInstructions);
            if (!includeMustard) Assert.Contains("Hold mustard", entree.SpecialInstructions);
            if (!includePickle) Assert.Contains("Hold pickle", entree.SpecialInstructions);
            if (!includeCheese) Assert.Contains("Hold cheese", entree.SpecialInstructions);
            if (!includeTomato) Assert.Contains("Hold tomato", entree.SpecialInstructions);
            if (!includeLettuce) Assert.Contains("Hold lettuce", entree.SpecialInstructions);
            if (!includeMayo) Assert.Contains("Hold mayo", entree.SpecialInstructions);
            if (!includeBacon) Assert.Contains("Hold bacon", entree.SpecialInstructions);
            if (!includeEgg) Assert.Contains("Hold egg", entree.SpecialInstructions);
            else Assert.Empty(entree.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Thalmor Triple", entree.ToString());
        }
    }
}