using System.Linq.Expressions;
using FluentAssertions;

namespace CsAi;

public class NeuralNetworkTests
{
    [Fact]
    public void When_firing_a_neuron_it_should_return_its_value()
    {
        Neuron neuron = new Neuron(() => 0.4, 2);
        neuron.Fire(new double[] { 1, 1 }).Should().Be(0.3543436937742046);
    }

    [Fact]
    public void When_firing_a_layer_it_should_return_the_values_of_its_neurons()
    {
        Layer layer = new Layer(() => 0.4, 2, 2);
        layer.Fire(new double[] { 1, 1 });
        layer.Activations[0].Should().Be(0.3543436937742046);
        layer.Activations[1].Should().Be(0.3543436937742046);
    }

    [Fact]
    public void When_firing_the_neural_network_it_should_return_the_combined_values_of_its_layers()
    {
        NeuralNetwork neuralNetwork = new NeuralNetwork(() => 0.4, new[] { 2, 2, 2 });
        var output = neuralNetwork.Fire(new double[] { 1, 1 });
        output[0].Should().Be(0.41258730245090935);
        output[1].Should().Be(0.41258730245090935);
    }
}
public class TrainingScenarioTests
{
    [Fact]
    public void When_instancing_a_training_scenario_it_should_hold_the_correct_data()
    {
        // Given
        double[] testInputs = { 0.354343693, 0.7302450909, 0.19713811 };
        double[] testOutputs = { 0.354343693, 0.7302450909, 0.19713811 };

        // When
        TrainingScenario trainingScenario = new TrainingScenario(testInputs, testOutputs);

        // Then
        trainingScenario.getInputs().Should().Equal(testInputs);
        trainingScenario.getOutputs().Should().Equal(testOutputs);
    }
}

public class DeviationManager
{
    [Fact]
    public void DeviationManager_should_return_correct_values()
    {
        // Given
        double[] inputs = { 1, 1, 1 };
        double[] outputs = { 1, 1, 1 };
        double[] expectedDeviations = {0.9744787489988975 - 1, 0.9744787489988975 - 1, 0.9744787489988975 - 1};

        NeuralNetwork neuralNetwork = new NeuralNetwork(() => 1, new int[] { 3, 3 });

        TrainingScenario trainingScenario = new TrainingScenario(inputs, outputs);
        // When
        
        double[] deviations = neuralNetwork.Delta(trainingScenario);

        // Then

        deviations.Should().Equal(expectedDeviations);
    }
}