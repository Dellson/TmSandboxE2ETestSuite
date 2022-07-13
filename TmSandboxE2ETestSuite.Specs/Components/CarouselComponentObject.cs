using Microsoft.Playwright;

namespace TmSandboxE2ETestSuite.Components
{
    internal class CarouselComponentObject : BaseComponentObject
    {
        public CarouselComponentObject(IPage page, string selector) : base(page, selector) { }

        public async Task<string?> GetJobLocation(IElementHandle tile)
        {
            var element = await tile.QuerySelectorAsync(".location");
            return await element?.InnerTextAsync();
        }
        public async Task<string?> GetJobTitle(IElementHandle tile)
        {
            var element = await tile.QuerySelectorAsync(".title");
            return await element?.InnerTextAsync();
        }
        public async Task<string?> GetJobListed(IElementHandle tile)
        {
            var element = await tile.QuerySelectorAsync(".listed");
            return await element?.InnerTextAsync();
        }

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

        public async Task ScrollJobTileIntoView(IElementHandle elementHandle)
        {
            var rightButton = await page.QuerySelectorAsync(".recommendation-button.right");

            await rightButton.ClickAsync();

            for (var i = 0; i < 10; i++)
            {
                if (await elementHandle.IsVisibleAsync()) break;
                await rightButton.ClickAsync();
            }
        }

        public async Task<IElementHandle?> GetTileByJobTitle(string jobTitle)
        {
            var allTiles = await GetAllTiles();
            int i = 0;

            for (i = 0; i < allTiles.Count; i++)
            {
                var title = await (await allTiles[i].QuerySelectorAsync(".title")).InnerTextAsync();
                if (title.Trim() == jobTitle.Trim()) {
                    break; 
                }
            }
        
            //var element = allTiles.ToAsyncEnumerable().WhereAwait(async t => 
            //    await (await t.QuerySelectorAsync(".title")).InnerTextAsync() == jobTitle).FirstOrDefaultAsync();
            return allTiles[i];
        }

        public async Task<IElementHandle?> GetTileByIndex(int index) =>
            (await page.QuerySelectorAllAsync($"{selector}.tile{index}"))?.FirstOrDefault();

        public async Task<IReadOnlyList<IElementHandle>> GetAllTiles() =>
            await page.QuerySelectorAllAsync($"{selector}");
    }
}
