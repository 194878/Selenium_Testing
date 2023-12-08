using FirstCry.com.PageObjects;
using FirstCry.com.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.TestScripts
{
    internal class LoginwithExistingAccntTest:CoreCodes
    {
        [Test]
        [Category("smoke test")]
        public void LoginExistingAccntTest()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

            HomePage homePage = new HomePage(driver);
            var loginpage = homePage.LoginHomeClick();
            loginpage.LoginEmailTextLinkType();
            Thread.Sleep(3000);
            loginpage.ContinueBtnLinkBtn();
            Thread.Sleep(3000);
       
            try 
            {
                
                Assert.That(driver.Url == "https://www.firstcry.com/m/login?URL=https://www.firstcry.com/");
                test = extent.CreateTest("Login Test");
               test.Pass("Login Completed");
               Log.Information("Login page loaded with OTP");
           } 
           catch (AssertionException)
            {
                test = extent.CreateTest("Login test");
                test.Fail("Login test fail");
                Log.Information(" Can't find OTP");
            }
        }
    }
}
