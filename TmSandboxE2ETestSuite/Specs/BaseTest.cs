using Microsoft.Playwright;

namespace TmSandboxE2ETestSuite.Specs
{
    public abstract class BaseTest
    {
        protected IBrowser browser;
        protected IPage page;

        [SetUp]
        public async Task BaseSetup()
        {
            var playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50
            });
            var context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
        }
    }
}
