using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Exchange
{
    class Data
    {
        public string filename;
        public string numerNotowaniaS = "";
        public Data(){
            dayoy = DateTime.Today.DayOfYear;
            day = DateTime.Today.Day;
            month = DateTime.Today.Month;
            year = DateTime.Today.Year.ToString();
            weekofYear = dayoy / 7;
        }
        ~Data(){ }
        static int dayoy;        
        static int day;
        static int month;
        static string year;
        int weekofYear;
        string dayS;
        string monthS;

        string numerNotowania()
        {
            
            int numerNotowania = 0; 
            if (DateTime.Today.DayOfWeek.ToString() == "Sunday" || DateTime.Today.DayOfWeek.ToString() == "Saturday")     //update tylko w dni robocze 
                numerNotowania = dayoy - weekofYear* 2 - 1;
            else numerNotowania = dayoy - weekofYear* 2;

            numerNotowania = numerNotowania - 1;
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

        public string data()
        {
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
        public void correctDate(string option)
        {            
            int x = Convert.ToInt32(DateTime.Today.Day) - 3;
            string xs = x.ToString();
            xs = xs.Insert(0, "0");
            string nos = DateTime.Today.Day.ToString();
            //nos = nos.Insert(0, "0");
            string newNumNot = filename.Replace(numerNotowaniaS, "049");
            string NewDay = filename.Replace(nos, xs);
                switch (option)
            {
                case "SKW": filename = "http://www.nbp.pl/kursy/xml/a" + "049" + "z" + year+monthS+xs + ".xml"; break;
                case "KKS": filename = "http://www.nbp.pl/kursy/xml/c" + "049" + "z" + year + monthS + xs + ".xml"; break;

            }
            
        }
        public string NazwaPliku(string name)
        {   switch(name)
            {
                case "SKW": filename = "http://www.nbp.pl/kursy/xml/a" + numerNotowania() + "z" + data() + ".xml"; return filename;
                case "KKS": filename = "http://www.nbp.pl/kursy/xml/c" + numerNotowania() + "z" + data() + ".xml"; return filename;
            }  
            return filename;
        }
       
                
    }
}



    

