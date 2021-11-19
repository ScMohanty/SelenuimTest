using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestingOrangeHrm
{

   
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Test1()
        {
           
            driver.Url = "https://orangehrm.com";
            IList<IWebElement> option = driver.FindElements(By.XPath("//li[@class='main-list']"));
            Assert.AreEqual(option.Count, 4);
            Actions act = new Actions(driver);
            driver.FindElement(By.XPath("//input[@class='home-tril-email']")).SendKeys("subashchandramohanty480@gmail.com") ;
            
          IWebElement email_reg=  driver.FindElement(By.XPath("//input[@class='home-tril-email-btn']"));
            act.MoveToElement(email_reg).Click(email_reg).Perform();

            driver.FindElement(By.XPath("//input[@name='subdomain']")).SendKeys("http//:google.com");
            driver.FindElement(By.Id("Form_submitForm_Name")).SendKeys("subashchandramohanty480@gmail.com");

            driver.FindElement(By.XPath("//input[@placeholder='Contact Number']")).SendKeys("8144479891");

            IWebElement dropDown_Country = driver.FindElement(By.XPath("//select[@name='Country']"));

            SelectElement country_Option = new SelectElement(dropDown_Country);
            country_Option.SelectByValue("India");

            IWebElement dropDown_State = driver.FindElement(By.XPath("//select[@name='State']"));
            Thread.Sleep(2000);
            SelectElement state_Option = new SelectElement(dropDown_State);
            state_Option.SelectByValue("Odisha");

            Thread.Sleep(7000);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }
    }
}