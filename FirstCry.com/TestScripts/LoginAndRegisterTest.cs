using FirstCry.com.PageObjects;
using FirstCry.com.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.TestScripts
{
    internal class LoginAndRegisterTest : CoreCodes
    {
        [Test]
        [Category("Regression Test")]

        public void Registration()
        {

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

                string fileName = currDir + "/TestData/InputData.xlsx";
                var excelData = ExcelUtils.ReadExcelData(fileName, "FirstCry");
               

                foreach (var data in excelData)
                {
                   
                if(driver.Url!= "https://www.firstcry.com/")
                {
                    driver.Navigate().GoToUrl("https://www.firstcry.com/");
                }

                    HomePage homePage = new HomePage(driver);
               
                        var loginPage = homePage.LoginHomeClick();
                        Thread.Sleep(3000);
                    
                    var registerPage = loginPage.RegisterPageClick();
                    Thread.Sleep(3000);
                        registerPage.FullNameType(data.Name);
                        Thread.Sleep(3000);
                        registerPage.MobileNumberType(data.MobileNumber);
                        Thread.Sleep(3000);
                        registerPage.EmailType(data.Email);
                        Thread.Sleep(3000);
                        registerPage.PasswordType(data.Password);
                        Thread.Sleep(3000);
                    registerPage.ContinueBtnClk();
                try
                {
                    Assert.That(driver.Url == "https://www.firstcry.com/m/register?ref2=registerlink&URL=https://www.firstcry.com/");
                    test = extent.CreateTest("Registration Test");
                    test.Pass("Registration Completed");
                    Log.Information(" Registration Completed","Login page loaded");
                }
                catch(AssertionException)
                {
                    test = extent.CreateTest("Registration form test");
                    test.Fail("Registration form test fail");
                    Log.Information(" Registration form completed test failed");

                }
                }

           
        }
    }
}
