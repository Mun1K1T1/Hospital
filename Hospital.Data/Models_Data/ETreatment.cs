using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Data.Models_Data
{
    public class ETreatment : EEntity
    {
        [ForeignKey("Patient_key")]
        public Guid PatientKey { get; set; }

        [ForeignKey("Doctor_key")]
        public Guid DoctorKey { get; set; }

        public required string PatientFirstName { get; set; }

        public required string PatientSecondName { get; set; }

        public required string TreatmentContent { get; set; }

    }
}
