
﻿using CommunityToolkit.Mvvm.DependencyInjection;
using Copilot.Sw.Config;
using Copilot.Sw.Skills;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolidWorks.Interop.sldworks;
using System.Diagnostics;
using Xarial.XCad.SolidWorks;

namespace Copilot.SwTests;

public class StandandAloneSw : IAddin
{
    private static StandandAloneSw _instance;

    private StandandAloneSw()