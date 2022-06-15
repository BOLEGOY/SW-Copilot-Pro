﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Text.Json.Serialization;

namespace Copilot.Sw.Models;

public abstract partial class Message: ObservableObject
{
    [JsonIgnore]
    public abstract MessageType MessageType { get; }

    public string? Content { get; set; }

    public static Message CreateError(string message)
    {
        return new ErrorMessage() { Content = message };
    }

    internal static Message CreateAnswer(string result)
    {
       