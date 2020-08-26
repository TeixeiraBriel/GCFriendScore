using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GCFriendsScore.Fixtures
{
    public class ColetaFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public ColetaFixture()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
