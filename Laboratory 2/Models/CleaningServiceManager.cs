using System;

namespace Laboratory_2.Models
{
    public class CleaningServiceManager : Person
    {
        public Guid[] AssignedCleaningServiceWorkers { get; set; }

        public CleaningServiceManager(string id, string firstName, string secondName, Guid[] assignedECleaningServiceWorkers) : base(id, firstName, secondName)
        {
            AssignedCleaningServiceWorkers = assignedECleaningServiceWorkers;
        }
    }
}
