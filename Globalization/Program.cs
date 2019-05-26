using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globalization
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>
            {
                "en-EN",
                "de-DE",
                "fr-FR",
                "ru-RU",
                "ar-AR",
                "pl-PL"
            };
            foreach(var elem in list)
            {
                CultureInfo es = new CultureInfo(elem, false);
                GetWeekDaysByCulture(es);
                GetMonthNamesByCulture(es);
                Console.WriteLine(DateTime.Now.ToString(es));
                Console.WriteLine();
            }
        }

        public static void GetWeekDaysByCulture(CultureInfo culture)
        {
            string str = "";
            str += String.Format("{0} ({1}), ", 
                culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Monday), 
                culture.DateTimeFormat.GetDayName(DayOfWeek.Monday));
            str += String.Format("{0} ({1}), ",
                culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Tuesday),
                culture.DateTimeFormat.GetDayName(DayOfWeek.Tuesday));
            str += String.Format("{0} ({1}), ",
                culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Wednesday),
                culture.DateTimeFormat.GetDayName(DayOfWeek.Wednesday));
            str += String.Format("{0} ({1}), ",
                culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Thursday),
                culture.DateTimeFormat.GetDayName(DayOfWeek.Thursday));
            str += String.Format("{0} ({1}), ",
                culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Friday),
                culture.DateTimeFormat.GetDayName(DayOfWeek.Friday));
            str += String.Format("{0} ({1}), ",
                culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Saturday),
                culture.DateTimeFormat.GetDayName(DayOfWeek.Saturday));
            str += String.Format("{0} ({1}), ",
                culture.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.Sunday),
                culture.DateTimeFormat.GetDayName(DayOfWeek.Sunday));
            Console.WriteLine(str);
        }

        public static void GetMonthNamesByCulture(CultureInfo culture)
        {
            string str = "";
            foreach(int i in Enumerable.Range(1,12))
            {
                str += String.Format("{0} ({1}), ",
                culture.DateTimeFormat.GetAbbreviatedMonthName(i),
                culture.DateTimeFormat.GetMonthName(i));
            }

            Console.WriteLine(str);

        }
    }


}
