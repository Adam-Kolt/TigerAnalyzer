using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using TigerAnalyzerApp.ViewModels;

namespace TigerAnalyzerApp.Views
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private async Task<string> GetData()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filters.Add(new FileDialogFilter() { Extensions = {"csv"}});

            string[]? dataPath = await fileDialog.ShowAsync(this);

            return String.Join("", dataPath);
        }
        
        public void GetFilePath()
        {
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}