namespace Copilot.Sw.Config;

public enum ServerType
{
    OpenAI,
    Azure,
}

public sealed class TextCompletionConfig
{
    /// <summary>
    /// name for this config
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    