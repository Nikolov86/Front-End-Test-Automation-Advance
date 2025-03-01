using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testNakovCom
{
    public class Tests

    {
       private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
             driver = new ChromeDriver(); // open browser
        }

        [Test]
        public void Nakov_Test()
        {
            driver.Url = "https://nakov.com/"; // Navigate to the URL
            var windowTitle = driver.Title; // Take the title of webpage
            Assert.That(windowTitle.Contains("Svetlin Nakov – Official Web Site")); // Check the title text
            Console.WriteLine(windowTitle);// print title name in test logs

            var searchLink = driver.FindElement(By.ClassName("smoothScroll")); // take the element atribute 
            Assert.That(searchLink.Text, Does.Contain("SEARCH")); // Check the searchLink text
            Console.WriteLine(searchLink.Text);// print the text

            searchLink.Click();

            var message = driver.FindElement(By.Id("s")); // take the element by ID
            var placeHolderText = message.GetAttribute("placeholder"); // find placeholder
            Assert.That(placeHolderText, Is.EqualTo("Search this site")); //Check the text in placeholder
            Console.WriteLine(placeHolderText);//print this text

        }


        [TearDown]
        public void TearDown()
        {
            driver.Dispose(); // close browser
        }
    }
}