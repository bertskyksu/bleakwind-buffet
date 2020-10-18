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

        private DependencyObject parent = new DependencyObject();

        public PaymentOptions currentPayment;

        public Order currentOrder;
        public CreditDebitPayment(Order order)
        {
            InitializeComponent();
            //Order currentOrder = CreditDebitPayment.FindControl<Order>();
            currentOrder = order;
            
            
        }

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

        public void RunCard()
        {
             CardReaderResults(CardReader.RunCard(currentOrder.newOrder.Total));
        }

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
                    currentPayment.PrintReciept("Credit/Debit", 0.00);
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
