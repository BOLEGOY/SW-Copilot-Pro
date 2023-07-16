
﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Copilot.Sw.Models;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Copilot.Sw.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Copilot.Sw.Config;
using Copilot.Sw.Skills;
using System.Collections.Generic;
using Microsoft.SemanticKernel.Memory;
using Copilot.Sw.Extensions;

namespace Copilot.Sw.ViewModels;

public partial class WPFChatPaneViewModel : ObservableObject
{
    #region Fields
    private AsyncRelayCommand? _sendCommand;
    private string? _question;
    private readonly ILogger? _logger;
    private readonly IAddin _addin;
    private readonly ITextCompletionProvider _textCompletionProvider;
    protected readonly ISkillsProvider _skillsProvider;
    protected bool _configLoadResult;
    private LocalSemanticFunctionModel _selectedSkill;
    #endregion

    #region Ctor
    public WPFChatPaneViewModel(
        IAddin addin,
        ITextCompletionProvider textCompletionProvider,
        ISkillsProvider skillsProvider)
    {
        _addin = addin;
        _textCompletionProvider = textCompletionProvider;
        _skillsProvider = skillsProvider;
        Skills = _skillsProvider.GetSkills()
            .SelectMany(p => p.SemanticFunctions)
            .ToList();
        //_logger = logger;
    }
    #endregion

    #region Properties
    public string? Question
    {
        get => _question; set
        {
            SetProperty(ref _question, value);
            SendCommand.NotifyCanExecuteChanged();
        }
    }

    public List<LocalSemanticFunctionModel> Skills { get; set; }

    public LocalSemanticFunctionModel SelectedSkill { get; set; }

    public Conversation Conversation { get; set; } = new();

    public IKernel? Kernel { get; private set; }

    public bool HasItem => Conversation?.Messages?.Any() == true;

    public AsyncRelayCommand SendCommand { get => _sendCommand ??= new AsyncRelayCommand(SendAsync, CanSend); }
    #endregion