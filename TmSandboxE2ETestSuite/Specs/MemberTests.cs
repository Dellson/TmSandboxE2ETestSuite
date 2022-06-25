using Microsoft.Playwright;
using FluentAssertions;
using TmSandboxE2ETestSuite.Pages;
using NUnit.Framework;

namespace TmSandboxE2ETestSuite.Specs;

[Parallelizable(ParallelScope.Self)]
public class MemberTests
{
    private IBrowser _browser;
    private IPage _page;

    [SetUp]
    public async Task Setup()
    {
        var playwright = await Playwright.CreateAsync();
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50
        });
        var context = await _browser.NewContextAsync();
        _page = await context.NewPageAsync();
    }

    [Test]
    public async Task OpenTheJobsPage()
    {
        var mainPage = new MainPage(_page);
        await mainPage.OpenPage();
        await mainPage.ClickJobsButton();

        _page.Url.Should().Be("https://www.tmsandbox.co.nz/jobs");
    }

    [Test]
    public async Task SearchForJobs()
    {
        await _page.GotoAsync("https://www.tmsandbox.co.nz/");
        await _page.ClickAsync("#SearchTabs1_JobsLink");
        await _page.WaitForURLAsync("https://www.tmsandbox.co.nz/jobs");
        _page.Url.Should().Be("https://www.tmsandbox.co.nz/jobs");

        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        var carousel = await _page.QuerySelectorAllAsync(".job-card.tile1");
        var title = await carousel[0].QuerySelectorAsync(".title");

        (await title.InnerTextAsync()).Should().Be("Sales Manager");

        // email:       pawel@dela.net.pl
        // password:    HkB9U4LqaTP4UqBKITxf

    }

    [Test]
    public async Task CreateNewUser()
    {

    }
}