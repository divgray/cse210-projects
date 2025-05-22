using System;

class Program
{
    static void Main(string[] args)
    {
        // first job
        Job job1 = new Job();
        job1.job_title = "Software Engineer";
        job1.company = "Microsoft";
        job1.start_year = 2019;
        job1.end_year = 2022;

        //second job
        Job job2 = new Job();
        job2.job_title = "Manager";
        job2.company = "Apple";
        job2.start_year = 2022;
        job2.end_year = 2023;

        Resume my_resume = new Resume();
        my_resume.name = "Allison Rose";

        my_resume.jobs.Add(job1);
        my_resume.jobs.Add(job2);
        my_resume.Display();
    }
}