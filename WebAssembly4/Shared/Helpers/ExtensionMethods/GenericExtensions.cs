using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskEvidence.Shared.Helpers.ExtensionMethods.Generics
{
    public static class GenericExtensions
    {
        public static T Clone<T>(this T source) where T : new()
        {
            T clone = new T();
            CloneProperties(source, clone);
            return clone;
        }

        public static void CloneProperties<T>(T source, T target)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(source);
                    property.SetValue(target, value);
                }
            }
        }
        public static T CloneFile<T>(this T source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(source));
        }
    }
}
