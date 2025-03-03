using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task1
{
    public class Task1Test
       
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
            driver.FindElement(By.XPath("//span[text()='My Account']")).Click();

            driver.FindElement(By.XPath("//span[text()='Continue']")).Click();

            //fill reg form
            driver.FindElement(By.XPath("//input[@value='m']")).Click();

            driver.FindElement(By.XPath("//input[@name='firstname']")).SendKeys("FirstName");
            driver.FindElement(By.XPath("//input[@name='lastname']")).SendKeys("LastName");
            driver.FindElement(By.XPath("//input[@name='dob']")).SendKeys("10/10.2001" + Keys.Enter);

            //Generate a unique email address
            Random random = new Random();
            //Generate random number between 1000  and 9999

            int num = random.Next(1000, 9999);
            String email = "fiona.apple" + num.ToString() + "@gmail.com";

            driver.FindElement(By.XPath("//input[@name='email_address']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@name='company']")).SendKeys("Veliko Tarnovo");
            driver.FindElement(By.XPath("//input[@name='street_address']")).SendKeys("Test Address");
            driver.FindElement(By.XPath("//input[@name='suburb']")).SendKeys("Center");
            driver.FindElement(By.XPath("//input[@name='postcode']")).SendKeys("1000");
            driver.FindElement(By.XPath("//input[@name='city']")).SendKeys("Veliko Tarnovo");
            driver.FindElement(By.XPath("//input[@name='state']")).SendKeys("Veliko Tarnovo");

            //Select from dropdown
            IWebElement countryDropDown = driver.FindElement(By.Name("country"));
            SelectElement selectCountry = new SelectElement(countryDropDown);
            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");

            driver.FindElement(By.XPath("//input[@name='telephone']")).SendKeys("087123122");
            driver.FindElement(By.XPath("//input[@name='newsletter']")).Click();
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("Test123");
            driver.FindElement(By.XPath("//input[@name='confirmation']")).SendKeys("Test123");
            driver.FindElement(By.Id("tdb4")).Submit();

            //Assert account creation success
            Assert.IsTrue(driver.PageSource.Contains("Your Account Has Been Created!"), "Account creation failed.");

            driver.FindElement(By.XPath("//span[text()='Log Off']")).Click();
            driver.FindElement(By.XPath("//span[text()='Continue']")).Click();

            Console.WriteLine("User Account Created with email: " + email);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}