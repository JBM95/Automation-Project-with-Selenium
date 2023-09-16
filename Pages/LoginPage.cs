using OpenQA.Selenium.DevTools.V114.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Library.Pages
{
    public partial class LoginPage
    {
        public void Login(string username, string password)
        {
            var loginRetries = 0;
            const int maxLoginRetries = 5;

            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LogInButton.Click();
        }

    }
}
