using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class ParentingPage
    {
        IWebDriver driver;
        public ParentingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[text()=' 6 Months to 2 Yrs ']")]
        public IWebElement AgeSelectLink { get; set; }

        public ChildDetailsPage AgeSelectClick()
        {
            
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => AgeSelectLink.Displayed);
            AgeSelectLink.Click();
            return new ChildDetailsPage(driver);
        }
   
    }
}
