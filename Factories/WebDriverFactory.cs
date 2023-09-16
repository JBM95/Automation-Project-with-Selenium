using Automation.Library.Helpers;
using Automation.Library.Models.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation.Library.Factories
{
    public class WebDriverFactory
    {
        /// <summary>
        /// Gets an instance of WebDriver based on settings in the appsettings.json file.
        /// </summary>
        /// <returns>An instance of WebDriver for the specified browser.</returns>
        /// <exception cref="System.NotSupportedException">Exception if the browser sepcified in the settings is not supported.</exception>
        public IWebDriver GetWebDriver()
        {
            var webDriverSettings = SettingsReader.GetSettings<WebDriverSettings>("WebDriver");

            return webDriverSettings.Browser switch
            {
                "Chrome" => GetChromeWebDriver(webDriverSettings),
                _ => throw new System.NotSupportedException($"Specified webdriver browser setting is not supported in this project: {webDriverSettings.Browser}.")
            };
        }

        protected IWebDriver GetChromeWebDriver(WebDriverSettings webDriverSettings)
        {
            var chromeOptions = new ChromeOptions();

            if (webDriverSettings.Headless) chromeOptions.AddArgument("headless=new");
            if (webDriverSettings.Incognito) chromeOptions.AddArgument("incognito");

            chromeOptions.AddArgument("start-maximized");

            return new ChromeDriver(chromeOptions);
        }
    }
}