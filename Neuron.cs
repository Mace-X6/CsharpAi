namespace CsAi
{
    public class Neuron
    {
        public IReadOnlyList<double> Weights => weights;
        public double Bias => bias;
        public double Output => output;
        
        private readonly double[] weights;
        private readonly double bias;
        private double output;

        public Neuron(double[] weights, double bias, double output)
        {
            this.weights = weights;
            this.bias = bias;
            this.output = output;
        }

        public static Neuron Create(NextRandomDouble random, int axons)
        {
            double[] weights = new double[axons];
            for (int i = 0; i < axons; i++)
            {
                weights[i] = random() * 2 - 1;
            }
            
            double bias = random() * 2 - 1;

            return new Neuron(weights, bias, 0);
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public void Fire(double[] activations)
        {
            double output = this.output;
            for (int i = 0; i < activations.Length; i++)
            {
                output += activations[i] * weights[i];
            }
            output += bias;
            this.output = Sigmoid(output);
        }
    }
}