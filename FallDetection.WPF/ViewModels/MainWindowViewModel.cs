using FallDetection.WPF.Common;
using FallDetection.WPF.Models;
using FallDetection.WPF.Repositories;
using FallDetection.WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace FallDetection.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly DetectionRepository _detectionRepository;
        private MainWindow _mainWindow;
        
        public MainWindowViewModel(MainWindow mainWindow) {
            _detectionRepository = new DetectionRepository();
            _mainWindow = mainWindow;
        }


        public BaseCommand Command_Fun
        {
            get { return new BaseCommand(Command_Fun_Executed); }
        }

        private void Command_Fun_Executed(object obj)
        {
            string str = obj.ToString();
            switch (str)
            {
                case "Search":
                    DoSearch();
                    break;

            }
        }

        private async void DoSearch()
        {
            IEnumerable<DetectionModel> results;
            if (SearchName == null || SearchName == string.Empty)
            { 
                results = await _detectionRepository.GetAllAsync();
            }
            else
            {
                results = await _detectionRepository.GetByNameAsync(SearchName);
            }
            // 更新列表和地图标记
            DetectionModelList.Clear();
            foreach (var result in results)
            {
                DetectionModelList.Add(result);
            }

            // 将标记添加到地图上
            _mainWindow.AddMarkers(results);
        }

        private ObservableCollection<DetectionModel> _detectionModelList = new ObservableCollection<DetectionModel>();
        private string _searchName = "";
        public ObservableCollection<DetectionModel> DetectionModelList
        {
            get { return _detectionModelList; }
            set
            {
                if (value != null)
                {
                    onPropertyChanged(nameof(_detectionModelList));
                }
            }
        }
        public string SearchName
        {
            get { return _searchName; }
            set
            {
                if (value != null)
                {
                    onPropertyChanged(nameof(_searchName));
                }
            }
        }
    }
}
