using Microsoft.Playwright;

namespace TmSandboxE2ETestSuite.Components
{
    internal abstract class BaseComponentObject
    {
        protected readonly IPage page;
        protected readonly string selector;

        public BaseComponentObject(IPage page, string selector)
        {
            this.page = page;
            this.selector = selector;
        }
    }
}
