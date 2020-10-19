using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using PointOfSale.Payment;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.PaymentTests
{
    public class CashRegisterTests
    {
        CashRegister cash = new CashRegister();



        [Fact]
        public void ConfirmingCurrencyPaperPaidWorks()
        {
            RoundRegister.CashDrawer.ResetDrawer();

            cash.OnesPaid = 1;
            cash.TwosPaid = 1;
            cash.FivesPaid = 1;
            cash.TensPaid = 1;
            cash.TwentiesPaid = 1;
            cash.FiftiesPaid = 1;
            cash.HundredsPaid = 1;

            Assert.Equal(188, cash.CashPaid);
        }

        [Fact]
        public void ConfirmingCurrencyCoinsPaidWorks()
        {
            RoundRegister.CashDrawer.ResetDrawer();

            cash.PenniesPaid = 1;
            cash.NickelsPaid = 1;
            cash.DimesPaid = 1;
            cash.QuartersPaid = 1;
            cash.HalfDollarsPaid = 1;

            Assert.Equal(0.91, cash.CashPaid);
        }

        [Fact]
        public void ConfirmingRoundRegisterAddsCoins()
        {
            RoundRegister.CashDrawer.ResetDrawer();
            Assert.Equal(200, RoundRegister.CashDrawer.Pennies);
            Assert.Equal(80, RoundRegister.CashDrawer.Nickels);
            Assert.Equal(100, RoundRegister.CashDrawer.Dimes);
            Assert.Equal(80, RoundRegister.CashDrawer.Quarters);
            Assert.Equal(0, RoundRegister.CashDrawer.HalfDollars);


            cash.PenniesPaid = 1;
            cash.NickelsPaid = 1;
            cash.DimesPaid = 1;
            cash.QuartersPaid = 1;
            cash.HalfDollarsPaid = 1;
            cash.UpdateAddingCashRegister();

            Assert.Equal(201, RoundRegister.CashDrawer.Pennies);
            Assert.Equal(81, RoundRegister.CashDrawer.Nickels);
            Assert.Equal(101, RoundRegister.CashDrawer.Dimes);
            Assert.Equal(81, RoundRegister.CashDrawer.Quarters);
            Assert.Equal(1, RoundRegister.CashDrawer.HalfDollars);
        }

        [Fact]
        public void ConfirmingRoundRegisterAddsPaper()
        {
            RoundRegister.CashDrawer.ResetDrawer();


            Assert.Equal(20, RoundRegister.CashDrawer.Ones);
            Assert.Equal(0, RoundRegister.CashDrawer.Twos);
            Assert.Equal(4, RoundRegister.CashDrawer.Fives);
            Assert.Equal(10, RoundRegister.CashDrawer.Tens);
            Assert.Equal(5, RoundRegister.CashDrawer.Twenties);
            Assert.Equal(0, RoundRegister.CashDrawer.Fifties);
            Assert.Equal(0, RoundRegister.CashDrawer.Hundreds);
            cash.OnesPaid = 1;
            cash.TwosPaid = 1;
            cash.FivesPaid = 1;
            cash.TensPaid = 1;
            cash.TwentiesPaid = 1;
            cash.FiftiesPaid = 1;
            cash.HundredsPaid = 1;
            cash.UpdateAddingCashRegister();

            Assert.Equal(21, RoundRegister.CashDrawer.Ones);
            Assert.Equal(1, RoundRegister.CashDrawer.Twos);
            Assert.Equal(5, RoundRegister.CashDrawer.Fives);
            Assert.Equal(11, RoundRegister.CashDrawer.Tens);
            Assert.Equal(6, RoundRegister.CashDrawer.Twenties);
            Assert.Equal(1, RoundRegister.CashDrawer.Fifties);
            Assert.Equal(1, RoundRegister.CashDrawer.Hundreds);
        }

        [Fact]
        public void ConfirmingRoundRegisterRemovesCoins()
        {
            RoundRegister.CashDrawer.ResetDrawer();
            Assert.Equal(200, RoundRegister.CashDrawer.Pennies);
            Assert.Equal(80, RoundRegister.CashDrawer.Nickels);
            Assert.Equal(100, RoundRegister.CashDrawer.Dimes);
            Assert.Equal(80, RoundRegister.CashDrawer.Quarters);
            Assert.Equal(0, RoundRegister.CashDrawer.HalfDollars);


            cash.PenniesChange = 1;
            cash.NickelsChange = 1;
            cash.DimesChange = 1;
            cash.QuartersChange = 1;
            cash.HalfDollarsChange = 1;
            cash.UpdateRemovingCashRegister();

            Assert.Equal(199, RoundRegister.CashDrawer.Pennies);
            Assert.Equal(79, RoundRegister.CashDrawer.Nickels);
            Assert.Equal(99, RoundRegister.CashDrawer.Dimes);
            Assert.Equal(79, RoundRegister.CashDrawer.Quarters);
            Assert.Equal(-1, RoundRegister.CashDrawer.HalfDollars);
        }

        [Fact]
        public void ConfirmingRoundRegisterRemovesPaper()
        {
            RoundRegister.CashDrawer.ResetDrawer();


            Assert.Equal(20, RoundRegister.CashDrawer.Ones);
            Assert.Equal(0, RoundRegister.CashDrawer.Twos);
            Assert.Equal(4, RoundRegister.CashDrawer.Fives);
            Assert.Equal(10, RoundRegister.CashDrawer.Tens);
            Assert.Equal(5, RoundRegister.CashDrawer.Twenties);
            Assert.Equal(0, RoundRegister.CashDrawer.Fifties);
            Assert.Equal(0, RoundRegister.CashDrawer.Hundreds);
            cash.OnesChange = 1;
            cash.TwosChange = 1;
            cash.FivesChange = 1;
            cash.TensChange = 1;
            cash.TwentiesChange = 1;
            cash.FiftiesChange = 1;
            cash.HundredsChange = 1;
            cash.UpdateRemovingCashRegister();

            Assert.Equal(19, RoundRegister.CashDrawer.Ones);
            Assert.Equal(-1, RoundRegister.CashDrawer.Twos);
            Assert.Equal(3, RoundRegister.CashDrawer.Fives);
            Assert.Equal(9, RoundRegister.CashDrawer.Tens);
            Assert.Equal(4, RoundRegister.CashDrawer.Twenties);
            Assert.Equal(-1, RoundRegister.CashDrawer.Fifties);
            Assert.Equal(-1, RoundRegister.CashDrawer.Hundreds);
        }
        [Fact]
        public void ConfirmingCorrectChange()
        {
            RoundRegister.CashDrawer.ResetDrawer();
            cash.TwentiesPaid = 1;
            // $20 - $1.25 = $18.75

            cash.GetChangeOwed(1.25); //$1.25 order cost
            Assert.Equal(1, cash.TensChange);
            Assert.Equal(1, cash.FivesChange);
            Assert.Equal(1, cash.TwosChange);
            Assert.Equal(1, cash.OnesChange);
            Assert.Equal(1, cash.HalfDollarsChange);
            Assert.Equal(1, cash.QuartersChange);
            Assert.Equal(0.00, cash.CashOwed);

        }

        [Fact]
        public void ConfirmingPropertyChangedCashPaid()
        {
            RoundRegister.CashDrawer.ResetDrawer();
            
            Assert.PropertyChanged(cash, "CashPaid", () => cash.OnesPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.TwosPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.FivesPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.TensPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.TwentiesPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.FiftiesPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.HundredsPaid = 1);

            Assert.PropertyChanged(cash, "CashPaid", () => cash.PenniesPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.NickelsPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.DimesPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.QuartersPaid = 1);
            Assert.PropertyChanged(cash, "CashPaid", () => cash.HalfDollarsPaid = 1);

        }

        [Fact]
        public void ConfirmingPropertyChangedCashChange()
        {
            RoundRegister.CashDrawer.ResetDrawer();

            Assert.PropertyChanged(cash, "CashOwed", () => cash.OnesChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.TwosChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.FivesChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.TensChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.TwentiesChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.FiftiesChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.HundredsChange = 1);

            Assert.PropertyChanged(cash, "CashOwed", () => cash.PenniesChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.NickelsChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.DimesChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.QuartersChange = 1);
            Assert.PropertyChanged(cash, "CashOwed", () => cash.HalfDollarsChange = 1);

        }


    }
}
