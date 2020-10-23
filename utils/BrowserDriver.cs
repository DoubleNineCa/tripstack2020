using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.IO;
using System.Reflection;

class BrowserDriver
{
    private IWebDriver driver;

    public BrowserDriver(string browserName)
    {
        ChromeOptions co = new ChromeOptions(); // custom options for chrome
        co.PageLoadStrategy = PageLoadStrategy.Normal;  // could be used eager to make this faster

        if (browserName.ToLower().Equals("chrome"))
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), co);
        }
    }

    public IWebDriver GetDriver()
    {
        return driver;
    }
}