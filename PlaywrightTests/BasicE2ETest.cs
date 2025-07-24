using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace PlaywrightTests
{
    public class BasicE2ETest
    {
        [Fact]
        public async Task HomePage_Should_Have_Title()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("http://localhost:5000");
            var title = await page.TitleAsync();
            Assert.False(string.IsNullOrWhiteSpace(title));
        }
    }
}
