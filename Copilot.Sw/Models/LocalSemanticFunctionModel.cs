using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Copilot.Sw.Models;

/// <summary>
/// 本地语义函数
/// </summary>
public class LocalSemanticFunctionModel
{
    public LocalSemanticFunctionModel(string pathName,string category, string skillDir)
    {
        PathName = pathName;
        Category = category;
        SkillDir = skillDir;
        Name = new DirectoryInfo(Path.GetDirectoryName(pathName)).Name;

        var configFile = Path.Combine(
            Path.GetDirectoryName(pathName),
            "config.json");

        if (File.Exists(configFile))
        {
            var data = File.ReadAllText(configFile);

            var dic = JsonSerializer.Deserialize<Dictionary<string, object>>(data);
            if (dic?.TryGetValue("description", out var value)