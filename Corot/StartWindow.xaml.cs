using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Corot
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void StartGame_MouseEnter(object sender, MouseEventArgs e)
        {
            StartButton.Opacity = 1;
        }

        private void StartGame_MouseLeave(object sender, MouseEventArgs e)
        {
            StartButton.Opacity = 0.7;
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitButton.Opacity = 1;
        }

        private void Exit_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitButton.Opacity = 0.7;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
