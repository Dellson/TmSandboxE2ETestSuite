using BoDi;
using Microsoft.Playwright;

namespace TmSandboxE2ETestSuite.Specs.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IBrowser _browser;
        private IPage _page;
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task BaseSetup()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50
            });
            var context = await _browser.NewContextAsync();
            _page = await context.NewPageAsync();

            _objectContainer.RegisterInstanceAs<IPage>(_page);
        }
    }
}
