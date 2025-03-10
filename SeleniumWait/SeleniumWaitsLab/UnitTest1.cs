using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumWaitsLab
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        }

        [Test]
        public void AddBoxWithoutWaitsFails()
        {
            driver.FindElement(By.Id("adder")).Click();
            //IWebElement newBox = driver.FindElement(By.Id("box0"));

            Assert.Throws<NoSuchElementException>(() =>
            {
                var newBox = driver.FindElement(By.Id("box0"));
 
            });
            //Assert.That(newBox.Displayed, Is.True);
        }

        [Test]
        public void RevealInputWithoutWaitsFail()
        {
            driver.FindElement(By.Id("reveal")).Click();
            IWebElement newInput = driver.FindElement(By.Id("revealed"));
            Assert.Throws<ElementNotInteractableException>(() =>
            {
            newInput.SendKeys("Displayed");
                

            });
            //Assert.That(newInput.GetAttribute("value"), Is.EqualTo("Displayed"));
        }
        [Test]
        public void AddBoxWithThreadSleep()
        {
           
            driver.FindElement(By.Id("adder")).Click();
            Thread.Sleep(3000);
            IWebElement newBox = driver.FindElement(By.Id("box0"));
            Assert.That(newBox.Displayed, Is.True);
        }
        [Test]
        public void AddBoxWithImplicitWait()
        {

            driver.FindElement(By.Id("adder")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
             IWebElement newBox = driver.FindElement(By.Id("box0"));
            Assert.That(newBox.Displayed, Is.True);
        }
        [Test]
        public void RevealInputWithExplicitWaits()
        {
            driver.FindElement(By.Id("reveal")).Click();
            IWebElement newInput = driver.FindElement(By.Id("revealed"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            wait.Until(d => newInput.Displayed);

            newInput.SendKeys("Displayed");
            Assert.That(newInput.GetAttribute("value"), Is.EqualTo("Displayed"));
        }

        [Test]
        public void AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
        {
            driver.FindElement(By.Id("adder")).Click();

            //setUp fluent
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.PollingInterval = TimeSpan.FromMilliseconds(500); // check every 5 sec
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));// ignore trowing exeption

            IWebElement newBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("box0")));

            Assert.That(newBox.Displayed, Is.True);
        }
        [Test]
        public void RevealInputWithCustomFluentWait()
        {
            driver.FindElement(By.Id("reveal")).Click();
            IWebElement newInput = driver.FindElement(By.Id("revealed"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));// ignore trowing exeption
            wait.Until(d =>
            {
                newInput.SendKeys("Displayed");
                return true;
            });

            Assert.That(newInput.TagName, Is.EqualTo("input"));
            Assert.That(newInput.GetAttribute("value"), Is.EqualTo("Displayed"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}