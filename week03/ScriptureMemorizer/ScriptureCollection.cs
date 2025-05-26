using System;
using System.Collections.Generic;

public class ScriptureCollection // Manage and organizes multiple Scripture objects. Lets you pick a scripture to work with, but each scripture comes fully formed with its own reference information.
{
    // Private list to hold multiple Scripture objects
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureCollection()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();
    }

    // Add a Scripture verse to the collection
    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    // Retrieve a Scripture by index
    public Scripture GetScripture(int index)
    {
        if (index >= 0 && index < _scriptures.Count)
        {
            return _scriptures[index];
        }
        throw new ArgumentOutOfRangeException("Invalid scripture index.");
    }

    // Get a random Scripture from the collection
    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
