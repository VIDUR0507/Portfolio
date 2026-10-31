using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using System.Collections.Generic;

namespace Portfolio.Pages;

public class ContactInput
{
    [Required(ErrorMessage = "Enter your name."), StringLength(80)]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Enter your email."), EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = "";

    public string contact { get; set; } = "";

    [Required(ErrorMessage = "Tell me about your project."), StringLength(2000, MinimumLength = 10, ErrorMessage = "Write at least 10 characters.")]
    public string Message { get; set; } = "";
}

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _env;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly ILogger<IndexModel> _logger;

    //public IndexModel(IWebHostEnvironment env) => _env = env;

    public IndexModel(
       IWebHostEnvironment env,
       IHttpClientFactory httpClientFactory,
       IConfiguration configuration,
       ILogger<IndexModel> logger)
    {
        _env = env;
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _logger = logger;
    }

    [BindProperty]
    public ContactInput Input { get; set; } = new();

    [TempData]
    public string? Status { get; set; }

    public void OnGet() { }

    //public async Task<IActionResult> OnPostAsync()
    //{
    //    if (!ModelState.IsValid) return Page();

    //    // Messages are saved to App_Data/messages.jsonl. Swap this for SMTP or a database when you deploy.
    //    var dir = Path.Combine(_env.ContentRootPath, "App_Data");
    //    Directory.CreateDirectory(dir);
    //    var line = JsonSerializer.Serialize(new { Input.Name, Input.Email, Input.Message, SentAt = DateTime.UtcNow });
    //    await System.IO.File.AppendAllTextAsync(Path.Combine(dir, "messages.jsonl"), line + Environment.NewLine);

    //    Status = "Message sent. I will reply within a day or two.";
    //    return Redirect("/#contact");
    //}

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            var url = _configuration["GoogleSheets:WebAppUrl"];

            if (string.IsNullOrWhiteSpace(url))
            {
                //throw new InvalidOperationException(
                //    "Google Sheets URL is not configured.");

                _logger.LogError("Google Sheets WebAppUrl is missing from configuration.");
                ModelState.AddModelError(string.Empty,"Contact form configuration is missing.");
                return Page();
            }

            var payload = new
            {
                name = Input.Name,
                email = Input.Email,
                whatsapp = Input.contact,
                message = Input.Message
            };

            var client = _httpClientFactory.CreateClient();

            using var response = await client.PostAsJsonAsync(url, payload);
            //response.EnsureSuccessStatusCode();

            //var result = await response.Content.ReadFromJsonAsync
            //    <Dictionary<string, bool>>();

            //if (result == null ||
            //    !result.TryGetValue("success", out var success) ||
            //    !success)
            //{
            //    throw new InvalidOperationException(
            //        "Google Sheets did not confirm the submission.");
            //}

            var responseBody = await response.Content.ReadAsStringAsync();
            _logger.LogInformation(
           "Google Sheets HTTP Status: {StatusCode}; Response: {Body}",
           (int)response.StatusCode,
           responseBody);

            response.EnsureSuccessStatusCode();

            // Step 6: Parse the JSON response
            using var json = JsonDocument.Parse(responseBody);
            var root = json.RootElement;

            if (!root.TryGetProperty("success", out var success) ||
                success.ValueKind != JsonValueKind.True)
            {
                var errorMessage = root.TryGetProperty("error", out var error)
                    ? error.GetString()
                    : "Google Sheets did not confirm the submission.";

                throw new InvalidOperationException(
                    errorMessage ?? "Unknown Google Sheets error.");
            }

            Status = "Message submitted successfully. I will reply within a day or two.";
            return Redirect("/Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to submit contact form to Google Sheets.");

            ModelState.AddModelError(
                string.Empty,
                "Unable to submit your message right now. Please try again.");

            return Page();
        }
    }
}
