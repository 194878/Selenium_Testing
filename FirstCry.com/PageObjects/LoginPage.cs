using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.PageObjects
{
    internal class LoginPage
    {

        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "lemail")]
        IWebElement? LoginEmailTextLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='B14_white comm-btn btn-login-continue btn-login-cont-otp']")]
        IWebElement? ContinueBtnLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Register Here']")]
        IWebElement? RegisterPageLink { get; set; }
        public RegisterPage RegisterPageClick()
        {
            RegisterPageLink.Click();
            return new RegisterPage(driver);
        }
        public void LoginEmailTextLinkType()
        {
            LoginEmailTextLink.SendKeys("shahanaspj@gmail.com");
        }
        public void ContinueBtnLinkBtn()
        {
            ContinueBtnLink.Click();
        }
    }
}
