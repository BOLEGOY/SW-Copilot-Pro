using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Copilot.Sw.Config.Tests;

[TestClass()]
public class TextCompletionProviderTests
{
    [TestMethod()]
    public ITextCompletionProvider TextCompletionProviderTest()
    {
        var provider