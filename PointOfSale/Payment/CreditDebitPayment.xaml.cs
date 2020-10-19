/*
* Author: Albert Winemiller
* Class name: CreditDebitPayment.xaml.cs
* Purpose: This class represents using a credit of debit card to pay for the order
*/
using RoundRegister;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointOfSale.Payment
{
    /// <summary>
    /// Interaction logic for CreditDebitPayment.xaml
    /// </summary>
    public partial class CreditDebitPayment : UserControl
    {

        /// <summary>
        /// used to find the parent of the class using logicalTreeHelper
        /// </summary>
        private DependencyObject parent = new DependencyObject();

        /// <summary>
        /// holds the parent instance of PaymentOptions
        /// </summary>
        public PaymentOptions currentPayment;

        /// <summary>
        /// holds the current Ordering object(the current Order)
        /// </summary>
        public Order currentOrder;
        
        /// <summary>
        /// The constructor initializing the card payment
        /// </summary>
        /// <param name="order">The instance of the current food order</param>
        public CreditDebitPayment(Order order)
        {
            InitializeComponent();
            //Order currentOrder = CreditDebitPayment.FindControl<Order>();
            currentOrder = order;
            
            
        }

        /// <summary>
        /// This is used to find the parent of this class, PaymentOptions, So that methods from that 
        /// class can be called from this class
        /// </summary>
        public void GetPaymentOptionsObject()
        {
            parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent == null || parent is PaymentOptions));
            if (parent is PaymentOptions ancestor)
            {
                currentPayment = ancestor;
            }
        }

        /// <summary>
        /// Runs the CardReader.RunCard method from RoundRegister.dll
        /// </summary>
        public void RunCard()
        {
             CardReaderResults(CardReader.RunCard(currentOrder.newOrder.Total));
        }

        /// <summary>
        /// interprets the results of the CardReader.RunCard method
        /// </summary>
        /// <param name="result">result of RunCard() method</param>
        public void CardReaderResults(CardTransactionResult result)
        {
            switch(result)
            {
                case CardTransactionResult.Approved:
                    MessageBox.Show("Approved");
                    currentPayment.PrintReciept("Credit/Debit", 0.00);
                    break;
                case CardTransactionResult.Declined:
                    MessageBox.Show("Declined");
                    break;
                case CardTransactionResult.ReadError:
                    MessageBox.Show("ReadError");
                    break;
                case CardTransactionResult.InsufficientFunds:
                    MessageBox.Show("Insufficient Funds");
                    //currentPayment.PrintReciept("Credit/Debit", 0.00);
                    break;
                case CardTransactionResult.IncorrectPin:
                    MessageBox.Show("Incorrect Pin");
                    break;
                default:
                    MessageBox.Show("something went wrong??");
                    break;
            }
        }
    }
}
