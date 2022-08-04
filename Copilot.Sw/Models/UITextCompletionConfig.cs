﻿using CommunityToolkit.Mvvm.ComponentModel;
using Copilot.Sw.Config;

namespace Copilot.Sw.Models;

public sealed partial class UITextCompletionConfig:ObservableObject
{
    /// <summary>
    /// name for this config
    /// </summary>
    [ObservableProperty]public string? _name;

    /// <summary>
    /// type openai of azure
    /// </summary>
    [ObservableProperty]public ServerType _type;

    /// <summary>
    /// the llm model
    /// </summary>
    [ObservableProperty] public string? _model;

    /// <summary>
    /// endpoint if using azure
    /// </summary>
    [ObservableProperty] public string? _endpoint;

    /