
﻿using Copilot.Sw.Skills;
using Copilot.Sw.Skills.SketchSkill;
using Microsoft.SemanticKernel.CoreSkills;
using Microsoft.SemanticKernel.KernelExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Copilot.SwTests.Skills;

[TestClass]
public class CreateSketchSegmentSkillTest
{
    [TestMethod]
    public async Task Test()
    {
        var kernel = StandandAloneSw.S_Instance.InitKernel();

        var skill = kernel.ImportSemanticSkillFromDirectory(
            new SkillsProvider().SkillsLocation,
            "SketchSkill");

        var result = await kernel.RunAsync(
            "我需要在SolidWorks草图中绘制10个直径为100的圆，竖直排列，间距10",
            skill["CreateSketchSegment"]);

        Console.WriteLine(result);
    }

    //[TestMethod]
    //public async Task PlanTest()
    //{
    //    var kernel = StandandAloneSw.S_Instance.InitKernel();