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
            FrameMain.Content = new SredniKursWalut();
            ButtSredniKurs.Background=new SolidColorBrush(Color.FromRgb(0,0,0));
        }
        private void BC_KursKupSprzed(object sender, RoutedEventArgs e)
        {
            FrameMain.Content = new KursKupnaSprzedazy();
        }

        private void BC_KalkulatorWalut(object sender, RoutedEventArgs e)
        {
            FrameMain.Content = new KalkulatorWalut();
        }

        private void BC_Historia(object sender, RoutedEventArgs e)
        {
            FrameMain.Content = new Historia();
        }

        private void Kliku(object sender, RoutedEventArgs e)
        {          
            
        }
    }

}


