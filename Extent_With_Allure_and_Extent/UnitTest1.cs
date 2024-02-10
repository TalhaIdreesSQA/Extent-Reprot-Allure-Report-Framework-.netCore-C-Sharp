using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Extent_With_Allure_and_Extent
{
    [AllureNUnit]
    [TestFixture]
    public class Tests
    {
        public TestContext instance;

        public TestContext TestContext
        {
            get { return instance; }
            set { instance = value; }
        }
        [OneTimeSetUp]
        public void ClassSetup()
        {
            
        }
        [OneTimeTearDown]
        public void ClassCleanup()
        {
        }

        [SetUp]

        public void Setup()
        {
            Reports.Report();
            BasePage.SeleniumInt();
        }
        [TearDown]
        public void TextCleaup()
        {
            Reports.flush();
            BasePage.driver.Close();
        }

        [Test]
        [AllureStep]
        public void LoginPage()
        {
            Reports.ParentNode(NUnit.Framework.TestContext.CurrentContext.Test.Name);
            LoginPage loginPage = new LoginPage();
            loginPage.LoginWithValidCredentials();
            loginPage.LoginWithInValidCredentials();
        }
    }
    public class Assembly
    {
        [OneTimeSetUp]
        public void AssemblySetup()
        {
        }
        [OneTimeTearDown]
        public void AssemblyCleanup()
        {
        }

    }
}