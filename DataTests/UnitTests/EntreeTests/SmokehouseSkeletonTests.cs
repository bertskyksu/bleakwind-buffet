/*
 * Author: Zachery Brunner
 * Class: SmokehouseSkeletonTests.cs
 * Purpose: Test the SmokehouseSkeleton.cs class in the Data library
 * Modified by: Albert Winemiller
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Interface;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    public class SmokehouseSkeletonTests
    {
        SmokehouseSkeleton entree = new SmokehouseSkeleton();

        [Fact]
        public void ProfileShouldNotifyOfFoodCustomizationChanges()
        {
            Assert.PropertyChanged(entree, "SausageLink", () => entree.SausageLink = false);
            Assert.PropertyChanged(entree, "Egg", () => entree.Egg = false);
            Assert.PropertyChanged(entree, "HashBrowns", () => entree.HashBrowns = false);
            Assert.PropertyChanged(entree, "Pancake", () => entree.Pancake = false);

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
        public void ShouldInlcudeSausageByDefault()
        {
            Assert.True(entree.SausageLink);
        }

        [Fact]
        public void ShouldInlcudeEggByDefault()
        {
            Assert.True(entree.Egg);
        }

        [Fact]
        public void ShouldInlcudeHashbrownsByDefault()
        {
            Assert.True(entree.HashBrowns);
        }

        [Fact]
        public void ShouldInlcudePancakeByDefault()
        {
            Assert.True(entree.Pancake);
        }

        [Fact]
        public void ShouldBeAbleToSetSausage()
        {
            entree.SausageLink = true;
            Assert.True(entree.SausageLink);
            entree.SausageLink = false;
            Assert.False(entree.SausageLink);
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
        public void ShouldBeAbleToSetHashbrowns()
        {
            entree.HashBrowns = true;
            Assert.True(entree.HashBrowns);
            entree.HashBrowns = false;
            Assert.False(entree.HashBrowns);
        }

        [Fact]
        public void ShouldBeAbleToSetPancake()
        {
            entree.Pancake = true;
            Assert.True(entree.Pancake);
            entree.Pancake = false;
            Assert.False(entree.Pancake);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(5.62, entree.Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal(602.ToString(), (entree.Calories).ToString());
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSausage, bool includeEgg,
                                                            bool includeHashbrowns, bool includePancake)
        {
            entree.SausageLink = includeSausage;
            entree.Egg = includeEgg;
            entree.HashBrowns = includeHashbrowns;
            entree.Pancake = includePancake;

            if (!includeSausage) Assert.Contains("Hold sausage", entree.SpecialInstructions);
            if (!includeEgg) Assert.Contains("Hold egg", entree.SpecialInstructions);
            if (!includeHashbrowns) Assert.Contains("Hold hash browns", entree.SpecialInstructions);
            if (!includePancake) Assert.Contains("Hold pancakes", entree.SpecialInstructions);
            else Assert.Empty(entree.SpecialInstructions);

        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Smokehouse Skeleton", entree.ToString());
        }
    }
}