using System;
public class MathAssignment : Assignment
{
    // Additional member variables specific to math assignments
    private string _textbookSection;
    private string _problems;

    // Constructor that uses the base constructor to set student name and topic,
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        // Set the MathAssignment var.
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Returns the homework list.
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}