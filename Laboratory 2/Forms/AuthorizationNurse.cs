using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2.Forms
{
    public partial class AuthorizationNurse : MaterialForm, IForm
    {
        public const string nurseSubPath = @"C:\\DataBase\NurseData\";

        private readonly IFileOperations _fileOperations;
        private readonly DataHelper _dataHelper;
        private readonly DBApplicationContext _dbContext;

        public void ShowForm()
        {
            Show();
        }

        public AuthorizationNurse(IFileOperations fileOperations, DataHelper dataHelper, DBApplicationContext dbContext)
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

        public AuthorizationNurse()
        {
        }

        private void AuthorizationNurse_Load(object sender, EventArgs e)
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
                var newNurse = new ENurse(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExNurse = Repository<ENurse>
                    .GetRepo(_dbContext)
                    .GetFirst(nurse => nurse.Id == newNurse.Id);
                if (preExNurse != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such nurse already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExNurse = Repository<ENurse>
                            .GetRepo(_dbContext)
                            .GetFirst(doctor => doctor.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExNurse.SecondName + " " + newPreExNurse.FirstName + " managed to sing in!");
                        await _fileOperations.NeedToCloseToOpenNurse(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Nurse");
                        form.ShowForm();
                        Close();
                    }
                    else return;
                }
                else
                {
                    await _dataHelper.OnPlaceNurseCreation(newNurse, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Nurse");
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
                var newNurse = new ENurse(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExNurse = Repository<ENurse>
                    .GetRepo(_dbContext)
                    .GetFirst(nurse => nurse.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExNurse != null) && (preExNurse.FirstName == FirstNameTxtBox.Text) && (preExNurse.SecondName == SecondNameTxtBox.Text)
                    && (preExNurse.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExNurse.SecondName + " " + preExNurse.FirstName + " managed to sing in!");
                    await _fileOperations.NeedToCloseToOpenNurse(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("Nurse");
                    form.ShowForm();
                    Close();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such patient doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await _dataHelper.OnPlaceNurseCreation(newNurse, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("Nurse");
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
