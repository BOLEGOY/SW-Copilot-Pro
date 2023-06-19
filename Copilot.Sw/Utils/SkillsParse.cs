
﻿using System.Xml;

namespace Copilot.Sw.Utils;

public static class SkillsParse
{
    public static (int,string) Parse(string output)
    {
        output = output.Trim();
        if (int.TryParse(output,out var value))