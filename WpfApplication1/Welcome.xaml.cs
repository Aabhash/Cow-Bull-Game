using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
           // PlaySound();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
           MainWindow w = new MainWindow();
            this.Close();
            w.Show();
        }


        private void MainWindowSound_MediaOpened(object sender, RoutedEventArgs e)
        {

        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            
        }

        private void Image_GotMouseCapture(object sender, MouseEventArgs e)
        {
            
            
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            
            BullRules.Opacity=1;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            BullRules.Opacity = 0;
        }

        private void Image_MouseEnter_1(object sender, MouseEventArgs e)
        {
            CowRules.Opacity = 1;
        }

        private void Image_MouseLeave_1(object sender, MouseEventArgs e)
        {
            CowRules.Opacity = 0;
        }

        private void Image_ImageFailed_1(object sender, ExceptionRoutedEventArgs e)
        {

        }
        private void PlaySound()
        {
            //this.MainWindowSound.Position = new TimeSpan(0, 0, 0, 5);
            //this.MainWindowSound.Play();
        }

    }
}
