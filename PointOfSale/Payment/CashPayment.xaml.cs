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
    /// Interaction logic for CashPayment.xaml
    /// </summary>
    public partial class CashPayment : UserControl
    {

        private DependencyObject parent = new DependencyObject();

        public PaymentOptions currentPayment;

        public Order currentOrder;


        //public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(CashPayment));

        public CashPayment(Order order)
        {
            InitializeComponent();
            currentOrder = order;
            //now the GUi +#- buttons are linked to the properties ones,twos,etc of CashRegister()
            DataContext = new CashRegister();
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
        

    }
}
