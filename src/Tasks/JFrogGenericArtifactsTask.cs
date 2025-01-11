namespace Sharpliner.AzureDevOps.Model.Tasks.Marketplace.JFrog;

public record JFrogGenericArtifactsTask : AzureDevOpsTask
{
    public JFrogGenericArtifactsTask(string command, string connection) : base("JFrogGenericArtifacts@1")
    {
        SetProperty("command", command);
        SetProperty("connection", connection);
    }

    /// <summary>
    /// Artifactory service to be used by this task.
    /// </summary>
    [YamlIgnore]
    public string Connection
    {
        get => GetString("connection")!;
        init => SetProperty("connection", value);
    }

    /// <summary>
    /// Current working directory where the command is run.
    /// Empty is the root of the repo (build) or artifacts (release), which is $(System.DefaultWorkingDirectory)
    /// </summary>
    [YamlIgnore]
    public string? WorkingDirectory
    {
        get => GetString("workingDirectory");
        init => SetProperty("workingDirectory", value);
    }
}
