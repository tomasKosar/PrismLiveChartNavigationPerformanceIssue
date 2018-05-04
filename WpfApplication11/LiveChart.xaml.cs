using System;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for LiveChart.xaml
    /// </summary>
    public partial class LiveChart : UserControl
    {
        private Timer timer;

        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels { get; set; }

        public LiveChart()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> {0, -18, 10, 28},
                    Fill = Brushes.Transparent,
                },
            };

            Labels = new[] { "1", "2", "3", "4" };

            DataContext = this;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (timer == null)
            {
                timer = new Timer() { Interval = 100 };
                timer.Elapsed += timer_Elapsed;
                timer.Start();
                this.CartesianChart.Visibility = Visibility.Visible;
            }
            else
            {
                timer.Stop();
                timer.Elapsed -= timer_Elapsed;
                timer = null;
                this.CartesianChart.Visibility = Visibility.Collapsed;
            }
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var result1 = rand.Next(-10, 20);
            var result2 = rand.Next(-10, 20);
            var result3 = rand.Next(-10, 20);
            var result4 = rand.Next(-10, 20);

            this.Dispatcher.BeginInvoke((Action) (() =>
            {
                SeriesCollection.FirstOrDefault().Values = new ChartValues<double> { 0 + result1, -18 + result2, 10 + result3, 28 + result4};

            }));
        }
    }
}
