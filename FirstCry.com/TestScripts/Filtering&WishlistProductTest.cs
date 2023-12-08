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
    internal class FilteringProductTest : CoreCodes
    {
        [Test]
        [Category("Regression Test")]
        public void FilterProduct()
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
                    var searchproductpage = homePage.SearchProduct(data.Search);
                    Thread.Sleep(3000);
                    searchproductpage.SortByLinkClick();
                    searchproductpage.BestSellerLinkClick();
                    Thread.Sleep(5000);
                    searchproductpage.BathTimeFilterLinkClick();
                    Thread.Sleep(5000);
                    var whishlistpage = searchproductpage.SelectFilterProductClick();
                    Thread.Sleep(5000);
                    whishlistpage.ShortListBtnLinkClick();
                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("https://www.firstcry.com/moms-home/moms-home-baby-super-soft-absorbent-muslin-6-layer-wash-towel-yellow/11767503/product-detail"));
                    test = extent.CreateTest("Filter the product and add to wishlist test");
                    test.Pass("Filter the product and add to wishlist test pass");
                    Log.Information("Filter the product and add to wishlist successfully");
                }
                catch (Exception)
                {
                    test = extent.CreateTest("Filter the product and add to wishlist test");
                    test.Fail("Filter the product and add to wishlist test fail");
                    Log.Information("Filter the product and add to wishlist failed");
                }
               
                   

                }
            
        }
    }
}
