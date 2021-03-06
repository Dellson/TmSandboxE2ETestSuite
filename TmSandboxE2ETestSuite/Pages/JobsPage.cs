using Microsoft.Playwright;
using TmSandboxE2ETestSuite.Components;
using TmSandboxE2ETestSuite.DataModel;

namespace TmSandboxE2ETestSuite.Pages
{
    internal class JobsPage : BasePage
    {        
        protected override string Url => "https://www.tmsandbox.co.nz/jobs";
        private readonly CarouselComponentObject jobCarousel;

        public JobsPage(IPage page) : base(page)
        {
            jobCarousel = new CarouselComponentObject(page, ".job-card");
        }


        public async Task<JobCarouselDataModel> GetJobDataFromCarouselByIndex(int index) =>
            new JobCarouselDataModel
            {
                location = await jobCarousel.GetJobLocationByIndex(index),
                title = await jobCarousel.GetJobTitleByIndex(index),
                listed = await jobCarousel.GetJobListedByIndex(index)
            };
    }
}
