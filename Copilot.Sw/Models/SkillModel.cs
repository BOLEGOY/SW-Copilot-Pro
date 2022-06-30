using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Copilot.Sw.Models;

/// <summary>
/// AI Skill
/// </summary>
public class SkillModel
{
    /// <summary>
    /// Create a skill model for ui present
    /// </summary>
    /// <param name="location">propmpt file pathName</param>
    public SkillModel(string skillDir)
    {
        SkillDir = skillDir;
        Name = new DirectoryInfo(skillDir).Name;

        var files = Directory.GetFiles(skillDir, "*.txt", SearchOption.AllDirectories)
            .Where(f => Path.GetFileNameWithoutExtension(f).EndsWith("skprompt"));

        SemanticFunctions = files
            .Select(p => new LocalSemanticFunctionModel(p,Name,skillDir))
            .ToList();

        var configPathName = Path.Combine(skillDir, "config.json");
        if (File.Exists(configPathName))
        {
            Con