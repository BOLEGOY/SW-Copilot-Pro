using Copilot.Sw.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Copilot.Sw.Skills;

public class SkillsProvider : ISkillsProvider
{
    ///<inheritdoc/>
    public string SkillsLocation { get; }

    public SkillsProvider()
    {
        SkillsLocation = Path.Combine(
            Path.GetDirectoryName(typeof(SkillsProvider).Assembly.Location), 
            "Skills");
    }

    public SkillsProvider(string skilldi