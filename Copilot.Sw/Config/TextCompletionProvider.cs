using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Copilot.Sw.Config;

public class TextCompletionProvider:ITextCompletionProvider
{
    public string SaveLocation { get; set; }

    public string FilePathName => Path.Combine(SaveLocation, "settings.json");

    public TextCompletionProvider()
    {
        SaveLocation = Path.Combine(
            Environment.GetFolderPath(Environ