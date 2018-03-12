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
    
    partial class KursKupnaSprzedazy : Page
    {   
        Data data = new Data();
        bool error = false;
        XmlDocument kurs = new XmlDocument();
        XmlNodeList CurrencyName;
        XmlNodeList listBuyPrice;
        XmlNodeList listSellPrice; 
        XmlNodeList PublicationDate; 

        public KursKupnaSprzedazy()
        {
            CurrencyName = kurs.GetElementsByTagName("nazwa_waluty");
            listBuyPrice = kurs.GetElementsByTagName("kurs_kupna");
            listSellPrice = kurs.GetElementsByTagName("kurs_sprzedazy");
            PublicationDate = kurs.GetElementsByTagName("data_publikacji");
            InitializeComponent();
        }
        
        private void SetData()
        {

            if (!error) kurs.Load(data.NazwaPliku("KKS"));                                                  //ladowanie danych z NBP              
            else kurs.Load(data.filename);            

            SredniKursWalut kursy = new SredniKursWalut();
            update.Text = PublicationDate[0].InnerXml.ToString();

            SetText("buy",kursy, CurrencyName, listBuyPrice);          //ceny kupna
            SetText("sell",kursy, CurrencyName, listSellPrice);        //ceny sprzedazy

            FillList();
        }
        private void SetText(string text, SredniKursWalut kursy,XmlNodeList CurrencyName,XmlNodeList listBuyPrice)
        { switch (text)
            {
                case ("sell"):
                    dolarysell.Text = kursy.search(CurrencyName, listBuyPrice, "dolar amerykański");
                    frankisell.Text = kursy.search(CurrencyName, listBuyPrice, "frank szwajcarski");
                    eurosell.Text = kursy.search(CurrencyName, listBuyPrice, "euro");
                    funtsell.Text = kursy.search(CurrencyName, listBuyPrice, "funt szterling");
                    koronysell.Text = kursy.search(CurrencyName, listBuyPrice, "korona czeska");
                    break;
                case ("buy"):
                    dolarybuy.Text = kursy.search(CurrencyName, listBuyPrice, "dolar amerykański");
                    frankibuy.Text = kursy.search(CurrencyName, listBuyPrice, "frank szwajcarski");
                    eurobuy.Text = kursy.search(CurrencyName, listBuyPrice, "euro");
                    funtbuy.Text = kursy.search(CurrencyName, listBuyPrice, "funt szterling");
                    koronybuy.Text = kursy.search(CurrencyName, listBuyPrice, "korona czeska");
                    break;
            }
            }

        private void BC_Refresh(object sender, RoutedEventArgs e)
        {
            try
            {
                SetData();
            }
            catch
            {
                error = true;
                data.correctDate("KKS");
                SetData();
            }
            }

        private void CurrencyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            int x = CurrencyList.SelectedIndex;
            ListValueKupno.Text = listBuyPrice[x].InnerXml.ToString();
            ListValueSprzedaz.Text = listSellPrice[x].InnerText.ToString();
        }

        public void FillList()
        {
            XmlNodeList elemList = kurs.GetElementsByTagName("nazwa_waluty");
            for (int i = 0; i < elemList.Count; i++)
            {
                CurrencyList.Items.Add(elemList[i].InnerXml.ToString());
            }
        }

    }
        
}
