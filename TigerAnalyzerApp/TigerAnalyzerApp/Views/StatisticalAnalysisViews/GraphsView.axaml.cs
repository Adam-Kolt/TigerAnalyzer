using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TigerAnalyzerApp.Views.StatisticalAnalysisViews;

public partial class GraphsView : UserControl
{
    public GraphsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}