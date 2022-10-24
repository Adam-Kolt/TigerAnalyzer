using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TigerAnalyzerApp.Views;

public partial class StatisticalAnalysisWindow : Window
{
    public StatisticalAnalysisWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}