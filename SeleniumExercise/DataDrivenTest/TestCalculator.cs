using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DataDrivenTest
{
    public class TestCalculater
    {
        private IWebDriver driver;
        IWebElement textBoxFirstNum;
        IWebElement textBoxSecondNum;
        IWebElement dropDownOperation;
        IWebElement calcBtn;
        IWebElement resetBtn;
        IWebElement divResult;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("file:///C:/Users/Nikola/Downloads/04.Resources/number-calculator/number-calculator.html");
            textBoxFirstNum = driver.FindElement(By.XPath("//input[@id='number1']"));
            dropDownOperation = driver.FindElement(By.XPath("//select[@id='operation']"));
            textBoxSecondNum = driver.FindElement(By.XPath("//input[@id='number2']"));
            calcBtn = driver.FindElement(By.XPath("//input[@id='calcButton']"));
            resetBtn = driver.FindElement(By.XPath("//input[@id='resetButton']"));
            divResult = driver.FindElement(By.XPath("//div[@id='result']"));
        }

        public void PerformCalculator(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            //Click the Reset btn
            resetBtn.Click();

            //Send values to the corresponding fields if! they are not empty!

            if(!string.IsNullOrEmpty(firstNumber))
            {
                textBoxFirstNum.SendKeys(firstNumber);
            }

            if(!string.IsNullOrEmpty(secondNumber))
            {
                textBoxSecondNum.SendKeys(secondNumber);
            }

            if(!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropDownOperation).SelectByText(operation);
            }
            //Click the calcBtn
            calcBtn.Click();

        }

        [Test]
        [TestCase("5", "+ (sum)", "5", "10")]
        [TestCase("5", "- (subtract)", "2", "3")]
        [TestCase("3", "* (multiply)", "2", "6")]
        [TestCase("10", "/ (divide)", "2", "5")]
        public void TestNumberCalculator(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            PerformCalculator(firstNumber, operation, secondNumber, expectedResult);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}