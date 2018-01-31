using System;
using System.Data;
using System.Linq;

namespace MISCOMMON.HelperClass
{

    /// <summary>
    /// Summary description for UnicodeConverter
    /// </summary>
    public static class UnicodeConverter
    {
        public static Byte ToByte(string strUnicode)
        {
            Byte valByte = 0;
            int valInt = 0;
            string uniNumberChar = "०१२३४५६७८९";
            bool checkFlag = false;
            if (strUnicode != String.Empty)
            {
                try
                {
                    for (int i = 0; i < strUnicode.Length; i++)
                    {
                        checkFlag = false;
                        for (int j = 0; j < uniNumberChar.Length; j++)
                        {
                            if (strUnicode[i] == uniNumberChar[j])
                            {
                                valInt = (valInt * 10) + j;
                                checkFlag = true;
                                break;
                            }
                        }
                        if (checkFlag == false)
                        {
                            valInt = 0;
                            break;
                        }
                    }
                    valByte = Convert.ToByte(valInt);
                }
                catch
                { valByte = 0; }
            }
            return valByte;
        }

        public static Int32 ToInt32(string strUnicode)
        {
            bool hasUnicode;

            Int32 valInt32 = 0;
            string uniNumberChar = "०१२३४५६७८९";
            bool checkFlag = false;

            hasUnicode = ContainsUnicodeCharacter(strUnicode);

            if (hasUnicode == false)
            {

                return Int32.Parse(strUnicode);
            }

            else
            {

                if (strUnicode != String.Empty)
                {
                    try
                    {
                        for (int i = 0; i < strUnicode.Length; i++)
                        {
                            checkFlag = false;
                            for (int j = 0; j < uniNumberChar.Length; j++)
                            {
                                if (strUnicode[i] == uniNumberChar[j])
                                {
                                    valInt32 = (valInt32 * 10) + j;
                                    checkFlag = true;
                                    break;
                                }
                            }
                            if (checkFlag == false)
                            {
                                valInt32 = 0;
                                break;
                            }
                        }
                    }
                    catch
                    { valInt32 = 0; }
                }
                return valInt32;
            }
        }

        public static Int64 ToInt64(string strUnicode)
        {
            Int64 valInt64 = 0;
            string uniNumberChar = "०१२३४५६७८९";
            bool checkFlag = false;
            if (strUnicode != String.Empty)
            {
                try
                {
                    for (int i = 0; i < strUnicode.Length; i++)
                    {
                        checkFlag = false;
                        for (int j = 0; j < uniNumberChar.Length; j++)
                        {
                            if (strUnicode[i] == uniNumberChar[j])
                            {
                                valInt64 = (valInt64 * 10) + j;
                                checkFlag = true;
                                break;
                            }
                        }
                        if (checkFlag == false)
                        {
                            valInt64 = 0;
                            break;
                        }
                    }
                }
                catch
                { valInt64 = 0; }
            }
            return valInt64;
        }

        public static Decimal ToDecimal(string strUnicode)
        {
            string uniDecimalChar = "०१२३४५६७८९";
            string decimalChar = "0123456789";
            bool checkFlag = false;
            string strDecimal = "0";
            Decimal decimalVal = 0;
            if (!string.IsNullOrEmpty(strUnicode))
            {
                try
                {
                    for (int i = 0; i < strUnicode.Length; i++)
                    {
                        checkFlag = false;
                        for (int j = 0; j < uniDecimalChar.Length; j++)
                        {
                            if (strUnicode[i] == '.')
                            {
                                strDecimal += '.';
                                checkFlag = true;
                                break;
                            }
                            else if (strUnicode[i] == ',')
                            {
                                strDecimal += ',';
                                checkFlag = true;
                                break;
                            }
                            else if (strUnicode[i] == '/')
                            {
                                strDecimal += '/';
                                checkFlag = true;
                                break;
                            }
                            else if (strUnicode[i] == uniDecimalChar[j] || strUnicode[i] == decimalChar[j])
                            {
                                strDecimal += j;
                                checkFlag = true;
                                break;
                            }
                        }
                        if (checkFlag == false)
                        {
                            strDecimal = "0";
                            break;
                        }
                    }
                    decimalVal = Decimal.Parse(Convert.ToDecimal(strDecimal).ToString("#.##"));
                }
                catch
                { decimalVal = 0; }
            }
            return decimalVal;
        }

