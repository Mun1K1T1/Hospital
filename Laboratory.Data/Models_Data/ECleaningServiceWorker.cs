using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratory_2.Data.Models.Data
{
    public class ECleaningServiceWorker : EPerson
    {
        public bool IsWorking { get; set; }

        public ECleaningServiceWorker(int id, string firstName, string secondName, bool isWorking = false) : base(id, firstName, secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            IsWorking = isWorking;
        }
    }
}
