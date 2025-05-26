using System;
using System.Collections.Generic;

public class Scripture // Handles one complete passage, using contained Reference to display the scriptures source along with its text
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        // Split the scripture text into words.
        string[] tokens = text.Split(' ');
        foreach (string token in tokens)
        {
            _words.Add(new Word(token));
        }
        _random = new Random();
    }

    // Returns the scriptures string representation: reference, then the text with words (hidden as needed)
    public override string ToString()
    {
        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return _reference.ToString() + "\n" + scriptureText.TrimEnd();
    }

    // Stretch Challenge : try to randomly select from only those words that are not already hidden
    public void HideRandomWords(int count)
    {
        // Filter to get only visible words
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < count; i++)
        {
            // If no visible words remain, exit the loop
            if (visibleWords.Count == 0)
                break;

            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();

            // Refresh the list after hiding a word
            visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        }
    }


    // Checks if all words have been hidden.
    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
