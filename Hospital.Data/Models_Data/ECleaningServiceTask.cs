using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Data.Models_Data
{
    public class ECleaningServiceTask : EEntity
    {
        [ForeignKey("AssignedCleaningServiceManager_Key")]
        public string AssignedCleaningServiceManager { get; set; }
        [ForeignKey("AssignedCleaningServiceWorkers_Key")]
        public string AssignedCleaningServiceWorker { get; set; }
        public string CleaningTask {get; set;}

        public ECleaningServiceTask(string assignedCleaningServiceManager, string assignedCleaningServiceWorker, string cleaningTask) 
        {
            AssignedCleaningServiceManager = assignedCleaningServiceManager;
            AssignedCleaningServiceWorker = assignedCleaningServiceWorker;
            CleaningTask = cleaningTask;
        }
    }
}
