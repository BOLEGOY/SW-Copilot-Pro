using Copilot.Sw.ViewModels;
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

  