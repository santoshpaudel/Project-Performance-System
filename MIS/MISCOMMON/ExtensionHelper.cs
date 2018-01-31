using System;


namespace Common
{
    public static class ExtensionHelper
    {
        public static string ToText(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return string.Empty;
            else
                return obj.ToString();
        }

        public static Int16 ToInt16(this object obj)
        {
            Int16 result = 0;
            Int16.TryParse(obj.ToText(), out result);
            return result;
        }

        public static Int64 ToInt64(this object obj)
        {
            Int64 result = 0;
            Int64.TryParse(obj.ToText(), out result);
            return result;
        }

        public static Int32 ToInt32(this object obj)
        {
            Int32 result = 0;
            Int32.TryParse(obj.ToText(), out result);
            return result;
        }
        public static long ToLong(this object obj)
        {
            long result = 0;
            long.TryParse(obj.ToText(), out result);
            return result;
        }
        public static Decimal ToDecimal(this object obj)
        {
            Decimal result = 0;
            Decimal.TryParse(obj.ToText(), out result);
            return result;
        }
        public static Boolean ToBoolean(this object obj)
        {
            Boolean res = false;
            Boolean.TryParse(obj.ToText(), out res);
            return res;
        }
        public static DateTime ToDateTime(this object obj)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(obj.ToText(), out result);
            return result;
        }
    }
}
