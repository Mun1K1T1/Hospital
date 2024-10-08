namespace Laboratory_2.Models
{
    public class CleaningServiceWorker : Person
    {
        public bool IsWorking { get; set; }

        public CleaningServiceWorker(string id, string firstName, string secondName, bool isWorking) : base(id, firstName, secondName)
        {
            IsWorking = isWorking;
        }
    }
}
