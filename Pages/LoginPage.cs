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
