using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = "2015";
        job1._endYear = "2018";
      

        Job job2 = new Job();
        job2._company = "Google";
        job2._jobTitle = "Cloud Engineer";
        job2._startYear = "2018";
        job2._endYear = "2021";
       

        Job job3 = new Job();
        job3._company = "Amazon";
        job3._jobTitle = "Devops Engineer";
        job3._startYear = "2021";
        job3._endYear = "Present";
       

        Resume myResume = new Resume();
        myResume._name = "Bruno Martin";
        
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.ShowResume();
    }
}