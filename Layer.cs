namespace CsAi
{
    public class Layer
    {
        private readonly Neuron[] neurons;
        
        public  IReadOnlyList<Neuron> Neurons => neurons;

        public Layer(Neuron[] neurons)
        {
            this.neurons = neurons;
        }
        
        public static Layer Create(NextRandomDouble random, int neuronCount, int axonsPerNeuron)
        {
            var neurons = new List<Neuron>();
            for (int i = 0; i < neuronCount; i++)
            {
                neurons.Add(Neuron.Create(random, axonsPerNeuron));
            }
            
            return new Layer(neurons.ToArray());
        }
        
        public void Fire(Layer input)
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].Fire(input.Neurons.Select(n => n.Output).ToArray());
            }
        }
    }
}