using FluentAssertions;

namespace CsAi;

public class UnitTest
{
    [Fact]
    public void When_creating_a_neuron_it_should_initialize()
    {
        // Arrange
        Neuron neuron = Neuron.Create(() => 0.4,  2);
        
        // Act
        neuron.Fire(new double[] { 1, 1 });
            
        // Assert
        neuron.Output.Should().BeInRange(0.0, 1.0);
    }

    [Fact]
    public void When_creating_a_layer_it_should_initialize()
    {
        Layer layer = Layer.Create(() => 0.4, 2, 2);
        // layer.Fire(new double[] { 1, 1 });
        // layer.Activations[0].Should().BeInRange(0.0, 1.0);
        // layer.Activations[1].Should().BeInRange(0.0, 1.0);
    }

    [Fact]
    public void When_creating_a_neural_network_it_should_initialize()
    {
        NeuralNetwork neuralNetwork = new NeuralNetwork(() => 0.4, new[] { 2, 2, 2 });
        neuralNetwork.Fire();
        // output[0].Should().BeInRange(0.0, 1.0);
        // output[1].Should().BeInRange(0.0, 1.0);
    }
}