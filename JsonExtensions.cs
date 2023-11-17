using System.Text.Json;

namespace CsAi
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static NeuralNetwork ToNeuralNetwork(this string jsonNeuralNet)
        {
            NeuralNetwork? neuralNetwork = JsonSerializer.Deserialize<NeuralNetwork>(jsonNeuralNet);
            if (neuralNetwork == null){
                return new NeuralNetwork(new int[1]);
            }
            return neuralNetwork;
        }
    }
}