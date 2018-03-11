using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Exchange
{
    class Data : SredniKursWalut
    {
        public Data()
        { }
        ~Data()
        { }
        static int dayoy = DateTime.Today.DayOfYear;
        int weekofYear = dayoy / 7;
        static int day = DateTime.Today.Day;
        static int month = DateTime.Today.Month;
        static string year = DateTime.Today.Year.ToString();
        string numerNotowania()
        {
            int numerNotowania = 0;
            string numerNotowaniaS="";

            if (DateTime.Today.DayOfWeek.ToString() == "Sunday" || DateTime.Today.DayOfWeek.ToString() == "Saturday")     //w sobote i niedziele nie ma updatów kursów
                numerNotowania = dayoy - weekofYear* 2 - 1;
            else numerNotowania = dayoy - weekofYear* 2;                                                   //kompletny numer notowania

            if (numerNotowania< 100 && numerNotowania >= 10)
            {
                numerNotowaniaS = numerNotowania.ToString();
                numerNotowaniaS = numerNotowaniaS.Insert(0, "0");
                return numerNotowaniaS;
            }

            if (numerNotowania< 10)
            {
                numerNotowaniaS = numerNotowania.ToString();
                numerNotowaniaS = numerNotowaniaS.Insert(0, "00");
                return numerNotowaniaS;
            }

            return numerNotowaniaS;
        }
        string data()
        {
            string dayS;
            string monthS;

            if (DateTime.Today.DayOfWeek.ToString() == "Sunday") day = day - 2;
            if (DateTime.Today.DayOfWeek.ToString() == "Saturday") day = day - 1;

            if (day < 10)                                                                                   //ustalanie daty zeby byla zgodna z formatem wejsciowym
                {
                    dayS = day.ToString();
                    dayS = dayS.Insert(0, "0");
                }
            else dayS = day.ToString();

            if (month < 10)
                {
                    monthS = month.ToString();
                    monthS = monthS.Insert(0, "0");
                }
            else monthS = month.ToString();

            year = year.Substring(2);

            return year + monthS + dayS;
        }
        public string NazwaPliku()
        {
            string filename = "http://www.nbp.pl/kursy/xml/a" + numerNotowania() + "z" +data() + ".xml";
            return filename;
        }
                
}
}



    

