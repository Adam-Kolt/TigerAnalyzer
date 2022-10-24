using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TigerAnalyzerApp.Views;

public partial class StatisticalAnalysisView : UserControl
{
    public StatisticalAnalysisView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}