using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratory_2.Data.Models.Data
{
    public class ECleaningServiceManager : EPerson
    {
        [ForeignKey("AssignedECleaningServiceWorkersKeys")]
        public Guid[] AssignedECleaningServiceWorkers { get; set; }
        public ECleaningServiceManager(int id, string firstName, string secondName, Guid[] assignedECleaningServiceWorkers) : base(id, firstName, secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            AssignedECleaningServiceWorkers = assignedECleaningServiceWorkers;
        }
    }
}
