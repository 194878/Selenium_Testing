using Casekaro.PageObjects;
using Casekaro.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casekaro.TestScripts
{
    internal class E2ETest : CoreCodes
    {
        [Test]
        public void SearchandAddtoCart()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

            string fileName = currDir + "/TestData/InputData.xlsx";
            var excelData = ExcelUtils.ReadExcelData(fileName, "Casekaro");
            foreach (var data in excelData)
            {
                if (driver.Url != "https://casekaro.com/")
                {
                    driver.Navigate().GoToUrl("https://casekaro.com/");
                }
                HomePage homepage = new HomePage(driver);
                var searchproductpage = homepage.SearchPro(data.Search);
                var addtocartpage = searchproductpage.SelectProduct();
                var placeorderpage = addtocartpage.AddtoCartButtn();
                placeorderpage.PlaceOrderBtnClk();

            }
        }
    }
}

