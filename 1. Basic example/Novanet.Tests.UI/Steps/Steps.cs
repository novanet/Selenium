using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using Novanet.Test.UI.Infrastructure;
using TechTalk.SpecFlow;

namespace Novanet.Tests.UI.Steps
{
    [Binding]
    public class Steps
    {
        [Given(@"I navigate to ""(.*)""")]
        public void NavigateTo(string page)
        {
            WebDriver.Current.Navigate().GoToUrl(page);
        }

        [When(@"I click the link ""(.*)""")]
        public void ClickTheLink(string linkText)
        {
            WebDriver.Current
                    .FindElements(By.TagName("a"))
                    .First(element => element.Text == linkText)
                    .Click();
        }

        [Then(@"the text ""(.*)"" is visible")]
        public void TheTextIsVisible(string text)
        {
            Assert.That(WebDriver.Current.PageSource.Contains(text), Is.True);
        }
    }
}
