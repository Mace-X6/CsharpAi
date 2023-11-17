using FluentAssertions;

namespace CsAi;

public class UnitTest
{
    [Fact]
    public void Neuron()
    {
        Neuron neuron = new Neuron(() => 0.4,  2);
        neuron.Fire(new double[] { 1, 1 }).Should().BeInRange(0.0, 1.0);
    }

    [Fact]
    public void Layer()
    {
        Layer layer = new Layer(() => 0.4, 2, 2);
        layer.Fire(new double[] { 1, 1 });
        layer.Activations[0].Should().BeInRange(0.0, 1.0);
        layer.Activations[1].Should().BeInRange(0.0, 1.0);
    }

    [Fact]
    public void NeuralNetwork()
    {
        NeuralNetwork neuralNetwork = new NeuralNetwork(() => 0.4, new[] { 2, 2, 2 });
        var output = neuralNetwork.Fire(new double[] { 1, 1 });
        output[0].Should().BeInRange(0.0, 1.0);
        output[1].Should().BeInRange(0.0, 1.0);
    }
}