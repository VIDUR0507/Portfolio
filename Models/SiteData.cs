namespace Portfolio.Models;

public record Service(string Title, string Summary, string[] Offers);
public record Project(string Name, string Kind, string Summary, string[] Highlights, string[] Stack);
public record Job(string Role, string Company, string Period, string[] Points);
public record SkillGroup(string Name, string[] Items);
public record Stat(string Value, string Label);
public record Education(string Degree, string School, string Period, string Score);

// Edit this file to change what the portfolio shows.
public static class SiteData
{
    public const string Name = "Vidur Singh";
    public const string Role = "Software Engineer";
    public const string Location = "Lucknow, Uttar Pradesh, India";
    public const string Email = "singhvidur761@gmail.com";
    public const string Phone = "+91-7843839368";
    public const string LinkedIn = "https://linkedin.com/in/vidur-singh-5112b1202";

    public const string Intro =
        "I build .NET application and Backend apis, SQL Server databases and automated test scripts for web products. " +
        "Two-plus years of shipping APIs, corporate websites and Selenium frameworks.";

    public const string HeroLead =
    "I design and build .NET applications, backend APIs, SQL Server databases, and automated test scripts using Selenium for web products.";

    //public const string About =
    //    "I am a software engineer in Lucknow with a Master of Computer Application degree. " +
    //    "I work mainly in C# and ASP.NET Core, building RESTful APIs, Razor Pages websites and SQL Server databases, " +
    //    "and I write Selenium frameworks that keep those products working after every release. " +
    //    "I also have a background in Angular and Ionic mobile development.";

    public const string About =
    "I am Software Engineer with 2+ years of experience in .NET backend development, test automation, and full-stack web applications. " +
    "Proficient in building RESTful APIs using ASP.NET Core, developing scalable Selenium WebDriver automation frameworks in C# and Java, " +
    "and integrating enterprise platforms such as Microsoft Dataverse and Power Platform SDK. " +
    "Skilled in Angular and Ionic mobile development, SQL Server database management, and test automation using TestNG and Page Object Model (POM). " +
    "Committed to delivering clean, maintainable, and efficient code with a strong focus on software quality, performance, and end-to-end test coverage.";

    //public const string ProfileImage = "/images/profile.svg";

    public static readonly Stat[] Stats =
    {
        new("4+", "Projects done"),
        new("4", "Services offered"),
        new("2y+", "Experience"),
    };

    public static readonly Service[] Services =
    {
        new("Website development",
            "Responsive business and corporate websites with a clean, maintainable structure and real data behind them.",
            new[] { "ASP.NET Core Razor Pages", "Bootstrap, HTML, CSS", "Dynamic content sections", "Dataverse and CRM integration" }),
        new("Database development and management",
            "Relational schemas designed for the way your application reads and writes data.",
            new[] { "SQL Server and MySQL", "Tables, relationships, indexing", "Stored procedures and raw SQL", "Entity Framework Core" }),
        new("Custom software development",
            "Backends, REST APIs and mobile apps built around your workflow, from login to reporting.",
            new[] { "RESTful APIs and Minimal APIs", "JWT authentication", "MVC e-commerce and CRM backends", "Angular and Ionic mobile apps" }),
        new("Software testing and automation",
            "Automated checks that replace repetitive manual testing and catch regressions early.",
            new[] { "Selenium WebDriver in C# and Java", "TestNG and Page Object Model", "API testing with Postman", "Performance checks and alerts" }),
    };

