using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using SSDTestAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDTestAutomation.Pages
{
    public class EnvironmentalAssessment
    {
        private readonly IWebDriver _driver;
        HelperMethods helper;
        public EnvironmentalAssessment(IWebDriver driver) 
        { 
            _driver = driver;
            helper= new HelperMethods(driver);
        }


        IWebElement txtUserName => _driver.FindElement(By.Id("username"));
        IWebElement txtPassword => _driver.FindElement(By.Id("password"));
        IWebElement btnLogin => _driver.FindElement(By.Id("login"));
        public IWebElement mainMenuElement => _driver.FindElement(By.XPath("//a[text()='Modules']"));
        public IWebElement subMenuElement => _driver.FindElement(By.XPath("//ul[@class='she-nav-modules']//li[@data-areaname='Environment']/a[contains(text(),'Environment')]"));
        public IWebElement btnNewRecord => _driver.FindElement(By.XPath("//a[text()=' New Record ']"));
        public IWebElement txtEnvironment => _driver.FindElement(By.XPath("//legend[contains(text(),'Environmental Details')]"));
        public IWebElement txtDescription => _driver.FindElement(By.XPath("//*[@id='SheEnvironmental_Description']"));
        public IWebElement txtDate => _driver.FindElement(By.XPath("//*[@id='SheEnvironmental_AssessmentDate']"));
        public IWebElement btnSaveAndClose => _driver.FindElement(By.XPath("//button[@value='Close']"));
        public IWebElement btnConfirm => _driver.FindElement(By.XPath($"//button[contains(text(),'Confirm')]"));
        public IWebElement dpdwnUser => _driver.FindElement(By.XPath("//*[@class='she-nav-menu header-user-info she-user-info']"));
        public IWebElement btnLogout => _driver.FindElement(By.XPath("//a[text()='Log Out']"));
        public List<string> descriptions = new List<string>();
        
        public void Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
            helper.WaitForTime(1);
            btnLogin.Submit();
            helper.WaitForTime(2);
        }
       
        public void NavigateToApplication()
        {
            _driver.Navigate().GoToUrl("https://stirling.she-development.net/automation");
            _driver.Manage().Window.Maximize();
        }

        public void NavigateToMainMenu()
        {
            helper.WaitForElementLoad(mainMenuElement);
            helper.ClickElement(mainMenuElement);
            helper.WaitForElementLoad(subMenuElement);
            helper.ClickElement(subMenuElement);
        }
        public void ClickNewRecord()
        {
            helper.WaitForElementLoad(btnNewRecord);
            helper.ClickElement(btnNewRecord);
        }
        public void AddNewRecordForEnvironmentAssessment()
        {
            helper.WaitForElementLoad(txtEnvironment);
            EnterDescription();
            helper.WaitForElementLoad(txtDate);
            EnterDate();
        }
        public void EnterDescription()
        {
            string description;
            if (descriptions!=null && descriptions.ToList().Count > 0)
            {
                description = "Enter Second Record";
                txtDescription.SendKeys(description);
                descriptions.Add(description);
            }
            else
            {
                description = "Enter First Record";
                txtDescription.SendKeys(description);
                descriptions.Add(description);
            }

        }
        public void EnterDate()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtDate.SendKeys(date);
        }
        public void DeleteRecord()
        {

            String Delete_Toggle = "//span[contains(text(),'Description:')]/following-sibling::a[text()='#']/../../../following-sibling::div//button[@title='Manage Record']".Replace("#", descriptions[0]);
           _driver.FindElement(By.XPath(Delete_Toggle)).Click();
            helper.WaitForTime(1);
            String Delete = "//span[contains(text(),'Description:')]/following-sibling::a[text()='#']/../../../following-sibling::div//button[@title='Manage Record']/following-sibling::ul//a[contains(@id,'Delete')]".Replace("#", descriptions[0]);

            _driver.FindElement(By.XPath(Delete)).Click();
            helper.WaitForElementLoad(btnConfirm);
            helper.ClickElement(btnConfirm);
        }
        public bool ValidateRecord()
        {
            bool recordExist = false;
            String DescriptionValue_xpath = "//span[contains(text(),'Description:')]/following-sibling::a[text()='#']".Replace("#", descriptions[1]);
            IWebElement element = _driver.FindElement(By.XPath(DescriptionValue_xpath));

            if (element.Displayed)
            {
                recordExist = true;
            }
            else
            {
                recordExist = true;

            }
            return recordExist;
        }
        public void Logout()
        {
            helper.ClickElement(dpdwnUser);
            helper.WaitForTime(1);
            helper.ClickElement(btnLogout);
            helper.WaitForTime(2);
        }
    }
}
