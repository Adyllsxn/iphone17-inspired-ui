var builder = WebApplication.CreateBuilder(args);
    builder.AddBuildExtensions();

var app = builder.Build();

    var cultureInfo = new CultureInfo("en-US");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

    app.UseAppExtensions();
    app.Run();