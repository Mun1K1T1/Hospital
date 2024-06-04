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
    public partial class PatientForm : MaterialForm
    {
        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();

        //------------------------------------------------------------------------------------------

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

        //------------------------------------------------------------------------------------------

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
                            where treatment.PatientKey.ToString() == Patient_Key.Text
                            select new { treatment.TreatmentContent };
                var result = await query.FirstOrDefaultAsync();
                return result?.TreatmentContent;
            }
        }

        //------------------------------------------------------------------------------------------
        private async void PatientForm_Load(object sender, EventArgs e)
        {
            try
            {
                PatientNameTbx.Text = await fileOperations.ReadTempJson();
                dataHelper.AddPatientKeyToTheForm(PatientNameTbx, Patient_Key);
                fileOperations.ClearTempDir();
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
            try
            {
                dataHelper.DeletePatient(PatientNameTbx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Hide();
            MainPage.form1Main.Show();
        }
    }
}
