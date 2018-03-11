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
    /// Interaction logic for KursKupnaSprzedazy.xaml
    /// </summary>
    public partial class KursKupnaSprzedazy : Page
    {
        public KursKupnaSprzedazy()
        {
            InitializeComponent();
        }

        XmlDocument kurs = new XmlDocument();
        private void SetData()
        {
            Data data = new Data();
            kurs.Load(data.NazwaPlikuKKS());                                                  //ladowanie danych z NBP       
            XmlNodeList CurrencyName = kurs.GetElementsByTagName("nazwa_waluty");
            XmlNodeList listBuyPrice = kurs.GetElementsByTagName("kurs_kupna");
            XmlNodeList listSellPrice = kurs.GetElementsByTagName("kurs_sprzedazy");
            XmlNodeList PublicationDate = kurs.GetElementsByTagName("data_publikacji");

            SredniKursWalut kursy = new SredniKursWalut();

            dolarysell.Text = kursy.search(CurrencyName, listBuyPrice, "dolar amerykański");
        }

        private void BC_Refresh(object sender, RoutedEventArgs e)
        {
            SetData();
        }

        private void CurrencyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
