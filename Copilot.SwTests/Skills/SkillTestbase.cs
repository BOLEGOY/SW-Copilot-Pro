﻿using Microsoft.SemanticKernel;

namespace Copilot.SwTests.Skills;

public class SkillTestbase
{
    private IKernel _kernel;

    public IKernel Kernel => _kernel ??= StandandAloneSw.S_Instance.InitKernel();

    public string SkillsDir()
    {
   