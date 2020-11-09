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
        public uint CaloriesMin { get; set; }

        /// <summary>
        /// The maximum calories specified by the web user
        /// </summary>
        [BindProperty]
        public uint CaloriesMax { get; set; }

        /// <summary>
        /// The minimum Price specified by the web user
        /// </summary>
        [BindProperty]
        public double PricesMin { get; set; }

        /// <summary>
        /// The maximum Price specified by the web user
        /// </summary>
        [BindProperty]
        public double PricesMax { get; set; }

        /// <summary>
        /// This code runs during initial start of the webpage. AnyTime the submit button is clicked this code will run again calling on
        /// the filter methods provided in the Menu.cs class to filter the food results in the html webpage
        /// </summary>
        /// <param name="CaloriesMin">Minimum calories specified by user</param>
        /// <param name="CaloriesMax">Maximum Calories specified by user</param>
        /// <param name="PricesMin">minimum Price specified by user</param>
        /// <param name="PricesMax">Maximum Price specified by user</param>
        public void OnGet(uint CaloriesMin, uint CaloriesMax, double PricesMin, double PricesMax)
        {
            SearchTerms = Request.Query["SearchTerms"];
            FoodTypes = Request.Query["FoodTypes"];
            this.CaloriesMin = CaloriesMin; //keeps value updated after a search on the html
            this.CaloriesMax = CaloriesMax; //keeps value updated after a search on the html
            this.PricesMin = PricesMin;
            this.PricesMax = PricesMax;
            //Categories
            DisplayedEntrees = Menu.FilterByType(Entrees, FoodTypes);
            DisplayedSides = Menu.FilterByType(Sides, FoodTypes);
            DisplayedDrinks = Menu.FilterByType(Drinks, FoodTypes);
            //Search terms
            DisplayedEntrees = Menu.Search(DisplayedEntrees, SearchTerms);
            DisplayedSides = Menu.Search(DisplayedSides, SearchTerms);
            DisplayedDrinks = Menu.Search(DisplayedDrinks, SearchTerms);
            //Calories:
            DisplayedEntrees = Menu.FilterByCalories(DisplayedEntrees, CaloriesMin, CaloriesMax);
            DisplayedSides = Menu.FilterByCalories(DisplayedSides, CaloriesMin, CaloriesMax);
            DisplayedDrinks = Menu.FilterByCalories(DisplayedDrinks, CaloriesMin, CaloriesMax);
            //Prices:
            DisplayedEntrees = Menu.FilterByPrices(DisplayedEntrees, PricesMin, PricesMax);
            DisplayedSides = Menu.FilterByPrices(DisplayedSides, PricesMin, PricesMax);
            DisplayedDrinks = Menu.FilterByPrices(DisplayedDrinks, PricesMin, PricesMax);
        }
    }
}
