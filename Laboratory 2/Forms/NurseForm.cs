using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class NurseForm : MaterialForm
    {
        public NurseForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
                );
        }

        public static string patientSubPath = @"C:\\DataBase\PatientData\";
        public static string treatSubPath = @"C:\\DataBase\TreatmentData\";

        readonly FileOperations fileOperations = new FileOperations();
        //------------------------------------------------------------------------------------------
        private void AddItemsPatientsListview(/*string patAdress*/)
        {
            //string[] names = fileOperations.GetPatientsNames(fileOperations.FindPatientsFiles(patAdress));
            //for (int i = 0; i < names.Length; i++) PatientsListBox.Items.Add(names[i]);
            try
            {
                var context = new DBApplicationContext();
                    var query = from patient in context.Patients
                                orderby patient.FirstName ascending
                                select new { patient.FirstName, patient.SecondName };
                    foreach (var patient in query) PatientsListBox.Items.Add(patient.FirstName + " " + patient.SecondName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        //------------------------------------------------------------------------------------------
        private void DeletePatient()
        {
                try
                {
                    try
                    {
                        var context = new DBApplicationContext();
                        var preExPatient = Repository<EPatient>
                            .GetRepo(context)
                            .GetFirst(patient => patient.FirstName + patient.SecondName == PatientFirstNameTxb.Text + PatientSecNameTxb.Text);
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
                                .GetFirst(treatment => treatment.PatientFirstName + treatment.PatientSecondName == PatientFirstNameTxb.Text + PatientSecNameTxb.Text);
                            if (preExTreatment != null)
                            {
                                Guid treatGuid = preExTreatment.Key;
                                Repository<ETreatment>
                                    .GetRepo(context)
                                    .Delete(treatGuid);
                                MessageBox.Show("Patient's treatment was deleted!");
                            }
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred - \n" + ex);
                }
        }

        public async Task<string> TreatmentTextAcquire()
        {
            using (var context = new DBApplicationContext())
            {
                var query = from treatment in context.Treatments
                            where treatment.PatientFirstName == PatientFirstNameTxb.Text
                            where treatment.PatientSecondName == PatientSecNameTxb.Text
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
            //return query.FirstOrDefault()?.TreatmentContent;
        }

        private async void NurseForm_Load(object sender, EventArgs e)
        {
            NurNameTbx.Text = await fileOperations.ReadTempJson();
            await fileOperations.ClearTempDir();
            AddItemsPatientsListview();
        }

        private async void PatientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string patientFullName = PatientsListBox.SelectedItem.ToString();
            string[] patientNameElements = patientFullName.Split(' ');
            PatientFirstNameTxb.Text = patientNameElements[0];
            PatientSecNameTxb.Text = patientNameElements[1];

            TreatmentTxtBx.Clear();

            string treatmentText = await TreatmentTextAcquire();
            if (treatmentText != null) TreatmentTxtBx.AppendText(treatmentText);
            else TreatmentTxtBx.Text = "No content available";
            //string[] treatmentContext = fileOperations.FillTheTreatment(treatSubPath, patientNameElements[0], patientNameElements[1]);
            //if (treatmentContext != null)
            //{
            //    foreach (string element in treatmentContext)
            //    {
            //        TreatmentTxtBx.AppendText(element + Environment.NewLine);
            //    }
            //}
            //else
            //{
            //    TreatmentTxtBx.Text = "No treatment content available.";
            //}



        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            //fileOperations.DischargePatient(patientSubPath, treatSubPath, PatientFirstNameTxb.Text, PatientSecNameTxb.Text);
            try
            {
                DeletePatient();
                PatientsListBox.Items.Clear();
                TreatmentTxtBx.Text = String.Empty;
                AddItemsPatientsListview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }

        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            //fileOperations.PerformTreatment(patientSubPath, treatSubPath, PatientFirstNameTxb.Text, PatientSecNameTxb.Text);
            try
            {
                DeletePatient();
                PatientsListBox.Items.Clear();
                TreatmentTxtBx.Text = String.Empty;
                AddItemsPatientsListview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
                Close();
                MainPage.form1Main.Show();
        }
    }
}
