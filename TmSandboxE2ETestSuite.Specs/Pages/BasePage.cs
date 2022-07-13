using Microsoft.Playwright;

namespace TmSandboxE2ETestSuite.Pages
{
    internal abstract class BasePage
    {
        protected abstract string Url { get; }
        protected readonly IPage page;

        public BasePage(IPage page)
        {
            this.page = page;
        }

        public async Task OpenPage()
        {
            await page.GotoAsync(Url);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
    }
}
