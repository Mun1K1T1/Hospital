using Laboratory_2.Data.Models.Data;
using Laboratory_2.Forms;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class PatientForm : MaterialForm
    {
        public PatientForm()
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

        public string patientName;
        public static string patientSubPath = @"C:\\DataBase\PatientData\";
        public static string treatSubPath = @"C:\\DataBase\TreatmentData\";

        readonly FileOperations fileOperations = new FileOperations();

        //------------------------------------------------------------------------------------------
        public async Task FillTheTreatmentTxtBox(string subPath, string firstName, string secondName)
        {
            string path = (subPath + firstName + " " + secondName + ".json");
            if (!File.Exists(path))
            {
                MessageBox.Show("This pathient didn't get medical direction!");
            }
            else
            {
                string jsonContent = await fileOperations.ReadJsonFromFile(treatSubPath, firstName, secondName);
                string[] treatment = await fileOperations.GetUserTreatmentContent(jsonContent);
                TreatmentTxtBx.Text = String.Join("\n", treatment);

            }
        }

        public async Task<string> TreatmentTextAcquire()
        {
            string patientFullName = PatientNameTbx.Text;
            string[] patientNameElements = patientFullName.Split(' ');
            string patientFirstName = patientNameElements[0];
            string patientSecondName = patientNameElements[1];
            using (var context = new DBApplicationContext())
            {
                var query = from treatment in context.Treatments
                            where treatment.PatientFirstName == patientFirstName
                            where treatment.PatientSecondName == patientSecondName
                            select new { treatment.TreatmentContent };
                //return query.FirstOrDefault()?.TreatmentContent;
                var result = await query.FirstOrDefaultAsync();
                return result?.TreatmentContent;
            }
        }

        private void DeletePatient()
        {
            string patientFullName = PatientNameTbx.Text;
            string[] patientNameElements = patientFullName.Split(' ');
            string patientFirstName = patientNameElements[0];
            string patientSecondName = patientNameElements[1];
                try
                {
                    using (var context = new DBApplicationContext())
                    {
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
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to delete patient's treatment - \n" + ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred - \n" + ex);
                }
        }

        //------------------------------------------------------------------------------------------
        private async void PatientForm_Load(object sender, EventArgs e)
        {
            PatientNameTbx.Text = await fileOperations.ReadTempJson();
            await fileOperations.ClearTempDir();
            try
            {
                //FillTheTreatmentTxtBox(treatSubPath, AuthorizationPatient.patRegInst.fNameTB.Text, AuthorizationPatient.patRegInst.sNameTB.Text);
                string treatmentText = await TreatmentTextAcquire();
                if (treatmentText != null) TreatmentTxtBx.AppendText(treatmentText);
                else TreatmentTxtBx.Text = "No content available";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }

        private void DischargeBtn_Click(object sender, EventArgs e)
        {
            DeletePatient();
            //fileOperations.DischargePatient(patientSubPath, treatSubPath, patientFirstName, patientSecondName);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
                Hide();
                MainPage.form1Main.Show();
        }
    }
}