    public static readonly Project[] Projects =
    {
        new("Polymath & Boffin corporate website", "Website",
            "Responsive real estate corporate website with user-specific content pulled from Microsoft Dataverse.",
            new[]
            {
                "Shared layouts, partial views, modals and alert components",
                "Fetch XML and the Dataverse SDK for listings, applications and contact submissions",
                "Minimal APIs that serve mobile and external clients",
            },
            new[] { "ASP.NET Core Razor Pages", "C#", "Bootstrap", "Dataverse" }),
        new("CRM integration and automation backend", "Web API",
            "Web API for CRM user registration, login and project access management.",
            new[]
            {
                "JWT authentication and BCrypt password hashing",
                "Model validation and null safety across every layer",
                "EF Core CRUD, stored procedures and raw SQL, tested in Postman",
            },
            new[] { "ASP.NET Core Web API", "C#", "SQL Server", "EF Core" }),
        new("Web performance optimization system", "Test automation",
            "Data-driven framework that benchmarks page speed and alerts stakeholders when an SLA is missed.",
            new[]
            {
                "Test scenarios read from Excel and executed dynamically",
                "Login, homepage and multi-page navigation timings",
                "Automatic email alerts and trend reports",
            },
            new[] { "Selenium", "Java", "TestNG", "C#" }),
        new("Practitioner fitness checker", "Test automation",
            "C# automation that replaced a manual judgment check on a healthcare regulatory website.",
            new[]
            {
                "Daily verification of registration numbers and fitness-to-practice status",
                "Timestamped screenshots stored for audit and compliance",
                "Cut operational effort by nearly 100%",
            },
            new[] { "Selenium WebDriver", "C#" }),
    };

    public static readonly Job[] Jobs =
    {
        //new("Software Engineer", "XRM Labs Pvt. Ltd.", "Feb 2024 – Present", new[]
        //{
        //    "Built RESTful APIs, MVC controllers and SQL Server schemas for CRM and e-commerce projects.",
        //    "Delivered a responsive Razor Pages corporate website integrated with Microsoft Dataverse.",
        //    "Wrote Selenium scripts in (C# and Java) and TestNG suites using the Page Object Model, and tested APIs in Postman.",
        //    "Performed manual testing including functional, regression, and UI testing to ensure software quality before deployment." 
        //}),

        new("Software Engineer", "XRM Labs Pvt. Ltd.", "Feb 2024 – Present", new[]
        {
            "Designed and developed a responsive corporate website from scratch using ASP.NET Core Razor Pages and Bootstrap, featuring static and dynamic content sections.",
            "Integrated Microsoft Dataverse with FetchXML and the Power Platform SDK to retrieve CRM data and create applicant records, enabling two-way data exchange between the website and CRM.",
            "Developed secure RESTful APIs using ASP.NET Core for CRM operations, including user registration, login, and project access management, with JWT authentication.",
            "Designed relational database schemas for e-commerce and CRM projects, including table structures, relationships, and indexing strategies in SQL Server.",
            "Developed and maintained automated test scripts using Selenium WebDriver with C# to validate web application functionality and reliability.",
            "Implemented end-to-end (E2E) test automation using the Page Object Model (POM) design pattern and TestNG, improving test coverage and maintainability.",
            "Tested RESTful APIs using Postman, validating request and response payloads, HTTP status codes, and data integrity.Performed manual functional, regression, and UI testing to identify defects and ensure software quality before deployment."
        }),
        new("Trainee Software Engineer", "Jamtech Technologies", "Sept 2023 – Feb 2024", new[]
        {
            "Built cross-platform mobile apps with Angular and Ionic.",
            "Created reactive forms with validation and clear error handling.",
        }),
    };

    public static readonly SkillGroup[] Skills =
    {
        new("Programming Languages", new[] { "C#", "Core Java", "JavaScript", "TypeScript" }),
        new("Frameworks", new[] { ".NET Core", "ASP.NET", "Razor Pages", "Angular", "Ionic", "Bootstrap" }),
        new("Testing", new[] { "Selenium WebDriver", "TestNG", "Postman" }),
        new("Databases", new[] { "SQL Server", "MySQL" }),
        new("Tools", new[] { "Visual Studio", "VS Code", "Eclipse" }),
    };

    public static readonly Education[] Education =
    {
        new("Master of Computer Application", "Babu Banarasi Das University, Lucknow", "2020 – 2022", "82.3%"),
        new("Bachelor of Computer Application", "Lucknow University, Lucknow", "2017 – 2020", "64.9%"),
    };

    public static readonly string[] Certifications =
    {
        "Ionic Framework – Jamtech Technologies",
        "Core Java Using MySQL – Digipodium",
        "Django Web Development – Digipodium",
    };
}
