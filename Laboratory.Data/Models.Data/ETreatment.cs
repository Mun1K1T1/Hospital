using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratory_2.Data.Models.Data
{
    public class ETreatment : EEntity
    {
        [ForeignKey("Patient_key")]
        public Guid PatientKey { get; set; }

        [ForeignKey("Doctor_key")]
        public Guid DoctorKey { get; set; }

        public string PatientFirstName { get; set; }

        public string PatientSecondName { get; set; }

        public string TreatmentContent { get; set; }

    }
}
