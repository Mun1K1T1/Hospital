using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class NurseForm : MaterialForm
    {
        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();

        //------------------------------------------------------------------------------------------

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

        //------------------------------------------------------------------------------------------

        private async void NurseForm_Load(object sender, EventArgs e)
        {
            try
            {
                NurNameTbx.Text = await fileOperations.ReadTempJson();
                dataHelper.AddNurseKeyToTheForm(NurNameTbx, Nurse_Key);
                fileOperations.ClearTempDir();
                dataHelper.AddItemsPatientsListview(PatientsListBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        private async void PatientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (PatientsListBox.SelectedItem != null)
                {
                    string patientFullName = PatientsListBox.SelectedItem.ToString();
                    string[] patientNameElements = patientFullName.Split(' ');
                    PatientFirstNameTxb.Text = patientNameElements[0];
                    PatientSecNameTxb.Text = patientNameElements[1];
                    Patient_Key.Text = patientNameElements[2];
                }

                TreatmentTxtBx.Clear();

                string treatmentText = await dataHelper.TreatmentTextAcquire(PatientFirstNameTxb, PatientSecNameTxb);
                if (treatmentText != null) TreatmentTxtBx.AppendText(treatmentText);
                else TreatmentTxtBx.Text = "No content available";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        private void PerformBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dataHelper.DeletePatient(PatientFirstNameTxb, PatientSecNameTxb);
                PatientsListBox.Items.Clear();
                TreatmentTxtBx.Text = String.Empty;
                dataHelper.AddItemsPatientsListview(PatientsListBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }

        }

        private void DischargeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dataHelper.DeletePatient(PatientFirstNameTxb, PatientSecNameTxb);
                PatientsListBox.Items.Clear();
                TreatmentTxtBx.Text = String.Empty;
                dataHelper.AddItemsPatientsListview(PatientsListBox);
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
