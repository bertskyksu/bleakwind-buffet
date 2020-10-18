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

        /*public void SwitchToPaymentScreen(UIElement screen)
        {
            /*parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent == null || parent is Order));
            if (parent is Order ancestor)
            {
                ancestor.SwitchToNewScreen(screen);
            }
            currentOrder.SwitchToNewScreen(screen);
        }*/


        public void ReturnToOrderButtonSelection(object sender, RoutedEventArgs e)
        {
            /*parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent == null || parent is Order));
            if (parent is Order ancestor)
            {
                ancestor.SwitchToMenu();
            }*/
            currentOrder.SwitchToMenu();
        }

        public void CashButtonSelection(object sender, RoutedEventArgs e)
        {
            CashPayment cashScreen = new CashPayment(currentOrder);

            //SwitchToPaymentScreen(cashScreen);
            //currentOrder.SwitchToNewScreen(cashScreen); //if we do this The parent will NOT be PaymentOptions in a TreeTraversal

            switchBorder.Child = cashScreen; //switch Border of PaymentOptions Screen
            cashScreen.GetPaymentOptionsObject();
        }

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
        /// need: Order #, date&time, all IOrderItems(price, special Instructions), subtotal, tax, total, payment method, changed owed
        /// </summary>
        public void PrintReciept(string paymentMethod, double changeOwed) //can I set a Button inside of Cash and credit Classes?
        {
            
            RecieptPrinter.PrintLine(currentOrder.newOrder.OrderNumber.ToString()); //order number
            RecieptPrinter.PrintLine(DateTime.Now.ToString()); //date&time

            foreach (IOrderItem food in currentOrder.newOrder.ListOrder)
            {
                RecieptPrinter.PrintLine(food.ToString() + "  $" + food.Price);
                foreach (string custom in food.SpecialInstructions)
                {
                    RecieptPrinter.PrintLine("-" + custom);
                }

            }
            RecieptPrinter.PrintLine(currentOrder.newOrder.Subtotal.ToString()); //subtotal
            RecieptPrinter.PrintLine(currentOrder.newOrder.Tax.ToString()); //subtotal
            RecieptPrinter.PrintLine(currentOrder.newOrder.Total.ToString()); //subtotal
            //make a parameter for which payment method was used?
            RecieptPrinter.PrintLine(paymentMethod); //payment method
            RecieptPrinter.PrintLine(changeOwed.ToString()); //0.00 for credit/debit
            RecieptPrinter.CutTape();
            //make sure 1 reciept line is no longer than 40 characters
        }
    }
}
