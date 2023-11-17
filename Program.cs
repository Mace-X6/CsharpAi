namespace CsAi
{
    static class Program
    {
        static void Main(string[] args)
        {
            NeuralNetwork neuralNetwork = new NeuralNetwork(new int[3] {2, 3, 2});
            Console.WriteLine(neuralNetwork);
            Console.WriteLine(neuralNetwork.ToJson());
        }
    }
}
