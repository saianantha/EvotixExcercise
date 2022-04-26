using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SSDTestAutomation.Pages;
using TechTalk.SpecFlow.Assist;

namespace SSDTestAutomation.StepDefinitions
{
    [Binding]
    public class EnvironmentalAssessmentStepDefinitions
    {
        private IWebDriver _driver;
        EnvironmentalAssessment page;

        public EnvironmentalAssessmentStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            page = new EnvironmentalAssessment(_driver);
        }



        [Given(@"user navigate to application")]
        public void GivenUserNavigateToApplication()
        {
            page.NavigateToApplication();
        }

        [Given(@"user login to the application using Username and Password")]
        public void GivenUserLoginToTheApplicationUsingUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            page.Login(data.UserName, data.Password);
        }
        [Given(@"user navigates to Environmental Assessment using modules drop down menu")]
        public void GivenUserNavigatesToEnvironmentalAssessmentUsingModulesDropDownMenu()
        {
            page.NavigateToMainMenu();            
        }

        [When(@"user selects click new record button")]
        public void WhenUserSelectsClickNewRecordButton()
        {
            page.ClickNewRecord();            
        }

        [When(@"user fills the assessment and description fields")]
        public void WhenUserFillsTheAssessmentAndDescriptionFields()
        {
            page.AddNewRecordForEnvironmentAssessment();
            
        }

        [Then(@"click on save and close button")]
        public void ThenClickOnSaveAndCloseButton()
        {
            page.btnSaveAndClose.Submit();
        }

        [When(@"user deletes the first record")]
        public void WhenUserDeletesTheFirstRecord()
        {
            page.DeleteRecord();
        }

        [Then(@"only second record should be available")]
        public void ThenOnlySecondRecordShouldBeAvailable()
        {
            Assert.True(page.ValidateRecord());
        }

        [Then(@"logout from the application")]
        public void ThenLogoutFromTheApplication()
        {
            page.Logout();
        }


    }
}