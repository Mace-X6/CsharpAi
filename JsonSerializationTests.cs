using FluentAssertions;

namespace CsAi;

public class JsonSerializationTests
{
    [Fact]
    public void When_serializing_a_neural_network_to_json_it_should_return_the_json_representation()
    {
        // Arrange
        NeuralNetwork neuralNetwork = new NeuralNetwork(() => 0.3, new[] { 2, 2, 2 });
        neuralNetwork.Fire();

        // Act
        string json = neuralNetwork.ToJson();

        // Assert
        json.Should().Be(@"{
  ""layers"": [
    {
      ""neurons"": [
        {
          ""weights"": [],
          ""bias"": -0.4,
          ""output"": 0
        },
        {
          ""weights"": [],
          ""bias"": -0.4,
          ""output"": 0
        }
      ]
    },
    {
      ""neurons"": [
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4,
          ""output"": 0.401312339887548
        },
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4,
          ""output"": 0.401312339887548
        }
      ]
    },
    {
      ""neurons"": [
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4,
          ""output"": 0.3271618358885832
        },
        {
          ""weights"": [
            -0.4,
            -0.4
          ],
          ""bias"": -0.4,
          ""output"": 0.3271618358885832
        }
      ]
    }
  ]
}");
    }
}