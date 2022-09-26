using CommunityToolkit.Mvvm.DependencyInjection;
using Copilot.Sw.Skills.SketchSkill;
using Copilot.Sw.Skills.SolidWorksSkill;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.CoreSkills;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.Planning.Planners;
using Microsoft.SemanticKernel.SkillDefinition;
using SolidWorks.Interop.swconst;
using System;
using System.Threading.Tasks;

namespace Copilot.Sw.Skills;

public class SolidWorksPlanSkill
{
    #region Fields
    private readonly IKernel _kernel;
    private readonly ISkillsProvider _skillsProvider;
    private readonly ISKFunction _isThrereSwTaskFunc;

    [Obsolete("Use default planner")]
    private readonly ISKFunction _taskPlanFunc;
    private readonly ISKFunction _chatFunc;
    #endregion

    #region Consts
    private const string IsThereSwTask =
        """
        SolidWorks has some funcations listed:
        1.Create part,assembly,drawing and modify some settings.
        2.Sketch s