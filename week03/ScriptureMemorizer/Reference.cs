using System;

public class Reference // Responsible for the citation details.
{
    // Private member variables
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd;

    // Constructor for a single verse (for like given example 1)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    // Constructor for a verse range (given example 2)
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (_verseEnd.HasValue && _verseEnd.Value != _verseStart)
        {
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd.Value}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verseStart}";
        }
    }
}
