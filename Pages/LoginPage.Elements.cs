using OpenQA.Selenium;

namespace Automation.Library.Pages
{
    public partial class LoginPage
    {
        private readonly ISearchContext _searchContext;

        public LoginPage(ISearchContext searchContext)
        {
            _searchContext = searchContext;
        }

        public IWebElement LogInButton => _searchContext.FindElement(By.Id("login-button"));

        public IWebElement UsernameInput => _searchContext.FindElement(By.Id("user-name"));

        public IWebElement PasswordInput => _searchContext.FindElement(By.Id("password"));

        // Other methods and properties related to the LoginPage
    }
}
