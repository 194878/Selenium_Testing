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
    internal class FirstCryEnd2EndTest:CoreCodes
    {
        [Test]
        [Category("Regression Test")]
        public void BuyProductTest()
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
                if (driver.Url != "https://www.firstcry.com/")
                {
                    driver.Navigate().GoToUrl("https://www.firstcry.com/");
                }

                        HomePage homePage = new HomePage(driver);
                        var searchproductpage = homePage.SearchProduct(data.Search);
                        Thread.Sleep(3000);
                        var addtocartpage = searchproductpage.ClickOnDress();
                        Thread.Sleep(3000);
                        addtocartpage.SizeSelect();
                        Thread.Sleep(3000);
                        addtocartpage.AddToCart();
                        Thread.Sleep(4000);
                        var gotocartpage = addtocartpage.GoToCartClick();
                        gotocartpage.LoginToPlaceOrderBtnClk();
                try
                {
                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("https://www.firstcry.com/m/login?URL=https://checkout.firstcry.com/pay"));
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
      
    }
}
