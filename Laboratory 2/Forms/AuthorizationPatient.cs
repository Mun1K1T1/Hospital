using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace Laboratory_2.Forms
{
    public partial class AuthorizationPatient : MaterialForm, IForm
    {
        public const string patientSubPath = @"C:\\DataBase\PatientData\";

        private readonly IFileOperations _fileOperations;
        private readonly DataHelper _dataHelper;
        private readonly DBApplicationContext _dbContext;

        public void ShowForm()
        {
            Show();
        }

        public AuthorizationPatient(IFileOperations fileOperations, DataHelper dataHelper, DBApplicationContext dbContext)
        {
            _fileOperations = fileOperations ?? throw new ArgumentNullException(nameof(fileOperations));
            _dataHelper = dataHelper ?? throw new ArgumentNullException(nameof(dataHelper));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

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

        public AuthorizationPatient()
        {
        }

        private void PatientAuthorization_Load(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            IForm form = FormFactory.CreateForm("MainPage");
            form.ShowForm();
            Close();
        }

        private async void SignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var newPatient = new EPatient(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExPatient = Repository<EPatient>
                    .GetRepo(_dbContext)
                    .GetFirst(patient => patient.Id == newPatient.Id);
                if (preExPatient != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such patient already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExPatient = Repository<EPatient>
                            .GetRepo(_dbContext)
                            .GetFirst(patient => patient.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExPatient.SecondName + " " + preExPatient.FirstName + " managed to sing in!");
                        await _fileOperations.NeedToCloseToOpenPatient(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Patient");
                        form.ShowForm();
                        Close();
                    }
                    else return;
                }
                else
                {
                    await _dataHelper.OnPlacePatientCreation(newPatient, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Patient");
                    form.ShowForm();
                    Close();
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
                var newPatient = new EPatient(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExPatient = Repository<EPatient>
                    .GetRepo(_dbContext)
                    .GetFirst(patient => patient.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExPatient != null) && (preExPatient.FirstName == FirstNameTxtBox.Text) && (preExPatient.SecondName == SecondNameTxtBox.Text)
                    && (preExPatient.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExPatient.SecondName + " " + preExPatient.FirstName + " managed to sing in!");
                    await _fileOperations.NeedToCloseToOpenPatient(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Patient");
                    form.ShowForm();
                    Close();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such patient doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await _dataHelper.OnPlacePatientCreation(newPatient, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Patient");
                        form.ShowForm();
                        Close();
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
