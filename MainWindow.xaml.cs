using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace Railroad.Clock
{
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ICommand MaximizeCommand { get; set; }
        public static ICommand MinimizeCommand { get; set; }
        public static ICommand NormalizeCommand { get; set; }
        public static ICommand ExitCommand { get; set; }

        public bool SecondsSweep
        {
            get { return !this.Clock.IsDiscrete; }
            set { this.Clock.IsDiscrete = !value; }
        }

        public bool MinutesSweep
        {
            get { return this.Clock.IsMinuteSweepMode; }
            set { this.Clock.IsMinuteSweepMode = value; }
        }

        public MainWindow()
        {
            MaximizeCommand = new RelayCommand((_) =>
            {
                this.WindowState = WindowState.Maximized;
            });

            MinimizeCommand = new RelayCommand((_) =>
            {
                this.WindowState = WindowState.Minimized;
            });

            NormalizeCommand = new RelayCommand((_) =>
            {
                this.WindowState = WindowState.Normal;
            });

            ExitCommand = new RelayCommand((_) =>
            {
                App.Current.Shutdown();
            });

            this.DataContext = this;

            InitializeComponent();

            this.SecondsSweep = true;
            this.MinutesSweep = false;
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
    }
}