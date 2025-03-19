public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public string _startYear = "";
    public string _endYear = "";

    public Job()
    {

    }

    public void ShowJobInfo()
    {
        Console.Write($"{_jobTitle} ({_company}) {_startYear} - {_endYear}");
    }

}
