using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class DoctorForm : MaterialForm
    {
        public static string treatSubPath = @"C:\\DataBase\TreatmentData\";

        readonly FileOperations fileOperations = new FileOperations();

        //------------------------------------------------------------------------------------------
        private void AddItemsPatientsListview() //string patAdress
        {
            //string[] names = fileOperations.GetPatientsNames(fileOperations.FindPatientsFiles(patAdress));
            //for (int i = 0; i < names.Length; i++)  PatientsListBox.Items.Add(names[i]);
            var context = new DBApplicationContext();
                    var query = from patient in context.Patients
                                orderby patient.FirstName ascending
                                select new { patient.FirstName, patient.SecondName };
                    foreach (var patient in query) PatientsListBox.Items.Add(patient.FirstName + " " + patient.SecondName);
        }

        public void SaveTreatmentContent()
        {
            try
            {
                string treatCont = TreatmentTxtBx.Text;
                using (var context = new DBApplicationContext())
                {
                        var newTreatment = new ETreatment
                        {
                            PatientFirstName = PatientFirstNameTxb.Text,
                            PatientSecondName = PatientSecNameTxb.Text,
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

        //public async Task<string[]> ReadTextboxToStringArray()
        //{
        //    string treatmentText = TreatmentTxtBx.Text.ToString();
        //    string[] textboxText = treatmentText.Split('\n');
        //    return await Task.FromResult(textboxText).ConfigureAwait(false);
        //}
        //------------------------------------------------------------------------------------------
        public DoctorForm()
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

        private async void DoctorForm_Load(object sender, EventArgs e) //-------------------------------------------------------------------------------------------------!!!!!!!!!!!!!!!!!!!!!!!!
        {
            DocNameTbx.Text = await fileOperations.ReadTempJson();
            await fileOperations.ClearTempDir();
            AddItemsPatientsListview();
        }
        private void PatientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                try
                {
                    string patientFullName = PatientsListBox.SelectedItem.ToString();
                    string[] patientNameElements = patientFullName.Split(' ');
                    PatientFirstNameTxb.Text = patientNameElements[0];
                    PatientSecNameTxb.Text = patientNameElements[1];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred - \n" + ex);
                }
        }

        private void TreatmentSubmissionBtn_Click(object sender, EventArgs e)
        {
            //fileOperations.TreatmentFileCreation(treatSubPath, PatientFirstNameTxb.Text, PatientSecNameTxb.Text, ReadTextboxToStringArray());
            try
            {
                SaveTreatmentContent();
                TreatmentTxtBx.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        private  void BackBtn_Click(object sender, EventArgs e)
        {
                Hide();
                MainPage.form1Main.Show();
        }
    }
}
