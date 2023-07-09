﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Copilot.Sw.Config;
using Copilot.Sw.Extensions;
using Copilot.Sw.Models;
using MvvmDialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Copilot.Sw.ViewModels;

public partial class SettingsWindowViewModel : 
    ObservableObject
{
    #region Fields
    [ObservableProperty]
    private UITextCompletionConfig? _selectedTextCompletionConfig;
    private ITextCompletionProvider _textCompletionProvider;
    #endregion

    #region Ctor
    public SettingsWindowViewModel(
        ITextCompletionProvider textCompletionProvider)
    {
        _textCompletionProvider = textCompletionProvider;
        TextCompletionConfigs =
            _textCompletionProvider.Load()?.Select(t => ToUI(t))?.ToObservableCollection() ??
            new ObservableCollection<UITextCompletionConfig>();
        _textCompletionProvider = textCompletionProvider;
    }

    #endregion

    [RelayCommand]
    private void Ok(Window window)
    {
        //TODO:Check

        window.DialogResult = true;
    }


    public ObservableCollection<UITextCompletionConfig> TextCompletionConfigs { get; private set; }

    [RelayCommand]
    private void Add()
    {
        bool nothing = TextCompletionConfigs.Count == 0;
        TextCompletionConfigs.Add(new UITextCompletionConfig()
        {
            Name = "ServerName",
            Model = "text-davinci-003",
            Type = ServerType.OpenAI,
            IsDefault = nothing,
        });
    