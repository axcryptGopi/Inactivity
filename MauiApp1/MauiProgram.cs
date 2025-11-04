using MauiApp1.Services;
using Microsoft.Extensions.Logging;

#if MACCATALYST
using MauiApp1.Platforms.MacCatalyst.Services;
#endif

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();


#if MACCATALYST
            builder.Services.AddSingleton<IScreenLockDetector, ScreenLockDetector>();
#endif
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
