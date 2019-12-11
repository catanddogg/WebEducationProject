using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    public class WebDriverController : Controller
    {
        private readonly IWebDriver _driver;
        public WebDriverController()
        {
            _driver = new ChromeDriver();
            Create_WhenExecuted_ReturnsCreateView();
        }

        public void Create_WhenExecuted_ReturnsCreateView()
        {
            _driver.Navigate()
                .GoToUrl("https://www.olx.com.eg/en/");

            _driver.FindElement(By.Id("headerSearch"))
                .SendKeys("Test");

            _driver.FindElement(By.Id("submit-searchmain"))
                    .Click();
        }
    }
}