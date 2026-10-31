# Vidur Singh Portfolio (ASP.NET Core 9 Razor Pages)

Open VidurPortfolio.sln in Visual Studio and press F5, or run:

    dotnet run

Then open the URL printed in the terminal (https://localhost:xxxx).

Where to edit:
- Models/SiteData.cs: contact details, stats, profile photo path, services, projects, experience, skills.
- wwwroot/css/site.css: colors are CSS variables at the top of the file.
- Pages/Index.cshtml.cs: contact form handler. Messages are saved to App_Data/messages.jsonl; replace with SMTP or a database before going live.

Photo: put your picture in wwwroot/images (for example profile.jpg) and change ProfileImage in Models/SiteData.cs.
Requires the .NET 9 SDK.
