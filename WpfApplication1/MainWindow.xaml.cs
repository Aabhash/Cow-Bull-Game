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

namespace CBGame
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
            renew();
             
        }

        int loaded, x, history;
        int[] Guessed = new int[4];
        int[] Number = new int[4];
        
        
        Random r = new Random();

        private void renew()
        {
            int[] random = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            loaded = 1;
            x = 0;
            history = 1;
            for (int i = 1; i <= 4; i++)
            {
                int ran = r.Next(1, 9);
                if (random[ran] != 0)
                {
                    random[ran] = 0;
                    Number[i-1] = ran;
                }
                else
                {
                    i--; 
                }
                Label l = (Label)FindName("label" + i );
                l.Content = Number[i-1].ToString(); 
            }  
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            x = 1; 
            Load(x);
            Button1.IsEnabled = false;
        }

        private void Load(int x)
        {
            if(loaded ==1)
            {
                labelDC.Content = "";
            }
            if (loaded <= 5)
            {
                Guessed[loaded-1] = x;
                Image i = (Image)this.FindName("DImage" + loaded);
                var uri = new Uri(@"\WpfApplication1;component\Images\" + x + ".png", UriKind.Relative);
                i.Opacity = 1; 
                i.Source = new BitmapImage(uri);
                loaded++;
                if (loaded == 5)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        Button b = (Button)FindName("Button" + j);
                        b.IsEnabled = false;
                    }
                }
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            x = 2;
            Load(x);
            Button2.IsEnabled = false;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            x = 3;
            Load(x);
            Button3.IsEnabled = false;
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            x = 4;
            Load(x);
            Button4.IsEnabled = false;
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            x = 5;
            Load(x);
            Button5.IsEnabled = false;
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            x = 6;
            Load(x);
            Button6.IsEnabled = false;
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            x = 7;
            Load(x);
            Button7.IsEnabled = false;
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            x = 8;
            Load(x);
            Button8.IsEnabled = false;
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            x = 9;
            Load(x);
            Button9.IsEnabled = false; 
        }

        //Guess Button Computation
        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            if (history <= 6)
            {
                int cow = 0;
                int bull = 0;
                if (loaded == 5)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (Guessed[i] == Number[i])
                        {
                            bull++;
                        }
                        else
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (Guessed[i] == Number[j])
                                {
                                    cow++;
                                }
                            }
                        }
                    }
                    Label la = (Label)FindName("l" + history);
                    la.Content = Guessed[0].ToString() + " " + Guessed[1].ToString() + " " + Guessed[2].ToString() + " " + Guessed[3].ToString() + " - ";
                    labelDC.Content = cow.ToString() + " C    " + bull.ToString() + " B"; 

                    for (int i = 1; i<=bull; i++)
                    {
                        Image IB = (Image)FindName("b" + history + i);
                        IB.Opacity = 1; 
                    }
                    for (int j = 1; j <= cow; j++)
                    {
                        Image IC = (Image)FindName("c" + history + (5-j));
                        IC.Opacity = 1;
                    }
                    if (bull == 4)
                    {
                        BImage1.Opacity = 0;
                        BImage2.Opacity = 0;
                        BImage3.Opacity = 0;
                        BImage4.Opacity = 0;
                        labelDC.Content = "";
                        MessageBox.Show("CONGRATULATIONS, YOU WON!", "Well Done", MessageBoxButton.OK, MessageBoxImage.Information);

                        GuessButton.IsEnabled = false;
                    }
                    else if (history >=6)
                    {
                        BImage1.Opacity = 0;
                        BImage2.Opacity = 0;
                        BImage3.Opacity = 0;
                        BImage4.Opacity = 0;
                        labelDC.Content = "";
                        MessageBox.Show("Game Over!", "Try Again", MessageBoxButton.OK, MessageBoxImage.Stop);
                        GuessButton.IsEnabled = false;

                        for (int j = 1; j <= 9; j++)
                        {
                            Button b = (Button)FindName("Button" + j);
                            b.IsEnabled = false;
                        }
                    }
                    else
                    {
                        history++;
                        ReEnable(); 
                    }
                }
                else
                {
                    MessageBox.Show("Press All Numbers!");
                }
            }
        }

        private void MainGrid_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void ReEnable()
        { 
            for (int j = 1; j <= 9; j++)
            {
                Button b = (Button)FindName("Button" + j);
                b.IsEnabled = true;
            }
            loaded = 1;
            x = 0;
            DImage1.Opacity = 0;
            DImage2.Opacity = 0;
            DImage3.Opacity = 0;
            DImage4.Opacity = 0;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            labelDC.Content = ""; 
            GuessButton.IsEnabled = true; 
            for(int i = 1; i<=6; i++)
            {
                for(int j = 1; j <= 4; j++)
                {
                    Image IB = (Image)FindName("b" + i + j);
                    IB.Opacity = 0;
                    Image IC = (Image)FindName("c" + i + j);
                    IC.Opacity = 0;
                }
                Label la = (Label)FindName("l" + i);
                la.Content = "";
            }
            BImage1.Opacity = 1;
            BImage2.Opacity = 1;
            BImage3.Opacity = 1;
            BImage4.Opacity = 1;
            ReEnable(); 
            renew(); 
        }
    }
}
