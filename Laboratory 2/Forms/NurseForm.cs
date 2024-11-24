using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class NurseForm : MaterialForm, IForm
    {
        private readonly IFileOperations _fileOperations;
        private readonly DataHelper _dataHelper;

        //------------------------------------------------------------------------------------------

        public void ShowForm()
        {
            Show();
        }

        public NurseForm(IFileOperations fileOperations, DataHelper dataHelper, DBApplicationContext dbContext)
        {
            _fileOperations = fileOperations ?? throw new ArgumentNullException(nameof(fileOperations));
            _dataHelper = dataHelper ?? throw new ArgumentNullException(nameof(dataHelper));

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
                NurNameTbx.Text = await _fileOperations.ReadTempJson();
                _dataHelper.AddNurseKeyToTheForm(NurNameTbx, Nurse_Key);
                await _fileOperations.ClearTempDir();
                _dataHelper.AddItemsPatientsListview(PatientsListBox);
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

                string treatmentText = await _dataHelper.TreatmentTextAcquire(PatientFirstNameTxb, PatientSecNameTxb);
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
                _dataHelper.DeletePatient(PatientFirstNameTxb, PatientSecNameTxb);
                PatientsListBox.Items.Clear();
                TreatmentTxtBx.Text = String.Empty;
                _dataHelper.AddItemsPatientsListview(PatientsListBox);
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
                _dataHelper.DeletePatient(PatientFirstNameTxb, PatientSecNameTxb);
                PatientsListBox.Items.Clear();
                TreatmentTxtBx.Text = String.Empty;
                _dataHelper.AddItemsPatientsListview(PatientsListBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            IForm form = FormFactory.CreateForm("MainPage");
            form.ShowForm();
            Close();
        }
    }
}
