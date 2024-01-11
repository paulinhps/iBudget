using iBudget.Framework;
using iBudget.Framework.Helpers;

namespace iBudget.UnitTest.Extensions;

public class StringHelpersTest
{
    [Fact]
    public void ShouldFindAccentWord()
    {
        const string wordToFind = "acentuacoes";
        const string accentSentence = "Uma palavra com acentuações";

        var accentWord = accentSentence;
        var foundWord = accentWord.Contains(wordToFind);
        Assert.False(foundWord);

        var unaccentWord = accentWord.Unaccent();
        var foundWordUnaccent = unaccentWord.Contains(wordToFind);
        Assert.True(foundWordUnaccent);
    }
}