using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace PlaywrightTests
{
    public class AllPagesE2ETest
    {
        [Theory]
        [InlineData("/", "Welcome to BackOffice.Blazor")]
        [InlineData("/workers", "Workers Management")]
        [InlineData("/tableadmin", "Table Administration")]
        [InlineData("/referral-form", "Patient Intake")]
        [InlineData("/mainform-full", "HCHB BackOffice")]
        [InlineData("/graphql-demo", "GraphQL Demo")]
        [InlineData("/clinical-input-search", "Search")]
        [InlineData("/clinical-input", "Clinical Input Console")]
        // [InlineData("/client-referral", "Client Referral Form")] // File missing or misnamed
        [InlineData("/billing-management", "Billing Management")]
        [InlineData("/workers/add-edit", "Add/Edit Worker")] // or form fields
        [InlineData("/workers/add-edit-1", "Add/Edit Worker")]
        [InlineData("/about", "About")]
        [InlineData("/wound/view-list", "form-header")] // class
        [InlineData("/wound/add-simple", "form-header")]
        [InlineData("/wound/add-edit-image", "form-header")]
        [InlineData("/wound/compare-images", "form-header")]
        [InlineData("/wound/correct-location-type", "dialog-container")]
        [InlineData("/wound/inactivate", "dialog-container")]
        [InlineData("/wound/restage-pressure-ulcer", "dialog-container")]
        [InlineData("/wound/associate-to-order", "dialog-container")]
        [InlineData("/wound/record", "app-header")]
        public async Task Page_Should_Load_And_Display_Key_Element(string route, string keyTextOrClass)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync($"http://localhost:5000{route}");

            bool found = false;
            // Prefer heading roles for text checks using GetByRole
            if (!string.IsNullOrWhiteSpace(keyTextOrClass))
            {
                try
                {
                    // Try heading roles (h1-h6) using GetByRole
                    var headingRoles = new[] { AriaRole.Heading };
                    foreach (var role in headingRoles)
                    {
                        var headingLocator = page.GetByRole(role, new() { Name = keyTextOrClass, Exact = true });
                        if (await headingLocator.CountAsync() == 1)
                        {
                            found = await headingLocator.IsVisibleAsync();
                            if (found) break;
                        }
                        else if (await headingLocator.CountAsync() > 1)
                        {
                            // If ambiguous, pick the first but log a warning
                            found = await headingLocator.First.IsVisibleAsync();
                            System.Console.WriteLine($"[Warning] Ambiguous heading match for '{keyTextOrClass}' on {route}, using first match.");
                            if (found) break;
                        }
                    }
                }
                catch { /* fallback to next method */ }
            }
            // If not found, try by exact text (for non-class selectors)
            if (!found && !string.IsNullOrWhiteSpace(keyTextOrClass))
            {
                try
                {
                    var textLocator = page.GetByText(keyTextOrClass, new() { Exact = true });
                    if (await textLocator.CountAsync() == 1)
                    {
                        found = await textLocator.IsVisibleAsync();
                    }
                    else if (await textLocator.CountAsync() > 1)
                    {
                        found = await textLocator.First.IsVisibleAsync();
                        System.Console.WriteLine($"[Warning] Ambiguous text match for '{keyTextOrClass}' on {route}, using first match.");
                    }
                }
                catch { /* fallback to next method */ }
            }
            // If not found, try by class (escape special characters)
            if (!found && !string.IsNullOrWhiteSpace(keyTextOrClass))
            {
                try
                {
                    var safeClass = CssEscape(keyTextOrClass);
                    var classLocator = page.Locator($".{safeClass}");
                    if (await classLocator.CountAsync() == 1)
                    {
                        found = await classLocator.IsVisibleAsync();
                    }
                    else if (await classLocator.CountAsync() > 1)
                    {
                        found = await classLocator.First.IsVisibleAsync();
                        System.Console.WriteLine($"[Warning] Ambiguous class match for '{keyTextOrClass}' on {route}, using first match.");
                    }
                }
                catch { /* fallback to assertion */ }
            }
            Assert.True(found, $"Key element '{keyTextOrClass}' not found on page {route}");
        }

        /// <summary>
        /// Escapes a string for use as a CSS class selector (mimics CSS.escape).
        /// </summary>
        private static string CssEscape(string className)
        {
            if (string.IsNullOrEmpty(className)) return string.Empty;
            var sb = new System.Text.StringBuilder();
            foreach (var c in className)
            {
                // Escape anything not a-z, A-Z, 0-9, underscore, or hyphen
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '-' || c == '_')
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append($"\\{((int)c).ToString("x")}");
                }
            }
            return sb.ToString().Replace(" ", ".");
        }
    }
}
