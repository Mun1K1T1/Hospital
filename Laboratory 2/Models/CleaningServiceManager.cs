using System;

namespace Laboratory_2.Models
{
    public class CleaningServiceManager : Person
    {
        public string AssignedCleaningServiceWorkers { get; set; }

        public CleaningServiceManager(string id, string firstName, string secondName, string assignedECleaningServiceWorkers = null) : base(id, firstName, secondName)
        {
            AssignedCleaningServiceWorkers = assignedECleaningServiceWorkers;
        }
    }
}
