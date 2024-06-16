using FluentAssertions;

namespace CsAi;

public class JsonSerializationTests
{
  [Fact]
  public void When_serializing_a_neural_network_to_json_it_should_return_the_json_representation()
  {
    // Arrange
    NeuralNetwork neuralNetwork = new NeuralNetwork(() => 0.3, new[] { 2, 2, 2 });
    neuralNetwork.Fire(new double[] { 1, 1 });

    // Act
    string json = neuralNetwork.ToJson();

    // Assert
    json.Should().Be(@"{
  ""layers"": [
    {
      ""neurons"": [
        {
          ""weights"": [],
          ""bias"": -0.4
        },
        {
          ""weights"": [],
          ""bias"": -0.4
        }
      ],
      ""activations"": [
        0.6456563062257954,
        0.6456563062257954
      ]
    },
    {
      ""neurons"": [
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4
        },
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4
        }
      ],
      ""activations"": [
        0.28566646911405097,
        0.28566646911405097
      ]
    },
    {
      ""neurons"": [
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4
        },
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4
        }
      ],
      ""activations"": [
        0.34784321020752484,
        0.34784321020752484
      ]
    }
  ]
}");
  }
  [Fact]
  public void When_deserializing_a_neural_network_from_json_it_should_return_the_correct_neural_network_object()
  {
    // Given
    NeuralNetwork neuralNetwork = new NeuralNetwork(() => 0.3, new[] { 2, 2, 2 });
    neuralNetwork.Fire(new double[] { 1.0, 1.0 });

    string jsonNeuralNet = @"{
  ""layers"": [
    {
      ""neurons"": [
        {
          ""weights"": [],
          ""bias"": -0.4
        },
        {
          ""weights"": [],
          ""bias"": -0.4
        }
      ],
      ""activations"": [
        0.6456563062257954,
        0.6456563062257954
      ]
    },
    {
      ""neurons"": [
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4
        },
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4
        }
      ],
      ""activations"": [
        0.28566646911405097,
        0.28566646911405097
      ]
    },
    {
      ""neurons"": [
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4
        },
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4
        }
      ],
      ""activations"": [
        0.34784321020752484,
        0.34784321020752484
      ]
    }
  ]
}";
    // When
    NeuralNetwork deserializedNeuralNet = jsonNeuralNet.ToNeuralNetwork();
    // Then
    deserializedNeuralNet.Should().Be(neuralNetwork);
  }
}