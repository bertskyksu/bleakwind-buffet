/*
* Author: Albert Winemiller
* Class name: CashPayment.xaml.cs
* Purpose: This class represents using cash to pay for the food order
*/
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
    /// Interaction logic for CashPayment.xaml 
    /// Model: RoundRegister.CashDrawer
    /// ModelView: CashRegister
    /// View: CashPayment (this)
    /// </summary>
    public partial class CashPayment : UserControl
    {
        /// <summary>
        /// keeps track of TreeHelper traversals
        /// </summary>
        private DependencyObject parent = new DependencyObject();

        /// <summary>
        /// keeps track of the PaymentOptions parent
        /// </summary>
        public PaymentOptions currentPayment;

        /// <summary>
        /// holds the current order 
        /// </summary>
        public Order currentOrder;

        
        /// <summary>
        /// a new instance of intermediary class from RoundRegister.CashDrawer 
        /// </summary>
        CashRegister Cash = new CashRegister();
       
        /// <summary>
        /// initializes the cashpayment and sets the datacontext of the intermediary class
        /// </summary>
        /// <param name="order"></param>
        public CashPayment(Order order)
        {
            InitializeComponent();
            currentOrder = order;
            //now the GUi +#- buttons are linked to the properties ones,twos,etc of CashRegister()
            //var Cash = new CashRegister();
            DataContext = Cash;
        }

        /// <summary>
        /// gets the PaymentOptions object parent so that methods from that 
        /// class can be called.
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
        /// button to get the change back after customer cash in inputted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GetChangeOwed(object sender, RoutedEventArgs e)
        {
            if (Cash.CashPaid >= currentOrder.newOrder.Total)
            {
                Cash.GetChangeOwed(currentOrder.newOrder.Total); //Get the change
                currentPayment.PrintReciept("Cash", Cash.initialCashOwed);
            }
            else
            {
                MessageBox.Show("Need More Cash!");
            }
        }





    }
}
