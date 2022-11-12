using Microsoft.SemanticKernel;
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
 