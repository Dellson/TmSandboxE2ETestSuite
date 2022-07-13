using FluentAssertions;
using TmSandboxE2ETestSuite.Pages;

namespace TmSandboxE2ETestSuite.Specs
{
    [Parallelizable(ParallelScope.Self)]
    public class JobsTests : BaseTest
    {
        [Test]
        public async Task OpenTheJobsPage()
        {
            // Arrange
            var mainPage = new MainPage(page);

            // Act
            await mainPage.OpenPage();
            await mainPage.ClickJobsButton();

            // Assert
            page.Url.Should().Be("https://www.tmsandbox.co.nz/jobs");
        }

        [Test]
        public async Task OpenJobFromCarousel()
        {
            // Arrange
            var jobsPage = new JobsPage(page);

            // Act
            await jobsPage.OpenPage();
            var jobDataModel = await jobsPage.GetJobDataFromCarouselByIndex(1);

            // Assert
            jobDataModel.location.Should().Be("Bay Of Plenty");
            jobDataModel.title.Should().Be("Sales Manager");
            jobDataModel.listed.Should().Be("Listed: Wed, 22 Jun");
        }
    }
}