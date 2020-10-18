using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PointOfSale.Payment
{
    public class CashRegister: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int onesPaid = 0;
        public int OnesPaid
        {
            get => onesPaid;
            set {
                onesPaid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OnesPaid"));
            }
        }

        private int twosPaid = 0;
        public int TwosPaid
        {
            get => twosPaid;
            set {
                twosPaid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwosPaid"));
            }
        }

        private int threesPaid = 0;
        public int ThreesPaid
        {
            get => threesPaid;
            set
            {
                threesPaid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThreesPaid"));
            }
        }

        //Change
        private int onesChange = 0;
        public int OnesChange
        {
            get => onesChange;
            set
            {
                onesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OnesChange"));
            }
        }
        private int twosChange = 0;
        public int TwosChange
        {
            get => twosChange;
            set
            {
                twosChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwosChange"));
            }
        }
        private int threesChange = 0;
        public int ThreesChange
        {
            get => threesChange;
            set
            {
                threesChange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThreesChange"));
            }
        }

        void GetChange(double totalPaid)


    }
}
