using Laboratory_2.Data.Models.Data;
using Laboratory_2.Repositories;
using Laboratory_2.Repositories.FormFactory;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Laboratory_2
{
    public partial class AuthorizationCleaningManager : MaterialForm, IForm
    {
        private readonly IFileOperations _fileOperations;
        private readonly DataHelper _dataHelper;
        private readonly DBApplicationContext _dbContext;

        public void ShowForm()
        {
            Show();
        }

        public AuthorizationCleaningManager(IFileOperations fileOperations, DataHelper dataHelper, DBApplicationContext dbContext)
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

        public AuthorizationCleaningManager()
        {
        }

        private void AuthorizationCleaningManager_Load(object sender, EventArgs e)
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
                var newCleaningManager = new ECleaningServiceManager(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExCleaningManager = Repository<ECleaningServiceManager>
                    .GetRepo(_dbContext)
                    .GetFirst(CleaningManager => CleaningManager.Id == newCleaningManager.Id);
                if (preExCleaningManager != null)
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign in?", "Such Cleaning Manager already exists!", MessageBoxButtons.YesNo);
                    if (msBoxResult == DialogResult.Yes)
                    {
                        var newPreExCleaningManager = Repository<ECleaningServiceManager>
                            .GetRepo(_dbContext)
                            .GetFirst(CleaningManager => CleaningManager.Id == Convert.ToInt32(IdTxtBox.Text));

                        MessageBox.Show($"Congratulations!\n" + newPreExCleaningManager.SecondName + " " + preExCleaningManager.FirstName + " managed to sing in!");
                        await _fileOperations.NeedToCloseToOpenCleaningManager(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("CleaningWorker");
                        form.ShowForm();
                        this.Close();
                    }
                    else return;
                }
                else
                {
                    await _dataHelper.OnPlaceCleaningManagerCreation(newCleaningManager, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("CleaningWorker");
                    form.ShowForm();
                    this.Close();
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
                var newCleaningManager = new ECleaningServiceManager(Convert.ToInt32(IdTxtBox.Text), FirstNameTxtBox.Text, SecondNameTxtBox.Text);
                var preExCleaningManager = Repository<ECleaningServiceManager>
                    .GetRepo(_dbContext)
                    .GetFirst(person => person.Id == Convert.ToInt32(IdTxtBox.Text));

                if ((preExCleaningManager != null) && (preExCleaningManager.FirstName == FirstNameTxtBox.Text) && (preExCleaningManager.SecondName == SecondNameTxtBox.Text)
                    && (preExCleaningManager.Id == Convert.ToInt32(IdTxtBox.Text)))
                {
                    MessageBox.Show($"Congratulations!\n" + preExCleaningManager.SecondName + " " + preExCleaningManager.FirstName + " managed to sing in!");
                    await _fileOperations.NeedToCloseToOpenCleaningManager(IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                    IForm form = FormFactory.CreateForm("CleaningWorker");
                    form.ShowForm();
                    this.Close();
                }
                else
                {
                    var msBoxResult = MessageBox.Show("Would you like to sign up?", "Such Cleaning Manager doesn't exist!", MessageBoxButtons.OKCancel);
                    if (msBoxResult == DialogResult.OK)
                    {
                        await _dataHelper.OnPlaceCleaningManagerCreation(newCleaningManager, IdTxtBox, FirstNameTxtBox, SecondNameTxtBox, this);
                        IForm form = FormFactory.CreateForm("CleaningWorker");
                        form.ShowForm();
                        this.Close();
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
