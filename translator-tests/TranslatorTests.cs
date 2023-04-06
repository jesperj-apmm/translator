using System.Runtime.CompilerServices;
using codesession;
using FluentAssertions;

namespace codesession_tests;

public class TranslatorTests
{
    [Fact]
    public void CanTranslateSingleWordToCodedLang()
    {

        var word = "hello";
        var codedWord = "ellohay";

        var traslator = new Translator();

        traslator
            .TranslateWord(word)
            .Should()
            .Be(codedWord);


    }

    [Theory]
    [InlineData("apple", "appleay")]
    [InlineData("eat", "eatay")]
    [InlineData("idea", "ideaay")]
    public void CanTranslateWithVovels(string word, string expectedResult)
    {
        var translator = new Translator();
        translator
            .TranslateWord(word)
            .Should()
            .Be(expectedResult);
    }

    [Theory]
    [InlineData("hello", "ellohay")]
    [InlineData("Hello", "Ellohay")]
    public void CanHonorUpperCaseFirstChar(string word, string expectedResult)
    {
        var translator = new Translator();
        translator
            .TranslateWord(word)
            .Should()
            .Be(expectedResult);
    }

    [Fact]
    public void CanHandleSentences()
    {
        var sentence = "Hello apple";
        var expectedResult = "Ellohay appleay";
        
        var translator = new Translator();
        translator
            .TranslateWord(sentence)
            .Should()
            .Be(expectedResult);
    }
}