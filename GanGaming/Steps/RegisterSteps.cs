using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace GanGaming.Steps
{
    [Binding]
    public class RegisterSteps :  IDisposable
    {
        private ChromeDriver Driver;
        public RegisterSteps()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

        }

        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Dispose();
                Driver = null;
            }
        }

        protected string HomePage = "https://moneygaming.qa.gameaccount.com/";
        protected virtual string homePageJoin => "a.newUser";
        protected virtual string title => "title";
        protected virtual string forename => "forename";
        protected virtual string lastname => "[name*='map(lastName']";
        protected virtual string termsCheckbox => "[name*='map(terms)']";
        protected virtual string joinus => "form";
        protected virtual string errorDob => "[for*='dob']";
        protected virtual string errorFieldMessage => "This field is required";
        protected virtual string passwordElement => "[name*='map(password)']";
        protected virtual string errorPassword => "[for*='password']";
        protected virtual string passwordConfirmElement => "[name*='map(passwordConfirm)']";
        protected virtual string errorPasswordConfirm => "[for*='passwordConfirm']";
        protected virtual string passwordErrorMessageAtleast6Chars => "The minimum length is 6 characters";
        protected virtual string RegisterationPage => "signupForm";



        [Given(@"I navigate to moneygaming website")]
        public void GivenINavigateToMoneygamingWebsite()
        {
            Driver.Navigate().GoToUrl(HomePage);
        }

        [When(@"I click JoinNow button")]
        public void WhenIClickJoinNowButton()
        {
            Driver.FindElement(By.CssSelector(homePageJoin)).Click();
        }

        [Given(@"I enter firstname '(.*)' and surname '(.*)' in the form")]
        public void GivenIEnterFirstnameAndSurnameInTheForm(string forenamevalue, string lastnamevalue)
        {
            Driver.FindElement(By.Id(forename)).SendKeys(forenamevalue);
            Driver.FindElement(By.CssSelector(lastname)).SendKeys(lastnamevalue);
        }

        [Given(@"I click terms and condition checkbox")]
        public void GivenIClickTermsAndConditionCheckbox()
        {
            Driver.FindElement(By.CssSelector(termsCheckbox)).Click();
        }

        [Given(@"I enter password '(.*)'")]
        public void GivenIEnterPassword(string passwordValue)
        {
            Driver.FindElement(By.CssSelector(passwordElement)).SendKeys(passwordValue);
            Driver.FindElement(By.CssSelector(passwordConfirmElement)).SendKeys(passwordValue);
        }

        [Then(@"I should be able to see error message in the password field be atleast six characters")]
        public void ThenIShouldBeAbleToSeeErrorMessageInThePasswordFieldBeAtleastSixCharacters()
        {
            string errorPasswordConfirmText = Driver.FindElement((By.CssSelector(errorPasswordConfirm))).Text;
            Assert.AreEqual(passwordErrorMessageAtleast6Chars, errorPasswordConfirmText, $"Error message for DOB is not correct {errorFieldMessage} ");
        }

        [Then(@"I should be able to see error message in the password field must contain atleast one number")]
        public void ThenIShouldBeAbleToSeeErrorMessageInThePasswordFieldMustContainAtleastOneNumber()
        {
            Driver.FindElement(By.Id(joinus)).Click();
            string errorPasswordConfirmText = Driver.FindElement((By.CssSelector(errorPasswordConfirm))).Text;
            Assert.AreNotEqual(errorFieldMessage, errorPasswordConfirm, $"Error message for DOB is not correct {errorFieldMessage} ");
        }

        [Then(@"I should be able to see error message in the password field must contain atleast one special character")]
        public void ThenIShouldBeAbleToSeeErrorMessageInThePasswordFieldMustContainAtleastOneSpecialCharacter()
        {
            Driver.FindElement(By.Id(joinus)).Click();
            string errorPasswordConfirmText = Driver.FindElement((By.CssSelector(errorPasswordConfirm))).Text;
            Assert.AreNotEqual(errorFieldMessage, errorPasswordConfirm, $"Error message for DOB is not correct {errorFieldMessage} ");
        }

        [Given(@"I see the registration page")]
        public void GivenISeeTheRegistrationPage()
        {
            Driver.FindElement(By.Id(RegisterationPage));
        }

        [Given(@"I select '(.*)' from the title selectbox")]
        public void GivenISelectFromTheTitleSelectbox(string titleValue)
        {
            new SelectElement(Driver.FindElement(By.Id(title))).SelectByValue(titleValue);
        }

        [Then(@"I should be able to see error message below dob selectbox as '(.*)'")]
        public void ThenIShouldBeAbleToSeeErrorMessageBelowDobSelectboxAs(string p0)
        {
            Driver.FindElement(By.Id(joinus)).Click();
            string errorDobText = Driver.FindElement((By.CssSelector(errorDob))).Text;
            Assert.AreEqual(errorFieldMessage, errorDobText, $"Error message for DOB is not correct {errorFieldMessage} ");
        }

        [Then(@"I enter password '(.*)'")]
        public void ThenIEnterPassword(string passwordValue)
        {
            Driver.FindElement(By.CssSelector(passwordElement)).SendKeys(passwordValue);
            Driver.FindElement(By.CssSelector(passwordConfirmElement)).SendKeys(passwordValue);
        }


    }
}
