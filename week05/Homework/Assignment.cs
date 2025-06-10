using System;
public class Assignment
{
    // Use 'protected' so that derived classes can access these variables
    protected string _studentName;
    protected string _topic;

    // Constructor that initializes the common attributes
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Returns a summary combining the student name and topic. Shortcut.
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}