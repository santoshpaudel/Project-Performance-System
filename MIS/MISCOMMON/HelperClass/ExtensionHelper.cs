// ***********************************************************************
// Assembly         : 
// Author           : Ujjwal Mishra
// Created          : 10-08-2012
//
// Last Modified By : Ujjwal Mishra
// Last Modified On : 10-08-2012
// ***********************************************************************
// <copyright file="CryptoHelper.cs" company="">
//     . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace MISCOMMON.HelperClass
{
    public static class ExtensionHelper
    {
        public static string ToText(this object obj)
        {
            if (obj==null || obj==DBNull.Value)
                return string.Empty;
            else
                return obj.ToString();
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
        public static float ToFloat(this object obj)
        {
            float result = 0;
            float.TryParse(obj.ToText(), out result);
            return result;
        }
        public static Decimal ToDecimal (this object obj)
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
