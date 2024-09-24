using FallDetection.WPF.Common;
using FallDetection.WPF.Models;
using FallDetection.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FallDetection.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly DetectionRepository _detectionRepository;
        public MainWindowViewModel() {
            _detectionRepository = new DetectionRepository();
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
            DetectionModelList.Clear();
            foreach (var result in results)
            {
                DetectionModelList.Add(result);
            }
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
