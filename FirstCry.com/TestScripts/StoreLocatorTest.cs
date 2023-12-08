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
    internal class StoreLocatorTest:CoreCodes
    {
        [Test]
        [Category("Regression Test")]
        public void StoreLocator()
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
                HomePage homePage = new HomePage(driver);
                homePage.StoresLinkClick();
                Thread.Sleep(3000);
                var storelocatorpage = homePage.FindStoreLinkClick();
                Thread.Sleep(3000);
                storelocatorpage.StoreTypeLinkClick();
                Thread.Sleep(3000);
                storelocatorpage.StoreTypeLinkSelectClk();
                Thread.Sleep(3000);
                storelocatorpage.SelectStateLinkClick();
                Thread.Sleep(3000);
                storelocatorpage.SelectStatePickLinkClick();
                Thread.Sleep(3000);
                storelocatorpage.SelectCityClick();
                Thread.Sleep(3000);
                storelocatorpage.SelectCityPick();
                Thread.Sleep(3000);
                storelocatorpage.SearchBtnClk();
                Thread.Sleep(3000);
                try 
                {
                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("https://www.firstcry.com/store-locator?ref2=topstrip"));
                    test = extent.CreateTest("Store Locator test");
                    test.Pass("Store Locator test pass");
                    Log.Information("Locate the Store Successfully");
                }
                catch (Exception)
                {
                    test = extent.CreateTest("Store Locator test");
                    test.Pass("Store Locator test fail");
                    Log.Information(" Couldn't Locate the Store");
                }
            }

        }
    }
}
