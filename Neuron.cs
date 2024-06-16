namespace CsAi
{
    public class Neuron
    {
        public IReadOnlyList<double> Weights => weights;
        public double Bias => bias;
        
        private double[] weights;
        private double bias;

        public Neuron(NewDouble random, int axons)
        {
            weights = new double[axons];
            for (int i = 0; i < axons; i++)
            {
                weights[i] = random() * 2 - 1;
            }
            
            bias = random() * 2 - 1;
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double Fire(double[] activations)
        {
            double output = 0.0;
            if (weights.Length != activations.Length)
            {
                output = activations[0];
            }
            else
            {
                for (int i = 0; i < activations.Length; i++)
                {
                    output += activations[i] * weights[i];
                }
            }
            output += bias;
            return Sigmoid(output);
        }

        public void SetWeight(int index, double newWeight){
            this.weights[index] = newWeight;
        }

        public void SetBias(double newBias){
            this.bias = newBias;
        }
    }
}