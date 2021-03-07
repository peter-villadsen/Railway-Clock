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
    }
}