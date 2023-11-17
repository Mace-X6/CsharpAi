namespace CsAi
{
    public class NeuralNetwork
    {
        private readonly Layer[] layers;

        public IReadOnlyList<Layer> Layers => layers;

        public NeuralNetwork(NextRandomDouble random, int[] layersToCreate)
        {
                layers = new Layer[layersToCreate.Length];
                for (int i = 0; i < layersToCreate.Length; i++)
                {
                    if (i == 0)
                    {
                        layers[i] = new Layer(random, layersToCreate[i], 0);
                    }
                    else
                    {
                        layers[i] = new Layer(random, layersToCreate[i], layersToCreate[i - 1]);
                    }
                }
        }

        public double[] Fire(double[] inputs)
        {
            double[] activations = inputs;
            for (int i = 0; i < layers.Length; i++)
            {
                layers[i].Fire(activations);
                activations = layers[i].Activations;
            }
            
            return activations;
        }
    }
}