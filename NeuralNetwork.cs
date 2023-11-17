namespace CsAi
{
    public class NeuralNetwork
    {
        private Layer[] Layers;
        public NeuralNetwork(int[] layersToCreate)
        {
                Layers = new Layer[layersToCreate.Length];
                for (int i = 0; i < layersToCreate.Length; i++)
                {
                    if (i == 0)
                    {
                        Layers[i] = new Layer(layersToCreate[i], 0);
                    }
                    else
                    {
                        Layers[i] = new Layer(layersToCreate[i], layersToCreate[i - 1]);
                    }
                }
        }

        public double[] Fire(double[] inputs)
        {
            double[] activations = inputs;
            for (int i = 0; i < Layers.Length; i++)
            {
                Layers[i].Fire(activations);
                activations = Layers[i].Activations;
            }
            return activations;
        }
    }
}