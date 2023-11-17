namespace CsAi
{
    public class NeuralNetwork
    {
        private readonly Layer[] layers;

        public IReadOnlyList<Layer> Layers => layers;

        public NeuralNetwork(NextRandomDouble random, int[] layersToCreate)
        {
            var layers = new List<Layer>();
            layers.Add(Layer.Create(random, layersToCreate[0], 0));
            for (int i = 1; i < layersToCreate.Length; i++)
            {
                layers.Add(Layer.Create(random, layersToCreate[i], layersToCreate[i - 1]));
            }

            this.layers = layers.ToArray();
        }

        public void Fire()
        {
            for (int i = 1; i < layers.Length; i++)
            {
                layers[i].Fire(layers[i-1]);
            }
        }
    }
}