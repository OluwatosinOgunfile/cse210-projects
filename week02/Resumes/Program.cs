using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._company = "Eye Foundation Hospital";
        job1._jobTitle = "Medical Records Officer";
        job1._startYear = 2011;
        job1._endYear = 2015;

        Job job2 = new Job();

        job2._company = "Summit Healthcare Limited";
        job2._jobTitle = "Biomed Technician";
        job2._startYear = 2017;
        job2._endYear = 2019;

        Resume myResume = new Resume();
        myResume._name = "Oluwatosin Ogunfile";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}