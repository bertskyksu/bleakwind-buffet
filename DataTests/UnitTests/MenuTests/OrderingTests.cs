using System;
using Xunit;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Interface;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.DataTests.UnitTests.MenuTests
{
    public class OrderingTests
    {
        Ordering order = new Ordering();
        DoubleDraugr newEntree = new DoubleDraugr();
        MadOtarGrits newSide = new MadOtarGrits();
        MarkarthMilk newDrink = new MarkarthMilk();

        [Fact]
        public void OrderingSalesTaxRateCheck()
        {
            Assert.Equal(0.12, order.SalesTaxRate);
        }

        [Fact]
        public void OrderingOrderNumberIncrements()
        {
            //note that order number changes depending on how many tests are run
            int initialOrderNumber = order.OrderNumber;
            Assert.Equal(initialOrderNumber, order.OrderNumber);
            Ordering order2 = new Ordering();
            Assert.Equal(initialOrderNumber+1, order2.OrderNumber);
        }

        [Fact]
        public void OrderingShouldListenForPropertyChanges()
        {
            order.Add(newEntree);
            order.Add(newSide);
            order.Add(newDrink);
            Assert.PropertyChanged(order, "Subtotal", () => newSide.Size = Size.Large);
            Assert.PropertyChanged(order, "Subtotal", () => newSide.Size = Size.Medium);
            Assert.PropertyChanged(order, "Subtotal", () => newSide.Size = Size.Small);
            Assert.PropertyChanged(order, "Tax", () => newSide.Size = Size.Large);
            Assert.PropertyChanged(order, "Tax", () => newSide.Size = Size.Medium);
            Assert.PropertyChanged(order, "Tax", () => newSide.Size = Size.Small);
            Assert.PropertyChanged(order, "Total", () => newSide.Size = Size.Large);
            Assert.PropertyChanged(order, "Total", () => newSide.Size = Size.Medium);
            Assert.PropertyChanged(order, "Total", () => newSide.Size = Size.Small);
            Assert.PropertyChanged(order, "Calories", () => newSide.Size = Size.Large);
            Assert.PropertyChanged(order, "Calories", () => newSide.Size = Size.Medium);
            Assert.PropertyChanged(order, "Calories", () => newSide.Size = Size.Small);

            Assert.PropertyChanged(order, "Subtotal", () => newDrink.Size = Size.Large);
            Assert.PropertyChanged(order, "Subtotal", () => newDrink.Size = Size.Medium);
            Assert.PropertyChanged(order, "Subtotal", () => newDrink.Size = Size.Small);
            Assert.PropertyChanged(order, "Tax", () => newDrink.Size = Size.Large);
            Assert.PropertyChanged(order, "Tax", () => newDrink.Size = Size.Medium);
            Assert.PropertyChanged(order, "Tax", () => newDrink.Size = Size.Small);
            Assert.PropertyChanged(order, "Total", () => newDrink.Size = Size.Large);
            Assert.PropertyChanged(order, "Total", () => newDrink.Size = Size.Medium);
            Assert.PropertyChanged(order, "Total", () => newDrink.Size = Size.Small);
            Assert.PropertyChanged(order, "Calories", () => newDrink.Size = Size.Large);
            Assert.PropertyChanged(order, "Calories", () => newDrink.Size = Size.Medium);
            Assert.PropertyChanged(order, "Calories", () => newDrink.Size = Size.Small);
        }


        [Fact]
        public void OrderingShouldListenForChangesAddingRemovingClearing()
        {
            //order.Add(newEntree);
            //order.Add(newSide);
           // order.Add(newDrink);

            Assert.PropertyChanged(order, "Subtotal", () => order.Add(newEntree));
            Assert.PropertyChanged(order, "Subtotal", () => order.Add(newSide));
            Assert.PropertyChanged(order, "Subtotal", () => order.Add(newDrink));
            Assert.PropertyChanged(order, "Tax", () => order.Add(newEntree));
            Assert.PropertyChanged(order, "Tax", () => order.Add(newSide));
            Assert.PropertyChanged(order, "Tax", () => order.Add(newDrink));
            Assert.PropertyChanged(order, "Total", () => order.Add(newEntree));
            Assert.PropertyChanged(order, "Total", () => order.Add(newSide));
            Assert.PropertyChanged(order, "Total", () => order.Add(newDrink));
            Assert.PropertyChanged(order, "Calories", () => order.Add(newEntree));
            Assert.PropertyChanged(order, "Calories", () => order.Add(newSide));
            Assert.PropertyChanged(order, "Calories", () => order.Add(newDrink));

            Assert.PropertyChanged(order, "Subtotal", () => order.Remove(newEntree));
            Assert.PropertyChanged(order, "Subtotal", () => order.Remove(newSide));
            Assert.PropertyChanged(order, "Subtotal", () => order.Remove(newDrink));
            Assert.PropertyChanged(order, "Tax", () => order.Remove(newEntree));
            Assert.PropertyChanged(order, "Tax", () => order.Remove(newSide));
            Assert.PropertyChanged(order, "Tax", () => order.Remove(newDrink));
            Assert.PropertyChanged(order, "Total", () => order.Remove(newEntree));
            Assert.PropertyChanged(order, "Total", () => order.Remove(newSide));
            Assert.PropertyChanged(order, "Total", () => order.Remove(newDrink));
            Assert.PropertyChanged(order, "Calories", () => order.Remove(newEntree));
            Assert.PropertyChanged(order, "Calories", () => order.Remove(newSide));
            Assert.PropertyChanged(order, "Calories", () => order.Remove(newDrink));

            Assert.PropertyChanged(order, "Subtotal", () => order.Clear());

            Assert.PropertyChanged(order, "Tax", () => order.Clear());

            Assert.PropertyChanged(order, "Total", () => order.Clear());
   
            Assert.PropertyChanged(order, "Calories", () => order.Clear());

        }

        [Fact]
        public void OrderingShouldReturnCorrectCalories()
        {
            Assert.Equal(0.ToString(), (order.Calories).ToString());
            order.Add(newEntree);
            Assert.Equal(843.ToString(), (order.Calories).ToString());
            order.Add(newSide);
            Assert.Equal(948.ToString(), (order.Calories).ToString());
            order.Add(newDrink);
            Assert.Equal(1004.ToString(), (order.Calories).ToString());
            
            order.Remove(newDrink);
            Assert.Equal(948.ToString(), (order.Calories).ToString());
            order.Remove(newSide);
            Assert.Equal(843.ToString(), (order.Calories).ToString());
            order.Remove(newEntree);
            Assert.Equal(0.ToString(), (order.Calories).ToString());

            order.Add(newEntree);
            order.Add(newSide);
            order.Add(newDrink);
            order.Clear();
            Assert.Equal(0.ToString(), (order.Calories).ToString());
        }


        [Fact]
        public void ComboShouldReturnCorrectSubTotal()
        {
            Assert.Equal(0.00, order.Subtotal);
            order.Add(newEntree);
            Assert.Equal(7.32, order.Subtotal);
            order.Add(newSide);
            Assert.Equal(8.54, order.Subtotal);
            order.Add(newDrink);
            Assert.Equal(9.59, order.Subtotal);

            order.Remove(newDrink);
            Assert.Equal(8.54, order.Subtotal);
            order.Remove(newSide);
            Assert.Equal(7.32, order.Subtotal);
            order.Remove(newEntree);
            Assert.Equal(0.00, order.Subtotal);

            order.Add(newEntree);
            order.Add(newSide);
            order.Add(newDrink);
            order.Clear();
            Assert.Equal(0.00, order.Subtotal);
        }

        [Fact]
        public void ComboShouldReturnCorrectTotal()
        {
            Assert.Equal(0.00, order.Total);
            order.Add(newEntree);
            Assert.Equal(8.20, order.Total);
            order.Add(newSide);
            Assert.Equal(9.56, order.Total);
            order.Add(newDrink);
            Assert.Equal(10.74, order.Total);

            order.Remove(newDrink);
            Assert.Equal(9.56, order.Total);
            order.Remove(newSide);
            Assert.Equal(8.20, order.Total);
            order.Remove(newEntree);
            Assert.Equal(0.00, order.Total);

            order.Add(newEntree);
            order.Add(newSide);
            order.Add(newDrink);
            order.Clear();
            Assert.Equal(0.00, order.Total);
        }
    }
}
