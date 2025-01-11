namespace Sharpliner.AzureDevOps.Model.Tasks.Marketplace.JFrog;

public enum SpecSources
{
    [YamlMember(Alias = "taskConfiguration")]
    TaskConfiguration,

    [YamlMember(Alias = "file")]
    File
}