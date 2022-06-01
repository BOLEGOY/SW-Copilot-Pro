﻿using System.Collections.Generic;
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
        