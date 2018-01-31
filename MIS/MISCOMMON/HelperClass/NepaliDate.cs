using System;

namespace MISCOMMON.HelperClass
{

    /// <summary>
    /// NepaliDate - data object class
    /// </summary>
    public class NepaliDate
    {
        
        private string _nepaliDate;

        /// <summary>
        /// String representation of Nepali Date. Format yyyy/m/d
        /// </summary>

        public static string GetNepaliDayOfWeek(DayOfWeek DayOfWeek)
        {
            switch(DayOfWeek)
            {
                case DayOfWeek.Sunday: return "आइतबार"; break;
                case DayOfWeek.Monday: return "सोमबार"; break;
                case DayOfWeek.Tuesday: return "मंगलबार"; break;
                case DayOfWeek.Wednesday: return "बुधबार"; break;
                case DayOfWeek.Thursday: return "बिहीबार"; break;
                case DayOfWeek.Friday: return "शुक्रबार"; break;
                case DayOfWeek.Saturday: return "सनिबार"; break;
                default: return "invalid";

            }
          
        }


        public NepaliDate()
        {

        }
        public NepaliDate(string DateString)
        {
           String[] fields = DateString.Split("[ -\\/]".ToCharArray(),3);
           _npYear = int.Parse(fields[0]);
           _npMonth = int.Parse(fields[1]);
           _npDay = int.Parse(fields[2]);

        }

        public NepaliDate(int Year, int Month, int Day)
        {
            _npYear = Year;
            _npMonth = Month;
            _npDay = Day;
        }

        public string npDate
        {
            get 
            {
                _nepaliDate = String.Format("{0}/{1}/{2}", _npYear, _npMonth, _npDay);
                return _nepaliDate; 
            }
            set { _nepaliDate = value; }
        }

        private int _npDaysInMonth;

        /// <summary>
        /// DaysInMonth of Nepali date
        /// </summary>
        public int npDaysInMonth
        {
            get { return _npDaysInMonth; }
            set { _npDaysInMonth = value; }
        }

        private int _npYear;

        /// <summary>
        /// Numeric Year of Nepali date
        /// </summary>
        public int npYear
        {
            get { return _npYear; }
            set { _npYear = value; }
        }

        private int _npMonth;

        /// <summary>
        /// Numeric Month of Nepali date
        /// </summary>
        public int npMonth
        {
            get { return _npMonth; }
            set { _npMonth = value; }
        }

        private int _npDay;
        private string longDateEng;
        private string longDateNep;
        private string monthNameEng;
        private string monthNameNep;
        /// <summary>
        /// Numeric Day of Nepali date
        /// </summary>
        public int npDay
        {
            get { return _npDay; }
            set { _npDay = value; }
        }

        public string LongDateStringEng
        {
            get
            {
               switch(npMonth)
               {
                   case 1:
                       monthNameEng = "Baisakh";
                       break;
                   case 2:
                       monthNameEng = "Jestha";
                       break;
                 
                   case 3:
                       monthNameEng = "Aashad";
                       break;
                   case 4:
                       monthNameEng = "Shrawan";
                       break;
                   case 5:
                       monthNameEng = "Bhadra";
                       break;
                   case 6:
                       monthNameEng = "Aasoj";
                       break;
                   case 7:
                       monthNameEng = "Kartik";
                       break;
                   case 8:
                       monthNameEng = "Mangsir";
                       break;
                   case 9:
                       monthNameEng = "Poush";
                       break;
                   case 10:
                       monthNameEng = "Magh";
                       break;
                   case 11:
                       monthNameEng = "Falgun";
                       break;
                   case 12:
                       monthNameEng = "Chaitra";
                       break;

               }
               return (string.Format("{0} {1} {2}", monthNameEng, npDay.ToString(), npYear.ToString()));

                   
            }
        }

        public string LongDateStringNep
        {
            get
            {
                switch (npMonth)
                {
                    case 1:
                        monthNameNep = "वैशाख";
                        break;
                    case 2:
                        monthNameNep = "जेठ";
                        break;

                    case 3:
                        monthNameNep = "असार";
                        break;
                    case 4:
                        monthNameNep = "श्रावण";
                        break;
                    case 5:
                        monthNameNep = "भदौ";
                        break;
                    case 6:
                        monthNameNep = "आशोज";
                        break;
                    case 7:
                        monthNameNep = "कार्तिक";
                        break;
                    case 8:
                        monthNameNep = "मंसिर";
                        break;
                    case 9:
                        monthNameNep = "पुष";
                        break;
                    case 10:
                        monthNameNep = "माघ";
                        break;
                    case 11:
                        monthNameNep = "फाल्गुण";
                        break;
                    case 12:
                        monthNameNep = "चैत";
                        break;

                }
                return (string.Format("{0} {1} {2}", monthNameNep, npDay.ToString(), npYear.ToString()));


            }
        }
    }
}
