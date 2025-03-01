using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLab
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void demoTest()

        {   // open browser
            IWebDriver driver = new ChromeDriver();

            //Navigate to URl
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");

            // print page title
            Console.WriteLine("Main page title:"  + driver.Title);

            // locate element 

            var searchBox = driver.FindElement(By.Id("searchInput"));

            // input text
            searchBox.SendKeys("Quality assurance" + Keys.Enter);
            // print page tag

            Console.WriteLine("Title is " + driver.Title);

            //quit close browser
            driver.Quit();
        }
    }
}