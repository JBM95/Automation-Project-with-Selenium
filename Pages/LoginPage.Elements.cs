using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Library.Pages
{
    public partial class LoginPage
    {
        public ISearchContext SearchContext;

        public IWebElement LogInButton => SearchContext.FindElement(By.Id("login-button"));

        public IWebElement UsernameInput => SearchContext.FindElement(By.Id("user-name"));

        public IWebElement PasswordInput => SearchContext.FindElement(By.Id("password"));



    }
}
