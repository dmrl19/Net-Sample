using Pulumi;
using Pulumi.Aws.S3;
using System.Collections.Generic;

class SampleStack : Stack
{
    private readonly Dictionary<string, string> _Tags = new Dictionary<string, string>();
    private readonly Config _config;
    public SampleStack()
    {
        _config = new Config();
        SetupTags();

        var ecrRepository = new Pulumi.Aws.Ecr.Repository($"ecr-sample-dmr-{_config.Require("Stage")}", new Pulumi.Aws.Ecr.RepositoryArgs()
        {
            Name = $"ecr-sample-dmr-{_config.Require("Stage")}",
            Tags = _Tags
        });

        RepositoryUrl = ecrRepository.RepositoryUrl;
    }

    private void SetupTags()
    {
        _Tags.Add("Environment", _config.Require("Environment"));
        _Tags.Add("Project", _config.Require("ProjecName"));    }

    [Output]
    public Output<string> RepositoryUrl { get; set; }
}
