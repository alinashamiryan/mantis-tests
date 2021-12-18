using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper: HelperBase
    {
        private string baseUrl;

        public AdminHelper(ApplicationManager manager, string baseUrl) : base(manager) {
        this.baseUrl = baseUrl;
        }
        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();
            
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_page.php";
            ICollection<IWebElement> rows = driver.FindElements
                (By.XPath("//i[@class='table table-striped table-bordered table-condensed table-hover']//tbody//tr"));
        foreach(IWebElement row in rows)
            {
             IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match n = Regex.Match(href,@"\d+$");
                string id = n.Value;
               
                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }
        return accounts;
        }
        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseUrl + "/manage_user_edit_page.php?user_id="+ account.Id;
            driver.FindElement(By.CssSelector("input[@value='Удалить учётную запись']")).Click();
            driver.FindElement(By.CssSelector("input[@value='Удалить учётную запись']")).Click();
        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseUrl + "/login_page.php";
            driver.FindElement(By.Name("username")).SendKeys("administrator");
            driver.FindElement(By.CssSelector("input[@value='Вход']")).Click();
            driver.FindElement(By.Name("password")).SendKeys("root");
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            return driver;
        }
    }
}
