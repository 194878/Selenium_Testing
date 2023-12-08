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
    internal class FirstCryIconTest:CoreCodes
    {
        [Test]
        [Category("smoke test")]
        public void IconTest()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            HomePage homePage = new HomePage(driver);
            homePage.HomeIconLinkClick();
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("https://www.firstcry.com/"));
                test = extent.CreateTest("Firstcry Icon test");
                test.Pass("Firstcry Icon test pass");
                Log.Information("Clicking icon refresh the page");

            }
            catch (Exception)
            {
                test = extent.CreateTest("Firstcry Icon test fail");
                test.Pass("Firstcry Icon test fail");
                Log.Information("Icon not Refresh");
            }
        }
    }
}
