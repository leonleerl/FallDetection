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

            // 设置 GMapControl 的地图提供者
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.Position = new PointLatLng(-31.9934926, 115.8032324);
            MainMap.MinZoom = 2;
            MainMap.MaxZoom = 17;
            MainMap.Zoom = 5;
            MainMap.CanDragMap = true;
        }

        // 在地图上添加标记
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

        // 清除所有标记
        public void ClearMarkers()
        {
            MainMap.Markers.Clear();
        }

        // 在地图上添加多个标记
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
