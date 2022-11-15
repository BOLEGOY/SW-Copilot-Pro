﻿using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.KernelExtensions;
using Microsoft.SemanticKernel.Orchestration;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copilot.Sw.Skills;

public static class SwSkillSelection
{
    private static StringBuilder? _skillBuilder;

    public const string SemanticFuncation =
        """
        Create an XML plan step by step, to satisfy the goal given, to run in SolidWorks.
        To create a plan, follow these steps:
        1. From a <goal> create a <task> as a series of <skill>.
        2. Use only the [AVAILABLE SKILLS] - do not create new skills or attribute values.
        3. Only use skills that are required for the given goal.
        4. Append an "END" XML comment at the end of the plan.

        Here are some good examples:      
        [AVAILABLE SKILLS]
          Properties:
            description: 