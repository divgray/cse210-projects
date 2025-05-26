using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Sets the word to hidden state
    public void Hide()
    {
        _isHidden = true;
    }

    // Getter for the hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the word's display text: either the actual word or underscores
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
