/*
 * Author: Zachery Brunner
 * Class: ThugsTBoneTests.cs
 * Purpose: Test the ThugsTBone.cs class in the Data library
 * Modified by: Albert Winemiller
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class ThugsTBoneTests
    {
        ThugsTBone entree = new ThugsTBone();

        [Fact]
        public void ProfileShouldNotifyOfFoodCustomizationChanges()
        {
            //none
            
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
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(6.44, entree.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal(982.ToString(), (entree.Calories).ToString());
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            Assert.Empty(entree.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Thugs T-Bone", entree.ToString());
        }
    }
}