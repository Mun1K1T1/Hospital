namespace Laboratory_2.Data.Models.Data
{
    public class ECleaningServiceManager : EPerson
    {
        public ECleaningServiceManager(int id, string firstName, string secondName, bool isWorking) : base(id, firstName, secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
        }
    }
}
}