        public static Decimal ToDecimalCheck(string strUnicode)
        {
            string uniDecimalChar = "०१२३४५६७८९";
            bool checkFlag = false;
            string strDecimal = "0";
            Decimal decimalVal = 0;
            if (strUnicode != String.Empty)
            {
                try
                {
                    for (int i = 0; i < strUnicode.Length; i++)
                    {
                        checkFlag = false;
                        for (int j = 0; j < uniDecimalChar.Length; j++)
                        {
                            if (strUnicode[i] == '.')
                            {
                                strDecimal += '.';
                                checkFlag = true;
                                break;
                            }
                            else if (strUnicode[i] == ',')
                            {
                                strDecimal += ',';
                                checkFlag = true;
                                break;
                            }
                            else if (strUnicode[i] == uniDecimalChar[j])
                            {
                                strDecimal += j;
                                checkFlag = true;
                                break;
                            }
                        }
                        if (checkFlag == false)
                        {
                            strDecimal = "-1";
                            break;
                        }
                    }
                    decimalVal = Decimal.Parse(Convert.ToDecimal(strDecimal).ToString("#.##"));
                }
                catch
                { decimalVal = -1; }
            }
            return decimalVal;
        }
        public static string ToText(string strUnicode)
        {
            //DateConversion dateConversion = new DateConversion();
            bool hasUnicode;
            string uniDateChar = "०१२३४५६७८९-";
            string ascDateChar = "0123456789-";
            bool checkFlag = false;
            string valDate = "";
            string valDateTime = null;

            hasUnicode = ContainsUnicodeCharacter(strUnicode);

            if (hasUnicode == false)
            {

                return strUnicode;
            }

            else
            {

                if (strUnicode != String.Empty)
                {
                    try
                    {
                        for (int i = 0; i < strUnicode.Length; i++)
                        {
                            checkFlag = false;
                            string a = "'";
                            char b = a[0];
                            for (int j = 0; j < uniDateChar.Length; j++)
                            {
                                if (strUnicode[i] == uniDateChar[j] || strUnicode[i] == ascDateChar[j])
                                {
                                    valDate = valDate + ascDateChar[j];
                                    
                                    checkFlag = true;
                                    break;
                                }
                                 if(strUnicode[i]==',')
                                {
                                    valDate = valDate + ",";
                                     break;
                                }
                                 if (strUnicode[i] ==b)
                                 {
                                     valDate = valDate + "'";
                                     break;
                                 }
                            }
                        }
                        if (valDate != "" && checkFlag == true)
                            valDateTime = valDate;
                    }
                    catch
                    { valDateTime = null; }
                }
                return valDateTime;
            }
        }

        public static string ToDate(string strUnicode)
        {
            //DateConversion dateConversion = new DateConversion();
            bool hasUnicode;
            string uniDateChar = "०१२३४५६७८९-";
            string ascDateChar = "0123456789-";
            bool checkFlag = false;
            string valDate = "";
            string valDateTime = null;

            hasUnicode = ContainsUnicodeCharacter(strUnicode);

            if (hasUnicode == false)
            {

                return strUnicode;
            }

            else
            {

                if (strUnicode != String.Empty)
                {
                    try
                    {
                        for (int i = 0; i < strUnicode.Length; i++)
                        {
                            checkFlag = false;
                            for (int j = 0; j < uniDateChar.Length; j++)
                            {
                                if (strUnicode[i] == uniDateChar[j] || strUnicode[i] == ascDateChar[j])
                                {
                                    valDate = valDate + ascDateChar[j];
                                    checkFlag = true;
                                    break;
                                }
                            }
                            if (checkFlag == false)
                            {
                                valDate = "";
                                break;
                            }
                        }
                        if (valDate != "" && checkFlag == true)
                            valDateTime = valDate;
                    }
                    catch
                    { valDateTime = null; }
                }
                return valDateTime;
            }
        }

        public static DataTable ConvertTableToUnicode(DataTable dt)
        {
            DataTable dtCloned = dt.Clone();
            int col = 0;
            col = dt.Columns.Count;
            int j = 0;
            for (int i = 0; i < dt.Columns.Count;i++ )
            {
                dtCloned.Columns[i].DataType = typeof(string);
            }
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow drNew = dtCloned.NewRow();
                    dtCloned.Rows.Add(drNew);
                    for (int i = 0; i < col; i++)
                    {
                        if (!ContainsAlphabetCharacter(dr[i].ToString()))
                        {
                            
                            if (!ContainsUnicodeCharacter(dr[i].ToString()) && dtCloned.Columns[i].ColumnName!="salary_id")
                            {
                                dtCloned.Rows[j][i] = UnicodeConverter.ToUnicodeNumber(dr[i].ToString());
                            }
                            else
                            {
                                dtCloned.Rows[j][i] = dr[i].ToString();
                            }
                        }
                        else
                        {
                            dtCloned.Rows[j][i] = dr[i].ToString();
                        }
                    }
                    j = j + 1;
                }
                return dtCloned;
        }

        public static String ToUnicodeDate(string strDateCode)
        {
            string strDateVal = "";
            string uniNumberChar = "-०१२३४५६७८९";
            string strNumberChar = "-0123456789";
            bool checkFlag = false;
            if (strDateCode != String.Empty)
            {
                for (int i = 0; i < strDateCode.Length; i++)
                {
                    checkFlag = false;
                    for (int j = 0; j < strNumberChar.Length; j++)
                    {
                        if (strDateCode[i] == strNumberChar[j])
                        {
                            strDateVal += uniNumberChar[j];
                            checkFlag = true;
                            break;
                        }
                    }
                    if (checkFlag == false)
                    {
                        strDateVal = "";
                        break;
                    }
                }
            }
            return strDateVal;
        }

        public static String ToUnicodeNumber(string strDateCode)
        {
            string strDateVal = "";
            string uniNumberChar = "-,०१२३४५६७८९. ";
            string strNumberChar = "-,0123456789. ";
            bool checkFlag = false;
            if (strDateCode != String.Empty)
            {
                for (int i = 0; i < strDateCode.Length; i++)
                {
                    checkFlag = false;
                    for (int j = 0; j < strNumberChar.Length; j++)
                    {
                        if (strDateCode[i] == strNumberChar[j])
                        {
                            strDateVal += uniNumberChar[j];
                            checkFlag = true;
                            break;
                        }
                    }
                    if (checkFlag == false)
                    {
                        strDateVal = "";
                        break;
                    }
                }
            }
            return strDateVal;
        }


        public static bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.ToCharArray().Any(c => c > MaxAnsiCode);
        }
        public static bool ContainsAlphabetCharacter(string input)
        {
            const int MaxAnsiCode = 90;
            const int MinAsciiCode = 65;
            
            return input.ToUpper().ToCharArray().Any(c => c < MaxAnsiCode && c>MinAsciiCode);
        }
    }
}
