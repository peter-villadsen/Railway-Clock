using System;

namespace Railroad.Clock
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.DataContext = new ViewModel.ViewModel(this);

            InitializeComponent();
        }

        private void OnLeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Clock_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            const int factor = 25;
            if (e.Delta < 0)
            {
                // Decrease size
                if (this.Width > 100)
                {
                    this.Width -= factor;
                    this.Height -= factor;
                }
            }
            else
            {
                // Increase size
                this.Width += factor;
                this.Height += factor;
            }
        }

        private void SelectStyle(string name)
        {
            var resourceKey = new ComponentResourceKey(typeof(ClockControl), name);
            var style = Application.Current.TryFindResource(resourceKey) as Style;
            this.Clock.Style = style;
        }

        private void DanishDesign_Click(object sender, RoutedEventArgs e)
        {
            SelectStyle("ClockStyleDanishDesign");
        }

        private void SwissRailway_Click(object sender, RoutedEventArgs e)
        {
            SelectStyle("ClockStyleOffice");
        }
    }
}