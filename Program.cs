namespace CsAi
{
    static class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            NeuralNetwork neuralNetwork = new NeuralNetwork(random.NextDouble, new int[] { 2, 3, 2 });
            Console.WriteLine(neuralNetwork);
            Console.WriteLine(neuralNetwork.ToJson());
        }
    }
}
