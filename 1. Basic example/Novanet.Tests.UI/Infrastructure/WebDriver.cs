using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Novanet.Test.UI.Infrastructure
{
    [Binding]
    public static class WebDriver
    {
        private static IWebDriver _instance;

        public static IWebDriver Current => _instance ?? (_instance = GetChromeDriver());

        private static IWebDriver GetChromeDriver()
        {
            Directory.SetCurrentDirectory(TestContext.CurrentContext.TestDirectory);

            var service = ChromeDriverService.CreateDefaultService(Path.GetFullPath(@"Infrastructure\ChromeDriver\"));

            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            return new ChromeDriver(service, options);
        }

        [AfterTestRun]
        public static void Kill()
        {
            if (_instance == null)
                return;

            try
            {
                _instance.Manage().Cookies.DeleteAllCookies();
            }
            finally
            {
                _instance.Quit();
            }
        }
    }
}
