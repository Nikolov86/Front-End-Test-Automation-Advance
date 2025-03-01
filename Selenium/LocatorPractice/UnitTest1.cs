using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LocatorPractice
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); // Use class-level driver
            driver.Navigate().GoToUrl("file:///C:/Users/Nikola/Downloads/03.SimpleForm/SimpleForm/Locators.html");
        }

        [Test]
        public void TestLocatorId()
        {
            var firstname = driver.FindElement(By.Id("fname"));
            firstname.Clear();
            firstname.SendKeys("FirstName");
        }
        [Test]
        public void TestLocatorName()
        {
            var checkBox = driver.FindElement(By.Name("newsletter"));
            checkBox.Click();
        }

        [Test]
        public void TestLocatorTagname()
        {
            Console.WriteLine(driver.FindElement(By.TagName("h2")).Text);
        }

        [Test]
        public void TestLocatorLinkText()
        {
            driver.FindElement(By.LinkText("Softuni Official Page")).Click();
        }
        [Test]
        public void TestPartialLinkText()
        {
            driver.FindElement(By.PartialLinkText("Official Page")).Click();
        }
        [Test]
        public void TestLocatorCssSelector()
        {
            var lastName = driver.FindElement(By.CssSelector("input#lname.information"));
            lastName.Clear();
            lastName.SendKeys("LastName");
            driver.FindElement(By.CssSelector("div.additional-info >p >input[type=\"text\"] "));
        }
        [Test]
        public void TestLocatorXpath()
        {
            driver.FindElement(By.XPath("//input[@type='submit']"));
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();// Use Quit() instead of Dispose() for better cleanup
        }

    }
}