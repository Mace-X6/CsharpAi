using CsAi;

public static class NeuralNetCoach
{
    public static void Coach(this NeuralNetwork neuralNetwork, TrainingScenario trainingScenario)
    {
        double[] deltas = neuralNetwork.Delta(trainingScenario);
        for (int o = 1; o <= neuralNetwork.Layers.Count; o++)
        {
            for (int i = 0; i < neuralNetwork.Layers[^o].Neurons.Count; i++)//length of layer[layer.length - o] in neural network
            {
                Neuron neuron = neuralNetwork.Layers[^o].Neurons[i];//neuron -> neuron i in last layer
                for (int j = 0; j < neuron.Weights.Count; j++)
                {
                    neuron.SetWeight(j, neuron.Weights[j] * deltas[i]);
                }
                neuron.SetBias(neuron.Bias * deltas[i]);
                // so neuron weights are set, now move on to previous layer + also change the bias.
            }
            //lets see if this still makes sense if i look at it tomorrow.
        }


    }
}