using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        float grade = float.Parse(Console.ReadLine());
        string letterGrade;

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"You earned a(n) {letterGrade} grade.");

        if (letterGrade != "F")
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Great Attempt! Although you failed this time, I am sure you will pass this course on your next attempt with the experience you now have. Stay motivated.");
        }
    }
}