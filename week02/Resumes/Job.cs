using System;
public class Job
{
    public string company;
    public string job_title;
    public int start_year;
    public int end_year;

    public void Display()
    {
        Console.WriteLine($"{job_title} ({company}) {start_year}-{end_year}");
    }
}