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
using System.Collections.ObjectModel;
using static PointOfSale.MenuSelectionScreen;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for ItemCustomizationScreen.xaml
    /// </summary>
    public partial class ItemCustomizationScreen : UserControl
    {
        public ObservableCollection<BoolStringClass> TheListChecked { get; set; }
        public ObservableCollection<BoolStringClass> TheListUnChecked { get; set; }

        //MenuSelectionScreen menuLists = new MenuSelectionScreen();


        public ItemCustomizationScreen()
        {
            InitializeComponent();
            CreateCheckBoxList();
        }

        public class BoolStringClass
        {
            public string TheFoodList { get; set; }
            public int TheValue { get; set; }
        }

        //public void CreateCheckBoxList(ObservableCollection<BoolString> menuLists)
        public void CreateCheckBoxList()
        {
            /*
            var menuLists = new List<MenuSelectionScreen>();
            //bool test = MenuSelectionScreen.MyItem.briar;
            //Console.WriteLine("test" + menuLists.Count);
            ObservableCollection<BoolString> listoftoppings = MenuSelectionScreen.MyItem.Listmenu;

            TheListChecked = new ObservableCollection<BoolStringClass>();
            TheListUnChecked = new ObservableCollection<BoolStringClass>();
            
            foreach (BoolString a in listoftoppings) 
            {
                
                TheListChecked.Add(new BoolStringClass { TheFoodList = a.TheFoodList, TheValue = a.TheValue }); //pre-checked boxes
                //TheListUnChecked.Add(new BoolStringClass { TheFoodList = a.TheFoodList, TheValue = a.TheValue }); //un-checked boxes
            }
            //we could try a for each loop here for a list of toppings
            //from menuSelectionScreen
            //TheListChecked.Add(new BoolStringClass { TheFoodList = "bun", TheValue = 1 });
            //TheListUnChecked.Add(new BoolStringClass { TheFoodList = "tomato", TheValue = 1 });
            //TheListUnChecked.Add(new BoolStringClass { TheFoodList = "mustard", TheValue = 1 });
            //TheListChecked.Add(new BoolStringClass { TheFoodList = "someting", TheValue = 0 });

            

            this.DataContext = this;
            */
        }

        
        void NewFoodItem(object sender, RoutedEventArgs e) //delete??
        {
            //string food = new MenuSelectionScreen();
        }

        void ConfirmCustomization(object sender, RoutedEventArgs e) //delete?
        {
            //string food = item
        }
        
        /// <summary>
        /// get the values of the checkedbox list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkZone = (CheckBox)sender;
            ZoneText.Text = "Selected Zone Name= " + chkZone.Content.ToString();
            ZoneValue.Text = "Selected Zone Value= " + chkZone.Tag.ToString();
        }

    }
}
