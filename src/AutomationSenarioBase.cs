using Dapper;
using FluentAutomation.Utility;
using FluentAutomation.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FluentAutomation
{
    public class AutomationSenarioBase
    {
        protected IWebDriver _driver;
        WebDriverFactory _webDriverFactory;
        public AutomationSenarioBase(AutomationEnvironment cnf = null)
        {
            cnf = cnf ?? AutomationTestConfig.Env;
            _webDriverFactory = new WebDriverFactory();
            _driver = _webDriverFactory.GetWebDriver(cnf.BrowserConfig);
        }

        public void Sleep(int sleep = 0)
        {
            Thread.Sleep((sleep.Is(0) ? AutomationTestConfig.Sleep : sleep) * 1000);
        }

        #region db executions
        public void ExecuteOnDb(string sql)
        {
            using (var conn = new Database(AutomationTestConfig.DbConnectionString).GetConnection())
            {
                var selectQuery = sql.Split(';')[0];
                var ids = conn.Query<int>(selectQuery).ToList();
                var updateQuery = sql.Split(';').ToList();
                updateQuery.RemoveAt(0);
                conn.Execute(string.Join(';', updateQuery), new
                {
                    vehicleTypeIds = ids
                });
            }
        }

        public List<T> ReadOnDb<T>(string sql)
        {
            using (var conn = new Database(AutomationTestConfig.DbConnectionString).GetConnection())
            {
                return conn.Query<T>(sql).ToList();
            }
        }

        #endregion
    }
}
