using CsAi;

static class DeviationManager
{
    public static double[] Delta(this NeuralNetwork neuralNet, TrainingScenario trainingScenario)
    {
        double[] actualOutputs = neuralNet.Fire(trainingScenario.getInputs());
        double[] expectedOutputs = trainingScenario.getOutputs();

        double[] deltas = new double[actualOutputs.Length];

        for (var i = 0; i < actualOutputs.Length; i++)
        {
            deltas[i] = actualOutputs[i] - expectedOutputs[i];
        }

        return deltas;
    }
}