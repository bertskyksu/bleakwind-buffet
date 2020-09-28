/*
 * Author: Zachery Brunner
 * Class: BriarheartBurgerTests.cs
 * Purpose: Test the BriarheartBurger.cs class in the Data library
 * Modified by: Albert Winemiller
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using System;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class BriarheartBurgerTests
    {
        BriarheartBurger entree = new BriarheartBurger();

        [Fact]
        public void ShouldBeADrink()
        {
            Assert.IsAssignableFrom<Entree>(entree);
        }

        [Fact]
        public void CheckIsAssignableFromIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(entree);
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
            entree.Pickle= true;
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
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(6.32, entree.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal(743.ToString(), (entree.Calories).ToString());
            
        }

        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese)
        {
            entree.Bun = includeBun;
            entree.Ketchup = includeKetchup;
            entree.Mustard = includeMustard;
            entree.Pickle = includePickle;
            entree.Cheese = includeCheese;

            if (!includeBun) Assert.Contains("Hold bun", entree.SpecialInstructions);
            if (!includeKetchup) Assert.Contains("Hold ketchup", entree.SpecialInstructions);
            if (!includeMustard) Assert.Contains("Hold mustard", entree.SpecialInstructions);
            if (!includePickle) Assert.Contains("Hold pickle", entree.SpecialInstructions);
            if (!includeCheese) Assert.Contains("Hold cheese", entree.SpecialInstructions);

            else Assert.Empty(entree.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Briarheart Burger", entree.ToString());
        }
    }
}