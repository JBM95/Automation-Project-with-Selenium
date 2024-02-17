using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Library.Pages
{
  public partial class MainPage 
    {
        private readonly ISearchContext _searchContext;

        public MainPage(ISearchContext searchContext)
        {
            _searchContext = searchContext;
        }

        public IWebElement CartButton => _searchContext.FindElement(By.Id("shopping_cart_container"));




    }
}
