using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casekaro.PageObjects
{
    internal class RegisterPage
    {
        IWebDriver driver;
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "FirstName")]
        IWebElement? FirstNameLink { get; set; }
        [FindsBy(How = How.Id, Using = "LastName")]
        IWebElement? LastNameLink { get; set; }
        [FindsBy(How = How.Id, Using = "Email")]
        IWebElement? EmailLink { get; set; }
        [FindsBy(How = How.Id, Using = "CreatePassword")]
        IWebElement? PasswordLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        IWebElement? CreateBtnLink { get; set; }

        public void RegisterDetails(string? firstname,string? lastname,string? email,string? password)
        {
            FirstNameLink.SendKeys(firstname);
            LastNameLink.SendKeys(lastname);
            EmailLink.SendKeys(email);
            PasswordLink.SendKeys(password);
        }
        public void CreateBtnClk()
        {
            CreateBtnLink.Click();
        }
    }
}
