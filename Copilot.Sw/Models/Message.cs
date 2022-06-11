using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Text.Json.Serialization;

namespace Copilot.Sw.Models;

public abstract partial class Message: ObservableObject
{
    [JsonIgnore]
    public abstract MessageType MessageType { get; }

    