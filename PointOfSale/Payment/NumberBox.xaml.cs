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
    /// Interaction logic for NumberBox.xaml
    /// </summary>
    public partial class NumberBox : UserControl
    {

        public static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(NumberBox));

        public int Value
        {
            get { return (int)GetValue(NumberBox.ValueProperty); }
            set { SetValue(NumberBox.ValueProperty, value); }
        }
        
        public NumberBox()
        {
            InitializeComponent();
            CheckIfZero();
        }

        void IncrementButtonClick(object sender, RoutedEventArgs e)
        {
            Value++;
            e.Handled = true;
            CheckIfZero();
        }

        void CheckIfZero()
        {
            if (Value == 0) Decrement.IsEnabled = false;
            else Decrement.IsEnabled = true;
        }

        void DecrementButtonClick(object sender, RoutedEventArgs e)
        {           
            Value--;
            e.Handled = true;
            CheckIfZero();
        }

    }
}
