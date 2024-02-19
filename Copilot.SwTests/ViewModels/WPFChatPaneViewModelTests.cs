
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.KernelExtensions;
using Copilot.Sw.Config;
using Copilot.Sw.Skills;

namespace Copilot.Sw.ViewModels.Tests;

[TestClass()]
public class KernelTests
{
    [TestMethod()]
    public async Task QuestionTest()
    {
        IKernel kernel = Microsoft.SemanticKernel.Kernel.Builder.Build();
