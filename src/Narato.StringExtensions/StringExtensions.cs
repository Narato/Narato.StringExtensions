using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Narato.StringExtensions
{
    public static class StringExtensions
    {
        /// <summary>Serializes the object to a JSON string.</summary>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJson<T>(this T value, JsonSerializerSettings settings = null)
        {
            if (settings == null)
            {
                settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<JsonConverter> { new StringEnumConverter() }
                };
            }

            return JsonConvert.SerializeObject(value, settings);
        }

        public static T FromJson<T>(this string json, params JsonConverter[] converters)
        {
            return JsonConvert.DeserializeObject<T>(json, converters);
        }

        public static T FromJson<T>(this string json, JsonSerializerSettings settings)
        { 
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static string EncodeJson(this string value)
        {
            return string.Concat
            ("\"",
                value.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "\\n"),
                "\""
            );
        }

        public static string EncodeXml(this string value)
        {
            return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }
    }
}
