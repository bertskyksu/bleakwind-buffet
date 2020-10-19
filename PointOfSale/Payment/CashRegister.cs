/*
* Author: Albert Winemiller
* Class name: CashRegister.cs
* Purpose: This class represents a intermediary class to update teh RoundRegister.CashDrawer
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Text;

namespace PointOfSale.Payment
{
    public class CashRegister: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int penniesPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int PenniesPaid
        {
            get => penniesPaid;
            set
            {
                penniesPaid = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PenniesPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }
        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int nickelsPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int NickelsPaid
        {
            get => nickelsPaid;
            set
            {
                nickelsPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NickelsPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }
        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int dimesPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int DimesPaid
        {
            get => dimesPaid;
            set
            {
                dimesPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DimesPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }
        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int quartersPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int QuartersPaid
        {
            get => quartersPaid;
            set
            {
                quartersPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("QuartersPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }

        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int halfDollarsPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int HalfDollarsPaid
        {
            get => halfDollarsPaid;
            set
            {
                halfDollarsPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HalfDollarsPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }

        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int onesPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int OnesPaid
        {
            get => onesPaid;
            set {
                onesPaid = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OnesPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }
        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int twosPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int TwosPaid
        {
            get => twosPaid;
            set {
                twosPaid = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwosPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }

        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int fivesPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int FivesPaid
        {
            get => fivesPaid;
            set
            {
                fivesPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FivesPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }
        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int tensPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int TensPaid
        {
            get => tensPaid;
            set
            {
                tensPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TensPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }

        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int twentiesPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int TwentiesPaid
        {
            get => twentiesPaid;
            set
            {
                twentiesPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwentiesPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }

        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int fiftiesPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int FiftiesPaid
        {
            get => fiftiesPaid;
            set
            {
                fiftiesPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiftiesPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }
        /// <summary>
        /// Private backing field for the Currency
        /// </summary>
        private int hundredsPaid = 0;
        /// <summary>
        /// sets and gets the current number of the currency paid by the customer
        /// </summary>
        public int HundredsPaid
        {
            get => hundredsPaid;
            set
            {
                hundredsPaid = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HundredsPaid"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int penniesChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int PenniesChange
        {
            get => penniesChange;
            set
            {
                penniesChange = value;
                CashOwed -= penniesChange * 0.01;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PenniesChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int nickelsChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int NickelsChange
        {
            get => nickelsChange;
            set
            {
                nickelsChange = value;
                CashOwed -= nickelsChange * 0.05;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NickelsChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int dimesChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int DimesChange
        {
            get => dimesChange;
            set
            {
                dimesChange = value;
                CashOwed -= dimesChange * 0.10;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DimesChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int quartersChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int QuartersChange
        {
            get => quartersChange;
            set
            {
                quartersChange = value;
                CashOwed -= quartersChange * 0.25;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("QuartersChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int halfDollarsChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int HalfDollarsChange
        {
            get => halfDollarsChange;
            set
            {
                halfDollarsChange = value;
                CashOwed -= halfDollarsChange * 0.50;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HalfDollarsChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int onesChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int OnesChange
        {
            get => onesChange;
            set
            {
                onesChange = value;
                CashOwed -= onesChange * 1.00;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OnesChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }
        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int twosChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int TwosChange
        {
            get => twosChange;
            set
            {
                twosChange = value;
                CashOwed -= twosChange * 2.00;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwosChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }
        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int fivesChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int FivesChange
        {
            get => fivesChange;
            set
            {
                fivesChange = value;
                CashOwed -= fivesChange * 5.00;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FivesChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int tensChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int TensChange
        {
            get => tensChange;
            set
            {
                tensChange = value;
                CashOwed -= tensChange * 10.00;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TensChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int twentiesChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int TwentiesChange
        {
            get => twentiesChange;
            set
            {
                twentiesChange = value;
                CashOwed -= twentiesChange * 20.00;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwentiesChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int fiftiesChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int FiftiesChange
        {
            get => fiftiesChange;
            set
            {
                fiftiesChange = value;
                CashOwed -= fiftiesChange * 50.00;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiftiesChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// private backing field of the currency given back to customer
        /// </summary>
        private int hundredsChange = 0;
        /// <summary>
        /// gets and sets the amount of the currency to give back to the customer
        /// </summary>
        public int HundredsChange
        {
            get => hundredsChange;
            set
            {
                hundredsChange = value;
                CashOwed -= hundredsChange * 100.00;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HundredsChange"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }



        /// <summary>
        /// private backing variable of CashPaid
        /// </summary>
        private double cashPaid;
        /// <summary>
        /// returns the total amount of cash paid by the customer based on the bills given to the cashier
        /// </summary>
        public double CashPaid
        {
            get
            {
                cashPaid = (HundredsPaid * 100.00) + (FiftiesPaid * 50.00) + (TwentiesPaid * 20.00) + (TensPaid * 10.00) + (FivesPaid * 5.00) + (TwosPaid * 2.00) 
                    + (OnesPaid * 1.00) + (HalfDollarsPaid * 0.50) + (QuartersPaid * 0.25) + (DimesPaid * 0.10) + (NickelsPaid * 0.05) + (PenniesPaid * 0.01);
                return Math.Round(cashPaid, 2);
            }
            /*set
            {
                cashPaid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashPaid"));
            }*/
        } 


        /// <summary>
        /// private backing variable of amount of cash owed
        /// </summary>
        private double cashOwed;
        /// <summary>
        /// represents the remaining amount of cash that needs to be given to the customer after
        /// curreny of change has been used
        /// </summary>
        public double CashOwed
        {
            get => cashOwed;
            set
            {
                cashOwed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CashOwed"));
            }
        }

        /// <summary>
        /// update Adds all the cash from the customer to the cash register
        /// </summary>
        public void UpdateAddingCashRegister()
        {
            RoundRegister.CashDrawer.Pennies += PenniesPaid;
            RoundRegister.CashDrawer.Nickels += NickelsPaid;
            RoundRegister.CashDrawer.Dimes += DimesPaid;
            RoundRegister.CashDrawer.Quarters += QuartersPaid;
            RoundRegister.CashDrawer.HalfDollars += HalfDollarsPaid;
            RoundRegister.CashDrawer.Ones += OnesPaid;
            RoundRegister.CashDrawer.Twos += TwosPaid;
            RoundRegister.CashDrawer.Fives += FivesPaid;
            RoundRegister.CashDrawer.Tens += TensPaid;
            RoundRegister.CashDrawer.Twenties += TwentiesPaid;
            RoundRegister.CashDrawer.Fifties += FiftiesPaid;
            RoundRegister.CashDrawer.Hundreds += HundredsPaid;

        }

        /// <summary>
        /// Update removes the money from the register to be given as change
        /// </summary>
        public void UpdateRemovingCashRegister()
        {
            RoundRegister.CashDrawer.Pennies -= PenniesChange;
            RoundRegister.CashDrawer.Nickels -= NickelsChange;
            RoundRegister.CashDrawer.Dimes -= DimesChange;
            RoundRegister.CashDrawer.Quarters -= QuartersChange;
            RoundRegister.CashDrawer.HalfDollars -= HalfDollarsChange;
            RoundRegister.CashDrawer.Ones -= OnesChange;
            RoundRegister.CashDrawer.Twos -= TwosChange;
            RoundRegister.CashDrawer.Fives -= FivesChange;
            RoundRegister.CashDrawer.Tens -= TensChange;
            RoundRegister.CashDrawer.Twenties -= TwentiesChange;
            RoundRegister.CashDrawer.Fifties -= FiftiesChange;
            RoundRegister.CashDrawer.Hundreds -= HundredsChange;

        }

        /// <summary>
        /// holds the initial amount of change given to the customer for use in a method outside of class
        /// </summary>
        public double initialCashOwed;

        /// <summary>
        /// Gets the correct curreny from the change and updates it to the GUI
        /// </summary>
        /// <param name="amountOwed">The Total of the Order</param>
        public void GetChangeOwed(double amountOwed)
        {
            CashOwed = CashPaid - amountOwed;
            initialCashOwed = Math.Round(CashOwed, 2);
            UpdateAddingCashRegister();
            HundredsChange = (int)(CashOwed / 100.00);
            FiftiesChange = (int)(CashOwed / 50.00);
            TwentiesChange = (int)(CashOwed / 20.00);
            TensChange = (int)(CashOwed / 10.00);
            FivesChange = (int)(CashOwed / 5.00);
            TwosChange = (int)(CashOwed / 2.00);
            OnesChange = (int)(CashOwed / 1.00);

            HalfDollarsChange = (int)(CashOwed / 0.50);
            QuartersChange = (int)(CashOwed / 0.25);
            DimesChange = (int)(CashOwed / 0.10);
            NickelsChange = (int)(CashOwed / 0.05);
            PenniesChange = (int)(CashOwed / 0.01);

            UpdateRemovingCashRegister();
        }


    }
}
