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
    internal class FirstCryParetingTest:CoreCodes
    {
        [Test]
        [Category("Regression Test")]
        public void ParentingTest()
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
                   var parentingpage = homePage.ParentingHomePageClick();
                   List<string>str= driver.WindowHandles.ToList();
                   driver.SwitchTo().Window(str[1]);
                var childdetailspage = parentingpage.AgeSelectClick();
                 Thread.Sleep(5000);
                 childdetailspage.ChildNameType(data.ChildName);
                 Thread.Sleep(1000);
                 childdetailspage.ChildGenderType();
                 Thread.Sleep(1000);
                 childdetailspage.SubmitBtnClick();
                 Thread.Sleep(5000);
                try
                {
                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("https://parenting.firstcry.com/?ref2=utm_source=firstcry_header&utm_medium=firstcrysite&utm_campaign=promote_parenting"));
                    test = extent.CreateTest("Firstcry parenting  test");
                    test.Pass("Parenting page  test pass");
                    Log.Information("Parenting page test success");
                }
                catch (Exception)
                {
                    test = extent.CreateTest("Firstcry parenting test");
                    test.Fail("Parenting page test fail");
                    Log.Information("Parenting page test failed");
                }

            }

            
        }
    }
    }

