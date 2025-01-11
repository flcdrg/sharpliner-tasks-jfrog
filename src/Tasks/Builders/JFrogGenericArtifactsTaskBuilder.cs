namespace Sharpliner.AzureDevOps.Model.Tasks.Marketplace.JFrog.Builders;

public class JFrogGenericArtifactsTaskBuilder
{
    internal JFrogGenericArtifactsTaskBuilder()
    {
    }

    /// <summary>
    /// Creates the <c>Upload</c> command version of the JFrogGenericArtifacts task.
    /// </summary>
    public JFrogGenericArtifactsUploadTask Upload(string connection) => new (connection)
    {
    };
}