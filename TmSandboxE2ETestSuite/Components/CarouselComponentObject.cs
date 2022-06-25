using Microsoft.Playwright;

namespace TmSandboxE2ETestSuite.Components
{
    internal class CarouselComponentObject : BaseComponentObject
    {
        public CarouselComponentObject(IPage page, string selector) : base(page, selector) { }

        public async Task<string?> GetJobLocationByIndex(int index)
        {
            var tile = await GetTileByIndex(index);
            var element = await tile?.QuerySelectorAsync(".location");
            return await element?.InnerTextAsync();
        }

        public async Task<string?> GetJobTitleByIndex(int index)
        {
            var tile = await GetTileByIndex(index);
            var element = await tile?.QuerySelectorAsync(".title");
            return await element?.InnerTextAsync();
        }

        public async Task<string?> GetJobListedByIndex(int index)
        {
            var tile = await GetTileByIndex(index);
            var element = await tile?.QuerySelectorAsync(".listed");
            return await element?.InnerTextAsync();
        }

        public async Task<IElementHandle?> GetTileByIndex(int index)
        {
            return (await page.QuerySelectorAllAsync($"{selector}.tile{index}"))?.FirstOrDefault();
        }
    }
}
