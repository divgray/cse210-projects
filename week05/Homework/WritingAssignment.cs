using System;
public class WritingAssignment : Assignment
{
    // Additional member variable specific to writing assignments
    private string _title;

    // Constructor that uses the base constructor for the common attributes
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Returns the information.
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }
}