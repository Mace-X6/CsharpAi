namespace CsAi
{
    public class Neuron
    {
        private double[] weights;
        private double bias;

        public Neuron(int axons)
        {
            weights = new double[axons];
            Random random = new Random();
            for (int i = 0; i < axons; i++)
            {
                weights[i] = random.NextDouble() * 2 - 1;
            }
            bias = random.NextDouble() * 2 - 1;
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
    }
}