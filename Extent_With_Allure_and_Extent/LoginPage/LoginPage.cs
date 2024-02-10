using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extent_With_Allure_and_Extent
{
    internal class LoginPage : BasePage
    {
        #region
        By Usernametxt = By.Id("username");
        By Passwordtxt = By.Id("password");
        By LoginBtn = By.Id("login");
        By Assert = By.CssSelector("body > table.content > tbody > tr:nth-child(1) > td:nth-child(1)");
        By AssertInvalid = By.CssSelector("#login_form > table > tbody > tr:nth-child(5) > td:nth-child(2) > div > b");
        #endregion
        public void LoginWithValidCredentials()
        {
            Reports.ChildNode("LoginWithValidCredentials");
            driver.Url = "https://adactinhotelapp.com/";
            Write(reportNAME,Usernametxt, "User2here", "Username", "UsernameField");
            Write(reportNAME, Passwordtxt, "user123", "password", "passwordField");
            Click(reportNAME, LoginBtn, "LoginBtn", "LoginBtnField");
            Text(reportNAME, Assert, "Welcome to Adactin Group of Hotels", "Confirmation", "ConfirmationField");
        }
        public void LoginWithInValidCredentials()
        {
            Reports.ChildNode("LoginWithInValidCredentials");
            driver.Url = "https://adactinhotelapp.com/";
            Write(reportNAME, Usernametxt, "User2here", "username", "usernameField");
            Write(reportNAME, Passwordtxt, "user", "Password", "PasswordField");
            Click(reportNAME, LoginBtn, "LoginBtn", "LoginBtnFieldfailed");
            Text(reportNAME, AssertInvalid, "Invalid Login details or Your Password might have expired. Click here to reset your password", "ConfirmationFailed", "ConfirmationField");
        }
    }
}
