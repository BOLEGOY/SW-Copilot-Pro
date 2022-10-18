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
        2.Sketch some sketch segment,such as line,arc,spline,slot.

        Determine whether the input is a function that can be performed in SolidWorks.

        BEGIN CONTENT TO SUMMARIZE:
        {{$INPUT}}
        END CONTENT TO SUMMARIZE.
        
        Answer with Y or N.
        """;

    private const string Chat =
        """
        You are an AI SolidWorks assistant.Your responses should be professional and helpful.
        {{$INPUT}}
        """;

    public static class Parameters
    {
        public const string ChatWithSolidWorks = nameof(ChatWithSolidWorks);
    }
    #endregion

    #region Ctor
    public SolidWorksPlanSkill(
        IKernel kernel,
        ISkillsProvider skillsProvider,
        int maxTokens = 1024)
    {
        _kernel = kernel;
        _skillsProvider = skillsProvider;

        _isThrereSwTaskFunc = kernel.CreateSemanticFunction(
            IsThereSwTask,
            "ChatOrTask",
            maxTokens: maxTokens,
            temperature:0d
            );

        var taskPlanPrompt = string.Format(SwSkillSelection.SemanticFuncation, SwSkillSelection.GetAvailavleSkills(_skillsProvider));
        _taskPlanFunc = kernel.CreateSemanticFunction(
            taskPlanPrompt,
            "SolidWorksTaskPlan",
            maxTokens:maxTokens,
            temperature:0.5d
            );

        _chatFunc = kernel.CreateSemanticFunction(
            Chat,
            "Chat",
            maxTokens: maxTokens,
            temperature: 0.8
            );
    }
    #endregion

    #region Methods
    [SKFunction("Chat with SolidWorks,parse solidworks perform tasks if there is a goal")]
    [SKFunctionName(Parameters.ChatWithSolidWorks)]
    public async Task<SKContext> ChatWithSolidWorks