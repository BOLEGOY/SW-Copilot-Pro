﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Copilot.Sw.Config.Tests;

[TestClass()]
public class TextCompletionProviderTests
{
    [TestMethod()]
    public ITextCompletionProvider TextCompletionProviderTest()
    {
        var provider = new TextCompletionProvider();
        Assert.IsNotNull(provider);
        return provider;
    }

    [TestMethod()]
    public void ConfigTest()
    {
        var provider = TextCompletionProviderTest();

        var configs = provider.Load();

        provider.Wirte(new List<TextCompletionConfig>()
    