using System.Windows.Forms;

namespace Laboratory_2.Models
{
    internal class Treatment : Entity
    {
        public string PatientFirstName { get; set; }
        public string PatientSecondName { get; set; }
        public string[] TreatmentContent { get; set; }

        public Treatment(string patientFirstName, string patientSecondName, string[] treatmentContent)
        {
            PatientFirstName = patientFirstName;
            PatientSecondName = patientSecondName;
            TreatmentContent = treatmentContent;
        }
    }
}
