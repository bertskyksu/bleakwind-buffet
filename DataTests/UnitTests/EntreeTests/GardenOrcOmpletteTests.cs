/*
 * Author: Zachery Brunner
 * Class: GardenOrcOmeletteTests.cs
 * Purpose: Test the GardenOrcOmelette.cs class in the Data library
 * Modified by: Albert Winemiller
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class GardenOrcOmeletteTests
    {
        GardenOrcOmelette entree = new GardenOrcOmelette();
        [Fact]
        public void ShouldInlcudeBroccoliByDefault()
        {
            Assert.True(entree.Broccoli);
        }

        [Fact]
        public void ShouldInlcudeMushroomsByDefault()
        {
            Assert.True(entree.Mushrooms);
        }

        [Fact]
        public void ShouldInlcudeTomatoByDefault()
        {
            Assert.True(entree.Tomato);
        }

        [Fact]
        public void ShouldInlcudeCheddarByDefault()
        {
            Assert.True(entree.Cheddar);
        }

        [Fact]
        public void ShouldBeAbleToSetBroccoli()
        {
            entree.Broccoli = true;
            Assert.True(entree.Broccoli);
            entree.Broccoli = false;
            Assert.False(entree.Broccoli);
        }

        [Fact]
        public void ShouldBeAbleToSetMushrooms()
        {
            entree.Mushrooms = true;
            Assert.True(entree.Mushrooms);
            entree.Mushrooms = false;
            Assert.False(entree.Mushrooms);
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
        public void ShouldBeAbleToSetCheddar()
        {
            entree.Cheddar = true;
            Assert.True(entree.Cheddar);
            entree.Cheddar = false;
            Assert.False(entree.Cheddar);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(4.57, entree.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal(404.ToString(), (entree.Calories).ToString());
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBroccoli, bool includeMushrooms,
                                                            bool includeTomato, bool includeCheddar)
        {
            entree.Broccoli = includeBroccoli;
            entree.Mushrooms = includeMushrooms;
            entree.Tomato = includeTomato;
            entree.Cheddar = includeCheddar;

            if (!includeBroccoli) Assert.Contains("Hold broccoli", entree.SpecialInstructions);
            if (!includeMushrooms) Assert.Contains("Hold mushrooms", entree.SpecialInstructions);
            if (!includeTomato) Assert.Contains("Hold tomato", entree.SpecialInstructions);
            if (!includeCheddar) Assert.Contains("Hold cheddar", entree.SpecialInstructions);
            else Assert.Empty(entree.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Garden Orc Omelette", entree.ToString());
        }
    }
}