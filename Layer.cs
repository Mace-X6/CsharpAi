namespace CsAi
{
    public class Layer
    {
        private readonly Neuron[] neurons;
        
        public IReadOnlyList<Neuron> Neurons => neurons;
        
        public double[] Activations { get; }
        
        public Layer(NewDouble random, int neurons, int axonsPerNeuron)
        {
            Activations = new double[neurons];
            this.neurons = new Neuron[neurons];
            for (int i = 0; i < neurons; i++)
            {
                this.neurons[i] = new Neuron(random, axonsPerNeuron);
            }
        }
        
        public void Fire(double[] activations)
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                Activations[i] = neurons[i].Fire(activations);
            }
        }
    }
}