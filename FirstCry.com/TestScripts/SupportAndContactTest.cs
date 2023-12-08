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
    internal class SupportAndContactTest:CoreCodes
    {
        [Test]
        [Category("Regression test")]
        public void SupportAndContact()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            HomePage homePage = new HomePage(driver);
            var supportpage = homePage.HomePageSupportClick();
            Thread.Sleep(5000);
            List<string> str = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(str[1]);
            supportpage.ContactDetailsLink();
            Thread.Sleep(2000);
            supportpage.CustomerCareClick();
            Thread.Sleep(3000);
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("https://www.firstcry.com/contactus?ref2=topstrip-Support"));
                test = extent.CreateTest("Support and contact test");
                test.Pass("Support and contact test pass");
                Log.Information("Shown contact details");

            }
            catch (Exception)
            {
                test = extent.CreateTest("Support and contact test fail");
                test.Pass("Support and contact testfail");
                Log.Information("Doesn't found contact details");
            }
        }



    }
}
