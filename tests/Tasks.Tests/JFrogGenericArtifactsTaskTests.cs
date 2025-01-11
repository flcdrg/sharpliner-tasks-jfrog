namespace Sharpliner.AzureDevOps.Model.Tasks.Marketplace.JFrog.Tests;

public class JfrogGenericArtifactTaskTests
{
    private readonly JFrogGenericArtifactsTaskBuilder _builder = new();

    private class JFrog_Pipeline(Step step) : SimpleTestPipeline
    {
        public override SingleStagePipeline Pipeline => new()
        {
            Jobs =
            {
                new Job("job")
                {
                    Steps = { step }
                }
            }
        };
    }

    [Fact]
    public Task Upload_Command()
    {
        var task = _builder.Upload("serviceConnection") with
        {
            WorkingDirectory = "/tmp"
        };

        return Verify(GetYaml(task));
    }

    private static string GetYaml(Step task) => new JFrog_Pipeline(task).Serialize();

}

internal abstract class SimpleTestPipeline : SingleStagePipelineDefinition
{
    public override string TargetFile => "azure-pipelines.yml";

    public override TargetPathType TargetPathType => TargetPathType.RelativeToGitRoot;
}
