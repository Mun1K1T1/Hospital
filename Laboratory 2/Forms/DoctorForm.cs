using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class DoctorForm : MaterialForm, IForm
    {
        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();
        //------------------------------------------------------------------------------------------

        public void ShowForm()
        {
            this.Show();
        }

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

        private async void DoctorForm_Load(object sender, EventArgs e)
        {
            try
            {
                DocNameTbx.Text = await fileOperations.ReadTempJson();
                dataHelper.AddDoctorKeyToTheForm(DocNameTbx, Doctor_Key);
                fileOperations.ClearTempDir();
                dataHelper.AddItemsPatientsListview(PatientsListBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }
        private void PatientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(PatientsListBox.SelectedItem != null)
                {
                    string patientFullName = PatientsListBox.SelectedItem.ToString();
                    string[] patientNameElements = patientFullName.Split(' ');
                    PatientFirstNameTxb.Text = patientNameElements[0];
                    PatientSecNameTxb.Text = patientNameElements[1];
                    Patient_Key.Text = patientNameElements[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        private void TreatmentSubmissionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dataHelper.SaveTreatmentContent(TreatmentTxtBx, Patient_Key, Doctor_Key, PatientFirstNameTxb, PatientSecNameTxb);
                TreatmentTxtBx.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred - \n" + ex);
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Hide();
            MainPage.form1Main.Show();
        }
    }
}
