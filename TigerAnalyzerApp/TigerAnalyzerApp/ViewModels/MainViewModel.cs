using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using TigerAnalyzerApp.Views;


namespace TigerAnalyzerApp.ViewModels
{
    
    public class MainViewModel : ViewModelBase
    {

        private string? _DataPath;
        public string? DataPath
        {
            get => _DataPath;
            set
            {
                _DataPath = value;
            }
        }

        public string DataButtonLabel
        {
            get
            {
                if (string.IsNullOrEmpty(DataPath))
                {
                    return "DATA";
                }
                else
                {
                    return DataPath;
                }
            }
        }

        private async Task<string> GetData(Window window)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filters.Add(new FileDialogFilter() { Extensions = {"csv"}});

            string[]? dataPath = await fileDialog.ShowAsync(window);

            return String.Join("", dataPath);
        }
        public async void DataButton_Clicked(Window window)
        {
            _DataPath = await GetData(window);
            

        }

        public async void EnterButton_Clicked(Window window)
        {
            var statisticsScreen = new StatisticalAnalysisWindow();
            statisticsScreen.DataContext = new StatisticAnalysisViewModel(_DataPath);

            await statisticsScreen.ShowDialog(window);
        }
     }
}