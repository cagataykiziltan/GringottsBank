using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GringottsBank.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static string AsJson(this object source)
        {
            return JsonConvert.SerializeObject(source,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });
        }

        public static T MapTo<T>(this object source)
            where T : new()
        {
            T dest = new T();

            var destPropNames = typeof(T).GetProperties()
                .Select(p => p.Name)
                .ToList();

            var sourceProps = source.GetType()
                .GetProperties()
                .Where(p => destPropNames.Contains((p.Name)))
                .ToList();

            // TODO: Handle enumerable types
            foreach (var sourceProp in sourceProps)
            {
                var destProp = typeof(T).GetProperty(sourceProp.Name, sourceProp.PropertyType);
                if (destProp != null)
                {
                    var v = sourceProp.GetValue(source);
                    if (destProp.CanWrite)
                    {
                        destProp.SetValue(dest as object, v);
                    }
                }
            }

            return dest;
        }
        public static IEnumerable<T> MapTo<T>(this IEnumerable<object> source)
            where T : new()
        {
            return source.Select(s => s.MapTo<T>())
                .ToList();
        }

        public static TSource DeepClone<TSource>(this TSource source)
        {
            return source == null
                ? default
                : source.AsJson().FromJson<TSource>();
        }
        public static TDest FromJson<TDest>(this string source)
        {

            try
            {
                var result = JsonConvert.DeserializeObject<TDest>(source,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    });

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
     
    }
}
