namespace Sharpliner.AzureDevOps.Model.Tasks.Marketplace.JFrog;

public record JFrogGenericArtifactsUploadTask : JFrogGenericArtifactsTask
{
    public JFrogGenericArtifactsUploadTask(string connection) : base("Upload", connection)
    {
    }

    /// <summary>
    /// Collect build info and store it locally.
    /// The build info can be later published to Artifactory using the \"JFrog Publish Build Info\" task.
    /// </summary>
    [YamlIgnore]
    public bool? CollectBuildInfo
    {
        get => GetBool("collectBuildInfo", false);
        init => SetProperty("collectBuildInfo", value);
    }
}