using System.Text.Json;
using System.Text.Json.Serialization;

namespace CsAi
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj, JsonSerializerOptions);
        }

        public static NeuralNetwork ToNeuralNetwork(this string jsonNeuralNet)
        {
            return jsonNeuralNet.FromJson<NeuralNetwork>();
        }
        
        public static T FromJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, JsonSerializerOptions)!;
        }
    }
}