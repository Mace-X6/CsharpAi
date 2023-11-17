namespace CsAi
{
    public class Layer
    {
        private Neuron[] Neurons;
        public double[] Activations { get; private set; }
        public Layer(int neurons, int axonsPerNeuron)
        {
            Activations = new double[neurons];
            Neurons = new Neuron[neurons];
            for (int i = 0; i < neurons; i++)
            {
                Neurons[i] = new Neuron(axonsPerNeuron);
            }
        }
        public void Fire(double[] activations)
        {
            
            for (int i = 0; i < Neurons.Length; i++)
            {
                Activations[i] = Neurons[i].Fire(activations);
            }
        }
    }
}