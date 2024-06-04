using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2.Forms
{
    public partial class AuthorizationPatient : MaterialForm
    {
        public const string patientSubPath = @"C:\\DataBase\PatientData\";

        readonly FileOperations fileOperations = new FileOperations();
        readonly DataHelper dataHelper = new DataHelper();
        public AuthorizationPatient()
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

        private void PatientAuthorization_Load(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Hide();
            MainPage.form1Main.Show();
        }

        private async void SignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var context = new DBApplicationContext();
                var newPatient = new EPatient(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExPatient = Repository<EPatient>
                    .GetRepo(context)
                    .GetFirst(patient => patient.Id == newPatient.Id);
                if (preExPatient != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such patient already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExPatient = Repository<EPatient>
                            .GetRepo(context)
                            .GetFirst(patient => patient.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExPatient.SecondName + " " + preExPatient.FirstName + " managed to sing in!");
                        await fileOperations.CloseAndOpenPatient(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    }
                    else return;
                }
                else
                {
                    await dataHelper.OnPlacePatientCreation(context, newPatient, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }

        private async void LogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var context = new DBApplicationContext();
                var newPatient = new EPatient(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExPatient = Repository<EPatient>
                    .GetRepo(context)
                    .GetFirst(patient => patient.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExPatient != null) && (preExPatient.FirstName == FirstNameTxtBox.Text) && (preExPatient.SecondName == SecondNameTxtBox.Text)
                    && (preExPatient.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExPatient.SecondName + " " + preExPatient.FirstName + " managed to sing in!");
                    await fileOperations.CloseAndOpenPatient(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such patient doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await dataHelper.OnPlacePatientCreation(context, newPatient, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    }
                    else return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: \n" + ex);
            }
        }
    }
}
