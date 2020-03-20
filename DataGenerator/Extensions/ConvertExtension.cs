using System;

namespace DataGenerator.Extensions
{
    public static class ConvertExtension
    {
        public static Guid ToGuid(this long value)
        {
            var bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
        
        public static Guid ToGuid(this int value)
        {
            return ToGuid((long) value);
        }
    }
}
