using System;
using System.Text.Json;

namespace NeurocorBackEnd.Infra.Extensions
{
    public static class SerializeExtensions
    {
        private static readonly JsonSerializerOptions defaultSerializerSettings = new JsonSerializerOptions
        {
            WriteIndented = true
        };


        public static string SerializeObject(this object objeto)
        {
            return JsonSerializer.Serialize(objeto, defaultSerializerSettings);
        }
        public static string SerializeObject(this object objeto, Type inputType)
        {
            return JsonSerializer.Serialize(objeto, inputType, defaultSerializerSettings);
        }
    }

}
