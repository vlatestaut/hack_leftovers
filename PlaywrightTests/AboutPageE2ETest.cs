using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace PlaywrightTests
{
    public class AboutPageE2ETest
    {
        private const string AboutUrl = "http://localhost:5000/about";

        [Fact]
        public async Task AboutPage_Should_Display_Heading()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync(AboutUrl);
            var heading = await page.Locator("h3").InnerTextAsync();
            Assert.Equal("About", heading);
        }

        [Fact]
        public async Task AboutPage_Should_Display_All_Images_With_Correct_Alt()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync(AboutUrl);
            Assert.True(await page.Locator("img[alt='Homecare']").IsVisibleAsync());
            Assert.True(await page.Locator("img[alt='Bug']").IsVisibleAsync());
            Assert.True(await page.Locator("img[alt='Homebase']").IsVisibleAsync());
        }

        [Fact]
        public async Task AboutPage_Should_Display_Version_Info()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync(AboutUrl);
            var versionLabel = await page.Locator("span:has-text('Version:')").IsVisibleAsync();
            var versionValue = await page.Locator("span:has-text('1.0.0')").IsVisibleAsync();
            Assert.True(versionLabel);
            Assert.True(versionValue);
        }

        [Fact]
        public async Task AboutPage_Should_Display_Copyright_Info()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync(AboutUrl);
            var copyrightLabel = await page.Locator("span:has-text('Copyright:')").IsVisibleAsync();
            var copyrightValue = await page.Locator("span:has-text('Homecare Homebase')").IsVisibleAsync();
            Assert.True(copyrightLabel);
            Assert.True(copyrightValue);
        }

        [Fact]
        public async Task AboutPage_Close_Button_Should_Navigate_To_Home()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync(AboutUrl);
            Assert.Contains("/about", page.Url); // Confirm we're on About page first
            await page.Locator("button:has-text('Close')").ClickAsync();
            // Wait for the URL to change to home (client-side navigation)
            await page.WaitForURLAsync(url => url == "http://localhost:5000" || url == "http://localhost:5000/", new PageWaitForURLOptions { Timeout = 10000 });
            // Print the actual URL for debugging
            System.Console.WriteLine($"Navigated URL: {page.Url}");
            Assert.True(page.Url == "http://localhost:5000" || page.Url == "http://localhost:5000/", $"Actual URL: {page.Url}");
        }
    }
}
