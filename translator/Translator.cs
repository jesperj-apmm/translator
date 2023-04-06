using System.Text;

namespace codesession;

public class Translator
{
    private readonly HashSet<string> _vovels;
    private readonly StringBuilder _builder;

    public Translator()
    {
        _vovels = new HashSet<string>
        {
            "a",
            "e",
            "i",
            "o",
            "u"
        };

        _builder = new StringBuilder();
    }

    public string TranslateWord(string word)
    {
        if (IsMultiWord(word))
            return TranslateSentence(word);
        
        return TranslateSingleWord(word);
    }

    private bool IsMultiWord(string word)
    {
        return word.Split(" ").Length > 1;
    }

    private string TranslateSentence(string words)
    {
        var cursor = 0;
        var wordsArray = words.Split(" ");
        var codedSentence = new string[wordsArray.Length];

        for (int i = 0; i < wordsArray.Length; i++)
        {
            codedSentence[i] = TranslateSingleWord(wordsArray[i]);
        }

        return string.Join(' ', codedSentence);
    }
    
    private string TranslateSingleWord(string word)
    {
        _builder.Clear();
        
        var firstChar = word.Substring(0, 1);
        var codedWord = string.Empty;

        if (_vovels.Contains(word.Substring(0, 1)))
            codedWord = TranslateWordsStartingWithVovels(word);
        else
            codedWord = TranslateWordStartingWithConsonant(word);


        if (IsCharUpperCase(firstChar))
        {
            codedWord = HonerUpperCaseFirstChar(firstChar, codedWord);
        }

        return codedWord;
    }
    
    private string HonerUpperCaseFirstChar(string firstChar, string codedWord)
    {
        var resultFirstChar = codedWord
            .Substring(0, 1)
            .ToUpper();

        _builder.Clear();

        var codedWordSubStr = codedWord.Substring(1, codedWord.Length - 1).ToLower();
            
        _builder
            .Append(resultFirstChar)
            .Append(codedWordSubStr);
            
        var word = _builder.ToString();

        return word;
    }

    private string TranslateWordStartingWithConsonant(string word)
    {
        var firstChar = word.Substring(0,1);
        
        _builder
            .Append(word.Substring(1, word.Length-1))
            .Append(firstChar)
            .Append("ay");
        
        return _builder.ToString();
    }
    
    private string TranslateWordsStartingWithVovels(string word)
    {
        _builder
            .Append(word)
            .Append("ay");
        return _builder.ToString();
    }

    private bool IsCharUpperCase(string c)
    {
        var upperCase = c.ToUpper();
        return upperCase.Equals(c);
    }
}