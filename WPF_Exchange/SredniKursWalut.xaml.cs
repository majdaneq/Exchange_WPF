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
{   public partial class SredniKursWalut : Page
    {
        

        Data nazwa = new Data();
        public bool error = false;
        public XmlDocument kurs = new XmlDocument();
        
        public SredniKursWalut()
        {
            InitializeComponent();            
        }  

        void GetData()
        {
            try
            {
                if (error == false) kurs.Load(nazwa.NazwaPliku("SKW"));
                else kurs.Load(nazwa.filename);                                            //ladowanie danych z NBP       
            }
            catch
            {
                kurs.Load("http://www.nbp.pl/kursy/xml/a064z180330.xml");
            }

            XmlNodeList elemList = kurs.GetElementsByTagName("nazwa_waluty");
            XmlNodeList elemList2 = kurs.GetElementsByTagName("kurs_sredni");
            XmlNodeList elemList3 = kurs.GetElementsByTagName("data_publikacji");

            dolary.Text = search(elemList, elemList2, "dolar amerykański") + " PLN";
            euro.Text = search(elemList, elemList2, "euro") + " PLN";
            franki.Text = search(elemList, elemList2, "frank szwajcarski") + " PLN";
            funt.Text = search(elemList, elemList2, "funt szterling") + " PLN";
            korony.Text = search(elemList, elemList2, "korona czeska") + " PLN";
            ruble.Text = search(elemList, elemList2, "rubel rosyjski") + " PLN";
            update.Text = elemList3[0].InnerXml.ToString();
            error = false;
        }

        public string search(XmlNodeList currency, XmlNodeList cost, string s_currency)
        {
            for (int i = 0; i < currency.Count; i++)
            {
                if (currency[i].InnerXml.ToString() == s_currency)
                {
                    return cost[i].InnerXml.ToString();
                }
            }
            return "ERROR";
        }

        public void FillList()
        {
            XmlNodeList elemList = kurs.GetElementsByTagName("nazwa_waluty");
            for (int i = 0; i < elemList.Count; i++)
            {
                CurrencyList.Items.Add(elemList[i].InnerXml.ToString());
            }
        }

        private void BC_Refresh(object sender, RoutedEventArgs e)
        {try
            {
                GetData();
                FillList();
            }
            catch                                                       //nie zupdatowana w poniedzalek
            {
                error = true;
                nazwa.correctDate("SKW");
                
                    GetData();
                FillList();
            }   
        }

        private void CurrencyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            XmlNodeList elemList2 = kurs.GetElementsByTagName("kurs_sredni");
            int x = CurrencyList.SelectedIndex;
            List_value.Text = elemList2[x].InnerXml.ToString();
        }
    }
}
