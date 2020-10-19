/*
* Author: Albert Winemiller
* Class name: PaymentOptions.xaml.cs
* Purpose: This class represents the payment options available for the customer
*/
using BleakwindBuffet.Data.Interface;
using RoundRegister;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PaymentOptions.xaml
    /// </summary>
    public partial class PaymentOptions : UserControl
    {
        //private UIElement OrderDependency;
        private DependencyObject parent = new DependencyObject();

        public Order currentOrder;
        public PaymentOptions()
        {
            InitializeComponent();

            //GetOrderObject();
        }

        /// <summary>
        /// Gets the order object to call on methods and get the current ordering instance
        /// </summary>
        public void GetOrderObject()
        {
            parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent == null || parent is Order));
            if (parent is Order ancestor)
            {
                currentOrder = ancestor;
            }
        }

        /// <summary>
        /// returns the user back to order customization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReturnToOrderButtonSelection(object sender, RoutedEventArgs e)
        {

            currentOrder.SwitchToMenu();
        }

        /// <summary>
        /// The button selection for making a cash payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CashButtonSelection(object sender, RoutedEventArgs e)
        {
            CashPayment cashScreen = new CashPayment(currentOrder);

            //SwitchToPaymentScreen(cashScreen);
            //currentOrder.SwitchToNewScreen(cashScreen); //if we do this The parent will NOT be PaymentOptions in a TreeTraversal

            switchBorder.Child = cashScreen; //switch Border of PaymentOptions Screen
            cashScreen.GetPaymentOptionsObject();
        }

        /// <summary>
        /// Takes user to the credit/debit card payment screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CreditDebitButtonSelection(object sender, RoutedEventArgs e)
        {
            CreditDebitPayment creditScreen = new CreditDebitPayment(currentOrder);

            //SwitchToPaymentScreen(creditScreen);
            //currentOrder.SwitchToNewScreen(creditScreen); //if we do this The parent will NOT be PaymentOptions in a TreeTraversal

            switchBorder.Child = creditScreen; //switch Border of PaymentOptions Screen. Important for traversal!
            creditScreen.GetPaymentOptionsObject();
            creditScreen.RunCard();
        }

        /// <summary>
        /// Prints the Reciept of the current Order in a text file 
        /// </summary>
        /// <param name="paymentMethod">the type of customer payment</param>
        /// <param name="changeOwed">the changed owed to the customer</param>
        public void PrintReciept(string paymentMethod, double changeOwed) //can I set a Button inside of Cash and credit Classes?
        {
            
            RecieptPrinter.PrintLine("Order # "+ currentOrder.newOrder.OrderNumber.ToString()); //order number
            RecieptPrinter.PrintLine(DateTime.Now.ToString()); //date&time

            foreach (IOrderItem food in currentOrder.newOrder.ListOrder)
            {
                RecieptPrinter.PrintLine(food.ToString() + "  $" + food.Price);
                foreach (string custom in food.SpecialInstructions)
                {
                    RecieptPrinter.PrintLine("-" + custom);
                }

            }
            RecieptPrinter.PrintLine("SubTotal: $" + currentOrder.newOrder.Subtotal.ToString()); //subtotal
            RecieptPrinter.PrintLine("Tax:      $"+ currentOrder.newOrder.Tax.ToString()); //Tax
            RecieptPrinter.PrintLine("Total:    $" + currentOrder.newOrder.Total.ToString()); //Total
            //make a parameter for which payment method was used?
            RecieptPrinter.PrintLine("Payment Type: " + paymentMethod); //payment method
            RecieptPrinter.PrintLine("Changed: $" + changeOwed.ToString()); //0.00 for credit/debit
            RecieptPrinter.CutTape();
            //make sure 1 reciept line is no longer than 40 characters
            
        }
    }
}
