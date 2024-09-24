using System.Windows;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Collections.Generic;
using FallDetection.WPF.Models;
using FallDetection.WPF.ViewModels;
using System.Windows.Media;

namespace FallDetection.WPF.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);

            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.Position = new PointLatLng(-31.9934926, 115.8032324);
            MainMap.MinZoom = 2;
            MainMap.MaxZoom = 17;
            MainMap.Zoom = 11;
            MainMap.ShowCenter = false;
            MainMap.CanDragMap = true;
            MainMap.IsManipulationEnabled = true;
        }

        public void AddMarker(double lat, double lng, string toolTipText)
        {
            GMapMarker marker = new GMapMarker(new PointLatLng(lat, lng))
            {
                Shape = new System.Windows.Controls.Label
                {
                    Content = toolTipText,
                    Foreground = Brushes.White,
                    Background = Brushes.IndianRed
                }
            };
            MainMap.Markers.Add(marker);
        }

        public void ClearMarkers()
        {
            MainMap.Markers.Clear();
        }

        public void AddMarkers(IEnumerable<DetectionModel> detections)
        {
            ClearMarkers(); // 清除旧的标记

            foreach (var detection in detections)
            {
                double latitude;
                double longitude;

                if (double.TryParse(detection.Latitude, out latitude) &&
                    double.TryParse(detection.Longitude, out longitude))
                {
                    AddMarker(latitude, longitude, detection.Name);
                }
            }
        }
    }
}
