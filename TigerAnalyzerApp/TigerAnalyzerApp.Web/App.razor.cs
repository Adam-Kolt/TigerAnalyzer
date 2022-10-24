using Avalonia.ReactiveUI;
using Avalonia.Web.Blazor;

namespace TigerAnalyzerApp.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        WebAppBuilder.Configure<TigerAnalyzerApp.App>()
            .UseReactiveUI()
            .SetupWithSingleViewLifetime();
    }
}