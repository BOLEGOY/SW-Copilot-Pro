
﻿using Copilot.Sw.Config;
using Microsoft.SemanticKernel;
using System.Collections.Generic;
using System.Linq;

namespace Copilot.Sw.Extensions;

public static class KernelExtensions
{
    public static bool LoadConfigs(
        this KernelConfig kernelConfig, 
        IReadOnlyList<TextCompletionConfig> configs)
    {
        if (configs?.Any() != true)
        {