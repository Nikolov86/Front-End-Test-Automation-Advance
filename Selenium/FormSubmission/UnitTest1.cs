using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FormSubmission
{
    public class Tests
    {
        IWebDriver driver;
          [SetUp]
        public void Setup()
        {
            
            driver = new ChromeDriver(); // Use class-level driver
            driver.Navigate().GoToUrl("file:///C:/Users/Nikola/Downloads/03.SimpleForm/SimpleForm/Locators.html");
        }

        [Test]
        public void AssertTheTitle()
        {
            var formTitle = driver.FindElement(By.TagName("h2"));
            Assert.That(formTitle.Text, Is.EqualTo("Contact Form"));
        }
        [Test]
        public void SelectRadioButton()
        {
            var maleButton = driver.FindElement(By.XPath("//input[@value='m']"));
            maleButton.Click();
            Assert.That(maleButton.Selected);
        }
        [Test]
        public void EnterFirstName()
        {
            var firstName = driver.FindElement(By.XPath("//input[@id='fname']"));
            firstName.Clear();
            firstName.SendKeys("Butch");
            Assert.That(firstName.GetAttribute("value"), Is.EqualTo("Butch"));
        }
        [Test]
        public void EnterLastName()
        {
            var lastName = driver.FindElement(By.XPath("//input[@id='lname']"));
            lastName.Clear();
            lastName.SendKeys("Coolidge");
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Coolidge"));
        }
        [Test]
        public void AssertAddictionalInformation()
        {
            var addInfo = driver.FindElement(By.TagName("h3"));
            Assert.That(addInfo.Text, Is.EqualTo("Additional Information"));
        }
        [Test]
        public void EnterPhoneNumber()
        {
            var phoneNumber = driver.FindElement(By.CssSelector("div.additional-info p input"));
            phoneNumber.Clear();
            phoneNumber.SendKeys("0888999777");
            Assert.That(phoneNumber.GetAttribute("value"), Is.EqualTo("0888999777"));
        }
        [Test]
        public void SelectCheckBox()
        {
            var checkBox = driver.FindElement(By.XPath("//input[@type=\"checkbox\"]"));
            checkBox.Click();
            Assert.That(checkBox.Selected);
        }
        [Test]
        public void CLickSubmitButton()
        {
            var subButton = driver.FindElement(By.XPath("//input[@type=\"submit\"]"));
            subButton.Click();

            var formTitle = driver.FindElement(By.TagName("h1"));
            Assert.That(formTitle.Text, Is.EqualTo("Thank You!"));

        }
                [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();// Use Quit() instead of Dispose() for better cleanup
        }
    }
}