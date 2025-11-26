/*using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace KmPlaywrightUnitDemo
{
    public class NunitPlaywright : PageTest
    {
        private IBrowser _browser;
        private IPage _page;
        private IPlaywright _playwright;

        [SetUp]
        public async Task Setup()
        {


        }

        [TearDown]
        public async Task Teardown()
        {

        }


        [Test]
        public async Task NavigateToPublixHomePage()
        {

            // Use the already initialized _page
            await Page.GotoAsync("https://www.publix.com");
            await Page.ClickAsync("text=Log in");
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "publix.jpg"
            });

            // Example assertion to verify navigation
            Assert.That((await _page.TitleAsync()).Contains("Publix"));
        }
    }
}
Got your message from visual studio*/

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : PageTest
{
    [Test]
    public async Task HasTitle()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [Test]
    public async Task GetStartedLink()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Click the get started link.
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation.
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }
}
