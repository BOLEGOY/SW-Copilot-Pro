using CommunityToolkit.Mvvm.ComponentModel;
using Copilot.Sw.Config;

namespace Copilot.Sw.Models;

public sealed partial class UITextCompletionConfig:ObservableObject
{
    /// <summary>
    /// name for this config
    /// </summary>
    [ObservableProperty]public string? _name;

    /// <summary>
    /// type openai of azu