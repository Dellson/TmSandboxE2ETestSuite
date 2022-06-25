using Microsoft.Playwright;

namespace TmSandboxE2ETestSuite.Pages
{
    internal class MainPage : BasePage
    {
        protected override string Url => "https://www.tmsandbox.co.nz/";
        private const string jobsButtonSelector = "#SearchTabs1_JobsLink";

        public MainPage(IPage page) : base(page) { }

        public async Task ClickJobsButton()
        {
            await page.ClickAsync(jobsButtonSelector);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions { Timeout = 5000 });
        }
    }
}
