using Laboratory_2.Data.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2.Repositories
{
    internal class DataHelper
    {
        readonly FileOperations fileOperations = new FileOperations();

        public async Task OnPlacePatientCreation(DBApplicationContext dBApplicationContext, EPatient newEPatient, TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            try
            {
                Repository<EPatient>
                    .GetRepo(dBApplicationContext)
                    .Create(newEPatient);
                MessageBox.Show("Success!");

                await fileOperations.CloseAndOpenPatient(Id, FirstName, SecondName, This);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.ToString());
                return;
            }
        }
        public async Task OnPlaceDoctorCreation(DBApplicationContext dBApplicationContext, EDoctor newEDoctor, TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            try
            {
                Repository<EDoctor>
                    .GetRepo(dBApplicationContext)
                    .Create(newEDoctor);
                MessageBox.Show("Success!");

                await fileOperations.CloseAndOpenDoctor(Id, FirstName, SecondName, This);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.ToString());
                return;
            }
        }

        public async Task OnPlaceNurseCreation(DBApplicationContext dBApplicationContext, ENurse newENurse, TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            try
            {
                Repository<ENurse>
                    .GetRepo(dBApplicationContext)
                    .Create(newENurse);
                MessageBox.Show("Success!");

                await fileOperations.CloseAndOpenNurse(Id, FirstName, SecondName, This);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.ToString());
                return;
            }
        }

        public async Task OnPlaceCleaningWorkerCreation(DBApplicationContext dBApplicationContext, EPerson newEPerson, TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            try
            {
                Repository<EPerson>
                    .GetRepo(dBApplicationContext)
                    .Create(newEPerson);
                MessageBox.Show("Success!");

                await fileOperations.CloseAndOpenCleaningWorker(Id, FirstName, SecondName, This);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.ToString());
                return;
            }
        }

        public async Task OnPlaceCleaningManagerCreation(DBApplicationContext dBApplicationContext, EPerson newEPerson, TextBox Id, TextBox FirstName, TextBox SecondName, Form This)
        {
            try
            {
                Repository<EPerson>
                    .GetRepo(dBApplicationContext)
                    .Create(newEPerson);
                MessageBox.Show("Success!");

                await fileOperations.CloseAndOpenCleaningManager(Id, FirstName, SecondName, This);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.ToString());
                return;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public void AddItemsPatientsListview(ListBox listBox)
        {
            try
            {
                var context = new DBApplicationContext();
                var query = from patient in context.Patients
                            orderby patient.FirstName ascending
                            select new { patient.FirstName, patient.SecondName, patient.Key };
                foreach (var patient in query)
                {
                    listBox.Items.Add(patient.FirstName + " " + patient.SecondName + " " + patient.Key.ToString());
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        public void AddItemsCleaningWorkersListview(ListBox listBox)
        {
            try
            {
                var context = new DBApplicationContext();
                var query = from worker in context.CleaningServiceWorkers
                            orderby worker.FirstName ascending
                            select new { worker.FirstName, worker.SecondName, worker.Key };
                foreach (var worker in query)
                {
                    listBox.Items.Add(worker.FirstName + " " + worker.SecondName + " " + worker.Key.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public void DeletePatient(TextBox PatientFirstName, TextBox PatientSecondName)
        {
            try
            {
                var context = new DBApplicationContext();
                var preExPatient = Repository<EPatient>
                    .GetRepo(context)
                    .GetFirst(patient => patient.FirstName + patient.SecondName == PatientFirstName.Text + PatientSecondName.Text);
                if (preExPatient != null)
                {
                    Guid patGuid = preExPatient.Key;
                    Repository<EPatient>
                        .GetRepo(context)
                        .Delete(patGuid);
                    MessageBox.Show("Patient was deleted!");
                }
                else return;
                try
                {
                    var preExTreatment = Repository<ETreatment>
                        .GetRepo(context)
                        .GetFirst(treatment => treatment.PatientFirstName + treatment.PatientSecondName == PatientFirstName.Text + PatientSecondName.Text);
                    if (preExTreatment != null)
                    {
                        Guid treatGuid = preExTreatment.Key;
                        Repository<ETreatment>
                            .GetRepo(context)
                            .Delete(treatGuid);
                        MessageBox.Show("Patient's treatment was deleted!");
                    }
                    else return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete patient's treatment - \n" + ex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete patient - \n" + ex);
            }
        }

        public void DeletePatient(TextBox patientName)
        {
            string patientFullName = patientName.Text;
            string[] patientNameElements = patientFullName.Split(' ');
            string patientFirstName = patientNameElements[0];
            string patientSecondName = patientNameElements[1];
            try
            {
                var context = new DBApplicationContext();
                var preExPatient = Repository<EPatient>
                        .GetRepo(context)
                        .GetFirst(patient => patient.FirstName + patient.SecondName == patientFirstName + patientSecondName);
                if (preExPatient != null)
                {
                    Guid patGuid = preExPatient.Key;
                    Repository<EPatient>
                        .GetRepo(context)
                        .Delete(patGuid);
                    MessageBox.Show("Patient was deleted!");
                }
                try
                {
                    var preExTreatment = Repository<ETreatment>
                        .GetRepo(context)
                        .GetFirst(treatment => treatment.PatientFirstName + treatment.PatientSecondName == patientFirstName + patientSecondName);
                    if (preExTreatment != null)
                    {
                        Guid treatGuid = preExTreatment.Key;
                        Repository<ETreatment>
                            .GetRepo(context)
                            .Delete(treatGuid);
                        MessageBox.Show("Patient's treatment was deleted!");
                        patientName.Text = String.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete patient's treatment - \n" + ex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public async void AddPatientKeyToTheForm(TextBox Name, Label label)
        {
            try
            {
                string fullName = Name.Text;
                string[] nameParts = fullName.Split(' ');
                string patFirstName = nameParts[0];
                string patSecondName = nameParts[1];
                int patId = Convert.ToInt16(fileOperations.ReadTempJsonId());
                var context = new DBApplicationContext();
                var query = from patient in context.Patients
                            where patient.Id == patId
                            where patient.FirstName == patFirstName
                            where patient.SecondName == patSecondName
                            select new { patient.Key };
                var foundKey = await query.FirstOrDefaultAsync();
                if (foundKey != null)
                {
                    label.Text = Convert.ToString(foundKey.Key);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        public async void AddDoctorKeyToTheForm(TextBox Name, Label label)
        {
            try
            {
                string fullName = Name.Text;
                string[] nameParts = fullName.Split(' ');
                string docFirstName = nameParts[0];
                string docSecondName = nameParts[1];
                int patId = Convert.ToInt16(fileOperations.ReadTempJsonId());
                var context = new DBApplicationContext();
                var query = from doctor in context.Doctors
                            where doctor.Id == patId
                            where doctor.FirstName == docFirstName
                            where doctor.SecondName == docSecondName
                            select new { doctor.Key };
                var foundKey = await query.FirstOrDefaultAsync();
                if (foundKey != null)
                {
                    label.Text = Convert.ToString(foundKey.Key);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        public async void AddNurseKeyToTheForm(TextBox Name, Label label)
        {
            try
            {
                string fullName = Name.Text;
                string[] nameParts = fullName.Split(' ');
                string nurFirstName = nameParts[0];
                string nurSecondName = nameParts[1];
                int patId = Convert.ToInt16(fileOperations.ReadTempJsonId());
                var context = new DBApplicationContext();
                var query = from nurse in context.Nurses
                            where nurse.Id == patId
                            where nurse.FirstName == nurFirstName
                            where nurse.SecondName == nurSecondName
                            select new { nurse.Key };
                var foundKey = await query.FirstOrDefaultAsync();
                if (foundKey != null)
                {
                    label.Text = Convert.ToString(foundKey.Key);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        public async void AddCleaningManagerKeyToTheForm(TextBox Name, Label label)
        {
            try
            {
                string fullName = Name.Text;
                string[] nameParts = fullName.Split(' ');
                string cleanManagerFirstName = nameParts[0];
                string cleanManagerSecondName = nameParts[1];
                int cleanManagerId = Convert.ToInt16(fileOperations.ReadTempJsonId());
                var context = new DBApplicationContext();
                var query = from manager in context.CleaningServiceManagers
                            where manager.Id == cleanManagerId
                            where manager.FirstName == cleanManagerFirstName
                            where manager.SecondName == cleanManagerSecondName
                            select new { manager.Key };
                var foundKey = await query.FirstOrDefaultAsync();
                if (foundKey != null)
                {
                    label.Text = Convert.ToString(foundKey.Key);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        public async void AddCleaningWorkerKeyToTheForm(TextBox Name, Label label)
        {
            try
            {
                string fullName = Name.Text;
                string[] nameParts = fullName.Split(' ');
                string cleanWorkerFirstName = nameParts[0];
                string cleanWorkerSecondName = nameParts[1];
                int cleanWorkerId = Convert.ToInt16(fileOperations.ReadTempJsonId());
                var context = new DBApplicationContext();
                var query = from worker in context.CleaningServiceWorkers
                            where worker.Id == cleanWorkerId
                            where worker.FirstName == cleanWorkerFirstName
                            where worker.SecondName == cleanWorkerSecondName
                            select new { worker.Key };
                var foundKey = await query.FirstOrDefaultAsync();
                if (foundKey != null)
                {
                    label.Text = Convert.ToString(foundKey.Key);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public void SaveTreatmentContent(TextBox treatTxtBx, Label patKeyLab, Label docKeyLab, TextBox patFName, TextBox patSName)
        {
            try
            {
                string treatCont = treatTxtBx.Text;
                using (var context = new DBApplicationContext())
                {
                    var newTreatment = new ETreatment
                    {
                        PatientKey = Guid.Parse(patKeyLab.Text),
                        DoctorKey = Guid.Parse(docKeyLab.Text),
                        PatientFirstName = patFName.Text,
                        PatientSecondName = patSName.Text,
                        TreatmentContent = treatCont
                    };
                    Repository<ETreatment>
                        .GetRepo(context)
                        .Create(newTreatment);
                    MessageBox.Show("Treatment successfully submited!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        public async Task<string> TreatmentTextAcquire(TextBox patFName, TextBox patSecName)
        {
            using (var context = new DBApplicationContext())
            {
                var query = from treatment in context.Treatments
                            where treatment.PatientFirstName == patFName.Text
                            where treatment.PatientSecondName == patSecName.Text
                            select new { treatment.TreatmentContent };

                var foundTretment = await query.FirstOrDefaultAsync();
                if (foundTretment != null)
                {
                    return foundTretment.TreatmentContent;
                }
                else
                {
                    return "No treatment found";
                }
            }
        }
    }
}
