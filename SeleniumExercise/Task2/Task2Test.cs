using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace Task2
{
    public class Task2Test
    {

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [Test]
        public void Test1()
        {
            IWebElement productTable = driver.FindElement(By.XPath("//div[@class='contentText']//table"));
            ReadOnlyCollection<IWebElement> tableRows = productTable.FindElements(By.XPath("//tbody//tr"));
            //path to save CSV file
            string path = System.IO.Directory.GetCurrentDirectory() + "/productinformation.csv";

            //check file existing
            if (File.Exists(path)) 
            {
                File.Delete(path);
            }

            foreach (IWebElement trows in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableCols = trows.FindElements(By.XPath("td"));

                foreach (IWebElement tcol in tableCols) 
                {
                    //Extract product name and cost
                    String data = tcol.Text;
                    String[] productInfo = data.Split("\n");
                    String printProductInfo = productInfo[0].Trim() + ", " + productInfo[1].Trim() + "\n";
                    //Write product info extracted file
                    File.AppendAllText(path, printProductInfo);

                    //Asseert

                    Assert.That(File.Exists(path), Is.True, "CSV file was not created");
                    Assert.That(new FileInfo(path).Length, Is.GreaterThan(0), "CSV file is empty");
                }
            }
        }

        [TearDown]
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}