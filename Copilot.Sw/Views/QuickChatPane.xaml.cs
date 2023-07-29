﻿using Copilot.Sw.ViewModels;
using System.Windows;
using System.Windows.Interop;

namespace Copilot.Sw.Views;

/// <summary>
/// QuickChatPane.xaml 的交互逻辑
/// </summary>
public partial class QuickChatPane : Window
{
    private readonly IAddin _addin;

    public QuickChatPane(
        IAddin addin,
        QuickChatPaneViewModel quickChatPaneViewModel)
    {
        _addin = addin;

        InitializeComponent();
        var windowInteropHelper = new WindowInteropHelper(this);
        windowInteropHelper.Owner = _addin.SwHandle;

        quickChatPaneViewModel.CloseAction = () => Close();
        DataContext = quickChatPaneViewModel;

        this.Loaded += QuickChatPane_Loaded;

        try
        {
            quickChatPaneViewModel.Init();
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void QuickCh