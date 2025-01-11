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
        var task = _builder.Upload("serviceConnection");

        return Verify(GetYaml(task));
    }

    [Fact]
    public Task Upload_Full_Command()
    {
        var task = _builder.Upload("serviceConnection") with
        {
            CollectBuildInfo = true,
            SpecSource = SpecSources.TaskConfiguration,
            FileSpec = """
                       {
                               "files": [
                                 {
                                   "pattern": "libs-generic-local/*.zip",
                                   "target": "dependencies/files/"
                                 }
                               ]
                             }
                       """,
            BuildName = "ThisBuild",
            BuildNumber = "1.0.0",
            ReplaceSpecVars = true,
            SpecVars = "key1=value1;key2=value2",
            ProjectKey = "projectKey",
            IncludeEnvVars = true,
            FailNoOp = true,
            WorkingDirectory = Path.GetTempPath()
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
