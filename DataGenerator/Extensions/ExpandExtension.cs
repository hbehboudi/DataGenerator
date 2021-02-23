namespace DataGenerator.Extensions
{
    internal static class ExpandExtension
    {
        public static string Expand(this string str, int size)
        {
            while (str.Length < size)
            {
                str = "0" + str;
            }

            return str;
        }

        public static string Expand(this long num, int size) =>
            Expand(num.ToString(), size);

        public static string Expand(this int num, int size) =>
            Expand(num.ToString(), size);
    }
}
