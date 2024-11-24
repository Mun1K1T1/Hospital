using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class AuthorizationCleaningWorker : MaterialForm, IForm
    {
        private readonly IFileOperations _fileOperations;
        private readonly DataHelper _dataHelper;
        private readonly DBApplicationContext _dbContext;

        public void ShowForm()
        {
            Show();
        }

        public AuthorizationCleaningWorker(IFileOperations fileOperations, DataHelper dataHelper, DBApplicationContext dbContext)
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

        public AuthorizationCleaningWorker()
        {
        }

        private void AuthorizationCleaningWorker_Load(object sender, EventArgs e)
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
                var newCleaningWorker = new ECleaningServiceWorker(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExCleaningWorker = Repository<ECleaningServiceWorker>
                    .GetRepo(_dbContext)
                    .GetFirst(CleaningWorker => CleaningWorker.Id == newCleaningWorker.Id);
                if (preExCleaningWorker != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such Cleaning Worker already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExCleaningWorker = Repository<ECleaningServiceWorker>
                            .GetRepo(_dbContext)
                            .GetFirst(CleaningWorker => CleaningWorker.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExCleaningWorker.SecondName + " " + preExCleaningWorker.FirstName + " managed to sing in!");
                        await _fileOperations.NeedToCloseToOpenCleaningWorker(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("CleaningWorker");
                        form.ShowForm();
                        Close();
                    }
                    else return;
                }
                else
                {
                    await _dataHelper.OnPlaceCleaningWorkerCreation(newCleaningWorker, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("CleaningWorker");
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
                var newCleaningWorker = new ECleaningServiceWorker(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExCleaningWorker = Repository<ECleaningServiceWorker>
                    .GetRepo(_dbContext)
                    .GetFirst(person => person.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExCleaningWorker != null) && (preExCleaningWorker.FirstName == FirstNameTxtBox.Text) && (preExCleaningWorker.SecondName == SecondNameTxtBox.Text)
                    && (preExCleaningWorker.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExCleaningWorker.SecondName + " " + preExCleaningWorker.FirstName + " managed to sing in!");
                    await _fileOperations.NeedToCloseToOpenCleaningWorker(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("CleaningWorker");
                    form.ShowForm();
                    Close();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such Cleaning Worker doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await _dataHelper.OnPlaceCleaningWorkerCreation(newCleaningWorker, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("CleaningWorker");
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
