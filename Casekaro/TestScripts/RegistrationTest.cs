using Casekaro.PageObjects;
using Casekaro.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Casekaro.TestScripts
{
    internal class RegistrationTest : CoreCodes
    {
        [Test]
        public void Registration()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

            string fileName = currDir + "/TestData/InputData.xlsx";
            var excelData = ExcelUtils.ReadRegisterExcelData(fileName, "Register");
            foreach (var data in excelData)
            {
                if (driver.Url != "https://casekaro.com/")
                {
                    driver.Navigate().GoToUrl("https://casekaro.com/");
                }
                HomePage homepage = new HomePage(driver);
                var loginpage = homepage.LoginIconClk();
                var registerpage=loginpage.CreateAccntClk();
                registerpage.RegisterDetails(data.FirstName, data.LastName, data.Email, data.Password);
                registerpage.CreateBtnClk();
                Thread.Sleep(5000);
                try
                {
                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("https://casekaro.com/"));
                    test = extent.CreateTest("Order place test");
                    test.Pass("Order Place test pass");
                    Log.Information("Place the order and Login page loaded");
                }
                catch (Exception)
                {
                    test = extent.CreateTest("Order place test");
                    test.Pass("Order Place test fail");
                    Log.Information("Login page not loaded");
                }
            }
        }
        [Test]
        [TestCase("fghfg","fdzdxcx","dfdggf","xvxfccv")]
        public void InvalidUser(string? firstname, string? lastname, string? email, string? password)
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            HomePage homepage = new HomePage(driver);
            var loginpage = homepage.LoginIconClk();
            var registerpage = loginpage.CreateAccntClk();
            registerpage.RegisterDetails(firstname,lastname,email,password);
            registerpage.CreateBtnClk();
            Thread.Sleep(5000);
        }
    }
}
