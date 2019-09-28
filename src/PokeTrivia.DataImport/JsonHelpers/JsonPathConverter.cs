using System;
using System.Collections;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PokeTrivia.DataImport.JsonHelpers
{
    /*
     * Taken from https://stackoverflow.com/questions/52619432/json-net-deserialize-object-nested-data
     */
    public class JsonPathConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return !objectType.IsPrimitive &&
                objectType.FullName != "System.String";
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JContainer jsonItem;

            var targetObj = Activator.CreateInstance(objectType);

            if (reader.TokenType == JsonToken.StartArray)
            {
                jsonItem = JArray.Load(reader);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                jsonItem = JObject.Load(reader);
            }
            else
            {
                return targetObj;
            }

            foreach (var prop in objectType.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {
                var att = prop.GetCustomAttributes(true)
                    .OfType<JsonPropertyAttribute>()
                    .FirstOrDefault();

                var jsonPath = (att != null ? att.PropertyName : prop.Name);

                if (jsonPath.Contains("[") || jsonPath.Contains("]"))
                {
                    var tokens = jsonItem.SelectTokens(jsonPath);
                    if (tokens != null)
                    {
                        var containedType = prop.PropertyType.GenericTypeArguments[0];
                        
                        var enumerableType = typeof(Enumerable);
                        var castMethod = enumerableType.GetMethod(nameof(Enumerable.Cast)).MakeGenericMethod(containedType);
                        var toListMethod = enumerableType.GetMethod(nameof(Enumerable.ToList)).MakeGenericMethod(containedType);

                        var valueList = tokens
                            .Select(t => t.ToObject(containedType, serializer))
                            .ToList();

                        var castedItems = castMethod.Invoke(null, new[] {valueList});
                        var valuesToSet = toListMethod.Invoke(null, new[] {castedItems});

                        prop.SetValue(targetObj, valuesToSet, null);
                    }
                }
                else
                {
                    var token = jsonItem.SelectToken(jsonPath);

                    if (token != null && token.Type != JTokenType.Null)
                    {
                        var value = token.ToObject(prop.PropertyType, serializer);
                        prop.SetValue(targetObj, value, null);
                    }
                }
            }

            return targetObj;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}