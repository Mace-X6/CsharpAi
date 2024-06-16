class TrainingScenario
{
    private double[] inputs;
    private double[] outputs;
    public double[] getInputs() => inputs;
    public double[] getOutputs() => outputs; 
    public TrainingScenario(double[] inputs, double[] outputs){

        foreach(double input in inputs){
            if (input < 0 || input > 1){
                throw new ArgumentOutOfRangeException(nameof(input), "input value must be between 1 and 0");
            }
        }
        foreach(double output in outputs){
            if (output < 0 || output > 1){
                throw new ArgumentOutOfRangeException(nameof(output), "output value must be between 1 and 0");
            }
        }

        this.inputs = inputs;
        this.outputs = outputs;
    }

}