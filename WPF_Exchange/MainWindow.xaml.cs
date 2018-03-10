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

        void GetData()
        {        
                XmlDocument kurs = new XmlDocument();
                kurs.Load("http://www.nbp.pl/kursy/xml/a049z180309.xml");   //ladowanie danych z NBP

                XmlNodeList elemList = kurs.GetElementsByTagName("nazwa_waluty");
                XmlElement elemList3 = kurs.GetElementById("forint (Węgry)");
                XmlNodeList elemList2 = kurs.GetElementsByTagName("kurs_sredni");
            
            dolary.Text = search(elemList, elemList2,"dolar amerykański") + " PLN";
            euro.Text = search(elemList, elemList2, "euro") + " PLN";
            franki.Text = search(elemList, elemList2, "frank szwajcarski") + " PLN";
            funt.Text = search(elemList, elemList2, "funt szterling") + " PLN";
            korony.Text = search(elemList, elemList2, "korona czeska") + " PLN";
            ruble.Text = search(elemList, elemList2, "rubel rosyjski") + " PLN";
          
        }

        string search(XmlNodeList listwaluta,XmlNodeList kurs, string waluta)
        {
            for (int i = 0; i < listwaluta.Count; i++)
            {
                if (listwaluta[i].InnerXml.ToString() == waluta)
                {                     
                    return kurs[i].InnerXml.ToString();
                }   
            }
            return "ERROR";
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }
    }

}


