using CommunityToolkit.Mvvm.DependencyInjection;
using Copilot.Sw;
using Copilot.Sw.Config;
using Copilot.Sw.Skills;
using Copilot.Sw.ViewModels;
using Copilot.Sw.Views;
using Microsoft.Extensions.DependencyInjection;
using MvvmDialogs;
using SolidWorks.Interop.sldworks;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Xarial.XCad.Base.Attributes;
using Xarial.XCad.Base.Enums;
using Xarial.XCad.SolidWorks;
using Xarial.XCad.UI.Commands;
using Xarial.XCad.UI.Commands.Structures;

[ComVisible(true)]
[Guid("9F9212BF-6856-4078-AE4E-F5CD5774DD71")]
[Title(AddinName)]
[Icon(typeof(Copilot.Sw.Properties.Resources), nameof(Copilot.Sw.Properties.Resources.SolidWorksCopilot))]
public class AddI