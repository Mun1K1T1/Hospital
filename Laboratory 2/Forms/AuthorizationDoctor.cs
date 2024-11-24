using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2.Forms
{
    public partial class AuthorizationDoctor : MaterialForm, IForm
    {
        public const string docSubPath = @"C:\\DataBase\DocData\";

        private readonly IFileOperations _fileOperations;
        private readonly DataHelper _dataHelper;
        private readonly DBApplicationContext _dbContext;

        public void ShowForm()
        {
            Show();
        }

        public AuthorizationDoctor(IFileOperations fileOperations, DataHelper dataHelper, DBApplicationContext dbContext)
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

        public AuthorizationDoctor()
        {
        }

        private void DoctorAuthorization_Load(object sender, EventArgs e)
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
                var newDoctor = new EDoctor(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExDoctor = Repository<EDoctor>
                    .GetRepo(_dbContext)
                    .GetFirst(doctor => doctor.Id == newDoctor.Id);
                if (preExDoctor != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such doctor already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExDoctor = Repository<EDoctor>
                            .GetRepo(_dbContext)
                            .GetFirst(doctor => doctor.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExDoctor.SecondName + " " + newPreExDoctor.FirstName + " managed to sing in!");
                        await _fileOperations.NeedToCloseToOpenDoctor(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Doctor");
                        form.ShowForm();
                        Close();
                    }
                    else return;
                }
                else
                {
                    await _dataHelper.OnPlaceDoctorCreation(newDoctor, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Doctor");
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
                var newDoctor = new EDoctor(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExDoctor = Repository<EDoctor>
                    .GetRepo(_dbContext)
                    .GetFirst(doctor => doctor.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExDoctor != null) && (preExDoctor.FirstName == FirstNameTxtBox.Text) && (preExDoctor.SecondName == SecondNameTxtBox.Text)
                    && (preExDoctor.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExDoctor.SecondName + " " + preExDoctor.FirstName + " managed to sing in!");
                    await _fileOperations.NeedToCloseToOpenDoctor(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Doctor");
                    form.ShowForm();
                    Close();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such patient doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await _dataHelper.OnPlaceDoctorCreation(newDoctor, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Doctor");
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
