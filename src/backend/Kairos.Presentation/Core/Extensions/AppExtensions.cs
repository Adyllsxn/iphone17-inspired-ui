namespace Kairos.Presentation.Core.Extensions;
public static class AppExtensions
{
    public static void UseAppExtensions(this WebApplication app)
    {
        // HTTPS Redirection
        app.UseHttpsRedirection();

        // Static Files (wwwroot e Storage)
        app.UseStaticFiles();

        var storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(storagePath),
            RequestPath = "/Storage"
        });

        // Swagger (caso tenha)
        app.UseSweggerExtensions();

        // CORS
        app.UseCorsExtensions();

        // Auth
        app.UseAuthentication();
        app.UseAuthorization();

        // Controllers
        app.MapControllers();
    }
}
