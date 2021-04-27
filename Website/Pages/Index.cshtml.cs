/*
* Author: Albert Winemiller
* Class name: index.cshtml.cs
* Purpose: This class represents the index page
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Menu;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Interface;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Logger Message
        /// </summary>
        private readonly ILogger<IndexModel> _logger; 

        /// <summary>
        /// Keeps track of the Entrees to be displayed
        /// </summary>
        public IEnumerable<IOrderItem> DisplayedEntrees { get; protected set; }

        /// <summary>
        /// Gets the original list of Entrees from Menu class
        /// </summary>
        public IEnumerable<IOrderItem> Entrees { get { return Menu.Entrees(); } }
        // I might need to make a separate variable for the food items like the Movie.cs class from the exercise..but we will see

        /// <summary>
        /// Keeps track of the Sides to be displayed
        /// </summary>
        public IEnumerable<IOrderItem> DisplayedSides { get; protected set; }

        /// <summary>
        /// Gets the original list of Sides from Menu class
        /// </summary>
        public IEnumerable<IOrderItem> Sides { get { return Menu.Sides(); } }

        /// <summary>
        /// Keeps track of the Drinks to be displayed
        /// </summary>
        public IEnumerable<IOrderItem> DisplayedDrinks { get; protected set; }

        /// <summary>
        /// Gets the original list of Drinks from Menu class
        /// </summary>
        public IEnumerable<IOrderItem> Drinks { get { return Menu.DrinksNoFlavors(); } }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// so that we can access search terms outside of this class
        /// </summary>
        //[BindProperty] //couldnt get this to work
        public string SearchTerms { get; set; }

        /// <summary>
        /// The filtered Food type: Entree, Side, or 
        /// </summary>
        public string[] FoodTypes { get; set; }
        
        /// <summary>
        /// The minimum calories specified by the web user
        /// </summary>
        [BindProperty]
        public uint? CaloriesMin { get; set; }

        /// <summary>
        /// The maximum calories specified by the web user
        /// </summary>
        [BindProperty]
        public uint? CaloriesMax { get; set; }

        /// <summary>
        /// The minimum Price specified by the web user
        /// </summary>
        [BindProperty]
        public double? PricesMin { get; set; }

        /// <summary>
        /// The maximum Price specified by the web user
        /// </summary>
        [BindProperty]
        public double? PricesMax { get; set; }
        
        /// <summary>
        /// This code runs during initial start of the webpage. AnyTime the submit button is clicked this code will run again calling on
        /// the filter methods provided in the Menu.cs class to filter the food results in the html webpage
        /// </summary>
        /// <param name="CaloriesMin">Minimum calories specified by user</param>
        /// <param name="CaloriesMax">Maximum Calories specified by user</param>
        /// <param name="PricesMin">minimum Price specified by user</param>
        /// <param name="PricesMax">Maximum Price specified by user</param>
        public void OnGet(uint? CaloriesMin, uint? CaloriesMax, double? PricesMin, double? PricesMax)
        {
            SearchTerms = Request.Query["SearchTerms"];
            FoodTypes = Request.Query["FoodTypes"];
            this.CaloriesMin = CaloriesMin; //keeps value updated after a search on the html
            this.CaloriesMax = CaloriesMax; //keeps value updated after a search on the html
            this.PricesMin = PricesMin;
            this.PricesMax = PricesMax;
            //set the displayed results to All original Entrees, sides, drinks (avoids the first search needing to refer to Entrees.Where()
            DisplayedEntrees = Entrees;
            DisplayedSides = Sides;
            DisplayedDrinks = Drinks;


            if (FoodTypes.Count() != 0) //no checkboxes are not checked so ignore category search
            {
                List<IOrderItem> emptyList = new List<IOrderItem>();
                if (FoodTypes.Contains("Entrees"))
                {
                    DisplayedEntrees = DisplayedEntrees.Where(entree => entree is Entree);
                }
                else DisplayedEntrees = emptyList;
                if (FoodTypes.Contains("Sides"))
                {
                    DisplayedSides = DisplayedSides.Where(side => side is Side);
                }
                else DisplayedSides = emptyList;
                if (FoodTypes.Contains("Drinks"))
                {
                    DisplayedDrinks = DisplayedDrinks.Where(drink => drink is Drink);
                }
                else DisplayedDrinks = emptyList;

            }
            //Categories
                //DisplayedEntrees = Menu.FilterByType(Entrees, FoodTypes); //starts filtering from All entrees
                //DisplayedSides = Menu.FilterByType(Sides, FoodTypes);
                //DisplayedDrinks = Menu.FilterByType(Drinks, FoodTypes);

            //testing Linq method/ query sql
            if(SearchTerms != null) //search terms using LINQ Where() method
            {
                //note we should separate string into a string array and then run through this multiple times to accumulate a list 
                // so that we can use multiple search words without achieving minimal results
                string[] splitString = SearchTerms.Split(' ');
                IEnumerable<IOrderItem> listEntrees = Enumerable.Empty<IOrderItem>();
                IEnumerable<IOrderItem> listSides = Enumerable.Empty<IOrderItem>();
                IEnumerable<IOrderItem> listDrinks = Enumerable.Empty<IOrderItem>();
                IEnumerable<IOrderItem> list = Enumerable.Empty<IOrderItem>();
                foreach (string word in splitString)
                {
                    //listEntrees = DisplayedEntrees.Where(entree => entree.ToString() != null
                    //&& entree.ToString().Contains(word, StringComparison.InvariantCultureIgnoreCase));
                    list = DisplayedEntrees.Where(entree => entree.ToString() != null
                        && (entree.ToString().Contains(word, StringComparison.InvariantCultureIgnoreCase)
                        || entree.Description.Contains(word, StringComparison.InvariantCultureIgnoreCase)));
                    listEntrees = listEntrees.Concat(list);

                    list = DisplayedSides.Where(side => side.ToString() != null
                        && (side.ToString().Contains(word, StringComparison.InvariantCultureIgnoreCase)
                        || side.Description.Contains(word, StringComparison.InvariantCultureIgnoreCase)));
                    listSides = listSides.Concat(list);

                    list = DisplayedDrinks.Where(drink => drink.ToString() != null
                        && (drink.ToString().Contains(word, StringComparison.InvariantCultureIgnoreCase)
                        || drink.Description.Contains(word, StringComparison.InvariantCultureIgnoreCase)));
                    listDrinks = listDrinks.Concat(list);
                }
                DisplayedEntrees = listEntrees;
                DisplayedSides = listSides;
                DisplayedDrinks = listDrinks;


            }
            //Search terms filter... using functions() from menu.cs
                //DisplayedEntrees = Menu.Search(DisplayedEntrees, SearchTerms);
                //DisplayedSides = Menu.Search(DisplayedSides, SearchTerms);
                //DisplayedDrinks = Menu.Search(DisplayedDrinks, SearchTerms);
            
            if((CaloriesMin != 0 && CaloriesMin != null) || (CaloriesMax != 0 && CaloriesMax != null)) //Calories filter using LINQ Where() method
            {
                if (CaloriesMax == 0 || CaloriesMax == null)
                {
                    DisplayedEntrees = DisplayedEntrees.Where(entree => entree.Calories >= CaloriesMin);
                    DisplayedSides = DisplayedSides.Where(side => side.Calories >= CaloriesMin);
                    DisplayedDrinks = DisplayedDrinks.Where(drink => drink.Calories >= CaloriesMin);

                }
                else if (CaloriesMin == 0 || CaloriesMin == null)
                {
                    DisplayedEntrees = DisplayedEntrees.Where(entree => entree.Calories <= CaloriesMax);
                    DisplayedSides = DisplayedSides.Where(side => side.Calories <= CaloriesMax);
                    DisplayedDrinks = DisplayedDrinks.Where(drink => drink.Calories <= CaloriesMax);
                }
                else //both min and max are specified are available
                {
                    DisplayedEntrees = DisplayedEntrees.Where(entree => entree.Calories >= CaloriesMin && entree.Calories <= CaloriesMax);
                    DisplayedSides = DisplayedSides.Where(side => side.Calories >= CaloriesMin && side.Calories <= CaloriesMax);
                    DisplayedDrinks = DisplayedDrinks.Where(drink => drink.Calories >= CaloriesMin && drink.Calories <= CaloriesMax);
                }
            }
            //Calories filter: ...using functions() from menu.cs
                //DisplayedEntrees = Menu.FilterByCalories(DisplayedEntrees, CaloriesMin, CaloriesMax);
                //DisplayedSides = Menu.FilterByCalories(DisplayedSides, CaloriesMin, CaloriesMax);
                //DisplayedDrinks = Menu.FilterByCalories(DisplayedDrinks, CaloriesMin, CaloriesMax);
            if ((PricesMin != 0 && PricesMin != null) || (PricesMax != 0 && PricesMax != null)) //Prices filter using LINQ Where() method
            {
                if (PricesMax == 0 || PricesMax == null)
                {
                    DisplayedEntrees = DisplayedEntrees.Where(entree => entree.Price >= PricesMin);
                    DisplayedSides = DisplayedSides.Where(side => side.Price >= PricesMin);
                    DisplayedDrinks = DisplayedDrinks.Where(drink => drink.Price >= PricesMin);

                }
                else if (PricesMin == 0 || PricesMin == null)
                {
                    DisplayedEntrees = DisplayedEntrees.Where(entree => entree.Price <= PricesMax);
                    DisplayedSides = DisplayedSides.Where(side => side.Price <= PricesMax);
                    DisplayedDrinks = DisplayedDrinks.Where(drink => drink.Price <= PricesMax);
                }
                else //both min and max are specified are available
                {
                    DisplayedEntrees = DisplayedEntrees.Where(entree => entree.Price >= PricesMin && entree.Price <= PricesMax);
                    DisplayedSides = DisplayedSides.Where(side => side.Price >= PricesMin && side.Price <= PricesMax);
                    DisplayedDrinks = DisplayedDrinks.Where(drink => drink.Price >= PricesMin && drink.Price <= PricesMax);
                }
            }
            //Prices filter: ..using functions() from menu.cs
                //DisplayedEntrees = Menu.FilterByPrices(DisplayedEntrees, PricesMin, PricesMax);
                //DisplayedSides = Menu.FilterByPrices(DisplayedSides, PricesMin, PricesMax);
                //DisplayedDrinks = Menu.FilterByPrices(DisplayedDrinks, PricesMin, PricesMax);
        }
    }
}
