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
        SkillDir =