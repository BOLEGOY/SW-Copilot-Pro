using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

namespace Copilot.Sw.Skills.SolidWorksSkill;

public class DocumentCreatationSkill:SldWorksSkillContext
{
    //[SKFunction("SolidWorks document creation or modify settings skill")]
    //[SKFunctionName("SolidWorks")]
    //public void SolidWorksLevelPlan(SKContext context)
    //{

    //}

    [SKFunction("Create a solidworks's part doucment")]