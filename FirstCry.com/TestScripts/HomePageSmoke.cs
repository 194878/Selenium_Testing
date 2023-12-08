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
    internal class HomePageSmoke : CoreCodes
    {
        [Test]
        [Order(0)]
        [Category("Smoke test")]
        public void ShortlistProduct()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            driver.Navigate().GoToUrl("https://www.firstcry.com/");
            HomePage homePage = new HomePage(driver);
            homePage.ShortListClick();
            Thread.Sleep(3000);
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("https://www.firstcry.com/"));
                test = extent.CreateTest("Shortlist Click  test");
                test.Pass("Shortlist Click  test pass");
                Log.Information("Shortlist Click test success");
            }
            catch (Exception)
            {
                test = extent.CreateTest("Shortlist Click test");
                test.Fail("Shortlist Click test fail");
                Log.Information("Shortlist Click test failed");
            }
        }
        [Test]
        [Order(1)]
        [Category("Smoke test")]
        public void QuickReOrderTest()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            driver.Navigate().GoToUrl("https://www.firstcry.com/");
            Thread.Sleep(3000);
            HomePage homePage = new HomePage(driver);
            homePage.QuickReorderClick();
            Thread.Sleep(3000);
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("https://www.firstcry.com/"));
                test = extent.CreateTest("QuickReorder Click  test");
                test.Pass("QuickReorder Click  test pass");
                Log.Information("QuickReorder Click test success");
            }
            catch (Exception)
            {
                test = extent.CreateTest("QuickReorder Click test");
                test.Fail("QuickReorder Click test fail");
                Log.Information("QuickReorder Click test failed");
            }
        }
        [Test]
        [Order(2)]
        [Category("Smoke test")]
        public void TrackOrder()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            driver.Navigate().GoToUrl("https://www.firstcry.com/");
            HomePage homePage = new HomePage(driver);
            homePage.TrackorderClick();
            Thread.Sleep(3000);
        }
        [Test]
        [Order(2)]
        [Category("Smoke test")]
        public void DiaperingTest()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            driver.Navigate().GoToUrl("https://www.firstcry.com/");
            HomePage homePage = new HomePage(driver);
            homePage.DiaperingClick();
        }
    }
}
