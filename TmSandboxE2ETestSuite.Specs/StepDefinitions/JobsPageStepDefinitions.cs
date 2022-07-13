using Microsoft.Playwright;
using TmSandboxE2ETestSuite.Pages;

namespace TmSandboxE2ETestSuite.Specs.StepDefinitions
{
    [Binding]
    public sealed class JobsPageStepDefinitions
    {
        private JobsPage jobsPage;

        public JobsPageStepDefinitions(IPage page)
        {
            jobsPage = new JobsPage(page);
        }

        [Given("the starting page is the jobs page")]
        public async Task GivenJobsPageIsOpened()
        {
            await jobsPage.OpenPage();
        }

        [Given("the job named (.*) is present on the carousel")]
        public async void GivenTheCarouselContainsJobWithIndex(string jobTitle)
        {
            //await jobsPage.ScrollToJob(jobTitle);
        }

        [When("I click the (.*) job")]
        public async Task WhenJobIsClicked(string jobTitle)
        {
            //var jobDataModel = await jobsPage.GetJobDataFromCarouselByIndex(1);
            var jobDataModel = await jobsPage.GetJobDataFromCarouselByTitle(jobTitle);
            jobDataModel.location.Should().Be("Bay Of Plenty");
            jobDataModel.title.Should().Be("Sales Manager");
            jobDataModel.listed.Should().Contain("Listed: Wed,");
        }

        [Then("the job details page is opened")]
        public async Task TheTheJobDetailsPageIsOpened()
        {
            //TODO: implement assert (verification) logic
            var jobDataModel = await jobsPage.GetJobDataFromCarouselByTitle("Sales Manager");
            jobDataModel.location.Should().Be("Bay Of Plenty");
            jobDataModel.title.Should().Be("Sales Manager");
            jobDataModel.listed.Should().Contain("Listed: Wed,");
        }
    }
}