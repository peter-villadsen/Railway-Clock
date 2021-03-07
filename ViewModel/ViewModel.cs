using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Railroad.Clock.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public static ICommand MaximizeCommand { get; set; }
        public static ICommand MinimizeCommand { get; set; }
        public static ICommand NormalizeCommand { get; set; }
        public static ICommand ExitCommand { get; set; }


        public MainWindow View { get; set; }

        public bool SecondsSweep
        {
            get { return Properties.Settings.Default.SweepSeconds; }
            set
            {
                if (value != Properties.Settings.Default.SweepSeconds)
                {
                    Properties.Settings.Default.SweepSeconds = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondsSweep)));
                }
            }
        }

        public bool MinutesSweep
        {
            get { return Properties.Settings.Default.SweepMinutes; }
            set
            {
                if (value != Properties.Settings.Default.SweepMinutes)
                {
                    Properties.Settings.Default.SweepMinutes = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MinutesSweep)));
                }
            }
        }

        public ViewModel(MainWindow view)
        {
            this.View = view;

            MaximizeCommand = new RelayCommand((_) =>
            {
                this.View.WindowState = WindowState.Maximized;
            });

            MinimizeCommand = new RelayCommand((_) =>
            {
                this.View.WindowState = WindowState.Minimized;
            });

            NormalizeCommand = new RelayCommand((_) =>
            {
                this.View.WindowState = WindowState.Normal;
            });

            ExitCommand = new RelayCommand((_) =>
            {
                App.Current.Shutdown();
            });

            Properties.Settings.Default.PropertyChanged += SettingsChanged;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when any of the properties are changed. We choose to save the 
        /// values every time, so changes survive crashes and unexpected closedowns.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void SettingsChanged(object sender, PropertyChangedEventArgs e)
        {
            // Save all the user's settings
            Properties.Settings.Default.Save();
        }

    }
}
