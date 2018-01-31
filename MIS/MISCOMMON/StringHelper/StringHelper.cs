namespace MISCOMMON.StringHelper
{
    public static class StringHelper
    {
        public static string [] Add(this string[] ab,string strNew)
        {
            string[] str = null;
            str = ab;
            str[ab.Length]=strNew;
            return str;
        }
    }
}
