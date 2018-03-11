using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WPF_Exchange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        short active=0;

        public MainWindow()
        {
            InitializeComponent();            
        }        

        public void InfoButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wykonał Szymon Bortel");
        }

        private void BC_SredniKurs(object sender, RoutedEventArgs e)
        {
            if (checkPage(active, 1))
            {
                FrameMain.Content = new SredniKursWalut();
                SetBgButtons(1);
                active = 1;
            }  
        }

        private void BC_KursKupSprzed(object sender, RoutedEventArgs e)
        {
            if (checkPage(active, 2))
            {
                FrameMain.Content = new KursKupnaSprzedazy();
                SetBgButtons(2);
                active = 2;
            } 
        }

        private void BC_KalkulatorWalut(object sender, RoutedEventArgs e)
        {
            if (checkPage(active, 3))
            {
                active = 3;
                FrameMain.Content = new KalkulatorWalut();
                SetBgButtons(3);
            }
        }

        private void BC_Historia(object sender, RoutedEventArgs e)
        {
            if (checkPage(active, 4))
            {
                active = 4;
                FrameMain.Content = new Historia();
                SetBgButtons(4);
            }
        }       

        void SetBgButtons(int choice)                                               //ustawianie koloru pozostałych buttonów na defaultowy, gdy 1 opcja wybrana
        {
            switch (choice)
            {
                case 1:
                    ButtSredniKurs.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    ButtKursKupnoSprzed.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtKalkulator.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtHis.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    break;
                case 2:
                    ButtSredniKurs.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtKursKupnoSprzed.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    ButtKalkulator.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtHis.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    break;
                case 3:
                    ButtSredniKurs.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtKursKupnoSprzed.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtKalkulator.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    ButtHis.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    break;
                case 4:
                    ButtSredniKurs.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtKursKupnoSprzed.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtKalkulator.Background = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    ButtHis.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    break;
            }
        }

        bool checkPage(int prev,int act)
        {
            if (prev == act)
            {
                MessageBox.Show("Już wybrałeś tę kartę!");
                return false;
            }
            else return true;
        }
    }

}


