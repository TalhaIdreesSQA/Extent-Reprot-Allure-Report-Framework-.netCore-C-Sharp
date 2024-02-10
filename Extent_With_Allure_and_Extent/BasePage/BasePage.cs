using Allure.Net.Commons;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extent_With_Allure_and_Extent
{
    internal class BasePage 
    {
        public static string reportNAME = "extentreport";
        public static string path = "C:\\Users\\Taha\\source\\repos\\Extent_With_Allure_and_Extent\\Extent_With_Allure_and_Extent\\ScreenShot";
        public static IWebDriver driver;
        public static void SeleniumInt()
        {
            driver = new ChromeDriver();
        }
        public static void Write(string Reportname, By by, string text, string StepDetails, string Filename = "")
        {
            Reportname.ToLower();
            if (Reportname == "extentreport")
            {
                try
                {
                    driver.FindElement(by).SendKeys(text);
                    Reports.ExtentReportPass(Filename, StepDetails);
                }
                catch (Exception)
                {
                    Reports.ExtentReportFail(Filename, StepDetails);
                    throw;
                }
            }
            else if (Reportname == "allurereport")
            {
                try
                {
                    driver.FindElement(by).SendKeys(text);
                    BasePage.AllureReport(StepDetails + " :Passed");
                }
                catch (Exception)
                {
                    BasePage.AllureReport(StepDetails + " :Failed");
                    throw;
                }
            }


        }
        public static void Click(string Reportname, By by, string StepDetails, string Filename = "")
        {
            Reportname.ToLower();
            if (Reportname == "extentreport")
            {
                try
                {

                    driver.FindElement(by).Click();
                    Reports.ExtentReportPass(Filename, StepDetails);
                }
                catch (Exception)
                {
                    Reports.ExtentReportFail(Filename, StepDetails);
                    throw;
                }
            }
            else if (Reportname == "allurereport")
            {
                try
                {
                    driver.FindElement(by).Click();
                    BasePage.AllureReport(StepDetails + " :Passed");
                }
                catch (Exception)
                {
                    BasePage.AllureReport(StepDetails + " :Failed");
                    throw;
                }
            }

        }
        public static void Text(string Reportname, By by, string expected, string StepDetails, string Filename = "")
        {
            Reportname.ToLower();
            if (Reportname == "extentreport")
            {
                try
                {
                    string actual = driver.FindElement(by).Text;
                    Assert.AreEqual(expected, actual);
                    Reports.ExtentReportPass(Filename, StepDetails);
                }
                catch (Exception)
                {
                    Reports.ExtentReportFail(Filename, StepDetails);
                    throw;
                }
            }
            else if (Reportname == "allurereport")
            {
                try
                {
                    string actual = driver.FindElement(by).Text;
                    Assert.AreEqual(expected, actual);
                    BasePage.AllureReport(StepDetails + " :Passed");
                }
                catch (Exception)
                {
                    BasePage.AllureReport(StepDetails + " :Failed");
                    throw;
                }
            }

        }
        public static void Screenshot(string filename)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path + filename+".Png");
        }
        public static void AllureReport(string StepDetails)
        {
            string path1 = "C:\\Users\\Taha\\source\\repos\\Extent_With_Allure_and_Extent\\Extent_With_Allure_and_Extent\\ScreenShot" + "TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            //screenshot.SaveAsFile(path1, ScreenshotImageFormat.Png);
            AllureLifecycle.Instance.AddAttachment(StepDetails, "image.png", path1);
        }
        public static void Action(string txt)
        {
            Actions action = new Actions(driver);
            if (txt == "ArrowDown")
            {
                action.SendKeys(Keys.ArrowDown).Build().Perform();
            }
            else if (txt == "ArrowUp")
            {
                action.SendKeys(Keys.ArrowUp).Build().Perform();
            }

        }
        public static void JS_Executor(string type, int value)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            type.ToLower();
            if (type == "scrolldown")
            {
                js.ExecuteScript("window.scrollBy(0,-250)");
            }
            else if (type == "scrollup")
            {
                js.ExecuteScript("window.scrollBy(0,250");
            }
            else if (type == "ZOOMIN")
            {
                js.ExecuteScript(string.Format("document.body.style.zoom=25%"));
            }
            else if (type == "ZOOMOUT")
            {
                js.ExecuteScript(string.Format("document.body.style.zoom=-25%"));
            }

        }
        public static void BOptions(string browser, string type)
        {
            browser.ToLower();
            type.ToLower();
            if (browser == "chrome")
            {
                ChromeOptions options = new ChromeOptions();
                if (type == "incognito")
                {
                    options.AddArgument("--incognito");
                }
                else if (type == "headless")
                {
                    options.AddArgument("--headless=new");
                }
                driver = new ChromeDriver(options);
            }
            else if (browser == "firefox")
            {
                var options = new FirefoxOptions();
                if (type == "incognito")
                {
                    options.AddArgument("--incognito");
                }
                else if (type == "headless")
                {
                    options.AddArgument("--headless=new");
                }
                driver = new FirefoxDriver(options);
            }


        }
        public static void ImplicitWait(double timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }
        public static void Key(By by, string text)
        {
            text.ToLower();
            if (text == "tab")
            {
                driver.FindElement(by).SendKeys(Keys.Tab);
            }
            else if (text == "arrowdown")
            {
                driver.FindElement(by).SendKeys(Keys.ArrowDown);
            }
            else if (text == "enter")
            {
                driver.FindElement(by).SendKeys(Keys.Enter);
            }

        }
    }
}
