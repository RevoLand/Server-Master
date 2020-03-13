using System;
using System.Linq;
using System.Reflection;

namespace ServerMaster
{
    public static class ExtensionMethods
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
        }

        public static bool IsIn<T>(this T source, params T[] list)
        {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(source, default(T))) throw new ArgumentNullException(nameof(source));
            return list.Contains(source);
        }

        public static void LogToForm(this string Text)
        {
            try
            {
                Forms.Main.ProgramLogs.Add($"[{DateTime.Now}] {Text}");
            }
            catch { }
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static byte[] Combine(byte[] first, byte[] second, byte[] third)
        {
            var ret = new byte[first.Length + second.Length + third.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            Buffer.BlockCopy(third, 0, ret, first.Length + second.Length,
                             third.Length);
            return ret;
        }

        public static byte[] Combine(params byte[][] arrays)
        {
            var ret = new byte[arrays.Sum(x => x.Length)];
            var offset = 0;
            foreach (var data in arrays)
            {
                Buffer.BlockCopy(data, 0, ret, offset, data.Length);
                offset += data.Length;
            }
            return ret;
        }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class SkipPropertyAttribute : Attribute
    {
    }

    public static class TypeExtensions
    {
        public static PropertyInfo[] GetFilteredProperties(this Type type)
        {
            return type.GetProperties().Where(pi => !Attribute.IsDefined(pi, typeof(SkipPropertyAttribute))).ToArray();
        }
    }
}