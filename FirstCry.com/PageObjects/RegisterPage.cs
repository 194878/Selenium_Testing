using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class RegisterPage
    {
        IWebDriver driver;
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.Id, Using = "usrname")]
        IWebElement? FullNameText { get; set; }
        [FindsBy(How = How.Id, Using = "usrmb")]
        IWebElement? MobileNoText { get; set; }

        [FindsBy(How = How.Id, Using = "usremail")]
        IWebElement? EmailText { get; set; }

        [FindsBy(How = How.Id, Using = "usrpass")]
        IWebElement? PasswordText { get; set; }

        [FindsBy(How = How.Id, Using = "continueid")]
        IWebElement? ContinueBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[text()='An account already exists with the same email id.']")]
        IWebElement? AccntAlreadyAlertLink { get; set; }

        public void FullNameType(string? name)
        {
            FullNameText.Clear();
            FullNameText.SendKeys(name);       
        }
        public void MobileNumberType(string? mobilenumber)
        {
            MobileNoText.Clear();
            MobileNoText.SendKeys(mobilenumber);
        }
        public void EmailType(string? email)
        {
            EmailText.Clear();
            EmailText.SendKeys(email);
        }
        public void PasswordType(string? password)
        {
            PasswordText.Clear();
            PasswordText.SendKeys(password);
        }
        public void ContinueBtnClk()
        {
            ContinueBtn.Click();
        }


    }
}
